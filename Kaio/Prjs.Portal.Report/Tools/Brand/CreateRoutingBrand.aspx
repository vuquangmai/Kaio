<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CreateRoutingBrand.aspx.vb" Inherits="Prjs.Portal.Report.CreateRoutingBrand"  ValidateRequest="false" %>
<%@ Register Assembly="FilePickerControl" Namespace="AWS.FilePicker" TagPrefix="cc2" %>
<%@ Register Assembly="ASPnetPagerV2_8" Namespace="ASPnetControls" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../../Styles/HQ.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/LightStyle.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        fieldset
        {
            display: block;
            border: 1px solid #BCDDAF;
            -moz-border-radius: 8px;
            -webkit-border-radius: 8px;
            border-radius: 8px;
        }

        legend
        {
            background: #FF9;
            border: solid 1px green;
            -webkit-border-radius: 8px;
            -moz-border-radius: 8px;
            border-radius: 8px;
        }

        .auto-style3
        {
            height: 17px;
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
                <telerik:AjaxSetting AjaxControlID="DropDownListMobile_Operator">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="DropDownListAccount_MT" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <div id="HQ">
            <div class="alert">
                <asp:Label ID="lbltitle" runat="server" CssClass="lbltitle"></asp:Label><br />
                <asp:Label ID="lblerror" runat="server" CssClass="lblerror"></asp:Label>
            </div>
            <div class="input" style="border-width: 0px; width: 80%;" >
                   <fieldset id="fieldsetBound">
                       <legend>
                        <asp:Label ID="Label1" runat="server" CssClass="lblerror">Thông tin import</asp:Label></legend>
                   <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                        <tr>
                            <td align="right" width="35%">
                                <asp:Label ID="Label26" runat="server" CssClass="label">File brand:</asp:Label>
                            </td>
                            <td align="left">
                                <cc2:FilePicker ID="txtUserFile" runat="server" CssClass="txtContent" fpAllowedUploadFileExts="" fpPopupURL="../../FilePicker/FilePicker.aspx" fpPopupWidth="600" Width="80%"></cc2:FilePicker>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="35%">
                                <asp:Label ID="Label45" runat="server" CssClass="label">Sheet:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtSheet" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="20%" Font-Bold="False">Sheet1</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="35%">
                                &nbsp;</td>
                            <td align="left">
                                <asp:Label ID="Label46" runat="server" CssClass="label" Font-Italic="True" ForeColor="#FF3300">(Lưu ý: Hệ thống đọc từ row thứ 2 trở đi của file)</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="35%">
                                <asp:Label ID="Label47" runat="server" CssClass="label">Danh sách brand:</asp:Label>
                            </td>
                            <td align="left">

                                <asp:TextBox ID="txtImport" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="30%" Font-Bold="False" Height="200px" TextMode="MultiLine"></asp:TextBox>

                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label6" runat="server" CssClass="label">Mạng:</asp:Label>
                            </td>
                            <td align="left"  >
                                <asp:DropDownList ID="DropDownListMobile_Operator" runat="server" CssClass="droplist" Font-Bold="True" AutoPostBack="True">
                                    <asp:ListItem>--Chọn--</asp:ListItem>
                                    <asp:ListItem>VMS</asp:ListItem>
                                    <asp:ListItem>VIETTEL</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="auto-style3">
                                <asp:Label ID="Label3" runat="server" CssClass="label">Account:</asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                <asp:DropDownList ID="DropDownListAccount_MT" runat="server" CssClass="droplist">
                                    <asp:ListItem>--Chọn--</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td align="right" class="auto-style3">
                                &nbsp;</td>
                            <td align="left" class="auto-style3">
                                <asp:Label ID="lblFileDownload" runat="server" CssClass="label"></asp:Label>
                            </td>
                        </tr>

                        </table>
                </fieldset>
                <div class="submmit">
                    <asp:Button ID="btnUpdate" runat="server" CssClass="btnbackground"
                        Text="Import" />
                    <asp:Button ID="btnExport" runat="server" CssClass="btnbackground"
                        Text="Xóa" />
                </div>
                <fieldset id="fieldset2">
                    <legend>
                        <asp:Label ID="Label9" runat="server" CssClass="lblerror">Dữ liệu đã import</asp:Label></legend>
                    <div class="pager">

                                <asp:TextBox ID="txtResult" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="100%" Font-Bold="False" Height="500px" TextMode="MultiLine" ReadOnly="True"></asp:TextBox>

                    </div>
                    <div class="datagrid">

                    </div>
                </fieldset>
            </div>
            </div>
    </form>
</body>
</html>
