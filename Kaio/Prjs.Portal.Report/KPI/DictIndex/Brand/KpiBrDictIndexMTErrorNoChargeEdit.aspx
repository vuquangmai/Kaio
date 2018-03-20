<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="KpiBrDictIndexMTErrorNoChargeEdit.aspx.vb" Inherits="Prjs.Portal.Report.KpiBrDictIndexMTErrorNoChargeEdit" %>

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
            <div class="input">
                <table border="0" cellpadding="2" cellspacing="1" style="width: 100%">
                    <tr>
                        <td align="right" width="30%">
                            <asp:Label ID="Label18" runat="server" CssClass="label">Tiêu chí:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtCriteria_Text" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="90%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="20%">
                            <asp:Label ID="Label16" runat="server" CssClass="label">Ngưỡng xử lý:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtStandar_Threshold_Handle" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="10%" Font-Bold="True"></asp:TextBox>
                            <asp:Label ID="lblTypeOf_Unit" runat="server" CssClass="label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label17" runat="server" CssClass="label">Bước nhảy quá ngưỡng xử lý chuẩn:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtStandar_Threshold_Handle_Over" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="10%" Font-Bold="True"></asp:TextBox>
                            <asp:Label ID="lblTypeOf_Unit0" runat="server" CssClass="label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label14" runat="server" CssClass="label">Điểm trừ:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtDecrease_Percent" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="10%" Font-Bold="True"></asp:TextBox>
                            <asp:Label ID="Label29" runat="server" CssClass="label">%</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label28" runat="server" CssClass="label">Điểm trừ tối đa:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtDecrease_Percent_Max" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="10%" Font-Bold="True"></asp:TextBox>
                            <asp:Label ID="Label30" runat="server" CssClass="label">%</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label9" runat="server" CssClass="label">Ghi chú:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtDescription" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Height="55px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="submmit">
                <asp:Button ID="btnUpdate" runat="server" CssClass="btnbackground"
                    Text="Ghi lại" />
                <asp:Button ID="btnReturn" runat="server" CssClass="btnbackground"
                    Text="Quay ra" />
            </div>
        </div>
    </form>
</body>
</html>
