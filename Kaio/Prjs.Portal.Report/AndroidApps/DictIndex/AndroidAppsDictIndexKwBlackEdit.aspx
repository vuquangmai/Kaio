<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AndroidAppsDictIndexKwBlackEdit.aspx.vb" Inherits="Prjs.Portal.Report.AndroidAppsDictIndexKwBlackEdit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../../Styles/HQ.css" rel="stylesheet" type="text/css" />
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
                <telerik:AjaxSetting AjaxControlID="txtUrl_Code">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="txtUrl" />
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
                <table border="0" cellpadding="2" cellspacing="1" style="width: 100%">
                    <tr>
                        <td align="right" width="30%">
                                        <asp:Label ID="Label2" runat="server" CssClass="label">Keyword:</asp:Label>
                        </td>
                        <td align="left">
                                        <asp:TextBox ID="txtKeyword" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                            Width="80%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="30%">
                                        <asp:Label ID="Label1" runat="server" CssClass="label">Trường dữ liệu:</asp:Label>
                        </td>
                        <td align="left">
                                        <asp:DropDownList ID="DropDownListField_Id" runat="server" CssClass="droplist">
                                            <asp:ListItem Value="--Chọn--">--Chọn--</asp:ListItem>
                                            <asp:ListItem Value="App_Id">App Id</asp:ListItem>
                                            <asp:ListItem Value="Requires_Android">Requires Android</asp:ListItem>
                                            <asp:ListItem Value="Current_Version" >Current Version</asp:ListItem>
                                            <asp:ListItem Value="Installs_Id" >Installs</asp:ListItem>
                                            <asp:ListItem Value="Offered_By" >Offered By</asp:ListItem>
                                            <asp:ListItem Value="Developer" >Developer</asp:ListItem>
                                        </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label9" runat="server" CssClass="label">Ghi chú:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtDescription" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Height="96px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="submmit">
                <asp:Button ID="btnUpdate" runat="server" CssClass="btnbackground"
                    Text="Ghi lại" />
                <asp:Button ID="btnDelete" runat="server" CssClass="btnbackground"
                    Text="Xóa bỏ" />
                <asp:Button ID="btnReturn" runat="server" CssClass="btnbackground"
                    Text="Quay ra" />
            </div>
        </div>
    </form>
</body>
</html>
