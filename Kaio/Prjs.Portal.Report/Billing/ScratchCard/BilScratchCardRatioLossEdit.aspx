<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BilScratchCardRatioLossEdit.aspx.vb" Inherits="Prjs.Portal.Report.BilScratchCardRatioLossEdit" %>
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
        </telerik:RadAjaxManager>
        <div id="HQ">
            <div class="alert">
                <asp:Label ID="lbltitle" runat="server" CssClass="lbltitle"></asp:Label><br />
                <asp:Label ID="lblerror" runat="server" CssClass="lblerror"></asp:Label>
            </div>
            <div class="input" style="width: 90%">
                <table border="0" cellpadding="3" cellspacing="3" style="width: 100%">
                    <tr>
                        <td align="right" width="15%">
                            <asp:Label ID="Label7" runat="server" CssClass="label">Năm:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListYear" runat="server" CssClass="droplist" Font-Bold="False">
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
                        <td align="right"  >
                            <asp:Label ID="Label26" runat="server" CssClass="label">Tháng:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListMonth" runat="server" CssClass="droplist" Font-Bold="False">
                                <asp:ListItem Value="01">1</asp:ListItem>
                                <asp:ListItem Value="02">2</asp:ListItem>
                                <asp:ListItem Value="03">3</asp:ListItem>
                                <asp:ListItem Value="04">4</asp:ListItem>
                                <asp:ListItem Value="05">5</asp:ListItem>
                                <asp:ListItem Value="06">6</asp:ListItem>
                                <asp:ListItem Value="07">7</asp:ListItem>
                                <asp:ListItem Value="08">8</asp:ListItem>
                                <asp:ListItem Value="09">9</asp:ListItem>
                                <asp:ListItem Value="10">10</asp:ListItem>
                                <asp:ListItem Value="11">11</asp:ListItem>
                                <asp:ListItem Value="12">12</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right"  >
                            <asp:Label ID="Label16" runat="server" CssClass="label">Mạng:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListMobile_Operator" runat="server" CssClass="droplist" Font-Bold="False">
                                <asp:ListItem>--Chọn--</asp:ListItem>
                                <asp:ListItem>VIETTEL</asp:ListItem>
                                <asp:ListItem>VMS</asp:ListItem>
                                <asp:ListItem>VNP</asp:ListItem>
                                <asp:ListItem>VNM</asp:ListItem>
                                <asp:ListItem>GTEL</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right"  >
                            <asp:Label ID="Label28" runat="server" CssClass="label">Chu kỳ đối soát:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListCycle_Number" runat="server" CssClass="droplist" Font-Bold="False">
                                <asp:ListItem Value="01">1</asp:ListItem>
                                <asp:ListItem Value="02">2</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label27" runat="server" CssClass="label">Tỷ lệ thất thoát(Tỷ lệ áp lại)</asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtRatio_Percent_Loss" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="10%" Font-Bold="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label9" runat="server" CssClass="label">Ghi chú:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtDescription" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Height="60px" TextMode="MultiLine" Width="100%"></asp:TextBox>
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
