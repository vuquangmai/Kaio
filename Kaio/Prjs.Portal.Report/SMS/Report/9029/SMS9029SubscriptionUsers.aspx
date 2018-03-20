<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SMS9029SubscriptionUsers.aspx.vb" Inherits="Prjs.Portal.Report.SMS9029SubscriptionUsers" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="ASPnetPagerV2_8" Namespace="ASPnetControls" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../../../Styles/HQ.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/LightStyle.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .RadPicker {
            vertical-align: middle;
        }

        .RadPicker {
            vertical-align: middle;
        }

        .RadPicker {
            vertical-align: middle;
        }

        .RadPicker {
            vertical-align: middle;
        }

            .RadPicker .rcTable {
                table-layout: auto;
            }

            .RadPicker .rcTable {
                table-layout: auto;
            }

            .RadPicker .rcTable {
                table-layout: auto;
            }

            .RadPicker .rcTable {
                table-layout: auto;
            }

            .RadPicker .RadInput {
                vertical-align: baseline;
            }

            .RadPicker .RadInput {
                vertical-align: baseline;
            }

            .RadPicker .RadInput {
                vertical-align: baseline;
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

        .RadInput {
            vertical-align: middle;
            width: 160px;
        }

        .RadInput_Default {
            font: 12px "segoe ui",arial,sans-serif;
        }

        .RadInput {
            vertical-align: middle;
            width: 160px;
        }

        .RadInput_Default {
            font: 12px "segoe ui",arial,sans-serif;
        }

        .RadInput {
            vertical-align: middle;
            width: 160px;
        }

        .RadInput_Default {
            font: 12px "segoe ui",arial,sans-serif;
        }

        .RadInput {
            vertical-align: middle;
            width: 160px;
        }

        .RadInput_Default {
            font: 12px "segoe ui",arial,sans-serif;
        }

        .RadInput {
            vertical-align: middle;
            width: 160px;
        }

        .RadInput_Default {
            font: 12px "segoe ui",arial,sans-serif;
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
        </telerik:RadAjaxManager>
        <div id="HQ">
            <div class="alert">
                <asp:Label ID="lblTitle" runat="server" CssClass="lbltitle"></asp:Label><br />
                <asp:Label ID="lblerror" runat="server" CssClass="lblerror"></asp:Label>
            </div>
            <div class="parametter">
                <table width="100%">
                    <tr>
                        <td align="right" width="20%">
                            <asp:Label ID="lblTrang7" runat="server" CssClass="label">Từ ngày:</asp:Label>
                        </td>
                        <td align="left" width="30%">
                            <telerik:RadDatePicker ID="RadFromDate" rMinDate="2006/01/01" runat="server"
                                ZIndex="30001" Culture="vi-VN" Skin="Forest">
                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"
                                    Skin="Forest">
                                </Calendar>

                                <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                            </telerik:RadDatePicker>
                        </td>
                        <td align="right" width="20%">
                            <asp:CheckBox ID="CheckBoxPartnerId" runat="server"
                                CssClass="checkbox" Text="Đối tác:"
                                TextAlign="Left" />
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListPartnerId" runat="server" CssClass="droplist">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="15%">
                            <asp:Label ID="lblTrang8" runat="server" CssClass="label">Đến ngày:</asp:Label>
                        </td>
                        <td align="left" width="35%">
                            <telerik:RadDatePicker ID="RadToDate" rMinDate="2006/01/01" runat="server"
                                ZIndex="30001" Culture="vi-VN" Skin="Forest">
                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"
                                    Skin="Forest">
                                </Calendar>

                                <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                            </telerik:RadDatePicker>
                        </td>
                        <td align="right" width="15%">
                            <asp:CheckBox ID="CheckBoxChannel" runat="server" CssClass="checkbox" Text="Kênh:"
                                TextAlign="Left" />
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListChannel" runat="server" CssClass="droplist">
                                <asp:ListItem>--all--</asp:ListItem>
                                <asp:ListItem>SMS</asp:ListItem>
                                <asp:ListItem>WAP</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">&nbsp;
                        </td>
                        <td align="char">

                            <asp:CheckBox ID="CheckBoxAllDate" runat="server" CssClass="checkbox"
                                Text="Toàn thời gian" />

                        </td>
                        <td align="right">
                            <asp:CheckBox ID="CheckBoxUser" runat="server" CssClass="checkbox" Text="Khách hàng:"
                                TextAlign="Left" />
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtMsisdn" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="80%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblTrang12" runat="server" CssClass="label">Trạng thái:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListStatus" runat="server" CssClass="droplist">
                                <asp:ListItem Value="1">Active</asp:ListItem>
                                <asp:ListItem Value="0">Inactive</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            <asp:CheckBox ID="CheckBoxKeyword" runat="server" CssClass="checkbox" Text="Mã:"
                                TextAlign="Left" />
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtKeyword" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="80%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                                <asp:Label ID="Label4" runat="server" CssClass="label">Tổng số :</asp:Label></td>
                        <td align="left">
                            <asp:Label ID="lblTotal" runat="server" CssClass="label" Font-Bold="False"
                                ForeColor="Blue"></asp:Label>
                        </td>
                        <td align="right">
                            <asp:CheckBox ID="CheckBoxMonth" runat="server" CssClass="checkbox" Text="Tháng:"
                                TextAlign="Left" />
                        </td>
                        <td align="left">
                            <asp:CheckBox ID="CheckBoxDate" runat="server" CssClass="checkbox" Text="Ngày:" TextAlign="Left" />
                            <asp:CheckBox ID="CheckBoxHour" runat="server" CssClass="checkbox" Text="Giờ:" TextAlign="Left" />
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
           
            </div>
            <div class="pager">
                <cc1:PagerV2_8 ID="pager1" runat="server" OnCommand="pager_Command" GenerateGoToSection="true"
                    Font-Size="10pt" PageSize="50" />

            </div>
            <div class="datagrid">
                <asp:DataGrid ID="DataGrid" runat="server" AutoGenerateColumns="false" CellPadding="0"
                    CssClass="datagrid" EnableViewState="False" GridLines="None" PagerStyle-Mode="NextPrev"
                    PagerStyle-Visible="true" Width="100%" PageSize="50">
                    <HeaderStyle CssClass="datagridHeader" />
                    <AlternatingItemStyle CssClass="datagridAlternatingItemStyle" />
                    <ItemStyle CssClass="datagridItemStyle" />
                    <Columns>
                        <asp:TemplateColumn>
                            <HeaderTemplate>
                                #
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblOrder" runat="server" CssClass="label"
                                    Text="<%# Container.ItemIndex+1 %>"> </asp:Label>
                            </ItemTemplate>

                            <HeaderStyle HorizontalAlign="Center" Width="2%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="NĂM">
                            <ItemTemplate>
                                <%#DataBinder.Eval(Container.DataItem, "vyear")%>
                            </ItemTemplate>
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="THÁNG">
                            <ItemTemplate>
                                <%#DataBinder.Eval(Container.DataItem, "month")%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="NGÀY">
                            <ItemTemplate>
                                <%#DataBinder.Eval(Container.DataItem, "day")%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="GIỜ">
                            <ItemTemplate>
                                <%#DataBinder.Eval(Container.DataItem, "hour")%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="KHÁCH HÀNG">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "MSISDN")%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="MÃ">
                            <ItemTemplate>
                                <%#DataBinder.Eval(Container.DataItem, "Detail")%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="KÊNH">
                            <ItemTemplate>
                                <%#DataBinder.Eval(Container.DataItem, "RegisterChannel")%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="ĐỐI TÁC">
                            <ItemTemplate>
                                <%#DataBinder.Eval(Container.DataItem, "PartnerName")%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="TỔNG SỐ">
                            <ItemTemplate>
                                <asp:Label ID="lbltotalMoneyVMG" runat="server" Font-Bold="true" ForeColor="Blue">         <%#Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "total"), 0)%></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="10%" />
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
