<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AdminUrlEdit.aspx.vb" Inherits="Prjs.Portal.Report.AdminUrlEdit" %>

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
                            <asp:Label ID="Label7" runat="server" CssClass="label">Tên Menu:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtUrl_Text" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="80%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label11" runat="server" CssClass="label">Url:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtUrl_Id" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="80%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label15" runat="server" CssClass="label">Alias:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtUrl_Alias" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="80%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label13" runat="server" CssClass="label">Kênh:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListChannel_Id" runat="server" CssClass="droplist" AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label8" runat="server" CssClass="label">Loại Menu:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListTypeOfMenu" runat="server" CssClass="droplist" AutoPostBack="True">
                                <asp:ListItem Value="0">--Chọn--</asp:ListItem>
                                <asp:ListItem Value="2">Menu level 2</asp:ListItem>
                                <asp:ListItem Value="3">Menu level 3</asp:ListItem>
                                <asp:ListItem Value="4">Menu level 4</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblParent_Id" runat="server" CssClass="label">Menu cha:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListParent_Id" runat="server" CssClass="droplist">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label2" runat="server" CssClass="label">Thứ tự:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListUrl_Order" runat="server" CssClass="droplist">
                                <asp:ListItem>0</asp:ListItem>
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem>8</asp:ListItem>
                                <asp:ListItem>9</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>11</asp:ListItem>
                                <asp:ListItem>12</asp:ListItem>
                                <asp:ListItem>13</asp:ListItem>
                                <asp:ListItem>14</asp:ListItem>
                                <asp:ListItem>15</asp:ListItem>
                                <asp:ListItem>16</asp:ListItem>
                                <asp:ListItem>17</asp:ListItem>
                                <asp:ListItem>18</asp:ListItem>
                                <asp:ListItem>19</asp:ListItem>
                                <asp:ListItem>20</asp:ListItem>
                                <asp:ListItem>21</asp:ListItem>
                                <asp:ListItem>22</asp:ListItem>
                                <asp:ListItem>23</asp:ListItem>
                                <asp:ListItem>24</asp:ListItem>
                                <asp:ListItem>25</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label14" runat="server" CssClass="label">Trạng thái:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListIs_Locked" runat="server" CssClass="droplist">
                                <asp:ListItem Value="0">Active</asp:ListItem>
                                <asp:ListItem Value="1">Locked</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label12" runat="server" CssClass="label">Tùy chọn:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:CheckBox ID="CheckBoxUrl_Display" runat="server" CssClass="checkbox" Text="Hiển thị" />
                            <asp:CheckBox ID="CheckBoxUrl_Privilege" runat="server" CssClass="checkbox" Text="Menu chức năng" />
                            <asp:CheckBox ID="CheckBoxUrl_Private" runat="server" CssClass="checkbox"
                                Text="Phân quyền riêng" />
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
