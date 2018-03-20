<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="KpiInfrasNetwork.aspx.vb" Inherits="Prjs.Portal.Report.KpiInfrasNetwork" %>

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

        .auto-style2 {
            height: 18px;
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
                        <telerik:AjaxUpdatedControl ControlID="DropDownListCriteria_IdQ1" />
                        <telerik:AjaxUpdatedControl ControlID="txtDescriptionQ1" />
                        <telerik:AjaxUpdatedControl ControlID="txtRatio_PercentQ1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="RadDate_IdQ2">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="PagerQ2" />
                        <telerik:AjaxUpdatedControl ControlID="DataGridQ2" />
                    </UpdatedControls>
                </telerik:AjaxSetting>

                <telerik:AjaxSetting AjaxControlID="DataGridQ2">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="lbltitle_Q2" />
                        <telerik:AjaxUpdatedControl ControlID="RadDate_IdQ2" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListCriteria_IdQ2" />
                        <telerik:AjaxUpdatedControl ControlID="txtDescriptionQ2" />
                        <telerik:AjaxUpdatedControl ControlID="txtRatio_PercentQ2" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="RadDate_IdQ3">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="PagerQ3" />
                        <telerik:AjaxUpdatedControl ControlID="DataGridQ3" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="DataGridQ3">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="lbltitle_Q3" />
                        <telerik:AjaxUpdatedControl ControlID="RadDate_IdQ3" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListCriteria_IdQ3" />
                        <telerik:AjaxUpdatedControl ControlID="RadTime_Start_IdQ3" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListFromHourQ3" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListFromMinuteQ3" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListFromSecondQ3" />
                        <telerik:AjaxUpdatedControl ControlID="RadTime_End_IdQ3" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListToHourQ3" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListToMinuteQ3" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListToSecondQ3" />
                        <telerik:AjaxUpdatedControl ControlID="txtError_DescQ3" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="RadDate_IdQ4">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="PagerQ4" />
                        <telerik:AjaxUpdatedControl ControlID="DataGridQ4" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="DataGridQ4">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="lbltitle_Q4" />
                        <telerik:AjaxUpdatedControl ControlID="RadDate_IdQ4" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListCriteria_IdQ4" />
                        <telerik:AjaxUpdatedControl ControlID="RadTime_Start_IdQ4" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListFromHourQ4" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListFromMinuteQ4" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListFromSecondQ4" />
                        <telerik:AjaxUpdatedControl ControlID="RadTime_End_IdQ4" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListToHourQ4" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListToMinuteQ4" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListToSecondQ4" />
                        <telerik:AjaxUpdatedControl ControlID="txtError_DescQ4" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="RadDate_IdQ5">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="PagerQ5" />
                        <telerik:AjaxUpdatedControl ControlID="DataGridQ5" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="DataGridQ5">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="lbltitle_Q5" />
                        <telerik:AjaxUpdatedControl ControlID="RadDate_IdQ5" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListCriteria_IdQ5" />
                        <telerik:AjaxUpdatedControl ControlID="RadTime_Start_IdQ5" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListFromHourQ5" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListFromMinuteQ5" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListFromSecondQ5" />
                        <telerik:AjaxUpdatedControl ControlID="RadTime_End_IdQ5" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListToHourQ5" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListToMinuteQ5" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListToSecondQ5" />
                        <telerik:AjaxUpdatedControl ControlID="txtError_DescQ5" />
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
                        <telerik:RadTab Text="Băng thông mạng Internet" Font-Names="Arial" Selected="True">
                        </telerik:RadTab>
                        <telerik:RadTab Text="Băng thông kênh riêng" Font-Names="Arial">
                        </telerik:RadTab>
                        <telerik:RadTab Text="Chất lượng cung cấp dịch vụ của telco" Font-Names="Arial">
                        </telerik:RadTab>
                        <telerik:RadTab Text="Độ ổn định mạng Internet" Font-Names="Arial">
                        </telerik:RadTab>
                        <telerik:RadTab Text="Độ ổn định kênh riêng" Font-Names="Arial">
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
                                                    <asp:Label ID="Label94" runat="server" CssClass="label">Ngày:</asp:Label>
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
                                                    <asp:Label ID="Label95" runat="server" CssClass="label">Đường truyền:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="DropDownListCriteria_IdQ1" runat="server" CssClass="droplist" Font-Bold="False" ForeColor="#000099">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label77" runat="server" CssClass="label">Ghi chú:</asp:Label>
                                                </td>
                                                <td align="left" width="35%">
                                                    <asp:TextBox ID="txtDescriptionQ1" runat="server" AutoCompleteType="Disabled" CssClass="txtContent" TextMode="MultiLine" Width="90%"></asp:TextBox>
                                                </td>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label6" runat="server" CssClass="label">Tỷ lệ %:</asp:Label>
                                                </td>
                                                <td align="left">

                                                    <asp:TextBox ID="txtRatio_PercentQ1" runat="server" AutoCompleteType="Disabled" CssClass="txtContent" Width="15%"></asp:TextBox>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="auto-style2"></td>
                                                <td align="left" class="auto-style2"></td>
                                                <td align="right" class="auto-style2">
                                                    <asp:Label ID="Label79" runat="server" CssClass="label" Font-Italic="False">Tổng số:</asp:Label>
                                                </td>
                                                <td align="left" class="auto-style2">

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
                            <asp:Button ID="btnExpQ1" runat="server" CssClass="btnbackground" Text="Báo cáo" />
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
                                        <HeaderStyle HorizontalAlign="Center" Width="2%" />
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
                                            <asp:Label ID="Date_IdQ1" runat="server" CssClass="label"> <%# DateTime.Parse(Eval("Date_Id")).ToString("dd-MM-yyyy")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="ĐƯỜNG  TRUYỀN">
                                        <ItemStyle HorizontalAlign="Left" Width="20%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Criteria_TextQ1" runat="server" CssClass="label"> <%# DataBinder.Eval(Container.DataItem, "Criteria_Text")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="MÔ TẢ LỖI">
                                        <ItemStyle HorizontalAlign="Left" Width="20%" />
                                        <ItemTemplate>
                                            <asp:Label ID="DescriptionQ1" runat="server" CssClass="label"> <%# DataBinder.Eval(Container.DataItem, "Description")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>

                                    <asp:TemplateColumn HeaderText="TỶ LỆ %">
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Ratio_PercentQ1" runat="server" CssClass="label" Font-Bold="true">  <%# UtilsNumeric.FormatDecimal(DataBinder.Eval(Container.DataItem, "Ratio_Percent"), 0)%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="ĐIỂM TRỪ LỖI">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Decrease_Percent_Quantity_TotalQ1" runat="server" CssClass="label" Font-Bold="true">  <%#Eval("Decrease_Percent_Quantity_Total")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="ĐIỂM TRỪ BĂNG THÔNG">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Decrease_Percent_Time_TotalQ1" runat="server" CssClass="label" Font-Bold="true">  <%#Eval("Decrease_Percent_Time_Total")%>
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
                                                    <asp:Label ID="Label1" runat="server" CssClass="label">Ngày:</asp:Label>
                                                </td>
                                                <td align="left" width="35%">
                                                    <telerik:RadDatePicker ID="RadDate_IdQ2" runat="server" AutoPostBack="True" Culture="vi-VN" rMinDate="2006/01/01" Skin="Forest" ZIndex="30001">
                                                        <Calendar Skin="Forest" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                        </Calendar>
                                                        <DateInput AutoPostBack="True" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%">
                                                        </DateInput>
                                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label2" runat="server" CssClass="label">Đường truyền:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="DropDownListCriteria_IdQ2" runat="server" CssClass="droplist" Font-Bold="False" ForeColor="#000099">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label3" runat="server" CssClass="label">Ghi chú:</asp:Label>
                                                </td>
                                                <td align="left" width="35%">
                                                    <asp:TextBox ID="txtDescriptionQ2" runat="server" AutoCompleteType="Disabled" CssClass="txtContent" TextMode="MultiLine" Width="90%"></asp:TextBox>
                                                </td>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label4" runat="server" CssClass="label">Tỷ lệ %:</asp:Label>
                                                </td>
                                                <td align="left">

                                                    <asp:TextBox ID="txtRatio_PercentQ2" runat="server" AutoCompleteType="Disabled" CssClass="txtContent" Width="15%"></asp:TextBox>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="auto-style2"></td>
                                                <td align="left" class="auto-style2"></td>
                                                <td align="right" class="auto-style2">
                                                    <asp:Label ID="Label5" runat="server" CssClass="label" Font-Italic="False">Tổng số:</asp:Label>
                                                </td>
                                                <td align="left" class="auto-style2">

                                                    <asp:Label ID="lblTotalQ2" runat="server" CssClass="lblerror"></asp:Label>

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
                            <asp:Button ID="btnExpQ2" runat="server" CssClass="btnbackground" Text="Báo cáo" />
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
                                        <HeaderStyle HorizontalAlign="Center" Width="2%" />
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
                                            <asp:Label ID="Date_IdQ2" runat="server" CssClass="label"> <%# DateTime.Parse(Eval("Date_Id")).ToString("dd-MM-yyyy")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="ĐƯỜNG  TRUYỀN">
                                        <ItemStyle HorizontalAlign="Left" Width="20%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Criteria_TextQ2" runat="server" CssClass="label"> <%# DataBinder.Eval(Container.DataItem, "Criteria_Text")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="MÔ TẢ LỖI">
                                        <ItemStyle HorizontalAlign="Left" Width="20%" />
                                        <ItemTemplate>
                                            <asp:Label ID="DescriptionQ2" runat="server" CssClass="label"> <%# DataBinder.Eval(Container.DataItem, "Description")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>

                                    <asp:TemplateColumn HeaderText="TỶ LỆ %">
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Ratio_PercentQ2" runat="server" CssClass="label" Font-Bold="true">  <%# UtilsNumeric.FormatDecimal(DataBinder.Eval(Container.DataItem, "Ratio_Percent"), 0)%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="ĐIỂM TRỪ LỖI">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Decrease_Percent_Quantity_TotalQ2" runat="server" CssClass="label" Font-Bold="true">  <%#Eval("Decrease_Percent_Quantity_Total")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="ĐIỂM TRỪ BĂNG THÔNG">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Decrease_Percent_Time_TotalQ2" runat="server" CssClass="label" Font-Bold="true">  <%#Eval("Decrease_Percent_Time_Total")%>
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
                    <telerik:RadPageView runat="server" ID="RadPageViewQ3" CssClass="PageView">
                        <div class="parametter" style="margin: 1px auto 1px auto; border-color: #B4B4B4; width: 80%; background-color: #E1EDD4;">
                            <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                                <tr>
                                    <td align="center">
                                        <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                                            <tr>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="lbltitleQ3" runat="server" CssClass="lblerror" Font-Bold="False">»</asp:Label>
                                                </td>
                                                <td align="left" width="35%">
                                                    <asp:Label ID="lbltitle_Q3" runat="server" CssClass="lblerror" Font-Bold="False"></asp:Label>
                                                </td>
                                                <td align="right" width="15%">&nbsp;</td>
                                                <td align="left">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label7" runat="server" CssClass="label">Ngày:</asp:Label>
                                                </td>
                                                <td align="left" width="35%">
                                                    <telerik:RadDatePicker ID="RadDate_IdQ3" runat="server" AutoPostBack="True" Culture="vi-VN" rMinDate="2006/01/01" Skin="Forest" ZIndex="30001">
                                                        <Calendar Skin="Forest" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                        </Calendar>
                                                        <DateInput AutoPostBack="True" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%">
                                                        </DateInput>
                                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label8" runat="server" CssClass="label">Mạng:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="DropDownListCriteria_IdQ3" runat="server" CssClass="droplist" Font-Bold="False" ForeColor="#000099">
                                                        <asp:ListItem Value="0">--Chọn--</asp:ListItem>
                                                        <asp:ListItem Value="1">Mobifone</asp:ListItem>
                                                        <asp:ListItem Value="2">Vinaphone</asp:ListItem>
                                                        <asp:ListItem Value="3">Viettel</asp:ListItem>
                                                        <asp:ListItem Value="4">Vietnamobile</asp:ListItem>
                                                        <asp:ListItem Value="5">Gmobile</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label9" runat="server" CssClass="label">Thời gian phát hiện lỗi:</asp:Label>
                                                </td>
                                                <td align="left" width="35%">
                                                    <telerik:RadDatePicker ID="RadTime_Start_IdQ3" runat="server" AutoPostBack="True" Culture="vi-VN" rMinDate="2006/01/01" Skin="Forest" ZIndex="30001">
                                                        <Calendar Skin="Forest" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                        </Calendar>
                                                        <DateInput AutoPostBack="True" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%">
                                                        </DateInput>
                                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label10" runat="server" CssClass="label">Thời gian bắt đầu:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <table class="auto-style1">
                                                        <tr>
                                                            <td width="10%">
                                                                <asp:DropDownList ID="DropDownListFromHourQ3" runat="server" CssClass="droplist">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td width="10%">
                                                                <asp:DropDownList ID="DropDownListFromMinuteQ3" runat="server" CssClass="droplist">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListFromSecondQ3" runat="server" CssClass="droplist">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label11" runat="server" CssClass="label">Thời gian khắc phục lỗi:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <telerik:RadDatePicker ID="RadTime_End_IdQ3" runat="server" AutoPostBack="True" Culture="vi-VN" rMinDate="2006/01/01" Skin="Forest" ZIndex="30001">
                                                        <Calendar Skin="Forest" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                        </Calendar>
                                                        <DateInput AutoPostBack="True" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%">
                                                        </DateInput>
                                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="Label12" runat="server" CssClass="label">Thời gian kết thúc:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <table class="auto-style1">
                                                        <tr>
                                                            <td width="10%">
                                                                <asp:DropDownList ID="DropDownListToHourQ3" runat="server" CssClass="droplist">
                                                                </asp:DropDownList>
                                                            </td>

                                                            <td width="10%">
                                                                <asp:DropDownList ID="DropDownListToMinuteQ3" runat="server" CssClass="droplist">
                                                                </asp:DropDownList>
                                                            </td>

                                                            <td>
                                                                <asp:DropDownList ID="DropDownListToSecondQ3" runat="server" CssClass="droplist">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label13" runat="server" CssClass="label">Mô tả lỗi:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtError_DescQ3" runat="server" AutoCompleteType="Disabled" CssClass="txtContent" TextMode="MultiLine" Width="90%"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="Label15" runat="server" CssClass="label" Font-Italic="False">Tổng số:</asp:Label>
                                                </td>
                                                <td align="left">

                                                    <asp:Label ID="lblTotalQ3" runat="server" CssClass="lblerror"></asp:Label>

                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="submmit">
                            <asp:Button ID="btnUpdateQ3" runat="server" CssClass="btnbackground"
                                Text="Ghi lại" />
                            <asp:Button ID="btnExpQ3" runat="server" CssClass="btnbackground" Text="Báo cáo" />
                            <asp:Button ID="btDelQ3" runat="server" CssClass="btnbackground" Text="Xóa" />
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
                                        <HeaderTemplate>
                                            <input id="Check_All" name="Check_All" onclick="CheckAll_Click_Q3(this)" type="checkbox"> </input>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <input id="chkActive" runat="server" name="Add" value='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                                type="checkbox" onclick="Toggle(this)" />
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn>
                                        <HeaderStyle HorizontalAlign="Center" Width="2%" />
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
                                            <asp:Label ID="Date_IdQ3" runat="server" CssClass="label"> <%# DateTime.Parse(Eval("Date_Id")).ToString("dd-MM-yyyy")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="LOẠI LỖI">
                                        <ItemStyle HorizontalAlign="Left" Width="20%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Criteria_TextQ3" runat="server" CssClass="label"> <%# DataBinder.Eval(Container.DataItem, "Criteria_Text")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="MÔ TẢ LỖI">
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Mobile_Operator_TextQ3" runat="server" CssClass="label"> <%# DataBinder.Eval(Container.DataItem, "Error_Desc")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="T/G PHÁT HIỆN">
                                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Time_Start_IdQ3" runat="server" CssClass="label">  <%# DateTime.Parse(Eval("Time_Start_Id")).ToString("dd-MM-yyyy HH:mm:ss")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="T/G KHẮC PHỤC">
                                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Time_End_IdQ3" runat="server" CssClass="label"> <%# DateTime.Parse(Eval("Time_End_Id")).ToString("dd-MM-yyyy HH:mm:ss")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="TỔNG T/G LỖI (Phút)">
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Total_MinQ3" runat="server" CssClass="label" Font-Bold="true">  <%# UtilsNumeric.FormatDecimal(DataBinder.Eval(Container.DataItem, "Total_Min"),0)%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>

                                    <asp:TemplateColumn HeaderText="ĐIỂM TRỪ T/G">
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Decrease_Percent_Time_TotalQ3" runat="server" CssClass="label" Font-Bold="true">  <%#Eval("Decrease_Percent_Time_Total")%>
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
                                            <asp:ImageButton ID="EditerQ3" runat="server" BorderStyle="None" CausesValidation="False" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID")%>' ImageAlign="absmiddle" ImageUrl="~/Images/comment-edit-icon.png" OnCommand="EditQ3" title="Edit" />
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn>
                                        <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            XÓA
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="DeleterQ3" runat="server" BorderStyle="None" CausesValidation="False" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID")%>' ImageAlign="absmiddle" ImageUrl="~/Images/del.gif" OnCommand="DelQ3" title="Delete" />
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                </Columns>
                                <PagerStyle HorizontalAlign="Right" NextPageText="" PageButtonCount="5" PrevPageText="" Visible="False" />
                            </asp:DataGrid>
                        </div>
                    </telerik:RadPageView>
                    <telerik:RadPageView runat="server" ID="RadPageViewQ4" CssClass="PageView">
                        <div class="parametter" style="margin: 1px auto 1px auto; border-color: #B4B4B4; width: 80%; background-color: #E1EDD4;">
                            <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                                <tr>
                                    <td align="center">
                                        <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                                            <tr>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="lbltitleQ4" runat="server" CssClass="lblerror" Font-Bold="False">»</asp:Label>
                                                </td>
                                                <td align="left" width="35%">
                                                    <asp:Label ID="lbltitle_Q4" runat="server" CssClass="lblerror" Font-Bold="False"></asp:Label>
                                                </td>
                                                <td align="right" width="15%">&nbsp;</td>
                                                <td align="left">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label14" runat="server" CssClass="label">Ngày:</asp:Label>
                                                </td>
                                                <td align="left" width="35%">
                                                    <telerik:RadDatePicker ID="RadDate_IdQ4" runat="server" AutoPostBack="True" Culture="vi-VN" rMinDate="2006/01/01" Skin="Forest" ZIndex="30001">
                                                        <Calendar Skin="Forest" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                        </Calendar>
                                                        <DateInput AutoPostBack="True" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%">
                                                        </DateInput>
                                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label16" runat="server" CssClass="label">Mạng:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="DropDownListCriteria_IdQ4" runat="server" CssClass="droplist" Font-Bold="False" ForeColor="#000099">
                                                        <asp:ListItem Value="0">--Chọn--</asp:ListItem>
                                                        <asp:ListItem Value="1">Mobifone</asp:ListItem>
                                                        <asp:ListItem Value="2">Vinaphone</asp:ListItem>
                                                        <asp:ListItem Value="3">Viettel</asp:ListItem>
                                                        <asp:ListItem Value="4">Vietnamobile</asp:ListItem>
                                                        <asp:ListItem Value="5">Gmobile</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label17" runat="server" CssClass="label">Thời gian phát hiện lỗi:</asp:Label>
                                                </td>
                                                <td align="left" width="35%">
                                                    <telerik:RadDatePicker ID="RadTime_Start_IdQ4" runat="server" AutoPostBack="True" Culture="vi-VN" rMinDate="2006/01/01" Skin="Forest" ZIndex="30001">
                                                        <Calendar Skin="Forest" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                        </Calendar>
                                                        <DateInput AutoPostBack="True" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%">
                                                        </DateInput>
                                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label18" runat="server" CssClass="label">Thời gian bắt đầu:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <table class="auto-style1">
                                                        <tr>
                                                            <td width="10%">
                                                                <asp:DropDownList ID="DropDownListFromHourQ4" runat="server" CssClass="droplist">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td width="10%">
                                                                <asp:DropDownList ID="DropDownListFromMinuteQ4" runat="server" CssClass="droplist">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListFromSecondQ4" runat="server" CssClass="droplist">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label19" runat="server" CssClass="label">Thời gian khắc phục lỗi:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <telerik:RadDatePicker ID="RadTime_End_IdQ4" runat="server" AutoPostBack="True" Culture="vi-VN" rMinDate="2006/01/01" Skin="Forest" ZIndex="30001">
                                                        <Calendar Skin="Forest" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                        </Calendar>
                                                        <DateInput AutoPostBack="True" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%">
                                                        </DateInput>
                                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="Label20" runat="server" CssClass="label">Thời gian kết thúc:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <table class="auto-style1">
                                                        <tr>
                                                            <td width="10%">
                                                                <asp:DropDownList ID="DropDownListToHourQ4" runat="server" CssClass="droplist">
                                                                </asp:DropDownList>
                                                            </td>

                                                            <td width="10%">
                                                                <asp:DropDownList ID="DropDownListToMinuteQ4" runat="server" CssClass="droplist">
                                                                </asp:DropDownList>
                                                            </td>

                                                            <td>
                                                                <asp:DropDownList ID="DropDownListToSecondQ4" runat="server" CssClass="droplist">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label21" runat="server" CssClass="label">Mô tả lỗi:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtError_DescQ4" runat="server" AutoCompleteType="Disabled" CssClass="txtContent" TextMode="MultiLine" Width="90%"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="Label22" runat="server" CssClass="label" Font-Italic="False">Tổng số:</asp:Label>
                                                </td>
                                                <td align="left">

                                                    <asp:Label ID="lblTotalQ4" runat="server" CssClass="lblerror"></asp:Label>

                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="submmit">
                            <asp:Button ID="btnUpdateQ4" runat="server" CssClass="btnbackground"
                                Text="Ghi lại" />
                            <asp:Button ID="btnExpQ4" runat="server" CssClass="btnbackground" Text="Báo cáo" />
                            <asp:Button ID="btDelQ4" runat="server" CssClass="btnbackground" Text="Xóa" />
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
                                        <HeaderTemplate>
                                            <input id="Check_All" name="Check_All" onclick="CheckAll_Click_Q4(this)" type="checkbox"> </input>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <input id="chkActive" runat="server" name="Add" value='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                                type="checkbox" onclick="Toggle(this)" />
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn>
                                        <HeaderStyle HorizontalAlign="Center" Width="2%" />
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
                                            <asp:Label ID="Date_IdQ4" runat="server" CssClass="label"> <%# DateTime.Parse(Eval("Date_Id")).ToString("dd-MM-yyyy")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="LOẠI LỖI">
                                        <ItemStyle HorizontalAlign="Left" Width="20%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Criteria_TextQ4" runat="server" CssClass="label"> <%# DataBinder.Eval(Container.DataItem, "Criteria_Text")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="MÔ TẢ LỖI">
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Mobile_Operator_TextQ4" runat="server" CssClass="label"> <%# DataBinder.Eval(Container.DataItem, "Error_Desc")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="T/G PHÁT HIỆN">
                                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Time_Start_IdQ4" runat="server" CssClass="label">  <%# DateTime.Parse(Eval("Time_Start_Id")).ToString("dd-MM-yyyy HH:mm:ss")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="T/G KHẮC PHỤC">
                                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Time_End_IdQ4" runat="server" CssClass="label"> <%# DateTime.Parse(Eval("Time_End_Id")).ToString("dd-MM-yyyy HH:mm:ss")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="TỔNG T/G LỖI (Phút)">
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Total_MinQ4" runat="server" CssClass="label" Font-Bold="true">  <%# UtilsNumeric.FormatDecimal(DataBinder.Eval(Container.DataItem, "Total_Min"),0)%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>

                                    <asp:TemplateColumn HeaderText="ĐIỂM TRỪ T/G">
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Decrease_Percent_Time_TotalQ4" runat="server" CssClass="label" Font-Bold="true">  <%#Eval("Decrease_Percent_Time_Total")%>
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
                                            <asp:ImageButton ID="EditerQ4" runat="server" BorderStyle="None" CausesValidation="False" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID")%>' ImageAlign="absmiddle" ImageUrl="~/Images/comment-edit-icon.png" OnCommand="EditQ4" title="Edit" />
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn>
                                        <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            XÓA
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="DeleterQ4" runat="server" BorderStyle="None" CausesValidation="False" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID")%>' ImageAlign="absmiddle" ImageUrl="~/Images/del.gif" OnCommand="DelQ4" title="Delete" />
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                </Columns>
                                <PagerStyle HorizontalAlign="Right" NextPageText="" PageButtonCount="5" PrevPageText="" Visible="False" />
                            </asp:DataGrid>
                        </div>
                    </telerik:RadPageView>
                    <telerik:RadPageView runat="server" ID="RadPageViewQ5" CssClass="PageView">
                        <div class="parametter" style="margin: 1px auto 1px auto; border-color: #B4B4B4; width: 80%; background-color: #E1EDD4;">
                            <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                                <tr>
                                    <td align="center">
                                        <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                                            <tr>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="lbltitleQ5" runat="server" CssClass="lblerror" Font-Bold="False">»</asp:Label>
                                                </td>
                                                <td align="left" width="35%">
                                                    <asp:Label ID="lbltitle_Q5" runat="server" CssClass="lblerror" Font-Bold="False"></asp:Label>
                                                </td>
                                                <td align="right" width="15%">&nbsp;</td>
                                                <td align="left">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label23" runat="server" CssClass="label">Ngày:</asp:Label>
                                                </td>
                                                <td align="left" width="35%">
                                                    <telerik:RadDatePicker ID="RadDate_IdQ5" runat="server" AutoPostBack="True" Culture="vi-VN" rMinDate="2006/01/01" Skin="Forest" ZIndex="30001">
                                                        <Calendar Skin="Forest" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                        </Calendar>
                                                        <DateInput AutoPostBack="True" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%">
                                                        </DateInput>
                                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label24" runat="server" CssClass="label">Mạng:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="DropDownListCriteria_IdQ5" runat="server" CssClass="droplist" Font-Bold="False" ForeColor="#000099">
                                                        <asp:ListItem Value="0">--Chọn--</asp:ListItem>
                                                        <asp:ListItem Value="1">Mobifone</asp:ListItem>
                                                        <asp:ListItem Value="2">Vinaphone</asp:ListItem>
                                                        <asp:ListItem Value="3">Viettel</asp:ListItem>
                                                        <asp:ListItem Value="4">Vietnamobile</asp:ListItem>
                                                        <asp:ListItem Value="5">Gmobile</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label25" runat="server" CssClass="label">Thời gian phát hiện lỗi:</asp:Label>
                                                </td>
                                                <td align="left" width="35%">
                                                    <telerik:RadDatePicker ID="RadTime_Start_IdQ5" runat="server" AutoPostBack="True" Culture="vi-VN" rMinDate="2006/01/01" Skin="Forest" ZIndex="30001">
                                                        <Calendar Skin="Forest" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                        </Calendar>
                                                        <DateInput AutoPostBack="True" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%">
                                                        </DateInput>
                                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label26" runat="server" CssClass="label">Thời gian bắt đầu:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <table class="auto-style1">
                                                        <tr>
                                                            <td width="10%">
                                                                <asp:DropDownList ID="DropDownListFromHourQ5" runat="server" CssClass="droplist">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td width="10%">
                                                                <asp:DropDownList ID="DropDownListFromMinuteQ5" runat="server" CssClass="droplist">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListFromSecondQ5" runat="server" CssClass="droplist">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label27" runat="server" CssClass="label">Thời gian khắc phục lỗi:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <telerik:RadDatePicker ID="RadTime_End_IdQ5" runat="server" AutoPostBack="True" Culture="vi-VN" rMinDate="2006/01/01" Skin="Forest" ZIndex="30001">
                                                        <Calendar Skin="Forest" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                        </Calendar>
                                                        <DateInput AutoPostBack="True" DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%">
                                                        </DateInput>
                                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="Label28" runat="server" CssClass="label">Thời gian kết thúc:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <table class="auto-style1">
                                                        <tr>
                                                            <td width="10%">
                                                                <asp:DropDownList ID="DropDownListToHourQ5" runat="server" CssClass="droplist">
                                                                </asp:DropDownList>
                                                            </td>

                                                            <td width="10%">
                                                                <asp:DropDownList ID="DropDownListToMinuteQ5" runat="server" CssClass="droplist">
                                                                </asp:DropDownList>
                                                            </td>

                                                            <td>
                                                                <asp:DropDownList ID="DropDownListToSecondQ5" runat="server" CssClass="droplist">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label29" runat="server" CssClass="label">Mô tả lỗi:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtError_DescQ5" runat="server" AutoCompleteType="Disabled" CssClass="txtContent" TextMode="MultiLine" Width="90%"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="Label30" runat="server" CssClass="label" Font-Italic="False">Tổng số:</asp:Label>
                                                </td>
                                                <td align="left">

                                                    <asp:Label ID="lblTotalQ5" runat="server" CssClass="lblerror"></asp:Label>

                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="submmit">
                            <asp:Button ID="btnUpdateQ5" runat="server" CssClass="btnbackground"
                                Text="Ghi lại" />
                            <asp:Button ID="btnExpQ5" runat="server" CssClass="btnbackground" Text="Báo cáo" />
                            <asp:Button ID="btDelQ5" runat="server" CssClass="btnbackground" Text="Xóa" />
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
                                        <HeaderTemplate>
                                            <input id="Check_All" name="Check_All" onclick="CheckAll_Click_Q5(this)" type="checkbox"> </input>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <input id="chkActive" runat="server" name="Add" value='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                                type="checkbox" onclick="Toggle(this)" />
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn>
                                        <HeaderStyle HorizontalAlign="Center" Width="2%" />
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
                                            <asp:Label ID="Date_IdQ5" runat="server" CssClass="label"> <%# DateTime.Parse(Eval("Date_Id")).ToString("dd-MM-yyyy")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="LOẠI LỖI">
                                        <ItemStyle HorizontalAlign="Left" Width="20%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Criteria_TextQ5" runat="server" CssClass="label"> <%# DataBinder.Eval(Container.DataItem, "Criteria_Text")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="MÔ TẢ LỖI">
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Mobile_Operator_TextQ5" runat="server" CssClass="label"> <%# DataBinder.Eval(Container.DataItem, "Error_Desc")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="T/G PHÁT HIỆN">
                                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Time_Start_IdQ5" runat="server" CssClass="label">  <%# DateTime.Parse(Eval("Time_Start_Id")).ToString("dd-MM-yyyy HH:mm:ss")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="T/G KHẮC PHỤC">
                                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Time_End_IdQ5" runat="server" CssClass="label"> <%# DateTime.Parse(Eval("Time_End_Id")).ToString("dd-MM-yyyy HH:mm:ss")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="TỔNG T/G LỖI (Phút)">
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Total_MinQ5" runat="server" CssClass="label" Font-Bold="true">  <%# UtilsNumeric.FormatDecimal(DataBinder.Eval(Container.DataItem, "Total_Min"),0)%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>

                                    <asp:TemplateColumn HeaderText="ĐIỂM TRỪ T/G">
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Decrease_Percent_Time_TotalQ5" runat="server" CssClass="label" Font-Bold="true">  <%#Eval("Decrease_Percent_Time_Total")%>
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
                                            <asp:ImageButton ID="EditerQ5" runat="server" BorderStyle="None" CausesValidation="False" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID")%>' ImageAlign="absmiddle" ImageUrl="~/Images/comment-edit-icon.png" OnCommand="EditQ5" title="Edit" />
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn>
                                        <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            XÓA
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="DeleterQ5" runat="server" BorderStyle="None" CausesValidation="False" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID")%>' ImageAlign="absmiddle" ImageUrl="~/Images/del.gif" OnCommand="DelQ5" title="Delete" />
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
    <script type="text/javascript">
        var DataGridQ3 = document.getElementById('DataGridQ3');
        function CheckAll_Click_Q3(e) {
            if (e.checked) {
                Check_All_Q3();
            }
            else {
                Clear_All_Q3();
            }
        }
        function Check_All_Q3() {
            var chkList = DataGridQ3.getElementsByTagName('input');
            for (var i = 0; i < chkList.length; i++) {
                chkList[i].checked = true;
            }
        }
        function Clear_All_Q3() {
            var chkList = DataGridQ3.getElementsByTagName('input');
            for (var i = 0; i < chkList.length; i++) {
                chkList[i].checked = false;
            }
        }
    </script>
    <script type="text/javascript">
        var DataGridQ4 = document.getElementById('DataGridQ4');
        function CheckAll_Click_Q4(e) {
            if (e.checked) {
                Check_All_Q4();
            }
            else {
                Clear_All_Q4();
            }
        }
        function Check_All_Q4() {
            var chkList = DataGridQ4.getElementsByTagName('input');
            for (var i = 0; i < chkList.length; i++) {
                chkList[i].checked = true;
            }
        }
        function Clear_All_Q4() {
            var chkList = DataGridQ4.getElementsByTagName('input');
            for (var i = 0; i < chkList.length; i++) {
                chkList[i].checked = false;
            }
        }
    </script>
    <script type="text/javascript">
        var DataGridQ5 = document.getElementById('DataGridQ5');
        function CheckAll_Click_Q5(e) {
            if (e.checked) {
                Check_All_Q5();
            }
            else {
                Clear_All_Q5();
            }
        }
        function Check_All_Q5() {
            var chkList = DataGridQ5.getElementsByTagName('input');
            for (var i = 0; i < chkList.length; i++) {
                chkList[i].checked = true;
            }
        }
        function Clear_All_Q5() {
            var chkList = DataGridQ5.getElementsByTagName('input');
            for (var i = 0; i < chkList.length; i++) {
                chkList[i].checked = false;
            }
        }
    </script>
</body>
</html>
