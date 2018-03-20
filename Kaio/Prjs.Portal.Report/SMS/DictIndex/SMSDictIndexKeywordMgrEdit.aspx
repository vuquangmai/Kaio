<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SMSDictIndexKeywordMgrEdit.aspx.vb" Inherits="Prjs.Portal.Report.SMSDictIndexKeywordMgrEdit" %>
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
                <telerik:AjaxSetting AjaxControlID="DropDownListDepartment_Id">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="DropDownListPartner_Id" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="DropDownListRangeShortCode">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="DropDownListShortCode" />
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
                                    <asp:Label ID="Label17" runat="server" CssClass="label">Phòng ban:</asp:Label>
                        </td>
                        <td align="left">
                                    <asp:DropDownList ID="DropDownListDepartment_Id" runat="server" CssClass="droplist" AutoPostBack="True">
                                    </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="20%">
                                    <asp:Label ID="Label18" runat="server" CssClass="label">Đối tác sở hữu:</asp:Label>
                        </td>
                        <td align="left">
                                    <asp:DropDownList ID="DropDownListPartner_Id" runat="server" CssClass="droplist">
                                    </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="20%">
                                        <asp:Label ID="Label81" runat="server" CssClass="label">Dải số:</asp:Label>
                        </td>
                        <td align="left">
                                        <asp:DropDownList ID="DropDownListRangeShortCode" runat="server" CssClass="droplist" Font-Bold="False" AutoPostBack="True">
                                            <asp:ListItem>--Chọn--</asp:ListItem>
                                            <asp:ListItem>99x</asp:ListItem>
                                            <asp:ListItem>8x79</asp:ListItem>
                                            <asp:ListItem>8x99</asp:ListItem>
                                            <asp:ListItem>6x66</asp:ListItem>
                                        </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="20%">
                                        <asp:Label ID="Label27" runat="server" CssClass="label">Đầu số:</asp:Label>
                        </td>
                        <td align="left">
                                        <asp:DropDownList ID="DropDownListShortCode" runat="server" CssClass="droplist" Font-Bold="True">
                                            <asp:ListItem Value="0">--Chọn--</asp:ListItem>
                                        </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="20%">
                                        <asp:Label ID="Label82" runat="server" CssClass="label">Định tuyến:</asp:Label>
                        </td>
                        <td align="left">
                                        <asp:DropDownList ID="DropDownListRouting_Text" runat="server" CssClass="droplist" Font-Bold="False" ForeColor="#0033CC">
                                            <asp:ListItem Value="0">--Chọn--</asp:ListItem>
                                        </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="20%">
                            <asp:Label ID="Label7" runat="server" CssClass="label">Mã dịch vụ:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtKeyWord" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="50%" Font-Bold="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label13" runat="server" CssClass="label">Dịch vụ:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListCate_1" runat="server" CssClass="droplist">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label14" runat="server" CssClass="label">Trạng thái:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListStatus" runat="server" CssClass="droplist">
                                <asp:ListItem Value="1">Sử dụng</asp:ListItem>
                                <asp:ListItem Value="0">Khóa</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label9" runat="server" CssClass="label">Ghi chú:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtDescription" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Height="42px" TextMode="MultiLine" Width="100%"></asp:TextBox>
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
