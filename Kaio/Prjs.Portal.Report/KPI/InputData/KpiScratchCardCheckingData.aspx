<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="KpiScratchCardCheckingData.aspx.vb" Inherits="Prjs.Portal.Report.KpiScratchCardCheckingData" %>

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
            height: 26px;
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
                <telerik:AjaxSetting AjaxControlID="RadTime_StartQ1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="txtTotal_DayQ1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="RadDate_IdQ1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="lblTotalQ1" />
                        <telerik:AjaxUpdatedControl ControlID="PagerQ1" />
                        <telerik:AjaxUpdatedControl ControlID="DataGridQ1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="RadTime_EndQ1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="txtTotal_DayQ1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="DropDownListMobile_OperatorQ1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="DropDownListTypeOf_IdQ1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="DataGridQ1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="lbltitle_Q1" />
                        <telerik:AjaxUpdatedControl ControlID="RadTime_StartQ1" />
                        <telerik:AjaxUpdatedControl ControlID="RadDate_IdQ1" />
                        <telerik:AjaxUpdatedControl ControlID="RadTime_EndQ1" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListMobile_OperatorQ1" />
                        <telerik:AjaxUpdatedControl ControlID="txtTotal_DayQ1" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListTypeOf_IdQ1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>

                <telerik:AjaxSetting AjaxControlID="RadTime_StartQ2">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="txtTotal_Day_1Q2" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="RadDate_IdQ2">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="lblTotalQ2" />
                        <telerik:AjaxUpdatedControl ControlID="PagerQ2" />
                        <telerik:AjaxUpdatedControl ControlID="DataGridQ2" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="RadTime_EndQ2">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="txtTotal_Day_1Q2" />
                        <telerik:AjaxUpdatedControl ControlID="txtTotal_Day_2Q2" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="DropDownListMobile_OperatorQ2">
                                   <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="DropDownListTypeOf_IdQ2" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="RadTime_PaymentQ2">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="txtTotal_Day_2Q2" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="DataGridQ2">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="lbltitle_Q2" />
                        <telerik:AjaxUpdatedControl ControlID="RadTime_StartQ2" />
                        <telerik:AjaxUpdatedControl ControlID="RadDate_IdQ2" />
                        <telerik:AjaxUpdatedControl ControlID="RadTime_EndQ2" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListMobile_OperatorQ2" />
                        <telerik:AjaxUpdatedControl ControlID="RadTime_PaymentQ2" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListTypeOf_IdQ2" />
                        <telerik:AjaxUpdatedControl ControlID="txtTotal_Day_1Q2" />
                        <telerik:AjaxUpdatedControl ControlID="txtTotal_Day_2Q2" />
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
                        <telerik:RadTab Text="Tiến độ đối soát" Font-Names="Arial" Selected="True">
                        </telerik:RadTab>
                        <telerik:RadTab Text="Tiến độ thanh toán - Xuất hóa đơn - Telcos thanh toán" Font-Names="Arial">
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
                                                <td align="left" width="20%">
                                                    <asp:Label ID="lbltitle_Q1" runat="server" CssClass="lblerror" Font-Bold="False"></asp:Label>
                                                </td>
                                                <td align="right" width="35%">
                                                    <asp:Label ID="Label6" runat="server" CssClass="label">Thời điểm thống nhất BB với Telcos</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <telerik:RadDatePicker ID="RadTime_StartQ1" runat="server" AutoPostBack="True" Culture="vi-VN" rMinDate="2006/01/01" Skin="Forest" ZIndex="30001">
                                                        <Calendar Skin="Forest" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                        </Calendar>
                                                        <DateInput AutoPostBack="True" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%">
                                                        </DateInput>
                                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                    </telerik:RadDatePicker>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="auto-style1">
                                                    <asp:Label ID="Label87" runat="server" CssClass="label">Ngày:</asp:Label>
                                                </td>
                                                <td align="left" class="auto-style1">
                                                    <telerik:RadDatePicker ID="RadDate_IdQ1" runat="server" AutoPostBack="True" Culture="vi-VN" rMinDate="2006/01/01" Skin="Forest" ZIndex="30001">
                                                        <Calendar Skin="Forest" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                        </Calendar>
                                                        <DateInput AutoPostBack="True" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%">
                                                        </DateInput>
                                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td align="right" width="15%" class="auto-style1">
                                                    <asp:Label ID="Label83" runat="server" CssClass="label">Thời điểm gửi thông tin sang Kế toán:</asp:Label>
                                                </td>
                                                <td align="left" class="auto-style1">
                                                    <telerik:RadDatePicker ID="RadTime_EndQ1" runat="server" AutoPostBack="True" Culture="vi-VN" rMinDate="2006/01/01" Skin="Forest" ZIndex="30001">
                                                        <Calendar Skin="Forest" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                        </Calendar>
                                                        <DateInput AutoPostBack="True" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%">
                                                        </DateInput>
                                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                    </telerik:RadDatePicker>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label89" runat="server" CssClass="label">Mạng:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="DropDownListMobile_OperatorQ1" runat="server" CssClass="droplist" Font-Bold="False" AutoPostBack="True">
                                                        <asp:ListItem Value="0">--Chọn--</asp:ListItem>
                                                        <asp:ListItem Value="1">VNP</asp:ListItem>
                                                        <asp:ListItem Value="2">VMS</asp:ListItem>
                                                        <asp:ListItem Value="3">VIETTEL</asp:ListItem>
                                                        <asp:ListItem Value="4">VNM</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label94" runat="server" CssClass="label">Tổng số ngày:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <telerik:RadNumericTextBox ID="txtTotal_DayQ1" runat="server" CssClass="txtContent" Culture="vi-VN" DataType="System.Decimal" Font-Bold="True" Font-Names="Arial" IncrementSettings-InterceptArrowKeys="true" IncrementSettings-InterceptMouseWheel="true" LabelWidth="" ShowSpinButtons="true" Skin="Forest" Width="100px">
                                                        <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                                                    </telerik:RadNumericTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label88" runat="server" CssClass="label">Chu kỳ đối soát:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="DropDownListTypeOf_IdQ1" runat="server" CssClass="droplist" Font-Bold="False">
                                                        <asp:ListItem Value="0">--Chọn--</asp:ListItem>
                                                        <asp:ListItem Value="1">Đối soát 1 lần/tháng</asp:ListItem>
                                                        <asp:ListItem Value="2">Đối soát 2 lần/tháng</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label93" runat="server" CssClass="label">Tổng số:</asp:Label>
                                                </td>
                                                <td align="left">
                                               
                                                    <asp:Label ID="lblTotalQ1" runat="server" CssClass="lblerror"></asp:Label>
                                               
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
                            <asp:Button ID="btDelQ1" runat="server" CssClass="btnbackground" Text="Xóa" />
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
                                            <input id="Check_All" name="Check_All" onclick="CheckAll_Click_Q1(this)" type="checkbox"> </input>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <input id="chkActive" runat="server" name="Add" value='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                                type="checkbox" onclick="Toggle(this)" />
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
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
                                    <asp:TemplateColumn HeaderText="MẠNG">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Mobile_Operator_TextQ1" runat="server" CssClass="label"> <%# DataBinder.Eval(Container.DataItem, "Mobile_Operator_Text")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="THỂ LOẠI">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:Label ID="TypeOf_TextQ1" runat="server" CssClass="label"> <%# DataBinder.Eval(Container.DataItem, "TypeOf_Text")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    
                                    <asp:TemplateColumn HeaderText="T/G THỐNG NHẤT TELCOS">
                                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Time_Start_IdQ1" runat="server" CssClass="label"> <%# DateTime.Parse(Eval("Time_Start_Id")).ToString("dd-MM-yyyy")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="T/G GỬI KT">
                                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Time_End_IdQ1" runat="server" CssClass="label">  <%# DateTime.Parse(Eval("Time_End_Id")).ToString("dd-MM-yyyy")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="TỔNG THỜI GIAN">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                                                                       <asp:Label ID="Total_DayQ1" runat="server" CssClass="label"  ForeColor="red">  <%# Eval("Total_Day")%>

                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="ĐIỂM TRỪ">
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Decrease_Percent_TotalQ1" runat="server" CssClass="label"  ForeColor="Blue">  <%# Eval("Decrease_Percent_Total")%>
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
                                                <td align="left" width="20%">
                                                    <asp:Label ID="lbltitle_Q2" runat="server" CssClass="lblerror" Font-Bold="False"></asp:Label>
                                                </td>
                                                <td align="right" width="35%">
                                                    <asp:Label ID="Label1" runat="server" CssClass="label">TG kế toán nhận được thông tin từ ĐSTC:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <telerik:RadDatePicker ID="RadTime_StartQ2" runat="server" AutoPostBack="True" Culture="vi-VN" rMinDate="2006/01/01" Skin="Forest" ZIndex="30001">
                                                        <Calendar Skin="Forest" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                        </Calendar>
                                                        <DateInput AutoPostBack="True" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%">
                                                        </DateInput>
                                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                    </telerik:RadDatePicker>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="auto-style1">
                                                    <asp:Label ID="Label2" runat="server" CssClass="label">Ngày:</asp:Label>
                                                </td>
                                                <td align="left" class="auto-style1">
                                                    <telerik:RadDatePicker ID="RadDate_IdQ2" runat="server" AutoPostBack="True" Culture="vi-VN" rMinDate="2006/01/01" Skin="Forest" ZIndex="30001">
                                                        <Calendar Skin="Forest" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                        </Calendar>
                                                        <DateInput AutoPostBack="True" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%">
                                                        </DateInput>
                                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td align="right" width="15%" class="auto-style1">
                                                    <asp:Label ID="Label3" runat="server" CssClass="label">TG xuất hóa đơn và gửi hồ sơ:</asp:Label>
                                                </td>
                                                <td align="left" class="auto-style1">
                                                    <telerik:RadDatePicker ID="RadTime_EndQ2" runat="server" AutoPostBack="True" Culture="vi-VN" rMinDate="2006/01/01" Skin="Forest" ZIndex="30001">
                                                        <Calendar Skin="Forest" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                        </Calendar>
                                                        <DateInput AutoPostBack="True" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%">
                                                        </DateInput>
                                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                    </telerik:RadDatePicker>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label4" runat="server" CssClass="label">Mạng:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="DropDownListMobile_OperatorQ2" runat="server" CssClass="droplist" Font-Bold="False" AutoPostBack="True">
                                                        <asp:ListItem Value="0">--Chọn--</asp:ListItem>
                                                        <asp:ListItem Value="1">VNP</asp:ListItem>
                                                        <asp:ListItem Value="2">VMS</asp:ListItem>
                                                        <asp:ListItem Value="3">VIETTEL</asp:ListItem>
                                                        <asp:ListItem Value="4">VNM</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label95" runat="server" CssClass="label">Thời điểm Telcos thanh toán:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <telerik:RadDatePicker ID="RadTime_PaymentQ2" runat="server" AutoPostBack="True" Culture="vi-VN" rMinDate="2006/01/01" Skin="Forest" ZIndex="30001">
                                                        <Calendar Skin="Forest" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                        </Calendar>
                                                        <DateInput AutoPostBack="True" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%">
                                                        </DateInput>
                                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                    </telerik:RadDatePicker>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label7" runat="server" CssClass="label">Chu kỳ đối soát:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="DropDownListTypeOf_IdQ2" runat="server" CssClass="droplist" Font-Bold="False">
                                                        <asp:ListItem Value="0">--Chọn--</asp:ListItem>
                                                        <asp:ListItem Value="1">Đối soát 1 lần/tháng</asp:ListItem>
                                                        <asp:ListItem Value="2">Đối soát 2 lần/tháng</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label5" runat="server" CssClass="label">Chênh lệch TG xuất hoá đơn:</asp:Label>
                                                </td>
                                                <td align="left">
                                               
                                                    <telerik:RadNumericTextBox ID="txtTotal_Day_1Q2" runat="server" CssClass="txtContent" Culture="vi-VN" DataType="System.Decimal" Font-Bold="True" Font-Names="Arial" IncrementSettings-InterceptArrowKeys="true" IncrementSettings-InterceptMouseWheel="true" LabelWidth="" ShowSpinButtons="true" Skin="Forest" Width="100px">
                                                        <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                                                    </telerik:RadNumericTextBox>
                                               
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label8" runat="server" CssClass="label">Tổng số:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblTotalQ2" runat="server" CssClass="lblerror"></asp:Label>
                                                </td>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label96" runat="server" CssClass="label">Chênh lệch TG Telcos thanh toán:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <telerik:RadNumericTextBox ID="txtTotal_Day_2Q2" runat="server" CssClass="txtContent" Culture="vi-VN" DataType="System.Decimal" Font-Bold="True" Font-Names="Arial" IncrementSettings-InterceptArrowKeys="true" IncrementSettings-InterceptMouseWheel="true" LabelWidth="" ShowSpinButtons="true" Skin="Forest" Width="100px">
                                                        <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                                                    </telerik:RadNumericTextBox>
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
                            <asp:Button ID="btDelQ2" runat="server" CssClass="btnbackground" Text="Xóa" />
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
                                            <input id="Check_All" name="Check_All" onclick="CheckAll_Click_Q2(this)" type="checkbox"> </input>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <input id="chkActive" runat="server" name="Add" value='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                                type="checkbox" onclick="Toggle(this)" />
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
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
                                    <asp:TemplateColumn HeaderText="MẠNG">
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Mobile_Operator_TextQ2" runat="server" CssClass="label"> <%# DataBinder.Eval(Container.DataItem, "Mobile_Operator_Text")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="THỂ LOẠI">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:Label ID="TypeOf_TextQ2" runat="server" CssClass="label"> <%# DataBinder.Eval(Container.DataItem, "TypeOf_Text")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    
                                    <asp:TemplateColumn HeaderText="T/G NHẬN THÔNG TIN TỪ ĐSTC">
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Time_Start_IdQ2" runat="server" CssClass="label"> <%# DateTime.Parse(Eval("Time_Start_Id")).ToString("dd-MM-yyyy")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="T/G XUẤT HĐ">
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Time_End_IdQ2" runat="server" CssClass="label">  <%# DateTime.Parse(Eval("Time_End_Id")).ToString("dd-MM-yyyy")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                       <asp:TemplateColumn HeaderText="T/G THANH TOÁN">
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Time_Payment_IdQ2" runat="server" CssClass="label">  <%# DateTime.Parse(Eval("Time_Payment_Id")).ToString("dd-MM-yyyy")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="CHÊNH LỆCH T/G XUẤT HĐ">
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                        <ItemTemplate>
                                                                                       <asp:Label ID="Total_Day_1Q2" runat="server" CssClass="label"  ForeColor="red">  <%# Eval("Total_Day_1")%>

                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                         <asp:TemplateColumn HeaderText="CHÊNH LỆCH T/G THANH TOÁN">
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                        <ItemTemplate>
                                                                                       <asp:Label ID="Total_Day_2Q2" runat="server" CssClass="label"  ForeColor="red">  <%# Eval("Total_Day_2")%>

                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="ĐIỂM TRỪ XUẤT HĐ">
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Decrease_Percent_Total_1Q2" runat="server" CssClass="label"  ForeColor="Blue">  <%# Eval("Decrease_Percent_Total_1")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                           <asp:TemplateColumn HeaderText="ĐIỂM TRỪ THANH TOÁN">
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Decrease_Percent_Total_2Q2" runat="server" CssClass="label"  ForeColor="Blue">  <%# Eval("Decrease_Percent_Total_2")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                             <asp:TemplateColumn HeaderText="ĐIỂM TRỪ TỔNG">
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Decrease_Percent_TotalQ2" runat="server" CssClass="label"  ForeColor="Blue">  <%# Eval("Decrease_Percent_Total")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn>
                                        <HeaderStyle HorizontalAlign="Center" Width="3%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            SỬA
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="EditerQ2" runat="server" BorderStyle="None" CausesValidation="False" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID")%>' ImageAlign="absmiddle" ImageUrl="~/Images/comment-edit-icon.png" OnCommand="EditQ2" title="Edit" />
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn>
                                        <HeaderStyle HorizontalAlign="Center" Width="3%" />
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
     <script type="text/javascript">
         var DataGridQ1 = document.getElementById('DataGridQ1');
         function CheckAll_Click_Q1(e) {
             if (e.checked) {
                 Check_All_Q1();
             }
             else {
                 Clear_All_Q1();
             }
         }
         function Check_All_Q1() {
             var chkList = DataGridQ1.getElementsByTagName('input');
             for (var i = 0; i < chkList.length; i++) {
                 chkList[i].checked = true;
             }
         }
         function Clear_All_Q1() {
             var chkList = DataGridQ1.getElementsByTagName('input');
             for (var i = 0; i < chkList.length; i++) {
                 chkList[i].checked = false;
             }
         }
    </script>
    <script type="text/javascript">
        var DataGridQ2 = document.getElementById('DataGridQ2');
        function CheckAll_Click_Q2(e) {
            if (e.checked) {
                Check_All_Q2();
            }
            else {
                Clear_All_Q2();
            }
        }
        function Check_All_Q2() {
            var chkList = DataGridQ2.getElementsByTagName('input');
            for (var i = 0; i < chkList.length; i++) {
                chkList[i].checked = true;
            }
        }
        function Clear_All_Q2() {
            var chkList = DataGridQ2.getElementsByTagName('input');
            for (var i = 0; i < chkList.length; i++) {
                chkList[i].checked = false;
            }
        }
    </script>
</body>
</html>
