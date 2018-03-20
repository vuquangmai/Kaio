Public Class SimToolKit_Index
    Inherits GlobalPage
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            IsAccessChannel(ChannelUser.SimToolKit)
        End If
    End Sub
#End Region

End Class