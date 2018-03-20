<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="S2KpiViSportVNM.aspx.vb" Inherits="Prjs.Portal.Report.S2KpiViSportVNM" %>


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

        .RadPicker {
            vertical-align: middle;
        }

            .RadPicker .rcTable {
                table-layout: auto;
            }

            .RadPicker .RadInput {
                vertical-align: baseline;
            }

        .RadInput_Default {
            font: 12px "segoe ui",arial,sans-serif;
        }

        .RadInput {
            vertical-align: middle;
            width: 160px;
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
                        <td align="right" width="15%">
                            <asp:Label ID="lblTrang11" runat="server" CssClass="label">Từ ngày:</asp:Label>
                        </td>
                        <td align="left" width="25%">
                            <telerik:RadDatePicker ID="RadDatePickerFromDate" Width="150px" runat="server" Skin="Hay" Culture="vi-VN">
                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" Skin="Hay"></Calendar>

                                <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                            </telerik:RadDatePicker>


                        </td>
                        <td align="right" width="15%">
                            <asp:CheckBox ID="CheckBoxPartnerId" runat="server" CssClass="checkbox" Text="Đối tác:"
                                TextAlign="Left" />
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListPartner" runat="server" CssClass="droplist">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="15%">
                            <asp:Label ID="lblTrang7" runat="server" CssClass="label">Đến ngày:</asp:Label>
                        </td>
                        <td align="left">
                            <telerik:RadDatePicker ID="RadDatePickerToDate" Width="150px" runat="server" Skin="Hay" Culture="vi-VN">
                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" Skin="Hay"></Calendar>

                                <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                            </telerik:RadDatePicker>



                        </td>
                        <td align="right" width="15%">
                            <asp:CheckBox ID="CheckBoxPackage" runat="server" CssClass="checkbox" Text="Gói:"
                                TextAlign="Left" />
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListPackage" runat="server" CssClass="droplist">
                                <asp:ListItem>--all--</asp:ListItem>
                                <asp:ListItem Value="1">NGÀY</asp:ListItem>
                                <asp:ListItem Value="2">TUẦN</asp:ListItem>
                                <asp:ListItem Value="3">THÁNG</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="15%">&nbsp;</td>
                        <td align="left">
                            <asp:CheckBox ID="CheckBoxAllDate" runat="server" CssClass="checkbox"
                                Text="Toàn thời gian" />
                        </td>
                        <td align="right" width="15%">
                            <asp:CheckBox ID="CheckBoxCode" runat="server" CssClass="checkbox" Text="Mã:"
                                TextAlign="Left" />
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtCode" runat="server"
                                AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="50%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td align="left">&nbsp;</td>
                        <td align="right">
                            <asp:CheckBox ID="CheckBoxDate" runat="server" CssClass="checkbox" Text="Ngày:"
                                TextAlign="Left" />
                        </td>
                        <td align="left">&nbsp;
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
             <div class="submmit">
                      <fieldset id="fieldset" class="fieldset_data_info">
                   <table width="40%">
                            <tr>
                                <td width="25%" align="left">
                                   
                                        <asp:Label ID="Label12" runat="server" CssClass="label">Tổng User(Thuê bao lũy kế):</asp:Label> 
                                </td>
                                <td width="30%" align="left">
                                    <asp:Label ID="lblTotalUser" runat="server" CssClass="label" 
                                        Font-Bold="True" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="25%">
                                    
                                        <asp:Label ID="Label14" runat="server" CssClass="label">Tổng doanh thu khách hàng:</asp:Label> 
                                </td>
                                <td align="left" width="25%">
                                    <asp:Label ID="lblTotalMoney" runat="server" CssClass="label" 
                                        Font-Bold="True"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" width="25%">
                               
                                        <asp:Label ID="Label16" runat="server" CssClass="label">Doanh thu VMG:</asp:Label> </td>
                                <td align="left" width="25%">
                                    <asp:Label ID="lblTotalMoneyVMG" runat="server" CssClass="label" 
                                        Font-Bold="True" ForeColor="#0033CC"></asp:Label>
                                </td>
                            </tr>
                        </table>
                          </fieldset>
             </div>
            <div class="pager">
                <cc1:PagerV2_8 ID="pager1" runat="server" OnCommand="pager_Command" GenerateGoToSection="true"
                    Font-Size="10pt" PageSize="50" />

            </div>

            <div class="datagrid">
                 <table cellpadding="0" cellspacing="0" class="auto-style1" border="1" width="100%">
                        <tr>
                            <td rowspan="2" width="5%">
                                NGÀY
                            </td>
                            <td rowspan="2" width="8%">
                                ĐỐI TÁC
                            </td>
                            <td rowspan="2" width="4%">
                                GÓI
                            </td>
                            <td rowspan="2" width="4%">
                                MÃ
                            </td>
                            <td rowspan="2" width="5%">
                                THUÊ BAO LŨY KẾ
                            </td>
                            <td rowspan="2" width="5%">
                                SỐ MT
                            </td>
                            <td colspan="3" width="12%">
                                ĐĂNG KÝ MỚI
                            </td>
                            <td colspan="3" width="12%">
                                THUÊ BAO HỦY
                            </td>
                            <td colspan="2" width="10%">
                                GIA HẠN
                            </td>
                            <td colspan="4" width="20%">
                                DOANH THU
                            </td>
                        </tr>
                        <tr>
                            <td width="4%">
                                <asp:Label ID="Label0" runat="server" CssClass="label" Font-Bold="false">SMS</asp:Label>
                            </td>
                            <td width="4%">
                                <asp:Label ID="Label1" runat="server" CssClass="label" Font-Bold="false"> WAP</asp:Label>
                            </td>
                            <td width="4%">
                                <asp:Label ID="Label2" runat="server" CssClass="label" Font-Bold="false">TỔNG</asp:Label>
                            </td>
                            <td width="4%">
                                <asp:Label ID="Label3" runat="server" CssClass="label" Font-Bold="false">SMS</asp:Label>
                            </td>
                            <td width="4%">
                                <asp:Label ID="Label4" runat="server" CssClass="label" Font-Bold="false">WAP</asp:Label>
                            </td>
                            <td width="5%">
                                <asp:Label ID="Label6" runat="server" CssClass="label" Font-Bold="false">TỔNG HỦY</asp:Label>
                            </td>
                            <td width="5%">
                                <asp:Label ID="Label5" runat="server" CssClass="label" Font-Bold="false">THÀNH CÔNG</asp:Label>
                            </td>
                            <td width="5%">
                                <asp:Label ID="Label8" runat="server" CssClass="label" Font-Bold="false">TỔNG</asp:Label>
                            </td>
                            <td width="5%">
                                <asp:Label ID="Label9" runat="server" CssClass="label" Font-Bold="false">ĐĂNG KÝ</asp:Label>
                            </td>
                            <td width="7%">
                                <asp:Label ID="Label10" runat="server" CssClass="label" Font-Bold="false">GIA HẠN</asp:Label>
                            </td>
                            <td width="7%">
                                <asp:Label ID="Label11" runat="server" CssClass="label" Font-Bold="false">TỔNG</asp:Label>
                            </td>
                            <td width="7%">
                                <asp:Label ID="Label7" runat="server" CssClass="label" Font-Bold="false">VMG</asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:DataGrid ID="DataGrid" runat="server" AllowPaging="True" AutoGenerateColumns="false"
                        CellPadding="0" CssClass="datagrid" EnableViewState="False" GridLines="None"
                        PagerStyle-Mode="NextPrev" PagerStyle-Visible="true" Width="100%" PageSize="120"
                        ShowHeader="false">
                        <HeaderStyle CssClass="datagridHeader" />
                        <AlternatingItemStyle CssClass="datagridAlternatingItemStyle" />
                        <ItemStyle CssClass="datagridItemStyle" />
                        <Columns>
                             
                            <asp:TemplateColumn HeaderText="NGÀY">
                                <ItemStyle Width="5%" HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblNGAY" runat="server" CssClass="label" Font-Size="10px">   <%# DataBinder.Eval(Container.DataItem, "NGAY")%></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="TEN_DOI_TAC">
                                <ItemStyle Width="8%" HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblTEN_DOI_TAC" runat="server" CssClass="label" Font-Size="10px">   <%# DataBinder.Eval(Container.DataItem, "TEN_DOI_TAC")%></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="TENGOI">
                                <ItemStyle Width="4%" HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblTENGOI" runat="server" CssClass="label" Font-Size="10px">   <%# DataBinder.Eval(Container.DataItem, "TENGOI")%></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="MA">
                                <ItemStyle Width="4%" HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblMA" runat="server" CssClass="label" Font-Size="10px">   <%# DataBinder.Eval(Container.DataItem, "MA")%></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="THUE_BAO_LUY_KE">
                                <ItemStyle Width="5%" HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:Label ID="lblTHUE_BAO_LUY_KE" runat="server" CssClass="label" Font-Bold="true"
                                        Font-Size="10px" ForeColor="Blue">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "THUE_BAO_LUY_KE"), 0)%></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="CDR">
                                <ItemStyle Width="5%" HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCDR" runat="server" CssClass="label" Font-Bold="true" Font-Size="10px">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "CDR"), 0)%></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="DANG_KY_MOI_SMS">
                                <ItemStyle Width="4%" HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDANG_KY_MOI_SMS" runat="server" CssClass="label" Font-Size="10px">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "DANG_KY_MOI_SMS"), 0)%></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="DANG_KY_MOI_WAP">
                                <ItemStyle Width="4%" HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDANG_KY_MOI_WAP" runat="server" Font-Size="10px"><%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "DANG_KY_MOI_WAP"), 0)%>  </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="TONG_DANG_KY_MOI">
                                <ItemStyle Width="4%" HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:Label ID="lblTONG_DANG_KY_MOI" runat="server" CssClass="label" Font-Bold="true"
                                        Font-Size="10px" ForeColor="red"> <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "TONG_DANG_KY_MOI"), 0)%> </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="HUY_SMS">
                                <ItemStyle Width="4%" HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:Label ID="lblHUY_SMS" runat="server" CssClass="label" Font-Size="10px"> <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "HUY_SMS"), 0)%> </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="HUY_WAP">
                                <ItemStyle Width="4%" HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:Label ID="lblHUY_WAP" runat="server" CssClass="label" Font-Size="10px"> <%# DataBinder.Eval(Container.DataItem, "HUY_WAP")%> </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="TONG_HUY">
                                <ItemStyle Width="5%" HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:Label ID="lblTONG_HUY" runat="server" CssClass="label" Font-Bold="true" ForeColor="red"
                                        Font-Size="10px"> <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "TONG_HUY"), 0)%> </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="GIA_HAN_THANH_CONG">
                                <ItemStyle Width="5%" HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:Label ID="lblGIA_HAN_THANH_CONG" runat="server" CssClass="label" Font-Size="10px"> <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "GIA_HAN_THANH_CONG"), 0)%> </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="TONG_GIA_HAN">
                                <ItemStyle Width="5%" HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:Label ID="lblTONG_GIA_HAN" runat="server" CssClass="label" Font-Bold="true"
                                        Font-Size="10px" ForeColor="red"> <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "TONG_GIA_HAN"), 0)%> </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="TONG_TIEN_TU_DANG_KY">
                                <ItemStyle Width="5%" HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:Label ID="lblTONG_TIEN_TU_DANG_KY" runat="server" CssClass="label" Font-Size="10px"> <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "TONG_TIEN_TU_DANG_KY"), 0)%> </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="TONG_TIEN_TU_GIA_HAN">
                                <ItemStyle Width="7%" HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:Label ID="lblTONG_TIEN_TU_GIA_HAN" runat="server" CssClass="label" Font-Size="10px"> <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "TONG_TIEN_TU_GIA_HAN"), 0)%> </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="TONG_DOANH_THU">
                                <ItemStyle Width="7%" HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:Label ID="lblTONG_DOANH_THU" runat="server" CssClass="label" Font-Bold="true"
                                        Font-Size="10px" ForeColor="Black"> <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "TONG_DOANH_THU"), 0)%> </asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="TONG_DOANH_THU_VMG">
                                <ItemStyle Width="7%" HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:Label ID="lblTONG_DOANH_THU_VMG" runat="server" CssClass="label" Font-Bold="true"
                                        Font-Size="10px" ForeColor="Red"> <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "TONG_DOANH_THU_VMG"), 0)%> </asp:Label>
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
