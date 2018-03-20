<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ReportLKFLotteryCycle.aspx.vb" Inherits="Prjs.Portal.Report.ReportLKFLotteryCycle" %>
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
            <div class="input">
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
                                    <asp:Label ID="Label18" runat="server" CssClass="label">Miền:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListRegion_Id" runat="server" CssClass="droplist" AutoPostBack="True" Height="16px">
                                <asp:ListItem Value="0">--all--</asp:ListItem>
                                <asp:ListItem Value="1">Miền Bắc</asp:ListItem>
                                <asp:ListItem Value="2">Miền Trung</asp:ListItem>
                                <asp:ListItem Value="3">Miền Nam</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="20%">
                                        <asp:Label ID="Label81" runat="server" CssClass="label">Công ty xổ số:</asp:Label>
                        </td>
                        <td align="left">
                                        <asp:DropDownList ID="DropDownListCompany_Id" runat="server" CssClass="droplist" Font-Bold="False" AutoPostBack="True">
                                        </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label9" runat="server" CssClass="label">Ngày mở thưởng:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:CheckBoxList ID="CheckBoxListDateResult" runat="server" CssClass="checkbox" RepeatColumns="7">
                                <asp:ListItem Value="1">Thứ 2</asp:ListItem>
                                <asp:ListItem Value="2">Thứ 3</asp:ListItem>
                                <asp:ListItem Value="3">Thứ 4</asp:ListItem>
                                <asp:ListItem Value="4">Thứ 5</asp:ListItem>
                                <asp:ListItem Value="5">Thứ 6</asp:ListItem>
                                <asp:ListItem Value="6">Thứ 7</asp:ListItem>
                                <asp:ListItem Value="0">Chủ nhật</asp:ListItem>
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label83" runat="server" CssClass="label">Tổng số kỳ trong năm:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblTotalCycle" runat="server" CssClass="label" Font-Bold="True" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label82" runat="server" CssClass="label">Kỳ theo tháng:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblTotalCycleMonth" runat="server" CssClass="label" Font-Bold="False"></asp:Label>
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
