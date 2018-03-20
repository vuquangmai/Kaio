<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="KpiBrInputData.aspx.vb" Inherits="Prjs.Portal.Report.KpiBrInputData" %>
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
                        <telerik:AjaxUpdatedControl ControlID="txtProgram_CodeQ1" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListMobile_OperatorQ1" />
                        <telerik:AjaxUpdatedControl ControlID="RadTime_StartQ1" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListFromHourQ1" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListFromMinuteQ1" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListFromSecondQ1" />
                        <telerik:AjaxUpdatedControl ControlID="RadTime_EndQ1" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListToHourQ1" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListToMinuteQ1" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListToSecondQ1" />
                        <telerik:AjaxUpdatedControl ControlID="txtFileUploadQ1" />
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
                        <telerik:AjaxUpdatedControl ControlID="txtProgram_CodeQ2" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListMobile_OperatorQ2" />
                        <telerik:AjaxUpdatedControl ControlID="RadTime_StartQ2" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListFromHourQ2" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListFromMinuteQ2" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListFromSecondQ2" />
                        <telerik:AjaxUpdatedControl ControlID="RadTime_EndQ2" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListToHourQ2" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListToMinuteQ2" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListToSecondQ2" />
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
                        <telerik:AjaxUpdatedControl ControlID="txtProgram_CodeQ3" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListErrorCodeQ3" />
                        <telerik:AjaxUpdatedControl ControlID="RadTime_StartQ3" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListFromHourQ3" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListFromMinuteQ3" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListFromSecondQ3" />
                        <telerik:AjaxUpdatedControl ControlID="RadTime_EndQ3" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListToHourQ3" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListToMinuteQ3" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListToSecondQ3" />
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
                        <telerik:AjaxUpdatedControl ControlID="txtProgram_CodeQ4" />
                        <telerik:AjaxUpdatedControl ControlID="txtTotal_MT_Q4" />
                        <telerik:AjaxUpdatedControl ControlID="txtTotal_MT_Error_Q4" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <div id="HQ">
            <div class="alert">
                <asp:Label ID="lbltitle" runat="server" CssClass="lbltitle"></asp:Label><br />
                <asp:Label ID="lblerror" runat="server" CssClass="lblerror"></asp:Label>
                <telerik:RadTabStrip runat="server" ID="RadTabStrip1" MultiPageID="RadMultiPage1" Skin="Forest" Font-Bold="False" Font-Names="Arial" SelectedIndex="0" >
                    <Tabs>
                        <telerik:RadTab Text="Thời gian up nội dung QC" Font-Names="Arial" Selected="True">
                        </telerik:RadTab>
                        <telerik:RadTab Text="Thời gian duyệt brand CSKH" Font-Names="Arial">
                        </telerik:RadTab>
                        <telerik:RadTab Text="Lỗi nhập liệu" Font-Names="Arial">
                        </telerik:RadTab>
                        <telerik:RadTab Text="MT lỗi không tính phí" Font-Names="Arial">
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
                                                <td align="right" width="15%">
                                                    &nbsp;</td>
                                                <td align="left">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label6" runat="server" CssClass="label">Ngày:</asp:Label>
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
                                                    &nbsp;</td>
                                                <td align="left">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label84" runat="server" CssClass="label">Chương trình:</asp:Label>
                                                </td>
                                                <td align="left" width="35%">
                                                    <asp:TextBox ID="txtProgram_CodeQ1" runat="server" AutoCompleteType="Disabled" CssClass="txtContent" Width="80%"></asp:TextBox>
                                                </td>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label1" runat="server" CssClass="label">Mạng:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="DropDownListMobile_OperatorQ1" runat="server" CssClass="droplist" Font-Bold="False">
                                                        <asp:ListItem Value="0">--Chọn--</asp:ListItem>
                                                        <asp:ListItem Value="1">Mobi</asp:ListItem>
                                                        <asp:ListItem Value="2">Viettel</asp:ListItem>
                                                        <asp:ListItem Value="3">Vina</asp:ListItem>
                                                        <asp:ListItem Value="4">VNM, Gtel</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label85" runat="server" CssClass="label">Thời gian bắt đầu:</asp:Label>
                                                </td>
                                                <td align="left" width="35%">
                                                    <telerik:RadDatePicker ID="RadTime_StartQ1" runat="server" Culture="vi-VN" rMinDate="2006/01/01" Skin="Forest" ZIndex="30001">
                                                        <Calendar Skin="Forest" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                        </Calendar>
                                                        <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%">
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
                                                    <asp:Label ID="Label86" runat="server" CssClass="label">Thời gian kết thúc:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <telerik:RadDatePicker ID="RadTime_EndQ1" runat="server" Culture="vi-VN" rMinDate="2006/01/01" Skin="Forest" ZIndex="30001">
                                                        <Calendar Skin="Forest" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                        </Calendar>
                                                        <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%">
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
                                                    <asp:Label ID="Label87" runat="server" CssClass="label">File excel:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <cc2:FilePicker ID="txtFileUploadQ1" runat="server" CssClass="txtContent" fpAllowedUploadFileExts="" fpPopupURL="../../FilePicker/FilePicker.aspx" fpPopupWidth="600" Width="90%"></cc2:FilePicker>
                                                </td>
                                                <td align="right">&nbsp;</td>
                                                <td align="left">
                                                    <asp:Label ID="Label79" runat="server" CssClass="label" Font-Italic="True">(Giờ : Phút : Giây)</asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label88" runat="server" CssClass="label">Sheet:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtSheetQ1" runat="server" AutoCompleteType="Disabled" CssClass="txtContent" Width="50%"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="Label90" runat="server" CssClass="label">Tổng số:</asp:Label>
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
                            <asp:Button ID="btnImportQ1" runat="server" CssClass="btnbackground"
                                Text="Import" />
                            <asp:Button ID="btnExpQ1" runat="server" CssClass="btnbackground" Text="Báo cáo" />
                            <asp:Button ID="btnDelQ1" runat="server" CssClass="btnbackground" Text="Xóa" />
                        </div>
                        <div class="pager">
                <cc1:PagerV2_8 ID="PagerQ1" runat="server"   GenerateGoToSection="true"
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
                                        <HeaderStyle HorizontalAlign="Center" Width="5%" />
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
                                          <asp:Label ID="Date_IdQ1" runat="server" CssClass="label"  > <%# DateTime.Parse(Eval("Date_Id")).ToString("dd-MM-yyyy")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="CHƯƠNG TRÌNH">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                             <asp:Label ID="Program_CodeQ1" runat="server" CssClass="label" > <%# DataBinder.Eval(Container.DataItem, "Program_Code")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="MẠNG">
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                        <ItemTemplate>
                                             <asp:Label ID="Mobile_Operator_TextQ1" runat="server" CssClass="label" > <%# DataBinder.Eval(Container.DataItem, "Mobile_Operator_Text")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                      <asp:TemplateColumn HeaderText="THỜI GIAN BẮT ĐẦU">
                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Time_Start_IdQ1" runat="server" CssClass="label"  > <%# DateTime.Parse(Eval("Time_Start_Id")).ToString("dd-MM-yyyy HH:mm:ss")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                      <asp:TemplateColumn HeaderText="THỜI GIAN KẾT THÚC">
                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Time_End_IdQ1" runat="server" CssClass="label"     >  <%# DateTime.Parse(Eval("Time_End_Id")).ToString("dd-MM-yyyy HH:mm:ss")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                      <asp:TemplateColumn HeaderText="TỔNG THỜI GIAN">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:Label ID="TotalTime" runat="server" CssClass="label"    Font-Bold="true" >  <%# ConvertTimeSS(Eval("Total_Sec"))%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                     <asp:TemplateColumn HeaderText="ĐIỂM TRỪ">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Decrease_Percent_TotalQ1" runat="server" CssClass="label"    Font-Bold="true" >  <%#Eval("Decrease_Percent_Total")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                       <asp:TemplateColumn HeaderText="KHỞI TẠO">
                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Create_TimeQ1" runat="server" CssClass="label"     >  <%# DateTime.Parse(Eval("Create_Time")).ToString("dd-MM-yyyy HH:mm:ss")%>
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
                                                <td align="right" width="15%">
                                                    &nbsp;</td>
                                                <td align="left">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label2" runat="server" CssClass="label">Ngày:</asp:Label>
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
                                                    &nbsp;</td>
                                                <td align="left">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label4" runat="server" CssClass="label">Chương trình:</asp:Label>
                                                </td>
                                                <td align="left" width="35%">
                                                    <asp:TextBox ID="txtProgram_CodeQ2" runat="server" AutoCompleteType="Disabled" CssClass="txtContent" Width="80%"></asp:TextBox>
                                                </td>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label5" runat="server" CssClass="label">Mạng:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="DropDownListMobile_OperatorQ2" runat="server" CssClass="droplist" Font-Bold="False">
                                                        <asp:ListItem Value="0">--Chọn--</asp:ListItem>
                                                        <asp:ListItem Value="1">Mobi</asp:ListItem>
                                                        <asp:ListItem Value="2">Vina</asp:ListItem>
                                                        <asp:ListItem Value="3">Viettel</asp:ListItem>
                                                        <asp:ListItem Value="4">VNM, Gtel</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label7" runat="server" CssClass="label">Thời gian bắt đầu:</asp:Label>
                                                </td>
                                                <td align="left" width="35%">
                                                    <telerik:RadDatePicker ID="RadTime_StartQ2" runat="server" Culture="vi-VN" rMinDate="2006/01/01" Skin="Forest" ZIndex="30001">
                                                        <Calendar Skin="Forest" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                        </Calendar>
                                                        <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%">
                                                        </DateInput>
                                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label8" runat="server" CssClass="label">Lúc:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <table class="auto-style1">
                                                        <tr>
                                                            <td width="10%">
                                                                <asp:DropDownList ID="DropDownListFromHourQ2" runat="server" CssClass="droplist">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td width="10%">
                                                                <asp:DropDownList ID="DropDownListFromMinuteQ2" runat="server" CssClass="droplist">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListFromSecondQ2" runat="server" CssClass="droplist">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label9" runat="server" CssClass="label">Thời gian kết thúc:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <telerik:RadDatePicker ID="RadTime_EndQ2" runat="server" Culture="vi-VN" rMinDate="2006/01/01" Skin="Forest" ZIndex="30001">
                                                        <Calendar Skin="Forest" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                        </Calendar>
                                                        <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%">
                                                        </DateInput>
                                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="Label10" runat="server" CssClass="label">Lúc:</asp:Label>
                                                </td>
                                                <td align="left">
                                                   
                                                    <table class="auto-style1">
                                                        <tr>
                                                            <td width="10%">
                                                                <asp:DropDownList ID="DropDownListToHourQ2" runat="server" CssClass="droplist">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td width="10%">
                                                                <asp:DropDownList ID="DropDownListToMinuteQ2" runat="server" CssClass="droplist">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="DropDownListToSecondQ2" runat="server" CssClass="droplist">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                   
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label20" runat="server" CssClass="label">File excel:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <cc2:FilePicker ID="txtFileUploadQ2" runat="server" CssClass="txtContent" fpAllowedUploadFileExts="" fpPopupURL="../../FilePicker/FilePicker.aspx" fpPopupWidth="600" Width="90%"></cc2:FilePicker>
                                                </td>
                                                <td align="right">&nbsp;</td>
                                                <td align="left">
                                                    <asp:Label ID="Label22" runat="server" CssClass="label" Font-Italic="True">(Giờ : Phút : Giây)</asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="Label89" runat="server" CssClass="label">Sheet:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtSheetQ2" runat="server" AutoCompleteType="Disabled" CssClass="txtContent" Width="50%"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="Label91" runat="server" CssClass="label">Tổng số:</asp:Label>
                                                </td>
                                                <td align="left">
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
                            <asp:Button ID="btnImportQ2" runat="server" CssClass="btnbackground"
                                Text="Import" />
                            <asp:Button ID="btnExpQ2" runat="server" CssClass="btnbackground" Text="Báo cáo" />
                            <asp:Button ID="btnDelQ2" runat="server" CssClass="btnbackground" Text="Xóa" />
                        </div>
                        <div class="pager">
                <cc1:PagerV2_8 ID="PagerQ2" runat="server"   GenerateGoToSection="true"
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
                                        <HeaderStyle HorizontalAlign="Center" Width="5%" />
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
                                          <asp:Label ID="Date_IdQ2" runat="server" CssClass="label"  > <%# DateTime.Parse(Eval("Date_Id")).ToString("dd-MM-yyyy")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="CHƯƠNG TRÌNH">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                             <asp:Label ID="Program_CodeQ2" runat="server" CssClass="label" > <%# DataBinder.Eval(Container.DataItem, "Program_Code")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="MẠNG">
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                        <ItemTemplate>
                                             <asp:Label ID="Mobile_Operator_TextQ2" runat="server" CssClass="label" > <%# DataBinder.Eval(Container.DataItem, "Mobile_Operator_Text")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                      <asp:TemplateColumn HeaderText="THỜI GIAN BẮT ĐẦU">
                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Time_Start_IdQ2" runat="server" CssClass="label"  > <%# DateTime.Parse(Eval("Time_Start_Id")).ToString("dd-MM-yyyy HH:mm:ss")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                      <asp:TemplateColumn HeaderText="THỜI GIAN KẾT THÚC">
                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Time_End_IdQ2" runat="server" CssClass="label"     >  <%# DateTime.Parse(Eval("Time_End_Id")).ToString("dd-MM-yyyy HH:mm:ss")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                      <asp:TemplateColumn HeaderText="TỔNG THỜI GIAN">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:Label ID="TotalTime" runat="server" CssClass="label"    Font-Bold="true" >  <%# ConvertTimeSS2HH(Eval("Total_Sec"))%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                     <asp:TemplateColumn HeaderText="ĐIỂM TRỪ">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Decrease_Percent_TotalQ2" runat="server" CssClass="label"    Font-Bold="true" >  <%#Eval("Decrease_Percent_Total")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                       <asp:TemplateColumn HeaderText="KHỞI TẠO">
                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Create_TimeQ2" runat="server" CssClass="label"     >  <%# DateTime.Parse(Eval("Create_Time")).ToString("dd-MM-yyyy HH:mm:ss")%>
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
                                                <td align="right" width="15%">
                                                    &nbsp;</td>
                                                <td align="left">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label3" runat="server" CssClass="label">Ngày:</asp:Label>
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
                                                    &nbsp;</td>
                                                <td align="left">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label11" runat="server" CssClass="label">Chương trình:</asp:Label>
                                                </td>
                                                <td align="left" width="35%">
                                                    <asp:TextBox ID="txtProgram_CodeQ3" runat="server" AutoCompleteType="Disabled" CssClass="txtContent" Width="80%"></asp:TextBox>
                                                </td>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label12" runat="server" CssClass="label">Loại lỗi:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:DropDownList ID="DropDownListErrorCodeQ3" runat="server" CssClass="droplist" Font-Bold="False">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label13" runat="server" CssClass="label">Thời gian phát hiện lỗi:</asp:Label>
                                                </td>
                                                <td align="left" width="35%">
                                                    <telerik:RadDatePicker ID="RadTime_StartQ3" runat="server" Culture="vi-VN" rMinDate="2006/01/01" Skin="Forest" ZIndex="30001">
                                                        <Calendar Skin="Forest" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                        </Calendar>
                                                        <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%">
                                                        </DateInput>
                                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label14" runat="server" CssClass="label">Lúc:</asp:Label>
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
                                                    <asp:Label ID="Label15" runat="server" CssClass="label">Thời gian khắc phục lỗi:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <telerik:RadDatePicker ID="RadTime_EndQ3" runat="server" Culture="vi-VN" rMinDate="2006/01/01" Skin="Forest" ZIndex="30001">
                                                        <Calendar Skin="Forest" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                        </Calendar>
                                                        <DateInput DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" LabelWidth="40%">
                                                        </DateInput>
                                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="Label16" runat="server" CssClass="label">Lúc:</asp:Label>
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
                                                    <asp:Label ID="Label92" runat="server" CssClass="label">Tổng số:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:Label ID="lblTotalQ3" runat="server" CssClass="lblerror"></asp:Label>
                                                </td>
                                                <td align="right">&nbsp;</td>
                                                <td align="left">
                                                    <asp:Label ID="Label26" runat="server" CssClass="label" Font-Italic="True">(Giờ : Phút : Giây)</asp:Label>
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
                            <asp:Button ID="btnExxpQ3" runat="server" CssClass="btnbackground" Text="Báo cáo" />
                            <asp:Button ID="btnDelQ3" runat="server" CssClass="btnbackground" Text="Xóa" />
                        </div>
                        <div class="pager">
                <cc1:PagerV2_8 ID="PagerQ3" runat="server"   GenerateGoToSection="true"
                    Font-Size="10pt" PageSize="10" />

            </div>
                        <div class="datagrid">
                            <asp:DataGrid ID="DataGridQ3" runat="server" AllowPaging="True" AutoGenerateColumns="false" CellPadding="0" CssClass="datagrid" EnableViewState="False" GridLines="None" PagerStyle-Mode="NextPrev" PagerStyle-Visible="true" Width="100%">
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
                                        <ItemStyle HorizontalAlign="Center" Width="7%" />
                                        <ItemTemplate>
                                          <asp:Label ID="Date_IdQ3" runat="server" CssClass="label"  > <%# DateTime.Parse(Eval("Date_Id")).ToString("dd-MM-yyyy")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="LOẠI LỖI">
                                        <ItemStyle HorizontalAlign="Left" Width="15%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Error_TextQ3" runat="server" CssClass="label"  > <%# DataBinder.Eval(Container.DataItem, "Error_Text")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                   <asp:TemplateColumn HeaderText="CHƯƠNG TRÌNH">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                             <asp:Label ID="Program_CodeQ3" runat="server" CssClass="label" > <%# DataBinder.Eval(Container.DataItem, "Program_Code")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                      <asp:TemplateColumn HeaderText="T/G BẮT ĐẦU">
                                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Time_Start_IdQ3" runat="server" CssClass="label"  > <%# DateTime.Parse(Eval("Time_Start_Id")).ToString("dd-MM-yyyy HH:mm:ss")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                      <asp:TemplateColumn HeaderText="T/G KẾT THÚC">
                                        <ItemStyle HorizontalAlign="Center" Width="12%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Time_End_IdQ3" runat="server" CssClass="label"     >  <%# DateTime.Parse(Eval("Time_End_Id")).ToString("dd-MM-yyyy HH:mm:ss")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                      <asp:TemplateColumn HeaderText="TỔNG T/G">
                                        <ItemStyle HorizontalAlign="Center" Width="6%" />
                                        <ItemTemplate>
                                            <asp:Label ID="TotalTime" runat="server" CssClass="label"    Font-Bold="true" >  <%# ConvertTimeSS(Eval("Total_Sec"))%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                         <asp:TemplateColumn HeaderText="TRỪ LỖI">
                                        <ItemStyle HorizontalAlign="Center" Width="6%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Decrease_Percent_ErrorQ3" runat="server" CssClass="label"   ForeColor="Blue">  <%# Eval("Decrease_Percent_Error")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                      <asp:TemplateColumn HeaderText="TRỪ T/G">
                                        <ItemStyle HorizontalAlign="Center" Width="6%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Decrease_Percent_Total_TimeQ3" runat="server" CssClass="label"  ForeColor="Red"> <%# DataBinder.Eval(Container.DataItem, "Decrease_Percent_Total_Time")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="TRỪ TỔNG">
                                        <ItemStyle HorizontalAlign="Center" Width="6%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Decrease_Percent_TotalQ3" runat="server" CssClass="label" Font-Bold="true" >  <%# Eval("Decrease_Percent_Total")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                       <asp:TemplateColumn HeaderText="KHỞI TẠO">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Create_TimeQ3" runat="server" CssClass="label"     >  <%# DateTime.Parse(Eval("Create_Time")).ToString("dd-MM-yyyy HH:mm:ss")%>
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
                                                <td align="right" width="25%">
                                                    <asp:Label ID="Label18" runat="server" CssClass="label">Chương trình:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtProgram_CodeQ4" runat="server" AutoCompleteType="Disabled" CssClass="txtContent" Width="80%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label17" runat="server" CssClass="label">Ngày:</asp:Label>
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
                                                    <asp:Label ID="Label19" runat="server" CssClass="label">Tổng số MT lỗi không tính phí:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtTotal_MT_Error_Q4" runat="server" AutoCompleteType="Disabled" CssClass="txtContent" Width="40%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label21" runat="server" CssClass="label">Tổng số tin:</asp:Label>
                                                </td>
                                                <td align="left" width="35%">
                                                    <asp:TextBox ID="txtTotal_MT_Q4" runat="server" AutoCompleteType="Disabled" CssClass="txtContent" Width="40%"></asp:TextBox>
                                                </td>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label93" runat="server" CssClass="label">Tổng số:</asp:Label>
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
                            <asp:Button ID="btnDelQ4" runat="server" CssClass="btnbackground" Text="Xóa" />
                        </div>
                        <div class="pager">
                <cc1:PagerV2_8 ID="PagerQ4" runat="server"   GenerateGoToSection="true"
                    Font-Size="10pt" PageSize="10" />

            </div>
                        <div class="datagrid">
                            <asp:DataGrid ID="DataGridQ4" runat="server" AllowPaging="True" AutoGenerateColumns="false" CellPadding="0" CssClass="datagrid" EnableViewState="False" GridLines="None" PagerStyle-Mode="NextPrev" PagerStyle-Visible="true" Width="100%">
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
                                        <HeaderStyle HorizontalAlign="Center" Width="5%" />
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
                                          <asp:Label ID="Date_IdQ4" runat="server" CssClass="label"  > <%# DateTime.Parse(Eval("Date_Id")).ToString("dd-MM-yyyy")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="CHƯƠNG TRÌNH">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                             <asp:Label ID="Program_CodeQ4" runat="server" CssClass="label" > <%# DataBinder.Eval(Container.DataItem, "Program_Code")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="TỔNG MT LỖI">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                             <asp:Label ID="Total_MT_ErrorQ4" runat="server" CssClass="label" > <%# UtilsNumeric.FormatDecimal(DataBinder.Eval(Container.DataItem, "Total_MT_Error"), 0)%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                   
                                      <asp:TemplateColumn HeaderText="TỔNG TIN">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Total_MTQ4" runat="server" CssClass="label"    Font-Bold="true" >  <%# UtilsNumeric.FormatDecimal(DataBinder.Eval(Container.DataItem, "Total_MT"), 0)%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                       <asp:TemplateColumn HeaderText="SỐ TIN LỖI CHO PHÉP">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Total_MT_Error_ThresholdQ4" runat="server" CssClass="label"    Font-Bold="true" >  <%# UtilsNumeric.FormatDecimal(DataBinder.Eval(Container.DataItem, "Total_MT_Error_Threshold"), 0)%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                       <asp:TemplateColumn HeaderText="TỶ LỆ LỖI">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Rate_ErrorQ4" runat="server" CssClass="label"    Font-Bold="true" >  <%#  DataBinder.Eval(Container.DataItem, "Rate_Error") %>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                     <asp:TemplateColumn HeaderText="ĐIỂM TRỪ">
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Decrease_Percent_TotalQ4" runat="server" CssClass="label"    Font-Bold="true" >  <%#Eval("Decrease_Percent_Total")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                       <asp:TemplateColumn HeaderText="KHỞI TẠO">
                                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Create_TimeQ4" runat="server" CssClass="label"     >  <%# DateTime.Parse(Eval("Create_Time")).ToString("dd-MM-yyyy HH:mm:ss")%>
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
      
</body>
</html>
