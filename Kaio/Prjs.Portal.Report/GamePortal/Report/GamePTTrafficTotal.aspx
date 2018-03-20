<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="GamePTTrafficTotal.aspx.vb" Inherits="Prjs.Portal.Report.GamePTTrafficTotal" %>

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
            window.open("../DictIndex/GamePortalContractInfo.aspx?objid=" + contract_code + "&year=" + year + "&month=" + month, "Bil_GamePortal_Info", "location=no,directories=no,left=0,top=0,height=900,width=1000,status=no,scrollbars=yes,toolbars=no,menubar=no,resizable=yes");
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
                <div class="input">
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
                                <asp:CheckBox ID="CheckBoxPayment_Type_Id" runat="server" CssClass="checkbox" Text="Loại hình thanh toán:" TextAlign="Left" />
                            </td>
                            <td align="left">


                                <telerik:RadComboBox ID="RadDropListPayment_Type_Id" runat="server" CheckBoxes="True" EnableCheckAllItemsCheckBox="True" Skin="Hay" Width="120px">
                                    <Items>
                                        <telerik:RadComboBoxItem runat="server" Text="SMS" Value="1" />
                                        <telerik:RadComboBoxItem runat="server" Text="Thẻ cào" Value="2" />
                                        <telerik:RadComboBoxItem runat="server" Text="Ngân hàng" Value="3" />
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
                                <asp:CheckBox ID="CheckBoxService_Text" runat="server" CssClass="checkbox" Text="Kênh thanh toán:" TextAlign="Left" />
                            </td>
                            <td align="left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblTrang12" runat="server" CssClass="label">Trạng thái:</asp:Label>
                            </td>
                            <td align="left">
                                <telerik:RadComboBox ID="RadDropDownListStatus_Id" runat="server"  Skin="Hay" Width="90px">
                                    <Items>
                                        <telerik:RadComboBoxItem Text="Thành công" Value="1" />
                                        <telerik:RadComboBoxItem Text="Lỗi" Value="0" />
                                    </Items>
                                   
                                </telerik:RadComboBox>
                            </td>
                            <td align="right">
                                <asp:CheckBox ID="CheckBoxMobile_Operator" runat="server" CssClass="checkbox" Text="Mạng:" TextAlign="Left" />
                            </td>
                            <td align="left">
                                <telerik:RadComboBox ID="RadDropDownListMobile_Operator" runat="server" CheckBoxes="True" EnableCheckAllItemsCheckBox="True" Skin="Hay" Width="100px">
                                    <Items>
                                        <telerik:RadComboBoxItem Text="GTEL" Value="GTEL" />
                                        <telerik:RadComboBoxItem Text="VIETTEL" Value="VIETTEL" />
                                        <telerik:RadComboBoxItem Text="VMS" Value="VMS" />
                                        <telerik:RadComboBoxItem Text="VNM" Value="VNM" />
                                        <telerik:RadComboBoxItem runat="server" Text="VNP" Value="VNP" />
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
                                <asp:CheckBox ID="CheckBoxPrice_Unit" runat="server" CssClass="checkbox" Text="Đơn giá:" TextAlign="Left" />
                            </td>
                            <td align="left">
                                <telerik:RadComboBox ID="RadDropDownListPrice_Unit" runat="server" CheckBoxes="true" EnableCheckAllItemsCheckBox="True" Skin="Hay" Width="100px">
                                    <Items>
                                        <telerik:RadComboBoxItem Text="500" Value="500" />
                                        <telerik:RadComboBoxItem Text="1000" Value="1000" />
                                        <telerik:RadComboBoxItem Text="2000" Value="2000" />
                                        <telerik:RadComboBoxItem Text="3000" Value="3000" />
                                        <telerik:RadComboBoxItem Text="4000" Value="4000" />
                                        <telerik:RadComboBoxItem Text="5000" Value="5000" />
                                        <telerik:RadComboBoxItem Text="10000" Value="10000" />
                                        <telerik:RadComboBoxItem Text="15000" Value="15000" />
                                        <telerik:RadComboBoxItem Text="20000" Value="20000" />
                                        <telerik:RadComboBoxItem Text="50000" Value="50000" />
                                        <telerik:RadComboBoxItem Text="100000" Value="100000" />
                                        <telerik:RadComboBoxItem Text="200000" Value="200000" />
                                        <telerik:RadComboBoxItem Text="500000" Value="500000" />
                                    </Items>
                                    <Localization AllItemsCheckedString="--all--" CheckAllString="--all--" />
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:CheckBox ID="CheckBoxDate" runat="server" CssClass="checkbox" Text="Ngày:" TextAlign="Left" />
                            </td>
                            <td align="left">
                                <asp:CheckBox ID="CheckBoxHour" runat="server" CssClass="checkbox" Text="Giờ:" TextAlign="Left" />
                            </td>
                            <td align="right">
                                &nbsp;</td>
                            <td align="left">
                                &nbsp;</td>
                        </tr>
                    </table>
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
            <div id="divCat2" class="parametter" style="border-style: none; border-width: 0px; width: 40%; background-color: #FFFFFF; visibility: visible;">

                <table style="width: 100%; border-collapse: collapse">
                    <tr>
                        <td> 
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
                        <asp:TemplateColumn HeaderText="GIỜ">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblHour" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Hour")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="THỨ">
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblDayOfWeek_Text" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "DayOfWeek_Text")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="LOẠI HÌNH THANH TOÁN">
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblChannel_Text" runat="server" CssClass="label"> <%# DataBinder.Eval(Container.DataItem, "Payment_Type_Text")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="KÊNH THANH TOÁN">
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblService_Text" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Service_Text")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                          <asp:TemplateColumn HeaderText="ĐƠN GIÁ">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblPrice_Unit" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Price_Unit")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                         <asp:TemplateColumn HeaderText="TỔNG SỐ">
                            <ItemStyle Width="10%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblCDR" runat="server" CssClass="label" Font-Bold="true" ForeColor="Red">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "Total"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                              <asp:TemplateColumn HeaderText="MẠNG">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblMobile_Operator" runat="server" CssClass="label"> <%# DataBinder.Eval(Container.DataItem, "Mobile_Operator")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="DOANH THU K/H">
                            <ItemStyle Width="10%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblMoney_Ccare" runat="server" CssClass="label" Font-Bold="true">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "Money_Ccare"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="VMG SAU TELCO">
                            <ItemStyle Width="10%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblMoney_VMG_Telcos" runat="server" CssClass="label" Font-Bold="true">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "Money_VMG_Telcos"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="DOANH THU TELCO">
                            <ItemStyle Width="10%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblMoney_Telcos_VMG" runat="server" CssClass="label" Font-Bold="true">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "Money_Telcos_VMG"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText=" DOANH THU ĐỐI TÁC">
                            <ItemStyle Width="10%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblMoney_Partner_VMG" runat="server" CssClass="label" Font-Bold="true" ForeColor="Red">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "Money_Partner_VMG"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="VMG SAU ĐỐI TÁC">
                            <ItemStyle Width="10%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblMoney_VMG_Partner" runat="server" CssClass="label" Font-Bold="true" ForeColor="Blue">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "Money_VMG_Partner"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="ĐỐI TÁC">
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
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

                    </Columns>

                    <PagerStyle HorizontalAlign="Right" NextPageText="" PageButtonCount="5" PrevPageText=""
                        Visible="False" />
                </asp:DataGrid>
            </div>
        </div>
    </form>
</body>
</html>
