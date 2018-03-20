Imports System.Web.SessionState
Imports System.Threading
Imports Prjs.Portal.Report.IsLiveConnection

Public Class Global_asax
    Inherits System.Web.HttpApplication
    Private ThreadGlobal As Thread
    Dim SystemCallBack As New MSSQLDatabaseGlobal

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application is started
        Try
            LogService.WriteLog(Constants.LogLevel._Info, "Restart Web Server !, Initializing The Connection !")
            If GlobalManager.OpenGlobalConnection().Trim = "" Then
                LogService.WriteLog(Constants.LogLevel._Info, "The new Connection has been opened !")
            End If
        Catch ex As Exception
            LogService.WriteLog(Constants.LogLevel._Error, "Error when initializing the Connection. Code:" & ex.Message)
        End Try
        ThreadGlobal = New Threading.Thread(AddressOf SystemCallBack.IsCallBack)
        ThreadGlobal.Start()

    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session is started
        Session.Timeout = 12000
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires at the beginning of each request
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticate the use
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when an error occurs
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session ends
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub

End Class