<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SMSDictIndexKeywordFilterList.aspx.vb" Inherits="Prjs.Portal.Report.SMSDictIndexKeywordFilterList" %>

<%@ Register Assembly="ASPnetPagerV2_8" Namespace="ASPnetControls" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../Styles/HQ.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/LightStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
        </telerik:RadStyleSheetManager>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Transparency="30"
            MinDisplayTime="500">
        </telerik:RadAjaxLoadingPanel>
        <telerik:RadAjaxManager ID="AjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="DropDownListRangeShortCode">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="DropDownListShortCode" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <div id="HQ">
            <div class="alert">
                <asp:Label ID="lbltitle" runat="server" CssClass="lbltitle"></asp:Label><br />
                <asp:Label ID="lblerror" runat="server" CssClass="lblerror"></asp:Label>
            </div>
            <div class="parametter" style="width: 70%">
                <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
                    <tr>
                        <td align="center">
                            <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
                                <tr>
                                    <td align="right" width="15%">
                                        <asp:Label ID="Label6" runat="server" CssClass="label">Từ ngày:</asp:Label>
                                    </td>
                                    <td align="left" width="35%">
                                        <telerik:RadDatePicker ID="RadFromDate" rMinDate="2006/01/01" runat="server"
                                            ZIndex="30001" Culture="vi-VN" Skin="Forest">
                                            <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"
                                                Skin="Forest">
                                            </Calendar>

                                            <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

                                            <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                        </telerik:RadDatePicker>
                                    </td>
                                    <td align="right" width="15%">
                                        <asp:Label ID="Label4" runat="server" CssClass="label">Dải số:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DropDownListRangeShortCode" runat="server" CssClass="droplist" Font-Bold="True" AutoPostBack="True">
                                            <asp:ListItem>--all--</asp:ListItem>
                                            <asp:ListItem>99x</asp:ListItem>
                                            <asp:ListItem>8x79</asp:ListItem>
                                            <asp:ListItem>8x99</asp:ListItem>
                                            <asp:ListItem>6x66</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label7" runat="server" CssClass="label">Đến ngày:</asp:Label>
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
                                    <td align="right">
                                        <asp:Label ID="Label2" runat="server" CssClass="label">Đầu số:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DropDownListShortCode" runat="server" CssClass="droplist" Font-Bold="False">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">&nbsp;</td>
                                    <td align="left">
                                        <asp:CheckBox ID="CheckBoxAllDate" runat="server" Checked="True" CssClass="checkbox" Text="Toàn thời gian" />
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="Label3" runat="server" CssClass="label">Mã filter:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtKeyWord" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                            Width="50%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label5" runat="server" CssClass="label">Trạng thái:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DropDownListStatus" runat="server" CssClass="droplist" Font-Bold="False" ForeColor="Red">
                                            <asp:ListItem Value="-1">--all--</asp:ListItem>
                                            <asp:ListItem Value="1">Duyệt</asp:ListItem>
                                            <asp:ListItem Value="0">Chờ duyệt</asp:ListItem>
                                            <asp:ListItem Value="2">Hủy</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="Label8" runat="server" CssClass="label">Tổng số:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblTotal" runat="server" CssClass="lblerror"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="submmit">
                <asp:Button ID="btnSearching" runat="server" CssClass="btnbackground"
                    Text="Tìm kiếm" />
                <asp:Button ID="btnExport" runat="server" CssClass="btnbackground"
                    Text="Báo cáo" />
                <asp:Button ID="btnAdd" runat="server" CssClass="btnbackground"
                    Text="Thêm" />
            </div>
            <div class="pager">
                <cc1:PagerV2_8 ID="pager1" runat="server" OnCommand="pager_Command" GenerateGoToSection="true"
                    Font-Size="10pt" PageSize="50" />

            </div>
            <div class="datagrid">

                <asp:DataGrid ID="DataGrid" runat="server" AllowPaging="True" AutoGenerateColumns="false"
                    CellPadding="0" CssClass="datagrid" EnableViewState="False" GridLines="None"
                    PagerStyle-Mode="NextPrev" PagerStyle-Visible="true" Width="100%" PageSize="30">
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

                        <asp:TemplateColumn HeaderText="MÃ">
                            <ItemStyle Width="15%" HorizontalAlign="Center" />
                            <ItemTemplate>

                                <asp:Label ID="keyword" runat="server" CssClass="label" Font-Bold="true"> <%# DataBinder.Eval(Container.DataItem, "keyword")%>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>

                        <asp:TemplateColumn HeaderText="ĐẦU SỐ">
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "shortcode")%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="TRẠNG THÁI">
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Status")%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="THỜI GIAN TẠO">
                            <ItemStyle Width="15%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "create_date")).ToString("dd/MM/yyyy HH:mm:ss")%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="THỜI GIAN CẬP NHẬT">
                            <ItemStyle Width="15%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "last_updated")).ToString("dd/MM/yyyy HH:mm:ss")%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="GHI CHÚ">
                            <ItemStyle Width="25%" HorizontalAlign="Left" />
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "description")%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn>
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderTemplate>
                                SỬA
                            </HeaderTemplate>
                            <ItemTemplate>
                                <a class="datagridLinks" title="Sửa đổi thông tin" href='SMSDictIndexKeywordFilterEdit.aspx?objid=<%# Utils.EncryptText(DataBinder.Eval(Container.DataItem, "ID")) %>'>
                                    <img border="0" src="/images/comment-edit-icon.png" />
                                </a>
                            </ItemTemplate>

                        </asp:TemplateColumn>
                        <asp:TemplateColumn>
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderTemplate>
                                XÓA
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="deleter" runat="server" title="Delete" BorderStyle="None"
                                    CausesValidation="False" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID")%>'
                                    ImageAlign="absmiddle" ImageUrl="~/Images/del.gif" OnCommand="DelData" />
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
