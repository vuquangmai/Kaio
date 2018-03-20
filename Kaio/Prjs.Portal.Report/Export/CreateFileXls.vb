Public Class CreateFilexls
    Public Class SMS
        Public Class LKF
            Public Shared Function CycleReport(ByVal Year As Integer, ByVal Company_Id As Integer, ByVal FilePath As String) As String
                Dim retval As String = ""
                Dim wsheet As New Excel.Worksheet
                Dim exl As New Excel.Application
                'wsheet = exl.Workbooks.Add.Worksheets.Add
                exl.Application.Sheets.Add()
                wsheet = exl.Worksheets(1)
                With wsheet
                    .Name = "996,998"
                    '------------------------------------------------Tittle----------------------------------------------
                    .Range("A1:AG1").MergeCells = "true"
                    .Range("A1:AG1").Value = "BÁO CÁO SẢN LƯỢNG SMS DẢI 996,998, THÁNG " & Now.AddDays(-1).Month & " - " & Now.AddDays(-1).Year
                    .Range("A1:AG1").Name = "Arial"
                    .Range("A1:AG1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                    .Range("A1:AG1").Font.Bold = "true"
                    .Range("A1:AG1").Font.Size = 16
                    '.Range("B1:O1").Font.Color = System.Drawing.Color.RoyalBlue 'RGB(210, 255, 255)
                    .Range("A1:AG1").EntireColumn.AutoFit()
                End With


                Try
                    wsheet.SaveAs(FilePath & ".xls")
                    LogService.WriteLog(Constants.LogLevel._Info, "Create file xls successfull")
                    retval = FilePath & ".xls"
                Catch ex As Exception
                    LogService.WriteLog(Constants.LogLevel._Error, "Error select databse MSSQL. Code: " & ex.Message)
                    LogService.WriteLog(Constants.LogLevel._Debug, ex.Message)

                End Try
                exl.Workbooks.Close()
                exl.Quit()
                exl = Nothing
                Return retval
            End Function
        End Class
    End Class
    Public Class KPI
        Public Class Brand

        End Class
    End Class
End Class
