<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CcareReportImport.aspx.vb" Inherits="Prjs.Portal.Report.CcareReportImport" %>
<%@ Register Assembly="ASPnetPagerV2_8" Namespace="ASPnetControls" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../../Styles/HQ.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/LightStyle.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../../Js/Menu.js"></script>

    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
         
        <telerik:RadAjaxManager ID="AjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="DropDownListPARTNER_ID">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="DropDownListBRAND_NAME" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="DropDownListPROVINCE_ID">
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
          <div id="HQ">
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            </telerik:RadScriptManager>
            <div class="alert">
                <asp:Label ID="lbltitle" runat="server" CssClass="lbltitle"></asp:Label><br />
                <asp:Label ID="lblerror" runat="server" CssClass="lblerror"></asp:Label>
            </div>
               <div class="parametter" style="width: 90%;">
                <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                        <tr>
                            <td align="right" width="15%">
                                <asp:Label ID="Label43" runat="server" CssClass="label">Từ ngày:</asp:Label>
                            </td>
                            <td align="left" width="35%">
                                <table cellpadding="0" cellspacing="0" width="100%"  >
                                    <tr>
                                        <td width="120px">
                                    <telerik:RadDatePicker ID="RadFromDate" rMinDate="2006/01/01" runat="server"
                                        ZIndex="30001" Culture="vi-VN" Skin="Forest" Width="125px">
                                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"
                                            Skin="Forest">
                                        </Calendar>

                                        <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

                                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                    </telerik:RadDatePicker>
                                        </td>
                                        <td align="center" width="50px">
                                <asp:Label ID="Label44" runat="server" CssClass="label">đến ngày:</asp:Label>
                                        </td>
                                        <td>
                                    <telerik:RadDatePicker ID="RadToDate" rMinDate="2006/01/01" runat="server"
                                        ZIndex="30001" Culture="vi-VN" Skin="Forest" Width="125px">
                                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"
                                            Skin="Forest">
                                        </Calendar>

                                        <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

                                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                    </telerik:RadDatePicker>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="15%" align="right">
                                            <asp:CheckBox ID="CheckBoxMOBILE_OPERATOR" runat="server" CssClass="checkbox" Text="Mạng:" TextAlign="Left" />
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DropDownListMOBILE_OPERATOR" runat="server" CssClass="droplist">
                                    <asp:ListItem Value="--all--">--all--</asp:ListItem>
                                    <asp:ListItem>VIETTEL</asp:ListItem>
                                    <asp:ListItem>VMS</asp:ListItem>
                                    <asp:ListItem>VNM</asp:ListItem>
                                    <asp:ListItem>VNP</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                            <asp:CheckBox ID="CheckBoxPARTNER_ID" runat="server" CssClass="checkbox" Text="Đối tác:" TextAlign="Left" />
                            </td>
                            <td align="left" width="35%">
                                <asp:DropDownList ID="DropDownListPARTNER_ID" runat="server" CssClass="droplist" Font-Bold="True" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                            <td width="15%" align="right">
                                            <asp:CheckBox ID="CheckBoxUSER_ID" runat="server" CssClass="checkbox" Text="Số điện thoại:" TextAlign="Left" />
                            </td>
                            <td align="left">

                                <asp:TextBox ID="txtUSER_ID" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="50%" Font-Bold="True" ForeColor="#0033CC"></asp:TextBox>

                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                            <asp:CheckBox ID="CheckBoxBRAND_NAME" runat="server" CssClass="checkbox" Text="Brand:" TextAlign="Left" />
                            </td>
                            <td align="left" width="35%">
                                <table cellpadding="0"  cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                <asp:DropDownList ID="DropDownListBRAND_NAME" runat="server" CssClass="droplist">
                                    <asp:ListItem Value="0">--all--</asp:ListItem>
                                </asp:DropDownList>
                                        </td>
                                        <td width="20%">
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                            <td width="15%" align="right">
                                            <asp:CheckBox ID="CheckBoxSEX_TEXT" runat="server" CssClass="checkbox" Text="Giới tính:" TextAlign="Left" />
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DropDownListSEX" runat="server" CssClass="droplist">
                                    <asp:ListItem Value="-1">--all--</asp:ListItem>
                                    <asp:ListItem Value="1">Nam</asp:ListItem>
                                    <asp:ListItem Value="2">Nữ</asp:ListItem>
                                    <asp:ListItem Value="0">Chưa xác định</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                            <asp:CheckBox ID="CheckBoxKEY_WORD" runat="server" CssClass="checkbox" Text="Từ khóa:" TextAlign="Left" />
                            </td>
                            <td align="left" width="35%">
                               <table cellpadding="0"  cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                <asp:TextBox ID="txtKEY_WORD" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="98%" Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td width="20%">
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                            <td width="15%" align="right">
                                            <asp:CheckBox ID="CheckBoxPROVINCE_TEXT" runat="server" CssClass="checkbox" Text="Tỉnh thành:" TextAlign="Left" />
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DropDownListPROVINCE_ID" runat="server" CssClass="droplist">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                            <asp:CheckBox ID="CheckBoxGROUP_TEXT" runat="server" CssClass="checkbox" Text="Mã nhóm:" TextAlign="Left" />
                            </td>
                            <td align="left" width="35%">
                                <table cellpadding="0"  cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                <asp:TextBox ID="txtGROUP_TEXT" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="98%" Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td width="20%">
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                            <td width="15%" align="right">
                                            <asp:CheckBox ID="CheckBoxFEES_TEXT" runat="server" CssClass="checkbox" Text="Mức cước:" TextAlign="Left" />
                            </td>
                            <td align="left">

                                <asp:DropDownList ID="DropDownListFEES_ID" runat="server" CssClass="droplist">
                                </asp:DropDownList>

                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                            <asp:CheckBox ID="CheckBoxSOURCE_TEXT" runat="server" CssClass="checkbox" Text="Nguồn dữ liệu:" TextAlign="Left" />
                            </td>
                            <td align="left" width="35%">

                                <asp:DropDownList ID="DropDownListSOURCE_ID" runat="server" CssClass="droplist">
                                </asp:DropDownList>

                            </td>
                            <td width="15%" align="right">
                                            <asp:CheckBox ID="CheckBoxINCOME_TEXT" runat="server" CssClass="checkbox" Text="Mức thu nhập:" TextAlign="Left" />
                            </td>
                            <td align="left">

                          
                                <asp:DropDownList ID="DropDownListINCOME_ID" runat="server" CssClass="droplist">
                                </asp:DropDownList>

                          
                            </td>
                        </tr>
                        <tr>
                            <td align="right"  >
                                            <asp:CheckBox ID="CheckBoxSTATUS_TEXT" runat="server" CssClass="checkbox" Text="Trạng thái:" TextAlign="Left" />
                            </td>
                            <td align="left"  >
                                <asp:DropDownList ID="DropDownListSTATUS_ID" runat="server" CssClass="droplist">
                                    <asp:ListItem Value="0">--all--</asp:ListItem>
                                    <asp:ListItem Value="1">New</asp:ListItem>
                                    <asp:ListItem Value="2">Call</asp:ListItem>
                                    <asp:ListItem Value="3">Invalid</asp:ListItem>
                                    <asp:ListItem Value="4">Done</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="right"  >
                                            <asp:CheckBox ID="CheckBoxEXACTLY_RATE" runat="server" CssClass="checkbox" Text="Độ chính xác:" TextAlign="Left" />
                            </td>
                            <td align="left"  >
                                <asp:DropDownList ID="DropDownListEXACTLY_RATE_NUMBER" runat="server" CssClass="droplist">
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td align="right"  >
                                &nbsp;</td>
                            <td align="left"  >

                                &nbsp;</td>
                            <td align="right"  >
                                <asp:Label ID="Label54" runat="server" CssClass="label">Tổng số:</asp:Label>
                            </td>
                            <td align="left"  >
                                <a class="cateGrid" href="javascript:showSubcat('3');">
                                <asp:Label ID="lblTotal" runat="server"   CssClass="label" ForeColor="red"> </asp:Label></a>
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
                        <asp:TemplateColumn HeaderText="NĂM">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblYEAR" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "YEAR")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                          <asp:TemplateColumn HeaderText="TRẠNG THÁI">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                
                                <asp:Label ID="lblSTATUS_TEXT" runat="server" CssClass="label"><%# DataBinder.Eval(Container.DataItem, "STATUS_TEXT")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                          <asp:TemplateColumn HeaderText="MẠNG">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                <asp:Label ID="lblMOBILE_OPERATOR" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "MOBILE_OPERATOR")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                              <asp:TemplateColumn HeaderText="ĐỐI TÁC">
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblPARTNER_TEXT" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "PARTNER_TEXT")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="BRAND">
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblBRAND_NAME" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "BRAND_NAME")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="TỪ KHÓA">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <asp:Label ID="lblKEY_WORD" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "KEY_WORD")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                              <asp:TemplateColumn HeaderText="NHÓM">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <asp:Label ID="lblGROUP_TEXT" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "GROUP_TEXT")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="NGUỒN DỮ LIỆU">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <asp:Label ID="lblSOURCE_TEXT" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "SOURCE_TEXT")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                      
                      
                        <asp:TemplateColumn HeaderText="SỐ ĐIỆN THOẠI">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <asp:Label ID="lblUSER_ID" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "USER_ID")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                               <asp:TemplateColumn HeaderText="GIỚI TÍNH">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                <asp:Label ID="lblSEX_TEXT" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "SEX_TEXT")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                             <asp:TemplateColumn HeaderText="TỈNH THÀNH">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                <asp:Label ID="lblPROVINCE_TEXT" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "PROVINCE_TEXT")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                             <asp:TemplateColumn HeaderText="MỨC CƯỚC">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                <asp:Label ID="lblFEES_TEXT" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "FEES_TEXT")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="THU NHẬP">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                <asp:Label ID="lblINCOME_TEXT" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "INCOME_TEXT")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="ĐỘ CHÍNH XÁC">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                <asp:Label ID="lblEXACTLY_RATE" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "EXACTLY_RATE")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                           <asp:TemplateColumn HeaderText="TỔNG">
                            <ItemStyle HorizontalAlign="Right" Width="5%" />
                            <ItemTemplate>
                                <asp:Label ID="lblTOTAL" runat="server" CssClass="label" Font-Bold="true">   <%#  Utils_1.FormatDecimal(DataBinder.Eval(Container.DataItem, "TOTAL"),0)%></asp:Label>
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