Public Class PerformanceClaculator
    Private _plannedPerformance As Integer              ' производительность целевая, изделий в час
    Private _quantityTotal As Integer                   ' сколько надо произвести изделий
    Private _quantityCurrent As Integer                 ' сколько изделий произведено
    Private _startTime As Date                          ' время начала работы над заказом
    Private _labelColor As Color                        ' цвет отображения информации о производительности
    Private _reajustingWarningEventRaised As Boolean    ' событие оповещения о переналадке сработало
    Private _timeSpanReajusting As TimeSpan             ' время, за которое надо предупредить о переналадке

    Public Event ReajustingWarningEvent()
    Public Event ReajustingEvent()


    Public Property TimeSpanReajusting As TimeSpan
        Get
            Return _timeSpanReajusting
        End Get
        Set(value As TimeSpan)
            _timeSpanReajusting = value
            _reajustingWarningEventRaised = False
        End Set
    End Property

    Public ReadOnly Property LabelColor As Color
        Get
            Return _labelColor 'Todo: предусмотреть вызов без использования ToString, если понадобится
        End Get
    End Property

    Public Property QuantityCurrent As Integer
        Get
            Return _quantityCurrent
        End Get
        Set(value As Integer)
            _quantityCurrent = value
            If _quantityCurrent <= 1 Then ' или всё таки 0?
                _startTime = Date.Now
                _reajustingWarningEventRaised = False
            End If

            'тут должна быть прверка, не пора ли стрельнуть событием "предупреждение о переналадке"
            'Вычислить ожидаемое время, когда произойдёт событие
            Dim raiseEventTime As Date = _startTime + TimeSpan.FromHours((CDbl(_quantityTotal) / CDbl(currenpPerformance()))) - _timeSpanReajusting
            Dim part1Timespan As TimeSpan = TimeSpan.FromHours(1 / CDbl(currenpPerformance())) ' сколько надо времени на производство одной детали

            'Если разница текущего времени и времени когда произойдёт событие меньше чем надо на производство одной детали, то сгенерировать событие и поставить флаг, что событие сработало.
            If raiseEventTime - part1Timespan < Date.Now And Not _reajustingWarningEventRaised Then
                RaiseEvent ReajustingWarningEvent() 'стреляем событие о уведомлением о переналадке
                _reajustingWarningEventRaised = True
            End If

            If QuantityCurrent = QuantityTotal Then RaiseEvent ReajustingEvent()

        End Set
    End Property

    Public Property PlannedPerformance As Integer
        Get
            Return _plannedPerformance
        End Get
        Set(value As Integer)
            _plannedPerformance = value
        End Set
    End Property

    Public Property QuantityTotal As Integer
        Get
            Return _quantityTotal
        End Get
        Set(value As Integer)
            _quantityTotal = value
            _reajustingWarningEventRaised = False
        End Set
    End Property

    Overloads Function ToString() As String
        Dim currentPerformance = currenpPerformance()
        If currentPerformance < _plannedPerformance - 1 Then
            _labelColor = Color.Red
        ElseIf currentPerformance > _plannedPerformance + 1 Then
            _labelColor = Color.Green
        Else
            _labelColor = Color.Yellow
        End If
        Return _plannedPerformance.ToString() + "/" + currentPerformance.ToString()
    End Function

    Protected Function currenpPerformance() As Integer
        Dim timeElapsed = (Date.Now - _startTime).TotalSeconds
        Return (_quantityCurrent * 3600) / timeElapsed ' производительность фактическая, изделий в час
        'TODO: проблема деления на ноль
    End Function

End Class
