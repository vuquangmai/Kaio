<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ChelseaReport.aspx.vb" Inherits="Prjs.Portal.Report.ChelseaReport" %>

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
            <a href="javascript:showSubcat('1');">
                <img id="imgCat1" src="../../Images/collapse_thead.gif" border="0" alt="" />
            </a>
            <div id="divCat1" style="visibility: visible">
                <div class="input"  >
                    <table width="100%">
                        <tr>
                            <td align="right" width="15%">
                                <asp:Label ID="lblTrang7" runat="server" CssClass="label">Từ ngày;</asp:Label>
                            </td>
                            <td align="left" width="35%">
                              <telerik:RadDatePicker ID="RadDatePickerFromDate" Width="150px" runat="server" Skin="Hay" Culture="vi-VN">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" Skin="Hay"></Calendar>

<DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

<DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
        </telerik:RadDatePicker>


                            </td>
                            <td align="right" width="15%">
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
                            <td align="right">
                                <asp:CheckBox ID="CheckBoxMonth" runat="server" CssClass="checkbox" Text="Tháng:" TextAlign="Left" />


                            </td>
                            <td align="left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right">
                                &nbsp;</td>
                            <td align="left">
                                &nbsp;</td>
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
                                <table width="100%" cellpadding="4" cellspacing="2">
                                    <tr>
                                        <td width="25%">
                                            <asp:Label ID="lblMO1" runat="server" CssClass="label_parametter" Font-Italic="False">Tổng đăng ký (1):</asp:Label>
                                        </td>
                                        <td align="right" width="25%">
                                            <asp:Label ID="lblRegister_User_Date" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td align="left" width="25%">
                                            <asp:Label ID="lblMO5" runat="server" CssClass="label_parametter" Font-Italic="False">Doanh thu khách hàng:</asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblMoney_Ccare" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblMO0" runat="server" CssClass="label_parametter" Font-Italic="False">Tổng hủy (2):</asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblCancel_User_Date" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblMO6" runat="server" CssClass="label_parametter" Font-Italic="False">Tổng MO dự đoán:</asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblMO_Predicts_Date" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblMO16" runat="server" CssClass="label_parametter" Font-Italic="False">Tổng active (3):</asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblActive_User_Date" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lblMO17" runat="server" CssClass="label_parametter" Font-Italic="False">Tổng MO charge:</asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblMO_Charge_Date" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True" ForeColor="Blue"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblMO14" runat="server" CssClass="label" Font-Italic="True">(2)+(3)=(1)</asp:Label>
                                        </td>
                                        <td align="right">
                                            &nbsp;</td>
                                        <td align="left">
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
                  
                         <asp:TemplateColumn HeaderText="THÁNG">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblMonth" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Month")%></asp:Label>
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
                        <asp:TemplateColumn HeaderText="TỔNG USER">
                            <ItemStyle Width="10%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblTotal_User" runat="server" CssClass="label" Font-Bold="true" ><%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "Total_User"), 0)%>  </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                           <asp:TemplateColumn HeaderText="TỔNG ACTIVE">
                            <ItemStyle Width="10%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblTotal_Active_Userr" runat="server" CssClass="label"><%#Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "Total_Active_User"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                           <asp:TemplateColumn HeaderText="TỔNG HỦY">
                            <ItemStyle Width="10%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblTotal_Cancel_User" runat="server" CssClass="label"><%#Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "Total_Cancel_User"), 0)%>  </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="ĐK TRONG NGÀY">
                            <ItemStyle Width="10%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblRegister_User_Date" runat="server" CssClass="label" Font-Bold="true" ForeColor="Blue"> <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "Register_User_Date"), 0)%> </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="HỦY TRONG NGÀY">
                            <ItemStyle Width="10%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblCancel_User_Date" runat="server" CssClass="label" Font-Bold="true">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "Cancel_User_Date"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="MO DỰ ĐOÁN">
                            <ItemStyle Width="10%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblMO_Predicts_Date" runat="server" CssClass="label" Font-Bold="true">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "MO_Predicts_Date"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="MO CHARGE">
                            <ItemStyle Width="10%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblMO_Charge_Date" runat="server" CssClass="label" Font-Bold="true">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "MO_Charge_Date"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="DOANH THU">
                            <ItemStyle Width="10%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblMoney_Ccare" runat="server" CssClass="label" Font-Bold="true" ForeColor="Red">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "Money_Ccare"), 0)%></asp:Label>
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
