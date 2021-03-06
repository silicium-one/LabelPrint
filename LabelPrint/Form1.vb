﻿Imports System.ComponentModel
Imports System.Globalization
Imports LabelPrint.IniFile
Imports System.IO.Ports
Imports System.IO
Imports System.Threading
Imports System.Text
Imports System.Data.Odbc
Imports System.Reflection
Imports LabelPrint.My
Imports LabelPrint.sb_tamesEmployeesDataSetTableAdapters


Public Class Form1

    Delegate Sub UpdateTextDelegate()
    Private Delegate Sub ProcessScannersignalDelegate(spName As String, indata As String)
    Private Delegate Sub ProcessEoLsignalDelegate(spName As String, indata As String)

    'flag for open order: True/False
    Public OrderOpen As Boolean = False
    Public PackFactor As Integer
    Public TotalPartsInOrder As Integer
    Public CurentCustomerLabel As String = vbNullString
    Public IsError As Boolean
    Public IsReajustingWarningNeedToSendToController As Boolean = False ' ставится в ИСТИНУ после сканирования очередного изделия (после которого надо уведомить), сбрасывается после того, как контроллер подтвердит приём сигнала об уведомлении о переналадке
    Public IsReajustingNeedToSendToController As Boolean = False ' ставится в ИСТИНУ после сканирования последнего изделия в заказе, сбрасывается после того, как контроллер подтвердит приём сигнала о переналадке (или может не ждём подтверждения ? )
    Public IndexOfEol As Integer = -1

    Public EoLtime As Date
    Public EoLtimeOut As Integer

    Public Hlbltime As Date
    Public HlbltimeOut As Integer
    Public StopOrderTimer As Integer

    Public CustomerLabeltype As String = vbNullString

    'name of the line
    Public LineName As String
    ' key pressed
    Public Keyspressed As String

    Public OrderPn As String

    Public EolDataBuffer As String

    'serialports asigned to the scanners
    Public WithEvents SerialCom As SerialPort

    Private ReadOnly _monitorSp As New List(Of SerialPort)
    'набор таймеров для отслеживания состояния линии (1 перерыв - 2 таймера + 1 не перевзводку в конце суток) 
    Private ReadOnly _breakTimers As New List(Of Timer)

    Private ReadOnly _objini As New IniFile
    Private ReadOnly _iniPath As String = Windows.Forms.Application.StartupPath & "\LabelPrint.ini"

    Private ReadOnly _curentInfoIni As New IniFile
    Private ReadOnly _curentIniPath As String = System.Windows.Forms.Application.StartupPath & "\CurentInfo.ini"
    
    Private ReadOnly _eoLcodes As New Dictionary(Of String, String) ' коды ошибок от контроллера
    Private ReadOnly _eoLcodesOk As New List(Of String) ' коды завершения  простоев и переналадок от контроллера


    Private ReadOnly _permitBClist As New Dictionary(Of String, String) ' ключ - последние 4 цифры ШК с бейджика, значеие - Фамилия или что там будет

    Private ReadOnly _controlledByScanner As New Dictionary(Of String, Control) ' Список контролов Form1, которые контролирует сканер. Грузится из ini-файла
    
    'время на работу за вычетом времени на запланированные перерывы и простои, для каждого часа суток (до 7 утра обычно 0, потом начинает расти)
    'заполняется всякий раз, когда выполняется вычисление производительности
    Private ReadOnly _workTimeInMinuts(0 To 23) As UInt32

    Private _reajustingWarningEol As String = "400" ' код оповещения о предупреждении о скорой переналадке по умолчанию, берётся из файла ini
    Private _reajustingEol As String = "401" ' код оповещения о переналадке по умолчанию, берётся из файла ini

    Private _beginOfInterruptTime As Date?
    Private _beginOfRepairInterruptTime As Date?
    Private _whoIsLast As String = String.Empty
    Private _endOfInterruptTime As Date?

    Private _isLineBreaked As Boolean = False
    Private _lineStateCode As String '= "100"

    Dim WithEvents _currentPerformanceCounter As New PerformanceClaculator
    Dim _plannedProductivity As New Dictionary(Of String, Integer) ' ключ - деталь, значение  количество заггтовок в час
    Dim _enterKeyByScanner As String = String.Empty ' код со сканера, соответсвующий клавише Enter

    Protected Property IsLineBreaked As Boolean
        Get
            Return _isLineBreaked
        End Get
        Set(value As Boolean)
            _isLineBreaked = value
            UpdateLineState()
        End Set
    End Property

    Public Property LineStateCode As String
        Get
            Return _lineStateCode
        End Get
        Set(value As String)
            If _eoLcodes.ContainsKey(_lineStateCode) And _eoLcodesOk.Contains(value) Then 'end interrupt todo: убрать хардкод на годную деталь
                _endOfInterruptTime = NowTimeRoundToMinute()

                T_linesInterruptsTableAdapter.InsertQuery(_beginOfInterruptTime, "Заполнить!", LineName, "Заполнить!",
                                              _beginOfInterruptTime, _beginOfRepairInterruptTime, _endOfInterruptTime, _lineStateCode,
                                              "Заполнить!", "Заполнить!", _whoIsLast)
                Me.T_linesInterruptsTableAdapter.FillAndCalculate(Me.Sb_tamesInterruptsDataSet.t_linesInterrupts)
                _beginOfInterruptTime = Nothing
                _beginOfRepairInterruptTime = Nothing
                _endOfInterruptTime = Nothing
                _whoIsLast = String.Empty

                _lineStateCode = value
                UpdateLineState()
            ElseIf _eoLcodesOk.Contains(_lineStateCode) And _eoLcodes.ContainsKey(value) Then 'begin interrupt
                _beginOfInterruptTime = NowTimeRoundToMinute()
                _lineStateCode = value
                UpdateLineState()
            End If
        End Set
    End Property

    Public Function ExportInterruptsToCsv(srcTable As DataGridView) As String
        Dim result = New StringBuilder
        For i = 0 To srcTable.Columns.Count - 1
            result.Append(Chr(34).ToString())
            result.Append(srcTable.Columns(i).HeaderText)
            result.Append(Chr(34).ToString())
            result.Append(";")
        Next
        result.Remove(result.Length - 1, 1)
        result.AppendLine()

        For Each row As DataGridViewRow In srcTable.Rows
            For i = 0 To srcTable.Columns.Count - 1
                result.Append(Chr(34).ToString())
                result.Append(row.Cells(i).Value)
                result.Append(Chr(34).ToString())
                result.Append(";")
            Next
            result.Remove(result.Length - 1, 1)
            result.AppendLine()
        Next
        'Return result.ToString()
        Dim ascii = Encoding.GetEncoding("windows-1251")
        Dim unicode As Encoding = Encoding.UTF8
        Dim unicodeBytes = unicode.GetBytes(result.ToString())
        Dim asciiBytes = Encoding.Convert(unicode, ascii, unicodeBytes)
        Dim asciiChars(ascii.GetCharCount(asciiBytes, 0, asciiBytes.Length)) As Char ' todo: optimize
        ascii.GetChars(asciiBytes, 0, asciiBytes.Length, asciiChars, 0)
        Dim asciiString = New String(asciiChars)
        Return asciiString
    End Function
    
    Private Sub currentPerformanceCounter_ReajustingWarningEvent() Handles _currentPerformanceCounter.ReajustingWarningEvent
        'MsgBox("Скоро переналадка") 'TODO: только для отладки
        IsReajustingNeedToSendToController = False
        IsReajustingWarningNeedToSendToController = True
    End Sub

    Private Sub currentPerformanceCounter_ReajustingEvent() Handles _currentPerformanceCounter.ReajustingEvent
        'MsgBox("Переналадка началась") 'TODO: только для отладки
        'IsReajustingNeedToSendToController = True
        'IsReajustingWarningNeedToSendToController = False
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim version = Assembly.GetExecutingAssembly().GetName().Version
            Text += " " + version.Major.ToString() + "." + version.Minor.ToString() + "." + version.Build.ToString()
#If VERSION_TYPE = "a" Then
            Text += " a"
            Me.TabControl1.Controls.Remove(TabPageBreaks)
            Me.TabControl1.Controls.Remove(TabPageInterrupts)
#ElseIf VERSION_TYPE = "b" Then
            Text += " b"
