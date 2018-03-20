<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MobileTrafficOnlineMO.aspx.vb" Inherits="Prjs.Portal.Report.MobileTrafficOnlineMO" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="ASPnetPagerV2_8" Namespace="ASPnetControls" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../../../Styles/HQ.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/LightStyle.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        function CancelService(vId)
        { window.open("http://vigame.com.vn/cancel.aspx?msisdn=" + vId, "Cancel", "location=no,directories=no,left=100,top=0,height=300,width=700,status=no,scrollbars=yes,toolbars=no,menubar=no,resizable=yes"); }

</script>
    <style type="text/css">
.RadComboBox_Hay{font:12px "Segoe UI",Arial,sans-serif;color:#272722}.RadComboBox{vertical-align:middle;display:-moz-inline-stack;display:inline-block}.RadComboBox{text-align:left}.RadComboBox_Hay{font:12px "Segoe UI",Arial,sans-serif;color:#272722}.RadComboBox{vertical-align:middle;display:-moz-inline-stack;display:inline-block}.RadComboBox{text-align:left}.RadComboBox_Hay{font:12px "Segoe UI",Arial,sans-serif;color:#272722}.RadComboBox{vertical-align:middle;display:-moz-inline-stack;display:inline-block}.RadComboBox{text-align:left}.RadComboBox_Hay{font:12px "Segoe UI",Arial,sans-serif;color:#272722}.RadComboBox{vertical-align:middle;display:-moz-inline-stack;display:inline-block}.RadComboBox{text-align:left}.RadComboBox_Hay{font:12px "Segoe UI",Arial,sans-serif;color:#272722}.RadComboBox{vertical-align:middle;display:-moz-inline-stack;display:inline-block}.RadComboBox{text-align:left}.RadComboBox_Hay{font:12px "Segoe UI",Arial,sans-serif;color:#272722}.RadComboBox{vertical-align:middle;display:-moz-inline-stack;display:inline-block}.RadComboBox{text-align:left}.RadComboBox_Hay{font:12px "Segoe UI",Arial,sans-serif;color:#272722}.RadComboBox{vertical-align:middle;display:-moz-inline-stack;display:inline-block}.RadComboBox{text-align:left}.RadComboBox_Hay{font:12px "Segoe UI",Arial,sans-serif;color:#272722}.RadComboBox{vertical-align:middle;display:-moz-inline-stack;display:inline-block}.RadComboBox{text-align:left}.RadComboBox_Hay{font:12px "Segoe UI",Arial,sans-serif;color:#272722}.RadComboBox{vertical-align:middle;display:-moz-inline-stack;display:inline-block}.RadComboBox{text-align:left}.RadComboBox_Hay{font:12px "Segoe UI",Arial,sans-serif;color:#272722}.RadComboBox{vertical-align:middle;display:-moz-inline-stack;display:inline-block}.RadComboBox{text-align:left}
.RadComboBox, .RadComboBox .rcbInput, .RadComboBoxDropDown {
    text-align: left;
}
 .RadComboBox_Hay, .RadComboBox_Hay .rcbInput, .RadComboBoxDropDown_Hay {
    color: #272722;
    font-family:Arial    !important;
   font-size:11px     !important;
}
.RadComboBox, .RadComboBox .rcbInput, .RadComboBoxDropDown {
    text-align: left;
}
.RadComboBox_Hay, .RadComboBox_Hay .rcbInput, .RadComboBoxDropDown_Hay {
    color: #272722;
   font-family:Arial    !important;
   font-size:11px     !important;
}
.RadComboBox *{margin:0;padding:0}.RadComboBox *{margin:0;padding:0}.RadComboBox *{margin:0;padding:0}.RadComboBox *{margin:0;padding:0}.RadComboBox *{margin:0;padding:0}.RadComboBox *{margin:0;padding:0}.RadComboBox *{margin:0;padding:0}.RadComboBox *{margin:0;padding:0}.RadComboBox *{margin:0;padding:0}.RadComboBox *{margin:0;padding:0}
.RadComboBox * {
    margin: 0;
    padding: 0;
}
 
.RadComboBox_Hay .rcbReadOnly .rcbInputCellLeft{background-position:0 0}.RadComboBox_Hay .rcbReadOnly .rcbInputCellLeft{background-position:0 0}.RadComboBox_Hay .rcbReadOnly .rcbInputCellLeft{background-position:0 0}.RadComboBox_Hay .rcbReadOnly .rcbInputCellLeft{background-position:0 0}.RadComboBox_Hay .rcbReadOnly .rcbInputCellLeft{background-position:0 0}.RadComboBox_Hay .rcbReadOnly .rcbInputCellLeft{background-position:0 0}.RadComboBox_Hay .rcbReadOnly .rcbInputCellLeft{background-position:0 0}.RadComboBox_Hay .rcbReadOnly .rcbInputCellLeft{background-position:0 0}.RadComboBox_Hay .rcbReadOnly .rcbInputCellLeft{background-position:0 0}.RadComboBox_Hay .rcbReadOnly .rcbInputCellLeft{background-position:0 0}.RadComboBox_Hay .rcbInputCellLeft{background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSprite.png');_background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSpriteIE6.png')}.RadComboBox .rcbInputCellLeft{background-color:transparent;background-repeat:no-repeat}.RadComboBox_Hay .rcbInputCellLeft{background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSprite.png');_background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSpriteIE6.png')}.RadComboBox .rcbInputCellLeft{background-color:transparent;background-repeat:no-repeat}.RadComboBox_Hay .rcbInputCellLeft{background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSprite.png');_background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSpriteIE6.png')}.RadComboBox .rcbInputCellLeft{background-color:transparent;background-repeat:no-repeat}.RadComboBox_Hay .rcbInputCellLeft{background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSprite.png');_background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSpriteIE6.png')}.RadComboBox .rcbInputCellLeft{background-color:transparent;background-repeat:no-repeat}.RadComboBox_Hay .rcbInputCellLeft{background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSprite.png');_background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSpriteIE6.png')}.RadComboBox .rcbInputCellLeft{background-color:transparent;background-repeat:no-repeat}.RadComboBox_Hay .rcbInputCellLeft{background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSprite.png');_background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSpriteIE6.png')}.RadComboBox .rcbInputCellLeft{background-color:transparent;background-repeat:no-repeat}.RadComboBox_Hay .rcbInputCellLeft{background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSprite.png');_background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSpriteIE6.png')}.RadComboBox .rcbInputCellLeft{background-color:transparent;background-repeat:no-repeat}.RadComboBox_Hay .rcbInputCellLeft{background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSprite.png');_background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSpriteIE6.png')}.RadComboBox .rcbInputCellLeft{background-color:transparent;background-repeat:no-repeat}.RadComboBox_Hay .rcbInputCellLeft{background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSprite.png');_background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSpriteIE6.png')}.RadComboBox .rcbInputCellLeft{background-color:transparent;background-repeat:no-repeat}.RadComboBox_Hay .rcbInputCellLeft{background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSprite.png');_background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSpriteIE6.png')}.RadComboBox .rcbInputCellLeft{background-color:transparent;background-repeat:no-repeat}.RadComboBox_Hay .rcbArrowCellRight{background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSprite.png');_background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSpriteIE6.png')}.RadComboBox .rcbArrowCellRight{background-color:transparent;background-repeat:no-repeat}.RadComboBox_Hay .rcbArrowCellRight{background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSprite.png');_background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSpriteIE6.png')}.RadComboBox .rcbArrowCellRight{background-color:transparent;background-repeat:no-repeat}.RadComboBox_Hay .rcbArrowCellRight{background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSprite.png');_background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSpriteIE6.png')}.RadComboBox .rcbArrowCellRight{background-color:transparent;background-repeat:no-repeat}.RadComboBox_Hay .rcbArrowCellRight{background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSprite.png');_background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSpriteIE6.png')}.RadComboBox .rcbArrowCellRight{background-color:transparent;background-repeat:no-repeat}.RadComboBox_Hay .rcbArrowCellRight{background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSprite.png');_background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSpriteIE6.png')}.RadComboBox .rcbArrowCellRight{background-color:transparent;background-repeat:no-repeat}.RadComboBox_Hay .rcbArrowCellRight{background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSprite.png');_background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSpriteIE6.png')}.RadComboBox .rcbArrowCellRight{background-color:transparent;background-repeat:no-repeat}.RadComboBox_Hay .rcbArrowCellRight{background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSprite.png');_background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSpriteIE6.png')}.RadComboBox .rcbArrowCellRight{background-color:transparent;background-repeat:no-repeat}.RadComboBox_Hay .rcbArrowCellRight{background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSprite.png');_background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSpriteIE6.png')}.RadComboBox .rcbArrowCellRight{background-color:transparent;background-repeat:no-repeat}.RadComboBox_Hay .rcbArrowCellRight{background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSprite.png');_background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSpriteIE6.png')}.RadComboBox .rcbArrowCellRight{background-color:transparent;background-repeat:no-repeat}.RadComboBox_Hay .rcbArrowCellRight{background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSprite.png');_background-image:url('mvwres://Telerik.Web.UI.Skins, Version=2012.2.731.35, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Hay.ComboBox.rcbSpriteIE6.png')}.RadComboBox .rcbArrowCellRight{background-color:transparent;background-repeat:no-repeat}</style>
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
                <asp:Label ID="lblTitle" runat="server" CssClass="lbltitle"></asp:Label><br />
                <asp:Label ID="lblerror" runat="server" CssClass="lblerror"></asp:Label>
            </div>
            <div class="parametter" style="width: 70%">
                 <table width="100%">
                            <tr>
                                <td align="right" width="15%">
                                    <asp:Label ID="lblTrang7" runat="server" CssClass="label">Năm:</asp:Label>
                                </td>
                                <td align="left" width="35%">
                                    <asp:DropDownList ID="DropDownListYear" runat="server" CssClass="droplist">
                                        <asp:ListItem>2009</asp:ListItem>
                                        <asp:ListItem>2010</asp:ListItem>
                                        <asp:ListItem>2011</asp:ListItem>
                                        <asp:ListItem>2012</asp:ListItem>
                                        <asp:ListItem>2013</asp:ListItem>
                                        <asp:ListItem>2014</asp:ListItem>
                                        <asp:ListItem>2015</asp:ListItem>
                                        <asp:ListItem>2016</asp:ListItem>
                                        <asp:ListItem>2017</asp:ListItem>
                                        <asp:ListItem>2018</asp:ListItem>
                                        <asp:ListItem>2019</asp:ListItem>
                                        <asp:ListItem>2020</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td align="right" width="15%">
                                    <asp:Label ID="lblTrang12" runat="server" CssClass="label">Trạng thái:</asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="DropDownListStatus" runat="server" CssClass="droplist">
                                        <asp:ListItem Value="-1">--all--</asp:ListItem>
                                        <asp:ListItem Value="0">Thành công</asp:ListItem>
                                        <asp:ListItem Value="1">Lỗi</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right"  >
                                    <asp:Label ID="lblTrang8" runat="server" CssClass="label">Tháng:</asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="DropDownListMonth" runat="server" CssClass="droplist" AutoPostBack="True">
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
                                    </asp:DropDownList>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblTrang17" runat="server" CssClass="label">Mạng:</asp:Label>
                                </td>
                                <td align="left">
                                            <telerik:RadComboBox ID="RadDropDownListMobileOperator" runat="server" CheckBoxes="true" EnableCheckAllItemsCheckBox="True" Skin="Hay" Width="90px">
                                                <Items>
                                                    <telerik:RadComboBoxItem Text="VIETTEL" Value="VIETTEL" />
                                                    <telerik:RadComboBoxItem Text="VMS" Value="VMS" />
                                                    <telerik:RadComboBoxItem Text="VNP" Value="VNP" />
                                                    <telerik:RadComboBoxItem Text="VNM" Value="VNM" />
                                                    <telerik:RadComboBoxItem Text="GTEL" Value="GTEL" />
                                                </Items>
                                                <Localization AllItemsCheckedString="--all--" CheckAllString="--all--" />
                                            </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right"  >
                                    <asp:Label ID="lblTrang9" runat="server" CssClass="label">Từ ngày:</asp:Label>
                                </td>
                                <td align="left"  >
                                    <table cellpadding="0" cellspacing="0" class="style1">
                                        <tr>
                                            <td width="20px">
                                                <asp:DropDownList ID="DropDownListFromDate" runat="server" CssClass="droplist">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="center" width="20px">
                                                <asp:Label ID="lblTrang10" runat="server" CssClass="label">lúc:</asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownListFromHour" runat="server" CssClass="droplist">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label2" runat="server" CssClass="label">giờ</asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownListFromMinute" runat="server" CssClass="droplist">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label4" runat="server" CssClass="label">phút</asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblTrang18" runat="server" CssClass="label">Dải số:</asp:Label>
                                </td>
                                <td align="left">
                                            <telerik:RadComboBox ID="RadDropDownListRangOfShortCode" runat="server" CheckBoxes="true" EnableCheckAllItemsCheckBox="True" Skin="Hay" Width="90px" AutoPostBack="True">
                                                <Localization AllItemsCheckedString="--all--" CheckAllString="--all--" />
                                            </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblTrang11" runat="server" CssClass="label">Đến ngày:</asp:Label>
                                </td>
                                <td align="left">
                                    <table cellpadding="0" cellspacing="0" class="style1">
                                        <tr>
                                            <td width="20px">
                                                <asp:DropDownList ID="DropDownListToDate" runat="server" CssClass="droplist">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="center" width="20px">
                                                <asp:Label ID="Label1" runat="server" CssClass="label">lúc:</asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownListToHour" runat="server" CssClass="droplist">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label3" runat="server" CssClass="label">giờ</asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownListToMinute" runat="server" CssClass="droplist">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label5" runat="server" CssClass="label">phút</asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblTrang19" runat="server" CssClass="label">Đầu số:</asp:Label>
                                </td>
                                <td align="left">
                                                    <telerik:RadComboBox ID="RadDropDownListShortCode" runat="server" CheckBoxes="true" EnableCheckAllItemsCheckBox="True" Skin="Hay" Width="90px">
                                                        <Localization AllItemsCheckedString="--all--" CheckAllString="--all--" />
                                                    </telerik:RadComboBox>

                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblTrang21" runat="server" CssClass="label">Số điện thoại:</asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtUser_Id" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                        Width="40%"></asp:TextBox>
                                </td>
                                <td align="right">
                                    <asp:Label ID="lblTrang20" runat="server" CssClass="label">Mã dịch vụ:</asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtKeyWord" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                        Width="40%"></asp:TextBox>
                                    <asp:CheckBox ID="CheckBoxAbsolute" runat="server" CssClass="checkbox" Text="Tuyệt đối" />
                                </td>
                            </tr>
                            </table>
            </div>

            <div class="submmit">
                <asp:Button ID="btnSearch" runat="server" CssClass="btnbackground"
                    Text="Tìm kiếm" />
                <asp:Button ID="btnExport" runat="server" CssClass="btnbackground"
                    Text="Báo cáo" />
            </div>
            <div class="pager">
                <cc1:PagerV2_8 ID="pager1" runat="server" OnCommand="pager_Command" GenerateGoToSection="true"
                    Font-Size="10pt" PageSize="100" />

            </div>
            <div class="datagrid">

                <asp:DataGrid ID="DataGrid" runat="server" AutoGenerateColumns="false" CellPadding="0"
                    CssClass="datagrid" EnableViewState="False" GridLines="None" PagerStyle-Mode="NextPrev"
                    PagerStyle-Visible="true" Width="100%" PageSize="100">
                    <HeaderStyle CssClass="datagridHeader" />
                    <AlternatingItemStyle CssClass="datagridAlternatingItemStyle" />
                    <ItemStyle CssClass="datagridItemStyle" />
                    <Columns>
                        <asp:TemplateColumn>
                            <HeaderTemplate>
                                #
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblOrder" runat="server" CssClass="label"
                                    Text="<%# Container.ItemIndex+1 %>"> </asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="2%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="SỐ ĐIỆN THOẠI">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "sender")%>
                            </ItemTemplate>
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="NỘI DUNG MO">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "msgdata")%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="ĐẦU SỐ">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "receiver")%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="MÃ">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "keyword")%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="MẠNG">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "operator")%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="ĐỊNH TUYẾN">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "thirdparty")%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="TRẠNG THÁI">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "status")%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:TemplateColumn>

                        <asp:TemplateColumn HeaderText="THỜI GIAN GỬI">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "loggingTime")%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
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

