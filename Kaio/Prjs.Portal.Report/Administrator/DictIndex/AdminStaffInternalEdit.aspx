<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AdminStaffInternalEdit.aspx.vb" Inherits="Prjs.Portal.Report.AdminStaffInternalEdit" %>
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
                <telerik:AjaxSetting AjaxControlID="DropDownListDept_Id">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="DropDownListCompetence" />
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
                            <asp:Label ID="Label7" runat="server" CssClass="label">Tên nhân viên:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtStaff_Text" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="50%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="20%">
                            <asp:Label ID="Label16" runat="server" CssClass="label">Mã nhân viên:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtStaff_Code" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="30%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label13" runat="server" CssClass="label">Phòng ban:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListDept_Id" runat="server" CssClass="droplist" AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label19" runat="server" CssClass="label">Chức vụ:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListCompetence" runat="server" CssClass="droplist">
                                <asp:ListItem Value="0">--Chọn--</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label17" runat="server" CssClass="label">Điện thoại:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtMobile" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="30%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label18" runat="server" CssClass="label">Địa chỉ email:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtEmail" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="50%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label14" runat="server" CssClass="label">Trạng thái:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListStatus" runat="server" CssClass="droplist">
                                <asp:ListItem Value="1">Active</asp:ListItem>
                                <asp:ListItem Value="0">Locked</asp:ListItem>
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