#End If

            Me.Enabled = False
            Refresh()
            TabControlIndex.Alignment = TabAlignment.Bottom
            PanelStartOrder.Size = New Size(Me.Size.Width - 20, PanelStartOrder.Size.Height)
            PanelError.Size = New Size(Me.Size.Width - 20, PanelError.Size.Height)
            PanelWarning.Size = New Size(Me.Size.Width - 20, PanelWarning.Size.Height)
            PanelScanMaster.Size = New Size(Me.Size.Width - 20, PanelScanMaster.Size.Height)

            For Each c As Control In Me.Controls
                AddHandler c.KeyDown, AddressOf Form1_KeyDown
            Next

            Writelog("Application Started")

            'check the existance of LabelPrint.ini in current app path
            If Not File.Exists(_iniPath) Then
                MessageBox.Show("LabelPrint.ini is missing!!!" & vbNewLine & "Program cannot start without this file", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Writelog("LabelPrint.ini not found. Application Close")
                Me.Close()
            End If

            LoadSettings()

            'load order if it is opened
            _curentInfoIni.Load(_curentIniPath)
            Dim corder As String = _curentInfoIni.GetKeyValue("CurentInfo", "order")

            'load settings from t_settings table
            Try
                T_SettingsTableAdapter1.Fill(Ru_sb_tames1.t_Settings)
            Catch ex As Exception
                MsgBox("Error connecting to server!" & vbNewLine & "Please check connection string first" & vbNewLine & ex.ToString)
                Me.Close()
            End Try

            If corder <> vbNullString Then
                sub_Start_Order(corder, False)
            End If

            'TODO: данная строка кода позволяет загрузить данные в таблицу "Sb_tamesInterruptsLineIDDataSet.t_linesInterrupts". При необходимости она может быть перемещена или удалена.
            Me.T_linesInterruptsLineIDTableAdapter.Fill(Me.Sb_tamesInterruptsLineIDDataSet.t_linesInterrupts)
            'TODO: данная строка кода позволяет загрузить данные в таблицу "Sb_tamesInterruptsDataSet.t_linesInterrupts". При необходимости она может быть перемещена или удалена.
            Me.T_linesInterruptsTableAdapter.FillAndCalculate(Me.Sb_tamesInterruptsDataSet.t_linesInterrupts)
            'TODO: данная строка кода позволяет загрузить данные в таблицу "Sb_tamesBreaksDataSet.t_linesBreaks". При необходимости она может быть перемещена или удалена.
            Me.T_linesBreaksTableAdapter.Fill(Me.Sb_tamesBreaksDataSet.t_linesBreaks)
            RespawnLineStateTimers()

            'заполнение данных о бейджиках сотрудников
            Dim tEmployeesAdapter = New t_EmployeesTableAdapter()
            tEmployeesAdapter.Fill((New sb_tamesEmployeesDataSet).t_Employees)
            Dim dataTable = tEmployeesAdapter.GetData()
            _permitBClist.Clear()
            With dataTable
                For row = 0 To dataTable.Rows.Count - 1
                    Dim bc = .Rows(row).Item("BC").ToString()
                    Dim name = .Rows(row).Item("Name").ToString()
                    Try
                        bc = bc.Substring(bc.Length - 4, 4)
                    Catch ex As ArgumentOutOfRangeException
                        Debug.WriteLine("Wrong BC:" + bc + ", ignoring")
                        Continue For
                    End Try
                    Debug.WriteLine(bc + ":" + name)
                    Try
                        _permitBClist.Add(bc, name)

                    Catch ex As Exception

                    End Try
                Next
            End With

            'currentPerformanceCounter.QuantityTotal = 50 'todo: заполнить при открытии заказа чем-то конкретным
            'currentPerformanceCounter.PlannedPerformance = 120 'Заполнение происходит при сканировании заготовки
            'currentPerformanceCounter.TimeSpanReajusting = TimeSpan.FromMinutes(5) 'берём из ini файла

            Me.Enabled = True

            BreaksIDDataGridViewTextBoxColumn.Visible = False
            InterruptsIDDataGridViewTextBoxColumn.Visible = False ' VS Designer bugfix
            InterruptsNoDataGridViewTextBoxColumn.Visible = False
            ' Refresh()

        Catch ex As NullReferenceException ' VS designer bugfix too
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub LoadSettings()
        Try
            'objini = New IniFile
            _objini.Load(_iniPath)

            'modify connection string
            Dim uConnStr As String = _objini.GetKeyValue("TPRULabelPrint", "connString")

            If uConnStr <> vbNullString Then
                Writelog("Changing ConnStr: " & Settings.Item("ru_sb_tames"))
                Settings.Item("ru_sb_tames") = uConnStr
                Settings.Save()
                Writelog("New ConnStr: " & Settings.Item("ru_sb_tames"))
            End If

            'loop trough com ports -----------------------------------------------------------------------------------------------------------

            For Each s As IniSection.IniKey In _objini.GetSection("COMPorts").Keys
                'INPUT SERIAL DEVICES ------------------------------------------------------------------------------------------------------------------------------
                '---------------------------------------------------------------------------------------------------------------------------------------------------
                'Ports for scanners -----------------------------------------------------------------------------------------------------------

                If Mid(s.Name, 1, 7) = "Scanner" Then
                    SerialCom = New SerialPort
                    SerialCom.PortName = s.Value

                    If Not SerialCom.IsOpen Then
                        AddHandler SerialCom.DataReceived, AddressOf ScanDataReceivedHandler
                        SerialCom.Open()
                        _monitorSp.Add(SerialCom)
                        Writelog("Assign " & s.Name & ": " & s.Value)
                    Else

                    End If
                End If

                'Port for EOL -----------------------------------------------------------------------------------------------------------

                If Mid(s.Name, 1, 3) = "EOL" Then
                    SerialCom = New SerialPort
                    SerialCom.PortName = s.Value
                    SerialCom.Parity = Parity.Even
                    If Not SerialCom.IsOpen Then
                        AddHandler SerialCom.DataReceived, AddressOf EOLDataReceivedHandler
                        SerialCom.Open()
                        _monitorSp.Add(SerialCom)
                        IndexOfEol = _monitorSp.Count - 1

                        Dim tim As String = _objini.GetKeyValue("COMTimeOut", s.Value)

                        If IsNumeric(tim) Then
                            EoLtimeOut = tim
                        End If

                        Writelog("Assign " & s.Name & ": " & s.Value & ", Signal interval: " & tim & " s")

                    Else

                    End If
                End If

                'port for label Homologation Print signal -----------------------------------------------------------------------------------------------------------

                If s.Name = "HLabelSgn" Then
                    SerialCom = New SerialPort
                    SerialCom.PortName = s.Value
                    SerialCom.Parity = Parity.Even
                    If Not SerialCom.IsOpen Then
                        AddHandler SerialCom.DataReceived, AddressOf HLabelSgnDataReceivedHandler
                        SerialCom.Open()
                        _monitorSp.Add(SerialCom)

                        Dim tim As String = _objini.GetKeyValue("COMTimeOut", s.Value)

                        If IsNumeric(tim) Then
                            HlbltimeOut = tim
                        End If

                        Writelog("Assign Homologation Label Print Signal: " & s.Value & ", Signal interval: " & tim & " s")
                    End If
                End If

            Next

            'get line name and write it to statusbar
            LineName = _objini.GetKeyValue("LineInfo", "LineName")

            If LCase(_objini.GetKeyValue("TPRULabelPrint", "testMode")) = "no" Then
                'if On production Mode
                TestMode()
            End If



            If LineName <> vbNullString Then
                ToolStripStatusLabelLineName.Text = LineName
            Else
                MessageBox.Show("Invalid Line Name!!!")
                ToolStripStatusLabelLineName.Text = "!!! INVALID LINE NAME !!!"
            End If


            If LCase(_objini.GetKeyValue("TPRULabelPrint", "lineType")) <> "final" Then

                PanelProductivity.Visible = False

            End If

            'коды ошибок от контроллера
            _eoLcodes.Clear()
            _currentPerformanceCounter.TimeSpanReajusting = TimeSpan.FromMinutes(5)
            For Each s As IniSection.IniKey In _objini.GetSection("EOLSignals").Keys
                If s.Name.Trim() = "readjustingWarning" Then
                    _reajustingWarningEol = s.Value.Trim()
                ElseIf s.Name.Trim() = "readjusting" Then
                    _reajustingEol = s.Value.Trim()
                ElseIf s.Name.Trim() = "warningTime_s" Then
                    Dim seconds As Integer
                    If Integer.TryParse(s.Value.Trim(), seconds) Then
                        _currentPerformanceCounter.TimeSpanReajusting = TimeSpan.FromSeconds(seconds)
                    End If
                Else
                    _eoLcodes.Add(s.Name.Trim(), s.Value.Trim())
                End If
            Next

            'формирование списка контролов, которые управляются со сканера. В настоящий момент поддерживаются только элементы управления типа Button
            _controlledByScanner.Clear()
            Dim allButtons = FindAllButtons(Me)
            For Each s As IniSection.IniKey In _objini.GetSection("ScannerKbd").Keys
                If allButtons.ContainsKey(s.Value.Trim()) Then
                    _controlledByScanner.Add(s.Name.Trim(), allButtons(s.Value.Trim()))
                ElseIf s.Value.Trim() = "{EnterKey}" Then
                    _enterKeyByScanner = s.Name.Trim()
                End If
            Next

            'загрузка продуктивности по умолчанию
            Try
                _plannedProductivity = PpFromCsv(_objini.GetKeyValue("Productivity", "defaultFile"))
            Catch ex As Exception

            End Try

            Windows.Forms.Application.DoEvents()

            Refresh()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Shared Function FindAllButtons(var As Control) As Dictionary(Of String, Button)
        Dim ret = New Dictionary(Of String, Button)
        For Each control As Control In var.Controls
            If TypeOf control Is Button Then
                ret.Add(control.Name, control)
            Else
                Dim btns = FindAllButtons(control)
                For Each btn As KeyValuePair(Of String, Button) In btns
                    ret.Add(btn.Key, btn.Value)
                Next
            End If
        Next
        Return ret
    End Function

    Private Sub TestMode()
        Me.FormBorderStyle = FormBorderStyle.None
        Me.WindowState = FormWindowState.Maximized
        Me.ListBoxLog.Visible = False
        Me.TabControlIndex.TabPages.RemoveAt(1)

    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            For Each port As SerialPort In _monitorSp
                If port.IsOpen Then
                    port.Close()
                    Writelog(port.PortName & " closed")
                End If
            Next
        Catch
        End Try
        Writelog("Application Close")
    End Sub

    Private Sub ScanDataReceivedHandler(sender As Object, e As SerialDataReceivedEventArgs)
        Try

            Dim sp = CType(sender, SerialPort)
            Thread.Sleep(100)

            Dim indata As String = Trim(Replace(sp.ReadExisting(), vbCrLf, vbNullString))

            If Me.InvokeRequired Then
                Me.Invoke(New ProcessScannersignalDelegate(AddressOf ProcessScannerSignal), New Object() {sp.PortName, indata})
            Else
                Me.ProcessScannerSignal(sp.PortName, indata)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    
    Private Sub ProcessScannerSignalOperatorBeginOrder(spName As String, indata As String)
        'orderPN -  the data scanned from AS400 order
        'indata - current scanned data

        If Len(indata) > 6 And PanelStartOrder.Visible = True Then

            If IsNumeric(Mid(indata, 1, 6)) Then

                OrderPn = TrimInfo(indata)
                ListBoxLog.Items.Add(Now.ToString("dd.MM.yyyy HH:mm:ss") & ": Leitzahl: <" & OrderPn.Substring(0, 6) & ">    PartNo: <" & OrderPn.Substring(6) & ">")
                ListBoxLog.SelectedIndex = ListBoxLog.Items.Count - 1
                PanelScanMaster.Visible = True
                PanelStartOrder.Visible = False

                Exit Sub

                'sub_Start_Order(indata, True)

            End If

        End If

        If PanelScanMaster.Visible = True And OrderPn <> vbNullString Then

            If indata.Substring(0, 1) = "L" Then

                indata = indata.Substring(1)

                If Len(OrderPn) > 6 Then

                    If OrderPn.Substring(6) = indata Then

                        sub_Start_Order(OrderPn, True)

                    Else

                        If CultureInfo.CurrentUICulture.ToString = "ru-RU" Then
                            SetError("Изделие отличается от Главного Образца")
                        Else
                            SetError("PART DIFFERENT THEN MASTER")
                        End If


                    End If

                End If
            Else

                If CultureInfo.CurrentUICulture.ToString = "ru-RU" Then

                    SetError("Штрих-код недействителен; первая буква должна быть 'L'")

                Else

                    SetError("INVALID BARCODE FORMAT; FIRST LETTER MUST BE 'L'")

                End If


            End If

        End If

    End Sub

    Private Sub ProcessScannerSignalOperator(spName As String, indata As String)
        'reset close order warning interval
        WarningInterval()

        ListBoxLog.Items.Add(Now.ToString("dd.MM.yyyy HH:mm:ss") & ": " & spName & ": " & indata)
        ListBoxLog.SelectedIndex = ListBoxLog.Items.Count - 1
        ToolStripStatusLabelCurentInfo.Text = "[" & Now & "]  Input Data: Scanner"

        ' возможно, отсканированный ШК - управляющая последовательность, проверяем
        If _controlledByScanner.ContainsKey(indata.Trim()) Then
            CType(_controlledByScanner(indata.Trim()), Button).PerformClick()
            Exit Sub
        ElseIf indata.Trim() = _enterKeyByScanner Then
            SendKeys.Send("~") ' клваиша ENTER активному приложению
        End If

        'start production order

        If OrderOpen = False Then
            ProcessScannerSignalOperatorBeginOrder(spName, indata)
        End If

        'check for clientlabel format

        If OrderOpen = True And IsError = False Then

            ' возможное сканирование кода сторудника при случившимся простое
            Try
                Dim permitBc = indata.Substring(indata.Length - 4, 4)
                If _permitBClist.ContainsKey(permitBc) And _eoLcodes.ContainsKey(LineStateCode) Then
                    _beginOfRepairInterruptTime = NowTimeRoundToMinute()
                    _whoIsLast = _permitBClist(permitBc)
                End If
            Catch ex As ArgumentOutOfRangeException
                'на случай сканирования кодов длинной меньше 4 символов
            End Try

            'c1 = BCInfo1 - Indicator of position in car (Ex: 2A,  2C)
            Dim c1 As String = DataGridViewOrders.Rows(0).Cells("ColumnBCInfo1").Value

            Dim partNo As String = DataGridViewOrders.Rows(0).Cells("ColumnpartNo").Value
            'clear revision
            Dim partNoFr As String = vbNullString

            If InStr(partNo, "-") > 0 Then
                partNoFr = partNo.Substring(0, InStr(partNo, "-"))
            Else
                partNoFr = partNo
            End If

            'spCode  = Supplyer Code

            Dim spCode As String = Ru_sb_tames1.t_Settings.Select("varName = 'SupplyerCode'").GetValue(0).item("varValue")  'Ru_sb_tames1.t_partList.Select("partNo = '" & partNoFR & "'").GetValue(0).item("suppliercode")
            Dim factoryNo As String = Ru_sb_tames1.t_Settings.Select("varName = 'FactoryNo'").GetValue(0).item("varValue")

            Dim custBc As String = c1 & spCode

            '------------------------------Check the content of barcode scanned ----------------------------------------------------------------------------------------------------------------------

            'If Not IsDBNull(customerLabeltype) Then

            If CustomerLabeltype = "EZE_GUT" Then
                'Check Wite Label (Nissan) format

                Dim curentYear As String = Mid(Now.ToString("yyyy"), 4, 1)

                Dim prodLine As String = DataGridViewOrders.Rows(0).Cells("ColumnLine").Value

                Dim factoryNumber As String = Ru_sb_tames1.t_Settings.Select("varName = 'FactoryNo'").GetValue(0).Item("varValue")

                Dim lineIdentification As String = Mid(prodLine, Len(prodLine))

                'Unique number for every part:   31 2 4 233 001

                'Factory Number (XX) + Line Identificator (X) + Year Identificator 201(4) + Day Identificator (XXX) + Alphanumeric Serial (XXX) -> from database

                custBc = c1 & lineIdentification & curentYear & Now.DayOfYear.ToString("000")

                'indata = indata.Substring(1)

                If InStr(indata, custBc, CompareMethod.Text) > 0 Then

                    ListBoxLog.Items.Add(Now.ToString("dd.MM.yyyy HH:mm:ss") & ": " & indata)
                    ListBoxLog.SelectedIndex = ListBoxLog.Items.Count - 1

                    If T_labelsTableAdapter1.UpdateBoxNo(DataGridViewOrders.Rows(0).Cells("ColumnBoxNo").Value + 1, indata) = 1 Then
                        'if barcode was  found in DB with BoxNo = 0 then the box number was inserted
                        'update count
                        UpdatePartsInBoxCounter(CInt(_curentInfoIni.GetKeyValue("CurentInfo", "parts")) + 1)
                    Else

                        'if barcode was found in DB and the box number was already updated
                        'then display error

                        If T_labelsTableAdapter1.Countlabels(indata) > 0 Then

                            'display error message
                            If CultureInfo.CurrentUICulture.ToString = "ru-RU" Then
                                SetError("Штрих-код уже отсканирован")
                            Else
                                SetError("BARCODE ALLREADY SCANNED")
                            End If

                        Else

                            If CultureInfo.CurrentUICulture.ToString = "ru-RU" Then
                                SetError("Штрих-код не найден")
                            Else
                                SetError("BARCODE NOT FOUND")
                            End If


                        End If

                    End If
                End If

                Exit Sub
            End If
            'End If

            If InStr(indata, custBc, CompareMethod.Text) = 2 Then

                ListBoxLog.Items.Add(Now.ToString("dd.MM.yyyy HH:mm:ss") & ": " & indata)
                ListBoxLog.SelectedIndex = ListBoxLog.Items.Count - 1

                If Mid(indata, Len(indata) - 2) = "000" Then
                    Exit Sub
                End If

                If T_labelsTableAdapter1.UpdateBoxNo(DataGridViewOrders.Rows(0).Cells("ColumnBoxNo").Value + 1, indata) = 1 Then
                    'if barcode was  found in DB then the box number was inserted
                    'update count
                    UpdatePartsInBoxCounter(CInt(_curentInfoIni.GetKeyValue("CurentInfo", "parts")) + 1)
                Else

                    'if barcode was found in DB and the box number was already updated
                    'then display error

                    If T_labelsTableAdapter1.Countlabels(indata) > 0 Then

                        'display error message
                        If CultureInfo.CurrentUICulture.ToString = "ru-RU" Then
                            SetError("Штрих-код уже отсканирован")
                        Else
                            SetError("BARCODE ALLREADY SCANNED")
                        End If

                    Else

                        If CultureInfo.CurrentUICulture.ToString = "ru-RU" Then
                            SetError("Штрих-код не найден")
                        Else
                            SetError("BARCODE NOT FOUND")
                        End If


                    End If

                End If

            End If

        End If

        'Scanning of GAZ Sets

        If OrderOpen = True And IsError = False Then
            'if data scanned contains character _ then continue

            If InStr(indata, "_") > 0 Then

                'extract part number from scanned barcode
                Dim pn As String = Mid(indata, 1, InStr(indata, "_") - 1)


                If DataGridViewOrders.Rows(0).Cells("ColumnpartNo").Value = pn Then
                    'if part number from current order = part number scaned then

                    'insert scanned label into t_labels table 
                    Try
                        If T_labelsTableAdapter1.InsertNewLabel(indata, Now.ToString("dd.MM.yyyy"), Now.ToString("HH:mm:ss"),
                                                DataGridViewOrders.Rows(0).Cells("ColumnOrderNo").Value, _
                                                DataGridViewOrders.Rows(0).Cells("ColumnpartNo").Value, _
                                                DataGridViewOrders.Rows(0).Cells("ColumnCustPN").Value, _
                                                DataGridViewOrders.Rows(0).Cells("ColumnBoxNo").Value, _
                                                vbNullString, vbNullString, vbNullString, vbNullString) > 0 Then

                            UpdatePartsInBoxCounter(CInt(_curentInfoIni.GetKeyValue("CurentInfo", "parts")) + 1)

                        End If
                    Catch ex As Exception
                        'if error ocure, test to see if error text contains pk_t_labels.

                        If InStr(ex.ToString, "pk_t_labels") > 0 Then
                            SetError("BARCODE ALLREADY SCANNED")
                        Else
                            MsgBox(ex.ToString)
                        End If

                    End Try

                Else

                    If CultureInfo.CurrentUICulture.ToString = "ru-RU" Then
                        SetError("ошибочный номер детали")
                    Else
                        SetError("WRONG PART NUMBER")
                    End If

                End If

            End If

            'Homologation Label as internal Label

            If DataGridViewOrders.Rows(0).Cells("ColumnpartNo").Value = indata Then
                'Height Adjuster Label - Layout97.hlb
                'Scanned barcode = Takata Part Number

                Try
                    If T_labelsTableAdapter1.InsertNewLabel(indata, Now.ToString("dd.MM.yyyy"), Now.ToString("HH:mm:ss"),
                                            DataGridViewOrders.Rows(0).Cells("ColumnOrderNo").Value, _
                                            DataGridViewOrders.Rows(0).Cells("ColumnpartNo").Value, _
                                            DataGridViewOrders.Rows(0).Cells("ColumnCustPN").Value, _
                                            DataGridViewOrders.Rows(0).Cells("ColumnBoxNo").Value, _
                                            vbNullString, vbNullString, vbNullString, vbNullString) > 0 Then

                        UpdatePartsInBoxCounter(CInt(_curentInfoIni.GetKeyValue("CurentInfo", "parts")) + 1)

                    End If
                Catch ex As Exception
                    'if error ocure, test to see if error text contains pk_t_labels.

                    If InStr(ex.ToString, "pk_t_labels") > 0 Then
                        SetError("BARCODE ALLREADY SCANNED")
                    Else
                        MsgBox(ex.ToString)
                    End If

                End Try

            End If

        End If
    End Sub

    Private Sub ProcessScannerSignal(spName As String, indata As String)
        Try

            If TabControlIndex.SelectedTab Is TabPage1 Then
                ProcessScannerSignalOperator(spName, indata)
            ElseIf TabControlIndex.SelectedTab Is TabPage2 Then
                'for admnistration
                If Len(indata) > 6 Then

                    If IsNumeric(Mid(indata, 1, 6)) Then

                        tbo_Order.Text = Mid(indata, 1, 6)

                        cbo_partNo.Text = Mid(indata, 7)
                    End If

                End If
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    
    Private Sub UpdatePartsInBoxCounter(count As Integer) 'сюда попадаем в ходе сканирования этикетки на изделии
        Try
            'next signal count = 1
            If count > PackFactor Then
                count = 1
            End If

            'save count to curentInfo.ini
            _curentInfoIni.SetKeyValue("CurentInfo", "parts", count.ToString)

            If IsNumeric(_curentInfoIni.GetKeyValue("CurentInfo", "totalParts")) Then

                _curentInfoIni.SetKeyValue("CurentInfo", "totalParts", CInt(_curentInfoIni.GetKeyValue("CurentInfo", "totalParts")) + 1)

            Else

                _curentInfoIni.SetKeyValue("CurentInfo", "totalParts", 0)

            End If

            _currentPerformanceCounter.QuantityCurrent = CInt(_curentInfoIni.GetKeyValue("CurentInfo", "totalParts"))
            LabelPerformanceInfo.Text = _currentPerformanceCounter.ToString()
            LabelPerformanceInfo.ForeColor = _currentPerformanceCounter.LabelColor
            Debug.WriteLine("productivity: " + LabelPerformanceInfo.Text)

            DataGridViewOrders.Rows(0).Cells("ColumnOrderQty").Value = _curentInfoIni.GetKeyValue("CurentInfo", "totalParts")

            'save info
            _curentInfoIni.Save(_curentIniPath)

            'print BoxLabel when count = packfactor
            If count = PackFactor Then
                If T_orderListTableAdapter1.UpdateBoxNo(DataGridViewOrders.Rows(0).Cells("ColumnBoxNo").Value + 1, DataGridViewOrders.Rows(0).Cells("ColumnOrderNo").Value) > 0 Then
                    DataGridViewOrders.Rows(0).Cells("ColumnBoxNo").Value += 1
                    ToolStripStatusLabelCurentInfo.Text = "[" & Now & "]  BoxNumber changed"
                End If
                PrintBoxLabel()
                count = 0
            End If

            'show count on screen
            LabelLabelCount.Text = count.ToString & " / " & PackFactor.ToString

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub SetError(errMessage As String)
        Try
            IsError = True
            PanelError.Visible = True
            PanelError.BringToFront()
            LabelError.Text = errMessage
            ToolStripStatusLabelCurentInfo.Text = "[" & Now & "]  Error ocured"

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub sub_Start_Order(indata As String, fromScanner As Boolean)
        Try

            T_orderListTableAdapter1.FillByOrderNo(Ru_sb_tames1.t_orderList, CInt(Mid(indata, 1, 6)))

            If Ru_sb_tames1.t_orderList.Rows.Count > 0 Then

                ToolStripStatusLabelCurentInfo.Text = "[" & Now & "]  Starging Production Order"

                If Ru_sb_tames1.t_orderList.Select("orderNo = '" & CInt(Mid(indata, 1, 6)) & "'").GetValue(0).item("oStatus") = "Started" And fromScanner = True Then

                    MessageBox.Show("Order " & Mid(indata, 1, 6) & " already opened!", "Cannot start order!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub

                End If

                Dim partNo As Object = Ru_sb_tames1.t_orderList.Select("orderNo = '" & CInt(Mid(indata, 1, 6)) & "'").GetValue(0).item("partNo")
                Dim partNoFr As String = vbNullString


                If partNo <> Mid(indata, 7) Then

                    If CultureInfo.CurrentUICulture.ToString = "ru-RU" Then
                        MessageBox.Show("Отсканированный Серийный Номер не соответсвует номеру в Базе Данных!" & vbNewLine & Mid(indata, 7) & "<->" & partNo.ToString & vbNewLine & "Невозможно запустить Заказ!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Else
                        MessageBox.Show("Order PartNumber does not match with DataBase part number!" & vbNewLine & Mid(indata, 7) & "<->" & partNo.ToString & vbNewLine & "Order cannot start!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    End If

                    Exit Sub

                End If

                Dim orderQty = Ru_sb_tames1.t_orderList.Select("orderNo = '" & CInt(Mid(indata, 1, 6)) & "'").GetValue(0).item("orderQty")
                _currentPerformanceCounter.QuantityTotal = CInt(orderQty)
                Dim partNoFrShort As String = String.Empty

                If Not IsDBNull(partNo) Then
                    If InStr(partNo, "-", CompareMethod.Text) > 0 Then
                        partNoFr = Mid(partNo, 1, InStr(partNo, "-", CompareMethod.Text))
                        partNoFrShort = Mid(partNo, 1, InStr(partNo, "-", CompareMethod.Text) - 1)
                    Else
                        partNoFr = partNo
                        partNoFrShort = partNo
                    End If
                End If

                If _plannedProductivity.ContainsKey(partNoFrShort) Then
                    _currentPerformanceCounter.PlannedPerformance = _plannedProductivity(partNoFrShort)

                    'перевзводим таймер предупреждения о переналадке
                    _currentPerformanceCounter.TimeSpanReajusting = _currentPerformanceCounter.TimeSpanReajusting
                    IsReajustingNeedToSendToController = True
                    IsReajustingWarningNeedToSendToController = False

                    LabelPerformanceInfo.Visible = True
                    IsReajustingWarningNeedToSendToController = False
                    LabelPerformanceInfo.ForeColor = Color.Black
                    LabelPerformanceInfo.Text = "---/---"
                Else
                    MessageBox.Show("Отсутствует информация о производительности для серийного номера " & partNoFrShort & vbNewLine & "Невозможно запустить Заказ!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                T_partListTableAdapter1.FillByPartNo(Ru_sb_tames1.t_partList, partNoFr)

                If Ru_sb_tames1.t_partList.Rows.Count > 0 Then

                    Dim dgvr As New DataGridViewRow

                    dgvr.Height = 80

                    With Ru_sb_tames1.t_orderList.Select("orderNo = '" & CInt(Mid(indata, 1, 6)) & "'").GetValue(0)
                        dgvr.CreateCells(DataGridViewOrders, New Object() {
                                             StrDup(6 - Len(.Item("orderNo")), "0") & .Item("orderNo").ToString,
                                             .Item("orderQty"),
                                             .Item("partNo"),
                                             .Item("partDesc"),
                                             .Item("custpartNo"),
                                             .Item("custName"),
                                        Ru_sb_tames1.t_partList.Select("partNo = '" & partNoFr & "'").GetValue(0).Item("packfactor"), _
                                       .Item("BoxNo"),
                                       .Item("c1"),
                                       Ru_sb_tames1.t_partList.Select("partNo = '" & partNoFr & "'").GetValue(0).Item("DGSymbol"), _
                                       Ru_sb_tames1.t_partList.Select("partNo = '" & partNoFr & "'").GetValue(0).Item("BCinfo1"), _
                                       Ru_sb_tames1.t_partList.Select("partNo = '" & partNoFr & "'").GetValue(0).Item("BCinfo2"), _
                                       Ru_sb_tames1.t_partList.Select("partNo = '" & partNoFr & "'").GetValue(0).Item("c1"), _
                                       Ru_sb_tames1.t_partList.Select("partNo = '" & partNoFr & "'").GetValue(0).Item("c2")}
                                   )
                    End With

                    DataGridViewOrders.Rows.Add(dgvr)



                    'if Curent data was loaded from file then load number of parts
                    Dim orderNo As String = vbNullString

                    If Len(DataGridViewOrders.Rows(0).Cells("ColumnOrderNo").Value) < 6 Then
                        orderNo = StrDup(6 - Len(DataGridViewOrders.Rows(0).Cells("ColumnOrderNo").Value.ToString), "0") & DataGridViewOrders.Rows(0).Cells("ColumnOrderNo").Value.ToString
                    Else
                        orderNo = DataGridViewOrders.Rows(0).Cells("ColumnOrderNo").Value.ToString
                    End If

                    'Customer label type  Lada or Nissan (white label)

                    With Ru_sb_tames1.t_partList.Select("partNo = '" & partNoFr & "'")
                        If .Count > 0 Then
                            If Not IsDBNull(.GetValue(0).Item("c3")) Then
                                CustomerLabeltype = .GetValue(0).Item("c3").ToString
                            End If
                        End If
                    End With

                    'customerLabeltype = Ru_sb_tames1.t_partList.Select("partNo = '" & partNoFR & "'").GetValue(0).Item("c3")

                    If fromScanner = False Then
                        Dim parts As String = _curentInfoIni.GetKeyValue("CurentInfo", "parts")

                        If IsNumeric(parts) Then

                            LogCurrentStatus(orderNo & DataGridViewOrders.Rows(0).Cells("ColumnpartNo").Value, parts, False)

                            LabelLabelCount.Text = parts.ToString & " / " & PackFactor

                        End If
                    Else

                        LogCurrentStatus(orderNo & DataGridViewOrders.Rows(0).Cells("ColumnpartNo").Value, 0)

                    End If

                    T_orderListTableAdapter1.UpdateStatus("Started", CInt(DataGridViewOrders.Rows(0).Cells("ColumnOrderNo").Value))


                    'test if column Holologation PN contains any part number

                    Dim homolPn As String

                    Ru_sb_tames1.t_HLabel.Rows.Clear()

                    If Not IsDBNull(Ru_sb_tames1.t_partList.Select("partNo = '" & partNoFr & "'").GetValue(0).Item("c1")) Then
                        homolPn = Ru_sb_tames1.t_partList.Select("partNo = '" & partNoFr & "'").GetValue(0).Item("c1")
                        t_HLabelTableAdapter1.FillBylabelPN(Ru_sb_tames1.t_HLabel, homolPn)
                    End If

                End If

            Else

                PanelScanMaster.Visible = False
                SetError("Production Order " & Mid(indata, 1, 6) & " does not exist !!!")

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub PrintWhiteLabel(indata As String)

        'DLG=EZE_GUT|DAT=00/00/0000|ZEI=00:00|AUNR=ZZZZZZZZZZ|ATK=000000000XXX-??|MNR=L99|TEXT:9=PART INFO|TEXT:10=|CNR=XXXXXXXXXX|PRAEFIX:CNR=H|

        Try

            'if there is no order opened the exit sub

            If DataGridViewOrders.Rows.Count = 0 Then
                Exit Sub
            End If

            'split block values into parts
            Dim val1 As String = vbNullString
            Dim val2 As String = vbNullString
            Dim val3 As String = vbNullString
            Dim val4 As String = vbNullString

            If Len(indata) >= 7 Then
                val1 = Mid(indata, 4, 4)
            End If

            If Len(indata) >= 11 Then
                val2 = Mid(indata, 8, 4)
            End If

            If Len(indata) >= 15 Then
                val3 = Mid(indata, 12, 4)
            End If

            If Len(indata) >= 19 Then
                val4 = Mid(indata, 16, 4)
            End If

            Dim curentDate As Date = Now.ToString("dd.MM.yyyy")

            Dim curentTime As String = Now.ToString("HH:mm:ss")

            Dim curentYear As String = Mid(Now.ToString("yyyy"), 4, 1)

            Dim c1 As String = DataGridViewOrders.Rows(0).Cells("ColumnBCInfo1").Value

            Dim c2 As String = DataGridViewOrders.Rows(0).Cells("ColumnBCInfo2").Value

            Dim prodLine As String = DataGridViewOrders.Rows(0).Cells("ColumnLine").Value

            Dim factoryNumber As String = Ru_sb_tames1.t_Settings.Select("varName = 'FactoryNo'").GetValue(0).Item("varValue")

            Dim lineIdentification As String = Mid(prodLine, Len(prodLine))

            'Unique number for every part:   31 2 4 233 001    31 2 4 233 001

            'Factory Number (XX) + Line Identificator (X) + Year Identificator 201(4) + Day Identificator (XXX) + Alphanumeric Serial (XXX) -> from database

            'Dim CustBC As String = factoryNumber & lineIdentification & curentYear & Now.DayOfYear.ToString("000")

            Dim custBc As String = c1 & lineIdentification & curentYear & Now.DayOfYear.ToString("000")

            Dim ctr As String

            'get last  customer label from DB
            Dim lastLabel As Object

retry:

            If CurentCustomerLabel = vbNullString Then  ' the first print of the order 

                'get last label from DB

                lastLabel = T_labelsTableAdapter1.MaxLabel(curentDate, custBc & "%")

                If lastLabel <> Nothing Then

                    'if label found 
                    ctr = Mid(lastLabel, Len(lastLabel) - 2, 3)

                    CurentCustomerLabel = custBc & CustCounter(ctr)

                Else

                    'if label not found, register with count 001

                    CurentCustomerLabel = custBc & "001"

                End If

                'try to write the customer label to DB

                If T_labelsTableAdapter1.InsertNewLabel(CurentCustomerLabel, curentDate, curentTime, _
                                                     DataGridViewOrders.Rows(0).Cells("ColumnOrderNo").Value, _
                                                     DataGridViewOrders.Rows(0).Cells("ColumnpartNo").Value, _
                                                     DataGridViewOrders.Rows(0).Cells("ColumnCustPN").Value, _
                                                   0, val1, val2, val3, val4) > 0 Then

                Else
                    MsgBox("Error inserting new Customert Label to Database!")
                    Exit Sub
                End If

            Else

                'if last customer label was printet at the same day as the curent label
                If InStr(CurentCustomerLabel, custBc, CompareMethod.Text) > 0 Then
                    'get the count of the last printed label

                    ctr = Mid(CurentCustomerLabel, Len(CurentCustomerLabel) - 2, 3)

                    Dim lInserted = False  'this flag exits the next while LOOP

                    'increment the curent count and tryes to insert the label to DB. If done, set curent label to the one inserted and exits loop

                    While lInserted = False
                        Try
                            ctr = CustCounter(ctr)

                            T_labelsTableAdapter1.InsertNewLabel(custBc & ctr, curentDate, curentTime, _
                                                                 DataGridViewOrders.Rows(0).Cells("ColumnOrderNo").Value, _
                                                     DataGridViewOrders.Rows(0).Cells("ColumnpartNo").Value, _
                                                     DataGridViewOrders.Rows(0).Cells("ColumnCustPN").Value, _
                                                    0, val1, val2, val3, val4)

                            CurentCustomerLabel = custBc & ctr
                            lInserted = True

                        Catch
                        End Try

                    End While
                Else

                    CurentCustomerLabel = vbNullString
                    GoTo retry

                End If

            End If

            If CurentCustomerLabel <> vbNullString Then   ' if White label was inserted to DB then print label

                If _objini.GetKeyValue("PrintCtrl", "printCustomerLabel") <> "Yes" Then
                    Exit Sub
                End If

                Dim prodDate As String = Now.ToString("MM/dd/yyyy")

                'PrintCtrl exe location
                Dim spoolPath As String = System.Windows.Forms.Application.StartupPath & "\Log\spoolWhiteLabel.txt"

                Dim printCtrlApp As String = _objini.GetKeyValue("PrintCtrl", "path")

                If Not Directory.Exists(System.Windows.Forms.Application.StartupPath & "\Log") Then
                    Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath & "\Log")
                End If

                Dim args As String = "DLG=EZE_GUT|DAT=" & prodDate &
                                    "|ZEI=" & CInt(Now.TimeOfDay.TotalSeconds) &
                                    "|AUNR=" & DataGridViewOrders.Rows(0).Cells("ColumnOrderNo").Value &
                                    "|ATK=" & DataGridViewOrders.Rows(0).Cells("ColumnpartNo").Value &
                                    "|CNR=" & CurentCustomerLabel & "|PRAEFIX:CNR=H|"

                File.WriteAllText(spoolPath, args)

                ToolStripStatusLabelCurentInfo.Text = "[" & Now & "]  Printing White Label: " & CurentCustomerLabel

                Shell(printCtrlApp & " " & spoolPath)

            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub EOLDataReceivedHandler(sender As Object, e As SerialDataReceivedEventArgs)

        Try

            Dim sp = CType(sender, SerialPort)
            Thread.Sleep(300)

            Dim indata As String = sp.ReadExisting

            Writelog("EOLSignal received: " & indata)

            'If InStr(indata, Chr(2), CompareMethod.Text) = 0 Or InStr(indata, Chr(3), CompareMethod.Text) = 0 Then
            ' writelog("Signal not plausible (No <STX> or <ETX> found)")
            ' Exit Sub
            ' End If

            indata = Trim(Replace(indata, vbCrLf, vbNullString))

            If DateDiff(DateInterval.Second, EoLtime, Now) < EoLtimeOut Then
                Writelog("EOLSignal ignored: " & indata & ";  " & DateDiff(DateInterval.Second, EoLtime, Now) & "<" & EoLtimeOut)
                Exit Sub
            End If

            EoLtime = Now

            'replace <STX> 
            ' indata = Replace(indata, Chr(2), "")

            'removel all data from <ETX> to the end of string
            ' indata = Mid(indata, 1, InStr(indata, Chr(3), CompareMethod.Text) - 1)

            'trim trailing and leeding spaces
            'indata = Trim(indata)

            If Me.InvokeRequired Then
                Me.Invoke(New ProcessEoLsignalDelegate(AddressOf ProcessEoLsignal), New Object() {sp.PortName, indata})
            Else
                Me.ProcessEoLsignal(sp.PortName, indata)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    
    Private Sub ProcessEoLsignal(spName As String, indata As String)
        Try
            'disable close order warning interval
            WarningInterval()

            ListBoxLog.Items.Add(Now.ToString("dd.MM.yyyy HH:mm:ss") & ": " & spName & ": " & indata)
            ListBoxLog.SelectedIndex = ListBoxLog.Items.Count - 1
            ToolStripStatusLabelCurentInfo.Text = "[" & Now & "]  Input Data: EOL"

            EolDataBuffer += indata

            Dim stx As Integer = InStr(EolDataBuffer, Chr(2), CompareMethod.Text)
            Dim etx As Integer = InStr(EolDataBuffer, Chr(3), CompareMethod.Text)


            If stx > 0 And etx > 0 Then     'if eolDataBuffer contains both STX and ETX

                If stx < etx Then           'if STX is before ETX 

                    indata = EolDataBuffer.Substring(stx, etx - stx - 1)   'get content between first STX and ETX

                    EolDataBuffer = EolDataBuffer.Substring(etx)            ' cut from eolDataBuffer content that is before ETX

                Else

                    If etx > 0 Then
                        EolDataBuffer = EolDataBuffer.Substring(etx)        ' cut from eolDataBuffer content that is before ETX
                    End If

                    Exit Sub

                End If
            Else

                If etx > 0 Then
                    EolDataBuffer = EolDataBuffer.Substring(etx)            ' cut from eolDataBuffer content that is before ETX
                End If

                Exit Sub

            End If

            indata = Trim(indata)

            If Len(indata) >= 3 Then
                If IsReajustingWarningNeedToSendToController = True And indata.Substring(0, 3) = _reajustingWarningEol Then ' мы находимся в состоянии ожидания подтверждения от контроллера, что он получил сигнал о скорой переналадке
                    IsReajustingWarningNeedToSendToController = False
                End If

                If IsReajustingNeedToSendToController = True And indata.Substring(0, 3) = _reajustingEol Then ' мы находимся в состоянии ожидания подтверждения от контроллера, что он получил сигнал о начале переналадки
                    IsReajustingNeedToSendToController = False
                End If

                If _eoLcodes.ContainsKey(indata.Substring(0, 3)) Then  'begin of interrupt
                    LineStateCode = indata.Substring(0, 3)
                ElseIf indata.Substring(0, 3) = _reajustingEol Then ' переналадка тоже вариант простоя
                    LineStateCode = _reajustingEol
                ElseIf _eoLcodesOk.Contains(indata.Substring(0, 3)) Then 'end of interrupt, логически выделил для удобства понимания алгоритма
                    LineStateCode = indata.Substring(0, 3)
                End If

                If indata.Substring(0, 1) = "1" Then   'Good part and Scrap 

                    If indata.Substring(1, 2) = "00" Then                    'Good part 1 00

                        Dim partType As String = DataGridViewOrders.Rows(0).Cells("ColumnPartType").Value

                        If LCase(_objini.GetKeyValue("TPRULabelPrint", "lineType")) = "final" Then   'if lineType is FINAL then print customer label, else increment count
                            PrintCustomerLabel(indata)
                        Else
                            If partType = "final" Then          'cases when LineType is Subassy and partType is Final
                                PrintCustomerLabel(indata)
                                UpdatePartsInBoxCounter(CInt(_curentInfoIni.GetKeyValue("CurentInfo", "parts")) + 1)
                            Else
                                UpdatePartsInBoxCounter(CInt(_curentInfoIni.GetKeyValue("CurentInfo", "parts")) + 1)
                            End If
                        End If

                        ' после годного изделия возможно надо отправить сигнал о переналадке
                        If IsReajustingNeedToSendToController = True Then
                            _monitorSp(IndexOfEol).Write(Chr(2) + _reajustingEol + Chr(3)) ' TODO: переделать на многократную посылку
                            'IsReajustingWarningNeedToSendToController = False
                        ElseIf IsReajustingWarningNeedToSendToController = True Then                            ' после годного изделия возможно надо отправить сигнал о скорой переналадке
                            _monitorSp(IndexOfEol).Write(Chr(2) + _reajustingWarningEol + Chr(3)) ' TODO: переделать на многократную посылку
                            'IsReajustingNeedToSendToController = False
                        End If


                    Else

                        If IsNumeric(indata.Substring(1, 2)) Then
                            PrintScrapLabel(indata.Substring(1, 2))              'Scrap part 1 XX
                        Else
                            Writelog("Scrap ID NOK: " & indata.Substring(1, 2))
                        End If

                    End If

                End If

                If indata.Substring(0, 1) = "0" Then   'Master or Dummy

                    If indata.Substring(1, 2) = "00" Then
                        PrintMasterLabel()                               'Master 0 00
                    Else

                        If IsNumeric(indata.Substring(1, 2)) Then
                            PrintDummyLabel(indata.Substring(1, 2))               'Dummy 0 XX
                        Else
                            Writelog("Dummy ID NOK: " & indata.Substring(1, 2))
                        End If

                    End If

                End If

            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    
    Private Sub HLabelSgnDataReceivedHandler(sender As Object, e As SerialDataReceivedEventArgs)
        Try
            Dim sp = CType(sender, SerialPort)
            Thread.Sleep(200)

            Dim indata As String = Trim(Replace(sp.ReadExisting(), vbCrLf, vbNullString))

            ListBoxLog.Items.Add(Now.ToString("dd.MM.yyyy HH:mm:ss") & ": " & sp.PortName & ": " & indata)
            ListBoxLog.SelectedIndex = ListBoxLog.Items.Count - 1
            ToolStripStatusLabelCurentInfo.Text = "[" & Now & "]  Input Data: " & sp.PortName

            PrintHomologationLabel()

            If DateDiff(DateInterval.Second, Hlbltime, Now) < HlbltimeOut Then
                Exit Sub
            End If

            Hlbltime = Now



            'replace <STX> 
            ' indata = Replace(indata, Chr(2), "")

            'removel all data from <ETX> to the end of string
            'If InStr(indata, Chr(3), CompareMethod.Binary) > 0 Then

            'indata = Mid(indata, 1, InStr(indata, Chr(3), CompareMethod.Binary) - 1)

            'trim trailing and leeding spaces
            'indata = Trim(indata)

            'printHomologationLabel()

            'End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If TabControlIndex.SelectedTab Is TabPage2 Then
            Exit Sub
        End If

        'show/hide Log list
        If e.KeyValue = 19 Then
            ListBoxLog.Visible = Not ListBoxLog.Visible
            Refresh()
        End If

        If LCase(_objini.GetKeyValue("TPRULabelPrint", "testMode")) = "yes" Then

            If e.KeyValue = 71 Then

                PrintCustomerLabel("1001234123412341234")
                UpdatePartsInBoxCounter(CInt(_curentInfoIni.GetKeyValue("CurentInfo", "parts")) + 1)

            End If

            If e.KeyCode = 68 Then   'D
                PrintDummyLabel(InputBox("Dummy Number:", "Print Dummy Label", "01"))
                MsgBox("Dummy Label Printed")
            End If

            If e.KeyCode = 83 Then   'S
                PrintScrapLabel(InputBox("Scrap Number:", "Print Scrap Label", "01"))
                MsgBox("Scrap Label Printed")
            End If

            If e.KeyCode = 72 Then    'H
                PrintHomologationLabel()
                MsgBox("Homologation Label Printed")
            End If

            If e.KeyCode = 77 Then    'M
                PrintMasterLabel()
                MsgBox("Master Label Printed")
            End If

        End If


        Keyspressed += e.KeyData.ToString

        If Len(Keyspressed) > 4 Then
            Keyspressed = Mid(Keyspressed, Len(Keyspressed) - 3, 4)
        End If
        If Keyspressed = "EXIT" Then
            If MessageBox.Show("Exit Program?", "Exit Program", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Me.Close()
            End If
        End If



    End Sub

    Private Sub ButtonOpenOrder_Click(sender As Object, e As EventArgs) Handles ButtonOpenOrder.Click
        PanelStartOrder.Visible = True
        ButtonOpenOrder.Enabled = False
    End Sub

    Private Sub PanelStartOrder_VisibleChanged(sender As Object, e As EventArgs) Handles PanelStartOrder.VisibleChanged
        If PanelStartOrder.Visible Then
            TimerStartOrder.Enabled = True
            ButtonCancelScanOrder.Focus()
            ' Else
            '    TimerStartOrder.Enabled = False
        End If
    End Sub

    Private Sub TimerStartOrder_Tick(sender As Object, e As EventArgs) Handles TimerStartOrder.Tick
        If PanelStartOrder.Visible Then
            LabelStartOrder.Visible = Not LabelStartOrder.Visible
        End If
        If PanelScanMaster.Visible Then
            LabelScanMaster.Visible = Not LabelScanMaster.Visible
        End If
    End Sub

    Private Sub DataGridViewOrders_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles DataGridViewOrders.RowsAdded
        Try
            PanelStartOrder.Visible = False
            PanelScanMaster.Visible = False
            ButtonCloseOrder.Enabled = True
            ButtonChangeCounter.Enabled = True
            ButtonOpenOrder.Enabled = False
            OrderOpen = True
            PackFactor = DataGridViewOrders.Rows(0).Cells("columnPackfactor").Value
            TotalPartsInOrder = 100 ' DataGridViewOrders.Rows(0).Cells("columnOrderQty").Value ' здесь надо запомнить в отдельную переменную , сколько всего изделий в заказе (или в 726 строчке??)
            LabelLabelCount.Text = 0 & " / " & PackFactor.ToString
            WarningInterval()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub DataGridViewOrders_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles DataGridViewOrders.RowsRemoved
        Try
            ButtonOpenOrder.Enabled = True
            ButtonCloseOrder.Enabled = False
            ButtonChangeCounter.Enabled = False
            OrderOpen = False
            CurentCustomerLabel = vbNullString
            ToolStripStatusLabelCurentInfo.Text = "[" & Now & "]  Production Order Stopped"

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ButtonCloseOrder_Click(sender As Object, e As EventArgs) Handles ButtonCloseOrder.Click
        Try

            If OrderOpen Then

                Dim result As MsgBoxResult = DialogResult.Yes
                'If CultureInfo.CurrentUICulture.ToString = "ru-RU" Then
                '    result = MessageBox.Show("Прервать Заказ?", "Прервать Заказ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                'Else
                '    result = MessageBox.Show("Close Order?", "Close Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                'End If

                If result = DialogResult.Yes Then
                    LabelPerformanceInfo.Visible = False

                    If DataGridViewOrders.Rows.Count > 0 Then

                        'update order status to STOPPED
                        T_orderListTableAdapter1.UpdateStatus("Stopped", CInt(DataGridViewOrders.Rows(0).Cells("ColumnOrderNo").Value))
                        DataGridViewOrders.Rows.RemoveAt(0)
                        OrderOpen = False
                        PackFactor = 0
                        TotalPartsInOrder = 0
                        LabelLabelCount.Text = vbNullString
                        LogCurrentStatus(vbNullString, 0)

                    End If
                End If

            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ButtonCancelScanOrder_Click(sender As Object, e As EventArgs) Handles ButtonCancelScanOrder.Click
        PanelStartOrder.Visible = False
        ButtonOpenOrder.Enabled = True
    End Sub

    Private Sub LabelLabelCount_TextChanged(sender As Object, e As EventArgs) Handles LabelLabelCount.TextChanged
        If LabelLabelCount.Text <> vbNullString Then
            If Mid(LabelLabelCount.Text, 1, 1) <> "0" Then
                ButtonPrintBoxLabel.Visible = True
            Else
                ButtonPrintBoxLabel.Visible = False
            End If
            If LabelLabelCount.Visible = False Then
                LabelLabelCount.Visible = True
            End If
            LabelLabelCount.BackColor = Color.Red
            LabelLabelCount.ForeColor = Color.White
            TimerCountBlink.Enabled = True
        Else
            LabelLabelCount.Visible = False
            ButtonPrintBoxLabel.Visible = False
        End If
    End Sub

    Private Sub LogCurrentStatus(order As String, partsProduced As Integer, Optional ByVal fromScanner As Boolean = True)

        Try
            _curentInfoIni.SetKeyValue("CurentInfo", "order", order)

            'set parts number to 0 only if a new order was started 

            If fromScanner Then

                _curentInfoIni.SetKeyValue("CurentInfo", "parts", partsProduced)
                _curentInfoIni.SetKeyValue("CurentInfo", "totalParts", 0)

            End If
            _curentInfoIni.Save(_curentIniPath)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    
    Private Sub PrintCustomerLabel(indata As String)

        Try

            'if there is no order opened the exit sub

            If DataGridViewOrders.Rows.Count = 0 Then
                Exit Sub
            End If

            'print White label if customerLabeltype = EZE_GUT
            'If Not IsDBNull(customerLabeltype) Then
            If CustomerLabeltype = "EZE_GUT" Then
                PrintWhiteLabel(indata)
                Exit Sub
            End If
            'End If


            'split block values into parts
            Dim val1 As String = vbNullString
            Dim val2 As String = vbNullString
            Dim val3 As String = vbNullString
            Dim val4 As String = vbNullString

            If Len(indata) >= 7 Then
                val1 = Mid(indata, 4, 4)
            End If

            If Len(indata) >= 11 Then
                val2 = Mid(indata, 8, 4)
            End If

            If Len(indata) >= 15 Then
                val3 = Mid(indata, 12, 4)
            End If

            If Len(indata) >= 19 Then
                val4 = Mid(indata, 16, 4)
            End If

            Dim curentDate As Date = Now.ToString("dd.MM.yyyy")

            Dim curentTime As String = Now.ToString("HH:mm:ss")

            Dim curentYear As String = Mid(Now.ToString("yyyy"), 4, 1)

            Dim c1 As String = DataGridViewOrders.Rows(0).Cells("ColumnBCInfo1").Value

            Dim spCode As String = Ru_sb_tames1.t_Settings.Select("varName = 'SupplyerCode'").GetValue(0).item("varValue")

            Dim partNo As String = T_orderListDataGridView.Rows(T_orderListDataGridView.SelectedCells(0).RowIndex).Cells("partNo").Value
            'clear revision
            Dim partNoFr As String = vbNullString

            If InStr(partNo, "-") > 0 Then
                partNoFr = partNo.Substring(0, InStr(partNo, "-"))
            Else
                partNoFr = partNo
            End If

            Dim c2 As String = DataGridViewOrders.Rows(0).Cells("ColumnBCInfo2").Value

            Dim custBc As String = "T" & c1 & spCode & Now.DayOfYear.ToString("000") & curentYear & c2

            Dim ctr As String

            'get last  customer label from DB
            Dim lastLabel As Object

retry:

            If CurentCustomerLabel = vbNullString Then  ' the first print of the order 

                'get last label from DB

                lastLabel = T_labelsTableAdapter1.MaxLabel(curentDate, custBc & "%")

                If lastLabel <> Nothing Then

                    'if label found 
                    ctr = Mid(lastLabel, Len(lastLabel) - 2, 3)

                    CurentCustomerLabel = custBc & CustCounter(ctr)

                Else

                    'if label not found, register with count 001

                    CurentCustomerLabel = custBc & "001"

                End If

                'try to write the customer label to DB

                If T_labelsTableAdapter1.InsertNewLabel(CurentCustomerLabel, curentDate, curentTime, _
                                                     DataGridViewOrders.Rows(0).Cells("ColumnOrderNo").Value, _
                                                     DataGridViewOrders.Rows(0).Cells("ColumnpartNo").Value, _
                                                     DataGridViewOrders.Rows(0).Cells("ColumnCustPN").Value, _
                                                   0, val1, val2, val3, val4) > 0 Then

                Else
                    MsgBox("Error inserting new Customert Label to Database!")
                    Exit Sub
                End If

            Else

                'if last customer label was printet at the same day as the curent label
                If InStr(CurentCustomerLabel, custBc, CompareMethod.Text) > 0 Then
                    'get the count of the last printed label

                    ctr = Mid(CurentCustomerLabel, Len(CurentCustomerLabel) - 2, 3)

                    Dim lInserted = False  'this flag exits the next while LOOP

                    'increment the curent count and tryes to insert the label to DB. If done, set curent label to the one inserted and exits loop

                    While lInserted = False
                        Try
                            ctr = CustCounter(ctr)

                            T_labelsTableAdapter1.InsertNewLabel(custBc & ctr, curentDate, curentTime, _
                                                                 DataGridViewOrders.Rows(0).Cells("ColumnOrderNo").Value, _
                                                     DataGridViewOrders.Rows(0).Cells("ColumnpartNo").Value, _
                                                     DataGridViewOrders.Rows(0).Cells("ColumnCustPN").Value, _
                                                    0, val1, val2, val3, val4)

                            CurentCustomerLabel = custBc & ctr
                            lInserted = True

                        Catch
                        End Try

                    End While
                Else

                    CurentCustomerLabel = vbNullString
                    GoTo retry

                End If

            End If


            If CurentCustomerLabel <> vbNullString Then   ' if customer label was inserted to DB then print label

                If _objini.GetKeyValue("PrintCtrl", "printCustomerLabel") <> "Yes" Then
                    Exit Sub
                End If

                Dim custPn As String = DataGridViewOrders.Rows(0).Cells("ColumnCustPN").Value
                Dim prodDate As String = Now.ToString("MM/dd/yyyy")

                'PrintCtrl exe location
                Dim spoolPath As String = System.Windows.Forms.Application.StartupPath & "\Log\spoolCustomerLabel.txt"

                Dim printCtrlApp As String = _objini.GetKeyValue("PrintCtrl", "path")

                If Not Directory.Exists(System.Windows.Forms.Application.StartupPath & "\Log") Then
                    Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath & "\Log")
                End If

                If IsDBNull(CustomerLabeltype) Then CustomerLabeltype = "Lada-HW"
                If CustomerLabeltype = vbNullString Then CustomerLabeltype = "Lada-HW"

                Dim args As String = "DLG=EZE_KD|DAT=" & prodDate & _
                                     "|ZEI=" & CInt(Now.TimeOfDay.TotalSeconds) & _
                                     "|BARCODE=" & CurentCustomerLabel & _
                                     "|TEXT:1=" & CustomerLabeltype & ".DRU|TEXT:2=" & custPn & _
                                     "|TEXT:3=|TEXT:4=|TEXT:5=|"

                File.WriteAllText(spoolPath, args)

                ToolStripStatusLabelCurentInfo.Text = "[" & Now & "]  Printing Customer Label: " & CurentCustomerLabel

                Shell(printCtrlApp & " " & spoolPath)

            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub ButtonCloseError_Click(sender As Object, e As EventArgs) Handles ButtonCloseError.Click
        PanelError.Visible = False
        IsError = False
        If OrderOpen = False Then
            ButtonOpenOrder.Enabled = True
        End If
    End Sub

    Private Sub ButtonPrintBoxLabel_Click(sender As Object, e As EventArgs) Handles ButtonPrintBoxLabel.Click
        Try
            If MessageBox.Show("Print Box label with curent quantity?", "Print Box Label", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then

                'show count on screen

                If T_orderListTableAdapter1.UpdateBoxNo(DataGridViewOrders.Rows(0).Cells("ColumnBoxNo").Value + 1, DataGridViewOrders.Rows(0).Cells("ColumnOrderNo").Value) > 0 Then
                    DataGridViewOrders.Rows(0).Cells("ColumnBoxNo").Value += 1
                    ToolStripStatusLabelCurentInfo.Text = "[" & Now & "]  BoxNumber changed"
                End If

                PrintBoxLabel()

                LabelLabelCount.Text = "0 / " & PackFactor.ToString
                _curentInfoIni.SetKeyValue("CurentInfo", "parts", 0)
                _curentInfoIni.Save(_curentIniPath)

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub PrintBoxLabel()
        Try

            If OrderOpen = False Then
                Exit Sub
            End If

            Dim factoryNumber As String = Ru_sb_tames1.t_Settings.Select("varName = 'FactoryNo'").GetValue(0).Item("varValue")
            Dim order As String = DataGridViewOrders.Rows(0).Cells("ColumnOrderNo").Value
            Dim boxNr As String = Format(CInt(DataGridViewOrders.Rows(0).Cells("ColumnBoxNo").Value), "000")

            Dim labelNumber As String = factoryNumber + order + "0" + boxNr
            Dim line As String = _objini.GetKeyValue("LineInfo", "LineName")

            Dim dgSy As String = DataGridViewOrders.Rows(0).Cells("ColumnDGSymbol").Value
            Dim counter As String = _curentInfoIni.GetKeyValue("CurentInfo", "parts")
            Dim prodDate As String = Now.ToString("MM/dd/yyyy")
            Dim partNo As String = DataGridViewOrders.Rows(0).Cells("ColumnpartNo").Value
            Dim partDesc As String = DataGridViewOrders.Rows(0).Cells("ColumnPartName").Value
            Dim custPn As String = DataGridViewOrders.Rows(0).Cells("ColumnCustPN").Value
            Dim custName As String = DataGridViewOrders.Rows(0).Cells("ColumnCustName").Value
            Dim partNoFr As String = vbNullString

            If InStr(partNo, "-") > 0 Then
                partNoFr = partNo.Substring(0, InStr(partNo, "-"))
            Else
                partNoFr = partNo
            End If

            Dim spCode As String = Ru_sb_tames1.t_Settings.Select("varName = 'SupplyerCode'").GetValue(0).item("varValue")   'Ru_sb_tames1.t_partList.Select("partNo = '" & partNoFR & "'").GetValue(0).item("suppliercode")  
            Dim spName As String = Ru_sb_tames1.t_Settings.Select("varName = 'SupplyerName'").GetValue(0).item("varValue")
            Dim spAddress As String = Ru_sb_tames1.t_Settings.Select("varName = 'SupplyerAddress'").GetValue(0).item("varValue")
            Dim args As String = vbNullString

            Dim partType As String = DataGridViewOrders.Rows(0).Cells("ColumnPartType").Value

            If partType = "final" Then

                args = "DLG=GEB_DRU|ANR=|" & _
                                            "MENGE=" & counter & "|" & _
                                            "ATK=" & partNo & "|" & _
                                            "ATKBEZ=" & partDesc & "|" & _
                                            "KLASSE=G|" & _
                                            "OPT:NPRN=N|" & _
                                            "DAT=" & prodDate & "|ZEI=00:00|" & _
                                            "USR=2055|" & _
                                            "SWZ=W|" & _
                                            "AUNR=|" & _
                                            "GBNR=" & labelNumber & "|" & _
                                            "LEITZAHL=" & order & "|" & _
                                            "MNR=" & line & "|" & _
                                            "TEXT:1=LADA-HW.DRU|" & _
                                            "TEXT:11=" & custPn & "|" & _
                                            "TEXT:12=" & spCode & "|" & _
                                            "TEXT:13=" & custName & "|" & _
                                            "TEXT:14=" & spName & "|" & _
                                            "TEXT:21=" & partDesc & "|" & _
                                            "PRAEFIX:ATK=P|" & _
                                            "PRAEFIX:CNR=H|" & _
                                            "SUPPL_NAME=" & spName & "|" & _
                                            "SUPPL_ADDR=" & spAddress & "|"

            ElseIf partType = "subassy" Then

                args = "DLG=EZE_DRU|DAT=00/00/0000|ZEI=00:00|CNTR=" & boxNr & "|GBNR=|" & _
                                            "CNR=|LEITZAHL=" & order & _
                                            "|MNR=" & line & _
                                            "|MENGE=" & counter & _
                                            "|ATK=" & partNo & _
                                            "|ATKBEZ=" & partDesc & _
                                            "|AUNR=" & order & _
                                            "|TEXT:11=|TEXT:12=|TEXT:13=|TEXT:15=|TEXT:16=|TEXT:17=|TEXT:21=" & partDesc & _
                                            "|TEXT:23=|TEXT:30=|SUPPL_NAME=" & spName & "|"   '   " & order & boxNr & "

            End If


            Dim spoolPath As String = System.Windows.Forms.Application.StartupPath & "\Log\spoolBoxLabel.txt"
            Dim printCtrlApp As String = _objini.GetKeyValue("PrintCtrl", "path")

            If Not Directory.Exists(System.Windows.Forms.Application.StartupPath & "\Log") Then
                Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath & "\Log")
            End If

            File.WriteAllText(spoolPath, args)

            If _objini.GetKeyValue("PrintCtrl", "printBoxLabel") <> "Yes" Then
                Exit Sub
            End If

            ToolStripStatusLabelCurentInfo.Text = "[" & Now & "]  Printing Box Label: " & labelNumber

            Shell(printCtrlApp & " " & spoolPath)

            Writelog("Print BoxLabel: " & labelNumber + vbNewLine + dgSy + vbNewLine + counter + vbNewLine + prodDate + vbNewLine + partNo + vbNewLine + _
                     partDesc + vbNewLine + custPn + vbNewLine + custName + vbNewLine + spCode + vbNewLine + spName)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub PrintBoxLabelManual(pboxNo As Integer, reprint As Boolean, Optional ByVal lCount As Integer = 1)
        Try
            If T_orderListDataGridView.SelectedCells.Count = 0 Then
                Exit Sub
            End If

            'get data from Settings datatable

            Dim factoryNumber As String = Ru_sb_tames1.t_Settings.Select("varName = 'FactoryNo'").GetValue(0).Item("varValue")
            Dim spCode As String = Ru_sb_tames1.t_Settings.Select("varName = 'SupplyerCode'").GetValue(0).item("varValue")
            Dim spName As String = Ru_sb_tames1.t_Settings.Select("varName = 'SupplyerName'").GetValue(0).item("varValue")
            Dim spAddress As String = Ru_sb_tames1.t_Settings.Select("varName = 'SupplyerAddress'").GetValue(0).item("varValue")

            Dim order As String = DataGridViewOrders.Rows(0).Cells("ColumnOrderNo").Value
            Dim partNo As String = DataGridViewOrders.Rows(0).Cells("ColumnpartNo").Value
            'clear revision
            Dim partNoFr As String = vbNullString

            If InStr(partNo, "-") > 0 Then
                partNoFr = partNo.Substring(0, InStr(partNo, "-"))
            Else
                partNoFr = partNo
            End If

            Dim boxNr As Integer

            'daca s-a selectat reprint, numarul cutie va fi cel transmis print InputBox, altfel, se va prelua din baza de date

            If reprint Then
                boxNr = pboxNo
            Else
                boxNr = CInt(T_orderListDataGridView.Rows(T_orderListDataGridView.SelectedCells(0).RowIndex).Cells("BoxNo").Value)
            End If

            'Format(xx, "000")

            Dim labelNumber As String = vbNullString

            Dim line As String = _objini.GetKeyValue("LineInfo", "LineName")

            Dim dgSy As String = vbNullString
            Dim packfactor As String = vbNullString
            Dim partDesc As String = vbNullString
            Dim custPn As String = vbNullString
            Dim custName As String = vbNullString
            Dim partType As String = vbNullString
            Dim prodDate As String = Now.ToString("MM/dd/yyyy")

            'fill part datatable
            T_partListTableAdapter1.FillByPartNo(Ru_sb_tames1.t_partList, partNoFr)

            If Ru_sb_tames1.t_partList.Rows.Count > 0 Then

                dgSy = Ru_sb_tames1.t_partList.Select("partNo = '" & partNoFr & "'").GetValue(0).item("DGSymbol")
                packfactor = Ru_sb_tames1.t_partList.Select("partNo = '" & partNoFr & "'").GetValue(0).item("packfactor")
                partDesc = Ru_sb_tames1.t_partList.Select("partNo = '" & partNoFr & "'").GetValue(0).item("partDesc")
                custPn = Ru_sb_tames1.t_partList.Select("partNo = '" & partNoFr & "'").GetValue(0).item("custPartNo")
                custName = Ru_sb_tames1.t_partList.Select("partNo = '" & partNoFr & "'").GetValue(0).item("custName")
                partType = Ru_sb_tames1.t_partList.Select("partNo = '" & partNoFr & "'").GetValue(0).item("c2")
                'spCode = Ru_sb_tames1.t_partList.Select("partNo = '" & partNoFR & "'").GetValue(0).item("suppliercode")
            Else

                MsgBox("No part number details was found!!!")
                TabControl1.SelectedTab = TabPagePN
                Exit Sub

            End If

            Dim args As String = vbNullString

            Dim reprintChar = "0"

            If reprint Then

                'in cazul reprintarii, numarul cutiei se preia din parametrul PboxNo si se printeaza o singura cutie avand caracterul 9 

                reprintChar = "9"

                If partType = "final" Then

                    labelNumber = factoryNumber + order + reprintChar + Format(boxNr, "000")

                    args = "DLG=GEB_DRU|ANR=|" & _
                                                "MENGE=" & packfactor & "|" & _
                                                "ATK=" & partNo & "|" & _
                                                "ATKBEZ=" & partDesc & "|" & _
                                                "KLASSE=G|" & _
                                                "OPT:NPRN=N|" & _
                                                "DAT=" & prodDate & "|ZEI=00:00|" & _
                                                "USR=2055|" & _
                                                "SWZ=W|" & _
                                                "AUNR=|" & _
                                                "GBNR=" & labelNumber & "|" & _
                                                "LEITZAHL=" & order & "|" & _
                                                "MNR=" & line & "|" & _
                                                "TEXT:1=LADA-HW.DRU|" & _
                                                "TEXT:11=" & custPn & "|" & _
                                                "TEXT:12=" & spCode & "|" & _
                                                "TEXT:13=" & custName & "|" & _
                                                "TEXT:14=" & spName & "|" & _
                                                "TEXT:21=" & partDesc & "|" & _
                                                "PRAEFIX:ATK=P|" & _
                                                "PRAEFIX:CNR=H|" & _
                                                "SUPPL_NAME=" & spName & "|" & _
                                                "SUPPL_ADDR=" & spAddress & "|"

                ElseIf partType = "subassy" Then

                    args = "DLG=EZE_DRU|DAT=00/00/0000|ZEI=00:00|CNTR=" & boxNr & "|GBNR=|" & _
                                                "CNR=|LEITZAHL=" & order & _
                                                "|MNR=" & line & _
                                                "|MENGE=" & packfactor & _
                                                "|ATK=" & partNo & _
                                                "|ATKBEZ=" & partDesc & _
                                                "|AUNR=" & order & _
                                                "|TEXT:11=|TEXT:12=|TEXT:13=|TEXT:15=|TEXT:16=|TEXT:17=|TEXT:21=" & partDesc & _
                                                "|TEXT:23=|TEXT:30=|SUPPL_NAME=" & spName & "|"   '   " & order & boxNr & "

                End If


                Dim spoolPath As String = System.Windows.Forms.Application.StartupPath & "\Log\spoolBoxLabel.txt"
                Dim printCtrlApp As String = _objini.GetKeyValue("PrintCtrl", "path")

                If Not Directory.Exists(System.Windows.Forms.Application.StartupPath & "\Log") Then
                    Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath & "\Log")
                End If

                File.WriteAllText(spoolPath, args)

                If _objini.GetKeyValue("PrintCtrl", "printBoxLabel") <> "Yes" Then
                    Exit Sub
                End If

                ToolStripStatusLabelCurentInfo.Text = "[" & Now & "]  Printing Box Label: " & labelNumber

                Shell(printCtrlApp & " " & spoolPath)

                Writelog("Print BoxLabel: " & labelNumber + vbNewLine + dgSy + vbNewLine + packfactor + vbNewLine + prodDate + vbNewLine + partNo + vbNewLine + _
                         partDesc + vbNewLine + custPn + vbNewLine + custName + vbNewLine + spCode + vbNewLine + spName)

            Else

                For c = 1 To lCount

                    If partType = "final" Then

                        labelNumber = factoryNumber + order + reprintChar + Format(boxNr + c, "000")

                        args = "DLG=GEB_DRU|ANR=|" & _
                                                    "MENGE=" & packfactor & "|" & _
                                                    "ATK=" & partNo & "|" & _
                                                    "ATKBEZ=" & partDesc & "|" & _
                                                    "KLASSE=G|" & _
                                                    "OPT:NPRN=N|" & _
                                                    "DAT=" & prodDate & "|ZEI=00:00|" & _
                                                    "USR=2055|" & _
                                                    "SWZ=W|" & _
                                                    "AUNR=|" & _
                                                    "GBNR=" & labelNumber & "|" & _
                                                    "LEITZAHL=" & order & "|" & _
                                                    "MNR=" & line & "|" & _
                                                    "TEXT:1=LADA-HW.DRU|" & _
                                                    "TEXT:11=" & custPn & "|" & _
                                                    "TEXT:12=" & spCode & "|" & _
                                                    "TEXT:13=" & custName & "|" & _
                                                    "TEXT:14=" & spName & "|" & _
                                                    "TEXT:21=" & partDesc & "|" & _
                                                    "PRAEFIX:ATK=P|" & _
                                                    "PRAEFIX:CNR=H|" & _
                                                    "SUPPL_NAME=" & spName & "|" & _
                                                    "SUPPL_ADDR=" & spAddress & "|"

                    ElseIf partType = "subassy" Then

                        args = "DLG=EZE_DRU|DAT=00/00/0000|ZEI=00:00|CNTR=" & boxNr & "|GBNR=|" & _
                                                    "CNR=|LEITZAHL=" & order & _
                                                    "|MNR=" & line & _
                                                    "|MENGE=" & packfactor & _
                                                    "|ATK=" & partNo & _
                                                    "|ATKBEZ=" & partDesc & _
                                                    "|AUNR=" & order & _
                                                    "|TEXT:11=|TEXT:12=|TEXT:13=|TEXT:15=|TEXT:16=|TEXT:17=|TEXT:21=" & partDesc & _
                                                    "|TEXT:23=|TEXT:30=|SUPPL_NAME=" & spName & "|"   '   " & order & boxNr & "

                    End If


                    Dim spoolPath As String = System.Windows.Forms.Application.StartupPath & "\Log\spoolBoxLabel.txt"
                    Dim printCtrlApp As String = _objini.GetKeyValue("PrintCtrl", "path")

                    If Not Directory.Exists(System.Windows.Forms.Application.StartupPath & "\Log") Then
                        Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath & "\Log")
                    End If

                    File.WriteAllText(spoolPath, args)

                    If _objini.GetKeyValue("PrintCtrl", "printBoxLabel") <> "Yes" Then
                        Exit Sub
                    End If

                    ToolStripStatusLabelCurentInfo.Text = "[" & Now & "]  Printing Box Label: " & labelNumber

                    Shell(printCtrlApp & " " & spoolPath)

                    Writelog("Print BoxLabel: " & labelNumber + vbNewLine + dgSy + vbNewLine + packfactor + vbNewLine + prodDate + vbNewLine + partNo + vbNewLine + _
                             partDesc + vbNewLine + custPn + vbNewLine + custName + vbNewLine + spCode + vbNewLine + spName)

                Next  'print lCount numbers of boxlabels

                Try

                    T_orderListTableAdapter1.UpdateBoxNo(boxNr + lCount, order)
                    T_orderListTableAdapter1.UpdateStatus("Stopped", order)

                Catch ex As Exception
                    MsgBox(ex.ToString)

                End Try

            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub PrintMasterLabel()
        Try

            If OrderOpen = False Then
                Exit Sub
            End If

            Dim prodDate As String = Now.ToString("MM/dd/yyyy")
            Dim custPn As String = DataGridViewOrders.Rows(0).Cells("ColumnCustPN").Value

            Dim curentYear As String = Mid(Now.ToString("yyyy"), 4, 1)

            Dim c1 As String = DataGridViewOrders.Rows(0).Cells("ColumnBCInfo1").Value

            Dim partNo As String = DataGridViewOrders.Rows(0).Cells("ColumnpartNo").Value

            Dim spCode As String = Ru_sb_tames1.t_Settings.Select("varName = 'SupplyerCode'").GetValue(0).item("varValue")

            Dim partNoFr As String = vbNullString

            If InStr(partNo, "-") > 0 Then
                partNoFr = partNo.Substring(0, InStr(partNo, "-"))
            Else
                partNoFr = partNo
            End If

            'Dim spCode As String = Ru_sb_tames1.t_partList.Select("partNo = '" & partNoFR & "'").GetValue(0).item("suppliercode")

            Dim c2 As String = DataGridViewOrders.Rows(0).Cells("ColumnBCInfo2").Value

            Dim custBc As String = "T" & c1 & spCode & Now.DayOfYear.ToString("000") & curentYear & c2

            Dim args As String = "DLG=EZE_KD|DAT=" & prodDate & _
                                 "|ZEI=" & CInt(Now.TimeOfDay.TotalSeconds) & _
                                 "|BARCODE=" & custBc & "000" & _
                                 "|TEXT:1=LADA-HW.DRU|TEXT:2=" & custPn & _
                                 "|TEXT:3=|TEXT:4=|TEXT:5=|"

            Dim spoolPath As String = System.Windows.Forms.Application.StartupPath & "\Log\spoolMasterLabel.txt"
            Dim printCtrlApp As String = _objini.GetKeyValue("PrintCtrl", "path")

            If Not Directory.Exists(System.Windows.Forms.Application.StartupPath & "\Log") Then
                Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath & "\Log")
            End If

            File.WriteAllText(spoolPath, args)

            'Exit Sub '------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            If _objini.GetKeyValue("PrintCtrl", "printCustomerLabel") <> "Yes" Then
                Exit Sub
            End If

            ToolStripStatusLabelCurentInfo.Text = "[" & Now & "]  Printing Master Label: " & custBc & "000"

            Shell(printCtrlApp & " " & spoolPath)

            Writelog("Printed Scrap Label: " & args)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    
    Private Sub PrintDummyLabel(dummyNr As String)
        Try
            Dim prodDate As String = Now.ToString("MM/dd/yyyy")

            Dim args As String = "DLG=EZE_DMY|DAT=" & prodDate & "|ZEI=" & CInt(Now.TimeOfDay.TotalSeconds) & "|BEZ=" & dummyNr & "|"

            Dim spoolPath As String = System.Windows.Forms.Application.StartupPath & "\Log\spoolDummyLabel.txt"
            Dim printCtrlApp As String = _objini.GetKeyValue("PrintCtrl", "path")

            If Not Directory.Exists(System.Windows.Forms.Application.StartupPath & "\Log") Then
                Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath & "\Log")
            End If

            File.WriteAllText(spoolPath, args)

            ' Exit Sub '------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            If _objini.GetKeyValue("PrintCtrl", "printDummyLabel") <> "Yes" Then
                Exit Sub
            End If

            ToolStripStatusLabelCurentInfo.Text = "[" & Now & "]  Printing Dummy Label: " & dummyNr

            Shell(printCtrlApp & " " & spoolPath)

            Writelog("Printed Dummy Label: " & args)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub PrintScrapLabel(scrapNr As String)
        Try

            If OrderOpen = False Then
                Exit Sub
            End If

            Dim prodDate As String = Now.ToString("MM/dd/yyyy")
            Dim order As String = DataGridViewOrders.Rows(0).Cells("ColumnOrderNo").Value
            Dim partNo As String = DataGridViewOrders.Rows(0).Cells("ColumnpartNo").Value
            Dim cnr As String = Now.ToString("MMddyyhhmmssf")

            Dim args As String = "DLG=EZE_AUS|DAT=" & prodDate & "|ZEI=" & CInt(Now.TimeOfDay.TotalSeconds) & "|AUNR=" & order & "|ATK=" & partNo & "|CNR=|BEZ=" & scrapNr & "|"

            Dim spoolPath As String = System.Windows.Forms.Application.StartupPath & "\Log\spoolScrapLabel.txt"
            Dim printCtrlApp As String = _objini.GetKeyValue("PrintCtrl", "path")

            If Not Directory.Exists(System.Windows.Forms.Application.StartupPath & "\Log") Then
                Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath & "\Log")
            End If

            File.WriteAllText(spoolPath, args)

            ' Exit Sub '------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            If _objini.GetKeyValue("PrintCtrl", "printScrapLabel") <> "Yes" Then
                Exit Sub
            End If

            ToolStripStatusLabelCurentInfo.Text = "[" & Now & "]  Printing Scrap Label: " & scrapNr

            Shell(printCtrlApp & " " & spoolPath)

            Writelog("Printed Scrap Label: " & args)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub PrintHomologationLabel()
        Try
            If OrderOpen = False Then
                Exit Sub
            End If

            Dim args As String

            Dim hpn As String
            If Not IsDBNull(DataGridViewOrders.Rows(0).Cells("ColumnHomologationPN").Value) Then
                hpn = DataGridViewOrders.Rows(0).Cells("ColumnHomologationPN").Value
            Else
                Writelog("No Homologation Part found for curent PartNumber")
                Exit Sub
            End If

            If Ru_sb_tames1.t_HLabel.Rows.Count > 0 Then

                If Ru_sb_tames1.t_HLabel.Select("labelPN = '" & hpn & "'").Count > 0 Then

                    With Ru_sb_tames1.t_HLabel.Select("labelPN = '" & hpn & "'").GetValue(0)

                        'get partNO
                        Dim partNo As String = DataGridViewOrders.Rows(0).Cells("ColumnpartNo").Value

                        'If InStr(partNo, "-", CompareMethod.Text) > 0 Then
                        ' partNo = Mid(partNo, 1, InStr(partNo, "-", CompareMethod.Text))
                        ' End If

                        Dim airbag = "False"

                        If .Item("AIRBAG") = 1 Then
                            airbag = "True"
                        End If

                        args = "DLG=EZE_HLB|DAT=00.00.0000|ZEI=00:00|ATK=" & partNo & _
                                                "|LATK=" & .Item("labelPN") & _
                                                "|LAYOUT=" & .Item("labelLayout") & _
                                                "|ID_NO=" & .item("IdentificationNo") & _
                                                "|MODEL=" & .Item("ModelNo") & _
                                                "|ECE_TYPE=" & .Item("ECEApprovalType") & _
                                                "|ECE=" & .Item("ECEApprovalNo") & _
                                                "|EEC_TYPE=" & .Item("EECApprovalType") & _
                                                "|EEC=" & .Item("EECApprovalNo") & _
                                                "|AIRBAG=" & airbag & _
                                                "|PRET=" & .Item("PretensionerType") & _
                                                "|BARCODE=" & .Item("BarCode") & "|"

                        ' labelPN, labelLayout, IdentificationNo, ModelNo, ECEApprovalType, ECEApprovalNo, EECApprovalType, EECApprovalNo, AIRBAG, PretensionerType, BarCode

                    End With

                    Dim spoolPath As String = System.Windows.Forms.Application.StartupPath & "\Log\spoolHomogationLabel.txt"
                    Dim printCtrlApp As String = _objini.GetKeyValue("PrintCtrl", "path")

                    If Not Directory.Exists(System.Windows.Forms.Application.StartupPath & "\Log") Then
                        Directory.CreateDirectory(System.Windows.Forms.Application.StartupPath & "\Log")
                    End If

                    File.WriteAllText(spoolPath, args)

                    If _objini.GetKeyValue("PrintCtrl", "printHomologationLabel") <> "Yes" Then
                        Exit Sub
                    End If

                    ToolStripStatusLabelCurentInfo.Text = "[" & Now & "]  Printing Homologation Label: " & hpn

                    Shell(printCtrlApp & " " & spoolPath)

                    Writelog("Printed Homologation Label: " & args)

                End If

            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub PanelError_VisibleChanged(sender As Object, e As EventArgs) Handles PanelError.VisibleChanged
        If PanelError.Visible Then
            ButtonCloseError.Focus()
        End If
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        PanelStartOrder.Size = New Size(Me.Size.Width - 20, PanelStartOrder.Size.Height)
        PanelError.Size = New Size(Me.Size.Width - 20, PanelError.Size.Height)
        PanelWarning.Size = New Size(Me.Size.Width - 20, PanelWarning.Size.Height)
        PanelScanMaster.Size = New Size(Me.Size.Width - 20, PanelScanMaster.Size.Height)
    End Sub

    Private Sub WarningInterval()

        TimerNoWorkWarning.Enabled = False
        PanelWarning.Visible = False

        If OrderOpen = False Then
            Exit Sub
        End If

        Dim interval As String = _objini.GetKeyValue("WarningIntervals", "TimerNoWorkWarning")

        If interval <> vbNullString Then
            If IsNumeric(interval) Then
                If interval > 0 Then
                    TimerNoWorkWarning.Interval = CInt(interval) * 60000
                    TimerNoWorkWarning.Enabled = True
                Else
                    TimerNoWorkWarning.Enabled = False
                End If
            Else
                TimerNoWorkWarning.Enabled = False
            End If
        Else
            TimerNoWorkWarning.Enabled = False
        End If

    End Sub
    
    Private Sub TimerNoWorkWarning_Tick(sender As Object, e As EventArgs) Handles TimerNoWorkWarning.Tick

        Dim stopinterval As String = _objini.GetKeyValue("WarningIntervals", "TimerStopOrder")
        If stopinterval <> vbNullString Then
            If IsNumeric(stopinterval) Then
                StopOrderTimer = CInt(stopinterval) * 60
                LabelWarning.Text = "No Activity" & vbNewLine & "Order closing in " & Format(Math.Floor(StopOrderTimer / 60), "00") & ":" & Format(StopOrderTimer Mod 60, "00")
                PanelWarning.Visible = True
                TimerStopOrder.Enabled = True
            End If
        End If

    End Sub

    Private Sub TimerStopOrder_Tick(sender As Object, e As EventArgs) Handles TimerStopOrder.Tick
        StopOrderTimer -= 1
        Console.WriteLine(StopOrderTimer)
        If StopOrderTimer = 0 Then

            TimerStopOrder.Enabled = False

            PanelWarning.Visible = False

            'close the order automaticaly
            Try

                If OrderOpen Then

                    If DataGridViewOrders.Rows.Count > 0 Then

                        'update order status to STOPPED
                        T_orderListTableAdapter1.UpdateStatus("Stopped", CInt(DataGridViewOrders.Rows(0).Cells("ColumnOrderNo").Value))
                        DataGridViewOrders.Rows.RemoveAt(0)
                        OrderOpen = False
                        PackFactor = 0
                        TotalPartsInOrder = 0
                        LabelLabelCount.Text = vbNullString
                        LogCurrentStatus(vbNullString, 0)
                        Writelog("Order Stopped by No Activity timer")

                    End If
                End If

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        Else
            If PanelWarning.Visible Then
                LabelWarning.Text = "No Activity" & vbNewLine & "Order closing in " & Format(Math.Floor(StopOrderTimer / 60), "00") & ":" & Format(StopOrderTimer Mod 60, "00")
            Else
                TimerStopOrder.Enabled = False
                StopOrderTimer = 0
            End If
        End If


    End Sub

    Private Sub PanelWarning_VisibleChanged(sender As Object, e As EventArgs) Handles PanelWarning.VisibleChanged
        If PanelWarning.Visible Then
            TimerNoWorkWarning.Enabled = False
            ButtonWarningCancel.Focus()
        Else
            WarningInterval()
        End If
    End Sub

    Private Sub ButtonWarningCancel_Click(sender As Object, e As EventArgs) Handles ButtonWarningCancel.Click
        PanelWarning.Visible = False
    End Sub

    Private Sub TimerCountBlink_Tick(sender As Object, e As EventArgs) Handles TimerCountBlink.Tick
        LabelLabelCount.BackColor = Color.Transparent
        LabelLabelCount.ForeColor = Color.Black
        TimerCountBlink.Enabled = False
    End Sub

    Private Sub ToolStripStatusLabelCurentInfo_TextChanged(sender As Object, e As EventArgs) Handles ToolStripStatusLabelCurentInfo.TextChanged
        If ToolStripStatusLabelCurentInfo.Text <> vbNullString Then

            TimerHideCurentStatus.Enabled = False

            If Mid(ToolStripStatusLabelCurentInfo.Text, 1, 1) = "[" Then
                Writelog(Mid(ToolStripStatusLabelCurentInfo.Text, 24))
            End If

            TimerHideCurentStatus.Enabled = True
        Else
            TimerHideCurentStatus.Enabled = False
        End If
    End Sub

    Private Sub TimerHideCurentStatus_Tick(sender As Object, e As EventArgs) Handles TimerHideCurentStatus.Tick
        ToolStripStatusLabelCurentInfo.Text = vbNullString
    End Sub

    Private Sub btno_query_Click(sender As Object, e As EventArgs) Handles btno_query.Click
        Try
            Dim created As String = vbNullString
            Dim started As String = vbNullString
            Dim stopped As String = vbNullString

            If cbo_created.Checked Then
                created = "Created"
            End If

            If cbo_started.Checked Then
                started = "Started"
            End If

            If cbo_stopped.Checked Then
                stopped = "Stopped"
            End If

            Dim paramArr(2) As String
            paramArr(0) = created
            paramArr(1) = started
            paramArr(2) = stopped

            T_orderListBindingSource.Filter = vbNullString

            T_orderListDataGridView.DataSource = Nothing

            '    Ru_sb_tames1.t_orderList.Rows.Clear()

            ToolStripProgressBar1.Visible = True
            btno_query.Enabled = False


            BackgroundWorkerQueryOrders.RunWorkerAsync(paramArr)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub BackgroundWorkerQueryOrders_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorkerQueryOrders.DoWork
        Try
            Dim paramArr() As String
            paramArr = CType(e.Argument, String())
            T_orderListTableAdapter1.FillByoStatus(Ru_sb_tames1.t_orderList, paramArr(0), paramArr(1), paramArr(2))
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub BackgroundWorkerQueryOrders_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorkerQueryOrders.RunWorkerCompleted

        ToolStripProgressBar1.Visible = False
        btno_query.Enabled = True
        T_orderListDataGridView.DataSource = T_orderListBindingSource
        ' T_orderListBindingSource.ResetBindings(False)

    End Sub

    Private Sub tbo_Order_KeyDown(sender As Object, e As KeyEventArgs) Handles tbo_Order.KeyDown
        Try
            If e.KeyCode = Keys.Return Then
                T_orderListBindingSource.Filter = "orderNo like '%" & tbo_Order.Text & "%'"
            End If

            If (e.KeyCode >= 48 And e.KeyCode <= 59) Or (e.KeyCode >= 96 And e.KeyCode <= 105) Or e.KeyCode = 8 Or e.KeyCode = 46 Or e.KeyCode = 37 Or e.KeyCode = 39 Then
            Else
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    
    Private Sub btno_addOrder_Click(sender As Object, e As EventArgs) Handles btno_addOrder.Click
        Try
            If Not IsNumeric(tbo_Order.Text) Then
                MsgBox("Invalid Order number")
                Exit Sub
            End If

            If Not IsNumeric(tbo_Qty.Text) Then
                MsgBox("Invalid quantity value")
                Exit Sub
            End If

            If cbo_partNo.Text = vbNullString Then
                MsgBox("Invalid Internal Part number")
                Exit Sub
            End If

            Dim linePos As Integer = InStr(cbo_partNo.Text, "-")
            Dim partLength As Integer = Len(cbo_partNo.Text)

            If linePos >= partLength Or linePos = 0 Then

                MsgBox("Part Number does not have a revision." & vbNewLine & "Please enter the revision")
                Exit Sub

            End If


            Me.Enabled = False

            If T_orderListTableAdapter1.CountOrder(tbo_Order.Text) = 0 Then

                If T_orderListTableAdapter1.InsertNewOrderNo(tbo_Order.Text, tbo_Qty.Text, cbo_partNo.Text, tbo_partDesc.Text, tbo_custPn.Text, tbo_custName.Text, "Created", 0, tbo_pLine.Text, vbNullString, vbNullString) > 0 Then
                    MsgBox("Order added succesfully")
                Else
                    MessageBox.Show("Error adding new order!" & vbNewLine & "Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                End If

                Me.Enabled = True
                Refresh()


                'querry crated orders

                cbo_created.Checked = True
                cbo_started.Checked = False
                cbo_stopped.Checked = False

                btno_query_Click(btno_query, New EventArgs())

            Else

                Me.Enabled = True
                MsgBox("Order " & tbo_Order.Text & " allready exists")

            End If

        Catch ex As Exception
            Me.Enabled = True
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub tbo_Order_Validated(sender As Object, e As EventArgs) Handles tbo_Order.Validated
        Try
            BackgroundWorkerFillOrderPNInfo.RunWorkerAsync()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub BackgroundWorkerFillOrderPNInfo_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorkerFillOrderPNInfo.DoWork
        Try
            Dim fillPn = CType(e.Argument, String)   'get the parameter indicating wheader to get all part numbers or a single one

            If fillPn <> vbNullString Then
                T_partListTableAdapter1.FillByPartNo(Ru_sb_tames1.t_partList, fillPn)
            Else
                T_partListTableAdapter1.Fill(Ru_sb_tames1.t_partList)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub BackgroundWorkerFillOrderPNInfo_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorkerFillOrderPNInfo.RunWorkerCompleted
        Try
            cbo_partNo.Items.Clear()
            For Each r As DataRow In Ru_sb_tames1.t_partList.Rows
                cbo_partNo.Items.Add(r.Item("partNo"))
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub cbo_partNo_TextChanged(sender As Object, e As EventArgs) Handles cbo_partNo.TextChanged
        Try
            If cbo_partNo.Text <> vbNullString Then

                Dim pn As String = cbo_partNo.Text
                Dim pnfR As String = vbNullString

                If InStr(pn, "-") > 0 Then
                    pnfR = Mid(pn, 1, InStr(pn, "-"))
                Else
                    pnfR = vbNullString
                End If

                If Ru_sb_tames1.t_partList.Rows.Count = 0 Then
                    T_partListTableAdapter1.Fill(Ru_sb_tames1.t_partList)
                End If

                Dim fRow As DataRow = Ru_sb_tames1.t_partList.Rows.Find(pnfR)

                If fRow IsNot Nothing Then
                    tbo_partDesc.Text = fRow.Item("partDesc")
                    tbo_custPn.Text = fRow.Item("custPartNo")
                    tbo_custName.Text = fRow.Item("custName")
                Else
                    tbo_partDesc.Text = vbNullString
                    tbo_custPn.Text = vbNullString
                    tbo_custName.Text = vbNullString
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    
    Private Sub btnp_query_Click(sender As Object, e As EventArgs) Handles btnp_query.Click
        btnp_query.Enabled = False
        ToolStripProgressBar1.Visible = True
        T_partListDataGridView.DataSource = Nothing
        BackgroundWorkerLoadPartTabel.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorkerLoadPartTabel_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorkerLoadPartTabel.DoWork
        Try
            T_partListTableAdapter1.Fill(Ru_sb_tames1.t_partList)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub BackgroundWorkerLoadPartTabel_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorkerLoadPartTabel.RunWorkerCompleted
        T_partListDataGridView.DataSource = T_partListBindingSource
        btnp_query.Enabled = True
        ToolStripProgressBar1.Visible = False
    End Sub
    
    Private Sub btn_AddPart_Click(sender As Object, e As EventArgs) Handles btn_AddPart.Click
        Try
            If Not IsNumeric(tbp_packfactor.Text) Then
                MessageBox.Show("Invalid Pack Factor", "Error Inserting new part number", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            Dim linetype As String = vbNullString

            For Each r In cbp_partType.Items
                If r = cbp_partType.Text Then
                    linetype = r
                End If
            Next

            If linetype = vbNullString Then
                MessageBox.Show("Invalid Production Line Type", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If Trim(tbp_partNo.Text).Substring(Len(tbp_partNo.Text) - 1) <> "-" Then
                If MessageBox.Show("Part number must end with ""-"" " & vbNewLine & " Continue anyway?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = _
                            DialogResult.No Then
                    Exit Sub
                End If
            End If

            If T_partListTableAdapter1.InsertNewPartNo(Trim(tbp_partNo.Text), _
                                                    Trim(tbp_partDesc.Text), _
                                                    Trim(tbp_custPartNo.Text), _
                                                    Trim(cbp_custName.Text), _
                                                    tbp_packfactor.Text, _
                                                    cbp_DGSymbol.Text, _
                                                    Trim(tbp_idComp.Text), _
                                                    tbp_partCounter.Text, _
                                                    Trim(cbp_HPN.Text), _
                                                    cbp_partType.Text,
                                                    tbp_labelType.Text,
                                                    tbp_suppliercode.Text) > 0 Then
                MsgBox("Part number added succesfully")

                btnp_query_Click(btnp_query, New EventArgs())

            Else
                MessageBox.Show("Error adding new part Number!" & vbNewLine & "Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    
    Private Sub btnh_query_Click(sender As Object, e As EventArgs) Handles btnh_query.Click
        Try
            btnh_query.Enabled = False
            ToolStripProgressBar1.Visible = True
            T_HLabelDataGridView.DataSource = Nothing
            BackgroundWorkerLoadHomoLabel.RunWorkerAsync()

        Catch ex As Exception
            btnh_query.Enabled = True
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub BackgroundWorkerLoadHomoLabel_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorkerLoadHomoLabel.DoWork
        Try
            t_HLabelTableAdapter1.Fill(Ru_sb_tames1.t_HLabel)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub BackgroundWorkerLoadHomoLabel_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorkerLoadHomoLabel.RunWorkerCompleted
        Try
            btnh_query.Enabled = True
            ToolStripProgressBar1.Visible = False
            T_HLabelDataGridView.DataSource = T_HLabelBindingSource
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub btnh_addHPN_Click(sender As Object, e As EventArgs) Handles btnh_addHPN.Click
        Try
            If tbh_partNo.Text = vbNullString Then
                Exit Sub
            End If
            If Not IsNumeric(tbh_layout.Text) Then
                MsgBox("Invalid layout number")
                Exit Sub
            End If
            If tbh_barcode.Text = vbNullString Then
                MsgBox("Invalid Barcode text")
                Exit Sub
            End If

            If t_HLabelTableAdapter1.InsertQuery(tbh_partNo.Text, _
                                             tbh_layout.Text, _
                                             tbh_custPn.Text, _
                                             tbh_modelNo.Text, _
                                             tbh_eceaptype.Text, _
                                             tbh_eceapnumber.Text, _
                                             tbh_eecaptype.Text, _
                                             tbh_eecapnumber.Text, _
                                             cbh_airbag.Text, _
                                             tbh_position.Text, _
                                             tbh_barcode.Text) > 0 Then

                MsgBox("Homologation Part number added succesfully")

                btnh_query_Click(btnh_query, New EventArgs())

            Else
                MessageBox.Show("Error adding new Homologation part Number!" & vbNewLine & "Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ButtonSettingsUpdate_Click(sender As Object, e As EventArgs) Handles ButtonSettingsUpdate.Click

        Try
            If MessageBox.Show("Update current info?", "Update Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                MsgBox(T_SettingsTableAdapter1.UpdateQuery(tbs_varValue.Text, T_SettingsDataGridView.Rows(T_SettingsDataGridView.SelectedCells(0).RowIndex).Cells(0).Value) & " row modified")
                T_SettingsTableAdapter1.Fill(Ru_sb_tames1.t_Settings)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub T_SettingsDataGridView_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles T_SettingsDataGridView.RowEnter
        Try
            tbs_varName.Text = T_SettingsDataGridView.Rows(e.RowIndex).Cells("DataGridViewTextBoxColumnvarName").Value
            tbs_varValue.Text = T_SettingsDataGridView.Rows(e.RowIndex).Cells("DataGridViewTextBoxColumnvarValue").Value
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ButtonSettingsAdd_Click(sender As Object, e As EventArgs) Handles ButtonSettingsAdd.Click
        Try
            If Ru_sb_tames1.t_Settings.Select("varName = '" & tbs_varName.Text & "'").Count = 0 Then

                If MessageBox.Show("Add current settings?", "Add setting", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                    MsgBox(T_SettingsTableAdapter1.InsertQuery(tbs_varName.Text, tbs_varValue.Text) & " row added")
                    T_SettingsTableAdapter1.Fill(Ru_sb_tames1.t_Settings)
                End If

            Else
                MessageBox.Show("Variable name already exists. This identificator cannot be duplicated", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                tbs_varName.Focus()
                tbs_varName.SelectAll()
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    
    Private Sub T_orderListDataGridView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles T_orderListDataGridView.CellDoubleClick
        Try
            With T_orderListDataGridView.Rows(e.RowIndex)
                tbo_Order.Text = .Cells("orderNo").Value
                tbo_Qty.Text = .Cells("orderQty").Value
                cbo_partNo.Text = .Cells("partNo").Value
                tbo_partDesc.Text = .Cells("partDesc").Value
                tbo_custPn.Text = .Cells("custpartNo").Value
                tbo_custName.Text = .Cells("custName").Value
                tbo_pLine.Text = .Cells("c1").Value
            End With

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub btno_delete_Click(sender As Object, e As EventArgs) Handles btno_delete.Click
        Try
            With T_orderListDataGridView.Rows(T_orderListDataGridView.CurrentCell.RowIndex)

                'if order is started then exit sub
                If .Cells("oStatus").Value = "Started" Then
                    MessageBox.Show("Cannot delete Started orders!", "Delete order", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                If MessageBox.Show("Delete order " & .Cells("orderNo").Value & " ?", "Delete order", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    T_orderListTableAdapter1.DeleteQuery(.Cells("orderNo").Value)
                    btno_query_Click(btno_query, New EventArgs())
                End If

            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub T_partListDataGridView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles T_partListDataGridView.CellDoubleClick
        Try

            With T_partListDataGridView.Rows(e.RowIndex)

                tbp_partNo.Text = .Cells("p_partNo").Value
                tbp_partDesc.Text = .Cells("p_partDesc").Value
                tbp_custPartNo.Text = .Cells("p_custPartNo").Value
                cbp_custName.Text = .Cells("p_custName").Value
                tbp_packfactor.Text = .Cells("p_packfactor").Value
                cbp_DGSymbol.Text = .Cells("p_DGSymbol").Value
                cbp_HPN.Text = .Cells("p_c1").Value
                tbp_idComp.Text = .Cells("p_BCinfo1").Value
                tbp_partCounter.Text = .Cells("p_BCinfo2").Value
                cbp_partType.Text = .Cells("p_c2").Value
                If Not IsDBNull(.Cells("p_c3").Value) Then
                    tbp_labelType.Text = .Cells("p_c3").Value
                Else
                    tbp_labelType.Text = vbNullString
                End If
                If Not IsDBNull(.Cells("suppliercode").Value) Then
                    tbp_suppliercode.Text = .Cells("suppliercode").Value
                Else
                    tbp_suppliercode.Text = vbNullString
                End If

            End With

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub btnp_Delete_Click(sender As Object, e As EventArgs) Handles btnp_Delete.Click
        Try
            With T_partListDataGridView.Rows(T_partListDataGridView.CurrentCell.RowIndex)

                If MessageBox.Show("Delete part number " & .Cells("p_partNo").Value & " ?", "Delete Part Number", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

                    T_partListTableAdapter1.DeleteQuery(.Cells("p_partNo").Value)
                    With Ru_sb_tames1.t_partList.Select("partNo = '" & .Cells("p_partNo").Value & "'")
                        If .Count > 0 Then
                            Dim dr As DataRow = .GetValue(0)
                            dr.Delete()
                        End If
                    End With
                    'btnp_query_Click(btnp_query, New System.EventArgs())
                End If

            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub T_HLabelDataGridView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles T_HLabelDataGridView.CellDoubleClick
        Try
            With T_HLabelDataGridView.Rows(e.RowIndex)

                tbh_partNo.Text = .Cells("h_labelPN").Value
                tbh_layout.Text = .Cells("h_labelLayout").Value
                tbh_custPn.Text = .Cells("h_IdentificationNo").Value
                tbh_modelNo.Text = .Cells("h_ModelNo").Value
                tbh_eceaptype.Text = .Cells("h_ECEApprovalType").Value
                tbh_eceapnumber.Text = .Cells("h_ECEApprovalNo").Value
                tbh_eecaptype.Text = .Cells("h_EECApprovalType").Value
                tbh_eecapnumber.Text = .Cells("h_EECApprovalNo").Value
                tbh_position.Text = .Cells("h_PretensionerType").Value
                tbh_barcode.Text = .Cells("h_BarCode").Value

                Select Case .Cells("h_AIRBAG").Value
                    Case Is = 0
                        cbh_airbag.Text = "False"
                    Case Is = 1
                        cbh_airbag.Text = "True"
                End Select

            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub btnh_delete_Click(sender As Object, e As EventArgs) Handles btnh_delete.Click
        Try

            With T_HLabelDataGridView.CurrentRow

                If MessageBox.Show("Delete Homologation Part Number " & .Cells("h_labelPN").Value & " ?", "Delete Homologation Part Number", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    t_HLabelTableAdapter1.DeleteQuery(.Cells("h_labelPN").Value)
                    btnh_query_Click(btnh_query, New EventArgs())
                End If

            End With

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub btn_FindBarcode_Click(sender As Object, e As EventArgs) Handles btn_FindBarcode.Click
        Try
            btn_FindBarcode.Enabled = False
            ToolStripProgressBar1.Visible = True
            T_labelsDataGridView.DataSource = Nothing

            BackgroundWorkerLoadCustLabel.RunWorkerAsync(tb_lblBarcode.Text)

            'T_labelsTableAdapter1.FillByLabel(Ru_sb_tames1.t_labels, "%" & tb_lblBarcode.Text & "%")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ButtonCancelMaster_Click(sender As Object, e As EventArgs) Handles ButtonCancelMaster.Click
        PanelScanMaster.Visible = False
        ButtonOpenOrder.Enabled = True
    End Sub

    Private Sub PanelScanMaster_VisibleChanged(sender As Object, e As EventArgs) Handles PanelScanMaster.VisibleChanged
        If PanelScanMaster.Visible Then
            'TimerStartOrder.Enabled = True
            ButtonCancelScanOrder.Focus()
        Else
            TimerStartOrder.Enabled = False
        End If
    End Sub

    Private Sub BackgroundWorkerLoadCustLabel_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorkerLoadCustLabel.DoWork
        Try
            T_labelsTableAdapter1.FillByLabel(Ru_sb_tames1.t_labels, "%" & e.Argument & "%")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub BackgroundWorkerLoadCustLabel_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorkerLoadCustLabel.RunWorkerCompleted
        T_labelsDataGridView.DataSource = T_labelsBindingSource
        btn_FindBarcode.Enabled = True
        ToolStripProgressBar1.Visible = False
    End Sub

    Private Sub btno_PrintBL_Click(sender As Object, e As EventArgs) Handles btno_PrintBL.Click
        Try
            If T_orderListDataGridView.SelectedCells.Count = 1 Then
                Dim lcount = 0
                Dim boxNo = 0
                Dim reprint = False
                Try
                    If CultureInfo.CurrentUICulture.ToString = "ru-RU" Then

                        '----------------------translate to Russia
                        If MessageBox.Show("Перепечатано этикетки?", "Перепечатано этикетки?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            reprint = True
                        End If

                        lcount = InputBox("Введите желаемое количество этикеток", "Распечатать этикетку для коробки", 1)
                    Else

                        If MessageBox.Show("Are these labels reprinted?", "Reprint", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                            reprint = True
                        End If

                        lcount = InputBox("Enter the number of labels needed", "Print Box Labels", 1)

                    End If

                    If reprint Then
                        For i = 1 To lcount
                            boxNo = InputBox("Enter Box Number that will be printed on label no " & i.ToString, "Print Box Labels", 1)
                            PrintBoxLabelManual(boxNo, reprint)
                        Next
                    Else
                        PrintBoxLabelManual(boxNo, reprint, lcount)
                    End If

                    btno_query_Click(btno_query, New EventArgs())

                Catch ex As Exception
                    MsgBox("Invalid number entered")
                    Exit Sub
                End Try
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ButtonChangeCounter_Click(sender As Object, e As EventArgs) Handles ButtonChangeCounter.Click
        Try

            If OrderOpen = True Then

                Dim counter = 0
                Dim result As Object

                If LoginForm1.ShowDialog(Me) = DialogResult.OK Then

                    Try
                        If CultureInfo.CurrentUICulture.ToString = "ru-RU" Then

                            result = InputBox("Введите количество произведенных изделий", "Изменить счетчик изделий", PackFactor)

                        Else

                            result = InputBox("Enter the correct number of parts produced", "Change part count", PackFactor)

                        End If

                        If IsNumeric(result) Then
                            counter = CInt(result)

                            'modify count
                            _curentInfoIni.SetKeyValue("CurentInfo", "parts", counter.ToString)
                            _curentInfoIni.Save(_curentIniPath)
                            LabelLabelCount.Text = counter.ToString & " / " & PackFactor.ToString

                        End If

                    Catch ex As Exception
                        MsgBox("Invalid Number")
                    End Try

                End If



            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub btnProdFind_Click(sender As Object, e As EventArgs) Handles btnProdFind.Click
        Try
            dgvProd.DataSource = Nothing
            System.Windows.Forms.Application.DoEvents()
            'BindingSourceProductivity.DataMember = vbNullString
            'BindingSourceProductivity.DataSource = Nothing
            If Len(tbProdLine.Text) = 3 Then
                ToolStripProgressBar1.Visible = True
                btnProdFind.Enabled = False

                BackgroundWorkerProductivity1.RunWorkerAsync(New Object() {dtpProdStart.Value.ToString("dd.MM.yyyy"),
                                                                                  dtpProdEnd.Value.ToString("dd.MM.yyyy"),
                                                                                  tbProdLine.Text,
                                                                                  dtpBeginOfTimeFilter.Value,
                                                                                  dtpEndOfTimeFilter.Value})

            Else
                MsgBox("Invalid Line Name")
            End If

        Catch ex As Exception
            btnProdFind.Enabled = True
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub BackgroundWorkerProductivity1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorkerProductivity1.DoWork
        Try

            Dim param = DirectCast(e.Argument, Object)

            Ru_sb_tames1.t_productivity.Columns.Clear()


            ' задача: заполнить для каждого часа из интервала, заданного через фильтр, сколкько же реально работала линия
            ' заполнить с агрегацией, так же, как и продуктивность
            For i = 0 To _workTimeInMinuts.Length - 1
                _workTimeInMinuts(i) = 0 ' избавляемся от старых данных
            Next

            If CType(param(3), Date).Hour = CType(param(4), Date).Hour Then 'интервал фильтрации час или меньше
                Dim hour = CType(param(3), Date).Hour
                _workTimeInMinuts(hour) = 60 - SumOfBreaksInMinuts(param(2).ToString(), CType(param(3), Date).ToString("HH:mm"), CType(param(4), Date).ToString("HH:mm"))
            Else
                For i = CType(param(3), Date).Hour To CType(param(4), Date).Hour ' перерывы для каждого часа
                    If i = CType(param(3), Date).Hour Then ' час От
                        _workTimeInMinuts(i) = 60 - CType(param(3), Date).Minute - SumOfBreaksInMinuts(param(2).ToString(), CType(param(3), Date).ToString("HH:mm"), TimeSpan.FromHours(i + 1).ToString("hh\:mm"))
                    ElseIf i = CType(param(4), Date).Hour Then ' час До
                        _workTimeInMinuts(i) = CType(param(4), Date).Minute - SumOfBreaksInMinuts(param(2).ToString(), TimeSpan.FromHours(i).ToString("hh\:mm"), CType(param(4), Date).ToString("HH:mm"))
                    Else ' интервал
                        _workTimeInMinuts(i) = 60 - SumOfBreaksInMinuts(param(2).ToString(), TimeSpan.FromHours(i).ToString("hh\:mm"), TimeSpan.FromHours(i + 1).ToString("hh\:mm"))
                    End If
                Next
                For i = CType(param(3), Date).Hour + 1 To CType(param(4), Date).Hour ' агрегация
                    _workTimeInMinuts(i) += _workTimeInMinuts(i - 1)
                Next
            End If

            If InStr(param(2), "H") > 0 Then
                T_productivityTableAdapter1.Fill(Ru_sb_tames1.t_productivity, param(0), param(1), param(2), CType(param(3), Date).ToString("HH:mm"), CType(param(4), Date).ToString("HH:mm"))
            Else
                T_productivityTableAdapter1.FillBy(Ru_sb_tames1.t_productivity, param(0), param(1), param(2), CType(param(3), Date).ToString("HH:mm"), CType(param(4), Date).ToString("HH:mm"))
            End If

            ' в связи с введенеием в программу простоев, нужна кололнка, которая покажет,
            ' сколько минут работали до текущего часа на текущую дату
            ' алгоритм рассчёта:
            ' 1. запросить таблицу перерывов за период времени от начала фильтра до конца текущего часа или конца фильтра (что меньше)
            ' 2. на основании записей в таблице сформировать интервалы работы
            ' 3. запросить у таблицы простоев сумму всех простоев за каждый рабочий промежуток на текущую дату
            ' 4. вычесть из всего рабочего времени все простои

            Ru_sb_tames1.t_productivity.Columns.Add("work_in_minutes")

            With Ru_sb_tames1.t_productivity
                Dim timeFrom = CType(param(3), Date)
                Dim timeFromStr = timeFrom.ToString("HH:mm")
                Dim timeTo = CType(param(4), Date)
                For r = 0 To .Rows.Count - 1
                    'Dim endOfHour = New Date(timeTo.Year, timeTo.Month, timeTo.Day, Integer.Parse(.Rows(r).Item("ora").ToString().Split("-"c)(1)), 0, 0)
                    Dim endOfHour = Integer.Parse(.Rows(r).Item("ora").ToString().Split("-"c)(1))
                    Dim timeToStr As String
                    Dim sumOfWorkMin As Integer = 0
                    If endOfHour > timeTo.Hour Then
                        timeToStr = timeTo.ToString("HH:mm")
                        sumOfWorkMin = (timeTo - timeFrom).TotalMinutes
                    Else
                        timeToStr = TimeSpan.FromHours(endOfHour).ToString("hh\:mm")
                        sumOfWorkMin = (TimeSpan.FromHours(endOfHour) - timeFrom.TimeOfDay).TotalMinutes
                    End If
                    Dim tableOfBreaks = T_linesBreaksTableAdapter.GetDataByLineNtime(timeFrom.TimeOfDay, TimeSpan.Parse(timeToStr),
                                                                                     LineName)
                    Dim beginIntervalStr As String = timeFromStr
                    Dim endIntervalStr As String = timeFromStr
                    Dim sumOfInterruptsMin = 0
                    Dim sumOfBreaksMin = SumOfBreaksInMinuts(LineName, timeFromStr, timeToStr)
                    Dim accidentDate = DirectCast(.Rows(r).Item(3), Date) ' дата из таблицы продуктивностей, которую заполняем

                    For r2 = 0 To tableOfBreaks.Rows.Count - 1
                        Debug.WriteLine(tableOfBreaks.Rows(r2).Item("timeFrom").ToString() & " - " & tableOfBreaks.Rows(r2).Item("timeTo").ToString())

                        endIntervalStr = tableOfBreaks.Rows(r2).Item("timeFrom").ToString()
                        sumOfInterruptsMin += SumOfInterruptsInMinuts(LineName,
                                                                      beginIntervalStr,
                                                                      endIntervalStr,
                                                                      accidentDate)
                        beginIntervalStr = tableOfBreaks.Rows(r2).Item("timeTo").ToString()
                    Next

                    endIntervalStr = timeToStr
                    sumOfInterruptsMin += SumOfInterruptsInMinuts(LineName,
                                                                  beginIntervalStr,
                                                                  endIntervalStr,
                                                                  accidentDate)

                    .Rows(r).Item("work_in_minutes") = sumOfWorkMin - sumOfInterruptsMin - sumOfBreaksMin
                Next
            End With

        Catch ex As NullReferenceException
            MsgBox(ex.ToString)
        End Try
    End Sub
    
    Private Sub BackgroundWorkerProductivity1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorkerProductivity1.RunWorkerCompleted
        Try
            'add column pcs/day or pcs/order 
            Dim colCompare As String = vbNullString

            If rbGroupByDate.Checked Then
                colCompare = "logDate"
            Else
                'reset at order swich 
                colCompare = "orderNo"
            End If

            With Ru_sb_tames1.t_productivity
                .Columns.Add("pcs_total")
                .Columns.Add("productivity")
                .Columns.Add("productivity_check")
                For r = 0 To .Rows.Count - 1
                    If r = 0 Then
                        .Rows(r).Item("pcs_total") = .Rows(r).Item("nr")
                    Else
                        If .Rows(r - 1).Item(colCompare) = .Rows(r).Item(colCompare) Then
                            .Rows(r).Item("pcs_total") = .Rows(r - 1).Item("pcs_total") + .Rows(r).Item("nr")
                        Else
                            .Rows(r).Item("pcs_total") = .Rows(r).Item("nr")
                        End If
                    End If

                    Dim hours = Integer.Parse(.Rows(r).Item("ora").ToString().Substring(0, 2))
                    Dim workedMinuts = _workTimeInMinuts(hours)
                    If (workedMinuts > 0) Then
                        .Rows(r).Item("productivity_check") = Math.Round(.Rows(r).Item("pcs_total") * 60 / workedMinuts)
                    Else
                        .Rows(r).Item("productivity_check") = 0
                    End If
                    .Rows(r).Item("productivity") = Math.Round(.Rows(r).Item("pcs_total") * 60 / .Rows(r).Item("work_in_minutes"))
                Next

                If tbLeitzahl.Text <> vbNullString Then
                    Dim lz As String = tbLeitzahl.Text
                    For r = .Rows.Count - 1 To 0 Step -1
                        If Not .Rows(r).Item("orderNo") Like "*" & lz & "*" Then
                            .Rows(r).Delete()
                        End If
                    Next
                End If
                .AcceptChanges()
            End With

            dgvProd.DataSource = Ru_sb_tames1.t_productivity   'BindingSourceProductivity 

            ToolStripProgressBar1.Visible = False
            btnProdFind.Enabled = True
            With dgvProd
                .Columns("orderNo").HeaderText = "Заказ №"
                .Columns("partNo").HeaderText = "Номер изделия"
                .Columns("partDesc").HeaderText = "Описание изделия"
                .Columns("logDate").HeaderText = "Дата"
                .Columns("ora").HeaderText = "Период"
                .Columns("nr").HeaderText = "Количество"
                .Columns("pcs_total").HeaderText = "Количество всего"
                .Columns("productivity").HeaderText = "Средняя производительность"
                .Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With

            dgvProd.Columns("work_in_minutes").Visible = False
            dgvProd.Columns("productivity_check").Visible = False

        Catch ex As Exception
            btnProdFind.Enabled = True
            MsgBox(ex.ToString)
        End Try
    End Sub
    
    Private Sub ToolStripStatusLabelLineName_TextChanged(sender As Object, e As EventArgs) Handles ToolStripStatusLabelLineName.TextChanged
        tbProdLine.Text = ToolStripStatusLabelLineName.Text
    End Sub

    Private Sub rbGroupByDate_CheckedChanged(sender As Object, e As EventArgs) Handles rbGroupByDate.CheckedChanged
        Try
            Dim colCompare As String = vbNullString

            If rbGroupByDate.Checked Then
                colCompare = "logDate"
            Else
                'reset at order swich 
                colCompare = "orderNo"
            End If

            With Ru_sb_tames1.t_productivity
                For r = 0 To .Rows.Count - 1
                    If r = 0 Then
                        .Rows(r).Item("pcs_total") = .Rows(r).Item("nr")
                    Else
                        If .Rows(r - 1).Item(colCompare) = .Rows(r).Item(colCompare) Then
                            .Rows(r).Item("pcs_total") = .Rows(r - 1).Item("pcs_total") + .Rows(r).Item("nr")
                        Else
                            .Rows(r).Item("pcs_total") = .Rows(r).Item("nr")
                        End If
                    End If

                    Dim hours = Integer.Parse(.Rows(r).Item("ora").ToString().Substring(0, 2))
                    Dim workedMinuts = _workTimeInMinuts(hours)
                    If (workedMinuts > 0) Then
                        .Rows(r).Item("productivity") = Math.Round(.Rows(r).Item("pcs_total") * 60 / workedMinuts)
                    Else
                        .Rows(r).Item("productivity") = 0
                    End If
                Next
            End With
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub dgvBreaks_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles dgvBreaks.UserDeletedRow
        T_linesBreaksTableAdapter.Update(CType(dgvBreaks.DataSource, BindingSource).DataSource)
        respawnLineStateTimers()
    End Sub

    Private Sub dgvBreaks_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBreaks.CellEndEdit
        Dim dgv = DirectCast(sender, DataGridView)
        Dim row = dgv.Rows.Item(e.RowIndex)
        T_linesBreaksTableAdapter.UpdateQuery(row.Cells("BreaksLineIDDataGridViewTextBoxColumn").Value.ToString(),
                                              Date.Parse(row.Cells("BeginBreakTimeDataGridViewTextBoxColumn").Value.ToString()),
                                              Date.Parse(row.Cells("EndBreakTimeDataGridViewTextBoxColumn").Value.ToString()),
                                              row.Cells("CommentDataGridViewTextBoxColumn").Value.ToString(),
                                              Integer.Parse(row.Cells("BreaksIDDataGridViewTextBoxColumn").Value.ToString()))
        respawnLineStateTimers()
    End Sub

    Private Sub btnAddBreak_Click(sender As Object, e As EventArgs) Handles btnAddBreak.Click
        T_linesBreaksTableAdapter.InsertQuery(tbBreaksLineID.Text, dtpBeginBreak.Value, dtpEndBreak.Value, tbComment.Text)
        T_linesBreaksTableAdapter.Fill(Me.Sb_tamesBreaksDataSet.t_linesBreaks)
        respawnLineStateTimers()
    End Sub

    Private Sub dgvInterrupts_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles dgvInterrupts.UserDeletedRow
        T_linesInterruptsTableAdapter.Update(CType(dgvInterrupts.DataSource, BindingSource).DataSource)
    End Sub

    Private Sub dgvInterrupts_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInterrupts.CellEndEdit
        Try
            Dim dgv = DirectCast(sender, DataGridView)
            Dim row = dgv.Rows.Item(e.RowIndex)
            Dim accidentDate = Date.Parse(row.Cells("AccidentDateDataGridViewTextBoxColumn").Value.ToString())
            Dim interruptTimestamp = Date.Parse(row.Cells("InterruptTimestampDataGridViewTextBoxColumn").Value.ToString())
            Dim beginRepairTimestamp = Date.Parse(row.Cells("BeginRepairTimestampDataGridViewTextBoxColumn").Value.ToString())
            Dim endOfInterruptTimestamp = Date.Parse(row.Cells("EndOfInterruptTimestampDataGridViewTextBoxColumn").Value.ToString())
            T_linesInterruptsTableAdapter.UpdateQuery(accidentDate,
                                                      row.Cells("GangDataGridViewTextBoxColumn").Value.ToString(),
                                                      row.Cells("InterruptsLineIDDataGridViewTextBoxColumn").Value.ToString(),
                                                      row.Cells("EquipmentNameDataGridViewTextBoxColumn").Value.ToString(),
                                                      interruptTimestamp,
                                                      beginRepairTimestamp,
                                                      endOfInterruptTimestamp,
                                                      row.Cells("InterruptCodeDataGridViewTextBoxColumn").Value.ToString(),
                                                      row.Cells("CauseOfInterruptDataGridViewTextBoxColumn").Value.ToString(),
                                                      row.Cells("CarriedOutActionsDataGridViewTextBoxColumn").Value.ToString(),
                                                      row.Cells("WhoIsLastDataGridViewTextBoxColumn").Value.ToString(),
                                                      Integer.Parse(row.Cells("InterruptsNoDataGridViewTextBoxColumn").Value.ToString()))
        Catch ex As FormatException
            MessageBox.Show("Проверьте правильность введённых данных", "Ошибка ввода даты и времени", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnInterruptsFilterApply_Click(sender As Object, e As EventArgs) Handles btnInterruptsFilterApply.Click
        T_linesInterruptsTableAdapter.FillAndCalculateBy(Me.Sb_tamesInterruptsDataSet.t_linesInterrupts,
                                                         dtpInterruptsFilterDateFrom.Value,
                                                         dtpInterruptsFilterDateTo.Value,
                                                         cbInterruptLineIDfilter.Text,
                                                         cbInterruptLineIDfilter.Text,
                                                         dtpInterruptsFilterTimeFrom.Value.TimeOfDay,
                                                         dtpInterruptsFilterDateTo.Value.TimeOfDay)
    End Sub

    Private Sub btnInterruptFilterReset_Click(sender As Object, e As EventArgs) Handles btnInterruptFilterReset.Click
        T_linesInterruptsTableAdapter.FillAndCalculate(Me.Sb_tamesInterruptsDataSet.t_linesInterrupts)
    End Sub

    Private Sub btnInterruptsExport_Click(sender As Object, e As EventArgs) Handles btnInterruptsExport.Click
        Dim dgv = dgvInterrupts
        If dgv.Rows.Count < 1 Then Return
        Dim dlg = New SaveFileDialog()
        dlg.Filter = "Файлы CSV (*.csv)|*.csv"
        If dlg.ShowDialog() <> DialogResult.OK Then Return

        Dim sw = New StreamWriter(dlg.FileName, False, Encoding.GetEncoding("windows-1251"))
        Dim str = exportInterruptsToCSV(dgv)
        sw.Write(str)
        sw.Close()
    End Sub

    Private Sub RespawnLineStateTimers(Optional sender As Object = vbNull) ' перевзвести все таймеры, по которым переключается состояние линии перерыв/работа (простой учитывается отдельно)
        Dim nowMs As Long = DateTime.Now.TimeOfDay.TotalMilliseconds ' Отправная точка для взвода таймеров
        _breakTimers.Clear()
        IsLineBreaked = False
        updateLineState()
        Dim tableOfBreaks = T_linesBreaksTableAdapter.GetDataByLine(LineName)

        With tableOfBreaks
            For row = 0 To tableOfBreaks.Rows.Count - 1
                Debug.WriteLine(.Rows(row).Item("beginBreakTime").ToString() & " - " & .Rows(row).Item("endBreakTime").ToString())
                Dim beginBreakMs As Long = .Rows(row).Item("beginBreakTime").TotalMilliseconds
                Dim endBreakMs As Long = .Rows(row).Item("endBreakTime").TotalMilliseconds

                If beginBreakMs > nowMs Then
                    Dim timerFrom As New Timer(AddressOf beginBreakOnLine, vbNull, beginBreakMs - nowMs, Timeout.Infinite)
                    Dim timerTo As New Timer(AddressOf endBreakOnLine, vbNull, endBreakMs - nowMs, Timeout.Infinite)
                    _breakTimers.Add(timerFrom)
                    _breakTimers.Add(timerTo)
                ElseIf endBreakMs > nowMs Then
                    Dim timerFrom As New Timer(AddressOf beginBreakOnLine, vbNull, 1, Timeout.Infinite)
                    Dim timerTo As New Timer(AddressOf endBreakOnLine, vbNull, endBreakMs - nowMs, Timeout.Infinite)
                    _breakTimers.Add(timerFrom)
                    _breakTimers.Add(timerTo)
                End If
            Next
        End With
        'Dim timerAutoRepeat As New Timer(AddressOf respawnLineStateTimers, vbNull, CType((24 * 60 * 60 * 1000 - nowMs), Long), Timeout.Infinite) ' передёргиваем таймер раз в сутки
        Dim timerAutoRepeat As New Timer(AddressOf respawnLineStateTimers, vbNull, CType(((DateTime.Now.TimeOfDay.TotalHours + 1) * 3600 * 1000 - nowMs), Long), Timeout.Infinite) ' передёргиваем таймер раз в час
        _breakTimers.Add(timerAutoRepeat)
    End Sub

    Private Sub BeginBreakOnLine(sender As Object) ' для вывода на панель оператора информации о том, что линия в состоянии "перерыв"
        IsLineBreaked = True
        updateLineState()
    End Sub

    Private Sub EndBreakOnLine(sender As Object) ' для вывода на панель оператора информации о том, что линия вышла из состояния "перерыв"
        IsLineBreaked = False
        updateLineState()
    End Sub

    Private Sub UpdateLineState()
        If labelLineState.InvokeRequired Then
            labelLineState.Invoke(New updateTextDelegate(AddressOf updateLineState))
        Else
            Dim currState As String = String.Empty
            If Not IsLineBreaked And _eoLcodesOk.Contains(LineStateCode) Then
                If labelLineState.ForeColor <> Color.Green Then
                    _currentPerformanceCounter.RespawnProductivity()
                End If
                labelLineState.ForeColor = Color.Green
                currState = "Линия " & LineName & Chr(13) & "Состояние: работает"
            ElseIf IsLineBreaked Then
                labelLineState.ForeColor = Color.Yellow
                currState = "Линия " & LineName & Chr(13) & "Состояние: перерыв"
            ElseIf _eoLcodes.ContainsKey(LineStateCode) Then
                labelLineState.ForeColor = Color.Red
                currState = "Линия " & LineName & Chr(13) & "Состояние: простой"
            End If

            labelLineState.Text = currState
        End If
    End Sub

    Private Sub ButtonLoadPlannedProductivity_Click(sender As Object, e As EventArgs) Handles ButtonLoadProductivity.Click
        Dim dlg = New OpenFileDialog()
        dlg.Filter = "Файлы CSV (*.csv)|*.csv"
        If dlg.ShowDialog() <> DialogResult.OK Then Return

        Dim pp = PpFromCsv(dlg.FileName)
        Dim applyDlg = New ProductivityApplyDlg(pp)
        If applyDlg.ShowDialog() = DialogResult.OK Then _plannedProductivity = pp
    End Sub
    
    Private Sub dgvInterrupts_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvInterrupts.DataBindingComplete
        For i = 0 To dgvInterrupts.Rows.Count - 1
            Dim row = dgvInterrupts.Rows(i)
            Dim eolCode = row.Cells.Item("InterruptCodeDataGridViewTextBoxColumn").Value
            Dim bc = row.Cells.Item("WhoIsLastDataGridViewTextBoxColumn").Value
            If _eoLcodes.ContainsKey(eolCode) Then row.Cells.Item("InterruptCodeDataGridViewTextBoxColumn").Value = _eoLcodes(eolCode)
            If _permitBClist.ContainsKey(bc) Then row.Cells.Item("WhoIsLastDataGridViewTextBoxColumn").Value = _permitBClist(bc)
        Next
    End Sub

    Private Shared Function TrimInfo(bData As String) As String
        Try
            'this function trims informations regarding deviations from barcode generated from AS400 order
            If InStr(bData, "-") > 0 Then
                bData = bData.Substring(0, InStr(bData, "-") + 2)
            End If

            Return bData
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return vbNullString
        End Try
    End Function

    Private Shared Sub tbo_Qty_KeyDown(sender As Object, e As KeyEventArgs) Handles tbo_Qty.KeyDown
        If (e.KeyCode >= 48 And e.KeyCode <= 59) Or (e.KeyCode >= 96 And e.KeyCode <= 105) Or e.KeyCode = 8 Or e.KeyCode = 46 Or e.KeyCode = 37 Or e.KeyCode = 39 Then
        Else
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Shared Function NowTimeRoundToMinute() As Date?
        Dim ret = Date.Now
        ret = New Date(ret.Year, ret.Month, ret.Day, ret.Hour, ret.Minute, 0)
        Return ret
    End Function

    Private Shared Sub ButtonSettingsDelete_Click(sender As Object, e As EventArgs) Handles ButtonSettingsDelete.Click
        Try

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Shared Function CustCounter(value As String) As String

        'value must bee 3 characters long

        Dim c1 As Integer = Asc(Mid(value, 1, 1))
        Dim c2 As Integer = Asc(Mid(value, 2, 1))
        Dim c3 As Integer = Asc(Mid(value, 3, 1))

        c3 += 1

        If c3 = 58 Then   'from 9 to A
            c3 = 65
        End If

        If c3 = 73 Then   ' if c3 = I then c3 = J
            c3 = 74
        End If

        If c3 = 79 Then   ' if c3 = O then c3 = P
            c3 = 80
        End If

        If c3 = 91 Then  'from A to increment next digit
            c3 = 48   'set last digit to 0
            c2 += 1     'increment next digit
        End If

        If c2 = 73 Then   ' if c2 = I then c2 = J
            c2 = 74
        End If

        If c2 = 79 Then   ' if c2 = O then c2 = P
            c2 = 80
        End If

        If c2 = 58 Then   'from 9 to A
            c2 = 65
        End If

        If c2 = 91 Then 'from A to increment next digit
            c2 = 48     'set second digit to 0
            c1 += 1     'increment next digit
        End If

        If c1 = 58 Then   'from 9 to A
            c1 = 65
        End If

        If c1 = 73 Then   ' if c1 = I then c1 = J
            c1 = 74
        End If

        If c1 = 79 Then   ' if c1 = O then c1 = P
            c1 = 80
        End If

        If c1 = 91 Then 'from A to increment next digit
            c1 = 48      'set second digit to 0
            c2 = 48
            c3 = 48
        End If

        Return Chr(c1) & Chr(c2) & Chr(c3)

    End Function

    Private Shared Sub tbp_packfactor_KeyDown(sender As Object, e As KeyEventArgs) Handles tbp_packfactor.KeyDown
        If (e.KeyCode >= 48 And e.KeyCode <= 59) Or (e.KeyCode >= 96 And e.KeyCode <= 105) Or e.KeyCode = 8 Or e.KeyCode = 46 Or e.KeyCode = 37 Or e.KeyCode = 39 Then
        Else
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Shared Sub tbp_partCounter_KeyDown(sender As Object, e As KeyEventArgs) Handles tbp_partCounter.KeyDown
        If (e.KeyCode >= 48 And e.KeyCode <= 59) Or (e.KeyCode >= 96 And e.KeyCode <= 105) Or e.KeyCode = 8 Or e.KeyCode = 46 Or e.KeyCode = 37 Or e.KeyCode = 39 Then
        Else
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Shared Sub cbp_custName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbp_custName.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Shared Sub cbp_HPN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbp_HPN.KeyPress
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Shared Sub tbh_layout_KeyDown(sender As Object, e As KeyEventArgs) Handles tbh_layout.KeyDown
        If (e.KeyCode >= 48 And e.KeyCode <= 59) Or (e.KeyCode >= 96 And e.KeyCode <= 105) Or e.KeyCode = 8 Or e.KeyCode = 46 Or e.KeyCode = 37 Or e.KeyCode = 39 Then
        Else
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Shared Sub dgvInterrupts_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInterrupts.CellValueChanged
        If e.RowIndex < 0 Or e.ColumnIndex < 0 Then Exit Sub
        Dim dgv = DirectCast(sender, DataGridView)
        Dim col = dgv.Columns.Item(e.ColumnIndex)
        Dim row = dgv.Rows.Item(e.RowIndex)
        Try
            If col.Name = "InterruptTimestampDataGridViewTextBoxColumn" Then 'calculate mainteranceWaitingInterval and interruptDuration
                Dim interruptTimestamp = Date.Parse(row.Cells("InterruptTimestampDataGridViewTextBoxColumn").Value.ToString())
                Dim beginRepairTimestamp = Date.Parse(row.Cells("BeginRepairTimestampDataGridViewTextBoxColumn").Value.ToString())
                Dim endOfInterruptTimestamp = Date.Parse(row.Cells("EndOfInterruptTimestampDataGridViewTextBoxColumn").Value.ToString())
                row.Cells("MainteranceWaitingIntervalDataGridViewTextBoxColumn").Value = (beginRepairTimestamp - interruptTimestamp).ToString()
                row.Cells("InterruptDurationDataGridViewTextBoxColumn").Value = (endOfInterruptTimestamp - interruptTimestamp).ToString()
            ElseIf col.Name = "BeginRepairTimestampDataGridViewTextBoxColumn" Then 'calcaulae mainteranceWaitingInterval
                Dim interruptTimestamp = Date.Parse(row.Cells("InterruptTimestampDataGridViewTextBoxColumn").Value.ToString())
                Dim beginRepairTimestamp = Date.Parse(row.Cells("BeginRepairTimestampDataGridViewTextBoxColumn").Value.ToString())
                row.Cells("MainteranceWaitingIntervalDataGridViewTextBoxColumn").Value = (beginRepairTimestamp - interruptTimestamp).ToString()
            ElseIf col.Name = "EndOfInterruptTimestampDataGridViewTextBoxColumn" Then 'calcaulae interruptDuration
                Dim interruptTimestamp = Date.Parse(row.Cells("InterruptTimestampDataGridViewTextBoxColumn").Value.ToString())
                Dim endOfInterruptTimestamp = Date.Parse(row.Cells("EndOfInterruptTimestampDataGridViewTextBoxColumn").Value.ToString())
                row.Cells("InterruptDurationDataGridViewTextBoxColumn").Value = (endOfInterruptTimestamp - interruptTimestamp).ToString()
            End If
        Catch ex As FormatException
            MessageBox.Show("Проверьте правильность введённого времени", "Время не распознано", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Shared Function SumOfBreaksInMinuts(lineId As String, timeFrom As String, timeTo As String) As UInt32
        Dim odbcConnector As New OdbcCommand()
        odbcConnector.Connection = New OdbcConnection(MySettings.Default.ru_sb_tames)
        odbcConnector.CommandText = "SELECT sum(least(to_timestamp(""endBreakTime""::varchar,'HH24:MI:SS'),to_timestamp(" & _
                                    "'" & timeTo & "', 'HH24:MI'))-greatest(to_timestamp(""beginBreakTime""::varchar,'HH24:MI:SS" & _
                                    "'),to_timestamp('" & timeFrom & "', 'HH24:MI'))) FROM ""t_linesBreaks"" where to_timestamp(""e" & _
                                    "ndBreakTime""::varchar,'HH24:MI:SS')>=to_timestamp('" & timeFrom & "', 'HH24:MI') and to_tim" & _
                                    "estamp(""beginBreakTime""::varchar,'HH24:MI:SS')<=to_timestamp('" & timeTo & "', 'HH24:MI')" & _
                                    " and ""lineID"" = '" & lineId & "';"
        odbcConnector.CommandType = CommandType.Text

        Dim previousConnectionState As ConnectionState = odbcConnector.Connection.State
        If ((odbcConnector.Connection.State And ConnectionState.Open) _
            <> ConnectionState.Open) Then
            odbcConnector.Connection.Open()
        End If

        Dim queryReturnValue As Object

        Try
            queryReturnValue = odbcConnector.ExecuteScalar
        Finally
            If (previousConnectionState = ConnectionState.Closed) Then
                odbcConnector.Connection.Close()
            End If
        End Try

        If ((queryReturnValue Is Nothing) _
            OrElse (queryReturnValue.GetType Is GetType(DBNull))) Then Return 0

        Dim sumTimeOfBreaks As Date
        If Not DateTime.TryParse(CType(queryReturnValue, String), sumTimeOfBreaks) Then Return 0

        Return sumTimeOfBreaks.TimeOfDay.TotalMinutes

    End Function

    Private Shared Function SumOfInterruptsInMinuts(lineId As String, timeFrom As String, timeTo As String, accidentDate As Date?) As UInt32
        Dim odbcConnector As New OdbcCommand()
        odbcConnector.Connection = New OdbcConnection(MySettings.Default.ru_sb_tames)
        odbcConnector.CommandText = "SELECT sum(least(to_timestamp(""endOfInterruptTimestamp""::varchar,'HH24:MI:SS'),to_timestamp(" & _
               "'" & timeTo & "', 'HH24:MI'))-greatest(to_timestamp(""interruptTimestamp""::varchar,'HH24:MI:SS" & _
               "'),to_timestamp('" & timeFrom & "', 'HH24:MI'))) FROM ""t_linesInterrupts"" where to_timestamp(""" & _
               "endOfInterruptTimestamp""::varchar,'HH24:MI:SS')>=to_timestamp('" & timeFrom & "', 'HH24:MI') and to_tim" & _
               "estamp(""interruptTimestamp""::varchar,'HH24:MI:SS')<=to_timestamp('" & timeTo & "', 'HH24:MI')" & _
               " and ""accidentDate"" =? and ""lineID"" = '" & lineId & "';"
        odbcConnector.CommandType = CommandType.Text
        odbcConnector.Parameters.Add(New OdbcParameter("accidentDate", OdbcType.Date))

        If (accidentDate.HasValue = True) Then
            odbcConnector.Parameters(0).Value = CType(accidentDate.Value, Date)
        Else
            odbcConnector.Parameters(0).Value = DBNull.Value
        End If

        Dim previousConnectionState As ConnectionState = odbcConnector.Connection.State
        If ((odbcConnector.Connection.State And ConnectionState.Open) _
                    <> ConnectionState.Open) Then
            odbcConnector.Connection.Open()
        End If

        Dim queryReturnValue As Object

        Try
            queryReturnValue = odbcConnector.ExecuteScalar
        Finally
            If (previousConnectionState = ConnectionState.Closed) Then
                odbcConnector.Connection.Close()
            End If
        End Try

        If ((queryReturnValue Is Nothing) _
                    OrElse (queryReturnValue.GetType Is GetType(DBNull))) Then Return 0

        Dim sumTimeOfInterrupts As Date
        If Not DateTime.TryParse(CType(queryReturnValue, String), sumTimeOfInterrupts) Then Return 0

        Return sumTimeOfInterrupts.TimeOfDay.TotalMinutes

    End Function

    Private Shared Sub tbProdLine_KeyPress(sender As Object, e As KeyPressEventArgs) Handles tbProdLine.KeyPress
        If Char.IsLower(e.KeyChar) Then
            e.KeyChar = Char.ToUpper(e.KeyChar)
        End If
    End Sub

    Private Shared Function PpFromCsv(fileName As String) As Dictionary(Of String, Integer)
        Dim pp As New Dictionary(Of String, Integer) ' ключ - деталь, значение  количество заггтовок в час

        Dim sr = New StreamReader(fileName, Encoding.GetEncoding("windows-1251"))
        Dim line = sr.ReadLine()
        While line <> Nothing
            Dim cells = line.Split(";"c)
            Dim productivity As Integer
            If cells.Length >= 2 And cells(0).Length > 0 And Integer.TryParse(cells(1), productivity) Then
                pp(cells(0)) = productivity
            End If
            line = sr.ReadLine()
        End While
        sr.Close()

        Return pp
    End Function

End Class
