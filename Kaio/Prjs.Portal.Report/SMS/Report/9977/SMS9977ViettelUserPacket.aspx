<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SMS9977ViettelUserPacket.aspx.vb" Inherits="Prjs.Portal.Report.SMS9977ViettelUserPacket" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="ASPnetPagerV2_8" Namespace="ASPnetControls" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../../../Styles/HQ.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/LightStyle.css" rel="stylesheet" type="text/css" />
    
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Transparency="30"
            MinDisplayTime="500">
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            </telerik:RadScriptManager>
        </telerik:RadAjaxLoadingPanel>
        <telerik:RadAjaxManager ID="AjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
        </telerik:RadAjaxManager>
        <div id="HQ">
            <div class="alert">
                <asp:Label ID="lblTitle" runat="server" CssClass="lbltitle"></asp:Label><br />
                <asp:Label ID="lblerror" runat="server" CssClass="lblerror"></asp:Label>
            </div>
            <div class="parametter">
                <table width="100%">
                    <tr>
                        <td align="right" width="30%">
                            <asp:Label ID="lblTrang12" runat="server" CssClass="label">Từ ngày:</asp:Label>
                        </td>
                        <td align="left">

                            <telerik:RadDatePicker ID="RadFromDate" rMinDate="2006/01/01" runat="server"
                                ZIndex="30001" Culture="vi-VN" Skin="Forest">
                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"
                                    Skin="Forest">
                                </Calendar>

                                <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                            </telerik:RadDatePicker>

                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="30%">
                            <asp:Label ID="lblTrang13" runat="server" CssClass="label">Đến ngày:</asp:Label>
                        </td>
                        <td align="left">

                            <telerik:RadDatePicker ID="RadToDate" rMinDate="2006/01/01" runat="server"
                                ZIndex="30001" Culture="vi-VN" Skin="Forest">
                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"
                                    Skin="Forest">
                                </Calendar>

                                <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                            </telerik:RadDatePicker>

                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="30%">
                            <asp:Label ID="lblTrang9" runat="server" CssClass="label">Khách hàng:</asp:Label>
                        </td>
                        <td align="left">

                            <asp:TextBox ID="txtMsisdn" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="60%"></asp:TextBox>

                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblTrang10" runat="server" CssClass="label">Mã gói:</asp:Label>
                        </td>
                        <td align="left">

                            <asp:TextBox ID="txtPacket_Code" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="30%"></asp:TextBox>

                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblTrang11" runat="server" CssClass="label">Tổng số:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblTotal" runat="server" CssClass="lblerror"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>

            <div class="submmit">
                <asp:Button ID="btnSearching" runat="server" CssClass="btnbackground"
                    Text="Tìm kiếm" />
                <asp:Button ID="btnExport" runat="server" CssClass="btnbackground"
                    Text="Báo cáo" />
            </div>
            <div class="pager">
                <cc1:PagerV2_8 ID="pager1" runat="server" OnCommand="pager_Command" GenerateGoToSection="true"
                    Font-Size="10pt" PageSize="120" />

            </div>
            <div class="datagrid">

                <asp:DataGrid ID="DataGrid" runat="server" AutoGenerateColumns="false" CellPadding="0"
                    CssClass="datagrid" EnableViewState="False" GridLines="None" PagerStyle-Mode="NextPrev"
                    PagerStyle-Visible="true" Width="100%" PageSize="120">
                    <HeaderStyle CssClass="datagridHeader" />
                    <AlternatingItemStyle CssClass="datagridAlternatingItemStyle" />
                    <ItemStyle CssClass="datagridItemStyle" />
                    <Columns>
                        <asp:TemplateColumn>
                            <HeaderTemplate>
                                #
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblOrder" runat="server" Font-Names="Tahoma" Font-Size="8pt" ForeColor="DimGray"
                                    Text="<%# Container.ItemIndex+1 %>"> </asp:Label>
                            </ItemTemplate>

                            <HeaderStyle HorizontalAlign="Center" Width="2%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="KHÁCH HÀNG">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "msisdn")%>
                            </ItemTemplate>
                            <ItemStyle Width="10%" HorizontalAlign="Left" />
                        </asp:TemplateColumn>


                        <asp:TemplateColumn HeaderText="MÃ GÓI">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "packet_code")%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateColumn>

                        <asp:TemplateColumn HeaderText="THỜI GIAN ĐĂNG KÝ">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "register_date")%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="20%" />
                        </asp:TemplateColumn>
                          <asp:TemplateColumn HeaderText="THỜI GIAN HẾN HẠN">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "exp_date")%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="20%" />
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
