<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SMSDictIndexKeywordDeclareReport.aspx.vb" Inherits="Prjs.Portal.Report.SMSDictIndexKeywordDeclareReport" %>
<%@ Register Assembly="ASPnetPagerV2_8" Namespace="ASPnetControls" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../Styles/HQ.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/LightStyle.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>

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
                <telerik:AjaxSetting AjaxControlID="DropDownListDepartment_Id">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="DropDownListPartner_Id" />
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
                                            <asp:ListItem>8x76</asp:ListItem>
                                            <asp:ListItem>6x66</asp:ListItem>
                                            <asp:ListItem>6x35</asp:ListItem>
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
                                        <asp:Label ID="Label3" runat="server" CssClass="label">Mã dịch vụ:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <table cellpadding="0" cellspacing="0" class="auto-style1">
                                            <tr>
                                                <td width="50%">
                                        <asp:TextBox ID="txtKeyWord" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                            Width="80%"></asp:TextBox>
                                                </td>
                                                <td>
                                        <asp:CheckBox ID="CheckBoxKeyword" runat="server" CssClass="checkbox" Text="Tương đối" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label5" runat="server" CssClass="label">Trạng thái:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DropDownListStatus_Id" runat="server" CssClass="droplist" >
                                        </asp:DropDownList>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="Label1" runat="server" CssClass="label">Phòng ban:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DropDownListDepartment_Id" runat="server" CssClass="droplist" AutoPostBack="True">
                                            <asp:ListItem>--all--</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                    <asp:Label ID="Label83" runat="server" CssClass="label">Thể loại:</asp:Label>
                                    </td>
                                    <td align="left">
                                    <asp:DropDownList ID="DropDownListTypeOf_Ticket_Id" runat="server" CssClass="droplist" AutoPostBack="True">
                                        <asp:ListItem Value="0">--all--</asp:ListItem>
                                        <asp:ListItem Value="1">Khai báo mới</asp:ListItem>
                                        <asp:ListItem Value="2">Sửa thông tin đã đăng ký</asp:ListItem>
                                        <asp:ListItem Value="3">Xóa mã đã đăng ký</asp:ListItem>
                                    </asp:DropDownList>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="Label9" runat="server" CssClass="label">Đối tác:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DropDownListPartner_Id" runat="server" CssClass="droplist">
                                            <asp:ListItem>--all--</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label8" runat="server" CssClass="label">Tổng số:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblTotal" runat="server" CssClass="lblerror"></asp:Label>
                                    </td>
                                    <td align="right">
                                        &nbsp;</td>
                                    <td align="left">
                                        &nbsp;</td>
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
                         <asp:TemplateColumn HeaderText="ID">
                            <ItemStyle Width="3%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                 <asp:Label ID="IdQ1" runat="server" CssClass="ItemsText"   ForeColor="#009933"> <a href="JavaScript:IsDetail('<%#Utils.EncryptText(Eval("Id") ) %>')"  title="Thông tin chi tiết" ><%# Eval("Id")%> </a>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="THỂ LOẠI">
                            <ItemStyle Width="8%" HorizontalAlign="Center" />
                            <ItemTemplate>

                                <asp:Label ID="TypeOf_Ticket_Text" runat="server" CssClass="label"  > <%# DataBinder.Eval(Container.DataItem, "TypeOf_Ticket_Text")%>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>

                        <asp:TemplateColumn HeaderText="MÃ">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>

                                <asp:Label ID="Key_Word" runat="server" CssClass="label" Font-Bold="true"> <%# DataBinder.Eval(Container.DataItem, "Key_Word")%>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        
                        <asp:TemplateColumn HeaderText="ĐẦU SỐ">
                            <ItemStyle Width="15%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="Short_Code" runat="server" CssClass="label" Font-Bold="true"> <%# DataBinder.Eval(Container.DataItem, "Short_Code")%>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                         <asp:TemplateColumn HeaderText="DỊCH VỤ">
                            <ItemStyle Width="15%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="Cate1_Text" runat="server" CssClass="label"  > <%# DataBinder.Eval(Container.DataItem, "Cate1_Text")%>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="TRẠNG THÁI">
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="Status_Text" runat="server" CssClass="label"  ForeColor="Red" > <%# DataBinder.Eval(Container.DataItem, "Status_Text")%>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="KHỞI TẠO TẠO">
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "Create_Time")).ToString("dd/MM/yyyy HH:mm:ss")%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="CẬP NHẬT">
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "Update_Time")).ToString("dd/MM/yyyy HH:mm:ss")%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                         <asp:TemplateColumn HeaderText="CẬP NHẬT">
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "Update_Time")).ToString("dd/MM/yyyy HH:mm:ss")%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="BỘ PHẬN">
                            <ItemStyle Width="5%" HorizontalAlign="center" />
                            <ItemTemplate>
                                  <asp:Label ID="Department_Code" runat="server" CssClass="label"  ForeColor="blue" > <%# DataBinder.Eval(Container.DataItem, "Department_Code")%>
                                </asp:Label>
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
