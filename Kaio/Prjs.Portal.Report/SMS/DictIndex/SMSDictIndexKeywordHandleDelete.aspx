<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SMSDictIndexKeywordHandleDelete.aspx.vb" Inherits="Prjs.Portal.Report.SMSDictIndexKeywordHandleDelete" %>

<%@ Register Assembly="ASPnetPagerV2_8" Namespace="ASPnetControls" TagPrefix="cc1" %>
<%@ Register Assembly="FilePickerControl" Namespace="AWS.FilePicker" TagPrefix="cc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                <telerik:AjaxSetting AjaxControlID="DropDownListRangeShortCodeQ1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="DropDownListShortCodeQ1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="DropDownListDepartment_IdQ1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="DropDownListPartner_IdQ1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="DropDownListRangeShortCodeQ5">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="DropDownListShortCodeQ5" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="DropDownListDepartment_IdQ5">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="DropDownListPartner_IdQ5" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="DropDownListRangeShortCodeQ2">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="DropDownListShortCodeQ2" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="DropDownListDepartment_IdQ2">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="DropDownListPartner_IdQ2" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="DropDownListRangeShortCodeQ7">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="DropDownListShortCodeQ7" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="DropDownListDepartment_IdQ7">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="DropDownListPartner_IdQ7" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="DropDownListStatus_IdQ8Proc">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="DropDownListGroup_Handle_IdQ8Proc" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <div id="HQ">
            <div class="alert">
                <asp:Label ID="lbltitle" runat="server" CssClass="lbltitle"></asp:Label><br />
                <asp:Label ID="lblerror" runat="server" CssClass="lblerror"></asp:Label>
                <telerik:RadTabStrip runat="server" ID="RadTabStrip1" MultiPageID="RadMultiPage1"
                    Skin="Forest" Font-Bold="False" Font-Names="Arial">
                    <Tabs>
                        <telerik:RadTab Text="Ticket chờ xử lý" Font-Names="Arial">
                        </telerik:RadTab>
                        <telerik:RadTab Text="Xử lý xóa định tuyến" Font-Names="Arial">
                        </telerik:RadTab>
                          <telerik:RadTab Text="Xử lý gán doanh thu" Font-Names="Arial">
                        </telerik:RadTab>
                        <telerik:RadTab Text="Ticket đã xử lý" Font-Names="Arial">
                        </telerik:RadTab>
                        <telerik:RadTab Text="Xử lý ticket" Font-Names="Arial">
                        </telerik:RadTab>

                    </Tabs>
                </telerik:RadTabStrip>
                <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="4" Width="99%"
                    CssClass="multiPage">
                    <telerik:RadPageView runat="server" ID="RadPageViewQ1" CssClass="PageView">
                        <div class="parametter" style="margin: 1px auto 1px auto; border-color: #B4B4B4; width: 80%; background-color: #E1EDD4;">
                            <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
                                <tr>
                                    <td align="center">
                                        <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
                                            <tr>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label6" runat="server" CssClass="label">Từ ngày:</asp:Label>
                                                </td>
                                                <td align="left" width="35%">
                                                    <telerik:RadDatePicker ID="RadFromDateQ1" rMinDate="2006/01/01" runat="server"
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
                                                    <asp:DropDownList ID="DropDownListRangeShortCodeQ1" runat="server" CssClass="droplist" Font-Bold="True" AutoPostBack="True">
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
                                                    <asp:Label ID="Label1" runat="server" CssClass="label">Đến ngày:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <telerik:RadDatePicker ID="RadToDateQ1" rMinDate="2006/01/01" runat="server"
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
                                                    <asp:DropDownList ID="DropDownListShortCodeQ1" runat="server" CssClass="droplist" Font-Bold="False">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">&nbsp;</td>
                                                <td align="left">
                                                    <asp:CheckBox ID="CheckBoxAllDateQ1" runat="server" Checked="True" CssClass="checkbox" Text="Toàn thời gian" />
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="Label8" runat="server" CssClass="label">Mã dịch vụ:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" class="auto-style1">
                                                        <tr>
                                                            <td width="50%">
                                                                <asp:TextBox ID="txtKeyWordQ1" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                                    Width="80%"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:CheckBox ID="CheckBoxKeywordQ1" runat="server" CssClass="checkbox" Text="Tương đối" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label48" runat="server" CssClass="label">Trạng thái:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="DropDownListStatus_IdQ1" runat="server" CssClass="droplist">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="Label49" runat="server" CssClass="label">Phòng ban:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="DropDownListDepartment_IdQ1" runat="server" CssClass="droplist" AutoPostBack="True">
                                                        <asp:ListItem>--all--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label50" runat="server" CssClass="label">Tổng số:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblTotalQ1" runat="server" CssClass="lblerror"></asp:Label>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="Label56" runat="server" CssClass="label">Đối tác:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="DropDownListPartner_IdQ1" runat="server" CssClass="droplist">
                                                        <asp:ListItem>--all--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="submmit">
                            <asp:Button ID="btnSearchingQ1" runat="server" CssClass="btnbackground"
                                Text="Tìm kiếm" />
                            <asp:Button ID="btnExpQ1" runat="server" CssClass="btnbackground"
                                Text="Báo cáo" />
                        </div>
                        <div class="datagrid">
                            <telerik:RadGrid ID="RadGridQ1" runat="server" AllowMultiRowSelection="False" AllowPaging="True"
                                AllowSorting="True" AutoGenerateColumns="False" PageSize="30" ShowStatusBar="true"
                                Skin="Hay" SortingSettings-SortedBackColor="Azure" StatusBarSettings-ReadyText="Customer Care Portal - Kaio Corp"
                                Width="100%">
                                <HeaderStyle Font-Names="Arial" Font-Size="8pt" />
                                <ItemStyle Font-Names="Arial" Font-Size="8pt" ForeColor="Black" />
                                <SortingSettings SortedBackColor="Azure" />
                                <ClientSettings>
                                    <Selecting AllowRowSelect="True" />
                                </ClientSettings>
                                <AlternatingItemStyle Font-Names="Arial" Font-Size="8pt" ForeColor="Black" />
                                <GroupHeaderItemStyle Font-Bold="False" Font-Names="Arial" Font-Size="8pt" Font-Underline="False"
                                    ForeColor="Black" HorizontalAlign="Center" />
                                <GroupPanel Font-Size="9pt">
                                </GroupPanel>
                                <MasterTableView AllowMultiColumnSorting="True" DataKeyNames="ID" Width="100%">
                                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                    </ExpandCollapseColumn>
                                    <Columns>

                                        <telerik:GridTemplateColumn HeaderText="STT" SortExpression="RowNumber">
                                            <HeaderStyle Font-Bold="true" Font-Names="Arial" Font-Size="10px" HorizontalAlign="Center"
                                                Width="3%" />
                                            <ItemStyle Font-Names="Arial" Font-Size="11px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblRowNumberQ2" runat="server" Text='<%# Eval("RowNumber") %>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="ID">
                                            <HeaderStyle Font-Bold="true" Font-Names="Arial" Font-Size="10px" HorizontalAlign="Center"
                                                Width="3%" />
                                            <ItemStyle Font-Names="Arial" Font-Size="11px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="IdQ1" runat="server" CssClass="ItemsText" Font-Bold="true"> <a href="JavaScript:IsDetail('<%#Utils.EncryptText(Eval("Id") ) %>')"  title="Thông tin chi tiết" ><%# Eval("Id")%> </a>
                                                </asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="THỂ LOẠI">
                                            <HeaderStyle Font-Bold="true" Font-Names="Arial" Font-Size="10px" HorizontalAlign="Center"
                                                Width="7%" />
                                            <ItemStyle Font-Names="Arial" Font-Size="11px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="TypeOf_Ticket_TextQ1" runat="server" Text='<%# Eval("TypeOf_Ticket_Text")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="MÃ">
                                            <HeaderStyle Font-Bold="true" Font-Names="Arial" Font-Size="10px" HorizontalAlign="Center"
                                                Width="5%" />
                                            <ItemStyle Font-Names="Arial" Font-Size="11px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="Key_WordQ1" runat="server" Font-Bold="true" Text='<%# Eval("Key_Word")%>'></asp:Label>

                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="ĐẦU SỐ">
                                            <HeaderStyle Font-Bold="true" Font-Names="Arial" Font-Size="10px" HorizontalAlign="Center"
                                                Width="15%" />
                                            <ItemStyle Font-Names="Arial" Font-Size="11px" HorizontalAlign="Center" Font-Bold="true" />
                                            <ItemTemplate>
                                                <asp:Label ID="Short_CodeQ1" runat="server" Text='<%# Eval("Short_Code")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="DỊCH VỤ">
                                            <HeaderStyle Font-Bold="true" Font-Names="Arial" Font-Size="10px" HorizontalAlign="Center"
                                                Width="12%" />
                                            <ItemStyle Font-Names="Arial" Font-Size="11px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="Cate1_TextQ1" runat="server" Text='<%# Eval("Cate1_Text")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="TRẠNG THÁI">
                                            <HeaderStyle Font-Bold="true" Font-Names="Arial" Font-Size="10px" HorizontalAlign="Center"
                                                Width="8%" />
                                            <ItemStyle Font-Names="Arial" Font-Size="11px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="Status_TextQ1" runat="server" Text='<%# Eval("Status_Text")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="KHỞI TẠO">
                                            <HeaderStyle Font-Bold="true" Font-Names="Arial" Font-Size="10px" HorizontalAlign="Center"
                                                Width="10%" />
                                            <ItemStyle Font-Names="Arial" Font-Size="11px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="Create_TimeQ1" runat="server" Text='<%# DateTime.Parse(Eval("Create_Time")).ToString("dd-MM-yyyy HH:mm:ss")%>'></asp:Label>

                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="CẬP NHẬT">
                                            <HeaderStyle Font-Bold="true" Font-Names="Arial" Font-Size="10px" HorizontalAlign="Center"
                                                Width="10%" />
                                            <ItemStyle Font-Names="Arial" Font-Size="11px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="Update_TimeQ1" runat="server" Text='<%# DateTime.Parse(Eval("Update_Time")).ToString("dd-MM-yyyy HH:mm:ss")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="GHI CHÚ">
                                            <HeaderStyle Font-Bold="true" Font-Names="Arial" Font-Size="10px" HorizontalAlign="Center"
                                                Width="12%" />
                                            <ItemStyle Font-Names="Arial" Font-Size="11px" HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:Label ID="DescriptionQ1" runat="server" Text='<%# Eval("Description")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="XỬ LÝ">
                                            <HeaderStyle Font-Size="11px" HorizontalAlign="Center" Width="5%" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="lnkQ1" ToolTip="Xử lý" OnCommand="lnkQ1_Click"
                                                    CommandArgument='<%#Eval("ID")%>'><img border="0" src="/images/comment-edit-icon.png" /></asp:LinkButton>

                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                    <EditFormSettings>
                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                        </EditColumn>
                                    </EditFormSettings>
                                </MasterTableView>
                                <StatusBarSettings ReadyText="Customer Care Portal - Kaio Corp" />
                                <FilterMenu EnableImageSprites="False">
                                </FilterMenu>
                            </telerik:RadGrid>
                        </div>
                    </telerik:RadPageView>
                  
                    
                    <telerik:RadPageView runat="server" ID="RadPageViewQ5" CssClass="PageView">
                        <div class="parametter" style="margin: 1px auto 1px auto; border-color: #B4B4B4; width: 80%; background-color: #E1EDD4;">
                            <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
                                <tr>
                                    <td align="center">
                                        <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
                                            <tr>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label36" runat="server" CssClass="label">Từ ngày:</asp:Label>
                                                </td>
                                                <td align="left" width="35%">
                                                    <telerik:RadDatePicker ID="RadFromDateQ5" rMinDate="2006/01/01" runat="server"
                                                        ZIndex="30001" Culture="vi-VN" Skin="Forest">
                                                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"
                                                            Skin="Forest">
                                                        </Calendar>

                                                        <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

                                                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label37" runat="server" CssClass="label">Dải số:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="DropDownListRangeShortCodeQ5" runat="server" CssClass="droplist" Font-Bold="True" AutoPostBack="True">
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
                                                    <asp:Label ID="Label38" runat="server" CssClass="label">Đến ngày:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <telerik:RadDatePicker ID="RadToDateQ5" rMinDate="2006/01/01" runat="server"
                                                        ZIndex="30001" Culture="vi-VN" Skin="Forest">
                                                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"
                                                            Skin="Forest">
                                                        </Calendar>

                                                        <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

                                                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="Label39" runat="server" CssClass="label">Đầu số:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="DropDownListShortCodeQ5" runat="server" CssClass="droplist" Font-Bold="False">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">&nbsp;</td>
                                                <td align="left">
                                                    <asp:CheckBox ID="CheckBoxAllDateQ5" runat="server" Checked="True" CssClass="checkbox" Text="Toàn thời gian" />
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="Label40" runat="server" CssClass="label">Mã dịch vụ:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" class="auto-style1">
                                                        <tr>
                                                            <td width="50%">
                                                                <asp:TextBox ID="txtKeyWordQ5" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                                    Width="80%"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:CheckBox ID="CheckBoxKeyWordQ5" runat="server" CssClass="checkbox" Text="Tương đối" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label41" runat="server" CssClass="label">Trạng thái:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="DropDownListStatus_IdQ5" runat="server" CssClass="droplist">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="Label74" runat="server" CssClass="label">Phòng ban:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="DropDownListDepartment_IdQ5" runat="server" CssClass="droplist" AutoPostBack="True">
                                                        <asp:ListItem>--all--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label75" runat="server" CssClass="label">Tổng số:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblTotalQ5" runat="server" CssClass="lblerror"></asp:Label>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="Label76" runat="server" CssClass="label">Đối tác:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="DropDownListPartner_IdQ5" runat="server" CssClass="droplist">
                                                        <asp:ListItem>--all--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="submmit">
                            <asp:Button ID="btnSearchingQ5" runat="server" CssClass="btnbackground"
                                Text="Tìm kiếm" />
                            <asp:Button ID="btnExpQ5" runat="server" CssClass="btnbackground"
                                Text="Báo cáo" />
                        </div>
                        <div class="datagrid">
                            <telerik:RadGrid ID="RadGridQ5" runat="server" AllowMultiRowSelection="False" AllowPaging="True"
                                AllowSorting="True" AutoGenerateColumns="False" PageSize="30" ShowStatusBar="true"
                                Skin="Hay" SortingSettings-SortedBackColor="Azure" StatusBarSettings-ReadyText="Customer Care Portal - Kaio Corp"
                                Width="100%">
                                <HeaderStyle Font-Names="Arial" Font-Size="8pt" />
                                <ItemStyle Font-Names="Arial" Font-Size="8pt" ForeColor="Black" />
                                <SortingSettings SortedBackColor="Azure" />
                                <ClientSettings>
                                    <Selecting AllowRowSelect="True" />
                                </ClientSettings>
                                <AlternatingItemStyle Font-Names="Arial" Font-Size="8pt" ForeColor="Black" />
                                <GroupHeaderItemStyle Font-Bold="False" Font-Names="Arial" Font-Size="8pt" Font-Underline="False"
                                    ForeColor="Black" HorizontalAlign="Center" />
                                <GroupPanel Font-Size="9pt">
                                </GroupPanel>
                                <MasterTableView AllowMultiColumnSorting="True" DataKeyNames="ID" Width="100%">
                                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                    </ExpandCollapseColumn>
                                    <Columns>

                                        <telerik:GridTemplateColumn HeaderText="STT" SortExpression="RowNumber">
                                            <HeaderStyle Font-Bold="true" Font-Names="Arial" Font-Size="10px" HorizontalAlign="Center"
                                                Width="3%" />
                                            <ItemStyle Font-Names="Arial" Font-Size="11px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblRowNumberQ5" runat="server" Text='<%# Eval("RowNumber") %>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="ID">
                                            <HeaderStyle Font-Bold="true" Font-Names="Arial" Font-Size="10px" HorizontalAlign="Center"
                                                Width="3%" />
                                            <ItemStyle Font-Names="Arial" Font-Size="11px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="IdQ5" runat="server" CssClass="ItemsText" Font-Bold="true"> <a href="JavaScript:IsDetail('<%#Utils.EncryptText(Eval("Id") ) %>')"  title="Thông tin chi tiết" ><%# Eval("Id")%> </a>
                                                </asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="THỂ LOẠI">
                                            <HeaderStyle Font-Bold="true" Font-Names="Arial" Font-Size="10px" HorizontalAlign="Center"
                                                Width="10%" />
                                            <ItemStyle Font-Names="Arial" Font-Size="11px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="TypeOf_Ticket_TextQ5" runat="server" Text='<%# Eval("TypeOf_Ticket_Text")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="MÃ">
                                            <HeaderStyle Font-Bold="true" Font-Names="Arial" Font-Size="10px" HorizontalAlign="Center"
                                                Width="5%" />
                                            <ItemStyle Font-Names="Arial" Font-Size="11px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="Key_WordQ5" runat="server" Font-Bold="true" Text='<%# Eval("Key_Word")%>'></asp:Label>

                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="ĐẦU SỐ">
                                            <HeaderStyle Font-Bold="true" Font-Names="Arial" Font-Size="10px" HorizontalAlign="Center"
                                                Width="5%" />
                                            <ItemStyle Font-Names="Arial" Font-Size="11px" HorizontalAlign="Center" Font-Bold="true" />
                                            <ItemTemplate>
                                                <asp:Label ID="Short_CodeQ5" runat="server" Text='<%# Eval("Short_Code")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="DỊCH VỤ">
                                            <HeaderStyle Font-Bold="true" Font-Names="Arial" Font-Size="10px" HorizontalAlign="Center"
                                                Width="15%" />
                                            <ItemStyle Font-Names="Arial" Font-Size="11px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="Cate1_TextQ5" runat="server" Text='<%# Eval("Cate1_Text")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="TRẠNG THÁI">
                                            <HeaderStyle Font-Bold="true" Font-Names="Arial" Font-Size="10px" HorizontalAlign="Center"
                                                Width="10%" />
                                            <ItemStyle Font-Names="Arial" Font-Size="11px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="Status_TextQ5" runat="server" Text='<%# Eval("Status_Text")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="T/G TẠO">
                                            <HeaderStyle Font-Bold="true" Font-Names="Arial" Font-Size="10px" HorizontalAlign="Center"
                                                Width="10%" />
                                            <ItemStyle Font-Names="Arial" Font-Size="11px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="Create_TimeQ5" runat="server" Text='<%# DateTime.Parse(Eval("Create_Time")).ToString("dd-MM-yyyy HH:mm:ss")%>'></asp:Label>

                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>



                                        <telerik:GridTemplateColumn HeaderText="XỬ LÝ">
                                            <HeaderStyle Font-Size="11px" HorizontalAlign="Center" Width="5%" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="lnkQ5" ToolTip="Xử lý" OnCommand="lnkQ5_Click"
                                                    CommandArgument='<%#Eval("ID")%>'><img border="0" src="/images/comment-edit-icon.png" /></asp:LinkButton>

                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                    <EditFormSettings>
                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                        </EditColumn>
                                    </EditFormSettings>
                                </MasterTableView>
                                <StatusBarSettings ReadyText="Customer Care Portal - Kaio Corp" />
                                <FilterMenu EnableImageSprites="False">
                                </FilterMenu>
                            </telerik:RadGrid>
                        </div>
                    </telerik:RadPageView>
                    <telerik:RadPageView runat="server" ID="RadPageViewQ2" CssClass="PageView">
                         <div class="parametter" style="margin: 1px auto 1px auto; border-color: #B4B4B4; width: 80%; background-color: #E1EDD4;">
                            <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
                                <tr>
                                    <td align="center">
                                        <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
                                            <tr>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label59" runat="server" CssClass="label">Từ ngày:</asp:Label>
                                                </td>
                                                <td align="left" width="35%">
                                                    <telerik:RadDatePicker ID="RadFromDateQ2" rMinDate="2006/01/01" runat="server"
                                                        ZIndex="30001" Culture="vi-VN" Skin="Forest">
                                                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"
                                                            Skin="Forest">
                                                        </Calendar>

                                                        <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

                                                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label60" runat="server" CssClass="label">Dải số:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="DropDownListRangeShortCodeQ2" runat="server" CssClass="droplist" Font-Bold="True" AutoPostBack="True">
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
                                                    <asp:Label ID="Label61" runat="server" CssClass="label">Đến ngày:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <telerik:RadDatePicker ID="RadToDateQ2" rMinDate="2006/01/01" runat="server"
                                                        ZIndex="30001" Culture="vi-VN" Skin="Forest">
                                                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"
                                                            Skin="Forest">
                                                        </Calendar>

                                                        <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

                                                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="Label62" runat="server" CssClass="label">Đầu số:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="DropDownListShortCodeQ2" runat="server" CssClass="droplist" Font-Bold="False">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">&nbsp;</td>
                                                <td align="left">
                                                    <asp:CheckBox ID="CheckBoxAllDateQ2" runat="server" Checked="True" CssClass="checkbox" Text="Toàn thời gian" />
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="Label63" runat="server" CssClass="label">Mã dịch vụ:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" class="auto-style1">
                                                        <tr>
                                                            <td width="50%">
                                                                <asp:TextBox ID="txtKeyWordQ2" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                                    Width="80%"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:CheckBox ID="CheckBoxKeywordQ2" runat="server" CssClass="checkbox" Text="Tương đối" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label64" runat="server" CssClass="label">Trạng thái:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="DropDownListStatus_IdQ2" runat="server" CssClass="droplist">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="Label65" runat="server" CssClass="label">Phòng ban:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="DropDownListDepartment_IdQ2" runat="server" CssClass="droplist" AutoPostBack="True">
                                                        <asp:ListItem>--all--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label66" runat="server" CssClass="label">Tổng số:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblTotalQ2" runat="server" CssClass="lblerror"></asp:Label>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="Label67" runat="server" CssClass="label">Đối tác:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="DropDownListPartner_IdQ2" runat="server" CssClass="droplist">
                                                        <asp:ListItem>--all--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="submmit">
                            <asp:Button ID="btnSearchingQ2" runat="server" CssClass="btnbackground"
                                Text="Tìm kiếm" />
                            <asp:Button ID="btnExpQ2" runat="server" CssClass="btnbackground"
                                Text="Báo cáo" />
                        </div>
                        <div class="datagrid">
                            <telerik:RadGrid ID="RadGridQ2" runat="server" AllowMultiRowSelection="False" AllowPaging="True"
                                AllowSorting="True" AutoGenerateColumns="False" PageSize="30" ShowStatusBar="true"
                                Skin="Hay" SortingSettings-SortedBackColor="Azure" StatusBarSettings-ReadyText="Customer Care Portal - Kaio Corp"
                                Width="100%">
                                <HeaderStyle Font-Names="Arial" Font-Size="8pt" />
                                <ItemStyle Font-Names="Arial" Font-Size="8pt" ForeColor="Black" />
                                <SortingSettings SortedBackColor="Azure" />
                                <ClientSettings>
                                    <Selecting AllowRowSelect="True" />
                                </ClientSettings>
                                <AlternatingItemStyle Font-Names="Arial" Font-Size="8pt" ForeColor="Black" />
                                <GroupHeaderItemStyle Font-Bold="False" Font-Names="Arial" Font-Size="8pt" Font-Underline="False"
                                    ForeColor="Black" HorizontalAlign="Center" />
                                <GroupPanel Font-Size="9pt">
                                </GroupPanel>
                                <MasterTableView AllowMultiColumnSorting="True" DataKeyNames="ID" Width="100%">
                                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                    </ExpandCollapseColumn>
                                    <Columns>

                                        <telerik:GridTemplateColumn HeaderText="STT" SortExpression="RowNumber">
                                            <HeaderStyle Font-Bold="true" Font-Names="Arial" Font-Size="10px" HorizontalAlign="Center"
                                                Width="3%" />
                                            <ItemStyle Font-Names="Arial" Font-Size="11px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblRowNumberQ2" runat="server" Text='<%# Eval("RowNumber") %>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="ID">
                                            <HeaderStyle Font-Bold="true" Font-Names="Arial" Font-Size="10px" HorizontalAlign="Center"
                                                Width="3%" />
                                            <ItemStyle Font-Names="Arial" Font-Size="11px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="IdQ2" runat="server" CssClass="ItemsText" Font-Bold="true"> <a href="JavaScript:IsDetail('<%#Utils.EncryptText(Eval("Id") ) %>')"  title="Thông tin chi tiết" ><%# Eval("Id")%> </a>
                                                </asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="THỂ LOẠI">
                                            <HeaderStyle Font-Bold="true" Font-Names="Arial" Font-Size="10px" HorizontalAlign="Center"
                                                Width="10%" />
                                            <ItemStyle Font-Names="Arial" Font-Size="11px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="TypeOf_Ticket_TextQ2" runat="server" Text='<%# Eval("TypeOf_Ticket_Text")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="MÃ">
                                            <HeaderStyle Font-Bold="true" Font-Names="Arial" Font-Size="10px" HorizontalAlign="Center"
                                                Width="5%" />
                                            <ItemStyle Font-Names="Arial" Font-Size="11px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="Key_WordQ2" runat="server" Font-Bold="true" Text='<%# Eval("Key_Word")%>'></asp:Label>

                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="ĐẦU SỐ">
                                            <HeaderStyle Font-Bold="true" Font-Names="Arial" Font-Size="10px" HorizontalAlign="Center"
                                                Width="5%" />
                                            <ItemStyle Font-Names="Arial" Font-Size="11px" HorizontalAlign="Center" Font-Bold="true" />
                                            <ItemTemplate>
                                                <asp:Label ID="Short_CodeQ2" runat="server" Text='<%# Eval("Short_Code")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="DỊCH VỤ">
                                            <HeaderStyle Font-Bold="true" Font-Names="Arial" Font-Size="10px" HorizontalAlign="Center"
                                                Width="15%" />
                                            <ItemStyle Font-Names="Arial" Font-Size="11px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="Cate1_TextQ2" runat="server" Text='<%# Eval("Cate1_Text")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="TRẠNG THÁI">
                                            <HeaderStyle Font-Bold="true" Font-Names="Arial" Font-Size="10px" HorizontalAlign="Center"
                                                Width="10%" />
                                            <ItemStyle Font-Names="Arial" Font-Size="11px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="Status_TextQ2" runat="server" Text='<%# Eval("Status_Text")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="T/G TẠO">
                                            <HeaderStyle Font-Bold="true" Font-Names="Arial" Font-Size="10px" HorizontalAlign="Center"
                                                Width="10%" />
                                            <ItemStyle Font-Names="Arial" Font-Size="11px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="Create_TimeQ2" runat="server" Text='<%# DateTime.Parse(Eval("Create_Time")).ToString("dd-MM-yyyy HH:mm:ss")%>'></asp:Label>

                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>


                                        <telerik:GridTemplateColumn HeaderText="XỬ LÝ">
                                            <HeaderStyle Font-Size="11px" HorizontalAlign="Center" Width="5%" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="lnkQ2" ToolTip="Xử lý" OnCommand="lnkQ2_Click"
                                                    CommandArgument='<%#Eval("ID")%>'><img border="0" src="/images/comment-edit-icon.png" /></asp:LinkButton>

                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                    </Columns>
                                    <EditFormSettings>
                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                        </EditColumn>
                                    </EditFormSettings>
                                </MasterTableView>
                                <StatusBarSettings ReadyText="Customer Care Portal - Kaio Corp" />
                                <FilterMenu EnableImageSprites="False">
                                </FilterMenu>
                            </telerik:RadGrid>
                        </div>
                    </telerik:RadPageView>
                   <telerik:RadPageView runat="server" ID="RadPageViewQ7" CssClass="PageView">
                        <div class="parametter" style="margin: 1px auto 1px auto; border-color: #B4B4B4; width: 80%; background-color: #E1EDD4;">
                            <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
                                <tr>
                                    <td align="center">
                                        <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
                                            <tr>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label3" runat="server" CssClass="label">Từ ngày:</asp:Label>
                                                </td>
                                                <td align="left" width="35%">
                                                    <telerik:RadDatePicker ID="RadFromDateQ7" rMinDate="2006/01/01" runat="server"
                                                        ZIndex="30001" Culture="vi-VN" Skin="Forest">
                                                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"
                                                            Skin="Forest">
                                                        </Calendar>

                                                        <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

                                                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label5" runat="server" CssClass="label">Dải số:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="DropDownListRangeShortCodeQ7" runat="server" CssClass="droplist" Font-Bold="True" AutoPostBack="True">
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
                                                    <telerik:RadDatePicker ID="RadToDateQ7" rMinDate="2006/01/01" runat="server"
                                                        ZIndex="30001" Culture="vi-VN" Skin="Forest">
                                                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"
                                                            Skin="Forest">
                                                        </Calendar>

                                                        <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

                                                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="Label9" runat="server" CssClass="label">Đầu số:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="DropDownListShortCodeQ7" runat="server" CssClass="droplist" Font-Bold="False">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">&nbsp;</td>
                                                <td align="left">
                                                    <asp:CheckBox ID="CheckBoxAllDateQ7" runat="server" Checked="True" CssClass="checkbox" Text="Toàn thời gian" />
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="Label10" runat="server" CssClass="label">Mã dịch vụ:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <table cellpadding="0" cellspacing="0" class="auto-style1">
                                                        <tr>
                                                            <td width="50%">
                                                                <asp:TextBox ID="txtKeyWordQ7" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                                    Width="80%"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:CheckBox ID="CheckBoxKeywordQ7" runat="server" CssClass="checkbox" Text="Tương đối" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label11" runat="server" CssClass="label">Trạng thái:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="DropDownListStatus_IdQ7" runat="server" CssClass="droplist">
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="Label12" runat="server" CssClass="label">Phòng ban:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="DropDownListDepartment_IdQ7" runat="server" CssClass="droplist" AutoPostBack="True">
                                                        <asp:ListItem>--all--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label13" runat="server" CssClass="label">Tổng số:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblTotalQ7" runat="server" CssClass="lblerror"></asp:Label>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="Label14" runat="server" CssClass="label">Đối tác:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="DropDownListPartner_IdQ7" runat="server" CssClass="droplist">
                                                        <asp:ListItem>--all--</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="submmit">
                            <asp:Button ID="btnSearchingQ7" runat="server" CssClass="btnbackground"
                                Text="Tìm kiếm" />
                            <asp:Button ID="btnExpQ7" runat="server" CssClass="btnbackground"
                                Text="Báo cáo" />
                        </div>
                        <div class="datagrid">
                            <telerik:RadGrid ID="RadGridQ7" runat="server" AllowMultiRowSelection="False" AllowPaging="True"
                                AllowSorting="True" AutoGenerateColumns="False" PageSize="30" ShowStatusBar="true"
                                Skin="Hay" SortingSettings-SortedBackColor="Azure" StatusBarSettings-ReadyText="Customer Care Portal - Kaio Corp"
                                Width="100%">
                                <HeaderStyle Font-Names="Arial" Font-Size="8pt" />
                                <ItemStyle Font-Names="Arial" Font-Size="8pt" ForeColor="Black" />
                                <SortingSettings SortedBackColor="Azure" />
                                <ClientSettings>
                                    <Selecting AllowRowSelect="True" />
                                </ClientSettings>
                                <AlternatingItemStyle Font-Names="Arial" Font-Size="8pt" ForeColor="Black" />
                                <GroupHeaderItemStyle Font-Bold="False" Font-Names="Arial" Font-Size="8pt" Font-Underline="False"
                                    ForeColor="Black" HorizontalAlign="Center" />
                                <GroupPanel Font-Size="9pt">
                                </GroupPanel>
                                <MasterTableView AllowMultiColumnSorting="True" DataKeyNames="ID" Width="100%">
                                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                    </ExpandCollapseColumn>
                                    <Columns>

                                        <telerik:GridTemplateColumn HeaderText="STT" SortExpression="RowNumber">
                                            <HeaderStyle Font-Bold="true" Font-Names="Arial" Font-Size="10px" HorizontalAlign="Center"
                                                Width="3%" />
                                            <ItemStyle Font-Names="Arial" Font-Size="11px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblRowNumberQ2" runat="server" Text='<%# Eval("RowNumber") %>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="ID">
                                            <HeaderStyle Font-Bold="true" Font-Names="Arial" Font-Size="10px" HorizontalAlign="Center"
                                                Width="3%" />
                                            <ItemStyle Font-Names="Arial" Font-Size="11px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="IdQ7" runat="server" CssClass="ItemsText" Font-Bold="true"> <a href="JavaScript:IsDetail('<%#Utils.EncryptText(Eval("Id") ) %>')"  title="Thông tin chi tiết" ><%# Eval("Id")%> </a>
                                                </asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="THỂ LOẠI">
                                            <HeaderStyle Font-Bold="true" Font-Names="Arial" Font-Size="10px" HorizontalAlign="Center"
                                                Width="7%" />
                                            <ItemStyle Font-Names="Arial" Font-Size="11px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="TypeOf_Ticket_TextQ7" runat="server" Text='<%# Eval("TypeOf_Ticket_Text")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="MÃ">
                                            <HeaderStyle Font-Bold="true" Font-Names="Arial" Font-Size="10px" HorizontalAlign="Center"
                                                Width="5%" />
                                            <ItemStyle Font-Names="Arial" Font-Size="11px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="Key_WordQ7" runat="server" Font-Bold="true" Text='<%# Eval("Key_Word")%>'></asp:Label>

                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="ĐẦU SỐ">
                                            <HeaderStyle Font-Bold="true" Font-Names="Arial" Font-Size="10px" HorizontalAlign="Center"
                                                Width="15%" />
                                            <ItemStyle Font-Names="Arial" Font-Size="11px" HorizontalAlign="Center" Font-Bold="true" />
                                            <ItemTemplate>
                                                <asp:Label ID="Short_CodeQ7" runat="server" Text='<%# Eval("Short_Code")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="DỊCH VỤ">
                                            <HeaderStyle Font-Bold="true" Font-Names="Arial" Font-Size="10px" HorizontalAlign="Center"
                                                Width="12%" />
                                            <ItemStyle Font-Names="Arial" Font-Size="11px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="Cate1_TextQ7" runat="server" Text='<%# Eval("Cate1_Text")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="TRẠNG THÁI">
                                            <HeaderStyle Font-Bold="true" Font-Names="Arial" Font-Size="10px" HorizontalAlign="Center"
                                                Width="8%" />
                                            <ItemStyle Font-Names="Arial" Font-Size="11px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="Status_TextQ7" runat="server" Text='<%# Eval("Status_Text")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="KHỞI TẠO">
                                            <HeaderStyle Font-Bold="true" Font-Names="Arial" Font-Size="10px" HorizontalAlign="Center"
                                                Width="10%" />
                                            <ItemStyle Font-Names="Arial" Font-Size="11px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="Create_TimeQ7" runat="server" Text='<%# DateTime.Parse(Eval("Create_Time")).ToString("dd-MM-yyyy HH:mm:ss")%>'></asp:Label>

                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="CẬP NHẬT">
                                            <HeaderStyle Font-Bold="true" Font-Names="Arial" Font-Size="10px" HorizontalAlign="Center"
                                                Width="10%" />
                                            <ItemStyle Font-Names="Arial" Font-Size="11px" HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label ID="Update_TimeQ7" runat="server" Text='<%# DateTime.Parse(Eval("Update_Time")).ToString("dd-MM-yyyy HH:mm:ss")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="GHI CHÚ">
                                            <HeaderStyle Font-Bold="true" Font-Names="Arial" Font-Size="10px" HorizontalAlign="Center"
                                                Width="12%" />
                                            <ItemStyle Font-Names="Arial" Font-Size="11px" HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:Label ID="DescriptionQ7" runat="server" Text='<%# Eval("Description")%>'></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                       
                                    </Columns>
                                    <EditFormSettings>
                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                        </EditColumn>
                                    </EditFormSettings>
                                </MasterTableView>
                                <StatusBarSettings ReadyText="Customer Care Portal - Kaio Corp" />
                                <FilterMenu EnableImageSprites="False">
                                </FilterMenu>
                            </telerik:RadGrid>
                        </div>
                    </telerik:RadPageView>
                    <telerik:RadPageView runat="server" ID="RadPageViewQ8" CssClass="PageView">
                        <div class="parametter" style="margin: 1px auto 1px auto; border-color: #B4B4B4; width: 98%; background-color: #E1EDD4;">
                            <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                                <tr>
                                    <td align="right" width="20%">&nbsp;</td>
                                    <td align="left">
                                        <asp:Label ID="Label109" runat="server" CssClass="lbltitle" Font-Bold="False" ForeColor="Red">»Thông tin đăng ký:</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" width="20%">
                                        <asp:Label ID="Label83" runat="server" CssClass="label">Thể loại:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DropDownListTypeOf_Ticket_IdQ8" runat="server" CssClass="droplist" Enabled="False">
                                            <asp:ListItem Value="0">--Chọn--</asp:ListItem>
                                            <asp:ListItem Value="1">Khai báo mới</asp:ListItem>
                                            <asp:ListItem Value="2">Sửa thông tin đã đăng ký</asp:ListItem>
                                            <asp:ListItem Value="3">Xóa mã đã đăng ký</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" width="20%">
                                        <asp:Label ID="Label51" runat="server" CssClass="label">Phòng ban:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DropDownListDepartment_IdQ8" runat="server" CssClass="droplist" Enabled="False">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" width="20%">
                                        <asp:Label ID="Label52" runat="server" CssClass="label">Đối tác sở hữu:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DropDownListPartner_IdQ8" runat="server" CssClass="droplist" Enabled="False">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" width="20%">
                                        <asp:CheckBox ID="CheckBox99x" runat="server" CssClass="checkbox" Font-Bold="True" Text="99x" TextAlign="Left" />
                                    </td>
                                    <td align="left">
                                        <table class="auto-style1">
                                            <tr>
                                                <td width="10%">
                                                    <asp:CheckBox ID="CheckBox996" runat="server" CssClass="checkbox" Text="996" TextAlign="Left" Enabled="False" />
                                                </td>
                                                <td width="10%">
                                                    <asp:CheckBox ID="CheckBox997" runat="server" CssClass="checkbox" Text="997" TextAlign="Left" Enabled="False" />
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="CheckBox998" runat="server" CssClass="checkbox" Text="998" TextAlign="Left" Enabled="False" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" width="20%">
                                        <asp:CheckBox ID="CheckBox8x79" runat="server" CssClass="checkbox" Font-Bold="True" Text="8x79" TextAlign="Left" />
                                    </td>
                                    <td align="left">
                                        <table class="auto-style1">
                                            <tr>
                                                <td width="10%">
                                                    <asp:CheckBox ID="CheckBox8079" runat="server" CssClass="checkbox" Text="8079" TextAlign="Left" Enabled="False" />
                                                </td>
                                                <td width="10%">
                                                    <asp:CheckBox ID="CheckBox8179" runat="server" CssClass="checkbox" Text="8179" TextAlign="Left" Enabled="False" />
                                                </td>
                                                <td width="10%">
                                                    <asp:CheckBox ID="CheckBox8279" runat="server" CssClass="checkbox" Text="8279" TextAlign="Left" Enabled="False" />
                                                </td>
                                                <td width="10%">
                                                    <asp:CheckBox ID="CheckBox8379" runat="server" CssClass="checkbox" Text="8379" TextAlign="Left" Enabled="False" />
                                                </td>
                                                <td width="10%">
                                                    <asp:CheckBox ID="CheckBox8479" runat="server" CssClass="checkbox" Text="8479" TextAlign="Left" Enabled="False" />
                                                </td>
                                                <td width="10%">
                                                    <asp:CheckBox ID="CheckBox8579" runat="server" CssClass="checkbox" Text="8579" TextAlign="Left" Enabled="False" />
                                                </td>
                                                <td width="10%">
                                                    <asp:CheckBox ID="CheckBox8679" runat="server" CssClass="checkbox" Text="8679" TextAlign="Left" Enabled="False" />
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="CheckBox8779" runat="server" CssClass="checkbox" Text="8779" TextAlign="Left" Enabled="False" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" width="20%">
                                        <asp:CheckBox ID="CheckBox6x66" runat="server" CssClass="checkbox" Font-Bold="True" Text="6x66" TextAlign="Left" />
                                    </td>
                                    <td align="left">
                                        <table class="auto-style1">
                                            <tr>
                                                <td width="10%">
                                                    <asp:CheckBox ID="CheckBox6066" runat="server" CssClass="checkbox" Text="6066" TextAlign="Left" Enabled="False" />
                                                </td>
                                                <td width="10%">
                                                    <asp:CheckBox ID="CheckBox6166" runat="server" CssClass="checkbox" Text="6166" TextAlign="Left" Enabled="False" />
                                                </td>
                                                <td width="10%">
                                                    <asp:CheckBox ID="CheckBox6266" runat="server" CssClass="checkbox" Text="6266" TextAlign="Left" Enabled="False" />
                                                </td>
                                                <td width="10%">
                                                    <asp:CheckBox ID="CheckBox6366" runat="server" CssClass="checkbox" Text="6366" TextAlign="Left" Enabled="False" />
                                                </td>
                                                <td width="10%">
                                                    <asp:CheckBox ID="CheckBox6466" runat="server" CssClass="checkbox" Text="6466" TextAlign="Left" Enabled="False" />
                                                </td>
                                                <td width="10%">
                                                    <asp:CheckBox ID="CheckBox6566" runat="server" CssClass="checkbox" Text="6566" TextAlign="Left" Enabled="False" />
                                                </td>
                                                <td width="10%">
                                                    <asp:CheckBox ID="CheckBox6666" runat="server" CssClass="checkbox" Text="6666" TextAlign="Left" Enabled="False" />
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="CheckBox6766" runat="server" CssClass="checkbox" Text="6766" TextAlign="Left" Enabled="False" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" width="20%">
                                        <asp:CheckBox ID="CheckBox8x99" runat="server" CssClass="checkbox" Font-Bold="True" Text="8x99" TextAlign="Left" />
                                    </td>
                                    <td align="left">
                                        <table class="auto-style1">
                                            <tr>
                                                <td width="10%">
                                                    <asp:CheckBox ID="CheckBox8099" runat="server" CssClass="checkbox" Text="8099" TextAlign="Left" Enabled="False" />
                                                </td>
                                                <td width="10%">
                                                    <asp:CheckBox ID="CheckBox8199" runat="server" CssClass="checkbox" Text="8199" TextAlign="Left" Enabled="False" />
                                                </td>
                                                <td width="10%">
                                                    <asp:CheckBox ID="CheckBox8299" runat="server" CssClass="checkbox" Text="8299" TextAlign="Left" Enabled="False" />
                                                </td>
                                                <td width="10%">
                                                    <asp:CheckBox ID="CheckBox8399" runat="server" CssClass="checkbox" Text="8399" TextAlign="Left" Enabled="False" />
                                                </td>
                                                <td width="10%">
                                                    <asp:CheckBox ID="CheckBox8499" runat="server" CssClass="checkbox" Text="8499" TextAlign="Left" Enabled="False" />
                                                </td>
                                                <td width="10%">
                                                    <asp:CheckBox ID="CheckBox8599" runat="server" CssClass="checkbox" Text="8599" TextAlign="Left" Enabled="False" />
                                                </td>
                                                <td width="10%">
                                                    <asp:CheckBox ID="CheckBox8699" runat="server" CssClass="checkbox" Text="8699" TextAlign="Left" Enabled="False" />
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="CheckBox8799" runat="server" CssClass="checkbox" Text="8799" TextAlign="Left" Enabled="False" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" width="20%">
                                        <asp:Label ID="Label54" runat="server" CssClass="label">Mã dịch vụ:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtKeyWordQ8" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                            Width="10%" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" width="20%">
                                        <asp:Label ID="Label82" runat="server" CssClass="label">Địa chỉ định tuyến MO:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtRouting_UrlQ8" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                            Width="90%" Font-Bold="False" ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label84" runat="server" CssClass="label">Nội dung MT:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtMTQ8" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                            Width="90%" Font-Bold="False" Height="53px" TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label85" runat="server" CssClass="label">File đính kèm:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lblUserFileQ8" runat="server" CssClass="label" ForeColor="#0033CC"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label55" runat="server" CssClass="label">Dịch vụ:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DropDownListCate_1Q8" runat="server" CssClass="droplist" Enabled="False">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label57" runat="server" CssClass="label">Trạng thái hiện tại:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DropDownListStatus_IdQ8" runat="server" CssClass="droplist" Enabled="False">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label58" runat="server" CssClass="label">Ghi chú:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtDescriptionQ8" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                            Height="42px" TextMode="MultiLine" Width="100%" ReadOnly="True"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">&nbsp;</td>
                                    <td align="left">
                                        <asp:Label ID="Label110" runat="server" CssClass="lbltitle" Font-Bold="False" ForeColor="Red">»Xử lý Ticket:</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label111" runat="server" CssClass="label">Định tuyến:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DropDownListRouting_CodeQ8Proc" runat="server" CssClass="droplist">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label112" runat="server" CssClass="label">Trạng thái xử lý:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DropDownListStatus_IdQ8Proc" runat="server" CssClass="droplist" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label114" runat="server" CssClass="label">Chuyển đến nhóm xử lý:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DropDownListGroup_Handle_IdQ8Proc" runat="server" CssClass="droplist">
                                            <asp:ListItem Value="0">--Chọn--</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label113" runat="server" CssClass="label">Ghi chú:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtDescriptionQ8Proc" runat="server" AutoCompleteType="Disabled" CssClass="txtContent" Height="42px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="submmit">
                            <asp:Button ID="btnUpdateQ8" runat="server" CssClass="btnbackground"
                                Text="Ghi lại" />

                            <asp:Button ID="btnCancelQ8" runat="server" CssClass="btnbackground"
                                Text="Hủy" />
                        </div>
                    </telerik:RadPageView>

                </telerik:RadMultiPage>
            </div>

        </div>
    </form>
</body>
</html>
