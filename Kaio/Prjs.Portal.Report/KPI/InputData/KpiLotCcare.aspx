<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="KpiLotCcare.aspx.vb" Inherits="Prjs.Portal.Report.KpiLotCcare" %>

<%@ Register Assembly="ASPnetPagerV2_8" Namespace="ASPnetControls" TagPrefix="cc1" %>
<%@ Register Assembly="FilePickerControl" Namespace="AWS.FilePicker" TagPrefix="cc2" %>
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
                <telerik:AjaxSetting AjaxControlID="RadDate_IdQ1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="PagerQ1" />
                        <telerik:AjaxUpdatedControl ControlID="DataGridQ1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="DataGridQ1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="lbltitle_Q1" />
                        <telerik:AjaxUpdatedControl ControlID="RadDate_IdQ1" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListFromHourQ1" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListFromMinuteQ1" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListFromSecondQ1" />
                        <telerik:AjaxUpdatedControl ControlID="RadToDateQ1" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListToHourQ1" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListToMinuteQ1" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListToSecondQ1" />
                        <telerik:AjaxUpdatedControl ControlID="txtUser_IdQ1" />
                        <telerik:AjaxUpdatedControl ControlID="txtInfoQ1" />
                        <telerik:AjaxUpdatedControl ControlID="DataGridQ2" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="RadDateQ2">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="DataGridQ2" />
                    </UpdatedControls>
                </telerik:AjaxSetting>

                <telerik:AjaxSetting AjaxControlID="DataGridQ2">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="lbltitle_Q2" />
                        <telerik:AjaxUpdatedControl ControlID="RadDateQ2" />
                        <telerik:AjaxUpdatedControl ControlID="txtTotalWaitQ2" />
                        <telerik:AjaxUpdatedControl ControlID="txtTotalSevingQ2" />
                        <telerik:AjaxUpdatedControl ControlID="txtTotalSatisfiedQ2" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <div id="HQ">
            <div class="alert">
                <asp:Label ID="lbltitle" runat="server" CssClass="lbltitle"></asp:Label><br />
                <asp:Label ID="lblerror" runat="server" CssClass="lblerror"></asp:Label>
                <telerik:RadTabStrip runat="server" ID="RadTabStrip1" MultiPageID="RadMultiPage1" Skin="Forest" Font-Bold="False" Font-Names="Arial" SelectedIndex="0">
                    <Tabs>
                        <telerik:RadTab Text="Khiếu nại" Font-Names="Arial" Selected="True">
                        </telerik:RadTab>
                        <telerik:RadTab Text="Chăm sóc khách hàng" Font-Names="Arial">
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
                <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0" Width="99%"
                    CssClass="multiPage">
                    <telerik:RadPageView runat="server" ID="RadPageViewQ1" CssClass="PageView">
                        <div class="parametter" style="margin: 1px auto 1px auto; border-color: #B4B4B4; width: 80%; background-color: #E1EDD4;">
                            <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                                <tr>
                                    <td align="center">
                                        <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                                            <tr>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="lbltitleQ1" runat="server" CssClass="lblerror" Font-Bold="False">»</asp:Label>
                                                </td>
                                                <td align="left" width="35%">
                                                    <asp:Label ID="lbltitle_Q1" runat="server" CssClass="lblerror" Font-Bold="False"></asp:Label>
                                                </td>
                                                <td align="right" width="15%">&nbsp;</td>
                                                <td align="left">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label6" runat="server" CssClass="label">Thời gian bắt đầu</asp:Label>
                                                </td>
                                                <td align="left" width="35%">
                                                    <telerik:RadDatePicker ID="RadDate_IdQ1" runat="server" AutoPostBack="True" Culture="vi-VN" rMinDate="2006/01/01" Skin="Forest" ZIndex="30001">
                                                        <Calendar Skin="Forest" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                        </Calendar>
                                                        <DateInput AutoPostBack="True" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%">
                                                        </DateInput>
                                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label48" runat="server" CssClass="label">Lúc:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <table class="auto-style1">
                                                        <tr>
                                                            <td width="10%">
                                                                <asp:DropDownList ID="DropDownListFromHourQ1" runat="server" CssClass="droplist">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td width="10%">
                                                                <asp:DropDownList ID="DropDownListFromMinuteQ1" runat="server" CssClass="droplist">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListFromSecondQ1" runat="server" CssClass="droplist">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label83" runat="server" CssClass="label">Thời gian kết thúc:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <telerik:RadDatePicker ID="RadToDateQ1" runat="server" AutoPostBack="True" Culture="vi-VN" rMinDate="2006/01/01" Skin="Forest" ZIndex="30001">
                                                        <Calendar Skin="Forest" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                        </Calendar>
                                                        <DateInput AutoPostBack="True" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%">
                                                        </DateInput>
                                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="Label49" runat="server" CssClass="label">Lúc:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <table class="auto-style1">
                                                        <tr>
                                                            <td width="10%">
                                                                <asp:DropDownList ID="DropDownListToHourQ1" runat="server" CssClass="droplist">
                                                                </asp:DropDownList>
                                                            </td>

                                                            <td width="10%">
                                                                <asp:DropDownList ID="DropDownListToMinuteQ1" runat="server" CssClass="droplist">
                                                                </asp:DropDownList>
                                                            </td>

                                                            <td>
                                                                <asp:DropDownList ID="DropDownListToSecondQ1" runat="server" CssClass="droplist">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label1" runat="server" CssClass="label">Khách hàng:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtUser_IdQ1" runat="server" AutoCompleteType="Disabled" CssClass="txtContent" Font-Bold="True" Width="60%"></asp:TextBox>
                                                </td>
                                                <td align="right">&nbsp;</td>
                                                <td align="left">

                                                    <asp:Label ID="Label79" runat="server" CssClass="label" Font-Italic="True">(Giờ : Phút : Giây)</asp:Label>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label81" runat="server" CssClass="label">Nội dung:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtInfoQ1" runat="server" AutoCompleteType="Disabled" CssClass="txtContent" Font-Bold="True" TextMode="MultiLine" Width="98%"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="Label82" runat="server" CssClass="label">Trạng thái:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="DropDownListStatusQ1" runat="server" CssClass="droplist">
                                                        <asp:ListItem Value="1">Đã xử lý</asp:ListItem>
                                                        <asp:ListItem Value="0">Chưa xử lý</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="submmit">
                            <asp:Button ID="btnUpdateQ1" runat="server" CssClass="btnbackground"
                                Text="Ghi lại" />
                            <asp:Button ID="btnExpQ1" runat="server" CssClass="btnbackground"
                                Text="Báo cáo" />
                        </div>
                        <div class="pager">
                            <cc1:PagerV2_8 ID="PagerQ1" runat="server" GenerateGoToSection="true"
                                Font-Size="10pt" PageSize="50" />

                        </div>
                        <div class="datagrid">
                            <asp:DataGrid ID="DataGridQ1" runat="server" AllowPaging="True" AutoGenerateColumns="false" CellPadding="0" CssClass="datagrid" EnableViewState="False" GridLines="None" PagerStyle-Mode="NextPrev" PagerStyle-Visible="true" PageSize="50" Width="100%">
                                <HeaderStyle CssClass="datagridHeader" />
                                <AlternatingItemStyle CssClass="datagridAlternatingItemStyle" />
                                <ItemStyle CssClass="datagridItemStyle" />
                                <Columns>
                                    <asp:TemplateColumn>
                                        <HeaderStyle HorizontalAlign="Center" Width="3%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            #
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblOrder1" runat="server" CssClass="label" Text="<%# Container.ItemIndex+1 %>">
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="NGÀY">
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Date_IdQ1" runat="server" CssClass="label"> <%#DateTime.Parse(Eval("Date_Id")).ToString("dd-MM-yyyy")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="KHÁCH HÀNG">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:Label ID="User_IdQ1" runat="server" CssClass="label"> <%# DataBinder.Eval(Container.DataItem, "User_Id")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="NỘI DUNG KHIẾU NẠI">
                                        <ItemStyle HorizontalAlign="Left" Width="20%" />
                                        <ItemTemplate>
                                            <asp:Label ID="InfoQ1" runat="server" CssClass="label"> <%# DataBinder.Eval(Container.DataItem, "Info")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="THỜI GIAN BẮT ĐẦU">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Time_Start_IdQ1" runat="server" CssClass="label"> <%# DateTime.Parse(Eval("Time_Start_Id")).ToString("dd-MM-yyyy HH:mm:ss")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="THỜI GIAN KẾT THÚC">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Time_End_IdQ1" runat="server" CssClass="label">  <%# DateTime.Parse(Eval("Time_End_Id")).ToString("dd-MM-yyyy HH:mm:ss")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="TỔNG THỜI GIAN">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:Label ID="TotalTimeQ1" runat="server" CssClass="label"  >  <%# ConvertTimeSS(Eval("Total_Sec"))%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="ĐIỂM TRỪ T/G">
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Decrease_Percent_TotalQ1" runat="server" CssClass="label"  ForeColor="Blue">  <%# Eval("Decrease_Percent_Total")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="KẾT QUẢ">
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Status_TextQ1" runat="server" CssClass="label"   ForeColor="Red">  <%# Eval("Status_Text")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="KHỞI TẠO">
                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Create_TimeQ1" runat="server" CssClass="label">  <%# DateTime.Parse(Eval("Create_Time")).ToString("dd-MM-yyyy HH:mm:ss")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn>
                                        <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            SỬA
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="EditerQ1" runat="server" BorderStyle="None" CausesValidation="False" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID")%>' ImageAlign="absmiddle" ImageUrl="~/Images/comment-edit-icon.png" OnCommand="EditQ1" title="Edit" />
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn>
                                        <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            XÓA
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="DeleterQ1" runat="server" BorderStyle="None" CausesValidation="False" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID")%>' ImageAlign="absmiddle" ImageUrl="~/Images/del.gif" OnCommand="DelQ1" title="Delete" />
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                </Columns>
                                <PagerStyle HorizontalAlign="Right" NextPageText="" PageButtonCount="5" PrevPageText="" Visible="False" />
                            </asp:DataGrid>
                        </div>
                    </telerik:RadPageView>
                    <telerik:RadPageView runat="server" ID="RadPageViewQ2" CssClass="PageView">
                        <div class="parametter" style="margin: 1px auto 1px auto; border-color: #B4B4B4; width: 80%; background-color: #E1EDD4;">
                            <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                                <tr>
                                    <td align="center">
                                        <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                                            <tr>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="lbltitleQ2" runat="server" CssClass="lblerror" Font-Bold="False">»</asp:Label>
                                                </td>
                                                <td align="left" width="35%">
                                                    <asp:Label ID="lbltitle_Q2" runat="server" CssClass="lblerror" Font-Bold="False"></asp:Label>
                                                </td>
                                                <td align="right" width="15%">&nbsp;</td>
                                                <td align="left">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label2" runat="server" CssClass="label">Ngày:</asp:Label>
                                                </td>
                                                <td align="left" width="35%">
                                                    <telerik:RadDatePicker ID="RadDateQ2" runat="server" AutoPostBack="True" Culture="vi-VN" rMinDate="2006/01/01" Skin="Forest" ZIndex="30001">
                                                        <Calendar Skin="Forest" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                        </Calendar>
                                                        <DateInput AutoPostBack="True" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%">
                                                        </DateInput>
                                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label5" runat="server" CssClass="label">Thời gian KH chờ phục vụ:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <table class="auto-style1">
                                                        <tr>
                                                            <td width="120">
                                                                <telerik:RadNumericTextBox ID="txtTotalWaitQ2" runat="server" CssClass="txtContent" Culture="vi-VN" DataType="System.Int32" Font-Bold="True" Font-Names="Arial" IncrementSettings-InterceptArrowKeys="true" IncrementSettings-InterceptMouseWheel="true" LabelWidth="" ShowSpinButtons="true" Skin="Forest" Width="100px">
                                                                    <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                                                                </telerik:RadNumericTextBox>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label80" runat="server" CssClass="label">(Giây)</asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label4" runat="server" CssClass="label">Tỷ lệ phục vụ KH:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <table class="auto-style1">
                                                        <tr>
                                                            <td width="120">
                                                                <telerik:RadNumericTextBox ID="txtTotalSevingQ2" runat="server" CssClass="txtContent" Culture="vi-VN" DataType="System.Int32" Font-Bold="True" Font-Names="Arial" IncrementSettings-InterceptArrowKeys="true" IncrementSettings-InterceptMouseWheel="true" LabelWidth="" ShowSpinButtons="true" Skin="Forest" Width="100px">
                                                                    <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                                                                </telerik:RadNumericTextBox>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label85" runat="server" CssClass="label">(%)</asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="Label84" runat="server" CssClass="label">Mức độ hài lòng của KH:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <table class="auto-style1">
                                                        <tr>
                                                            <td width="120">
                                                                <telerik:RadNumericTextBox ID="txtTotalSatisfiedQ2" runat="server" CssClass="txtContent" Culture="vi-VN" DataType="System.Int32" Font-Bold="True" Font-Names="Arial" IncrementSettings-InterceptArrowKeys="true" IncrementSettings-InterceptMouseWheel="true" LabelWidth="" ShowSpinButtons="true" Skin="Forest" Width="100px">
                                                                    <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                                                                </telerik:RadNumericTextBox>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label86" runat="server" CssClass="label">(%)</asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="submmit">
                            <asp:Button ID="btnUpdateQ2" runat="server" CssClass="btnbackground"
                                Text="Ghi lại" />
                            <asp:Button ID="btnExpQ2" runat="server" CssClass="btnbackground"
                                Text="Báo cáo" />
                        </div>
                        <div class="pager">
                            <cc1:PagerV2_8 ID="PagerQ2" runat="server" GenerateGoToSection="true"
                                Font-Size="10pt" PageSize="50" />

                        </div>
                        <div class="datagrid">
                            <asp:DataGrid ID="DataGridQ2" runat="server" AllowPaging="True" AutoGenerateColumns="false" CellPadding="0" CssClass="datagrid" EnableViewState="False" GridLines="None" PagerStyle-Mode="NextPrev" PagerStyle-Visible="true" PageSize="50" Width="100%">
                                <HeaderStyle CssClass="datagridHeader" />
                                <AlternatingItemStyle CssClass="datagridAlternatingItemStyle" />
                                <ItemStyle CssClass="datagridItemStyle" />
                                <Columns>
                                    <asp:TemplateColumn>
                                        <HeaderStyle HorizontalAlign="Center" Width="3%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            #
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblOrder1" runat="server" CssClass="label" Text="<%# Container.ItemIndex+1 %>">
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="NGÀY">
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Date_IdQ2" runat="server" CssClass="label"> <%#DateTime.Parse(Eval("Date_Id")).ToString("dd-MM-yyyy")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>

                                    <asp:TemplateColumn HeaderText="TỶ LỆ PHỤC VỤ KH">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Total_ServeQ2" runat="server" CssClass="label" Font-Bold="true">  <%# Eval("Total_Serve")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                      <asp:TemplateColumn HeaderText="T/G KH CHỜ">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Total_WaitQ2" runat="server" CssClass="label" Font-Bold="true">  <%# Eval("Total_Wait")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                       <asp:TemplateColumn HeaderText="MỨC ĐỘ HÀI LÒNG">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Total_SatisfiedQ2" runat="server" CssClass="label" Font-Bold="true">  <%# Eval("Total_Satisfied")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="ĐIỂM TRỪ PHỤC VỤ KH">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Decrease_Percent_Total_ServeQ2" runat="server" CssClass="label" Font-Bold="true" ForeColor="Red">  <%# Eval("Decrease_Percent_Total_Serve")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                   
                                      <asp:TemplateColumn HeaderText="ĐIỂM TRỪ KH CHỜ">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Decrease_Percent_Total_WaitQ2" runat="server" CssClass="label" Font-Bold="true" ForeColor="Red">  <%# Eval("Decrease_Percent_Total_Wait")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                      <asp:TemplateColumn HeaderText="ĐIỂM TRỪ HÀI LÒNG">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Decrease_Percent_Total_SatisfiedQ2" runat="server" CssClass="label" Font-Bold="true" ForeColor="Red">  <%# Eval("Decrease_Percent_Total_Satisfied")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                       <asp:TemplateColumn HeaderText="ĐIỂM TRỪ TỔNG">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Decrease_Percent_TotalQ2" runat="server" CssClass="label" Font-Bold="true" ForeColor="Blue">  <%# Eval("Decrease_Percent_Total")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="KHỞI TẠO">
                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Create_TimeQ2" runat="server" CssClass="label">  <%# DateTime.Parse(Eval("Create_Time")).ToString("dd-MM-yyyy HH:mm:ss")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn>
                                        <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            SỬA
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="EditerQ2" runat="server" BorderStyle="None" CausesValidation="False" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID")%>' ImageAlign="absmiddle" ImageUrl="~/Images/comment-edit-icon.png" OnCommand="EditQ2" title="Edit" />
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn>
                                        <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            XÓA
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="DeleterQ2" runat="server" BorderStyle="None" CausesValidation="False" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID")%>' ImageAlign="absmiddle" ImageUrl="~/Images/del.gif" OnCommand="DelQ2" title="Delete" />
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                </Columns>
                                <PagerStyle HorizontalAlign="Right" NextPageText="" PageButtonCount="5" PrevPageText="" Visible="False" />
                            </asp:DataGrid>
                        </div>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </div>

        </div>
    </form>
</body>
</html>
