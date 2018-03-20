<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SimToolKitTrafficTotal.aspx.vb" Inherits="Prjs.Portal.Report.SimToolKitTrafficTotal" %>

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
            window.open("../DictIndex/VishareContractInfo.aspx?objid=" + contract_code + "&year=" + year + "&month=" + month, "Bil_Brand_Info", "location=no,directories=no,left=0,top=0,height=900,width=900,status=no,scrollbars=yes,toolbars=no,menubar=no,resizable=yes");
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
                                <asp:CheckBox ID="CheckBoxChannel_Id" runat="server" CssClass="checkbox" Text="Kênh dịch vụ:" TextAlign="Left" />
                            </td>
                            <td align="left">


                                <telerik:RadComboBox ID="RadDropChannel_Id" runat="server" CheckBoxes="True" EnableCheckAllItemsCheckBox="True" Skin="Hay" Width="150px">
                                    <Items>
                                        <telerik:RadComboBoxItem runat="server" Text="VMG-VNM" Value="1" />
                                        <telerik:RadComboBoxItem runat="server" Text="VMG-NMS-VNM" Value="2" />
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
                                <asp:CheckBox ID="CheckBoxService_Id" runat="server" CssClass="checkbox" Text="Dịch vụ sử dụng:" TextAlign="Left" />
                            </td>
                            <td align="left">
                                <telerik:RadComboBox ID="RadDropDownListService_Id" runat="server" CheckBoxes="true" EnableCheckAllItemsCheckBox="True" Skin="Hay" Width="300px">
                                  
                                    <Localization AllItemsCheckedString="--all--" CheckAllString="--all--" />
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblTrang12" runat="server" CssClass="label">Trạng thái:</asp:Label>
                            </td>
                            <td align="left">


                                <telerik:RadComboBox ID="RadDropListStatus_Id" runat="server" CheckBoxes="false" EnableCheckAllItemsCheckBox="True" Skin="Hay" Width="90px">
                                    <Items>
                                        <telerik:RadComboBoxItem runat="server" Text="Thành công" Value="1" />
                                        <telerik:RadComboBoxItem runat="server" Text="Lỗi" Value="0" />
                                    </Items>
                                    
                                </telerik:RadComboBox>


                            </td>
                            <td align="right">
                                <asp:CheckBox ID="CheckBoxAccess_Number" runat="server" CssClass="checkbox" Text="Đầu số:" TextAlign="Left" />
                            </td>
                            <td align="left">
                                <telerik:RadComboBox ID="RadDropDownListAccess_Number" runat="server" CheckBoxes="true" EnableCheckAllItemsCheckBox="True" Skin="Hay" Width="90px">
                                    <Items>
                                        <telerik:RadComboBoxItem Text="921" Value="921" />
                                        <telerik:RadComboBoxItem Text="922" Value="922" />
                                        <telerik:RadComboBoxItem Text="923" Value="923" />
                                        <telerik:RadComboBoxItem Text="924" Value="924" />
                                        <telerik:RadComboBoxItem Text="925" Value="925" />
                                        <telerik:RadComboBoxItem Text="926" Value="926" />
                                        <telerik:RadComboBoxItem Text="927" Value="927" />
                                    </Items>
                                    <Localization AllItemsCheckedString="--all--" CheckAllString="--all--" />
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:CheckBox ID="CheckBoxPriceUnit" runat="server" CssClass="checkbox" Text="Đơn giá:" TextAlign="Left" />
                            </td>
                            <td align="left">
                                <telerik:RadComboBox ID="RadDropDownListPriceUnit" runat="server" CheckBoxes="true" EnableCheckAllItemsCheckBox="True" Skin="Hay" Width="90px">
                                    <Items>
                                        <telerik:RadComboBoxItem Text="1000" Value="1000" />
                                        <telerik:RadComboBoxItem Text="1500" Value="1500" />
                                        <telerik:RadComboBoxItem Text="2000" Value="2000" />
                                        <telerik:RadComboBoxItem Text="5000" Value="5000" />
                                        <telerik:RadComboBoxItem Text="15000" Value="15000" />
                                    </Items>
                                    <Localization AllItemsCheckedString="--all--" CheckAllString="--all--" />
                                </telerik:RadComboBox>
                            </td>
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
                                <asp:CheckBox ID="CheckBoxDate" runat="server" CssClass="checkbox" Text="Ngày:" TextAlign="Left" />
                                <asp:CheckBox ID="CheckBoxHour" runat="server" CssClass="checkbox" Text="Giờ:" TextAlign="Left" />
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
                                            <asp:Label ID="lblMO" runat="server" CssClass="label_parametter" Font-Italic="False">VMG (1):</asp:Label>
                                        </td>
                                        <td align="right" width="25%">
                                            <asp:Label ID="lblMoney_VMG" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td align="right" width="25%">
                                            <asp:Label ID="lblMO5" runat="server" CssClass="label_parametter" Font-Italic="False">Tổng số CDR:</asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblTotal_CDR" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblMO1" runat="server" CssClass="label_parametter" Font-Italic="False">VNM (2)</asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblMoney_VNM" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td align="right">
                                            &nbsp;</td>
                                        <td align="right">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblMO6" runat="server" CssClass="label_parametter" Font-Italic="False">NMS (3):</asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblMoney_NMS" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td align="right">
                                            &nbsp;</td>
                                        <td align="right">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblMO0" runat="server" CssClass="label_parametter" Font-Italic="False">Khách hàng (4):</asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblMoney_Ccare" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td align="center">
                                            &nbsp;</td>
                                        <td align="center">
                                            <asp:Label ID="lblMO15" runat="server" CssClass="label" Font-Italic="True">(1)+(2)+(3)=(4)</asp:Label>
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
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblDayOfWeek_Text" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "DayOfWeek_Text")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="TRẠNG THÁI">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblStatus_Text" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Status_Text")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="KÊNH DỊCH VỤ">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblChannel_Text" runat="server" CssClass="label"> <%# DataBinder.Eval(Container.DataItem, "Channel_Text")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="DỊCH VỤ">
                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblService_Text" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Service_Text")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                          <asp:TemplateColumn HeaderText="ĐẦU SỐ">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblAccess_Number" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Access_Number")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                         <asp:TemplateColumn HeaderText="ĐƠN GIÁ">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblPrice_Unit" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Price_Unit")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                         <asp:TemplateColumn HeaderText="CDR">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblCDR" runat="server" CssClass="label" Font-Bold="true" ForeColor="Red">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "CDR"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="DOANH THU K/H">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblMoney_Ccare" runat="server" CssClass="label" Font-Bold="true">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "Money_Ccare"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="VMG">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblMoney_VMG" runat="server" CssClass="label" Font-Bold="true" ForeColor="Blue">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "Money_VMG"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="VNM">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblMoney_VNM" runat="server" CssClass="label" Font-Bold="true">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "Money_VNM"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="NMS">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblMoney_NMS" runat="server" CssClass="label" Font-Bold="true" >   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "Money_NMS"), 0)%></asp:Label>
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
