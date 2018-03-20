Public Class SubscriptionService_Footer
    Inherits GlobalPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.lblcopyright.Text = ConfigurationManager.AppSettings("Copyright")
        End If
    End Sub

End Class