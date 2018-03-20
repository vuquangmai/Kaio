Public Class Charging_Banner
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

        Me.lblSMSChannel.Visible = ChannelUser.SMS
        If ChannelUser.SMS = True Then
            Me.lblSMS.Text = Constants.Channel.Text.SMS
        Else
            Me.lblSMS.Text = ""
        End If

        Me.lblS2Channel.Visible = ChannelUser.S2
        If ChannelUser.S2 = True Then
            Me.lblS2.Text = Constants.Channel.Text.S2
        Else
            Me.lblS2.Text = ""
        End If

        Me.lblVinaboxChannel.Visible = ChannelUser.Vinabox
        If ChannelUser.Vinabox = True Then
            Me.lblVinabox.Text = Constants.Channel.Text.Vinabox
        Else
            Me.lblVinabox.Text = ""
        End If

        Me.lblGamePortalChannel.Visible = ChannelUser.GamePortal
        If ChannelUser.GamePortal = True Then
            Me.lblGamePortal.Text = Constants.Channel.Text.GamePortal
        Else
            Me.lblGamePortal.Text = ""
        End If

        Me.lblVishareChannel.Visible = ChannelUser.Vishare
        If ChannelUser.Vishare = True Then
            Me.lblVishare.Text = Constants.Channel.Text.Vishare
        Else
            Me.lblVishare.Text = ""
        End If

        Me.lblSimToolKitChannel.Visible = ChannelUser.SimToolKit
        If ChannelUser.SimToolKit = True Then
            Me.lblSimToolKit.Text = Constants.Channel.Text.SimToolKit
        Else
            Me.lblSimToolKit.Text = ""
        End If
        Me.lblBillingChannel.Visible = ChannelUser.Billing
        If ChannelUser.Billing = True Then
            Me.lblBilling.Text = Constants.Channel.Text.Billing
        Else
            Me.lblBilling.Text = ""
        End If
        Me.lblCustomerInfoChannel.Visible = ChannelUser.CustomerInfo
        If ChannelUser.CustomerInfo = True Then
            Me.lblCustomerInfo.Text = Constants.Channel.Text.CustomerInfo
        Else
            Me.lblCustomerInfo.Text = ""
        End If

        Me.lblChargingChannel.Visible = ChannelUser.Charging
        If ChannelUser.Charging = True Then
            Me.lblCharging.Text = Constants.Channel.Text.Charging
        Else
            Me.lblCharging.Text = ""
        End If
        Me.lblMGameChannel.Visible = ChannelUser.MGame
        If ChannelUser.MGame = True Then
            Me.lblMGame.Text = Constants.Channel.Text.MGame
        Else
            Me.lblMGame.Text = ""
        End If
        Me.lblKPIChannel.Visible = ChannelUser.KPI
        If ChannelUser.KPI = True Then
            Me.lblKPI.Text = Constants.Channel.Text.KPI
        Else
            Me.lblKPI.Text = ""
        End If

        Me.lblContractChannel.Visible = ChannelUser.ContractInfo
        If ChannelUser.ContractInfo = True Then
            Me.lblContractInfo.Text = Constants.Channel.Text.ContractInfo
        Else
            Me.lblContractInfo.Text = ""
        End If
    End Sub
#End Region

End Class