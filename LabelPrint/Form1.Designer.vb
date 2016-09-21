<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.dgvProd = New System.Windows.Forms.DataGridView()
        Me.ListBoxLog = New System.Windows.Forms.ListBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabelLineName = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelCurentInfo = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.TabControlIndex = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.PanelProductivity = New System.Windows.Forms.Panel()
        Me.DataGridViewProductivity = New System.Windows.Forms.DataGridView()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.PanelScanMaster = New System.Windows.Forms.Panel()
        Me.LabelScanMaster = New System.Windows.Forms.Label()
        Me.ButtonCancelMaster = New System.Windows.Forms.Button()
        Me.DataGridViewOrders = New System.Windows.Forms.DataGridView()
        Me.ColumnOrderNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnOrderQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnpartNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnPartName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnCustPN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnCustName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnPackFactor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnBoxNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnLine = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnDGSymbol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnBCInfo1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnBCInfo2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnHomologationPN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnPartType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ButtonChangeCounter = New System.Windows.Forms.Button()
        Me.ButtonPrintBoxLabel = New System.Windows.Forms.Button()
        Me.LabelLabelCount = New System.Windows.Forms.Label()
        Me.ButtonCloseOrder = New System.Windows.Forms.Button()
        Me.ButtonOpenOrder = New System.Windows.Forms.Button()
        Me.PanelStartOrder = New System.Windows.Forms.Panel()
        Me.LabelStartOrder = New System.Windows.Forms.Label()
        Me.ButtonCancelScanOrder = New System.Windows.Forms.Button()
        Me.PanelWarning = New System.Windows.Forms.Panel()
        Me.LabelWarning = New System.Windows.Forms.Label()
        Me.ButtonWarningCancel = New System.Windows.Forms.Button()
        Me.PanelError = New System.Windows.Forms.Panel()
        Me.LabelError = New System.Windows.Forms.Label()
        Me.ButtonCloseError = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPageOrder = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.T_orderListDataGridView = New System.Windows.Forms.DataGridView()
        Me.orderNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.orderQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.partNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.partDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.custpartNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.custName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.oStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BoxNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.T_orderListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Ru_sb_tames1 = New LabelPrint.ru_sb_tames()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btno_PrintBL = New System.Windows.Forms.Button()
        Me.btno_delete = New System.Windows.Forms.Button()
        Me.btno_query = New System.Windows.Forms.Button()
        Me.cbo_stopped = New System.Windows.Forms.CheckBox()
        Me.cbo_started = New System.Windows.Forms.CheckBox()
        Me.cbo_created = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cbo_partNo = New System.Windows.Forms.ComboBox()
        Me.btno_addOrder = New System.Windows.Forms.Button()
        Me.tbo_partDesc = New System.Windows.Forms.TextBox()
        Me.tbo_pLine = New System.Windows.Forms.TextBox()
        Me.tbo_custName = New System.Windows.Forms.TextBox()
        Me.tbo_custPn = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbo_Qty = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbo_Order = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPagePN = New System.Windows.Forms.TabPage()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.T_partListDataGridView = New System.Windows.Forms.DataGridView()
        Me.p_partNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.p_partDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.p_custPartNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.p_custName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.p_packfactor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.p_DGSymbol = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.p_BCinfo1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.p_BCinfo2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.p_c1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.p_c2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.p_c3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.suppliercode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.T_partListBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.btnp_Delete = New System.Windows.Forms.Button()
        Me.btnp_query = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.tbp_suppliercode = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.tbp_labelType = New System.Windows.Forms.TextBox()
        Me.btn_AddPart = New System.Windows.Forms.Button()
        Me.cbp_HPN = New System.Windows.Forms.ComboBox()
        Me.cbp_partType = New System.Windows.Forms.ComboBox()
        Me.cbp_DGSymbol = New System.Windows.Forms.ComboBox()
        Me.cbp_custName = New System.Windows.Forms.ComboBox()
        Me.tbp_partCounter = New System.Windows.Forms.TextBox()
        Me.tbp_idComp = New System.Windows.Forms.TextBox()
        Me.tbp_packfactor = New System.Windows.Forms.TextBox()
        Me.tbp_custPartNo = New System.Windows.Forms.TextBox()
        Me.tbp_partDesc = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tbp_partNo = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TabPageHLabel = New System.Windows.Forms.TabPage()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.T_HLabelDataGridView = New System.Windows.Forms.DataGridView()
        Me.h_labelPN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.h_labelLayout = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.h_IdentificationNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.h_ModelNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.h_ECEApprovalType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.h_ECEApprovalNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.h_EECApprovalType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.h_EECApprovalNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.h_AIRBAG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.h_PretensionerType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.h_BarCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.T_HLabelBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.btnh_delete = New System.Windows.Forms.Button()
        Me.btnh_query = New System.Windows.Forms.Button()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.tbh_position = New System.Windows.Forms.TextBox()
        Me.btnh_addHPN = New System.Windows.Forms.Button()
        Me.tbh_barcode = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.cbh_airbag = New System.Windows.Forms.ComboBox()
        Me.tbh_eecapnumber = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.tbh_eecaptype = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.tbh_eceapnumber = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.tbh_eceaptype = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.tbh_modelNo = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.tbh_custPn = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.tbh_layout = New System.Windows.Forms.TextBox()
        Me.tbh_partNo = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TabPageTraceability = New System.Windows.Forms.TabPage()
        Me.T_labelsDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.T_labelsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.btn_FindBarcode = New System.Windows.Forms.Button()
        Me.tb_lblBarcode = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.TabPageProductivity = New System.Windows.Forms.TabPage()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.btnProdFind = New System.Windows.Forms.Button()
        Me.GroupBox15 = New System.Windows.Forms.GroupBox()
        Me.rbGroupByOrder = New System.Windows.Forms.RadioButton()
        Me.rbGroupByDate = New System.Windows.Forms.RadioButton()
        Me.GroupBox16 = New System.Windows.Forms.GroupBox()
        Me.dtpEndOfTimeFilter = New System.Windows.Forms.DateTimePicker()
        Me.tbLeitzahl = New System.Windows.Forms.TextBox()
        Me.GroupBox14 = New System.Windows.Forms.GroupBox()
        Me.dtpBeginOfTimeFilter = New System.Windows.Forms.DateTimePicker()
        Me.tbProdLine = New System.Windows.Forms.TextBox()
        Me.GroupBox17 = New System.Windows.Forms.GroupBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.dtpProdEnd = New System.Windows.Forms.DateTimePicker()
        Me.dtpProdStart = New System.Windows.Forms.DateTimePicker()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.TabPageBreaks = New System.Windows.Forms.TabPage()
        Me.gbNewBreak = New System.Windows.Forms.GroupBox()
        Me.dtpBeginBreak = New System.Windows.Forms.DateTimePicker()
        Me.dtpEndBreak = New System.Windows.Forms.DateTimePicker()
        Me.btnAddBreak = New System.Windows.Forms.Button()
        Me.tbComment = New System.Windows.Forms.TextBox()
        Me.labelComment = New System.Windows.Forms.Label()
        Me.labelBreakTo = New System.Windows.Forms.Label()
        Me.tbLineID = New System.Windows.Forms.TextBox()
        Me.labelBreakFrom = New System.Windows.Forms.Label()
        Me.labelLineID = New System.Windows.Forms.Label()
        Me.dgvBreaks = New System.Windows.Forms.DataGridView()
        Me.TabPageInterrupts = New System.Windows.Forms.TabPage()
        Me.dgvInterrupts = New System.Windows.Forms.DataGridView()
        Me.TabPageSettings = New System.Windows.Forms.TabPage()
        Me.T_SettingsDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumnvarName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumnvarValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.T_SettingsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.tbs_varValue = New System.Windows.Forms.TextBox()
        Me.tbs_varName = New System.Windows.Forms.TextBox()
        Me.ButtonSettingsDelete = New System.Windows.Forms.Button()
        Me.ButtonSettingsAdd = New System.Windows.Forms.Button()
        Me.ButtonSettingsUpdate = New System.Windows.Forms.Button()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.TimerStartOrder = New System.Windows.Forms.Timer(Me.components)
        Me.TimerNoWorkWarning = New System.Windows.Forms.Timer(Me.components)
        Me.TimerStopOrder = New System.Windows.Forms.Timer(Me.components)
        Me.TimerCountBlink = New System.Windows.Forms.Timer(Me.components)
        Me.TimerHideCurentStatus = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BackgroundWorkerQueryOrders = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorkerFillOrderPNInfo = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorkerLoadPartTabel = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorkerLoadHomoLabel = New System.ComponentModel.BackgroundWorker()
        Me.t_HLabelTableAdapter1 = New LabelPrint.ru_sb_tamesTableAdapters.t_HLabelTableAdapter()
        Me.T_partListTableAdapter1 = New LabelPrint.ru_sb_tamesTableAdapters.t_partListTableAdapter()
        Me.T_orderListTableAdapter1 = New LabelPrint.ru_sb_tamesTableAdapters.t_orderListTableAdapter()
        Me.T_SettingsTableAdapter1 = New LabelPrint.ru_sb_tamesTableAdapters.t_SettingsTableAdapter()
        Me.T_labelsTableAdapter1 = New LabelPrint.ru_sb_tamesTableAdapters.t_labelsTableAdapter()
        Me.TableAdapterManager = New LabelPrint.ru_sb_tamesTableAdapters.TableAdapterManager()
        Me.BackgroundWorkerLoadCustLabel = New System.ComponentModel.BackgroundWorker()
        Me.T_productivityTableAdapter1 = New LabelPrint.ru_sb_tamesTableAdapters.t_productivityTableAdapter()
        Me.BackgroundWorkerProductivity1 = New System.ComponentModel.BackgroundWorker()
        Me.T_HLabelTableAdapter2 = New LabelPrint.ru_sb_tamesTableAdapters.t_HLabelTableAdapter()
        Me.BreaksIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BreaksLineIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BeginBreakTimeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EndBreakTimeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CommentDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InterruptsIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AccidentDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GangDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InterruptsLineIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EquipmentNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InterruptTimestampDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BeginRepairTimestampDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EndOfInterruptTimestampDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InterruptCodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CauseOfInterruptDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CarriedOutActionsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WhoIsLastDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.T_linesBreaksBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Sb_tamesBreaksDataSet = New LabelPrint.sb_tamesBreaksDataSet()
        Me.T_linesInterruptsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Sb_tamesInterruptsDataSet = New LabelPrint.sb_tamesInterruptsDataSet()
        Me.T_linesBreaksTableAdapter = New LabelPrint.sb_tamesBreaksDataSetTableAdapters.t_linesBreaksTableAdapter()
        Me.T_linesInterruptsTableAdapter = New LabelPrint.sb_tamesInterruptsDataSetTableAdapters.t_linesInterruptsTableAdapter()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.dgvProd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.TabControlIndex.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.PanelProductivity.SuspendLayout()
        CType(Me.DataGridViewProductivity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelScanMaster.SuspendLayout()
        CType(Me.DataGridViewOrders, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.PanelStartOrder.SuspendLayout()
        Me.PanelWarning.SuspendLayout()
        Me.PanelError.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPageOrder.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.T_orderListDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_orderListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ru_sb_tames1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPagePN.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.T_partListDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_partListBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.TabPageHLabel.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        CType(Me.T_HLabelDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_HLabelBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox10.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.TabPageTraceability.SuspendLayout()
        CType(Me.T_labelsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_labelsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox12.SuspendLayout()
        Me.TabPageProductivity.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        Me.GroupBox15.SuspendLayout()
        Me.GroupBox16.SuspendLayout()
        Me.GroupBox14.SuspendLayout()
        Me.GroupBox17.SuspendLayout()
        Me.TabPageBreaks.SuspendLayout()
        Me.gbNewBreak.SuspendLayout()
        CType(Me.dgvBreaks, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageInterrupts.SuspendLayout()
        CType(Me.dgvInterrupts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageSettings.SuspendLayout()
        CType(Me.T_SettingsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_SettingsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox11.SuspendLayout()
        CType(Me.T_linesBreaksBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Sb_tamesBreaksDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_linesInterruptsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Sb_tamesInterruptsDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        resources.ApplyResources(Me.SplitContainer1, "SplitContainer1")
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgvProd)
        '
        'dgvProd
        '
        Me.dgvProd.AllowUserToAddRows = False
        Me.dgvProd.AllowUserToDeleteRows = False
        Me.dgvProd.AllowUserToResizeRows = False
        Me.dgvProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        resources.ApplyResources(Me.dgvProd, "dgvProd")
        Me.dgvProd.Name = "dgvProd"
        Me.dgvProd.ReadOnly = True
        '
        'ListBoxLog
        '
        resources.ApplyResources(Me.ListBoxLog, "ListBoxLog")
        Me.ListBoxLog.FormattingEnabled = True
        Me.ListBoxLog.Name = "ListBoxLog"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabelLineName, Me.ToolStripStatusLabelCurentInfo, Me.ToolStripProgressBar1})
        resources.ApplyResources(Me.StatusStrip1, "StatusStrip1")
        Me.StatusStrip1.Name = "StatusStrip1"
        '
        'ToolStripStatusLabelLineName
        '
        Me.ToolStripStatusLabelLineName.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        resources.ApplyResources(Me.ToolStripStatusLabelLineName, "ToolStripStatusLabelLineName")
        Me.ToolStripStatusLabelLineName.Name = "ToolStripStatusLabelLineName"
        '
        'ToolStripStatusLabelCurentInfo
        '
        Me.ToolStripStatusLabelCurentInfo.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        resources.ApplyResources(Me.ToolStripStatusLabelCurentInfo, "ToolStripStatusLabelCurentInfo")
        Me.ToolStripStatusLabelCurentInfo.Name = "ToolStripStatusLabelCurentInfo"
        Me.ToolStripStatusLabelCurentInfo.Spring = True
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        resources.ApplyResources(Me.ToolStripProgressBar1, "ToolStripProgressBar1")
        Me.ToolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        '
        'TabControlIndex
        '
        resources.ApplyResources(Me.TabControlIndex, "TabControlIndex")
        Me.TabControlIndex.Controls.Add(Me.TabPage1)
        Me.TabControlIndex.Controls.Add(Me.TabPage2)
        Me.TabControlIndex.Multiline = True
        Me.TabControlIndex.Name = "TabControlIndex"
        Me.TabControlIndex.SelectedIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Transparent
        Me.TabPage1.Controls.Add(Me.PanelProductivity)
        Me.TabPage1.Controls.Add(Me.PanelScanMaster)
        Me.TabPage1.Controls.Add(Me.DataGridViewOrders)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.PanelStartOrder)
        Me.TabPage1.Controls.Add(Me.PanelWarning)
        Me.TabPage1.Controls.Add(Me.PanelError)
        Me.TabPage1.Cursor = System.Windows.Forms.Cursors.Default
        resources.ApplyResources(Me.TabPage1, "TabPage1")
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'PanelProductivity
        '
        Me.PanelProductivity.Controls.Add(Me.DataGridViewProductivity)
        Me.PanelProductivity.Controls.Add(Me.Label30)
        resources.ApplyResources(Me.PanelProductivity, "PanelProductivity")
        Me.PanelProductivity.Name = "PanelProductivity"
        '
        'DataGridViewProductivity
        '
        Me.DataGridViewProductivity.AllowUserToAddRows = False
        Me.DataGridViewProductivity.AllowUserToDeleteRows = False
        Me.DataGridViewProductivity.AllowUserToResizeRows = False
        Me.DataGridViewProductivity.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewProductivity.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewProductivity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewProductivity.DefaultCellStyle = DataGridViewCellStyle2
        resources.ApplyResources(Me.DataGridViewProductivity, "DataGridViewProductivity")
        Me.DataGridViewProductivity.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridViewProductivity.Name = "DataGridViewProductivity"
        Me.DataGridViewProductivity.ReadOnly = True
        Me.DataGridViewProductivity.RowHeadersVisible = False
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.LightGray
        resources.ApplyResources(Me.Label30, "Label30")
        Me.Label30.Name = "Label30"
        '
        'PanelScanMaster
        '
        resources.ApplyResources(Me.PanelScanMaster, "PanelScanMaster")
        Me.PanelScanMaster.BackColor = System.Drawing.Color.Transparent
        Me.PanelScanMaster.Controls.Add(Me.LabelScanMaster)
        Me.PanelScanMaster.Controls.Add(Me.ButtonCancelMaster)
        Me.PanelScanMaster.Name = "PanelScanMaster"
        '
        'LabelScanMaster
        '
        resources.ApplyResources(Me.LabelScanMaster, "LabelScanMaster")
        Me.LabelScanMaster.Name = "LabelScanMaster"
        '
        'ButtonCancelMaster
        '
        Me.ButtonCancelMaster.BackColor = System.Drawing.Color.Gainsboro
        resources.ApplyResources(Me.ButtonCancelMaster, "ButtonCancelMaster")
        Me.ButtonCancelMaster.Name = "ButtonCancelMaster"
        Me.ButtonCancelMaster.UseVisualStyleBackColor = False
        '
        'DataGridViewOrders
        '
        Me.DataGridViewOrders.AllowUserToAddRows = False
        Me.DataGridViewOrders.AllowUserToDeleteRows = False
        Me.DataGridViewOrders.AllowUserToResizeRows = False
        Me.DataGridViewOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewOrders.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewOrders.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColumnOrderNo, Me.ColumnOrderQty, Me.ColumnpartNo, Me.ColumnPartName, Me.ColumnCustPN, Me.ColumnCustName, Me.ColumnPackFactor, Me.ColumnBoxNo, Me.ColumnLine, Me.ColumnDGSymbol, Me.ColumnBCInfo1, Me.ColumnBCInfo2, Me.ColumnHomologationPN, Me.ColumnPartType})
        resources.ApplyResources(Me.DataGridViewOrders, "DataGridViewOrders")
        Me.DataGridViewOrders.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridViewOrders.Name = "DataGridViewOrders"
        Me.DataGridViewOrders.ReadOnly = True
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewOrders.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewOrders.RowHeadersVisible = False
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        Me.DataGridViewOrders.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewOrders.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.DataGridViewOrders.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DataGridViewOrders.RowTemplate.Height = 50
        Me.DataGridViewOrders.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'ColumnOrderNo
        '
        DataGridViewCellStyle4.NullValue = Nothing
        Me.ColumnOrderNo.DefaultCellStyle = DataGridViewCellStyle4
        resources.ApplyResources(Me.ColumnOrderNo, "ColumnOrderNo")
        Me.ColumnOrderNo.Name = "ColumnOrderNo"
        Me.ColumnOrderNo.ReadOnly = True
        '
        'ColumnOrderQty
        '
        Me.ColumnOrderQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        resources.ApplyResources(Me.ColumnOrderQty, "ColumnOrderQty")
        Me.ColumnOrderQty.Name = "ColumnOrderQty"
        Me.ColumnOrderQty.ReadOnly = True
        '
        'ColumnpartNo
        '
        Me.ColumnpartNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        resources.ApplyResources(Me.ColumnpartNo, "ColumnpartNo")
        Me.ColumnpartNo.Name = "ColumnpartNo"
        Me.ColumnpartNo.ReadOnly = True
        '
        'ColumnPartName
        '
        Me.ColumnPartName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        resources.ApplyResources(Me.ColumnPartName, "ColumnPartName")
        Me.ColumnPartName.Name = "ColumnPartName"
        Me.ColumnPartName.ReadOnly = True
        '
        'ColumnCustPN
        '
        resources.ApplyResources(Me.ColumnCustPN, "ColumnCustPN")
        Me.ColumnCustPN.Name = "ColumnCustPN"
        Me.ColumnCustPN.ReadOnly = True
        '
        'ColumnCustName
        '
        resources.ApplyResources(Me.ColumnCustName, "ColumnCustName")
        Me.ColumnCustName.Name = "ColumnCustName"
        Me.ColumnCustName.ReadOnly = True
        '
        'ColumnPackFactor
        '
        resources.ApplyResources(Me.ColumnPackFactor, "ColumnPackFactor")
        Me.ColumnPackFactor.Name = "ColumnPackFactor"
        Me.ColumnPackFactor.ReadOnly = True
        '
        'ColumnBoxNo
        '
        Me.ColumnBoxNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        resources.ApplyResources(Me.ColumnBoxNo, "ColumnBoxNo")
        Me.ColumnBoxNo.Name = "ColumnBoxNo"
        Me.ColumnBoxNo.ReadOnly = True
        '
        'ColumnLine
        '
        resources.ApplyResources(Me.ColumnLine, "ColumnLine")
        Me.ColumnLine.Name = "ColumnLine"
        Me.ColumnLine.ReadOnly = True
        '
        'ColumnDGSymbol
        '
        resources.ApplyResources(Me.ColumnDGSymbol, "ColumnDGSymbol")
        Me.ColumnDGSymbol.Name = "ColumnDGSymbol"
        Me.ColumnDGSymbol.ReadOnly = True
        '
        'ColumnBCInfo1
        '
        resources.ApplyResources(Me.ColumnBCInfo1, "ColumnBCInfo1")
        Me.ColumnBCInfo1.Name = "ColumnBCInfo1"
        Me.ColumnBCInfo1.ReadOnly = True
        '
        'ColumnBCInfo2
        '
        resources.ApplyResources(Me.ColumnBCInfo2, "ColumnBCInfo2")
        Me.ColumnBCInfo2.Name = "ColumnBCInfo2"
        Me.ColumnBCInfo2.ReadOnly = True
        '
        'ColumnHomologationPN
        '
        resources.ApplyResources(Me.ColumnHomologationPN, "ColumnHomologationPN")
        Me.ColumnHomologationPN.Name = "ColumnHomologationPN"
        Me.ColumnHomologationPN.ReadOnly = True
        '
        'ColumnPartType
        '
        resources.ApplyResources(Me.ColumnPartType, "ColumnPartType")
        Me.ColumnPartType.Name = "ColumnPartType"
        Me.ColumnPartType.ReadOnly = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ButtonChangeCounter)
        Me.GroupBox1.Controls.Add(Me.ButtonPrintBoxLabel)
        Me.GroupBox1.Controls.Add(Me.LabelLabelCount)
        Me.GroupBox1.Controls.Add(Me.ButtonCloseOrder)
        Me.GroupBox1.Controls.Add(Me.ButtonOpenOrder)
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'ButtonChangeCounter
        '
        resources.ApplyResources(Me.ButtonChangeCounter, "ButtonChangeCounter")
        Me.ButtonChangeCounter.Name = "ButtonChangeCounter"
        Me.ButtonChangeCounter.UseVisualStyleBackColor = True
        '
        'ButtonPrintBoxLabel
        '
        Me.ButtonPrintBoxLabel.BackColor = System.Drawing.Color.LightGray
        resources.ApplyResources(Me.ButtonPrintBoxLabel, "ButtonPrintBoxLabel")
        Me.ButtonPrintBoxLabel.Name = "ButtonPrintBoxLabel"
        Me.ButtonPrintBoxLabel.UseVisualStyleBackColor = False
        '
        'LabelLabelCount
        '
        resources.ApplyResources(Me.LabelLabelCount, "LabelLabelCount")
        Me.LabelLabelCount.Name = "LabelLabelCount"
        '
        'ButtonCloseOrder
        '
        resources.ApplyResources(Me.ButtonCloseOrder, "ButtonCloseOrder")
        Me.ButtonCloseOrder.Name = "ButtonCloseOrder"
        Me.ButtonCloseOrder.UseVisualStyleBackColor = True
        '
        'ButtonOpenOrder
        '
        resources.ApplyResources(Me.ButtonOpenOrder, "ButtonOpenOrder")
        Me.ButtonOpenOrder.Name = "ButtonOpenOrder"
        Me.ButtonOpenOrder.UseVisualStyleBackColor = True
        '
        'PanelStartOrder
        '
        resources.ApplyResources(Me.PanelStartOrder, "PanelStartOrder")
        Me.PanelStartOrder.BackColor = System.Drawing.Color.Transparent
        Me.PanelStartOrder.Controls.Add(Me.LabelStartOrder)
        Me.PanelStartOrder.Controls.Add(Me.ButtonCancelScanOrder)
        Me.PanelStartOrder.Name = "PanelStartOrder"
        '
        'LabelStartOrder
        '
        resources.ApplyResources(Me.LabelStartOrder, "LabelStartOrder")
        Me.LabelStartOrder.Name = "LabelStartOrder"
        '
        'ButtonCancelScanOrder
        '
        Me.ButtonCancelScanOrder.BackColor = System.Drawing.Color.Gainsboro
        resources.ApplyResources(Me.ButtonCancelScanOrder, "ButtonCancelScanOrder")
        Me.ButtonCancelScanOrder.Name = "ButtonCancelScanOrder"
        Me.ButtonCancelScanOrder.UseVisualStyleBackColor = False
        '
        'PanelWarning
        '
        Me.PanelWarning.BackColor = System.Drawing.Color.Yellow
        Me.PanelWarning.Controls.Add(Me.LabelWarning)
        Me.PanelWarning.Controls.Add(Me.ButtonWarningCancel)
        resources.ApplyResources(Me.PanelWarning, "PanelWarning")
        Me.PanelWarning.Name = "PanelWarning"
        '
        'LabelWarning
        '
        Me.LabelWarning.BackColor = System.Drawing.Color.Yellow
        resources.ApplyResources(Me.LabelWarning, "LabelWarning")
        Me.LabelWarning.Name = "LabelWarning"
        '
        'ButtonWarningCancel
        '
        Me.ButtonWarningCancel.BackColor = System.Drawing.Color.Khaki
        resources.ApplyResources(Me.ButtonWarningCancel, "ButtonWarningCancel")
        Me.ButtonWarningCancel.Name = "ButtonWarningCancel"
        Me.ButtonWarningCancel.UseVisualStyleBackColor = False
        '
        'PanelError
        '
        Me.PanelError.BackColor = System.Drawing.Color.Red
        Me.PanelError.Controls.Add(Me.LabelError)
        Me.PanelError.Controls.Add(Me.ButtonCloseError)
        resources.ApplyResources(Me.PanelError, "PanelError")
        Me.PanelError.Name = "PanelError"
        '
        'LabelError
        '
        resources.ApplyResources(Me.LabelError, "LabelError")
        Me.LabelError.Name = "LabelError"
        '
        'ButtonCloseError
        '
        Me.ButtonCloseError.BackColor = System.Drawing.Color.MistyRose
        resources.ApplyResources(Me.ButtonCloseError, "ButtonCloseError")
        Me.ButtonCloseError.Name = "ButtonCloseError"
        Me.ButtonCloseError.UseVisualStyleBackColor = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.TabControl1)
        resources.ApplyResources(Me.TabPage2, "TabPage2")
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPageOrder)
        Me.TabControl1.Controls.Add(Me.TabPagePN)
        Me.TabControl1.Controls.Add(Me.TabPageHLabel)
        Me.TabControl1.Controls.Add(Me.TabPageTraceability)
        Me.TabControl1.Controls.Add(Me.TabPageProductivity)
        Me.TabControl1.Controls.Add(Me.TabPageBreaks)
        Me.TabControl1.Controls.Add(Me.TabPageInterrupts)
        Me.TabControl1.Controls.Add(Me.TabPageSettings)
        resources.ApplyResources(Me.TabControl1, "TabControl1")
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        '
        'TabPageOrder
        '
        Me.TabPageOrder.Controls.Add(Me.GroupBox3)
        Me.TabPageOrder.Controls.Add(Me.GroupBox2)
        resources.ApplyResources(Me.TabPageOrder, "TabPageOrder")
        Me.TabPageOrder.Name = "TabPageOrder"
        Me.TabPageOrder.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.T_orderListDataGridView)
        Me.GroupBox3.Controls.Add(Me.GroupBox4)
        resources.ApplyResources(Me.GroupBox3, "GroupBox3")
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.TabStop = False
        '
        'T_orderListDataGridView
        '
        Me.T_orderListDataGridView.AllowUserToAddRows = False
        Me.T_orderListDataGridView.AllowUserToDeleteRows = False
        Me.T_orderListDataGridView.AllowUserToResizeRows = False
        Me.T_orderListDataGridView.AutoGenerateColumns = False
        Me.T_orderListDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.T_orderListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T_orderListDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.orderNo, Me.orderQty, Me.partNo, Me.partDesc, Me.custpartNo, Me.custName, Me.oStatus, Me.BoxNo, Me.c1, Me.c2, Me.c3})
        Me.T_orderListDataGridView.DataSource = Me.T_orderListBindingSource
        resources.ApplyResources(Me.T_orderListDataGridView, "T_orderListDataGridView")
        Me.T_orderListDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.T_orderListDataGridView.Name = "T_orderListDataGridView"
        Me.T_orderListDataGridView.RowHeadersVisible = False
        '
        'orderNo
        '
        Me.orderNo.DataPropertyName = "orderNo"
        resources.ApplyResources(Me.orderNo, "orderNo")
        Me.orderNo.Name = "orderNo"
        '
        'orderQty
        '
        Me.orderQty.DataPropertyName = "orderQty"
        resources.ApplyResources(Me.orderQty, "orderQty")
        Me.orderQty.Name = "orderQty"
        '
        'partNo
        '
        Me.partNo.DataPropertyName = "partNo"
        resources.ApplyResources(Me.partNo, "partNo")
        Me.partNo.Name = "partNo"
        '
        'partDesc
        '
        Me.partDesc.DataPropertyName = "partDesc"
        resources.ApplyResources(Me.partDesc, "partDesc")
        Me.partDesc.Name = "partDesc"
        '
        'custpartNo
        '
        Me.custpartNo.DataPropertyName = "custpartNo"
        resources.ApplyResources(Me.custpartNo, "custpartNo")
        Me.custpartNo.Name = "custpartNo"
        '
        'custName
        '
        Me.custName.DataPropertyName = "custName"
        resources.ApplyResources(Me.custName, "custName")
        Me.custName.Name = "custName"
        '
        'oStatus
        '
        Me.oStatus.DataPropertyName = "oStatus"
        resources.ApplyResources(Me.oStatus, "oStatus")
        Me.oStatus.Name = "oStatus"
        '
        'BoxNo
        '
        Me.BoxNo.DataPropertyName = "BoxNo"
        resources.ApplyResources(Me.BoxNo, "BoxNo")
        Me.BoxNo.Name = "BoxNo"
        '
        'c1
        '
        Me.c1.DataPropertyName = "c1"
        resources.ApplyResources(Me.c1, "c1")
        Me.c1.Name = "c1"
        '
        'c2
        '
        Me.c2.DataPropertyName = "c2"
        resources.ApplyResources(Me.c2, "c2")
        Me.c2.Name = "c2"
        '
        'c3
        '
        Me.c3.DataPropertyName = "c3"
        resources.ApplyResources(Me.c3, "c3")
        Me.c3.Name = "c3"
        '
        'T_orderListBindingSource
        '
        Me.T_orderListBindingSource.DataMember = "t_orderList"
        Me.T_orderListBindingSource.DataSource = Me.Ru_sb_tames1
        '
        'Ru_sb_tames1
        '
        Me.Ru_sb_tames1.DataSetName = "ru_sb_tames"
        Me.Ru_sb_tames1.EnforceConstraints = False
        Me.Ru_sb_tames1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btno_PrintBL)
        Me.GroupBox4.Controls.Add(Me.btno_delete)
        Me.GroupBox4.Controls.Add(Me.btno_query)
        Me.GroupBox4.Controls.Add(Me.cbo_stopped)
        Me.GroupBox4.Controls.Add(Me.cbo_started)
        Me.GroupBox4.Controls.Add(Me.cbo_created)
        resources.ApplyResources(Me.GroupBox4, "GroupBox4")
        Me.GroupBox4.ForeColor = System.Drawing.Color.Black
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.TabStop = False
        '
        'btno_PrintBL
        '
        resources.ApplyResources(Me.btno_PrintBL, "btno_PrintBL")
        Me.btno_PrintBL.Name = "btno_PrintBL"
        Me.btno_PrintBL.UseVisualStyleBackColor = True
        '
        'btno_delete
        '
        resources.ApplyResources(Me.btno_delete, "btno_delete")
        Me.btno_delete.Name = "btno_delete"
        Me.ToolTip1.SetToolTip(Me.btno_delete, resources.GetString("btno_delete.ToolTip"))
        Me.btno_delete.UseVisualStyleBackColor = True
        '
        'btno_query
        '
        resources.ApplyResources(Me.btno_query, "btno_query")
        Me.btno_query.Name = "btno_query"
        Me.btno_query.UseVisualStyleBackColor = True
        '
        'cbo_stopped
        '
        resources.ApplyResources(Me.cbo_stopped, "cbo_stopped")
        Me.cbo_stopped.Name = "cbo_stopped"
        Me.cbo_stopped.UseVisualStyleBackColor = True
        '
        'cbo_started
        '
        resources.ApplyResources(Me.cbo_started, "cbo_started")
        Me.cbo_started.Checked = True
        Me.cbo_started.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbo_started.Name = "cbo_started"
        Me.cbo_started.UseVisualStyleBackColor = True
        '
        'cbo_created
        '
        resources.ApplyResources(Me.cbo_created, "cbo_created")
        Me.cbo_created.Name = "cbo_created"
        Me.cbo_created.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbo_partNo)
        Me.GroupBox2.Controls.Add(Me.btno_addOrder)
        Me.GroupBox2.Controls.Add(Me.tbo_partDesc)
        Me.GroupBox2.Controls.Add(Me.tbo_pLine)
        Me.GroupBox2.Controls.Add(Me.tbo_custName)
        Me.GroupBox2.Controls.Add(Me.tbo_custPn)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.tbo_Qty)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.tbo_Order)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.TabStop = False
        '
        'cbo_partNo
        '
        resources.ApplyResources(Me.cbo_partNo, "cbo_partNo")
        Me.cbo_partNo.FormattingEnabled = True
        Me.cbo_partNo.Name = "cbo_partNo"
        Me.cbo_partNo.Sorted = True
        '
        'btno_addOrder
        '
        resources.ApplyResources(Me.btno_addOrder, "btno_addOrder")
        Me.btno_addOrder.Name = "btno_addOrder"
        Me.btno_addOrder.UseVisualStyleBackColor = True
        '
        'tbo_partDesc
        '
        Me.tbo_partDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.tbo_partDesc, "tbo_partDesc")
        Me.tbo_partDesc.Name = "tbo_partDesc"
        '
        'tbo_pLine
        '
        Me.tbo_pLine.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.tbo_pLine, "tbo_pLine")
        Me.tbo_pLine.Name = "tbo_pLine"
        '
        'tbo_custName
        '
        Me.tbo_custName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.tbo_custName, "tbo_custName")
        Me.tbo_custName.Name = "tbo_custName"
        '
        'tbo_custPn
        '
        Me.tbo_custPn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.tbo_custPn, "tbo_custPn")
        Me.tbo_custPn.Name = "tbo_custPn"
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'tbo_Qty
        '
        resources.ApplyResources(Me.tbo_Qty, "tbo_Qty")
        Me.tbo_Qty.Name = "tbo_Qty"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'tbo_Order
        '
        resources.ApplyResources(Me.tbo_Order, "tbo_Order")
        Me.tbo_Order.Name = "tbo_Order"
        Me.ToolTip1.SetToolTip(Me.tbo_Order, resources.GetString("tbo_Order.ToolTip"))
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'TabPagePN
        '
        Me.TabPagePN.Controls.Add(Me.GroupBox6)
        Me.TabPagePN.Controls.Add(Me.GroupBox5)
        resources.ApplyResources(Me.TabPagePN, "TabPagePN")
        Me.TabPagePN.Name = "TabPagePN"
        Me.TabPagePN.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.T_partListDataGridView)
        Me.GroupBox6.Controls.Add(Me.GroupBox7)
        resources.ApplyResources(Me.GroupBox6, "GroupBox6")
        Me.GroupBox6.ForeColor = System.Drawing.Color.Black
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.TabStop = False
        '
        'T_partListDataGridView
        '
        Me.T_partListDataGridView.AllowUserToAddRows = False
        Me.T_partListDataGridView.AllowUserToDeleteRows = False
        Me.T_partListDataGridView.AllowUserToResizeRows = False
        Me.T_partListDataGridView.AutoGenerateColumns = False
        Me.T_partListDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.T_partListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T_partListDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.p_partNo, Me.p_partDesc, Me.p_custPartNo, Me.p_custName, Me.p_packfactor, Me.p_DGSymbol, Me.p_BCinfo1, Me.p_BCinfo2, Me.p_c1, Me.p_c2, Me.p_c3, Me.suppliercode})
        Me.T_partListDataGridView.DataSource = Me.T_partListBindingSource
        resources.ApplyResources(Me.T_partListDataGridView, "T_partListDataGridView")
        Me.T_partListDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.T_partListDataGridView.Name = "T_partListDataGridView"
        Me.T_partListDataGridView.RowHeadersVisible = False
        '
        'p_partNo
        '
        Me.p_partNo.DataPropertyName = "partNo"
        resources.ApplyResources(Me.p_partNo, "p_partNo")
        Me.p_partNo.Name = "p_partNo"
        '
        'p_partDesc
        '
        Me.p_partDesc.DataPropertyName = "partDesc"
        resources.ApplyResources(Me.p_partDesc, "p_partDesc")
        Me.p_partDesc.Name = "p_partDesc"
        '
        'p_custPartNo
        '
        Me.p_custPartNo.DataPropertyName = "custPartNo"
        resources.ApplyResources(Me.p_custPartNo, "p_custPartNo")
        Me.p_custPartNo.Name = "p_custPartNo"
        '
        'p_custName
        '
        Me.p_custName.DataPropertyName = "custName"
        resources.ApplyResources(Me.p_custName, "p_custName")
        Me.p_custName.Name = "p_custName"
        '
        'p_packfactor
        '
        Me.p_packfactor.DataPropertyName = "packfactor"
        resources.ApplyResources(Me.p_packfactor, "p_packfactor")
        Me.p_packfactor.Name = "p_packfactor"
        '
        'p_DGSymbol
        '
        Me.p_DGSymbol.DataPropertyName = "DGSymbol"
        resources.ApplyResources(Me.p_DGSymbol, "p_DGSymbol")
        Me.p_DGSymbol.Name = "p_DGSymbol"
        '
        'p_BCinfo1
        '
        Me.p_BCinfo1.DataPropertyName = "BCinfo1"
        resources.ApplyResources(Me.p_BCinfo1, "p_BCinfo1")
        Me.p_BCinfo1.Name = "p_BCinfo1"
        '
        'p_BCinfo2
        '
        Me.p_BCinfo2.DataPropertyName = "BCinfo2"
        resources.ApplyResources(Me.p_BCinfo2, "p_BCinfo2")
        Me.p_BCinfo2.Name = "p_BCinfo2"
        '
        'p_c1
        '
        Me.p_c1.DataPropertyName = "c1"
        resources.ApplyResources(Me.p_c1, "p_c1")
        Me.p_c1.Name = "p_c1"
        '
        'p_c2
        '
        Me.p_c2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.p_c2.DataPropertyName = "c2"
        resources.ApplyResources(Me.p_c2, "p_c2")
        Me.p_c2.Name = "p_c2"
        '
        'p_c3
        '
        Me.p_c3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.p_c3.DataPropertyName = "c3"
        resources.ApplyResources(Me.p_c3, "p_c3")
        Me.p_c3.Name = "p_c3"
        '
        'suppliercode
        '
        Me.suppliercode.DataPropertyName = "suppliercode"
        resources.ApplyResources(Me.suppliercode, "suppliercode")
        Me.suppliercode.Name = "suppliercode"
        '
        'T_partListBindingSource
        '
        Me.T_partListBindingSource.DataMember = "t_partList"
        Me.T_partListBindingSource.DataSource = Me.Ru_sb_tames1
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.btnp_Delete)
        Me.GroupBox7.Controls.Add(Me.btnp_query)
        resources.ApplyResources(Me.GroupBox7, "GroupBox7")
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.TabStop = False
        '
        'btnp_Delete
        '
        resources.ApplyResources(Me.btnp_Delete, "btnp_Delete")
        Me.btnp_Delete.Name = "btnp_Delete"
        Me.ToolTip1.SetToolTip(Me.btnp_Delete, resources.GetString("btnp_Delete.ToolTip"))
        Me.btnp_Delete.UseVisualStyleBackColor = True
        '
        'btnp_query
        '
        resources.ApplyResources(Me.btnp_query, "btnp_query")
        Me.btnp_query.Name = "btnp_query"
        Me.btnp_query.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label35)
        Me.GroupBox5.Controls.Add(Me.tbp_suppliercode)
        Me.GroupBox5.Controls.Add(Me.Label34)
        Me.GroupBox5.Controls.Add(Me.tbp_labelType)
        Me.GroupBox5.Controls.Add(Me.btn_AddPart)
        Me.GroupBox5.Controls.Add(Me.cbp_HPN)
        Me.GroupBox5.Controls.Add(Me.cbp_partType)
        Me.GroupBox5.Controls.Add(Me.cbp_DGSymbol)
        Me.GroupBox5.Controls.Add(Me.cbp_custName)
        Me.GroupBox5.Controls.Add(Me.tbp_partCounter)
        Me.GroupBox5.Controls.Add(Me.tbp_idComp)
        Me.GroupBox5.Controls.Add(Me.tbp_packfactor)
        Me.GroupBox5.Controls.Add(Me.tbp_custPartNo)
        Me.GroupBox5.Controls.Add(Me.tbp_partDesc)
        Me.GroupBox5.Controls.Add(Me.Label28)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Controls.Add(Me.Label17)
        Me.GroupBox5.Controls.Add(Me.Label16)
        Me.GroupBox5.Controls.Add(Me.Label15)
        Me.GroupBox5.Controls.Add(Me.Label14)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Controls.Add(Me.tbp_partNo)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Controls.Add(Me.Label9)
        Me.GroupBox5.Controls.Add(Me.Label8)
        resources.ApplyResources(Me.GroupBox5, "GroupBox5")
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.TabStop = False
        '
        'Label35
        '
        resources.ApplyResources(Me.Label35, "Label35")
        Me.Label35.Name = "Label35"
        '
        'tbp_suppliercode
        '
        resources.ApplyResources(Me.tbp_suppliercode, "tbp_suppliercode")
        Me.tbp_suppliercode.Name = "tbp_suppliercode"
        '
        'Label34
        '
        resources.ApplyResources(Me.Label34, "Label34")
        Me.Label34.Name = "Label34"
        '
        'tbp_labelType
        '
        resources.ApplyResources(Me.tbp_labelType, "tbp_labelType")
        Me.tbp_labelType.Name = "tbp_labelType"
        Me.ToolTip1.SetToolTip(Me.tbp_labelType, resources.GetString("tbp_labelType.ToolTip"))
        '
        'btn_AddPart
        '
        resources.ApplyResources(Me.btn_AddPart, "btn_AddPart")
        Me.btn_AddPart.Name = "btn_AddPart"
        Me.btn_AddPart.UseVisualStyleBackColor = True
        '
        'cbp_HPN
        '
        resources.ApplyResources(Me.cbp_HPN, "cbp_HPN")
        Me.cbp_HPN.FormattingEnabled = True
        Me.cbp_HPN.Name = "cbp_HPN"
        Me.cbp_HPN.Sorted = True
        '
        'cbp_partType
        '
        Me.cbp_partType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cbp_partType, "cbp_partType")
        Me.cbp_partType.FormattingEnabled = True
        Me.cbp_partType.Items.AddRange(New Object() {resources.GetString("cbp_partType.Items"), resources.GetString("cbp_partType.Items1")})
        Me.cbp_partType.Name = "cbp_partType"
        Me.cbp_partType.Sorted = True
        Me.ToolTip1.SetToolTip(Me.cbp_partType, resources.GetString("cbp_partType.ToolTip"))
        '
        'cbp_DGSymbol
        '
        Me.cbp_DGSymbol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cbp_DGSymbol, "cbp_DGSymbol")
        Me.cbp_DGSymbol.FormattingEnabled = True
        Me.cbp_DGSymbol.Items.AddRange(New Object() {resources.GetString("cbp_DGSymbol.Items"), resources.GetString("cbp_DGSymbol.Items1"), resources.GetString("cbp_DGSymbol.Items2")})
        Me.cbp_DGSymbol.Name = "cbp_DGSymbol"
        Me.cbp_DGSymbol.Sorted = True
        '
        'cbp_custName
        '
        resources.ApplyResources(Me.cbp_custName, "cbp_custName")
        Me.cbp_custName.FormattingEnabled = True
        Me.cbp_custName.Name = "cbp_custName"
        Me.cbp_custName.Sorted = True
        '
        'tbp_partCounter
        '
        resources.ApplyResources(Me.tbp_partCounter, "tbp_partCounter")
        Me.tbp_partCounter.Name = "tbp_partCounter"
        '
        'tbp_idComp
        '
        resources.ApplyResources(Me.tbp_idComp, "tbp_idComp")
        Me.tbp_idComp.Name = "tbp_idComp"
        '
        'tbp_packfactor
        '
        resources.ApplyResources(Me.tbp_packfactor, "tbp_packfactor")
        Me.tbp_packfactor.Name = "tbp_packfactor"
        Me.ToolTip1.SetToolTip(Me.tbp_packfactor, resources.GetString("tbp_packfactor.ToolTip"))
        '
        'tbp_custPartNo
        '
        Me.tbp_custPartNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.tbp_custPartNo, "tbp_custPartNo")
        Me.tbp_custPartNo.Name = "tbp_custPartNo"
        '
        'tbp_partDesc
        '
        Me.tbp_partDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.tbp_partDesc, "tbp_partDesc")
        Me.tbp_partDesc.Name = "tbp_partDesc"
        '
        'Label28
        '
        resources.ApplyResources(Me.Label28, "Label28")
        Me.Label28.Name = "Label28"
        '
        'Label13
        '
        resources.ApplyResources(Me.Label13, "Label13")
        Me.Label13.Name = "Label13"
        '
        'Label17
        '
        resources.ApplyResources(Me.Label17, "Label17")
        Me.Label17.Name = "Label17"
        '
        'Label16
        '
        resources.ApplyResources(Me.Label16, "Label16")
        Me.Label16.Name = "Label16"
        '
        'Label15
        '
        resources.ApplyResources(Me.Label15, "Label15")
        Me.Label15.Name = "Label15"
        '
        'Label14
        '
        resources.ApplyResources(Me.Label14, "Label14")
        Me.Label14.Name = "Label14"
        '
        'Label12
        '
        resources.ApplyResources(Me.Label12, "Label12")
        Me.Label12.Name = "Label12"
        Me.ToolTip1.SetToolTip(Me.Label12, resources.GetString("Label12.ToolTip"))
        '
        'tbp_partNo
        '
        Me.tbp_partNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.tbp_partNo, "tbp_partNo")
        Me.tbp_partNo.Name = "tbp_partNo"
        Me.ToolTip1.SetToolTip(Me.tbp_partNo, resources.GetString("tbp_partNo.ToolTip"))
        '
        'Label10
        '
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.Name = "Label10"
        '
        'Label11
        '
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.Name = "Label11"
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.Name = "Label9"
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        '
        'TabPageHLabel
        '
        Me.TabPageHLabel.Controls.Add(Me.GroupBox9)
        Me.TabPageHLabel.Controls.Add(Me.GroupBox8)
        resources.ApplyResources(Me.TabPageHLabel, "TabPageHLabel")
        Me.TabPageHLabel.Name = "TabPageHLabel"
        Me.TabPageHLabel.UseVisualStyleBackColor = True
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.T_HLabelDataGridView)
        Me.GroupBox9.Controls.Add(Me.GroupBox10)
        resources.ApplyResources(Me.GroupBox9, "GroupBox9")
        Me.GroupBox9.ForeColor = System.Drawing.Color.Black
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.TabStop = False
        '
        'T_HLabelDataGridView
        '
        Me.T_HLabelDataGridView.AllowUserToAddRows = False
        Me.T_HLabelDataGridView.AllowUserToDeleteRows = False
        Me.T_HLabelDataGridView.AllowUserToResizeRows = False
        Me.T_HLabelDataGridView.AutoGenerateColumns = False
        Me.T_HLabelDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.T_HLabelDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T_HLabelDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.h_labelPN, Me.h_labelLayout, Me.h_IdentificationNo, Me.h_ModelNo, Me.h_ECEApprovalType, Me.h_ECEApprovalNo, Me.h_EECApprovalType, Me.h_EECApprovalNo, Me.h_AIRBAG, Me.h_PretensionerType, Me.h_BarCode})
        Me.T_HLabelDataGridView.DataSource = Me.T_HLabelBindingSource
        resources.ApplyResources(Me.T_HLabelDataGridView, "T_HLabelDataGridView")
        Me.T_HLabelDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.T_HLabelDataGridView.Name = "T_HLabelDataGridView"
        Me.T_HLabelDataGridView.RowHeadersVisible = False
        '
        'h_labelPN
        '
        Me.h_labelPN.DataPropertyName = "labelPN"
        resources.ApplyResources(Me.h_labelPN, "h_labelPN")
        Me.h_labelPN.Name = "h_labelPN"
        '
        'h_labelLayout
        '
        Me.h_labelLayout.DataPropertyName = "labelLayout"
        resources.ApplyResources(Me.h_labelLayout, "h_labelLayout")
        Me.h_labelLayout.Name = "h_labelLayout"
        '
        'h_IdentificationNo
        '
        Me.h_IdentificationNo.DataPropertyName = "IdentificationNo"
        resources.ApplyResources(Me.h_IdentificationNo, "h_IdentificationNo")
        Me.h_IdentificationNo.Name = "h_IdentificationNo"
        '
        'h_ModelNo
        '
        Me.h_ModelNo.DataPropertyName = "ModelNo"
        resources.ApplyResources(Me.h_ModelNo, "h_ModelNo")
        Me.h_ModelNo.Name = "h_ModelNo"
        '
        'h_ECEApprovalType
        '
        Me.h_ECEApprovalType.DataPropertyName = "ECEApprovalType"
        resources.ApplyResources(Me.h_ECEApprovalType, "h_ECEApprovalType")
        Me.h_ECEApprovalType.Name = "h_ECEApprovalType"
        '
        'h_ECEApprovalNo
        '
        Me.h_ECEApprovalNo.DataPropertyName = "ECEApprovalNo"
        resources.ApplyResources(Me.h_ECEApprovalNo, "h_ECEApprovalNo")
        Me.h_ECEApprovalNo.Name = "h_ECEApprovalNo"
        '
        'h_EECApprovalType
        '
        Me.h_EECApprovalType.DataPropertyName = "EECApprovalType"
        resources.ApplyResources(Me.h_EECApprovalType, "h_EECApprovalType")
        Me.h_EECApprovalType.Name = "h_EECApprovalType"
        '
        'h_EECApprovalNo
        '
        Me.h_EECApprovalNo.DataPropertyName = "EECApprovalNo"
        resources.ApplyResources(Me.h_EECApprovalNo, "h_EECApprovalNo")
        Me.h_EECApprovalNo.Name = "h_EECApprovalNo"
        '
        'h_AIRBAG
        '
        Me.h_AIRBAG.DataPropertyName = "AIRBAG"
        resources.ApplyResources(Me.h_AIRBAG, "h_AIRBAG")
        Me.h_AIRBAG.Name = "h_AIRBAG"
        '
        'h_PretensionerType
        '
        Me.h_PretensionerType.DataPropertyName = "PretensionerType"
        resources.ApplyResources(Me.h_PretensionerType, "h_PretensionerType")
        Me.h_PretensionerType.Name = "h_PretensionerType"
        '
        'h_BarCode
        '
        Me.h_BarCode.DataPropertyName = "BarCode"
        resources.ApplyResources(Me.h_BarCode, "h_BarCode")
        Me.h_BarCode.Name = "h_BarCode"
        '
        'T_HLabelBindingSource
        '
        Me.T_HLabelBindingSource.DataMember = "t_HLabel"
        Me.T_HLabelBindingSource.DataSource = Me.Ru_sb_tames1
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.btnh_delete)
        Me.GroupBox10.Controls.Add(Me.btnh_query)
        resources.ApplyResources(Me.GroupBox10, "GroupBox10")
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.TabStop = False
        '
        'btnh_delete
        '
        resources.ApplyResources(Me.btnh_delete, "btnh_delete")
        Me.btnh_delete.Name = "btnh_delete"
        Me.ToolTip1.SetToolTip(Me.btnh_delete, resources.GetString("btnh_delete.ToolTip"))
        Me.btnh_delete.UseVisualStyleBackColor = True
        '
        'btnh_query
        '
        resources.ApplyResources(Me.btnh_query, "btnh_query")
        Me.btnh_query.Name = "btnh_query"
        Me.btnh_query.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.tbh_position)
        Me.GroupBox8.Controls.Add(Me.btnh_addHPN)
        Me.GroupBox8.Controls.Add(Me.tbh_barcode)
        Me.GroupBox8.Controls.Add(Me.Label27)
        Me.GroupBox8.Controls.Add(Me.cbh_airbag)
        Me.GroupBox8.Controls.Add(Me.tbh_eecapnumber)
        Me.GroupBox8.Controls.Add(Me.Label24)
        Me.GroupBox8.Controls.Add(Me.tbh_eecaptype)
        Me.GroupBox8.Controls.Add(Me.Label25)
        Me.GroupBox8.Controls.Add(Me.tbh_eceapnumber)
        Me.GroupBox8.Controls.Add(Me.Label23)
        Me.GroupBox8.Controls.Add(Me.tbh_eceaptype)
        Me.GroupBox8.Controls.Add(Me.Label22)
        Me.GroupBox8.Controls.Add(Me.tbh_modelNo)
        Me.GroupBox8.Controls.Add(Me.Label33)
        Me.GroupBox8.Controls.Add(Me.Label26)
        Me.GroupBox8.Controls.Add(Me.Label21)
        Me.GroupBox8.Controls.Add(Me.tbh_custPn)
        Me.GroupBox8.Controls.Add(Me.Label20)
        Me.GroupBox8.Controls.Add(Me.tbh_layout)
        Me.GroupBox8.Controls.Add(Me.tbh_partNo)
        Me.GroupBox8.Controls.Add(Me.Label19)
        Me.GroupBox8.Controls.Add(Me.Label18)
        resources.ApplyResources(Me.GroupBox8, "GroupBox8")
        Me.GroupBox8.ForeColor = System.Drawing.Color.Black
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.TabStop = False
        '
        'tbh_position
        '
        resources.ApplyResources(Me.tbh_position, "tbh_position")
        Me.tbh_position.Name = "tbh_position"
        '
        'btnh_addHPN
        '
        resources.ApplyResources(Me.btnh_addHPN, "btnh_addHPN")
        Me.btnh_addHPN.Name = "btnh_addHPN"
        Me.btnh_addHPN.UseVisualStyleBackColor = True
        '
        'tbh_barcode
        '
        resources.ApplyResources(Me.tbh_barcode, "tbh_barcode")
        Me.tbh_barcode.Name = "tbh_barcode"
        '
        'Label27
        '
        resources.ApplyResources(Me.Label27, "Label27")
        Me.Label27.Name = "Label27"
        '
        'cbh_airbag
        '
        Me.cbh_airbag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cbh_airbag, "cbh_airbag")
        Me.cbh_airbag.FormattingEnabled = True
        Me.cbh_airbag.Items.AddRange(New Object() {resources.GetString("cbh_airbag.Items"), resources.GetString("cbh_airbag.Items1")})
        Me.cbh_airbag.Name = "cbh_airbag"
        Me.cbh_airbag.Sorted = True
        '
        'tbh_eecapnumber
        '
        resources.ApplyResources(Me.tbh_eecapnumber, "tbh_eecapnumber")
        Me.tbh_eecapnumber.Name = "tbh_eecapnumber"
        '
        'Label24
        '
        resources.ApplyResources(Me.Label24, "Label24")
        Me.Label24.Name = "Label24"
        '
        'tbh_eecaptype
        '
        resources.ApplyResources(Me.tbh_eecaptype, "tbh_eecaptype")
        Me.tbh_eecaptype.Name = "tbh_eecaptype"
        '
        'Label25
        '
        resources.ApplyResources(Me.Label25, "Label25")
        Me.Label25.Name = "Label25"
        '
        'tbh_eceapnumber
        '
        resources.ApplyResources(Me.tbh_eceapnumber, "tbh_eceapnumber")
        Me.tbh_eceapnumber.Name = "tbh_eceapnumber"
        '
        'Label23
        '
        resources.ApplyResources(Me.Label23, "Label23")
        Me.Label23.Name = "Label23"
        '
        'tbh_eceaptype
        '
        resources.ApplyResources(Me.tbh_eceaptype, "tbh_eceaptype")
        Me.tbh_eceaptype.Name = "tbh_eceaptype"
        '
        'Label22
        '
        resources.ApplyResources(Me.Label22, "Label22")
        Me.Label22.Name = "Label22"
        '
        'tbh_modelNo
        '
        resources.ApplyResources(Me.tbh_modelNo, "tbh_modelNo")
        Me.tbh_modelNo.Name = "tbh_modelNo"
        '
        'Label33
        '
        resources.ApplyResources(Me.Label33, "Label33")
        Me.Label33.Name = "Label33"
        '
        'Label26
        '
        resources.ApplyResources(Me.Label26, "Label26")
        Me.Label26.Name = "Label26"
        '
        'Label21
        '
        resources.ApplyResources(Me.Label21, "Label21")
        Me.Label21.Name = "Label21"
        '
        'tbh_custPn
        '
        Me.tbh_custPn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.tbh_custPn, "tbh_custPn")
        Me.tbh_custPn.Name = "tbh_custPn"
        '
        'Label20
        '
        resources.ApplyResources(Me.Label20, "Label20")
        Me.Label20.Name = "Label20"
        '
        'tbh_layout
        '
        Me.tbh_layout.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.tbh_layout, "tbh_layout")
        Me.tbh_layout.Name = "tbh_layout"
        '
        'tbh_partNo
        '
        Me.tbh_partNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.tbh_partNo, "tbh_partNo")
        Me.tbh_partNo.Name = "tbh_partNo"
        Me.ToolTip1.SetToolTip(Me.tbh_partNo, resources.GetString("tbh_partNo.ToolTip"))
        '
        'Label19
        '
        resources.ApplyResources(Me.Label19, "Label19")
        Me.Label19.Name = "Label19"
        '
        'Label18
        '
        resources.ApplyResources(Me.Label18, "Label18")
        Me.Label18.Name = "Label18"
        '
        'TabPageTraceability
        '
        Me.TabPageTraceability.Controls.Add(Me.T_labelsDataGridView)
        Me.TabPageTraceability.Controls.Add(Me.GroupBox12)
        resources.ApplyResources(Me.TabPageTraceability, "TabPageTraceability")
        Me.TabPageTraceability.Name = "TabPageTraceability"
        Me.TabPageTraceability.UseVisualStyleBackColor = True
        '
        'T_labelsDataGridView
        '
        Me.T_labelsDataGridView.AllowUserToAddRows = False
        Me.T_labelsDataGridView.AllowUserToDeleteRows = False
        Me.T_labelsDataGridView.AllowUserToResizeRows = False
        Me.T_labelsDataGridView.AutoGenerateColumns = False
        Me.T_labelsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.T_labelsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T_labelsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12})
        Me.T_labelsDataGridView.DataSource = Me.T_labelsBindingSource
        resources.ApplyResources(Me.T_labelsDataGridView, "T_labelsDataGridView")
        Me.T_labelsDataGridView.Name = "T_labelsDataGridView"
        Me.T_labelsDataGridView.RowHeadersVisible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "labelBarcode"
        resources.ApplyResources(Me.DataGridViewTextBoxColumn2, "DataGridViewTextBoxColumn2")
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "logDate"
        resources.ApplyResources(Me.DataGridViewTextBoxColumn3, "DataGridViewTextBoxColumn3")
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "logTime"
        resources.ApplyResources(Me.DataGridViewTextBoxColumn4, "DataGridViewTextBoxColumn4")
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "orderNo"
        resources.ApplyResources(Me.DataGridViewTextBoxColumn5, "DataGridViewTextBoxColumn5")
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "partNo"
        resources.ApplyResources(Me.DataGridViewTextBoxColumn6, "DataGridViewTextBoxColumn6")
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "custPN"
        resources.ApplyResources(Me.DataGridViewTextBoxColumn7, "DataGridViewTextBoxColumn7")
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "BoxNo"
        resources.ApplyResources(Me.DataGridViewTextBoxColumn8, "DataGridViewTextBoxColumn8")
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "val1"
        resources.ApplyResources(Me.DataGridViewTextBoxColumn9, "DataGridViewTextBoxColumn9")
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "val2"
        resources.ApplyResources(Me.DataGridViewTextBoxColumn10, "DataGridViewTextBoxColumn10")
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "val3"
        resources.ApplyResources(Me.DataGridViewTextBoxColumn11, "DataGridViewTextBoxColumn11")
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "val4"
        resources.ApplyResources(Me.DataGridViewTextBoxColumn12, "DataGridViewTextBoxColumn12")
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        '
        'T_labelsBindingSource
        '
        Me.T_labelsBindingSource.DataMember = "t_labels"
        Me.T_labelsBindingSource.DataSource = Me.Ru_sb_tames1
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.btn_FindBarcode)
        Me.GroupBox12.Controls.Add(Me.tb_lblBarcode)
        Me.GroupBox12.Controls.Add(Me.Label29)
        resources.ApplyResources(Me.GroupBox12, "GroupBox12")
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.TabStop = False
        '
        'btn_FindBarcode
        '
        resources.ApplyResources(Me.btn_FindBarcode, "btn_FindBarcode")
        Me.btn_FindBarcode.Name = "btn_FindBarcode"
        Me.btn_FindBarcode.UseVisualStyleBackColor = True
        '
        'tb_lblBarcode
        '
        resources.ApplyResources(Me.tb_lblBarcode, "tb_lblBarcode")
        Me.tb_lblBarcode.Name = "tb_lblBarcode"
        '
        'Label29
        '
        resources.ApplyResources(Me.Label29, "Label29")
        Me.Label29.Name = "Label29"
        '
        'TabPageProductivity
        '
        Me.TabPageProductivity.Controls.Add(Me.SplitContainer1)
        Me.TabPageProductivity.Controls.Add(Me.GroupBox13)
        resources.ApplyResources(Me.TabPageProductivity, "TabPageProductivity")
        Me.TabPageProductivity.Name = "TabPageProductivity"
        Me.TabPageProductivity.UseVisualStyleBackColor = True
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.btnProdFind)
        Me.GroupBox13.Controls.Add(Me.GroupBox15)
        Me.GroupBox13.Controls.Add(Me.GroupBox16)
        Me.GroupBox13.Controls.Add(Me.GroupBox14)
        Me.GroupBox13.Controls.Add(Me.GroupBox17)
        resources.ApplyResources(Me.GroupBox13, "GroupBox13")
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.TabStop = False
        '
        'btnProdFind
        '
        resources.ApplyResources(Me.btnProdFind, "btnProdFind")
        Me.btnProdFind.Name = "btnProdFind"
        Me.btnProdFind.UseVisualStyleBackColor = True
        '
        'GroupBox15
        '
        Me.GroupBox15.Controls.Add(Me.rbGroupByOrder)
        Me.GroupBox15.Controls.Add(Me.rbGroupByDate)
        resources.ApplyResources(Me.GroupBox15, "GroupBox15")
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.TabStop = False
        '
        'rbGroupByOrder
        '
        resources.ApplyResources(Me.rbGroupByOrder, "rbGroupByOrder")
        Me.rbGroupByOrder.Name = "rbGroupByOrder"
        Me.rbGroupByOrder.UseVisualStyleBackColor = True
        '
        'rbGroupByDate
        '
        resources.ApplyResources(Me.rbGroupByDate, "rbGroupByDate")
        Me.rbGroupByDate.Checked = True
        Me.rbGroupByDate.Name = "rbGroupByDate"
        Me.rbGroupByDate.TabStop = True
        Me.rbGroupByDate.UseVisualStyleBackColor = True
        '
        'GroupBox16
        '
        Me.GroupBox16.Controls.Add(Me.dtpEndOfTimeFilter)
        Me.GroupBox16.Controls.Add(Me.tbLeitzahl)
        resources.ApplyResources(Me.GroupBox16, "GroupBox16")
        Me.GroupBox16.ForeColor = System.Drawing.Color.Black
        Me.GroupBox16.Name = "GroupBox16"
        Me.GroupBox16.TabStop = False
        '
        'dtpEndOfTimeFilter
        '
        Me.dtpEndOfTimeFilter.Format = System.Windows.Forms.DateTimePickerFormat.Time
        resources.ApplyResources(Me.dtpEndOfTimeFilter, "dtpEndOfTimeFilter")
        Me.dtpEndOfTimeFilter.Name = "dtpEndOfTimeFilter"
        Me.dtpEndOfTimeFilter.ShowUpDown = True
        Me.dtpEndOfTimeFilter.Value = New Date(2016, 9, 6, 23, 59, 0, 0)
        '
        'tbLeitzahl
        '
        resources.ApplyResources(Me.tbLeitzahl, "tbLeitzahl")
        Me.tbLeitzahl.Name = "tbLeitzahl"
        '
        'GroupBox14
        '
        Me.GroupBox14.Controls.Add(Me.dtpBeginOfTimeFilter)
        Me.GroupBox14.Controls.Add(Me.tbProdLine)
        resources.ApplyResources(Me.GroupBox14, "GroupBox14")
        Me.GroupBox14.ForeColor = System.Drawing.Color.Black
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.TabStop = False
        '
        'dtpBeginOfTimeFilter
        '
        Me.dtpBeginOfTimeFilter.Format = System.Windows.Forms.DateTimePickerFormat.Time
        resources.ApplyResources(Me.dtpBeginOfTimeFilter, "dtpBeginOfTimeFilter")
        Me.dtpBeginOfTimeFilter.Name = "dtpBeginOfTimeFilter"
        Me.dtpBeginOfTimeFilter.ShowUpDown = True
        Me.dtpBeginOfTimeFilter.Value = New Date(2016, 9, 6, 0, 1, 0, 0)
        '
        'tbProdLine
        '
        resources.ApplyResources(Me.tbProdLine, "tbProdLine")
        Me.tbProdLine.Name = "tbProdLine"
        '
        'GroupBox17
        '
        Me.GroupBox17.Controls.Add(Me.Label32)
        Me.GroupBox17.Controls.Add(Me.dtpProdEnd)
        Me.GroupBox17.Controls.Add(Me.dtpProdStart)
        Me.GroupBox17.Controls.Add(Me.Label31)
        resources.ApplyResources(Me.GroupBox17, "GroupBox17")
        Me.GroupBox17.Name = "GroupBox17"
        Me.GroupBox17.TabStop = False
        '
        'Label32
        '
        resources.ApplyResources(Me.Label32, "Label32")
        Me.Label32.Name = "Label32"
        '
        'dtpProdEnd
        '
        resources.ApplyResources(Me.dtpProdEnd, "dtpProdEnd")
        Me.dtpProdEnd.Name = "dtpProdEnd"
        '
        'dtpProdStart
        '
        resources.ApplyResources(Me.dtpProdStart, "dtpProdStart")
        Me.dtpProdStart.Name = "dtpProdStart"
        '
        'Label31
        '
        resources.ApplyResources(Me.Label31, "Label31")
        Me.Label31.Name = "Label31"
        '
        'TabPageBreaks
        '
        Me.TabPageBreaks.Controls.Add(Me.gbNewBreak)
        Me.TabPageBreaks.Controls.Add(Me.dgvBreaks)
        resources.ApplyResources(Me.TabPageBreaks, "TabPageBreaks")
        Me.TabPageBreaks.Name = "TabPageBreaks"
        Me.TabPageBreaks.UseVisualStyleBackColor = True
        '
        'gbNewBreak
        '
        Me.gbNewBreak.Controls.Add(Me.dtpBeginBreak)
        Me.gbNewBreak.Controls.Add(Me.dtpEndBreak)
        Me.gbNewBreak.Controls.Add(Me.btnAddBreak)
        Me.gbNewBreak.Controls.Add(Me.tbComment)
        Me.gbNewBreak.Controls.Add(Me.labelComment)
        Me.gbNewBreak.Controls.Add(Me.labelBreakTo)
        Me.gbNewBreak.Controls.Add(Me.tbLineID)
        Me.gbNewBreak.Controls.Add(Me.labelBreakFrom)
        Me.gbNewBreak.Controls.Add(Me.labelLineID)
        resources.ApplyResources(Me.gbNewBreak, "gbNewBreak")
        Me.gbNewBreak.ForeColor = System.Drawing.Color.Black
        Me.gbNewBreak.Name = "gbNewBreak"
        Me.gbNewBreak.TabStop = False
        '
        'dtpBeginBreak
        '
        Me.dtpBeginBreak.Format = System.Windows.Forms.DateTimePickerFormat.Time
        resources.ApplyResources(Me.dtpBeginBreak, "dtpBeginBreak")
        Me.dtpBeginBreak.Name = "dtpBeginBreak"
        Me.dtpBeginBreak.ShowUpDown = True
        Me.dtpBeginBreak.Value = New Date(2016, 9, 6, 0, 1, 0, 0)
        '
        'dtpEndBreak
        '
        Me.dtpEndBreak.Format = System.Windows.Forms.DateTimePickerFormat.Time
        resources.ApplyResources(Me.dtpEndBreak, "dtpEndBreak")
        Me.dtpEndBreak.Name = "dtpEndBreak"
        Me.dtpEndBreak.ShowUpDown = True
        Me.dtpEndBreak.Value = New Date(2016, 9, 6, 0, 1, 0, 0)
        '
        'btnAddBreak
        '
        resources.ApplyResources(Me.btnAddBreak, "btnAddBreak")
        Me.btnAddBreak.Name = "btnAddBreak"
        Me.btnAddBreak.UseVisualStyleBackColor = True
        '
        'tbComment
        '
        resources.ApplyResources(Me.tbComment, "tbComment")
        Me.tbComment.Name = "tbComment"
        '
        'labelComment
        '
        resources.ApplyResources(Me.labelComment, "labelComment")
        Me.labelComment.Name = "labelComment"
        '
        'labelBreakTo
        '
        resources.ApplyResources(Me.labelBreakTo, "labelBreakTo")
        Me.labelBreakTo.Name = "labelBreakTo"
        '
        'tbLineID
        '
        resources.ApplyResources(Me.tbLineID, "tbLineID")
        Me.tbLineID.Name = "tbLineID"
        Me.ToolTip1.SetToolTip(Me.tbLineID, resources.GetString("tbLineID.ToolTip"))
        '
        'labelBreakFrom
        '
        resources.ApplyResources(Me.labelBreakFrom, "labelBreakFrom")
        Me.labelBreakFrom.Name = "labelBreakFrom"
        '
        'labelLineID
        '
        resources.ApplyResources(Me.labelLineID, "labelLineID")
        Me.labelLineID.Name = "labelLineID"
        '
        'dgvBreaks
        '
        Me.dgvBreaks.AllowUserToAddRows = False
        resources.ApplyResources(Me.dgvBreaks, "dgvBreaks")
        Me.dgvBreaks.AutoGenerateColumns = False
        Me.dgvBreaks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBreaks.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BreaksIDDataGridViewTextBoxColumn, Me.BreaksLineIDDataGridViewTextBoxColumn, Me.BeginBreakTimeDataGridViewTextBoxColumn, Me.EndBreakTimeDataGridViewTextBoxColumn, Me.CommentDataGridViewTextBoxColumn})
        Me.dgvBreaks.DataSource = Me.T_linesBreaksBindingSource
        Me.dgvBreaks.Name = "dgvBreaks"
        '
        'TabPageInterrupts
        '
        Me.TabPageInterrupts.Controls.Add(Me.dgvInterrupts)
        resources.ApplyResources(Me.TabPageInterrupts, "TabPageInterrupts")
        Me.TabPageInterrupts.Name = "TabPageInterrupts"
        Me.TabPageInterrupts.UseVisualStyleBackColor = True
        '
        'dgvInterrupts
        '
        resources.ApplyResources(Me.dgvInterrupts, "dgvInterrupts")
        Me.dgvInterrupts.AutoGenerateColumns = False
        Me.dgvInterrupts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInterrupts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.InterruptsIDDataGridViewTextBoxColumn, Me.AccidentDateDataGridViewTextBoxColumn, Me.GangDataGridViewTextBoxColumn, Me.InterruptsLineIDDataGridViewTextBoxColumn, Me.EquipmentNameDataGridViewTextBoxColumn, Me.InterruptTimestampDataGridViewTextBoxColumn, Me.BeginRepairTimestampDataGridViewTextBoxColumn, Me.EndOfInterruptTimestampDataGridViewTextBoxColumn, Me.InterruptCodeDataGridViewTextBoxColumn, Me.CauseOfInterruptDataGridViewTextBoxColumn, Me.CarriedOutActionsDataGridViewTextBoxColumn, Me.WhoIsLastDataGridViewTextBoxColumn})
        Me.dgvInterrupts.DataSource = Me.T_linesInterruptsBindingSource
        Me.dgvInterrupts.Name = "dgvInterrupts"
        '
        'TabPageSettings
        '
        Me.TabPageSettings.Controls.Add(Me.T_SettingsDataGridView)
        Me.TabPageSettings.Controls.Add(Me.GroupBox11)
        resources.ApplyResources(Me.TabPageSettings, "TabPageSettings")
        Me.TabPageSettings.Name = "TabPageSettings"
        Me.TabPageSettings.UseVisualStyleBackColor = True
        '
        'T_SettingsDataGridView
        '
        Me.T_SettingsDataGridView.AllowUserToAddRows = False
        Me.T_SettingsDataGridView.AllowUserToDeleteRows = False
        Me.T_SettingsDataGridView.AllowUserToResizeRows = False
        Me.T_SettingsDataGridView.AutoGenerateColumns = False
        Me.T_SettingsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.T_SettingsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.T_SettingsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumnvarName, Me.DataGridViewTextBoxColumnvarValue})
        Me.T_SettingsDataGridView.DataSource = Me.T_SettingsBindingSource
        resources.ApplyResources(Me.T_SettingsDataGridView, "T_SettingsDataGridView")
        Me.T_SettingsDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.T_SettingsDataGridView.MultiSelect = False
        Me.T_SettingsDataGridView.Name = "T_SettingsDataGridView"
        Me.T_SettingsDataGridView.RowHeadersVisible = False
        Me.T_SettingsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        '
        'DataGridViewTextBoxColumnvarName
        '
        Me.DataGridViewTextBoxColumnvarName.DataPropertyName = "varName"
        resources.ApplyResources(Me.DataGridViewTextBoxColumnvarName, "DataGridViewTextBoxColumnvarName")
        Me.DataGridViewTextBoxColumnvarName.Name = "DataGridViewTextBoxColumnvarName"
        '
        'DataGridViewTextBoxColumnvarValue
        '
        Me.DataGridViewTextBoxColumnvarValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumnvarValue.DataPropertyName = "varValue"
        resources.ApplyResources(Me.DataGridViewTextBoxColumnvarValue, "DataGridViewTextBoxColumnvarValue")
        Me.DataGridViewTextBoxColumnvarValue.Name = "DataGridViewTextBoxColumnvarValue"
        '
        'T_SettingsBindingSource
        '
        Me.T_SettingsBindingSource.DataMember = "t_Settings"
        Me.T_SettingsBindingSource.DataSource = Me.Ru_sb_tames1
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.tbs_varValue)
        Me.GroupBox11.Controls.Add(Me.tbs_varName)
        Me.GroupBox11.Controls.Add(Me.ButtonSettingsDelete)
        Me.GroupBox11.Controls.Add(Me.ButtonSettingsAdd)
        Me.GroupBox11.Controls.Add(Me.ButtonSettingsUpdate)
        resources.ApplyResources(Me.GroupBox11, "GroupBox11")
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.TabStop = False
        '
        'tbs_varValue
        '
        resources.ApplyResources(Me.tbs_varValue, "tbs_varValue")
        Me.tbs_varValue.Name = "tbs_varValue"
        '
        'tbs_varName
        '
        resources.ApplyResources(Me.tbs_varName, "tbs_varName")
        Me.tbs_varName.Name = "tbs_varName"
        '
        'ButtonSettingsDelete
        '
        resources.ApplyResources(Me.ButtonSettingsDelete, "ButtonSettingsDelete")
        Me.ButtonSettingsDelete.Name = "ButtonSettingsDelete"
        Me.ButtonSettingsDelete.UseVisualStyleBackColor = True
        '
        'ButtonSettingsAdd
        '
        resources.ApplyResources(Me.ButtonSettingsAdd, "ButtonSettingsAdd")
        Me.ButtonSettingsAdd.Name = "ButtonSettingsAdd"
        Me.ButtonSettingsAdd.UseVisualStyleBackColor = True
        '
        'ButtonSettingsUpdate
        '
        resources.ApplyResources(Me.ButtonSettingsUpdate, "ButtonSettingsUpdate")
        Me.ButtonSettingsUpdate.Name = "ButtonSettingsUpdate"
        Me.ButtonSettingsUpdate.UseVisualStyleBackColor = True
        '
        'TimerStartOrder
        '
        Me.TimerStartOrder.Interval = 500
        '
        'TimerNoWorkWarning
        '
        Me.TimerNoWorkWarning.Interval = 500000
        '
        'TimerStopOrder
        '
        Me.TimerStopOrder.Interval = 1000
        '
        'TimerCountBlink
        '
        Me.TimerCountBlink.Interval = 200
        '
        'TimerHideCurentStatus
        '
        Me.TimerHideCurentStatus.Interval = 5000
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 300
        '
        'BackgroundWorkerQueryOrders
        '
        Me.BackgroundWorkerQueryOrders.WorkerSupportsCancellation = True
        '
        'BackgroundWorkerFillOrderPNInfo
        '
        Me.BackgroundWorkerFillOrderPNInfo.WorkerSupportsCancellation = True
        '
        'BackgroundWorkerLoadPartTabel
        '
        Me.BackgroundWorkerLoadPartTabel.WorkerSupportsCancellation = True
        '
        'BackgroundWorkerLoadHomoLabel
        '
        Me.BackgroundWorkerLoadHomoLabel.WorkerSupportsCancellation = True
        '
        't_HLabelTableAdapter1
        '
        Me.t_HLabelTableAdapter1.ClearBeforeFill = True
        '
        'T_partListTableAdapter1
        '
        Me.T_partListTableAdapter1.ClearBeforeFill = True
        '
        'T_orderListTableAdapter1
        '
        Me.T_orderListTableAdapter1.ClearBeforeFill = True
        '
        'T_SettingsTableAdapter1
        '
        Me.T_SettingsTableAdapter1.ClearBeforeFill = True
        '
        'T_labelsTableAdapter1
        '
        Me.T_labelsTableAdapter1.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.t_SettingsTableAdapter = Me.T_SettingsTableAdapter1
        Me.TableAdapterManager.UpdateOrder = LabelPrint.ru_sb_tamesTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'BackgroundWorkerLoadCustLabel
        '
        Me.BackgroundWorkerLoadCustLabel.WorkerSupportsCancellation = True
        '
        'T_productivityTableAdapter1
        '
        Me.T_productivityTableAdapter1.ClearBeforeFill = True
        '
        'BackgroundWorkerProductivity1
        '
        '
        'T_HLabelTableAdapter2
        '
        Me.T_HLabelTableAdapter2.ClearBeforeFill = True
        '
        'BreaksIDDataGridViewTextBoxColumn
        '
        Me.BreaksIDDataGridViewTextBoxColumn.DataPropertyName = "ID"
        resources.ApplyResources(Me.BreaksIDDataGridViewTextBoxColumn, "BreaksIDDataGridViewTextBoxColumn")
        Me.BreaksIDDataGridViewTextBoxColumn.Name = "BreaksIDDataGridViewTextBoxColumn"
        '
        'BreaksLineIDDataGridViewTextBoxColumn
        '
        Me.BreaksLineIDDataGridViewTextBoxColumn.DataPropertyName = "lineID"
        resources.ApplyResources(Me.BreaksLineIDDataGridViewTextBoxColumn, "BreaksLineIDDataGridViewTextBoxColumn")
        Me.BreaksLineIDDataGridViewTextBoxColumn.Name = "BreaksLineIDDataGridViewTextBoxColumn"
        '
        'BeginBreakTimeDataGridViewTextBoxColumn
        '
        Me.BeginBreakTimeDataGridViewTextBoxColumn.DataPropertyName = "beginBreakTime"
        resources.ApplyResources(Me.BeginBreakTimeDataGridViewTextBoxColumn, "BeginBreakTimeDataGridViewTextBoxColumn")
        Me.BeginBreakTimeDataGridViewTextBoxColumn.Name = "BeginBreakTimeDataGridViewTextBoxColumn"
        '
        'EndBreakTimeDataGridViewTextBoxColumn
        '
        Me.EndBreakTimeDataGridViewTextBoxColumn.DataPropertyName = "endBreakTime"
        resources.ApplyResources(Me.EndBreakTimeDataGridViewTextBoxColumn, "EndBreakTimeDataGridViewTextBoxColumn")
        Me.EndBreakTimeDataGridViewTextBoxColumn.Name = "EndBreakTimeDataGridViewTextBoxColumn"
        '
        'CommentDataGridViewTextBoxColumn
        '
        Me.CommentDataGridViewTextBoxColumn.DataPropertyName = "comment"
        resources.ApplyResources(Me.CommentDataGridViewTextBoxColumn, "CommentDataGridViewTextBoxColumn")
        Me.CommentDataGridViewTextBoxColumn.Name = "CommentDataGridViewTextBoxColumn"
        '
        'InterruptsIDDataGridViewTextBoxColumn
        '
        Me.InterruptsIDDataGridViewTextBoxColumn.DataPropertyName = "ID"
        resources.ApplyResources(Me.InterruptsIDDataGridViewTextBoxColumn, "InterruptsIDDataGridViewTextBoxColumn")
        Me.InterruptsIDDataGridViewTextBoxColumn.Name = "InterruptsIDDataGridViewTextBoxColumn"
        '
        'AccidentDateDataGridViewTextBoxColumn
        '
        Me.AccidentDateDataGridViewTextBoxColumn.DataPropertyName = "accidentDate"
        resources.ApplyResources(Me.AccidentDateDataGridViewTextBoxColumn, "AccidentDateDataGridViewTextBoxColumn")
        Me.AccidentDateDataGridViewTextBoxColumn.Name = "AccidentDateDataGridViewTextBoxColumn"
        '
        'GangDataGridViewTextBoxColumn
        '
        Me.GangDataGridViewTextBoxColumn.DataPropertyName = "gang"
        resources.ApplyResources(Me.GangDataGridViewTextBoxColumn, "GangDataGridViewTextBoxColumn")
        Me.GangDataGridViewTextBoxColumn.Name = "GangDataGridViewTextBoxColumn"
        '
        'InterruptsLineIDDataGridViewTextBoxColumn
        '
        Me.InterruptsLineIDDataGridViewTextBoxColumn.DataPropertyName = "lineID"
        resources.ApplyResources(Me.InterruptsLineIDDataGridViewTextBoxColumn, "InterruptsLineIDDataGridViewTextBoxColumn")
        Me.InterruptsLineIDDataGridViewTextBoxColumn.Name = "InterruptsLineIDDataGridViewTextBoxColumn"
        '
        'EquipmentNameDataGridViewTextBoxColumn
        '
        Me.EquipmentNameDataGridViewTextBoxColumn.DataPropertyName = "equipmentName"
        resources.ApplyResources(Me.EquipmentNameDataGridViewTextBoxColumn, "EquipmentNameDataGridViewTextBoxColumn")
        Me.EquipmentNameDataGridViewTextBoxColumn.Name = "EquipmentNameDataGridViewTextBoxColumn"
        '
        'InterruptTimestampDataGridViewTextBoxColumn
        '
        Me.InterruptTimestampDataGridViewTextBoxColumn.DataPropertyName = "interruptTimestamp"
        resources.ApplyResources(Me.InterruptTimestampDataGridViewTextBoxColumn, "InterruptTimestampDataGridViewTextBoxColumn")
        Me.InterruptTimestampDataGridViewTextBoxColumn.Name = "InterruptTimestampDataGridViewTextBoxColumn"
        '
        'BeginRepairTimestampDataGridViewTextBoxColumn
        '
        Me.BeginRepairTimestampDataGridViewTextBoxColumn.DataPropertyName = "beginRepairTimestamp"
        resources.ApplyResources(Me.BeginRepairTimestampDataGridViewTextBoxColumn, "BeginRepairTimestampDataGridViewTextBoxColumn")
        Me.BeginRepairTimestampDataGridViewTextBoxColumn.Name = "BeginRepairTimestampDataGridViewTextBoxColumn"
        '
        'EndOfInterruptTimestampDataGridViewTextBoxColumn
        '
        Me.EndOfInterruptTimestampDataGridViewTextBoxColumn.DataPropertyName = "endOfInterruptTimestamp"
        resources.ApplyResources(Me.EndOfInterruptTimestampDataGridViewTextBoxColumn, "EndOfInterruptTimestampDataGridViewTextBoxColumn")
        Me.EndOfInterruptTimestampDataGridViewTextBoxColumn.Name = "EndOfInterruptTimestampDataGridViewTextBoxColumn"
        '
        'InterruptCodeDataGridViewTextBoxColumn
        '
        Me.InterruptCodeDataGridViewTextBoxColumn.DataPropertyName = "interruptCode"
        resources.ApplyResources(Me.InterruptCodeDataGridViewTextBoxColumn, "InterruptCodeDataGridViewTextBoxColumn")
        Me.InterruptCodeDataGridViewTextBoxColumn.Name = "InterruptCodeDataGridViewTextBoxColumn"
        '
        'CauseOfInterruptDataGridViewTextBoxColumn
        '
        Me.CauseOfInterruptDataGridViewTextBoxColumn.DataPropertyName = "causeOfInterrupt"
        resources.ApplyResources(Me.CauseOfInterruptDataGridViewTextBoxColumn, "CauseOfInterruptDataGridViewTextBoxColumn")
        Me.CauseOfInterruptDataGridViewTextBoxColumn.Name = "CauseOfInterruptDataGridViewTextBoxColumn"
        '
        'CarriedOutActionsDataGridViewTextBoxColumn
        '
        Me.CarriedOutActionsDataGridViewTextBoxColumn.DataPropertyName = "carriedOutActions"
        resources.ApplyResources(Me.CarriedOutActionsDataGridViewTextBoxColumn, "CarriedOutActionsDataGridViewTextBoxColumn")
        Me.CarriedOutActionsDataGridViewTextBoxColumn.Name = "CarriedOutActionsDataGridViewTextBoxColumn"
        '
        'WhoIsLastDataGridViewTextBoxColumn
        '
        Me.WhoIsLastDataGridViewTextBoxColumn.DataPropertyName = "whoIsLast"
        resources.ApplyResources(Me.WhoIsLastDataGridViewTextBoxColumn, "WhoIsLastDataGridViewTextBoxColumn")
        Me.WhoIsLastDataGridViewTextBoxColumn.Name = "WhoIsLastDataGridViewTextBoxColumn"
        '
        'T_linesBreaksBindingSource
        '
        Me.T_linesBreaksBindingSource.DataMember = "t_linesBreaks"
        Me.T_linesBreaksBindingSource.DataSource = Me.Sb_tamesBreaksDataSet
        '
        'Sb_tamesBreaksDataSet
        '
        Me.Sb_tamesBreaksDataSet.DataSetName = "sb_tamesBreaksDataSet"
        Me.Sb_tamesBreaksDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'T_linesInterruptsBindingSource
        '
        Me.T_linesInterruptsBindingSource.DataMember = "t_linesInterrupts"
        Me.T_linesInterruptsBindingSource.DataSource = Me.Sb_tamesInterruptsDataSet
        '
        'Sb_tamesInterruptsDataSet
        '
        Me.Sb_tamesInterruptsDataSet.DataSetName = "sb_tamesInterruptsDataSet"
        Me.Sb_tamesInterruptsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'T_linesBreaksTableAdapter
        '
        Me.T_linesBreaksTableAdapter.ClearBeforeFill = True
        '
        'T_linesInterruptsTableAdapter
        '
        Me.T_linesInterruptsTableAdapter.ClearBeforeFill = True
        '
        'Form1
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TabControlIndex)
        Me.Controls.Add(Me.ListBoxLog)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.dgvProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TabControlIndex.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.PanelProductivity.ResumeLayout(False)
        CType(Me.DataGridViewProductivity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelScanMaster.ResumeLayout(False)
        CType(Me.DataGridViewOrders, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.PanelStartOrder.ResumeLayout(False)
        Me.PanelWarning.ResumeLayout(False)
        Me.PanelError.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPageOrder.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.T_orderListDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_orderListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ru_sb_tames1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabPagePN.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.T_partListDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_partListBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.TabPageHLabel.ResumeLayout(False)
        Me.GroupBox9.ResumeLayout(False)
        CType(Me.T_HLabelDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_HLabelBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.TabPageTraceability.ResumeLayout(False)
        CType(Me.T_labelsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_labelsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        Me.TabPageProductivity.ResumeLayout(False)
        Me.GroupBox13.ResumeLayout(False)
        Me.GroupBox15.ResumeLayout(False)
        Me.GroupBox15.PerformLayout()
        Me.GroupBox16.ResumeLayout(False)
        Me.GroupBox16.PerformLayout()
        Me.GroupBox14.ResumeLayout(False)
        Me.GroupBox14.PerformLayout()
        Me.GroupBox17.ResumeLayout(False)
        Me.GroupBox17.PerformLayout()
        Me.TabPageBreaks.ResumeLayout(False)
        Me.gbNewBreak.ResumeLayout(False)
        Me.gbNewBreak.PerformLayout()
        CType(Me.dgvBreaks, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageInterrupts.ResumeLayout(False)
        CType(Me.dgvInterrupts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageSettings.ResumeLayout(False)
        CType(Me.T_SettingsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_SettingsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        CType(Me.T_linesBreaksBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Sb_tamesBreaksDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_linesInterruptsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Sb_tamesInterruptsDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Friend WithEvents ListBoxLog As System.Windows.Forms.ListBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabelLineName As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TabControlIndex As System.Windows.Forms.TabControl
    Private WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents Ru_sb_tames1 As LabelPrint.ru_sb_tames
    Friend WithEvents DataGridViewOrders As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonOpenOrder As System.Windows.Forms.Button
    Friend WithEvents ButtonCloseOrder As System.Windows.Forms.Button
    Friend WithEvents PanelStartOrder As System.Windows.Forms.Panel
    Friend WithEvents LabelStartOrder As System.Windows.Forms.Label
    Friend WithEvents TimerStartOrder As System.Windows.Forms.Timer
    Friend WithEvents T_partListTableAdapter1 As LabelPrint.ru_sb_tamesTableAdapters.t_partListTableAdapter
    Friend WithEvents T_orderListTableAdapter1 As LabelPrint.ru_sb_tamesTableAdapters.t_orderListTableAdapter
    Friend WithEvents T_SettingsTableAdapter1 As LabelPrint.ru_sb_tamesTableAdapters.t_SettingsTableAdapter
    Friend WithEvents ButtonCancelScanOrder As System.Windows.Forms.Button
    Friend WithEvents LabelLabelCount As System.Windows.Forms.Label
    Friend WithEvents T_labelsTableAdapter1 As LabelPrint.ru_sb_tamesTableAdapters.t_labelsTableAdapter
    Friend WithEvents PanelError As System.Windows.Forms.Panel
    Friend WithEvents ButtonCloseError As System.Windows.Forms.Button
    Friend WithEvents LabelError As System.Windows.Forms.Label
    Friend WithEvents ButtonPrintBoxLabel As System.Windows.Forms.Button
    Friend WithEvents TimerNoWorkWarning As System.Windows.Forms.Timer
    Friend WithEvents TimerStopOrder As System.Windows.Forms.Timer
    Friend WithEvents PanelWarning As System.Windows.Forms.Panel
    Friend WithEvents ButtonWarningCancel As System.Windows.Forms.Button
    Friend WithEvents LabelWarning As System.Windows.Forms.Label
    Friend WithEvents TimerCountBlink As System.Windows.Forms.Timer
    Friend WithEvents t_HLabelTableAdapter1 As LabelPrint.ru_sb_tamesTableAdapters.t_HLabelTableAdapter
    Friend WithEvents ToolStripStatusLabelCurentInfo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents TimerHideCurentStatus As System.Windows.Forms.Timer
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPageOrder As System.Windows.Forms.TabPage
    Friend WithEvents TabPagePN As System.Windows.Forms.TabPage
    Friend WithEvents TabPageHLabel As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents tbo_Qty As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbo_Order As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents tbo_partDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tbo_custPn As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbo_custName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tbo_pLine As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents T_orderListDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents T_orderListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btno_addOrder As System.Windows.Forms.Button
    Friend WithEvents TableAdapterManager As LabelPrint.ru_sb_tamesTableAdapters.TableAdapterManager
    Friend WithEvents btno_query As System.Windows.Forms.Button
    Friend WithEvents cbo_stopped As System.Windows.Forms.CheckBox
    Friend WithEvents cbo_started As System.Windows.Forms.CheckBox
    Friend WithEvents cbo_created As System.Windows.Forms.CheckBox
    Friend WithEvents BackgroundWorkerQueryOrders As System.ComponentModel.BackgroundWorker
    Friend WithEvents cbo_partNo As System.Windows.Forms.ComboBox
    Friend WithEvents BackgroundWorkerFillOrderPNInfo As System.ComponentModel.BackgroundWorker
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents tbp_partNo As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbp_custName As System.Windows.Forms.ComboBox
    Friend WithEvents tbp_custPartNo As System.Windows.Forms.TextBox
    Friend WithEvents tbp_partDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents tbp_packfactor As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cbp_DGSymbol As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cbp_HPN As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents tbp_idComp As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents tbp_partCounter As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btn_AddPart As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents T_partListDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents T_partListBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents btnp_query As System.Windows.Forms.Button
    Friend WithEvents BackgroundWorkerLoadPartTabel As System.ComponentModel.BackgroundWorker
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents tbh_partNo As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents tbh_layout As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents tbh_custPn As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents tbh_modelNo As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents tbh_eceapnumber As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents tbh_eceaptype As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents tbh_eecapnumber As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents tbh_eecaptype As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents btnh_addHPN As System.Windows.Forms.Button
    Friend WithEvents tbh_barcode As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents btnh_query As System.Windows.Forms.Button
    Friend WithEvents T_HLabelDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents T_HLabelBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BackgroundWorkerLoadHomoLabel As System.ComponentModel.BackgroundWorker
    Friend WithEvents TabPageSettings As System.Windows.Forms.TabPage
    Friend WithEvents T_SettingsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents T_SettingsDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonSettingsUpdate As System.Windows.Forms.Button
    Friend WithEvents ButtonSettingsDelete As System.Windows.Forms.Button
    Friend WithEvents ButtonSettingsAdd As System.Windows.Forms.Button
    Friend WithEvents tbs_varValue As System.Windows.Forms.TextBox
    Friend WithEvents tbs_varName As System.Windows.Forms.TextBox
    Friend WithEvents btno_delete As System.Windows.Forms.Button
    Friend WithEvents btnp_Delete As System.Windows.Forms.Button
    Friend WithEvents btnh_delete As System.Windows.Forms.Button
    Friend WithEvents cbp_partType As System.Windows.Forms.ComboBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents TabPageTraceability As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents tb_lblBarcode As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents btn_FindBarcode As System.Windows.Forms.Button
    Friend WithEvents T_labelsDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents T_labelsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataGridViewTextBoxColumnvarName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumnvarValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PanelScanMaster As System.Windows.Forms.Panel
    Friend WithEvents LabelScanMaster As System.Windows.Forms.Label
    Friend WithEvents ButtonCancelMaster As System.Windows.Forms.Button
    Friend WithEvents ColumnOrderNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnOrderQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnpartNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnPartName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnCustPN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnCustName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnPackFactor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnBoxNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnLine As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnDGSymbol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnBCInfo1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnBCInfo2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnHomologationPN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnPartType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents orderNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents orderQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents partNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents partDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents custpartNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents custName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents oStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BoxNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BackgroundWorkerLoadCustLabel As System.ComponentModel.BackgroundWorker
    Friend WithEvents btno_PrintBL As System.Windows.Forms.Button
    Friend WithEvents ButtonChangeCounter As System.Windows.Forms.Button
    Friend WithEvents PanelProductivity As System.Windows.Forms.Panel
    Friend WithEvents DataGridViewProductivity As System.Windows.Forms.DataGridView
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents T_productivityTableAdapter1 As LabelPrint.ru_sb_tamesTableAdapters.t_productivityTableAdapter
    Friend WithEvents TabPageProductivity As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpProdEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents dtpProdStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents GroupBox14 As System.Windows.Forms.GroupBox
    Friend WithEvents tbProdLine As System.Windows.Forms.TextBox
    Friend WithEvents btnProdFind As System.Windows.Forms.Button
    Friend WithEvents BackgroundWorkerProductivity1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents dgvProd As System.Windows.Forms.DataGridView
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents h_labelPN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents h_labelLayout As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents h_IdentificationNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents h_ModelNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents h_ECEApprovalType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents h_ECEApprovalNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents h_EECApprovalType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents h_EECApprovalNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents h_AIRBAG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents h_PretensionerType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents h_BarCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cbh_airbag As System.Windows.Forms.ComboBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents GroupBox15 As System.Windows.Forms.GroupBox
    Friend WithEvents rbGroupByOrder As System.Windows.Forms.RadioButton
    Friend WithEvents rbGroupByDate As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox16 As System.Windows.Forms.GroupBox
    Friend WithEvents tbLeitzahl As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox17 As System.Windows.Forms.GroupBox
    Friend WithEvents tbh_position As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents tbp_labelType As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents tbp_suppliercode As System.Windows.Forms.TextBox
    Friend WithEvents p_partNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents p_partDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents p_custPartNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents p_custName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents p_packfactor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents p_DGSymbol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents p_BCinfo1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents p_BCinfo2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents p_c1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents p_c2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents p_c3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents suppliercode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents T_HLabelTableAdapter2 As LabelPrint.ru_sb_tamesTableAdapters.t_HLabelTableAdapter
    Friend WithEvents dtpEndOfTimeFilter As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpBeginOfTimeFilter As System.Windows.Forms.DateTimePicker
    Friend WithEvents TabPageBreaks As System.Windows.Forms.TabPage
    Friend WithEvents Sb_tamesBreaksDataSet As LabelPrint.sb_tamesBreaksDataSet
    Friend WithEvents T_linesBreaksBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents T_linesBreaksTableAdapter As LabelPrint.sb_tamesBreaksDataSetTableAdapters.t_linesBreaksTableAdapter
    Friend WithEvents dgvBreaks As System.Windows.Forms.DataGridView
    Friend WithEvents gbNewBreak As System.Windows.Forms.GroupBox
    Friend WithEvents btnAddBreak As System.Windows.Forms.Button
    Friend WithEvents tbComment As System.Windows.Forms.TextBox
    Friend WithEvents labelComment As System.Windows.Forms.Label
    Friend WithEvents labelBreakTo As System.Windows.Forms.Label
    Friend WithEvents tbLineID As System.Windows.Forms.TextBox
    Friend WithEvents labelBreakFrom As System.Windows.Forms.Label
    Friend WithEvents labelLineID As System.Windows.Forms.Label
    Friend WithEvents BreaksIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BreaksLineIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BeginBreakTimeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EndBreakTimeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtpBeginBreak As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpEndBreak As System.Windows.Forms.DateTimePicker
    Friend WithEvents TabPageInterrupts As System.Windows.Forms.TabPage
    Friend WithEvents dgvInterrupts As System.Windows.Forms.DataGridView
    Friend WithEvents Sb_tamesInterruptsDataSet As LabelPrint.sb_tamesInterruptsDataSet
    Friend WithEvents T_linesInterruptsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents T_linesInterruptsTableAdapter As LabelPrint.sb_tamesInterruptsDataSetTableAdapters.t_linesInterruptsTableAdapter
    Friend WithEvents InterruptsIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccidentDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GangDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InterruptsLineIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EquipmentNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InterruptTimestampDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BeginRepairTimestampDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EndOfInterruptTimestampDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InterruptCodeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CauseOfInterruptDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CarriedOutActionsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WhoIsLastDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
