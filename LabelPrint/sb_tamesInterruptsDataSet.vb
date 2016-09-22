Partial Class sb_tamesInterruptsDataSet
End Class

Namespace sb_tamesInterruptsDataSetTableAdapters
    
    Partial Public Class t_linesInterruptsTableAdapter
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), _
         Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"), _
         Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Fill, False)> _
        Public Overridable Overloads Function FillAndCalculateBy(ByVal dataTable As sb_tamesInterruptsDataSet.t_linesInterruptsDataTable, ByVal accidentDateFrom As Global.System.Nullable(Of Date), ByVal accidentDateTo As Global.System.Nullable(Of Date), ByVal lineIDempty As String, ByVal lineID As String, ByVal interruptTimestampFrom As Global.System.Nullable(Of TimeSpan), ByVal interruptTimestampTo As Global.System.Nullable(Of TimeSpan)) As Integer
            Me.Adapter.SelectCommand = Me.CommandCollection(3)
            If (accidentDateFrom.HasValue = True) Then
                Me.Adapter.SelectCommand.Parameters(0).Value = CType(accidentDateFrom.Value, Date)
            Else
                Me.Adapter.SelectCommand.Parameters(0).Value = Global.System.DBNull.Value
            End If
            If (accidentDateTo.HasValue = True) Then
                Me.Adapter.SelectCommand.Parameters(1).Value = CType(accidentDateTo.Value, Date)
            Else
                Me.Adapter.SelectCommand.Parameters(1).Value = Global.System.DBNull.Value
            End If
            If (lineIDempty Is Nothing) Then
                Me.Adapter.SelectCommand.Parameters(2).Value = Global.System.DBNull.Value
            Else
                Me.Adapter.SelectCommand.Parameters(2).Value = CType(lineIDempty, String)
            End If
            If (lineID Is Nothing) Then
                Me.Adapter.SelectCommand.Parameters(3).Value = Global.System.DBNull.Value
            Else
                Me.Adapter.SelectCommand.Parameters(3).Value = CType(lineID, String)
            End If
            If (interruptTimestampFrom.HasValue = True) Then
                Me.Adapter.SelectCommand.Parameters(4).Value = CType(interruptTimestampFrom.Value, TimeSpan)
            Else
                Me.Adapter.SelectCommand.Parameters(4).Value = Global.System.DBNull.Value
            End If
            If (interruptTimestampTo.HasValue = True) Then
                Me.Adapter.SelectCommand.Parameters(5).Value = CType(interruptTimestampTo.Value, TimeSpan)
            Else
                Me.Adapter.SelectCommand.Parameters(5).Value = Global.System.DBNull.Value
            End If
            If (Me.ClearBeforeFill = True) Then
                dataTable.Clear()
            End If
            Dim returnValue As Integer = Me.Adapter.Fill(dataTable)
            Return returnValue
        End Function
    End Class
End Namespace
