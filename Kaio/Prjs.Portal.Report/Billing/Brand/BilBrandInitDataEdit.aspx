<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BilBrandInitDataEdit.aspx.vb" Inherits="Prjs.Portal.Report.BilBrandInitDataEdit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../../Styles/HQ.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            border-collapse: collapse;
            width: 100%;
            vertical-align: bottom;
            border-style: none;
            border-color: inherit;
            border-width: 0;
        }
        .auto-style2 {
            width: 100%;
            padding-right: 4px;
        }
    </style>
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
                <telerik:AjaxSetting AjaxControlID="txtTotal_Revenue">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="txtTotal_Debts" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="txtTotal_Payment">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="txtTotal_Debts" />
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
                <table border="0" cellpadding="4" cellspacing="4" style="width: 100%">
                    <tr>
                        <td align="right" width="20%">
                            <asp:Label ID="Label7" runat="server" CssClass="label">Mã hợp đồng:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblContract_Code" runat="server" CssClass="label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" >
                            <asp:Label ID="Label27" runat="server" CssClass="label">Số hợp đồng:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblContract_Number" runat="server" CssClass="label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right"  >
                            <asp:Label ID="Label26" runat="server" CssClass="label">Đối tác:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblPartner_Text" runat="server" CssClass="label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" >
                            <asp:Label ID="Label28" runat="server" CssClass="label">Mã đối tác:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblPartner_Code" runat="server" CssClass="label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right"  >
                            <asp:Label ID="Label16" runat="server" CssClass="label">Tháng đối soát:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblMonth" runat="server" CssClass="label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label14" runat="server" CssClass="label">Doanh thu:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListHave_Revenue" runat="server" CssClass="droplist">
                                <asp:ListItem Value="Y">Phát sinh doanh thu</asp:ListItem>
                                <asp:ListItem Value="N">Không phát sinh doanh thu</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                                <asp:Label ID="Label29" runat="server" CssClass="label">Tổng doanh thu:</asp:Label>
                        </td>
                        <td align="left">

                                <telerik:RadNumericTextBox ShowSpinButtons="true"
                                    IncrementSettings-InterceptArrowKeys="true"
                                    IncrementSettings-InterceptMouseWheel="true" LabelWidth="" runat="server"
                                    ID="txtTotal_Revenue" Width="120px" CssClass="txtContent" Culture="vi-VN"
                                    Font-Bold="True" Font-Names="Arial" Skin="Forest" AutoPostBack="True">
                                    <NumberFormat ZeroPattern="n" DecimalDigits="2" AllowRounding="False"></NumberFormat>
                                </telerik:RadNumericTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                                <asp:Label ID="Label12" runat="server" CssClass="label">Đã thanh toán:</asp:Label>
                        </td>
                        <td align="left">

                                <telerik:RadNumericTextBox ShowSpinButtons="true"
                                    IncrementSettings-InterceptArrowKeys="true"
                                    IncrementSettings-InterceptMouseWheel="true" LabelWidth="" runat="server"
                                    ID="txtTotal_Payment" Width="120px" CssClass="txtContent" Culture="vi-VN"
                                    Font-Bold="True" Font-Names="Arial" Skin="Forest" AutoPostBack="True" ForeColor="#0033CC">
                                    <NumberFormat ZeroPattern="n" DecimalDigits="2" AllowRounding="False"></NumberFormat>
                                </telerik:RadNumericTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                                <asp:Label ID="Label30" runat="server" CssClass="label">Số tiền còn lại:</asp:Label>
                        </td>
                        <td align="left">

                                <telerik:RadNumericTextBox ShowSpinButtons="true"
                                    IncrementSettings-InterceptArrowKeys="true"
                                    IncrementSettings-InterceptMouseWheel="true" LabelWidth="" runat="server"
                                    ID="txtTotal_Debts" Width="120px" CssClass="txtContent" Culture="vi-VN"
                                    Font-Bold="True" Font-Names="Arial" Skin="Forest" ForeColor="Red">
                                    <NumberFormat ZeroPattern="n" DecimalDigits="2" AllowRounding="False"></NumberFormat>
                                </telerik:RadNumericTextBox>
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
                    Text="Xóa" />
                <asp:Button ID="btnReturn" runat="server" CssClass="btnbackground"
                    Text="Quay ra" />
            </div>
        </div>
    </form>
</body>
</html>
