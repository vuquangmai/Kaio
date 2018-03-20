<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="VishareDictIndexUrlEdit.aspx.vb" Inherits="Prjs.Portal.Report.VishareDictIndexUrlEdit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../../Styles/HQ.css" rel="stylesheet" type="text/css" />
      
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
       
        .auto-style2 {
            height: 19px;
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
                <telerik:AjaxSetting AjaxControlID="txtUrl_Code">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="txtUrl" />
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
                <table border="0" cellpadding="2" cellspacing="1" style="width: 100%">
                    <tr>
                        <td align="right" width="20%">
                            <asp:Label ID="Label7" runat="server" CssClass="label">Đối tác:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListPartner_Id" runat="server" CssClass="droplist">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="20%">
                            <asp:Label ID="Label16" runat="server" CssClass="label">Mã Url:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtUrl_Code" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="10%" Font-Bold="True" AutoPostBack="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label18" runat="server" CssClass="label">Url:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtUrl" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="90%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label17" runat="server" CssClass="label">Tỷ lệ đối tác hưởng các gói dịch vụ:</asp:Label>
                        </td>
                        <td align="left">
                            <table class="auto-style1">
                                <tr>
                                    <td align="right" width="15%">
                            <asp:Label ID="Label26" runat="server" CssClass="label">VISHARE:</asp:Label>
                                    </td>
                                    <td  >
                            <asp:TextBox ID="txtRatio_Share_Vishare" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="60px" Font-Bold="True" MaxLength="3"></asp:TextBox>
                            <asp:Label ID="Label25" runat="server" CssClass="label">%</asp:Label>
                                    </td>
                                   
                                </tr>
                                <tr>
                                    <td align="right">
                            <asp:Label ID="Label27" runat="server" CssClass="label">CLIP:</asp:Label>
                                    </td>
                                    <td  >
                            <asp:TextBox ID="txtRatio_Share_Clip" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="60px" Font-Bold="True" MaxLength="3"></asp:TextBox>
                            <asp:Label ID="Label29" runat="server" CssClass="label">%</asp:Label>
                                    </td>
                                   
                                </tr>
                                <tr>
                                    <td align="right" class="auto-style2">
                            <asp:Label ID="Label28" runat="server" CssClass="label">ANH:</asp:Label>
                                    </td>
                                    <td class="auto-style2"  >
                            <asp:TextBox ID="txtRatio_Share_Anh" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="60px" Font-Bold="True" MaxLength="3"></asp:TextBox>
                            <asp:Label ID="Label30" runat="server" CssClass="label">%</asp:Label>
                                    </td>
                                   
                                </tr>
                            </table>
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
