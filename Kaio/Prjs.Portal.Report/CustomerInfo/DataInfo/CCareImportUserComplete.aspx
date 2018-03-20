<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CCareImportUserComplete.aspx.vb" Inherits="Prjs.Portal.Report.CCareImportUserComplete" %>
<%@ Register Assembly="FilePickerControl" Namespace="AWS.FilePicker" TagPrefix="cc2" %>
<%@ Register Assembly="ASPnetPagerV2_8" Namespace="ASPnetControls" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../../Styles/HQ.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/LightStyle.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../../Js/Menu.js"></script>

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

        .RadComboBox_Hay{font:12px "Segoe UI",Arial,sans-serif;color:#272722}.RadComboBox{vertical-align:middle;display:-moz-inline-stack;display:inline-block}
       
    .RadComboBox{text-align:left}.RadComboBox_Hay{font:12px "Segoe UI",Arial,sans-serif;color:#272722}.RadComboBox{vertical-align:middle;display:-moz-inline-stack;display:inline-block}.RadComboBox{text-align:left}.RadComboBox_Hay{font:12px "Segoe UI",Arial,sans-serif;color:#272722}.RadComboBox{vertical-align:middle;display:-moz-inline-stack;display:inline-block}.RadComboBox{text-align:left}.RadComboBox_Hay{font:12px "Segoe UI",Arial,sans-serif;color:#272722}.RadComboBox{vertical-align:middle;display:-moz-inline-stack;display:inline-block}.RadComboBox{text-align:left}.RadComboBox_Hay{font:12px "Segoe UI",Arial,sans-serif;color:#272722}.RadComboBox{vertical-align:middle;display:-moz-inline-stack;display:inline-block}.RadComboBox{text-align:left}.RadComboBox_Hay{font:12px "Segoe UI",Arial,sans-serif;color:#272722}.RadComboBox{vertical-align:middle;display:-moz-inline-stack;display:inline-block}.RadComboBox{text-align:left}.RadComboBox_Hay{font:12px "Segoe UI",Arial,sans-serif;color:#272722}.RadComboBox{vertical-align:middle;display:-moz-inline-stack;display:inline-block}.RadComboBox{text-align:left}.RadComboBox_Hay{font:12px "Segoe UI",Arial,sans-serif;color:#272722}.RadComboBox{vertical-align:middle;display:-moz-inline-stack;display:inline-block}.RadComboBox{text-align:left}.RadComboBox_Hay{font:12px "Segoe UI",Arial,sans-serif;color:#272722}.RadComboBox{vertical-align:middle;display:-moz-inline-stack;display:inline-block}.RadComboBox{text-align:left}.RadComboBox_Hay{font:12px "Segoe UI",Arial,sans-serif;color:#272722}
.RadComboBox{vertical-align:middle;display:-moz-inline-stack;display:inline-block}
 .RadComboBox{text-align:left}
.RadComboBox {
    text-align: left;
}
 .RadComboBox_Hay {
    color: #272722;
    font-family:Arial    !important;
   font-size:11px     !important;
}
.RadComboBox {
    text-align: left;
}
 .RadComboBox_Hay {
    color: #272722;
   font-family:Arial    !important;
   font-size:11px     !important;
}
.RadComboBox{text-align:left}
.RadComboBox{vertical-align:middle;display:-moz-inline-stack;display:inline-block}
    .RadComboBox_Hay{font:12px "Segoe UI",Arial,sans-serif;color:#272722}
.RadComboBox *{margin:0;padding:0}.RadComboBox *{margin:0;padding:0}
.RadComboBox *{margin:0;padding:0}.RadComboBox *{margin:0;padding:0}.RadComboBox *{margin:0;padding:0}.RadComboBox *{margin:0;padding:0}.RadComboBox *{margin:0;padding:0}.RadComboBox *{margin:0;padding:0}
.RadComboBox *{margin:0;padding:0}
 
.RadComboBox *{margin:0;padding:0}
.RadComboBox * {
    margin: 0;
    padding: 0;
}
 
.RadComboBox *{margin:0;padding:0}
 
.RadComboBox_Hay .rcbReadOnly .rcbInputCellLeft{background-position:0 0}.RadComboBox_Hay .rcbReadOnly .rcbInputCellLeft{background-position:0 0}
 
.RadComboBox_Hay .rcbReadOnly .rcbInputCellLeft{background-position:0 0}.RadComboBox_Hay .rcbReadOnly .rcbInputCellLeft{background-position:0 0}.RadComboBox_Hay .rcbReadOnly .rcbInputCellLeft{background-position:0 0}.RadComboBox_Hay .rcbReadOnly .rcbInputCellLeft{background-position:0 0}.RadComboBox_Hay .rcbReadOnly .rcbInputCellLeft{background-position:0 0}.RadComboBox_Hay .rcbReadOnly .rcbInputCellLeft{background-position:0 0}.RadComboBox_Hay .rcbReadOnly .rcbInputCellLeft{background-position:0 0}.RadComboBox_Hay .rcbReadOnly .rcbInputCellLeft{background-position:0 0}.RadComboBox_Hay .rcbReadOnly .rcbInputCellLeft{background-position:0 0}.RadComboBox_Hay .rcbInputCellLeft{background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSprite.png');_background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSpriteIE6.png')}.RadComboBox .rcbInputCellLeft{background-color:transparent;background-repeat:no-repeat}.RadComboBox_Hay .rcbInputCellLeft{background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSprite.png');_background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSpriteIE6.png')}.RadComboBox .rcbInputCellLeft{background-color:transparent;background-repeat:no-repeat}.RadComboBox_Hay .rcbInputCellLeft{background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSprite.png');_background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSpriteIE6.png')}.RadComboBox .rcbInputCellLeft{background-color:transparent;background-repeat:no-repeat}.RadComboBox_Hay .rcbInputCellLeft{background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSprite.png');_background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSpriteIE6.png')}.RadComboBox .rcbInputCellLeft{background-color:transparent;background-repeat:no-repeat}.RadComboBox_Hay .rcbInputCellLeft{background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSprite.png');_background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSpriteIE6.png')}.RadComboBox .rcbInputCellLeft{background-color:transparent;background-repeat:no-repeat}.RadComboBox_Hay .rcbInputCellLeft{background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSprite.png');_background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSpriteIE6.png')}.RadComboBox .rcbInputCellLeft{background-color:transparent;background-repeat:no-repeat}.RadComboBox_Hay .rcbInputCellLeft{background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSprite.png');_background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSpriteIE6.png')}.RadComboBox .rcbInputCellLeft{background-color:transparent;background-repeat:no-repeat}.RadComboBox_Hay .rcbInputCellLeft{background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSprite.png');_background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSpriteIE6.png')}.RadComboBox .rcbInputCellLeft{background-color:transparent;background-repeat:no-repeat}.RadComboBox_Hay .rcbInputCellLeft{background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSprite.png');_background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSpriteIE6.png')}.RadComboBox .rcbInputCellLeft{background-color:transparent;background-repeat:no-repeat}.RadComboBox_Hay .rcbInputCellLeft{background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSprite.png');_background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSpriteIE6.png')}.RadComboBox .rcbInputCellLeft{background-color:transparent;background-repeat:no-repeat}.RadComboBox .rcbInputCellLeft{background-color:transparent;background-repeat:no-repeat}.RadComboBox_Hay .rcbInputCellLeft{background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSprite.png');_background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSpriteIE6.png')}.RadComboBox_Hay .rcbArrowCellRight{background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSprite.png');_background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSpriteIE6.png')}
        .RadComboBox .rcbArrowCellRight{background-color:transparent;background-repeat:no-repeat}.RadComboBox_Hay .rcbArrowCellRight{background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSprite.png');_background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSpriteIE6.png')}.RadComboBox .rcbArrowCellRight{background-color:transparent;background-repeat:no-repeat}.RadComboBox_Hay .rcbArrowCellRight{background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSprite.png');_background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSpriteIE6.png')}.RadComboBox .rcbArrowCellRight{background-color:transparent;background-repeat:no-repeat}.RadComboBox_Hay .rcbArrowCellRight{background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSprite.png');_background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSpriteIE6.png')}.RadComboBox .rcbArrowCellRight{background-color:transparent;background-repeat:no-repeat}.RadComboBox_Hay .rcbArrowCellRight{background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSprite.png');_background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSpriteIE6.png')}.RadComboBox .rcbArrowCellRight{background-color:transparent;background-repeat:no-repeat}.RadComboBox_Hay .rcbArrowCellRight{background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSprite.png');_background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSpriteIE6.png')}.RadComboBox .rcbArrowCellRight{background-color:transparent;background-repeat:no-repeat}.RadComboBox_Hay .rcbArrowCellRight{background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSprite.png');_background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSpriteIE6.png')}.RadComboBox .rcbArrowCellRight{background-color:transparent;background-repeat:no-repeat}.RadComboBox_Hay .rcbArrowCellRight{background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSprite.png');_background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSpriteIE6.png')}.RadComboBox .rcbArrowCellRight{background-color:transparent;background-repeat:no-repeat}.RadComboBox_Hay .rcbArrowCellRight{background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSprite.png');_background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSpriteIE6.png')}.RadComboBox .rcbArrowCellRight{background-color:transparent;background-repeat:no-repeat}
    .RadComboBox_Hay .rcbArrowCellRight{background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSprite.png');_background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSpriteIE6.png')}.RadComboBox .rcbArrowCellRight{background-color:transparent;background-repeat:no-repeat}
    .RadComboBox .rcbArrowCellRight{background-color:transparent;background-repeat:no-repeat}.RadComboBox_Hay .rcbArrowCellRight{background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSprite.png');_background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSpriteIE6.png')}

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
                <telerik:AjaxSetting AjaxControlID="DropDownListPARTNER_ID_IMPORT">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="DropDownListBRAND_ID_IMPORT" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <div id="HQ">
            <div class="alert">
                <asp:Label ID="lbltitle" runat="server" CssClass="lbltitle"></asp:Label><br />
                <asp:Label ID="lblerror" runat="server" CssClass="lblerror"></asp:Label>
            </div>
           
             <fieldset id="fieldsetBound">
                       <legend>
                        <asp:Label ID="Label1" runat="server" CssClass="lblerror">Thông tin import</asp:Label></legend>
                   <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                        <tr>
                            <td align="right" width="15%">
                                <asp:Label ID="Label26" runat="server" CssClass="label">File dữ liệu:</asp:Label>
                            </td>
                            <td align="left" width="35%">
                                <cc2:FilePicker ID="txtUserFile" runat="server" CssClass="txtContent" fpAllowedUploadFileExts="" fpPopupURL="../../FilePicker/FilePicker.aspx" fpPopupWidth="600" Width="80%"></cc2:FilePicker>
                            </td>
                             
                            <td align="right" width="15%">
                                <asp:Label ID="Label57" runat="server" CssClass="label">Đối tác:</asp:Label>
                            </td>
                            <td>  <asp:DropDownList ID="DropDownListPARTNER_ID_IMPORT" runat="server" CssClass="droplist" Font-Bold="True" AutoPostBack="True">
                                </asp:DropDownList></td>
                             
                        </tr>
                        
                        <tr>
                            <td align="right" width="20%">
                                <asp:Label ID="Label27" runat="server" CssClass="label">Sheet:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtSheet" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="20%" Font-Bold="False">Sheet1</asp:TextBox>
                            </td>
                             
                            <td align="right">
                                <asp:Label ID="Label58" runat="server" CssClass="label">Brand name:</asp:Label>
                            </td>
                            <td>     <asp:DropDownList ID="DropDownListBRAND_ID_IMPORT" runat="server" CssClass="droplist">
                                    <asp:ListItem Value="0">--all--</asp:ListItem>
                                </asp:DropDownList></td>
                             
                        </tr>
                        
                        <tr>
                            <td align="right" width="20%">
                                <asp:Label ID="Label55" runat="server" CssClass="label">Nhóm:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtGROUP_TEXT_IMPORT" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="50%" Font-Bold="False"></asp:TextBox>
                            </td>
                             
                            <td align="right">
                                <asp:Label ID="Label59" runat="server" CssClass="label">Ngành hàng:</asp:Label>
                            </td>
                            <td>

                                            <telerik:RadComboBox ID="RadDropDownListFIELD_ID_IMPORT" runat="server" CheckBoxes="true"   Skin="Hay" Width="200px">
                                            </telerik:RadComboBox>

                            </td>
                             
                        </tr>
                        
                        <tr>
                            <td align="right" width="20%">
                                <asp:Label ID="Label61" runat="server" CssClass="label">Từ khóa:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtKEY_WORD_IMPORT" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="50%" Font-Bold="False"></asp:TextBox>
                            </td>
                             
                            <td align="right">
                                <asp:Label ID="Label60" runat="server" CssClass="label">Nguồn dữ liệu:</asp:Label>
                            </td>
                            <td>

                                <asp:DropDownList ID="DropDownListSOURCE_ID_IMPORT" runat="server" CssClass="droplist">
                                </asp:DropDownList>

                            </td>
                             
                        </tr>
                        
                        <tr>
                            <td align="right" width="20%">
                                <asp:Label ID="Label56" runat="server" CssClass="label">Nội dung MT:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtMT_IMPORT" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="90%" Font-Bold="False" TextMode="MultiLine"></asp:TextBox>
                            </td>
                             
                            <td align="right">&nbsp;</td>
                            <td>&nbsp;</td>
                             
                        </tr>
                        
                    </table>
                </fieldset>
                <div class="submmit">
                    <asp:Button ID="btnImport" runat="server" CssClass="btnbackground"
                        Text="Import" />
                    <asp:Button ID="btnReturn" runat="server" CssClass="btnbackground"
                        Text="Quay ra" />
                </div>
                <a href="javascript:showSubcat('1');">
                    <img id="imgCat1" src="../../Images/collapse_thead_collapsed.gif" border="0" alt="" /></a> <a class="cateGrid" href="javascript:showSubcat('1');">
                        <asp:Label ID="Label16" runat="server"  CssClass="label" ForeColor="#666666">Thông tin tìm kiếm</asp:Label>
                    </a>
            <div id="divCat1" style=" display:none ">  
               <div class="parametter" style="width: 90%;">
                <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                        <tr>
                            <td align="right" width="15%">
                                <asp:Label ID="Label43" runat="server" CssClass="label">Từ ngày:</asp:Label>
                            </td>
                            <td align="left" width="35%">
                                <table cellpadding="0" cellspacing="0" width="100%"  >
                                    <tr>
                                        <td width="120px">
                                    <telerik:RadDatePicker ID="RadFromDate" rMinDate="2006/01/01" runat="server"
                                        ZIndex="30001" Culture="vi-VN" Skin="Forest" Width="125px">
                                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"
                                            Skin="Forest">
                                        </Calendar>

                                        <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

                                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                    </telerik:RadDatePicker>
                                        </td>
                                        <td align="center" width="50px">
                                <asp:Label ID="Label44" runat="server" CssClass="label">đến ngày:</asp:Label>
                                        </td>
                                        <td>
                                    <telerik:RadDatePicker ID="RadToDate" rMinDate="2006/01/01" runat="server"
                                        ZIndex="30001" Culture="vi-VN" Skin="Forest" Width="125px">
                                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"
                                            Skin="Forest">
                                        </Calendar>

                                        <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

                                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                    </telerik:RadDatePicker>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="15%" align="right">
                                <asp:Label ID="Label37" runat="server" CssClass="label">Mạng:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DropDownListMOBILE_OPERATOR" runat="server" CssClass="droplist">
                                    <asp:ListItem Value="--all--">--all--</asp:ListItem>
                                    <asp:ListItem>VIETTEL</asp:ListItem>
                                    <asp:ListItem>VMS</asp:ListItem>
                                    <asp:ListItem>VNM</asp:ListItem>
                                    <asp:ListItem>VNP</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                <asp:Label ID="Label45" runat="server" CssClass="label">Loại thời gian:</asp:Label>
                            </td>
                            <td align="left" width="35%">
                                <asp:DropDownList ID="DropDownListTypeOfTime" runat="server" CssClass="droplist" Font-Bold="False">
                                    <asp:ListItem Value="CREATE_TIME">Khởi tạo</asp:ListItem>
                                    <asp:ListItem Value="UPDATE_TIME">Cập nhật</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td width="15%" align="right">
                                <asp:Label ID="Label2" runat="server" CssClass="label">Số điện thoại:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtUSER_ID" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="50%" Font-Bold="True" ForeColor="#0033CC"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                <asp:Label ID="Label6" runat="server" CssClass="label">Đối tác:</asp:Label>
                            </td>
                            <td align="left" width="35%">
                                <asp:DropDownList ID="DropDownListPARTNER_ID" runat="server" CssClass="droplist" Font-Bold="True" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                            <td width="15%" align="right">
                                <asp:Label ID="Label30" runat="server" CssClass="label">Họ tên:</asp:Label>
                            </td>
                            <td align="left">

                                <table cellpadding="0" cellspacing="0" class="auto-style1">
                                    <tr>
                                        <td>

                                <asp:TextBox ID="txtCUSTOMER_NAME" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="80%" Font-Bold="False"></asp:TextBox>

                                        </td>
                                        <td width="20%">
                                            <asp:CheckBox ID="CheckBoxCUSTOMER_NAME" runat="server" CssClass="checkbox" Text="Tương đối" />
                                        </td>
                                    </tr>
                                </table>

                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                <asp:Label ID="Label3" runat="server" CssClass="label">Brand name:</asp:Label>
                            </td>
                            <td align="left" width="35%">
                                <table cellpadding="0"  cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                <asp:DropDownList ID="DropDownListBRAND_NAME" runat="server" CssClass="droplist">
                                    <asp:ListItem Value="0">--all--</asp:ListItem>
                                </asp:DropDownList>
                                        </td>
                                        <td width="20%">
                                            <asp:CheckBox ID="CheckBoxBRAND_NAME" runat="server" CssClass="checkbox" Text="Tương đối" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="15%" align="right">
                                <asp:Label ID="Label8" runat="server" CssClass="label">Giới tính:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DropDownListSEX" runat="server" CssClass="droplist">
                                    <asp:ListItem Value="-1">--all--</asp:ListItem>
                                    <asp:ListItem Value="1">Nam</asp:ListItem>
                                    <asp:ListItem Value="2">Nữ</asp:ListItem>
                                    <asp:ListItem Value="0">Chưa xác định</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                <asp:Label ID="Label29" runat="server" CssClass="label">Nội dung MT:</asp:Label>
                            </td>
                            <td align="left" width="35%">
                               <table cellpadding="0"  cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                <asp:TextBox ID="txtMT" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="98%" Font-Bold="False" Height="58px" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                        <td width="20%">
                                            <asp:CheckBox ID="CheckBoxMT" runat="server" CssClass="checkbox" Text="Tương đối" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="15%" align="right">
                                <asp:Label ID="Label52" runat="server" CssClass="label">Tuổi từ:</asp:Label>
                            </td>
                            <td align="left">
                               <table cellpadding="0"  cellspacing="0" width="100%">
                                    <tr>
                                        <td width="50px">
                                <asp:TextBox ID="txtFromYear" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="50px" Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td align="center" width="10%">
                                <asp:Label ID="Label53" runat="server" CssClass="label">đến</asp:Label>
                                        </td>
                                        <td>
                                <asp:TextBox ID="txtToYear" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="50px" Font-Bold="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                <asp:Label ID="Label4" runat="server" CssClass="label">Từ khóa:</asp:Label>
                            </td>
                            <td align="left" width="35%">
                               <table cellpadding="0"  cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                <asp:TextBox ID="txtKEY_WORD" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="98%" Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td width="20%">
                                            <asp:CheckBox ID="CheckBoxKEY_WORD" runat="server" CssClass="checkbox" Text="Tương đối" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="15%" align="right">
                                <asp:Label ID="Label5" runat="server" CssClass="label">Tỉnh/Thành:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DropDownListPROVINCE_ID" runat="server" CssClass="droplist">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                <asp:Label ID="Label46" runat="server" CssClass="label">Mã nhóm:</asp:Label>
                            </td>
                            <td align="left" width="35%">
                                <table cellpadding="0"  cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                <asp:TextBox ID="txtGROUP_TEXT" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="98%" Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td width="20%">
                                            <asp:CheckBox ID="CheckBoxGROUP_TEXT" runat="server" CssClass="checkbox" Text="Tương đối" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="15%" align="right">
                                <asp:Label ID="Label31" runat="server" CssClass="label">Địa chỉ:</asp:Label>
                            </td>
                            <td align="left">

                                <table cellpadding="0"  cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                <asp:TextBox ID="txtADDRESS" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="98%" Font-Bold="False"></asp:TextBox>
                                        </td>
                                        <td width="20%">
                                            <asp:CheckBox ID="CheckBoxADDRESS" runat="server" CssClass="checkbox" Text="Tương đối" />
                                        </td>
                                    </tr>
                                </table>

                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                <asp:Label ID="Label7" runat="server" CssClass="label">Nguồn dữ liệu:</asp:Label>
                            </td>
                            <td align="left" width="35%">

                                <asp:DropDownList ID="DropDownListSOURCE_ID" runat="server" CssClass="droplist">
                                </asp:DropDownList>

                            </td>
                            <td width="15%" align="right">
                                <asp:Label ID="Label32" runat="server" CssClass="label">Email:</asp:Label>
                            </td>
                            <td align="left">

                          
                                <asp:TextBox ID="txtEMAIL_ADDRESS" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="50%" Font-Bold="False"></asp:TextBox>

                          
                            </td>
                        </tr>
                        <tr>
                            <td align="right"  >
                                <asp:Label ID="Label47" runat="server" CssClass="label">Trạng thái:</asp:Label>
                            </td>
                            <td align="left"  >
                                <asp:DropDownList ID="DropDownListSTATUS_ID" runat="server" CssClass="droplist">
                                    <asp:ListItem Value="0">--all--</asp:ListItem>
                                    <asp:ListItem Value="1">New</asp:ListItem>
                                    <asp:ListItem Value="2">Call</asp:ListItem>
                                    <asp:ListItem Value="3">Invalid</asp:ListItem>
                                    <asp:ListItem Value="4">Done</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="right"  >
                                <asp:Label ID="Label33" runat="server" CssClass="label">Mức cước:</asp:Label>
                            </td>
                            <td align="left"  >
                                <asp:DropDownList ID="DropDownListFEES_ID" runat="server" CssClass="droplist">
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td align="right"  >
                                <asp:Label ID="Label48" runat="server" CssClass="label">Lần lặp:</asp:Label>
                            </td>
                            <td align="left"  >
                               <table cellpadding="0"  cellspacing="0" width="100%">
                                    <tr>
                                        <td width="10%">
                                <asp:DropDownList ID="DropDownListDUPLICATE_NUMBER" runat="server" CssClass="droplist">
                                    <asp:ListItem>&gt;=</asp:ListItem>
                                    <asp:ListItem>=</asp:ListItem>
                                    <asp:ListItem>&lt;=</asp:ListItem>
                                </asp:DropDownList>
                                        </td>
                                        <td>
                                <asp:TextBox ID="txtDUPLICATE_NUMBER" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="20%" Font-Bold="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td align="right"  >
                                <asp:Label ID="Label34" runat="server" CssClass="label">Mức thu nhập:</asp:Label>
                            </td>
                            <td align="left" >
                                <asp:DropDownList ID="DropDownListINCOME_ID" runat="server" CssClass="droplist">
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td align="right"  >
                                <asp:Label ID="Label49" runat="server" CssClass="label">Độ chính xác:</asp:Label>
                            </td>
                            <td align="left"  >
                                <table cellpadding="0"  cellspacing="0" width="100%">
                                    <tr>
                                        <td width="10%">
                                <asp:DropDownList ID="DropDownListEXACTLY_RATE" runat="server" CssClass="droplist">
                                    <asp:ListItem>&gt;=</asp:ListItem>
                                    <asp:ListItem>=</asp:ListItem>
                                    <asp:ListItem>&lt;=</asp:ListItem>
                                </asp:DropDownList>
                                        </td>
                                        <td>
                                <asp:DropDownList ID="DropDownListEXACTLY_RATE_NUMBER" runat="server" CssClass="droplist">
                                </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td align="right"  >
                                <asp:Label ID="Label36" runat="server" CssClass="label">Mã khách hàng:</asp:Label>
                            </td>
                            <td align="left"  >
                                <asp:TextBox ID="txtCUSTOMER_CODE" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="50%" Font-Bold="False"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td align="right"  >
                                <asp:Label ID="Label50" runat="server" CssClass="label">Top:</asp:Label>
                            </td>
                            <td align="left"  >

                                <asp:TextBox ID="txtTOP" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="20%" Font-Bold="True"></asp:TextBox>

                            </td>
                            <td align="right"  >
                                <asp:Label ID="Label28" runat="server" CssClass="label">Ghi chú:</asp:Label>
                            </td>
                            <td align="left"  >
                                <table cellpadding="0" cellspacing="0" class="auto-style1">
                                    <tr>
                                        <td>
                                <asp:TextBox ID="txtREMARK" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="98%" Font-Bold="False" TextMode="MultiLine" Height="48px"></asp:TextBox>
                                        </td>
                                        <td width="20%">
                                            <asp:CheckBox ID="CheckBoxREMARK" runat="server" CssClass="checkbox" Text="Tương đối" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>

                        <tr>
                            <td align="right"  >
                                <asp:Label ID="Label9" runat="server" CssClass="label">Ngành hàng:</asp:Label>
                            </td>
                            <td align="left"  >

                                <asp:CheckBoxList ID="CheckBoxListFIELD_ID" runat="server" CssClass="checkbox" RepeatColumns="3">
                                </asp:CheckBoxList>

                            </td>
                            <td align="right"  >
                                <asp:Label ID="Label51" runat="server" CssClass="label">Sắp xếp:</asp:Label>
                            </td>
                            <td align="left"  >
                                <table cellpadding="0" cellspacing="0" class="auto-style1">
                                    <tr>
                                        <td width="30%">
                                <asp:DropDownList ID="DropDownListOrderField" runat="server" CssClass="droplist">
                                    <asp:ListItem>--Chọn--</asp:ListItem>
                                    <asp:ListItem>Độ chính xác</asp:ListItem>
                                    <asp:ListItem Value="DUPLICATE_NUMBER">Số lần lặp</asp:ListItem>
                                    <asp:ListItem Value="CREATE_TIME">Khởi tạo</asp:ListItem>
                                </asp:DropDownList>
                                        </td>
                                        <td>
                                <asp:DropDownList ID="DropDownListOrder" runat="server" CssClass="droplist">
                                    <asp:ListItem Value="ASC">Tăng dần</asp:ListItem>
                                    <asp:ListItem Value="DESC">Giảm dần</asp:ListItem>
                                </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>

                        <tr>
                            <td align="right"  >
                                &nbsp;</td>
                            <td align="left"  >

                                &nbsp;</td>
                            <td align="right"  >
                                <asp:Label ID="Label54" runat="server" CssClass="label">Tổng số:</asp:Label>
                            </td>
                            <td align="left"  >
                                <a class="cateGrid" href="javascript:showSubcat('3');">
                                <asp:Label ID="lblTotal" runat="server"   CssClass="label" ForeColor="red"> </asp:Label></a>
                            </td>
                        </tr>

                        </table>
                     <div class="submmit" style="background-color: #E1EDD4">
                    <asp:Button ID="btnSearch" runat="server" CssClass="btnbackground"
                        Text="Tìm kiếm" />
                    <asp:Button ID="btnExport" runat="server" CssClass="btnbackground"
                        Text="Báo cáo" />
                    <asp:Button ID="btnAdd" runat="server" CssClass="btnbackground"
                        Text="Thêm" />
                </div>
            </div>
                 </div>
          
            <div class="pager">
              <cc1:PagerV2_8 ID="pager1" runat="server" OnCommand="pager_Command" GenerateGoToSection="true"
                Font-Size="10pt" PageSize="50" />
               
        </div>
            <div class="datagrid">
                <asp:DataGrid ID="DataGrid" runat="server" AllowPaging="True" AutoGenerateColumns="false"
                    CellPadding="0" CssClass="datagrid" EnableViewState="False" GridLines="None"
                    PagerStyle-Mode="NextPrev" PagerStyle-Visible="true" Width="100%" PageSize="50">
                    <HeaderStyle CssClass="datagridHeader" />
                    <AlternatingItemStyle CssClass="datagridAlternatingItemStyle" />
                    <ItemStyle CssClass="datagridItemStyle" />
                    <Columns>
                        <asp:TemplateColumn>
                            <HeaderStyle HorizontalAlign="Center" Width="2%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderTemplate>
                                #
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblOrder" runat="server" CssClass="label"
                                    Text='<%# Container.ItemIndex+1 %>'>
                                </asp:Label>
                            </ItemTemplate>

                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="ĐIỆN THOẠI">
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblUSER_ID" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "USER_ID")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                              <asp:TemplateColumn HeaderText="MẠNG">
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblMOBILE_OPERATOR" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "MOBILE_OPERATOR")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="MÃ KHÁCH HÀNG">
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblPARTNER_TEXT" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "ID")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="HỌ TÊN">
                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                            <ItemTemplate>
                                <asp:Label ID="lblCUSTOMER_NAME" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "CUSTOMER_NAME")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                              <asp:TemplateColumn HeaderText="TỈNH THÀNH">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <asp:Label ID="lblPROVINCE_TEXT" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "PROVINCE_TEXT")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="ĐỘ CHÍNH XÁC">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <asp:Label ID="lblEXACTLY_RATE" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "EXACTLY_RATE")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                      
                        <asp:TemplateColumn HeaderText="CẬP NHẬT">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                
                                <asp:Label ID="lblUPDATE_TIME" runat="server" CssClass="label"><%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "UPDATE_TIME")).ToString("dd-MM-yyyy")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                          <asp:TemplateColumn HeaderText="GHI CHÚ">
                            <ItemStyle HorizontalAlign="Left" Width="20%" />
                            <ItemTemplate>
                                <asp:Label ID="lblREMARK" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "REMARK")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn>
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderTemplate>
                                SỬA
                            </HeaderTemplate>
                            <ItemTemplate>
                                <a class="datagridLinks" title="Sửa đổi" href='CCareCustomerInfoEdit.aspx?objid=<%# Utils.EncryptText(DataBinder.Eval(Container.DataItem, "ID")) %>'>
                                    <img border="0" src="/images/comment-edit-icon.png">
                                </a>
                            </ItemTemplate>

                        </asp:TemplateColumn>
                    
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" NextPageText="" PageButtonCount="5" PrevPageText=""
                        Visible="False" />
                </asp:DataGrid>

            </div>
           
            </div>
    </form>
</body>
</html>
