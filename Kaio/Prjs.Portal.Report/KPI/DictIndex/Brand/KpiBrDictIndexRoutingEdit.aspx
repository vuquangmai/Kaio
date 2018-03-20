<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="KpiBrDictIndexRoutingEdit.aspx.vb" Inherits="Prjs.Portal.Report.KpiBrDictIndexRoutingEdit" %>

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
                            <asp:Label ID="Label31" runat="server" CssClass="label">Mã đường:</asp:Label>
                        </td>
                        <td align="left">
                                        <asp:DropDownList ID="DropDownListRouting_Id" runat="server" CssClass="droplist">
                                            <asp:ListItem Value="0">--Chọn--</asp:ListItem>
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem  Value="4">4</asp:ListItem>
                                            <asp:ListItem  Value="5">5</asp:ListItem>
                                            <asp:ListItem  Value="6">6</asp:ListItem>
                                            <asp:ListItem  Value="7">7</asp:ListItem>
                                            <asp:ListItem  Value="8">8</asp:ListItem>
                                            <asp:ListItem  Value="9">9</asp:ListItem>
                                        </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="30%">
                            <asp:Label ID="Label33" runat="server" CssClass="label">Tên đường:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtRouting_Text" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="90%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="30%">
                            <asp:Label ID="Label32" runat="server" CssClass="label">Thể loại:</asp:Label>
                        </td>
                        <td align="left">
                                        <asp:DropDownList ID="DropDownListTypeOf_Id" runat="server" CssClass="droplist">
                                            <asp:ListItem Value="0">--Chọn--</asp:ListItem>
                                            <asp:ListItem Value="1">Quảng cáo</asp:ListItem>
                                            <asp:ListItem Value="2">CSKH</asp:ListItem>
                                        </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="30%">
                            <asp:Label ID="Label18" runat="server" CssClass="label">Trạng thái:</asp:Label>
                        </td>
                        <td align="left">
                                        <asp:DropDownList ID="DropDownListStatus_Id" runat="server" CssClass="droplist">
                                            <asp:ListItem Value="0">--Chọn--</asp:ListItem>
                                            <asp:ListItem Value="1">Sử dụng</asp:ListItem>
                                            <asp:ListItem Value="2">Khóa</asp:ListItem>
                                        </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="20%">
                            <asp:Label ID="Label16" runat="server" CssClass="label">Tỷ trọng:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtPercentage" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="10%" Font-Bold="True"></asp:TextBox>
                            <asp:Label ID="lblTypeOf_Unit" runat="server" CssClass="label">%</asp:Label>
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
