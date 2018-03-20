<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ReportLKFLotteryCycleTotalOperator.aspx.vb" Inherits="Prjs.Portal.Report.ReportLKFLotteryCycleTotalOperator" %>
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
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="DropDownListRegion_Id">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="DropDownListCompany_Id" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="DropDownListCompany_Id">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="DropDownListRegion_Id" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBoxListDateResult" />
                        <telerik:AjaxUpdatedControl ControlID="lblTotalCycle" />
                        <telerik:AjaxUpdatedControl ControlID="lblTotalCycleMonth" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <div id="HQ">
            <div class="alert">
                <asp:Label ID="lbltitle" runat="server" CssClass="lbltitle"></asp:Label><br />
                <asp:Label ID="lblerror" runat="server" CssClass="lblerror"></asp:Label>
            </div>
            <div class="input" style="width: 50%">
                <table border="0" cellpadding="3" cellspacing="3" style="width: 100%">
                    <tr>
                        <td align="right" width="20%">
                                    <asp:Label ID="Label17" runat="server" CssClass="label">Năm:</asp:Label>
                        </td>
                        <td align="left">
                                    <asp:DropDownList ID="DropDownListYear" runat="server" CssClass="droplist">
                                        <asp:ListItem>2015</asp:ListItem>
                                        <asp:ListItem>2016</asp:ListItem>
                                        <asp:ListItem>2017</asp:ListItem>
                                        <asp:ListItem>2018</asp:ListItem>
                                        <asp:ListItem>2019</asp:ListItem>
                                        <asp:ListItem>2020</asp:ListItem>
                                    </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="20%">
                                    <asp:Label ID="Label18" runat="server" CssClass="label">Loại báo cáo:</asp:Label>
                        </td>
                        <td align="left">
                                    <asp:CheckBox ID="CheckBoxOperator" runat="server" CssClass="checkbox" Text="Theo mạng, đầu số" />
                                    <asp:CheckBox ID="CheckBoxCompany" runat="server" CssClass="checkbox" Text="Theo công ty xổ số" />
                        </td>
                    </tr>
                    </table>
            </div>
            <div class="submmit">
                <asp:Button ID="btnExpot" runat="server" CssClass="btnbackground"
                    Text="Báo cáo" />
                <asp:Button ID="btnReturn" runat="server" CssClass="btnbackground"
                    Text="Quay ra" />
            </div>
        </div>
    </form>
</body>
</html>
