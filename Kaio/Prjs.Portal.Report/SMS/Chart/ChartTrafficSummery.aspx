<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ChartTrafficSummery.aspx.vb" Inherits="Prjs.Portal.Report.ChartTrafficSummery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="ASPnetPagerV2_8" Namespace="ASPnetControls" TagPrefix="cc1" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Charting" TagPrefix="telerik" %>

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
           

                <div class="input_report">
                    <fieldset id="fieldset" class="fieldset_parametter">
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
                                    </asp:UpdatePanel></td>
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
                                    &nbsp;</td>
                                <td align="left">




                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </div>
                <div class="submmit">
                    <asp:Button ID="btnSearch" runat="server" CssClass="btnbackground"
                        Text="Tìm kiếm" />
                    <asp:Button ID="btnExport" runat="server" CssClass="btnbackground"
                        Text="Báo cáo" />
                </div>
            <div  style="margin: 3px; width: 99%" align="center">
               <telerik:RadChart ID="RadChart1" runat="server"  
                         DefaultType="Line" Width="1300px" Skin="Web" AutoLayout="True" Height="350px">
                      <Appearance>
                          <FillStyle MainColor="249, 250, 251">
                          </FillStyle>
                          <Border Color="103, 136, 190" />
                      </Appearance>
            <Series>
                <telerik:ChartSeries Name="Khách hàng" DataYColumn="Money_Total" Type="Line" >
                    <Appearance>
                        <FillStyle MainColor="97, 131, 217" FillType="ComplexGradient">
                            <FillSettings>
                                <ComplexGradient>
                                    <telerik:GradientElement Color="97, 131, 217" />
                                    <telerik:GradientElement Color="194, 194, 194" Position="1" />
                                </ComplexGradient>
                            </FillSettings>
                        </FillStyle>
                        <LabelAppearance Visible="false" />
                        <PointMark Visible="True">
                        </PointMark>
                    </Appearance>
                </telerik:ChartSeries>
                <telerik:ChartSeries DataYColumn="Money_Share" Name="VMG" Type="Line">
                    <Appearance>
                        <FillStyle MainColor="Red" FillType="ComplexGradient">
                            <FillSettings>
                                <ComplexGradient>
                                    <telerik:GradientElement Color="255, 153, 0" />
                                    <telerik:GradientElement Color="241, 241, 241" Position="1" />
                                </ComplexGradient>
                            </FillSettings>
                        </FillStyle>
                        <LabelAppearance Visible="false" />
                        <PointMark Visible="True">
                        </PointMark>
                    </Appearance>
                </telerik:ChartSeries>
                <telerik:ChartSeries DataYColumn="Money_Operator" Name="Telcos" Type="Line" >
                    <Appearance>
                        <FillStyle MainColor="172, 203, 45" FillType="ComplexGradient">
                            <FillSettings>
                                <ComplexGradient>
                                    <telerik:GradientElement Color="172, 203, 45" />
                                    <telerik:GradientElement Color="194, 194, 194" Position="1" />
                                </ComplexGradient>
                            </FillSettings>
                        </FillStyle>
                        <LabelAppearance Visible="false" />
                        <PointMark Visible="True">
                        </PointMark>
                    </Appearance>
                </telerik:ChartSeries>
            </Series>
            <PlotArea>
                <XAxis LayoutMode="Normal">
                    <Appearance Color="165, 190, 223" MajorTick-Color="165, 190, 223">
                        <MajorGridLines Color="165, 190, 223"></MajorGridLines>
                    </Appearance>
                </XAxis>
                <YAxis>
                    <Appearance Color="165, 190, 223" MinorTick-Color="165, 190, 223" MajorTick-Color="165, 190, 223">
                        <MajorGridLines Color="165, 190, 223"></MajorGridLines>
                        <MinorGridLines Color="165, 190, 223" Width="0" />
                    </Appearance>
                </YAxis>
                <Appearance Dimensions-Margins="18%, 23%, 12%, 10%">
                    <FillStyle MainColor="249, 250, 251" FillType="Solid">
                    </FillStyle>
                    <Border Color="165, 190, 223" />
                </Appearance>
            </PlotArea>
            <ChartTitle>
                <Appearance Dimensions-Margins="4%, 10px, 14px, 6%">
                </Appearance>
                <TextBlock Text="DOANH THU">
                    <Appearance TextProperties-Font="Arial, 9pt, style=Bold" 
                        TextProperties-Color="0, 0, 102">
                    </Appearance>
                </TextBlock>
            </ChartTitle>
            <Legend>
                <Appearance >
                    <FillStyle MainColor="231, 241, 255">
                    </FillStyle>
                    <Border Color="165, 190, 223"></Border>
                </Appearance>
                <TextBlock>
                    <Appearance AutoTextWrap="True">
                    </Appearance>
                </TextBlock>
            </Legend>
        </telerik:RadChart>
            </div>
             <div  style="margin: 3px; width: 99%" align="center">
                  <telerik:RadChart ID="RadChart2" runat="server"  
                         DefaultType="Line" Width="1300px" Skin="LightGreen" AutoLayout="True" Height="350px">
                      <Appearance>
                          <FillStyle MainColor="235, 249, 213">
                          </FillStyle>
                          <Border Color="203, 225, 169" />
                      </Appearance>
            <Series>
                <telerik:ChartSeries Name="MT" DataYColumn="MT" Type="Line" >
                    <Appearance>
                        <FillStyle MainColor="243, 206, 119" FillType="ComplexGradient">
                            <FillSettings>
                                <ComplexGradient>
                                    <telerik:GradientElement Color="243, 206, 119" />
                                    <telerik:GradientElement Color="236, 190, 82" Position="0.5" />
                                    <telerik:GradientElement Color="210, 157, 44" Position="1" />
                                </ComplexGradient>
                            </FillSettings>
                        </FillStyle>
                        <LabelAppearance Visible="false" />
                        <PointMark Visible="True">
                        </PointMark>
                        <TextAppearance TextProperties-Color="112, 93, 56">
                        </TextAppearance>
                        <Border Color="223, 170, 40" />
                    </Appearance>
                </telerik:ChartSeries>
                <telerik:ChartSeries DataYColumn="MO" Name="MO" Type="Line">
                    <Appearance>
                        <FillStyle MainColor="#0000CC" FillType="ComplexGradient">
                            <FillSettings>
                                <ComplexGradient>
                                    <telerik:GradientElement Color="154, 220, 230" />
                                    <telerik:GradientElement Color="121, 207, 220" Position="0.5" />
                                    <telerik:GradientElement Color="89, 185, 204" Position="1" />
                                </ComplexGradient>
                            </FillSettings>
                        </FillStyle>
                        <LabelAppearance Visible="false" />
                        <PointMark Visible="True">
                        </PointMark>
                        <TextAppearance TextProperties-Color="112, 93, 56">
                        </TextAppearance>
                        <Border Color="117, 177, 192" />
                    </Appearance>
                </telerik:ChartSeries>
                <telerik:ChartSeries DataYColumn="CDR" Name="CDR" Type="Line" >
                    <Appearance>
                        <FillStyle MainColor="#FF3300" FillType="ComplexGradient">
                            <FillSettings>
                                <ComplexGradient>
                                    <telerik:GradientElement Color="161, 218, 123" />
                                    <telerik:GradientElement Color="130, 202, 82" Position="0.5" />
                                    <telerik:GradientElement Color="104, 179, 48" Position="1" />
                                </ComplexGradient>
                            </FillSettings>
                        </FillStyle>
                        <LabelAppearance Visible="false" />
                        <PointMark Visible="True">
                        </PointMark>
                        <TextAppearance TextProperties-Color="112, 93, 56">
                        </TextAppearance>
                        <Border Color="81, 162, 37" />
                    </Appearance>
                </telerik:ChartSeries>
            </Series>
            <PlotArea>
                <XAxis LayoutMode="Normal">
                    <Appearance Color="226, 218, 202" MajorTick-Color="216, 207, 190">
                        <MajorGridLines Color="226, 218, 202"></MajorGridLines>
                        <TextAppearance TextProperties-Color="112, 93, 56">
                        </TextAppearance>
                    </Appearance>
                    <AxisLabel>
                        <TextBlock>
                            <Appearance TextProperties-Color="112, 93, 56">
                            </Appearance>
                        </TextBlock>
                    </AxisLabel>
                </XAxis>
                <YAxis>
                    <Appearance Color="226, 218, 202" MinorTick-Color="226, 218, 202" MajorTick-Color="226, 218, 202">
                        <MajorGridLines Color="231, 225, 212"></MajorGridLines>
                        <MinorGridLines Color="231, 225, 212" />
                        <TextAppearance TextProperties-Color="112, 93, 56">
                        </TextAppearance>
                    </Appearance>
                    <AxisLabel>
                        <TextBlock>
                            <Appearance TextProperties-Color="112, 93, 56">
                            </Appearance>
                        </TextBlock>
                    </AxisLabel>
                </YAxis>
                <Appearance Dimensions-Margins="18%, 23%, 12%, 10%">
                    <FillStyle MainColor="254, 255, 228" SecondColor="Transparent">
                    </FillStyle>
                    <Border Color="226, 218, 202" />
                </Appearance>
            </PlotArea>
            <ChartTitle>
                <Appearance>
                    <FillStyle MainColor="">
                    </FillStyle>
                </Appearance>
                <TextBlock Text="SẢN LƯỢNG">
                    <Appearance TextProperties-Font="Arial, 9pt, style=Bold" 
                        TextProperties-Color="Green">
                    </Appearance>
                </TextBlock>
            </ChartTitle>
            <Legend>
                <Appearance Corners="Round, Round, Round, Round, 6" >
                    <ItemTextAppearance TextProperties-Color="113, 94, 57">
                    </ItemTextAppearance>
                    <Border Color="225, 217, 201"></Border>
                </Appearance>
                <TextBlock>
                    <Appearance AutoTextWrap="True" TextProperties-Font="Arial, 8.25pt">
                    </Appearance>
                </TextBlock>
            </Legend>
        </telerik:RadChart>

             </div>
        </div>

    </form>

</body>
</html>
