<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FinancialSMSRev.aspx.vb" Inherits="Prjs.Portal.Report.FinancialSMSRev" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../../../Styles/HQ.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Transparency="30"
            MinDisplayTime="500">
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            </telerik:RadScriptManager>
        </telerik:RadAjaxLoadingPanel>
        <telerik:RadAjaxManager ID="AjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
        </telerik:RadAjaxManager>
        <div id="HQ">
            <div class="alert">
                <asp:Label ID="lbltitle" runat="server" CssClass="lbltitle"></asp:Label><br />
                <asp:Label ID="lblerror" runat="server" CssClass="lblerror"></asp:Label>
            </div>
            <div class="input" style="width: 30%">
                <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                    <tr>
                        <td align="right" width="30%">
                                    <asp:Label ID="Label17" runat="server" CssClass="label">Năm:</asp:Label>
                        </td>
                        <td align="left">
                                    <asp:DropDownList ID="DropDownListYear" runat="server" CssClass="droplist">
                                    </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="30%">
                                    <asp:Label ID="Label18" runat="server" CssClass="label">Dải số:</asp:Label>
                        </td>
                        <td align="left">
                                    <asp:DropDownList ID="DropDownListShortCode" runat="server" CssClass="droplist">
                                        <asp:ListItem Value="99x">997</asp:ListItem>
                                        <asp:ListItem>8x79</asp:ListItem>
                                        <asp:ListItem>6x66</asp:ListItem>
                                        <asp:ListItem Value="8x99">8x99,996,998</asp:ListItem>
                                    </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="20%">
                                        &nbsp;</td>
                        <td align="left">
                            <asp:Label ID="lblFileDownload" runat="server" CssClass="label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="20%">
                                        &nbsp;</td>
                        <td align="left">
                <asp:Button ID="btnExport" runat="server" CssClass="btnbackground"
                    Text="Báo cáo" />
                        </td>
                    </tr>
                    </table>
            </div>
      
        </div>
    </form>
</body>
</html>
