Public Class performanceClaculator
    Private _plannedPerformance As Integer   ' производительность целевая, изделий в час
    Private _quantityTotal As Integer        ' сколько надо произвести изделий
    Private _quantityCurrent As Integer      ' сколько изделий произведено
    Private _startTime As Date               ' время начала работы над заказом
    Private _labelColor As Color             ' цвет отображения информации о производительности

    Public ReadOnly Property LabelColor As Color
        Get
            Return _labelColor
        End Get
    End Property

    Public Property QuantityCurrent As Integer
        Get
            Return _quantityCurrent
        End Get
        Set(value As Integer)
            _quantityCurrent = value
            If _quantityCurrent = 1 Then
                _startTime = Date.Now
            End If
            'тут должна быть прверка, не пора ли стрельнуть событием "предупреждение о переналадке"
        End Set
    End Property

    Overloads Function ToString() As String
        Dim timeElapsed = (Date.Now - _startTime).TotalSeconds
        Dim currentPerformance = (_quantityCurrent * 3600) / timeElapsed ' производительность фактическая, изделий в час
        If currentPerformance < _plannedPerformance - 1 Then
            _labelColor = Color.Red
        ElseIf currentPerformance > _plannedPerformance + 1 Then
            _labelColor = Color.Green
        Else
            _labelColor = Color.Yellow
        End If
        Return _plannedPerformance.ToString() + "/" + currentPerformance.ToString()
    End Function


End Class
