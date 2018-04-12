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
                _quantityCorrectinFactor = 0
            End If

            'тут должна быть прверка, не пора ли стрельнуть событием "предупреждение о переналадке"
            'Вычислить ожидаемое время, когда произойдёт событие
            Dim curPerf = CurrentPerformance()
            If curPerf > 0 Then
                Dim raiseEventTime As Date = _startTime + TimeSpan.FromHours((CDbl(_quantityTotal - _quantityCorrectinFactor) / CDbl(curPerf))) - _timeSpanReajusting
                Dim part1Timespan As TimeSpan = TimeSpan.FromHours(1 / CDbl(curPerf)) ' сколько надо времени на производство одной детали

                'Если разница текущего времени и времени когда произойдёт событие меньше чем надо на производство одной детали, то сгенерировать событие и поставить флаг, что событие сработало.
                If raiseEventTime - part1Timespan < Date.Now And Not _reajustingWarningEventRaised Then
                    RaiseEvent ReajustingWarningEvent() 'стреляем событие о уведомлением о переналадке
                    _reajustingWarningEventRaised = True
                End If
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
        Dim currPerformance = currentPerformance()
        If currPerformance < _plannedPerformance Then
            _labelColor = Color.Red
        Else
            _labelColor = Color.Green
        End If
        Return _plannedPerformance.ToString() + "/" + currPerformance.ToString()
    End Function

    Protected Function CurrentPerformance() As Integer
        Dim timeElapsed = (Date.Now - _startTime).TotalSeconds
        If timeElapsed > 180 Then ' чтобы не пугать оператора бешенными цифрами вычисление проводим только по прошествии достаточного времени
            Return ((_quantityCurrent - _quantityCorrectinFactor) * 3600) / timeElapsed ' производительность фактическая, изделий в час
        Else
            Return 0 ' производительность фактическая, изделий в час
        End If
    End Function

    Dim _quantityCorrectinFactor As Integer = 0 ' костыль для пересчёта продуктивности

    Public Sub RespawnProductivity()
        _quantityCorrectinFactor = _quantityCurrent
        _startTime = Date.Now
        _reajustingWarningEventRaised = False
    End Sub

End Class
