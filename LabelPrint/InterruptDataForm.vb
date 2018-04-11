Public Class InterruptDataForm

    Public Sub New(gang As String,
                   equipmentName As String,
                   causeOfInterrupt As String,
                   carriedOutActions As String)

        gangTextBox.Text = gang
        equipmentNameTextBox.Text = equipmentName
        causeOfInterruptTextBox.Text = causeOfInterrupt
        carriedOutActionsTextBox.Text = carriedOutActions
    End Sub

    ReadOnly Property Gang() As String
        Get
            Return gangTextBox.Text
        End Get
    End Property

    ReadOnly Property EquipmentName() As String
        Get
            Return equipmentNameTextBox.Text
        End Get
    End Property

    ReadOnly Property CauseOfInterrupt() As String
        Get
            Return causeOfInterruptTextBox.Text
        End Get
    End Property

    ReadOnly Property CarriedOutActions() As String
        Get
            Return carriedOutActionsTextBox.Text
        End Get
    End Property

End Class