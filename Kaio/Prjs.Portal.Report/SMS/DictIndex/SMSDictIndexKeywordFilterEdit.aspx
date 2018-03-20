<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SMSDictIndexKeywordFilterEdit.aspx.vb" Inherits="Prjs.Portal.Report.SMSDictIndexKeywordFilterEdit" %>
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
                <telerik:AjaxSetting AjaxControlID="DropDownListCate_1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="DropDownListCate_2" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="DropDownListCate_2">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="DropDownListCate_3" />
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
                                    <asp:DropDownList ID="DropDownListDepartment_Id" runat="server" CssClass="droplist">
                                        <asp:ListItem Value="0">--Chọn--</asp:ListItem>
                                        <asp:ListItem Value="1">VMG</asp:ListItem>
  <asp:ListItem Value="2">be3a</asp:ListItem>
  <asp:ListItem Value="3">VNNLinks</asp:ListItem>
  <asp:ListItem Value="4">Lucky_fone</asp:ListItem>
  <asp:ListItem Value="5">Mcommerce</asp:ListItem>
  <asp:ListItem Value="27">ALOFUN</asp:ListItem>
  <asp:ListItem Value="29">DEC</asp:ListItem>
  <asp:ListItem Value="30">DVKH</asp:ListItem>
  <asp:ListItem Value="31">EVN</asp:ListItem>
  <asp:ListItem Value="32">IDEA</asp:ListItem>
  <asp:ListItem Value="34">IIS</asp:ListItem>
  <asp:ListItem Value="35">INCOM</asp:ListItem>
  <asp:ListItem Value="36">Kamak</asp:ListItem>
  <asp:ListItem Value="38">RedStar</asp:ListItem>
  <asp:ListItem Value="39">TINSAI</asp:ListItem>
  <asp:ListItem Value="40">URVN</asp:ListItem>
  <asp:ListItem Value="41">VASC.HCM</asp:ListItem>
  <asp:ListItem Value="42">VINAPOS</asp:ListItem>
  <asp:ListItem Value="44">VNNPlus</asp:ListItem>
  <asp:ListItem Value="45">VNNTV</asp:ListItem>
  <asp:ListItem Value="46">VOS</asp:ListItem>
  <asp:ListItem Value="47">YP</asp:ListItem>
  <asp:ListItem Value="48">XZONE</asp:ListItem>
  <asp:ListItem Value="49">HR</asp:ListItem>
  <asp:ListItem Value="50">Mbox</asp:ListItem>
  <asp:ListItem Value="51">EBIS</asp:ListItem>
  <asp:ListItem Value="52">Zlango</asp:ListItem>
  <asp:ListItem Value="53">BANQUYEN</asp:ListItem>
  <asp:ListItem Value="54">DongDuong</asp:ListItem>
  <asp:ListItem Value="55">HANEL</asp:ListItem>
  <asp:ListItem Value="56">KRAZE</asp:ListItem>
  <asp:ListItem Value="57">SFONE</asp:ListItem>
  <asp:ListItem Value="58">VNMS2</asp:ListItem>
  <asp:ListItem Value="59">PGOnline</asp:ListItem>
  <asp:ListItem Value="60">MOBIVI</asp:ListItem>
  <asp:ListItem Value="61">PBOnline</asp:ListItem>
  <asp:ListItem Value="62">MyTV</asp:ListItem>
  <asp:ListItem Value="63">S2Viettel</asp:ListItem>
  <asp:ListItem Value="64">IPTV</asp:ListItem>
  <asp:ListItem Value="65">ITRD</asp:ListItem>
  <asp:ListItem Value="66">EPAY</asp:ListItem>
  <asp:ListItem Value="67">LINGO</asp:ListItem>
  <asp:ListItem Value="68">PTDV</asp:ListItem>
  <asp:ListItem Value="69">TIEPTHISO</asp:ListItem>
  <asp:ListItem Value="70">VMG.HCM</asp:ListItem>

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
                            <asp:Label ID="Label83" runat="server" CssClass="label">Mã Filter:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtKeyWord" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="30%" Font-Bold="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="20%">
                            <asp:Label ID="Label7" runat="server" CssClass="label">Uri:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtservice_uri" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="50%" Font-Bold="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label14" runat="server" CssClass="label">Trạng thái:</asp:Label>
                        </td>
                        <td align="left">
                             <asp:DropDownList ID="DropDownListStatus" runat="server" 
                                    CssClass="droplist" Font-Bold="False" ForeColor="Red">
                                    <asp:ListItem Value="-1">--Chọn--</asp:ListItem>
                                    <asp:ListItem Value="1">Duyệt</asp:ListItem>
                                    <asp:ListItem Value="0">Chờ duyệt</asp:ListItem>
                                    <asp:ListItem Value="2">Hủy</asp:ListItem>
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
