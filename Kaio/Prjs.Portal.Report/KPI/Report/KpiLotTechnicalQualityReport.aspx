<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="KpiLotTechnicalQualityReport.aspx.vb" Inherits="Prjs.Portal.Report.KpiLotTechnicalQualityReport" %>

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
        </telerik:RadAjaxManager>
        <div id="HQ">
            <div class="alert">
                <asp:Label ID="lbltitle" runat="server" CssClass="lbltitle"></asp:Label><br />
                <asp:Label ID="lblerror" runat="server" CssClass="lblerror"></asp:Label>
                <telerik:RadTabStrip runat="server" ID="RadTabStrip1" MultiPageID="RadMultiPage1" Skin="Forest" Font-Bold="False" Font-Names="Arial" SelectedIndex="0">
                    <Tabs>
                        <telerik:RadTab Text="Thời gian nhận MT về máy" Font-Names="Arial" Selected="True">
                        </telerik:RadTab>
                        <telerik:RadTab Text="Thời gian xử lý Process" Font-Names="Arial">
                        </telerik:RadTab>
                        <telerik:RadTab Text="Thời gian MT sang Telcos" Font-Names="Arial">
                        </telerik:RadTab>
                        <telerik:RadTab Text="Lỗi hệ thống" Font-Names="Arial">
                        </telerik:RadTab>
                        <telerik:RadTab Text="MT lỗi" Font-Names="Arial">
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
                <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0" Width="99%"
                    CssClass="multiPage">
                    <telerik:RadPageView runat="server" ID="RadPageViewQ1" CssClass="PageView">
                        <div class="parametter" style="margin: 1px auto 1px auto; border-color: #B4B4B4; width: 60%; background-color: #E1EDD4;">
                            <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                                <tr>
                                    <td align="center">
                                        <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                                            <tr>
                                                <td align="right" width="20%">
                                                    <asp:Label ID="Label83" runat="server" CssClass="label">Từ ngày:</asp:Label></td>
                                                <td align="left">
                                                    <telerik:RadDatePicker ID="RadFromDateQ1" runat="server" Culture="vi-VN" rMinDate="2006/01/01" Skin="Forest" ZIndex="30001">
                                                        <Calendar Skin="Forest" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>
                                                        <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput><DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                    </telerik:RadDatePicker>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label6" runat="server" CssClass="label">Đến ngày:</asp:Label></td>
                                                <td align="left">
                                                    <telerik:RadDatePicker ID="RadToDateQ1" runat="server" Culture="vi-VN" rMinDate="2006/01/01" Skin="Forest" ZIndex="30001">
                                                        <Calendar Skin="Forest" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>
                                                        <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput><DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                    </telerik:RadDatePicker>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label1" runat="server" CssClass="label">Mạng:</asp:Label></td>
                                                <td align="left">
                                                    <asp:DropDownList ID="DropDownListMobile_OperatorQ1" runat="server" CssClass="droplist">
                                                        <asp:ListItem Value="0">--all--</asp:ListItem>
                                                        <asp:ListItem Value="1">VINA</asp:ListItem>
                                                        <asp:ListItem Value="2">GTEL</asp:ListItem>
                                                        <asp:ListItem Value="3">VIETTEL</asp:ListItem>
                                                        <asp:ListItem Value="4">MOBI</asp:ListItem>
                                                        <asp:ListItem Value="5">VNM</asp:ListItem>
                                                    </asp:DropDownList></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="submmit">
                            <asp:Button ID="btnSearchQ1" runat="server" CssClass="btnbackground"
                                Text="Tìm kiếm" /><asp:Button ID="btnExpQ1" runat="server" CssClass="btnbackground"
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
                                        <HeaderTemplate>#</HeaderTemplate>
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
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Mobile_Operator_TextQ1" runat="server" CssClass="label"> <%# DataBinder.Eval(Container.DataItem, "Mobile_Operator_Text")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="TỶ TRỌNG">
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                        <ItemTemplate>
                                            <asp:Label ID="PercentageQ1" runat="server" CssClass="label"> <%# DataBinder.Eval(Container.DataItem, "Percentage")%>
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
                                            <asp:Label ID="TotalTimeQ1" runat="server" CssClass="label" Font-Bold="true">  <%# ConvertTimeSS(Eval("Total_Sec"))%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="ĐIỂM TRỪ T/G">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Decrease_Percent_Total_1Q1" runat="server" CssClass="label" Font-Bold="true" ForeColor="Blue">  <%# Eval("Decrease_Percent_Total_1")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="ĐIỂM TRỪ TT">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Decrease_Percent_Total_2Q1" runat="server" CssClass="label" Font-Bold="true" ForeColor="Red">  <%# Eval("Decrease_Percent_Total_2")%>
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
                                </Columns>
                                <PagerStyle HorizontalAlign="Right" NextPageText="" PageButtonCount="5" PrevPageText="" Visible="False" />
                            </asp:DataGrid>
                        </div>
                    </telerik:RadPageView>
                    <telerik:RadPageView runat="server" ID="RadPageViewQ2" CssClass="PageView">
                        <div class="parametter" style="margin: 1px auto 1px auto; border-color: #B4B4B4; width: 60%; background-color: #E1EDD4;">
                            <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                                <tr>
                                    <td align="center">
                                        <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                                            <tr>
                                                <td align="right" width="30%">
                                                    <asp:Label ID="Label84" runat="server" CssClass="label">Từ ngày:</asp:Label></td>
                                                <td align="left">
                                                    <telerik:RadDatePicker ID="RadFromDateQ2" runat="server" Culture="vi-VN" rMinDate="2006/01/01" Skin="Forest" ZIndex="30001">
                                                        <Calendar Skin="Forest" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>
                                                        <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput><DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                    </telerik:RadDatePicker>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label2" runat="server" CssClass="label">Đến ngày:</asp:Label></td>
                                                <td align="left">
                                                    <telerik:RadDatePicker ID="RadToDateQ2" runat="server" Culture="vi-VN" rMinDate="2006/01/01" Skin="Forest" ZIndex="30001">
                                                        <Calendar Skin="Forest" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>
                                                        <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput><DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                    </telerik:RadDatePicker>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label4" runat="server" CssClass="label">Mạng:</asp:Label></td>
                                                <td align="left">
                                                    <asp:DropDownList ID="DropDownListMobile_OperatorQ2" runat="server" CssClass="droplist">
                                                        <asp:ListItem Value="0">--all--</asp:ListItem>
                                                        <asp:ListItem Value="1">GPC</asp:ListItem>
                                                        <asp:ListItem Value="2">GTEL</asp:ListItem>
                                                        <asp:ListItem Value="3">VIETTEL</asp:ListItem>
                                                        <asp:ListItem Value="4">VMS</asp:ListItem>
                                                        <asp:ListItem Value="5">VNM</asp:ListItem>
                                                    </asp:DropDownList></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="submmit">
                            <asp:Button ID="btnSearchQ2" runat="server" CssClass="btnbackground"
                                Text="Tìm kiếm" /><asp:Button ID="btnExpQ2" runat="server" CssClass="btnbackground"
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
                                        <HeaderTemplate>#</HeaderTemplate>
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
                                    <asp:TemplateColumn HeaderText="TỔNG THỜI GIAN">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:Label ID="TotalTimeQ2" runat="server" CssClass="label" Font-Bold="true">&#160;<%# UtilsNumeric.CommasInPlaceOfDecimals(Eval("Total_Sec"),3)%>  
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="ĐIỂM TRỪ">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Decrease_Percent_Total_2Q2" runat="server" CssClass="label" Font-Bold="true" ForeColor="Red"><%# Eval("Decrease_Percent_Total")%>  
                                            
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="KHỞI TẠO">
                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Create_TimeQ2" runat="server" CssClass="label">&#160;<%# DateTime.Parse(Eval("Create_Time")).ToString("dd-MM-yyyy HH:mm:ss")%>  
                                            
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                </Columns>
                                <PagerStyle HorizontalAlign="Right" NextPageText="" PageButtonCount="5" PrevPageText="" Visible="False" />
                            </asp:DataGrid>
                        </div>
                    </telerik:RadPageView>
                    <telerik:RadPageView runat="server" ID="RadPageViewQ3" CssClass="PageView">
                        <div class="parametter" style="margin: 1px auto 1px auto; border-color: #B4B4B4; width: 60%; background-color: #E1EDD4;">
                            <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                                <tr>
                                    <td align="center">
                                        <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                                            <tr>
                                                <td align="right" width="30%">
                                                    <asp:Label ID="Label3" runat="server" CssClass="label">Từ ngày:</asp:Label></td>
                                                <td align="left">
                                                    <telerik:RadDatePicker ID="RadFromDateQ3" runat="server" Culture="vi-VN" rMinDate="2006/01/01" Skin="Forest" ZIndex="30001">
                                                        <Calendar Skin="Forest" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>
                                                        <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput><DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                    </telerik:RadDatePicker>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label5" runat="server" CssClass="label">Đến ngày:</asp:Label></td>
                                                <td align="left">
                                                    <telerik:RadDatePicker ID="RadToDateQ3" runat="server" Culture="vi-VN" rMinDate="2006/01/01" Skin="Forest" ZIndex="30001">
                                                        <Calendar Skin="Forest" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>
                                                        <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput><DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                    </telerik:RadDatePicker>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label7" runat="server" CssClass="label">Mạng:</asp:Label></td>
                                                <td align="left">
                                                    <asp:DropDownList ID="DropDownListMobile_OperatorQ3" runat="server" CssClass="droplist">
                                                        <asp:ListItem Value="0">--all--</asp:ListItem>
                                                        <asp:ListItem Value="1">GPC</asp:ListItem>
                                                        <asp:ListItem Value="2">GTEL</asp:ListItem>
                                                        <asp:ListItem Value="3">VIETTEL</asp:ListItem>
                                                        <asp:ListItem Value="4">VMS</asp:ListItem>
                                                        <asp:ListItem Value="5">VNM</asp:ListItem>
                                                    </asp:DropDownList></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="submmit">
                            <asp:Button ID="btnSearchQ3" runat="server" CssClass="btnbackground"
                                Text="Tìm kiếm" /><asp:Button ID="btnExpQ3" runat="server" CssClass="btnbackground"
                                    Text="Báo cáo" />
                        </div>
                        <div class="pager">
                            <cc1:PagerV2_8 ID="PagerQ3" runat="server" GenerateGoToSection="true"
                                Font-Size="10pt" PageSize="50" />
                        </div>
                        <div class="datagrid">
                            <asp:DataGrid ID="DataGridQ3" runat="server" AllowPaging="True" AutoGenerateColumns="false" CellPadding="0" CssClass="datagrid" EnableViewState="False" GridLines="None" PagerStyle-Mode="NextPrev" PagerStyle-Visible="true" PageSize="50" Width="100%">
                                <HeaderStyle CssClass="datagridHeader" />
                                <AlternatingItemStyle CssClass="datagridAlternatingItemStyle" />
                                <ItemStyle CssClass="datagridItemStyle" />
                                <Columns>
                                    <asp:TemplateColumn>
                                        <HeaderStyle HorizontalAlign="Center" Width="3%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>#</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblOrder1" runat="server" CssClass="label" Text="<%# Container.ItemIndex+1 %>">
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="NGÀY">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Date_IdQ3" runat="server" CssClass="label"> <%#DateTime.Parse(Eval("Date_Id")).ToString("dd-MM-yyyy")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="MẠNG">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Mobile_Operator_TextQ3" runat="server" CssClass="label"> <%#Eval("Mobile_Operator_Text")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="TỔNG THỜI GIAN">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:Label ID="TotalTimeQ3" runat="server" CssClass="label" Font-Bold="true">  <%# UtilsNumeric.CommasInPlaceOfDecimals(Eval("Total_Sec"),3)%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="ĐIỂM TRỪ">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Decrease_Percent_Total_2Q3" runat="server" CssClass="label" Font-Bold="true" ForeColor="Red">  <%# Eval("Decrease_Percent_Total")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="KHỞI TẠO">
                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Create_TimeQ3" runat="server" CssClass="label">  <%# DateTime.Parse(Eval("Create_Time")).ToString("dd-MM-yyyy HH:mm:ss")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                </Columns>
                                <PagerStyle HorizontalAlign="Right" NextPageText="" PageButtonCount="5" PrevPageText="" Visible="False" />
                            </asp:DataGrid>
                        </div>
                    </telerik:RadPageView>
                    <telerik:RadPageView runat="server" ID="RadPageViewQ4" CssClass="PageView">
                        <div class="parametter" style="margin: 1px auto 1px auto; border-color: #B4B4B4; width: 60%; background-color: #E1EDD4;">
                            <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                                <tr>
                                    <td align="center">
                                        <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                                            <tr>
                                                <td align="right" width="30%">
                                                    <asp:Label ID="Label10" runat="server" CssClass="label">Từ ngày:</asp:Label></td>
                                                <td align="left">
                                                    <telerik:RadDatePicker ID="RadFromDateQ4" runat="server" Culture="vi-VN" rMinDate="2006/01/01" Skin="Forest" ZIndex="30001">
                                                        <Calendar Skin="Forest" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>
                                                        <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput><DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                    </telerik:RadDatePicker>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label82" runat="server" CssClass="label">Đến ngày:</asp:Label></td>
                                                <td align="left">
                                                    <telerik:RadDatePicker ID="RadToDateQ4" runat="server" Culture="vi-VN" rMinDate="2006/01/01" Skin="Forest" ZIndex="30001">
                                                        <Calendar Skin="Forest" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>
                                                        <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput><DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                    </telerik:RadDatePicker>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label12" runat="server" CssClass="label">Loại lỗi:</asp:Label></td>
                                                <td align="left">
                                                    <asp:DropDownList ID="DropDownListErrorCodeQ4" runat="server" CssClass="droplist">
                                                        <asp:ListItem Value="0">--Chọn--</asp:ListItem>
                                                        <asp:ListItem Value="1">GPC</asp:ListItem>
                                                        <asp:ListItem Value="2">GTEL</asp:ListItem>
                                                        <asp:ListItem Value="3">VIETTEL</asp:ListItem>
                                                        <asp:ListItem Value="4">VMS</asp:ListItem>
                                                        <asp:ListItem Value="5">VNM</asp:ListItem>
                                                    </asp:DropDownList></td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label81" runat="server" CssClass="label">Nội dung:</asp:Label></td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtError_DescQ4" runat="server" AutoCompleteType="Disabled" CssClass="txtContent" TextMode="MultiLine" Width="90%"></asp:TextBox></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="submmit">
                            <asp:Button ID="btnSearchQ4" runat="server" CssClass="btnbackground"
                                Text="Tìm kiếm" /><asp:Button ID="btnExpQ4" runat="server" CssClass="btnbackground"
                                    Text="Báo cáo" />
                        </div>
                        <div class="pager">
                            <cc1:PagerV2_8 ID="PagerQ4" runat="server" GenerateGoToSection="true"
                                Font-Size="10pt" PageSize="50" />
                        </div>
                        <div class="datagrid">
                            <asp:DataGrid ID="DataGridQ4" runat="server" AllowPaging="True" AutoGenerateColumns="false" CellPadding="0" CssClass="datagrid" EnableViewState="False" GridLines="None" PagerStyle-Mode="NextPrev" PagerStyle-Visible="true" PageSize="50" Width="100%">
                                <HeaderStyle CssClass="datagridHeader" />
                                <AlternatingItemStyle CssClass="datagridAlternatingItemStyle" />
                                <ItemStyle CssClass="datagridItemStyle" />
                                <Columns>
                                    <asp:TemplateColumn>
                                        <HeaderStyle HorizontalAlign="Center" Width="3%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>#</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblOrder1" runat="server" CssClass="label" Text="<%# Container.ItemIndex+1 %>">
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="NGÀY">
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Date_IdQ4" runat="server" CssClass="label"> <%#DateTime.Parse(Eval("Date_Id")).ToString("dd-MM-yyyy")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="NỘI DUNG">
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Error_DescQ4" runat="server" CssClass="label"> <%# DataBinder.Eval(Container.DataItem, "Error_Desc")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="LOẠI LỖI">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Error_TextQ4" runat="server" CssClass="label"> <%# DataBinder.Eval(Container.DataItem, "Error_Text")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="THỜI GIAN BẮT ĐẦU">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Time_Start_IdQ4" runat="server" CssClass="label"> <%# DateTime.Parse(Eval("Time_Start_Id")).ToString("dd-MM-yyyy HH:mm:ss")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="THỜI GIAN KẾT THÚC">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Time_End_IdQ4" runat="server" CssClass="label">  <%# DateTime.Parse(Eval("Time_End_Id")).ToString("dd-MM-yyyy HH:mm:ss")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="TỔNG T/G">
                                        <ItemStyle HorizontalAlign="Center" Width="6%" />
                                        <ItemTemplate>
                                            <asp:Label ID="TotalTimeQ4" runat="server" CssClass="label" Font-Bold="true">  <%# ConvertTimeSS(Eval("Total_Sec"))%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="TRỪ LỖI">
                                        <ItemStyle HorizontalAlign="Center" Width="6%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Decrease_Percent_ErrorQ4" runat="server" CssClass="label" ForeColor="Blue">  <%# Eval("Decrease_Percent_Error")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="TRỪ T/G">
                                        <ItemStyle HorizontalAlign="Center" Width="6%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Decrease_Percent_Total_TimeQ4" runat="server" CssClass="label" ForeColor="red">  <%# Eval("Decrease_Percent_Total_Time")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="TRỪ TỔNG">
                                        <ItemStyle HorizontalAlign="Center" Width="6%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Decrease_Percent_TotalQ4" runat="server" CssClass="label" Font-Bold="true">  <%# Eval("Decrease_Percent_Total")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="KHỞI TẠO">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Create_TimeQ4" runat="server" CssClass="label">  <%# DateTime.Parse(Eval("Create_Time")).ToString("dd-MM-yyyy HH:mm:ss")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                </Columns>
                                <PagerStyle HorizontalAlign="Right" NextPageText="" PageButtonCount="5" PrevPageText="" Visible="False" />
                            </asp:DataGrid>
                        </div>
                    </telerik:RadPageView>
                    <telerik:RadPageView runat="server" ID="RadPageViewQ5" CssClass="PageView">
                        <div class="parametter" style="margin: 1px auto 1px auto; border-color: #B4B4B4; width: 60%; background-color: #E1EDD4;">
                            <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                                <tr>
                                    <td align="center">
                                        <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                                            <tr>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label85" runat="server" CssClass="label">Từ ngày:</asp:Label>
                                                </td>
                                                <td align="left" width="35%">
                                                    <telerik:RadDatePicker ID="RadFromDateQ5" runat="server" Culture="vi-VN" rMinDate="2006/01/01" Skin="Forest" ZIndex="30001">
                                                        <Calendar Skin="Forest" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                        </Calendar>
                                                        <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%">
                                                        </DateInput>
                                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                    </telerik:RadDatePicker>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label15" runat="server" CssClass="label">Đến ngày:</asp:Label></td>
                                                <td align="left" width="35%">
                                                    <telerik:RadDatePicker ID="RadToDateQ5" runat="server" Culture="vi-VN" rMinDate="2006/01/01" Skin="Forest" ZIndex="30001">
                                                        <Calendar Skin="Forest" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x"></Calendar>
                                                        <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput><DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                    </telerik:RadDatePicker>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label17" runat="server" CssClass="label">Tỷ lệ MT lỗi:</asp:Label></td>
                                                <td align="left">
                                                    <telerik:RadNumericTextBox ID="txtPercent_ErrorQ5" runat="server" CssClass="txtContent" Culture="vi-VN" DataType="System.Decimal" Font-Bold="True" Font-Names="Arial" IncrementSettings-InterceptArrowKeys="true" IncrementSettings-InterceptMouseWheel="true" LabelWidth="" ShowSpinButtons="true" Skin="Forest" Width="100px">
                                                        <NumberFormat DecimalDigits="3" ZeroPattern="n" />
                                                    </telerik:RadNumericTextBox></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="submmit">
                            <asp:Button ID="btnSearchQ5" runat="server" CssClass="btnbackground"
                                Text="Tìm kiếm" /><asp:Button ID="btnExpQ5" runat="server" CssClass="btnbackground"
                                    Text="Báo cáo" />
                        </div>
                        <div class="pager">
                            <cc1:PagerV2_8 ID="PagerQ5" runat="server" GenerateGoToSection="true"
                                Font-Size="10pt" PageSize="50" />
                        </div>
                        <div class="datagrid">
                            <asp:DataGrid ID="DataGridQ5" runat="server" AllowPaging="True" AutoGenerateColumns="false" CellPadding="0" CssClass="datagrid" EnableViewState="False" GridLines="None" PagerStyle-Mode="NextPrev" PagerStyle-Visible="true" PageSize="50" Width="100%">
                                <HeaderStyle CssClass="datagridHeader" />
                                <AlternatingItemStyle CssClass="datagridAlternatingItemStyle" />
                                <ItemStyle CssClass="datagridItemStyle" />
                                <Columns>
                                    <asp:TemplateColumn>
                                        <HeaderStyle HorizontalAlign="Center" Width="3%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>#</HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblOrder1" runat="server" CssClass="label" Text="<%# Container.ItemIndex+1 %>">
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="NGÀY">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Date_IdQ5" runat="server" CssClass="label"> <%#DateTime.Parse(Eval("Date_Id")).ToString("dd-MM-yyyy")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="TỶ LỆ MT LỖI">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Percent_ErrorQ5" runat="server" CssClass="label"> <%# DataBinder.Eval(Container.DataItem, "Percent_Error")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="ĐIỂM TRỪ ">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Decrease_Percent_TotalQ5" runat="server" CssClass="label" ForeColor="red">  <%# Eval("Decrease_Percent_Total")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="KHỞI TẠO">
                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Create_TimeQ5" runat="server" CssClass="label">  <%# DateTime.Parse(Eval("Create_Time")).ToString("dd-MM-yyyy HH:mm:ss")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="GHI CHÚ">
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                        <ItemTemplate>
                                            <asp:Label ID="DescriptionQ5" runat="server" CssClass="label">  <%# Eval("Description")%>
                                            </asp:Label>
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
