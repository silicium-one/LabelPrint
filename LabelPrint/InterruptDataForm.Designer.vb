<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InterruptDataForm
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
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

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim gangLabel As System.Windows.Forms.Label
        Dim carriedOutActionsLabel As System.Windows.Forms.Label
        Dim causeOfInterruptLabel As System.Windows.Forms.Label
        Dim equpmentNameLabel As System.Windows.Forms.Label
        Me.gangTextBox = New System.Windows.Forms.TextBox()
        Me.carriedOutActionsTextBox = New System.Windows.Forms.TextBox()
        Me.equipmentNameTextBox = New System.Windows.Forms.TextBox()
        Me.causeOfInterruptTextBox = New System.Windows.Forms.TextBox()
        Me.OK = New System.Windows.Forms.Button()
        gangLabel = New System.Windows.Forms.Label()
        carriedOutActionsLabel = New System.Windows.Forms.Label()
        causeOfInterruptLabel = New System.Windows.Forms.Label()
        equpmentNameLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'gangLabel
        '
        gangLabel.AutoSize = True
        gangLabel.Location = New System.Drawing.Point(160, 18)
        gangLabel.Name = "gangLabel"
        gangLabel.Size = New System.Drawing.Size(58, 20)
        gangLabel.TabIndex = 0
        gangLabel.Text = "Смена"
        gangLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'carriedOutActionsLabel
        '
        carriedOutActionsLabel.AutoSize = True
        carriedOutActionsLabel.Location = New System.Drawing.Point(8, 112)
        carriedOutActionsLabel.Name = "carriedOutActionsLabel"
        carriedOutActionsLabel.Size = New System.Drawing.Size(209, 20)
        carriedOutActionsLabel.TabIndex = 1
        carriedOutActionsLabel.Text = "Произведённые действия"
        carriedOutActionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'causeOfInterruptLabel
        '
        causeOfInterruptLabel.AutoSize = True
        causeOfInterruptLabel.Location = New System.Drawing.Point(86, 80)
        causeOfInterruptLabel.Name = "causeOfInterruptLabel"
        causeOfInterruptLabel.Size = New System.Drawing.Size(131, 20)
        causeOfInterruptLabel.TabIndex = 2
        causeOfInterruptLabel.Text = "Причина отказа"
        causeOfInterruptLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'equpmentNameLabel
        '
        equpmentNameLabel.AutoSize = True
        equpmentNameLabel.Location = New System.Drawing.Point(22, 48)
        equpmentNameLabel.Name = "equpmentNameLabel"
        equpmentNameLabel.Size = New System.Drawing.Size(195, 20)
        equpmentNameLabel.TabIndex = 3
        equpmentNameLabel.Text = "Название оборудования"
        equpmentNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gangTextBox
        '
        Me.gangTextBox.Location = New System.Drawing.Point(224, 12)
        Me.gangTextBox.Name = "gangTextBox"
        Me.gangTextBox.Size = New System.Drawing.Size(100, 26)
        Me.gangTextBox.TabIndex = 4
        '
        'carriedOutActionsTextBox
        '
        Me.carriedOutActionsTextBox.Location = New System.Drawing.Point(224, 106)
        Me.carriedOutActionsTextBox.Name = "carriedOutActionsTextBox"
        Me.carriedOutActionsTextBox.Size = New System.Drawing.Size(488, 26)
        Me.carriedOutActionsTextBox.TabIndex = 5
        '
        'equipmentNameTextBox
        '
        Me.equipmentNameTextBox.Location = New System.Drawing.Point(224, 42)
        Me.equipmentNameTextBox.Name = "equipmentNameTextBox"
        Me.equipmentNameTextBox.Size = New System.Drawing.Size(488, 26)
        Me.equipmentNameTextBox.TabIndex = 6
        '
        'causeOfInterruptTextBox
        '
        Me.causeOfInterruptTextBox.Location = New System.Drawing.Point(224, 74)
        Me.causeOfInterruptTextBox.Name = "causeOfInterruptTextBox"
        Me.causeOfInterruptTextBox.Size = New System.Drawing.Size(488, 26)
        Me.causeOfInterruptTextBox.TabIndex = 7
        '
        'OK
        '
        Me.OK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OK.Location = New System.Drawing.Point(624, 144)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(88, 40)
        Me.OK.TabIndex = 8
        Me.OK.Text = "Принять"
        Me.OK.UseVisualStyleBackColor = True
        '
        'InterruptDataForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(725, 199)
        Me.ControlBox = False
        Me.Controls.Add(Me.OK)
        Me.Controls.Add(Me.causeOfInterruptTextBox)
        Me.Controls.Add(Me.equipmentNameTextBox)
        Me.Controls.Add(Me.carriedOutActionsTextBox)
        Me.Controls.Add(Me.gangTextBox)
        Me.Controls.Add(equpmentNameLabel)
        Me.Controls.Add(causeOfInterruptLabel)
        Me.Controls.Add(carriedOutActionsLabel)
        Me.Controls.Add(gangLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "InterruptDataForm"
        Me.Text = "Укажите данные простоя"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gangTextBox As TextBox
    Friend WithEvents carriedOutActionsTextBox As TextBox
    Friend WithEvents equipmentNameTextBox As TextBox
    Friend WithEvents causeOfInterruptTextBox As TextBox
    Friend WithEvents OK As Button
End Class
