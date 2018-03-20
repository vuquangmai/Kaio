<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="KpiScratchCardHandleTransaction.aspx.vb" Inherits="Prjs.Portal.Report.KpiScratchCardHandleTransaction" %>

<%@ Register Assembly="ASPnetPagerV2_8" Namespace="ASPnetControls" TagPrefix="cc1" %>
<%@ Register Assembly="FilePickerControl" Namespace="AWS.FilePicker" TagPrefix="cc2" %>
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
                <telerik:AjaxSetting AjaxControlID="RadDate_IdQ1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="PagerQ1" />
                        <telerik:AjaxUpdatedControl ControlID="DataGridQ1" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="DataGridQ1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="lbltitle_Q1" />
                        <telerik:AjaxUpdatedControl ControlID="txtFileUploadQ1" />
                        <telerik:AjaxUpdatedControl ControlID="RadDate_IdQ1" />
                        <telerik:AjaxUpdatedControl ControlID="txtTotal_Trans_1" />
                        <telerik:AjaxUpdatedControl ControlID="txtTotal_Trans_2" />
                        <telerik:AjaxUpdatedControl ControlID="txtTotal_Trans_3" />
                        <telerik:AjaxUpdatedControl ControlID="txtTotal_Pending" />
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
                        <telerik:RadTab Text="Chất lượng xử lý giao dịch" Font-Names="Arial" Selected="True">
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
                                                    <asp:Label ID="Label87" runat="server" CssClass="label">File excel:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <cc2:FilePicker ID="txtFileUploadQ1" runat="server" CssClass="txtContent" fpAllowedUploadFileExts="" fpPopupURL="../../FilePicker/FilePicker.aspx" fpPopupWidth="600" Width="90%"></cc2:FilePicker>
                                                </td>
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
                                                    <asp:Label ID="Label89" runat="server" CssClass="label">Sheet:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="txtSheetQ1" runat="server" AutoCompleteType="Disabled" CssClass="txtContent" Width="50%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label84" runat="server" CssClass="label">Số giao dịch &lt;1s:</asp:Label>
                                                </td>
                                                <td align="left" width="35%">
                                                    <telerik:RadNumericTextBox ID="txtTotal_Trans_1" runat="server" CssClass="txtContent" Culture="vi-VN" DataType="System.Int64" Font-Bold="True" Font-Names="Arial" IncrementSettings-InterceptArrowKeys="true" IncrementSettings-InterceptMouseWheel="true" LabelWidth="" ShowSpinButtons="true" Skin="Forest" Width="100px">
                                                        <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                                                    </telerik:RadNumericTextBox>
                                                </td>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label1" runat="server" CssClass="label">Số giao dịch từ 1s đến 2s:</asp:Label>
                                                </td>
                                                <td align="left">
                                                    <telerik:RadNumericTextBox ID="txtTotal_Trans_2" runat="server" CssClass="txtContent" Culture="vi-VN" DataType="System.Int16" Font-Bold="True" Font-Names="Arial" IncrementSettings-InterceptArrowKeys="true" IncrementSettings-InterceptMouseWheel="true" LabelWidth="" ShowSpinButtons="true" Skin="Forest" Width="100px">
                                                        <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                                                    </telerik:RadNumericTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label85" runat="server" CssClass="label">Số giao dịch &gt;2s:</asp:Label>
                                                </td>
                                                <td align="left" width="35%">
                                                    <telerik:RadNumericTextBox ID="txtTotal_Trans_3" runat="server" CssClass="txtContent" Culture="vi-VN" DataType="System.Int64" Font-Bold="True" Font-Names="Arial" IncrementSettings-InterceptArrowKeys="true" IncrementSettings-InterceptMouseWheel="true" LabelWidth="" ShowSpinButtons="true" Skin="Forest" Width="100px">
                                                        <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                                                    </telerik:RadNumericTextBox>
                                                </td>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label48" runat="server" CssClass="label">Số giao dịch pending:</asp:Label>
                                                </td>
                                                <td align="left">

                                                    <telerik:RadNumericTextBox ID="txtTotal_Pending" runat="server" CssClass="txtContent" Culture="vi-VN" DataType="System.Int16" Font-Bold="True" Font-Names="Arial" IncrementSettings-InterceptArrowKeys="true" IncrementSettings-InterceptMouseWheel="true" LabelWidth="" ShowSpinButtons="true" Skin="Forest" Width="100px">
                                                        <NumberFormat DecimalDigits="0" ZeroPattern="n" />
                                                    </telerik:RadNumericTextBox>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" width="15%">&nbsp;</td>
                                                <td align="left" width="35%">&nbsp;</td>
                                                <td align="right" width="15%">
                                                    <asp:Label ID="Label91" runat="server" CssClass="label">Tổng số:</asp:Label>
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
                                    <asp:TemplateColumn HeaderText="GD <1s">
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Total_Trans_1Q1" runat="server" CssClass="label"> <%#        UtilsNumeric.FormatDecimal(DataBinder.Eval(Container.DataItem, "Total_Trans_1"),0)%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="GD 1s ĐẾN 2s">
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Total_Trans_2Q1" runat="server" CssClass="label"> <%#        UtilsNumeric.FormatDecimal(DataBinder.Eval(Container.DataItem, "Total_Trans_2"),0)%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="GD >2s">
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Total_Trans_3Q1" runat="server" CssClass="label"> <%#        UtilsNumeric.FormatDecimal(DataBinder.Eval(Container.DataItem, "Total_Trans_3"),0)%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="TỔNG SỐ GD">
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Total_TransQ1" runat="server" CssClass="label"> <%#        UtilsNumeric.FormatDecimal(DataBinder.Eval(Container.DataItem, "Total_Trans"),0)%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="GD PENDING">
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Total_PendingQ1" runat="server" CssClass="label" ForeColor="Red">  <%#        UtilsNumeric.FormatDecimal(DataBinder.Eval(Container.DataItem, "Total_Pending"),0)%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="TỶ LỆ PENDING">
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Rate_PendingQ1" runat="server" CssClass="label" ForeColor="Red">  <%#Eval("Rate_Pending")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="ĐIỂM X/L GD ">
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                        <ItemTemplate>
                                            <asp:Label ID="KPI_Handle_TransactionQ1" runat="server" CssClass="label">  <%# Eval("KPI_Handle_Transaction")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="ĐIỂM TRỪ PENDING ">
                                        <ItemStyle HorizontalAlign="Center" Width="8%" />
                                        <ItemTemplate>
                                            <asp:Label ID="Decrease_Percent_TotalQ1" runat="server" CssClass="label" ForeColor="Red">  <%# Eval("Decrease_Percent_Total")%>
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
    
</body>
</html>
