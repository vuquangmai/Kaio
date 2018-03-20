Public Class AndroidApps_Banner
    Inherits GlobalPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            BindInfo()
            IsChannel()
        End If
    End Sub
#Region "Bind User Info"
    Private Sub BindInfo()
        Me.lblUserName.Text = CurrentUser.UserName
        Me.lblLastLogin.Text = DateTime.Parse(CurrentUser.LastLogin).ToString("dd/MM/yyyy HH:mm:ss")
        Me.lblCurrentTime.Text = Util.DateTimeFomat.DateNow()
    End Sub
#End Region
#Region "Check Access Channel"
    Private Sub IsChannel()
        Me.lblHome.Text = Constants.Channel.Text.Home
        Me.lblAdministratorChannel.Visible = ChannelUser.Administrator
        If ChannelUser.Administrator = True Then
            Me.lblAdministrator.Text = Constants.Channel.Text.Administrator
        Else
            Me.lblAdministrator.Text = ""
        End If

        Me.lblAndroidAppsChannel.Visible = ChannelUser.AndroidApps
        If ChannelUser.AndroidApps = True Then
            Me.lblAndroidApps.Text = Constants.Channel.Text.AndroidApps
        Else
            Me.lblAndroidApps.Text = ""
        End If

        Me.lblCcareChannel.Visible = ChannelUser.Ccare
        If ChannelUser.Ccare = True Then
            Me.lblCcare.Text = Constants.Channel.Text.Ccare
        Else
            Me.lblCcare.Text = ""
        End If


    End Sub
#End Region

End Class