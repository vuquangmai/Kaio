Public Class Administrator_Banner
    Inherits GlobalPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not Me.IsPostBack Then
            BindInfo()
        End If
    End Sub
#Region "Bind User Info"
    Private Sub BindInfo()
        Me.lblUserName.Text = CurrentUser.UserName
        Me.lblLastLogin.Text = DateTime.Parse(CurrentUser.LastLogin).ToString("dd/MM/yyyy HH:mm:ss")
        Me.lblCurrentTime.Text = Util.DateTimeFomat.DateNow()
    End Sub
#End Region
 

End Class