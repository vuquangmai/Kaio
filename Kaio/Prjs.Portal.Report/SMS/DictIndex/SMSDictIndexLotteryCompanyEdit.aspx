﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SMSDictIndexLotteryCompanyEdit.aspx.vb" Inherits="Prjs.Portal.Report.SMSDictIndexLotteryCompanyEdit" %>
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
                <telerik:AjaxSetting AjaxControlID="DropDownListChannel_Id">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="DropDownListParent_Id" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="DropDownListTypeOfMenu">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="lblParent_Id" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListParent_Id" />
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
                        <td align="right" width="20%">
                            <asp:Label ID="Label17" runat="server" CssClass="label">Tên công ty xổ số:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtCompany_Id" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="80%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label13" runat="server" CssClass="label">Miền:</asp:Label>
                        </td>
                        <td align="left" >
                            <asp:DropDownList ID="DropDownListRegion_Id" runat="server" CssClass="droplist">
                                <asp:ListItem Value="0">--Chọn--</asp:ListItem>
                                <asp:ListItem Value="1">Miền Bắc</asp:ListItem>
                                <asp:ListItem Value="2">Miền Trung</asp:ListItem>
                                <asp:ListItem Value="3">Miền Nam</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label14" runat="server" CssClass="label">Ngày mở thưởng:</asp:Label>
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
                <asp:Button ID="btnResetPassWord" runat="server" CssClass="btnbackground"
                    Text="Đổi mật khẩu" />
                <asp:Button ID="btnReturn" runat="server" CssClass="btnbackground"
                    Text="Quay ra" />
            </div>
        </div>
    </form>
</body>
</html>