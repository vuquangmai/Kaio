<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SMSDictIndexServiceList.aspx.vb" Inherits="Prjs.Portal.Report.SMSDictIndexServiceList" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../Styles/HQ.css" rel="stylesheet" type="text/css" />

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
                <telerik:AjaxSetting AjaxControlID="RadGrid">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadGrid" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
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
            <div class="parametter">
                <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
                    <tr>
                        <td align="center">
                            <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
                                <tr>
                                    <td align="right" width="20%">
                                        <asp:Label ID="Label3" runat="server" CssClass="label">Dịch vụ:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtCate_Name" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                            Width="80%"></asp:TextBox>
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
                <asp:Button ID="btnAdd" runat="server" CssClass="btnbackground"
                    Text="Thêm" />
            </div>
            <div class="datagrid">

                <telerik:RadGrid ID="RadGrid" runat="server" Width="100%" ShowStatusBar="true" StatusBarSettings-ReadyText="Kaio Corp"
                    SortingSettings-SortedBackColor="Azure" AutoGenerateColumns="False"
                    PageSize="100" AllowSorting="True" AllowMultiRowSelection="False" AllowPaging="True"
                    Skin="Hay">
                    <HeaderStyle Font-Names="Arial" Font-Size="8pt" />
                    <ItemStyle Font-Names="Arial" Font-Size="8pt" ForeColor="Black" />
                    <PagerStyle Mode="NumericPages"></PagerStyle>
                    <SortingSettings SortedBackColor="Azure" />
                    <ClientSettings>
                        <Selecting AllowRowSelect="True" />
                    </ClientSettings>
                    <AlternatingItemStyle Font-Names="Arial" Font-Size="8pt" ForeColor="Black" />
                    <GroupHeaderItemStyle Font-Bold="False" Font-Size="8pt" Font-Underline="False"
                        HorizontalAlign="Center" Font-Names="Arial" ForeColor="Black" />
                    <GroupPanel Font-Size="9pt">
                    </GroupPanel>
                    <MasterTableView Width="100%" DataKeyNames="ID" AllowMultiColumnSorting="True">
                        <DetailTables>
                            <telerik:GridTableView DataKeyNames="ID" Name="Orders" Width="100%">
                                <DetailTables>
                                    <telerik:GridTableView DataKeyNames="ID" Name="OrderDetails" Width="100%">
                                        <Columns>
                                            <telerik:GridBoundColumn SortExpression="ID" HeaderText="MÃ" HeaderButtonType="TextButton"
                                                DataField="ID" UniqueName="ID" Visible="false">
                                                <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn HeaderText="DỊCH VỤ (CATE 3)" >
                                                <HeaderStyle Width="70%" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblCate_Name_3" Font-Bold="True" Text='<%# Eval("Cate_Name")%>'></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                          
                                                 <telerik:GridTemplateColumn HeaderText="THỜI GIAN CẬP NHẬT">
                                                <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblUpdate_Time_3" Text='<%# DateTime.Parse(Eval("Update_Time")).ToString("yyyy-MM-dd")%>'></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="NGƯỜI CẬP NHẬT">
                                                <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblUpdate_By_Text_3" Text='<%# Eval("Update_By_Text")%>'></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="SỬA">
                                                <HeaderStyle Width="5%" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <a class="datagridLinks" href='SMSDictIndexServiceEdit.aspx?objid=<%#Utils.EncryptText(Eval("ID")) %>'
                                                        title="Sửa đổi thông tin">
                                                        <img border="0" src="/images/comment-edit-icon.png">
                                                    </a>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                        </Columns>
                                    </telerik:GridTableView>
                                </DetailTables>
                                <Columns>
                                    <telerik:GridBoundColumn SortExpression="ID" HeaderText="MÃ" HeaderButtonType="TextButton"
                                        DataField="ID" Visible="false">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn HeaderText="NHÓM DỊCH VỤ (CATE 2)"  >
                                        <HeaderStyle Width="80%" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblCate_Name_2" Text='<%# Eval("Cate_Name")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="TỔNG SỐ DỊCH VỤ (CATE 3)" SortExpression="Total">
                                        <HeaderStyle Width="20%" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblTotal_2" Text='<%#UtilsNumeric.FormatDecimal(Eval("Total"), 0)%>' CssClass="label" Font-Bold="true" ForeColor="Red"></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </telerik:GridTableView>
                        </DetailTables>
                        <Columns>
                            <telerik:GridBoundColumn SortExpression="ID" HeaderText="MÃ" HeaderButtonType="TextButton"
                                DataField="ID" Visible="false">
                                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                <ItemStyle Font-Bold="true" HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                              <telerik:GridTemplateColumn HeaderText="STT"  >
                                <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblRowNumber_1" Text='<%# Eval("RowNumber")%>' CssClass="label"></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="NHÓM DỊCH VỤ (CATE 1)"  >
                                <HeaderStyle Width="70%" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblCate_Name_1" Text='<%# Eval("Cate_Name")%>' CssClass="label"></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        
                            <telerik:GridTemplateColumn HeaderText="TỔNG SỐ DỊCH VỤ (CATE 2)" SortExpression="Total">
                                <HeaderStyle Width="20%" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblTotal_1" Text='<%# UtilsNumeric.FormatDecimal(Eval("Total"), 0)%>' CssClass="label" Font-Bold="true" ForeColor="Red"></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>



            </div>
        </div>
    </form>
</body>
</html>
