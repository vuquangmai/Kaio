﻿Public Class Billing_Index
    Inherits GlobalPage
#Region "Page Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            IsAccessChannel(ChannelUser.Billing)
        End If
    End Sub
#End Region

End Class