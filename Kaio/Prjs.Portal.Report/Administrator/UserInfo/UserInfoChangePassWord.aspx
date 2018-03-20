<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="UserInfoChangePassWord.aspx.vb" Inherits="Prjs.Portal.Report.UserInfoChangePassWord" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../Styles/HQ.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Transparency="30"
            MinDisplayTime="500">
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            </telerik:RadScriptManager>
        </telerik:RadAjaxLoadingPanel>
        <telerik:RadAjaxManager ID="AjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="CheckBoxShowPass">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="txtNew_PassWord" />
                        <telerik:AjaxUpdatedControl ControlID="txtReType_PassWord" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <div id="HQ">
            <div class="alert">
                <asp:Label ID="lbltitle" runat="server" CssClass="lbltitle"></asp:Label><br />
                <asp:Label ID="lblerror" runat="server" CssClass="lblerror"></asp:Label>
            </div>
            <div class="input">
                <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                    <tr>
                        <td align="right" width="30%">
                            <asp:Label ID="Label17" runat="server" CssClass="label">Mật khẩu cũ:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtOld_PassWord" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="40%" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="20%">
                            <asp:Label ID="Label7" runat="server" CssClass="label">Mật khẩu mới:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtNew_PassWord" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="40%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label15" runat="server" CssClass="label">Nhập lại mật khẩu:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtReType_PassWord" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="40%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            &nbsp;</td>
                        <td align="left">
                            <asp:CheckBox ID="CheckBoxShowPass" runat="server" AutoPostBack="True" CssClass="checkbox" Text="Hiển thị  ký tự" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            &nbsp;</td>
                        <td align="left">
                <asp:Button ID="btnResetPassWord" runat="server" CssClass="btnbackground"
                    Text="Đổi mật khẩu" />
                <asp:Button ID="btnReturn" runat="server" CssClass="btnbackground"
                    Text="Quay ra" />
                        </td>
                    </tr>
                    </table>
            </div>
            
        </div>
    </form>
</body>
</html>
