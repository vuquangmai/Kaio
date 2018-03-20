<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="VishareTrafficTotal.aspx.vb" Inherits="Prjs.Portal.Report.VishareTrafficTotal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="ASPnetPagerV2_8" Namespace="ASPnetControls" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../../Styles/HQ.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/LightStyle.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/RadTreeView.css" type="text/css" rel="stylesheet" />

    <script language="javascript" type="text/javascript" src="../../../Js/Menu3.js"></script>
    <script type="text/javascript">
        function IsDetail(contract_code, year, month) {
            window.open("../DictIndex/VishareContractInfo.aspx?objid=" + contract_code + "&year=" + year + "&month=" + month, "Bil_Vishare_Info", "location=no,directories=no,left=0,top=0,height=900,width=1000,status=no,scrollbars=yes,toolbars=no,menubar=no,resizable=yes");
        }
    </script>
    <style type="text/css">
        fieldset {
            display: block;
            border: 1px solid #BCDDAF;
            -moz-border-radius: 8px;
            -webkit-border-radius: 8px;
            border-radius: 8px;
        }

        legend {
            background: #377F44;
            border: solid 1px green;
            -webkit-border-radius: 8px;
            -moz-border-radius: 8px;
            border-radius: 8px;
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
                <telerik:AjaxSetting AjaxControlID="DropDownListMonth">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="DropDownListFromDate" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListToDate" />
                    </UpdatedControls>
                </telerik:AjaxSetting>

            </AjaxSettings>
        </telerik:RadAjaxManager>
        <div id="HQ">
            <div class="alert">
                <asp:Label ID="lbltitle" runat="server" CssClass="lbltitle"></asp:Label><br />
                <asp:Label ID="lblerror" runat="server" CssClass="lblerror"></asp:Label>
            </div>
            <a href="javascript:showSubcat('1');">
                <img id="imgCat1" src="../../Images/collapse_thead.gif" border="0" alt="" />
            </a>
            <div id="divCat1" style="visibility: visible">
                <div class="input_report">
                    <fieldset id="fieldset" class="fieldset_parametter">
                        <telerik:RadSplitter ID="RadSplitter1" runat="server" Width="100%" Height="200px" BorderColor="Gray"
                            Skin="Hay">
                            <telerik:RadPane ID="LeftPane" runat="server" Width="75%">
                                <table width="100%">
                                    <tr>
                                        <td align="right" width="15%">
                                            <asp:Label ID="lblTrang7" runat="server" CssClass="label">Năm:</asp:Label>
                                        </td>
                                        <td align="left" width="20%">
                                            <asp:DropDownList ID="DropDownListYear" runat="server" CssClass="droplist">
                                                <asp:ListItem>2015</asp:ListItem>
                                                <asp:ListItem>2016</asp:ListItem>
                                                <asp:ListItem>2017</asp:ListItem>
                                                <asp:ListItem>2018</asp:ListItem>
                                                <asp:ListItem>2019</asp:ListItem>
                                                <asp:ListItem>2020</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right" width="15%">
                                            <asp:CheckBox ID="CheckBoxDepartment" runat="server" CssClass="checkbox" Text="Bộ phận:" TextAlign="Left" />
                                        </td>
                                        <td align="left">
                                            <telerik:RadComboBox ID="RadDropDownListDepartment_Id" runat="server" AutoPostBack="True" Skin="Hay" Width="60%">
                                                <ExpandAnimation Type="None" />
                                            </telerik:RadComboBox>


                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblTrang8" runat="server" CssClass="label">Tháng:</asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="DropDownListMonth" runat="server" CssClass="droplist"
                                                AutoPostBack="True">
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
                                            <asp:CheckBox ID="CheckBoxPartnerId" runat="server" CssClass="checkbox" Text="Đối tác:" TextAlign="Left" />
                                        </td>
                                        <td align="left">
                                            <asp:UpdatePanel ID="UpdatePanelRadDropDownListPartner_Id" runat="server" UpdateMode="Conditional">
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="RadDropDownListDepartment_Id" />
                                                </Triggers>
                                                <ContentTemplate>
                                                    <telerik:RadComboBox ID="RadDropDownListPartner_Id" runat="server" AutoPostBack="True" Skin="Hay" Width="98%">
                                                    </telerik:RadComboBox>

                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblTrang9" runat="server" CssClass="label">Từ ngày:</asp:Label>
                                        </td>
                                        <td align="left">
                                            <table cellpadding="0" cellspacing="0" class="style1">
                                                <tr>
                                                    <td width="20px">
                                                        <asp:DropDownList ID="DropDownListFromDate" runat="server" CssClass="droplist">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="center" width="20px">
                                                        <asp:Label ID="lblTrang10" runat="server" CssClass="label">lúc:</asp:Label>
                                                    </td>
                                                    <td width="20">
                                                        <asp:DropDownList ID="DropDownListFromHour" runat="server" CssClass="droplist">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label2" runat="server" CssClass="label">giờ</asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td align="right">
                                            <asp:CheckBox ID="CheckBoxContractCode" runat="server" CssClass="checkbox" Text="Hợp đồng:" TextAlign="Left" />
                                        </td>
                                        <td align="left">
                                            <asp:UpdatePanel ID="UpdatePanelRadDropDownListContract_Code" runat="server" UpdateMode="Conditional">
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="RadDropDownListPartner_Id" />
                                                </Triggers>
                                                <ContentTemplate>
                                                    <telerik:RadComboBox ID="RadDropDownListContract_Code" runat="server" Skin="Hay" Width="98%">
                                                    </telerik:RadComboBox>

                                                </ContentTemplate>
                                            </asp:UpdatePanel>
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
                                                    <td width="20px">
                                                        <asp:DropDownList ID="DropDownListToHour" runat="server" CssClass="droplist">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="Label3" runat="server" CssClass="label">giờ</asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td align="right">
                                            <asp:CheckBox ID="CheckBoxPackage_Text" runat="server" CssClass="checkbox" Text="Gói dịch vụ:" TextAlign="Left" />
                                        </td>
                                        <td align="left">


                                            <telerik:RadComboBox ID="RadDropPackage_Text" runat="server" CheckBoxes="True" EnableCheckAllItemsCheckBox="True" Skin="Hay" Width="150px">
                                                <Items>
                                                    <telerik:RadComboBoxItem runat="server" Text="VISHARE" Value="1" />
                                                    <telerik:RadComboBoxItem runat="server" Text="CLIP" Value="2" />
                                                    <telerik:RadComboBoxItem runat="server" Text="ANH" Value="3" />
                                                </Items>
                                                <Localization AllItemsCheckedString="--all--" CheckAllString="--all--" />
                                            </telerik:RadComboBox>


                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">&nbsp;
                                        </td>
                                        <td align="left">
                                            <asp:CheckBox ID="CheckBoxAllDate" runat="server" Checked="True" CssClass="checkbox" Text="Cả tháng" />
                                        </td>
                                        <td align="right">
                                            <asp:CheckBox ID="CheckBoxPriceUnit" runat="server" CssClass="checkbox" Text="Đơn giá:" TextAlign="Left" />
                                        </td>
                                        <td align="left">
                                            <telerik:RadComboBox ID="RadDropDownListPriceUnit" runat="server" CheckBoxes="true" EnableCheckAllItemsCheckBox="True" Skin="Hay" Width="90px">
                                                <Items>
                                                    <telerik:RadComboBoxItem Text="1000" Value="1000" />
                                                    <telerik:RadComboBoxItem Text="3000" Value="3000" />
                                                    <telerik:RadComboBoxItem Text="5000" Value="5000" />
                                                    <telerik:RadComboBoxItem Text="10000" Value="10000" />
                                                </Items>
                                                <Localization AllItemsCheckedString="--all--" CheckAllString="--all--" />
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:CheckBox ID="CheckBoxDayOfWeek" runat="server" CssClass="checkbox" Text="Thứ:" TextAlign="Left" />
                                        </td>
                                        <td align="left">
                                            <telerik:RadComboBox ID="RadDropDownListDayOfWeek" runat="server" CheckBoxes="true" EnableCheckAllItemsCheckBox="True" Skin="Hay" Width="90px">
                                                <Items>
                                                    <telerik:RadComboBoxItem Text="Chủ nhật" Value="0" />
                                                    <telerik:RadComboBoxItem Text="Thứ 2" Value="1" />
                                                    <telerik:RadComboBoxItem Text="Thứ 3" Value="2" />
                                                    <telerik:RadComboBoxItem Text="Thứ 4" Value="3" />
                                                    <telerik:RadComboBoxItem Text="Thứ 5" Value="4" />
                                                    <telerik:RadComboBoxItem Text="Thứ 6" Value="5" />
                                                    <telerik:RadComboBoxItem Text="Thứ 7" Value="6" />
                                                </Items>
                                                <Localization AllItemsCheckedString="--all--" CheckAllString="--all--" />
                                            </telerik:RadComboBox>
                                        </td>
                                        <td align="right">
                                            <asp:CheckBox ID="CheckBoxUrl_Id" runat="server" CssClass="checkbox" Text="Url truyền thông:" TextAlign="Left" />
                                        </td>
                                        <td align="left">
                                            <telerik:RadComboBox ID="RadDropDownListUrl_Id" runat="server" Skin="Hay" Width="60%">
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:CheckBox ID="CheckBoxDate" runat="server" CssClass="checkbox" Text="Ngày:" TextAlign="Left" />
                                        </td>
                                        <td align="left">





                                            &nbsp;</td>
                                        <td align="right">
                                            &nbsp;</td>
                                        <td align="left">
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </telerik:RadPane>
                            <telerik:RadSplitBar ID="RadSplitBar1" runat="server" CollapseMode="Backward" CollapseExpandPaneText="Tùy chọn khác"></telerik:RadSplitBar>
                            <telerik:RadPane ID="MiddlePane1" runat="server" Width="25%" Collapsed="true">
                                <table cellpadding="2" cellspacing="2" width="100%">
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="Sorting1" runat="server" CssClass="label" Font-Bold="False" Font-Italic="False" Font-Underline="True" ForeColor="#666666">Tùy chọn khác</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="Sorting" runat="server" CssClass="label" Font-Italic="True">1. Sắp xếp:</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="100%" align="left">
                                            <table cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td width="30%">
                                                        <asp:DropDownList ID="DropDownListFieldList" runat="server" CssClass="droplist">
                                                            <asp:ListItem Value="0">--Chọn--</asp:ListItem>
                                                            <asp:ListItem Value="1">Doanh thu</asp:ListItem>
                                                            <asp:ListItem Value="2">Đăng ký</asp:ListItem>
                                                            <asp:ListItem Value="3">Hủy</asp:ListItem>
                                                            <asp:ListItem Value="4">Gia hạn</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="50%">
                                                        <asp:DropDownList ID="DropDownListSort" runat="server" CssClass="droplist">
                                                            <asp:ListItem Value="1">Giảm dần</asp:ListItem>
                                                            <asp:ListItem Value="2">Tăng dần</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="SORTING0" runat="server" CssClass="label" Font-Italic="True">2. Tiêu chí tìm kiếm:</asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td align="left">
                                            <table cellpadding="0" cellspacing="0" class="style1">
                                                <tr>
                                                    <td width="30%">
                                                        <asp:DropDownList ID="DropDownListFieldFilter" runat="server" CssClass="droplist">
                                                            <asp:ListItem Value="0">--Chọn--</asp:ListItem>
                                                            <asp:ListItem Value="1">Doanh thu</asp:ListItem>
                                                            <asp:ListItem Value="2">Đăng ký</asp:ListItem>
                                                            <asp:ListItem Value="3">Hủy</asp:ListItem>
                                                            <asp:ListItem Value="4">Gia hạn</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td width="10%">
                                                        <asp:DropDownList ID="DropDownListFilter" runat="server" CssClass="droplist">
                                                            <asp:ListItem Value="1">&gt;=</asp:ListItem>
                                                            <asp:ListItem Value="2">&lt;=</asp:ListItem>
                                                            <asp:ListItem Value="3">=</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="right">
                                                        <asp:TextBox ID="txtFilter" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                            Width="90%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="Label4" runat="server" CssClass="label" Font-Italic="True">3. Hiển thị:</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:CheckBox ID="CheckBoxRegister" runat="server" CssClass="checkbox" Text="Số liệu đăng ký" />
                                            <asp:CheckBox ID="CheckBoxCancel" runat="server" CssClass="checkbox" Text="Số liệu hủy" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:CheckBox ID="CheckBoxRenewal" runat="server" CssClass="checkbox" Text="Số liệu gia hạn" />
                                        </td>
                                    </tr>
                                </table>
                            </telerik:RadPane>
                        </telerik:RadSplitter>
                    </fieldset>
                </div>
                <div class="submmit">
                    <asp:Button ID="btnSearch" runat="server" CssClass="btnbackground"
                        Text="Tìm kiếm" />
                    <asp:Button ID="btnExport" runat="server" CssClass="btnbackground"
                        Text="Báo cáo" />
                </div>
            </div>
            <a href="javascript:showSubcat('2');">
                <img id="imgCat2" src="../../Images/collapse_thead.gif" border="0" alt="" />
            </a>
            <div id="divCat2" class="parametter"  style="border-style: none; border-width: 0px; width: 80%; background-color: #FFFFFF; visibility: visible;">

                <table style="width: 100%; border-collapse: collapse">
                    <tr>
                        <td width="40%">
                            <fieldset id="fieldset2">
                                <legend>
                                    <asp:Label ID="Label5" runat="server" CssClass="lblerror" ForeColor="White">DOANH THU</asp:Label>



                                </legend>
                                <table width="100%">
                                    <tr>
                                        <td width="25%">
                                            <asp:Label ID="lblMO" runat="server" CssClass="label_parametter" Font-Italic="False">VMG sau Telco (1):</asp:Label>
                                        </td>
                                        <td align="right" width="25%">
                                            <asp:Label ID="lblMoney_VMG_Telcos" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td align="right" width="25%">
                                            <asp:Label ID="lblMO5" runat="server" CssClass="label_parametter" Font-Italic="False">VMG sau đối tác (4):</asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblMoney_VMG_Partner" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True" ForeColor="Blue"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblMO1" runat="server" CssClass="label_parametter" Font-Italic="False">Telco sau VMG (2)</asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblMoney_Telcos_VMG" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblMO6" runat="server" CssClass="label_parametter" Font-Italic="False">Đối tác sau VMG (5):</asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblMoney_Partner_VMG" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblMO0" runat="server" CssClass="label_parametter" Font-Italic="False">Khách hàng (3):</asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblMoney_Ccare" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lblMO14" runat="server" CssClass="label" Font-Italic="True">(1)+(2)=(3)</asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lblMO15" runat="server" CssClass="label" Font-Italic="True">(4)+(5)=(1)</asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>

                        </td>
                        <td width="20%">
                            <fieldset id="fieldset4">
                                <legend>
                                    <asp:Label ID="Label6" runat="server" CssClass="lblerror" ForeColor="White">ĐĂNG KÝ</asp:Label>

                                </legend>
                                <table width="100%">
                                    <tr>
                                        <td width="50%">
                                            <asp:Label ID="lblMO3" runat="server" CssClass="label_parametter" Font-Italic="False">Kênh WAP:</asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblWAP_Registration" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblMO4" runat="server" CssClass="label_parametter" Font-Italic="False">Kênh SMS:</asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblSMS_Registration" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblMO16" runat="server" CssClass="label_parametter" Font-Italic="False">Kênh APP:</asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblApp_Registration" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblMO17" runat="server" CssClass="label_parametter" Font-Italic="False">Kênh WEB:</asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblWeb_Registration" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblMO2" runat="server" CssClass="label_parametter" Font-Italic="False">Tổng:</asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblTotal_Registration" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                        <td width="20%">
                            <fieldset id="fieldset5">
                                <legend>
                                    <asp:Label ID="Label7" runat="server" CssClass="lblerror" ForeColor="White">HỦY</asp:Label>



                                </legend>
                                <table width="100%">
                                    <tr>
                                        <td width="50%">
                                            <asp:Label ID="lblMO8" runat="server" CssClass="label_parametter" Font-Italic="False">Kênh WAP:</asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblWAP_Cancel" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True" ForeColor="Black"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblMO9" runat="server" CssClass="label_parametter" Font-Italic="False">Kênh SMS:</asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblSMS_Cancel" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True" ForeColor="Black"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblMO18" runat="server" CssClass="label_parametter" Font-Italic="False">Kênh WEB:</asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblWEB_Cancel" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True" ForeColor="Black"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblMO19" runat="server" CssClass="label_parametter" Font-Italic="False">Kênh APP:</asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblAPP_Cancel" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True" ForeColor="Black"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblMO20" runat="server" CssClass="label_parametter" Font-Italic="False">Kênh HỆ THỐNG:</asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblSYS_Cancel" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True" ForeColor="Black"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblMO10" runat="server" CssClass="label_parametter" Font-Italic="False">Tổng:</asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblTotal_Cancel" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                        <td width="20%">
                            <fieldset id="fieldset6">
                                <legend>
                                    <asp:Label ID="Label8" runat="server" CssClass="lblerror" ForeColor="White">GIA HẠN</asp:Label>

                                </legend>
                                <table width="100%">
                                    <tr>
                                        <td width="50%">
                                            <asp:Label ID="Label10" runat="server" CssClass="label_parametter" Font-Italic="False">Thành công:</asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblTotal_Renewal_Success" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True" ForeColor="Blue"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label12" runat="server" CssClass="label_parametter" Font-Italic="False">Thất bại:</asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblTotal_Renewal_Fail" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td align="right">
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>

                    </tr>
                </table>
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
                        <asp:TemplateColumn HeaderText="NGÀY">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblDay" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Day")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="THỨ">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblDayOfWeek_Text" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "DayOfWeek_Text")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="GÓI">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblPackage_Text" runat="server" CssClass="label"> <%# DataBinder.Eval(Container.DataItem, "Package_Text")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="ĐƠN GIÁ">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblPrice_Unit" runat="server" CssClass="label">   <%#  DataBinder.Eval(Container.DataItem, "Price_Unit")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="DOANH THU K/H">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="Total_Money_Ccare" runat="server" CssClass="label" Font-Bold="true">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "Total_Money_Ccare"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="VMG SAU TELCO">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="Total_Money_VMG_Telcos" runat="server" CssClass="label" Font-Bold="true">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "Total_Money_VMG_Telcos"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                               <asp:TemplateColumn HeaderText=" DOANH THU ĐỐI TÁC">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="Total_Money_VMG_Partner" runat="server" CssClass="label" Font-Bold="true" ForeColor="Red">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "Total_Money_Partner_VMG"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="VMG SAU ĐỐI TÁC">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="Total_Money_Partner_VMG" runat="server" CssClass="label" Font-Bold="true" ForeColor="Blue">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "Total_Money_VMG_Partner"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="TỔNG ĐK">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="Total_Registration" runat="server" CssClass="label" Font-Bold="true">  <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "Total_Registration"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="ĐK WAP">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="WAP_Registration" runat="server" CssClass="label">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "WAP_Registration"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="ĐK SMS">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="SMS_Registration" runat="server" CssClass="label">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "SMS_Registration"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="ĐK APP">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="APP_Registration" runat="server" CssClass="label">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "APP_Registration"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="ĐK WEB">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="WEB_Registration" runat="server" CssClass="label">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "WEB_Registration"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                          <asp:TemplateColumn HeaderText="ĐK TRỪ TIỀN">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="Registration_Charge" runat="server" CssClass="label">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "Registration_Charge"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                           <asp:TemplateColumn HeaderText="DOANH THU ĐK">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="Money_Registration_Ccare" runat="server" CssClass="label" Font-Bold="true">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "Money_Registration_Ccare"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="TỔNG HỦY">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="Total_Cancel" runat="server" CssClass="label" Font-Bold="true">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "Total_Cancel"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="HỦY WAP">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="WAP_Cancel" runat="server" CssClass="label">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "WAP_Cancel"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="HỦY SMS">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="SMS_Cancel" runat="server" CssClass="label">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "SMS_Cancel"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="HỦY WEB">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="WEB_Cancel" runat="server" CssClass="label">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "WEB_Cancel"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                          <asp:TemplateColumn HeaderText="HỦY APP">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="APP_Cancel" runat="server" CssClass="label">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "APP_Cancel"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                          <asp:TemplateColumn HeaderText="HỦY HỆ THỐNG">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="SYS_Cancel" runat="server" CssClass="label">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "SYS_Cancel"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="GIA HẠN THÀNH CÔNG">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="Total_Renewal_Success" runat="server" CssClass="label" Font-Bold="true">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "Total_Renewal_Success"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="GIA HẠN THẤT BẠI">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="Total_Renewal_Fail" runat="server" CssClass="label">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "Total_Renewal_Fail"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="DOANH THU GIA HẠN">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="Money_Renewal_Ccare" runat="server" CssClass="label">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "Money_Renewal_Ccare"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        
                        <asp:TemplateColumn HeaderText="ĐỐI TÁC">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblPartner_Code" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Partner_Code")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="HỢP ĐỒNG">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>

                                <a href="JavaScript:IsDetail('<%#Eval("Contract_Code")%>','<%#Eval("Year")%>','<%# Eval("Month")%>')" title="Thông tin chi tiết hợp đồng, đối soát thanh toán">
                                    <asp:Label ID="lblContract_Code" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Contract_Code")%></asp:Label></a>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                     
                        <asp:TemplateColumn HeaderText="MÃ URL">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblUrl_Text" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Url_Code")%></asp:Label>
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
