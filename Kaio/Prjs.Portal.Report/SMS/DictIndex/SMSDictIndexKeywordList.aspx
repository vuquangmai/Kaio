<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SMSDictIndexKeywordList.aspx.vb" Inherits="Prjs.Portal.Report.SMSDictIndexKeywordList" %>
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
                                        <asp:Label ID="Label1" runat="server" CssClass="label">Phòng ban:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DropDownListDepartment_Id" runat="server" CssClass="droplist">
                                            <asp:ListItem>--all--</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
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
                                        <asp:Label ID="Label2" runat="server" CssClass="label">Đầu số:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DropDownListShortCode" runat="server" CssClass="droplist" Font-Bold="True">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label3" runat="server" CssClass="label">Mã dịch vụ:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtKeyWord" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                            Width="50%"></asp:TextBox>
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
                                            <telerik:GridTemplateColumn HeaderText="ĐẦU SỐ" >
                                                <HeaderStyle Width="5%" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblShort_Code_3" Font-Bold="True" Text='<%# Eval("Short_Code")%>'></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="MÃ DỊCH VỤ" SortExpression="Key_Word">
                                                <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblKey_Word_3" Font-Bold="True" Text='<%# Eval("Key_Word")%>'></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                               <telerik:GridTemplateColumn HeaderText="TRẠNG THÁI" SortExpression="Status">
                                                <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblStatus_3"   Text='<%# Eval("Status")%>'></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="ĐỐI TÁC SỞ HỮU MÃ">
                                                <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblPartner_Code_3" Text='<%# Eval("Partner_Code")%>'></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="DỊCH VỤ" >
                                                <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblCate1_Text_3" Text='<%# Eval("Cate1_Text")%>' ></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                          
                                                 <telerik:GridTemplateColumn HeaderText="T/ G CẬP NHẬT">
                                                <HeaderStyle Width="10%" HorizontalAlign="Center" />
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
                                                    <a class="datagridLinks" href='SMSDictIndexKeywordEdit.aspx?objid=<%#Utils.EncryptText(Eval("ID")) %>'
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
                                    <telerik:GridTemplateColumn HeaderText="DẢI SỐ" SortExpression="Range_Of_Short_Code">
                                        <HeaderStyle Width="30%" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblRange_Of_Short_Code_2" Text='<%# Eval("Range_Of_Short_Code")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="ĐẦU SỐ" SortExpression="Short_Code">
                                        <HeaderStyle Width="45%" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblShort_Code_2" Text='<%# Eval("Short_Code")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                              
                                    <telerik:GridTemplateColumn HeaderText="TỔNG SỐ MÃ DỊCH VỤ" SortExpression="Total">
                                        <HeaderStyle Width="30%" HorizontalAlign="Center" />
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
                            <telerik:GridTemplateColumn HeaderText="TRUNG TÂM" SortExpression="Dept_Text">
                                <HeaderStyle Width="40%" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblDept_Text_1" Text='<%# Eval("Dept_Text")%>' CssClass="label"></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="MÃ TRUNG TÂM" SortExpression="Dept_Code">
                                <HeaderStyle Width="20%" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblDept_Code_1" Text='<%# Eval("Dept_Code")%>' CssClass="label"></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                              <telerik:GridTemplateColumn HeaderText="ĐỊNH TUYẾN" SortExpression="Routing_Text">
                                <HeaderStyle Width="20%" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblRouting_Text_1" Text='<%# Eval("Routing_Text")%>' CssClass="label"></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="TỔNG SỐ MÃ DỊCH VỤ" SortExpression="Total">
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
