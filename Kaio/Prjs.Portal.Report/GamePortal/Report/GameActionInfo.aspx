<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="GameActionInfo.aspx.vb" Inherits="Prjs.Portal.Report.GameActionInfo" %>

 
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
                            <asp:Label ID="lblTrang9" runat="server" CssClass="label">Game:</asp:Label>
                        </td>
                        <td align="left">
                            <telerik:RadComboBox ID="RadDropDownListGameId" runat="server" CheckBoxes="true" EnableCheckAllItemsCheckBox="True" Skin="Hay" Width="60%">
                                 <Localization AllItemsCheckedString="--all--" CheckAllString="--all--" />
                            </telerik:RadComboBox>


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
                    Font-Size="10pt" PageSize="50" />

            </div>
                   <div class="datagrid">
                      
                        </div>
            <div class="datagrid">
          <table cellpadding="0" class="auto-style1">
                           <tr>
                               <td rowspan="2" width="3%">#</td>
                               <td rowspan="2" width="10%">NGÀY</td>
                               <td colspan="2" width="20%">LƯỢNG CÀI ĐẶT MỚI</td>
                               <td colspan="2" width="17%">SỐ LIỆU ĐĂNG KÝ</td>
                               <td rowspan="2" width="10%">LOGIN MỚI</td>
                               <td colspan="2"  width="20%">THÔNG TIN NẠP THẺ</td>
                                <td colspan="2"  width="20%">DOANH THU</td>
                           </tr>
                           <tr>
                               <td width="10%"> <asp:Label ID="Label0" runat="server" CssClass="label"  Font-Bold="false"> Không trùng mac_address </asp:Label></td>
                               <td width="10%"><asp:Label ID="Label1" runat="server" CssClass="label"  Font-Bold="false"> Trùng mac_address </asp:Label></td>
                               <td width="7%"><asp:Label ID="Label2" runat="server" CssClass="label"  Font-Bold="false"> Mới </asp:Label></td>
                               <td width="10%"><asp:Label ID="Label3" runat="server" CssClass="label"  Font-Bold="false"> Tổng cộng </asp:Label></td>
                               <td width="10%"><asp:Label ID="Label4" runat="server" CssClass="label"  Font-Bold="false"> Nạp lần đầu </asp:Label></td>
                               <td width="10%"><asp:Label ID="Label5" runat="server" CssClass="label"  Font-Bold="false"> Nạp trong ngày </asp:Label></td>
                                <td width="10%"><asp:Label ID="Label6" runat="server" CssClass="label"  Font-Bold="false"> Nạp lần đầu</asp:Label></td>
                               <td width="10%"><asp:Label ID="Label7" runat="server" CssClass="label"  Font-Bold="false">Nạp trong ngày</asp:Label></td>
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
                            <ItemStyle HorizontalAlign="Center" Width="3%"/>
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
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lbUser_ID" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "create_date")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="new_install_non_rp_mac">
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblnew_install_non_rp_mac" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "new_install_non_rp_mac")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="new_install_rp_mac">
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblnew_install_rp_mac" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "new_install_rp_mac")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="new_registered">
                            <ItemStyle Width="7%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblnew_registered" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "new_registered")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="total_registered">
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lbltotal_registered" runat="server" ><%# DataBinder.Eval(Container.DataItem, "total_registered")%>  </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="new_login">
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                   <asp:Label ID="lblnew_login" runat="server" CssClass="label"> <%# DataBinder.Eval(Container.DataItem, "new_login")%> </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                       <asp:TemplateColumn HeaderText="new_paying">
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                   <asp:Label ID="lblnew_paying" runat="server" CssClass="label"> <%# DataBinder.Eval(Container.DataItem, "new_paying")%> </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                           <asp:TemplateColumn HeaderText="new_paying_inc_old">
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                   <asp:Label ID="lblnew_paying_inc_old" runat="server" CssClass="label"> <%# DataBinder.Eval(Container.DataItem, "new_paying_inc_old")%> </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                           <asp:TemplateColumn HeaderText="new_paying_profit">
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                   <asp:Label ID="lblnew_paying_profit" runat="server" CssClass="label"> <%# DataBinder.Eval(Container.DataItem, "new_paying_profit")%> </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                          <asp:TemplateColumn HeaderText="new_paying_inc_old_profit">
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                   <asp:Label ID="lblnew_paying_inc_old_profit" runat="server" CssClass="label"> <%# DataBinder.Eval(Container.DataItem, "new_paying_inc_old_profit")%> </asp:Label>
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
