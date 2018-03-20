<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MGameKpi.aspx.vb" Inherits="Prjs.Portal.Report.MGameKpi" %>

 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="ASPnetPagerV2_8" Namespace="ASPnetControls" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../../Styles/HQ.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/LightStyle.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/RadTreeView.css" type="text/css" rel="stylesheet" />

    <script language="javascript" type="text/javascript" src="../../../Js/Menu3.js"></script>

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
            width: 100%;
            border-collapse: collapse;
            border: 1px solid #FFFFFF;
            background-color: #2B7B69;
            font-family: Arial;
            font-size: 10px;
            color: white;	
            font-weight: bold;	
            text-align: center;
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

                <telerik:AjaxSetting AjaxControlID="RadDropListMobile_Operator">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadDropDownListService_Id" />
                    </UpdatedControls>
                </telerik:AjaxSetting>

            </AjaxSettings>
        </telerik:RadAjaxManager>
        <div id="HQ">
            <div class="alert">
                <asp:Label ID="lbltitle" runat="server" CssClass="lbltitle"></asp:Label><br />
                <asp:Label ID="lblerror" runat="server" CssClass="lblerror"></asp:Label>
            </div>


            <div class="input" style="width: 50%">
                <table width="100%">
                    <tr>
                        <td align="right" width="30%">
                            <asp:Label ID="lblTrang7" runat="server" CssClass="label">Từ ngày;</asp:Label>
                        </td>
                        <td align="left">
                            <telerik:RadDatePicker ID="RadDatePickerFromDate" Width="150px" runat="server" Skin="Hay" Culture="vi-VN">
                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" Skin="Hay"></Calendar>

                                <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                            </telerik:RadDatePicker>


                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblTrang8" runat="server" CssClass="label">Đến ngày:</asp:Label>
                        </td>
                        <td align="left">
                            <telerik:RadDatePicker ID="RadDatePickerToDate" Width="150px" runat="server" Skin="Hay" Culture="vi-VN">
                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" Skin="Hay"></Calendar>

                                <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                            </telerik:RadDatePicker>



                        </td>
                    </tr>
                    <tr>
                        <td align="right">&nbsp;</td>
                        <td align="left">
                            <asp:CheckBox ID="CheckBoxAllDate" runat="server" CssClass="checkbox" Text="Toàn thời gian" Checked="True" />



                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                                <asp:CheckBox ID="CheckBoxPartnerId" runat="server" CssClass="checkbox" Text="Đối tác:" TextAlign="Left" />
                        </td>
                        <td align="left">
                            <telerik:RadComboBox ID="RadDropDownListPartner" runat="server" CheckBoxes="true" EnableCheckAllItemsCheckBox="True" Skin="Hay" Width="60%">
                                 <Localization AllItemsCheckedString="--all--" CheckAllString="--all--" />
                            </telerik:RadComboBox>


                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                                <asp:CheckBox ID="CheckBoxPacket" runat="server" CssClass="checkbox" Text="Gói dịch vụ:" TextAlign="Left" />
                        </td>
                        <td align="left">
                            <telerik:RadComboBox ID="RadDropDownListPacket" runat="server" CheckBoxes="True" EnableCheckAllItemsCheckBox="True" Skin="Hay" Width="40%">
                                 <Items>
                                     <telerik:RadComboBoxItem runat="server" Text="Tải game" Value="1" />
                                     <telerik:RadComboBoxItem runat="server" Text="Gói ngày" Value="2" />
                                     <telerik:RadComboBoxItem runat="server" Text="Gói tuần" Value="3" />
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

            <div class="pager">
                <cc1:PagerV2_8 ID="pager1" runat="server" OnCommand="pager_Command" GenerateGoToSection="true"
                    Font-Size="10pt" PageSize="50" />

            </div>
                   <div class="datagrid">
                      
                        </div>
            <div class="datagrid">
          <table cellpadding="0" class="auto-style1" id="TableBound" runat="server">
                           <tr >
                               <td rowspan="2" width="2%">#</td>
                               <td rowspan="2" width="5%">NGÀY</td>
                               <td rowspan="2" width="5%">ĐỐI TÁC</td>
                               <td rowspan="2" width="5%">GÓI</td>
                               <td rowspan="2" width="5%">THUÊ BAO LŨY KẾ</td>
                               <td rowspan="2" width="5%">HỦY LŨY KẾ</td>
                               <td rowspan="2" width="5%">TỔNG LƯỢT TẢI</td>
                               <td colspan="3" width="15%">ĐĂNG KÝ MỚI</td>
                               <td colspan="3" width="15%">THUÊ BAO HỦY</td>
                               <td colspan="3" width="15%">GIAN HẠN</td>
                                <td colspan="3"  width="15%">DOANH THU</td>
                               
                           </tr>
                           <tr>
                               <td width="5%"> <asp:Label ID="Label0" runat="server" CssClass="label"  Font-Bold="false">SMS</asp:Label></td>
                               <td width="5%"><asp:Label ID="Label1" runat="server" CssClass="label"  Font-Bold="false"> WAP</asp:Label></td>
                               <td width="5%"><asp:Label ID="Label2" runat="server" CssClass="label"  Font-Bold="false">TỔNG</asp:Label></td>
                               <td width="5%"><asp:Label ID="Label3" runat="server" CssClass="label"  Font-Bold="false">SMS</asp:Label></td>
                               <td width="5%"><asp:Label ID="Label4" runat="server" CssClass="label"  Font-Bold="false">WAP</asp:Label></td>
                                <td width="5%"><asp:Label ID="Label5" runat="server" CssClass="label"  Font-Bold="false">TỔNG</asp:Label></td>
                                <td width="5%"><asp:Label ID="Label11" runat="server" CssClass="label"  Font-Bold="false">THÀNH CÔNG</asp:Label></td>
                                <td width="5%"><asp:Label ID="Label7" runat="server" CssClass="label"  Font-Bold="false">THẤT BẠI</asp:Label></td>
                                <td width="5%"><asp:Label ID="Label8" runat="server" CssClass="label"  Font-Bold="false">TỔNG</asp:Label></td>
                                <td width="5%"><asp:Label ID="Label9" runat="server" CssClass="label"  Font-Bold="false">TẢI GAME</asp:Label></td>
                                <td width="5%"><asp:Label ID="Label10" runat="server" CssClass="label"  Font-Bold="false">GIA HẠN</asp:Label></td>
                                <td width="5%"><asp:Label ID="Label6" runat="server" CssClass="label"  Font-Bold="false">TỔNG</asp:Label></td>
                           </tr>
                       </table>
                <asp:DataGrid ID="DataGrid" runat="server" AllowPaging="True" AutoGenerateColumns="false"
                    CellPadding="0" CssClass="datagrid" EnableViewState="False" GridLines="None"
                    PagerStyle-Mode="NextPrev" PagerStyle-Visible="true" Width="100%" PageSize="50"  ShowHeader="false" >
                    <HeaderStyle CssClass="datagridHeader"   />
                    <AlternatingItemStyle CssClass="datagridAlternatingItemStyle" />
                    <ItemStyle CssClass="datagridItemStyle" />
                    <Columns>
                        <asp:TemplateColumn>
                            <HeaderStyle HorizontalAlign="Center"  />
                            <ItemStyle HorizontalAlign="Center" Width="2%"/>
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
                                <asp:Label ID="lblNGAY" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "NGAY")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="TEN_DOI_TAC">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblTEN_DOI_TAC" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "TEN_DOI_TAC")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                          <asp:TemplateColumn HeaderText="MA">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblMA" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Loai_Goi")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="THUE_BAO_LUY_KE">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblTHUE_BAO_LUY_KE" runat="server" CssClass="label" Font-Bold="true" ForeColor="Blue">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "THUE_BAO_LUY_KE"),0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                           <asp:TemplateColumn HeaderText="TONG_HUY_LUY_KE">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblTONG_HUY_LUY_KE" runat="server" CssClass="label" Font-Bold="true"  >   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "TONG_HUY_LUY_KE"),0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                         <asp:TemplateColumn HeaderText="TONG_LUOT_TAI_GAME">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblTONG_LUOT_TAI_GAME" runat="server" CssClass="label" Font-Bold="true"  >   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "TONG_LUOT_TAI_GAME"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="DANG_KY_MOI_SMS">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblDANG_KY_MOI_SMS" runat="server" CssClass="label">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "DANG_KY_MOI_SMS"),0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="DANG_KY_MOI_WAP">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblDANG_KY_MOI_WAP" runat="server" ><%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "DANG_KY_MOI_WAP"),0)%>  </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="TONG_DANG_KY_MOI">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                   <asp:Label ID="lblTONG_DANG_KY_MOI" runat="server" CssClass="label" Font-Bold="true" ForeColor="red"> <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "TONG_DANG_KY_MOI"), 0)%> </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                       <asp:TemplateColumn HeaderText="HUY_SMS">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                   <asp:Label ID="lblHUY_SMS" runat="server" CssClass="label"> <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "HUY_SMS"),0)%> </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                           <asp:TemplateColumn HeaderText="HUY_WAP">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                   <asp:Label ID="lblHUY_WAP" runat="server" CssClass="label"> <%# DataBinder.Eval(Container.DataItem, "HUY_WAP")%> </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                           <asp:TemplateColumn HeaderText="TONG_HUY">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                   <asp:Label ID="lblTONG_HUY" runat="server" CssClass="label" Font-Bold="true" ForeColor="red"> <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "TONG_HUY"), 0)%> </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                          <asp:TemplateColumn HeaderText="GIA_HAN_THANH_CONG">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                   <asp:Label ID="lblGIA_HAN_THANH_CONG" runat="server" CssClass="label"> <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "GIA_HAN_THANH_CONG"),0)%> </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                              <asp:TemplateColumn HeaderText="GIA_HAN_THAT_BAI">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                   <asp:Label ID="lblGIA_HAN_THAT_BAI" runat="server" CssClass="label"> <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "GIA_HAN_THAT_BAI"),0)%> </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                       <asp:TemplateColumn HeaderText="TONG_GIA_HAN">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                   <asp:Label ID="lblTONG_GIA_HAN" runat="server" CssClass="label" Font-Bold="true" ForeColor="red"> <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "TONG_GIA_HAN"),0)%> </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                          <asp:TemplateColumn HeaderText="TONG_TIEN_TU_DANG_KY">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                   <asp:Label ID="lblTONG_TIEN_TU_TAI_GAME" runat="server" CssClass="label"> <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "TONG_TIEN_TU_TAI_GAME"),0)%> </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                          <asp:TemplateColumn HeaderText="TONG_TIEN_TU_GIA_HAN">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                   <asp:Label ID="lblTONG_TIEN_TU_GIA_HAN" runat="server" CssClass="label"> <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "TONG_TIEN_TU_GIA_HAN"),0)%> </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                          <asp:TemplateColumn HeaderText="TONG_DOANH_THU">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                   <asp:Label ID="lblTONG_DOANH_THU" runat="server" CssClass="label" Font-Bold="true" ForeColor="Black"> <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "TONG_DOANH_THU"), 0)%> </asp:Label>
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
