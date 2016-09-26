Partial Class sb_tamesBreaksDataSet
End Class


Namespace sb_tamesBreaksDataSetTableAdapters
    
    Partial Public Class t_linesBreaksTableAdapter
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), _
 Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"), _
 Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.[Select], False)> _
        Public Overridable Overloads Function GetDataByLineNtime(ByVal timeFrom As Global.System.Nullable(Of TimeSpan), ByVal timeTo As Global.System.Nullable(Of TimeSpan), ByVal lineID As String) As sb_tamesBreaksDataSet.t_linesBreaksDataTable
            Me.Adapter.SelectCommand = Me.CommandCollection(3)
            If (timeFrom.HasValue = True) Then
                Me.Adapter.SelectCommand.Parameters(0).Value = CType(timeFrom.Value, TimeSpan)
            Else
                Me.Adapter.SelectCommand.Parameters(0).Value = Global.System.DBNull.Value
            End If
            If (timeTo.HasValue = True) Then
                Me.Adapter.SelectCommand.Parameters(1).Value = CType(timeTo.Value, TimeSpan)
            Else
                Me.Adapter.SelectCommand.Parameters(1).Value = Global.System.DBNull.Value
            End If
            If (timeFrom.HasValue = True) Then
                Me.Adapter.SelectCommand.Parameters(2).Value = CType(timeFrom.Value, TimeSpan)
            Else
                Me.Adapter.SelectCommand.Parameters(2).Value = Global.System.DBNull.Value
            End If
            If (timeTo.HasValue = True) Then
                Me.Adapter.SelectCommand.Parameters(3).Value = CType(timeTo.Value, TimeSpan)
            Else
                Me.Adapter.SelectCommand.Parameters(3).Value = Global.System.DBNull.Value
            End If
            If (lineID Is Nothing) Then
                Me.Adapter.SelectCommand.Parameters(4).Value = Global.System.DBNull.Value
            Else
                Me.Adapter.SelectCommand.Parameters(4).Value = CType(lineID, String)
            End If
            Dim dataTable As sb_tamesBreaksDataSet.t_linesBreaksDataTable = New sb_tamesBreaksDataSet.t_linesBreaksDataTable()
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function

    End Class
End Namespace
