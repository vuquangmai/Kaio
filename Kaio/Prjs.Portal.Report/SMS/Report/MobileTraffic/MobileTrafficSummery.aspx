<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MobileTrafficSummery.aspx.vb" Inherits="Prjs.Portal.Report.MobileTrafficSummery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="ASPnetPagerV2_8" Namespace="ASPnetControls" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../../../Styles/HQ.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/LightStyle.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/RadTreeView.css" type="text/css" rel="stylesheet" />

    <script language="javascript" type="text/javascript" src="../../../Js/Menu3.js"></script>
    <script type="text/javascript">
        function IsDetail(contractId, year, month) {
            window.open("../../DictIndex/SMSContractInfo.aspx?objid=" + contractId + "&year=" + year + "&month=" + month, "Bil_SMS_Info", "location=no,directories=no,left=0,top=0,height=900,width=1000,status=no,scrollbars=yes,toolbars=no,menubar=no,resizable=yes");
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
        .auto-style1 {
            height: 18px;
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

                <telerik:AjaxSetting AjaxControlID="DropDownListCate1_Id">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="DropDownListCate2_Id" />
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
                <img id="imgCat1" src="../../../Images/collapse_thead.gif" border="0" alt="" />
            </a>
             
            <div id="divCat1" style="visibility: visible">
                <div class="input_report">
                    <fieldset id="fieldset" class="fieldset_parametter">
                        <telerik:RadSplitter ID="RadSplitter1" runat="server" Width="100%" Height="240px" BorderColor="Gray"
                            Skin="Hay">
                            <telerik:RadPane ID="LeftPane" runat="server" Width="75%">
                                <table width="100%">
                                    <tr>
                                        <td align="right" width="15%">
                                            <asp:Label ID="lblTrang7" runat="server" CssClass="label">Năm:</asp:Label>
                                        </td>
                                        <td align="left" width="35%">
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
                                            <asp:CheckBox ID="CheckBoxThirdParty" runat="server" CssClass="checkbox" Text="Định tuyến:"
                                                TextAlign="Left" />
                                        </td>
                                        <td align="left">
                                            <telerik:RadComboBox ID="RadDropDownListThirdParty" runat="server" CheckBoxes="true" EnableCheckAllItemsCheckBox="True" Skin="Hay" Width="150px">
                                                <Localization AllItemsCheckedString="--all--" CheckAllString="--all--" />
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
                                            <asp:CheckBox ID="CheckBoxMobileOperator" runat="server" CssClass="checkbox" Text="Mạng:"
                                                TextAlign="Left" />
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
                                        <td align="right">
                                            <asp:Label ID="lblTrang9" runat="server" CssClass="label">Từ ngày:</asp:Label>
                                        </td>
                                        <td align="left" width="35%">
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
                                            <asp:CheckBox ID="CheckBoxRangOfShortCode" runat="server" CssClass="checkbox" Text="Dải số:"
                                                TextAlign="Left" />
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
                                            <asp:CheckBox ID="CheckBoxShortCode" runat="server" CssClass="checkbox" Text="Đầu số:"
                                                TextAlign="Left" />
                                        </td>
                                        <td align="left">

                                            <asp:UpdatePanel ID="StockPricePanel" runat="server" UpdateMode="Conditional">
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="RadDropDownListRangOfShortCode" />
                                                </Triggers>
                                                <ContentTemplate>
                                                    <telerik:RadComboBox ID="RadDropDownListShortCode" runat="server" CheckBoxes="true" EnableCheckAllItemsCheckBox="True" Skin="Hay" Width="90px">
                                                        <Localization AllItemsCheckedString="--all--" CheckAllString="--all--" />
                                                    </telerik:RadComboBox>

                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">&nbsp;
                                        </td>
                                        <td align="left">
                                            <asp:CheckBox ID="CheckBoxAllDate" runat="server" Checked="True" CssClass="checkbox" Text="Cả tháng" />
                                        </td>
                                        <td align="right">
                                            <asp:CheckBox ID="CheckBoxKeyword" runat="server" CssClass="checkbox" Text="Mã:"
                                                TextAlign="Left" />
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtKeyword" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                Width="40%"></asp:TextBox>
                                            <asp:CheckBox ID="CheckBoxAbsolute" runat="server" CssClass="checkbox" Text="Tuyệt đối" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblTrang12" runat="server" CssClass="label">Trạng thái:</asp:Label>
                                        </td>
                                        <td align="left">
                                            <telerik:RadComboBox ID="RadDropDownListStatus" runat="server" Skin="Hay" Width="100px">
                                                <Items>
                                                    <telerik:RadComboBoxItem Text="--all--" Value="0" />
                                                    <telerik:RadComboBoxItem Text="Thành công" Value="1" />
                                                    <telerik:RadComboBoxItem Text="Hoàn cước" Value="2" />
                                                    <telerik:RadComboBoxItem Text="Lỗi" Value="3" />
                                                </Items>
                                            </telerik:RadComboBox>
                                        </td>
                                        <td align="right">
                                            <asp:CheckBox ID="CheckBoxDayOfWeek" runat="server" CssClass="checkbox"
                                                Text="Thứ:" TextAlign="Left" />
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
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:CheckBox ID="CheckBoxDepartment" runat="server" CssClass="checkbox" Text="Bộ phận:" TextAlign="Left" />
                                        </td>
                                        <td align="left">
                                            <telerik:RadComboBox ID="RadDropDownListDepartment_Id" runat="server" Skin="Hay" AutoPostBack="True" Width="70%">
                                                <ExpandAnimation Type="None" />
                                            </telerik:RadComboBox>
                                        </td>
                                        <td align="right">
                                            <asp:CheckBox ID="CheckBoxDate" runat="server" CssClass="checkbox" Text="Ngày:"
                                                TextAlign="Left" />
                                        </td>
                                        <td align="left">
                                            <asp:CheckBox ID="CheckBoxHour" runat="server" CssClass="checkbox" Text="Giờ:" TextAlign="Left" />
                                        </td>
                                    </tr>
                                    <tr>
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
                                        <td align="right">
                                            <asp:CheckBox ID="CheckBoxCate1_Id" runat="server" CssClass="checkbox" Text="Nhóm dịch vụ:" TextAlign="Left" />
                                        </td>
                                        <td align="left">
                                            <telerik:RadComboBox ID="RadDropDownListCate1_Id" runat="server" AutoPostBack="True" Skin="Hay" Width="70%">
                                                <ExpandAnimation Type="None" />
                                            </telerik:RadComboBox>
                                        </td>
                                    </tr>
                                    <tr>
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
                                        <td align="right">
                                            <asp:CheckBox ID="CheckBoxCate2_Id" runat="server" CssClass="checkbox" Text="Dịch vụ:" TextAlign="Left" />
                                        </td>
                                        <td align="left">


                                            <asp:UpdatePanel ID="UpdatePanelRadDropDownListCate2_Id" runat="server" UpdateMode="Conditional">
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="RadDropDownListCate1_Id" />
                                                </Triggers>
                                                <ContentTemplate>
                                                    <telerik:RadComboBox ID="RadDropDownListCate2_Id" runat="server" Skin="Hay" Width="98%">
                                                    </telerik:RadComboBox>

                                                </ContentTemplate>
                                            </asp:UpdatePanel>


                                        </td>
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
                                                            <asp:ListItem Value="2">MO</asp:ListItem>
                                                            <asp:ListItem Value="3">MT</asp:ListItem>
                                                            <asp:ListItem Value="4">CDR</asp:ListItem>
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
                                                            <asp:ListItem Value="2">MO</asp:ListItem>
                                                            <asp:ListItem Value="3">MT</asp:ListItem>
                                                            <asp:ListItem Value="4">CDR</asp:ListItem>
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
                                            <asp:CheckBox ID="CheckBoxError" runat="server" CssClass="checkbox" Text="Số liệu lỗi" />
                                            <asp:CheckBox ID="CheckBoxRefund" runat="server" CssClass="checkbox" Text="Số liệu hoàn cước" />
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
                <img id="imgCat2" src="../../../Images/collapse_thead.gif" border="0" alt="" />
            </a>
            <div id="divCat2" class="parametter" style="border-style: none; border-width: 0px; width: 80%; background-color: #FFFFFF; visibility: visible;">

                <table style="width: 100%; border-collapse: collapse">
                    <tr>
                        <td width="40%">
                            <fieldset id="fieldset2">
                                <legend>
                                    <asp:Label ID="Label5" runat="server" CssClass="lblerror" ForeColor="White">SẢN LƯỢNG, DOANH THU</asp:Label>



                                </legend>
                                <table width="100%">
                                    <tr>
                                        <td width="25%" align="right">
                                            <asp:Label ID="Label6" runat="server" CssClass="label_parametter" Font-Italic="False">MO:</asp:Label>
                                        </td>
                                        <td align="right" width="25%">
                                <asp:Label ID="lblTotalMO" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td align="right" width="25%">
                                            <asp:Label ID="Label7" runat="server" CssClass="label_parametter" Font-Italic="False">VMG:</asp:Label>
                                        </td>
                                        <td align="right">
                                <asp:Label ID="lblMoney_Share" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True" ForeColor="Blue"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label8" runat="server" CssClass="label_parametter" Font-Italic="False">MT:</asp:Label>
                                        </td>
                                        <td align="right">
                                <asp:Label ID="lblTotalMT" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label9" runat="server" CssClass="label_parametter" Font-Italic="False">Telcos:</asp:Label>
                                        </td>
                                        <td align="right">
                                <asp:Label ID="lblMoney_Operator" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label10" runat="server" CssClass="label_parametter" Font-Italic="False">CDR:</asp:Label>
                                        </td>
                                        <td align="right">
                                <asp:Label ID="lblTotalCDR" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label14" runat="server" CssClass="label_parametter" Font-Italic="False">Tổng:</asp:Label>
                                        </td>
                                        <td align="right">
                                <asp:Label ID="lblMoney_Total" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>

                        </td>
                        <td width="35%">
                            <fieldset id="fieldset4">
                                <legend>
                                    <asp:Label ID="Label11" runat="server" CssClass="lblerror" ForeColor="White">SỐ LIỆU LỖI</asp:Label>

                                </legend>
                                <table width="100%">
                                    <tr>
                                        <td width="25%" class="auto-style1" align="right">
                                            <asp:Label ID="Label12" runat="server" CssClass="label_parametter" Font-Italic="False">MO:</asp:Label>
                                        </td>
                                        <td align="right" width="25%" class="auto-style1">
                                <asp:Label ID="lblTotalMOErr" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td width="25%" class="auto-style1" align="right">
                                            <asp:Label ID="Label20" runat="server" CssClass="label_parametter" Font-Italic="False">VMG:</asp:Label>
                                        </td>
                                        <td class="auto-style1" align="right">
                                <asp:Label ID="lblMoney_Share_Error" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True" ForeColor="Blue"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label13" runat="server" CssClass="label_parametter" Font-Italic="False">MT:</asp:Label>
                                        </td>
                                        <td align="right">
                                <asp:Label ID="lblTotalMTErr" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label21" runat="server" CssClass="label_parametter" Font-Italic="False">Telcos:</asp:Label>
                                        </td>
                                        <td align="right">
                                <asp:Label ID="lblMoney_Operator_Error" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label19" runat="server" CssClass="label_parametter" Font-Italic="False">CDR:</asp:Label>
                                        </td>
                                        <td align="right">
                                <asp:Label ID="lblTotalCDRErr" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label22" runat="server" CssClass="label_parametter" Font-Italic="False">Tổng:</asp:Label>
                                        </td>
                                        <td align="right">
                                <asp:Label ID="lblMoney_Total_Error" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </td>
                        <td  >
                            <fieldset id="fieldset5">
                                <legend>
                                    <asp:Label ID="Label15" runat="server" CssClass="lblerror" ForeColor="White">HOÀN CƯỚC</asp:Label>



                                </legend>
                                <table width="100%">
                                    <tr>
                                        <td width="50%" align="right">
                                            <asp:Label ID="Label16" runat="server" CssClass="label_parametter" Font-Italic="False">VMG:</asp:Label>
                                        </td>
                                        <td align="right">
                                <asp:Label ID="lblMoney_Share_Refund" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True" ForeColor="Blue"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label17" runat="server" CssClass="label_parametter" Font-Italic="False">Telcos:</asp:Label>
                                        </td>
                                        <td align="right">
                                <asp:Label ID="lblMoney_Operator_Refund" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label18" runat="server" CssClass="label_parametter" Font-Italic="False">Tổng:</asp:Label>
                                        </td>
                                        <td align="right">
                                <asp:Label ID="lblMoney_Total_Refund" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True"></asp:Label>
                                        </td>
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
                        <asp:TemplateColumn HeaderText="MO">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblMO" runat="server" CssClass="label"> <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "MO"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="MT">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblMT" runat="server" CssClass="label">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "MT"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="CDR">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblCDR" runat="server" CssClass="label">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "CDR"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="VMG">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblMoney_Share" runat="server" CssClass="label" ForeColor="Blue" Font-Bold="true">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "Money_Share"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="TELCO">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblMoney_Operator" runat="server" CssClass="label" ForeColor="Red" Font-Bold="true">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "Money_Operator"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="TỔNG">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblMoney_Total" runat="server" CssClass="label" Font-Bold="true">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "Money_Total"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="MO lỗi">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblMO_Error" runat="server" CssClass="label"> <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "MO_Error"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="MT lỗi">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblMT_Error" runat="server" CssClass="label">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "MT_Error"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="CDR lỗi">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblCDR_Error" runat="server" CssClass="label">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "CDR_Error"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="VMG lỗi">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblMoney_Share_Error" runat="server" CssClass="label" ForeColor="Blue" Font-Bold="true">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "Money_Share_Error"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="TELCO lỗi">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblMoney_Operator_Error" runat="server" CssClass="label" ForeColor="Red" Font-Bold="true">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "Money_Operator_Error"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="TỔNG lỗi">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblMoney_Total_Error" runat="server" CssClass="label" Font-Bold="true">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "Money_Total_Error"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="MO Refund">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblMO_Refund" runat="server" CssClass="label">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "MO_Refund"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="VMG Refund">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblMoney_Share_Refund" runat="server" CssClass="label" ForeColor="Blue" Font-Bold="true">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "Money_Share_Refund"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="TELCO Refund">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblMoney_Operator_Refund" runat="server" CssClass="label" ForeColor="Red" Font-Bold="true">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "Money_Operator_Refund"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="TỔNG Refund">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblMoney_Total_Refund" runat="server" CssClass="label" Font-Bold="true">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "Money_Total_Refund"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="MẠNG">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblMobile_Operator" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Mobile_Operator")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="DẢI SỐ">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblRange_Short_Code" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Range_Short_Code")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="ĐẦU SỐ">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblShort_Code" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Short_Code")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="MÃ">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblKey_Word" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Key_Word")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="THỨ">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblDayOfWeek_Text" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "DayOfWeek_Text")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="NGÀY">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblDay" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Day")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="GIỜ">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblHour" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Hour")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="BỘ PHẬN">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblDepartment_Text" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Department_Text")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="ĐỐI TÁC">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblPartner_Text" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Partner_Text")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="HỢP ĐỒNG">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>

                                <a href="JavaScript:IsDetail('<%#Eval("Contract_Code")%>','<%#Eval("Year")%>','<%#Eval("Month")%>')" title="Thông tin chi tiết">
                                    <asp:Label ID="lblContract_Code" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Contract_Code")%></asp:Label></a>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="NHÓM DỊCH VỤ">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblCate1_Text" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Cate1_Text")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="DỊCH VỤ">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblCate2_Text" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Cate2_Text")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="ĐỊNH TUYẾN">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblThirdParty_Text" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "ThirdParty_Text")%></asp:Label>
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
