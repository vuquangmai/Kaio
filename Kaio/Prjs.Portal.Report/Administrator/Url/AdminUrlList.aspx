<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AdminUrlList.aspx.vb" Inherits="Prjs.Portal.Report.AdminUrlList" %>

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
                                        <asp:Label ID="lblPassword" runat="server" CssClass="label">Kênh:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DropDownListYear" runat="server" CssClass="droplist">
                                            <asp:ListItem>--all--</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label1" runat="server" CssClass="label">Thứ tự:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DropDownListWeek" runat="server" CssClass="droplist">
                                            <asp:ListItem>--all--</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label2" runat="server" CssClass="label">Menu cha:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtFullName0" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                            Width="80%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label3" runat="server" CssClass="label">Tên Menu:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtFullName" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
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
                                        <DetailTables>
                                                <telerik:GridTableView DataKeyNames="ID" Name="OrderDetails_4" Width="100%">
                                                     <Columns>
                                            <telerik:GridBoundColumn SortExpression="ID" HeaderText="MÃ" HeaderButtonType="TextButton"
                                                DataField="ID" UniqueName="ID">
                                                <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn HeaderText="TÊN MENU" SortExpression="Url_Text">
                                                <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblUrl_Text_4" Text='<%# Eval("Url_Text")%>'></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="URL" SortExpression="Url_Id">
                                                <HeaderStyle Width="30%" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblUrl_Id_4" Text='<%# Eval("Url_Id")%>'></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                              <telerik:GridTemplateColumn HeaderText="MENU CHỨC NĂNG" SortExpression="Url_Privilege">
                                                <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblUrl_Privilege_4" Text='<%# Eval("Url_Privilege")%>'  ></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="THỨ TỰ" SortExpression="Url_Order">
                                                <HeaderStyle Width="5%" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblUrl_Order_4" Text='<%# Eval("Url_Order")%>' Font-Bold="True"></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                              <telerik:GridTemplateColumn HeaderText="TRẠNG THÁI" SortExpression="Is_Locked">
                                        <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblIs_Locked_4" Text='<%# Eval("Is_Locked")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                             <telerik:GridTemplateColumn HeaderText="PHÂN QUYỀN RIÊNG" SortExpression="Url_Private">
                                        <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblUrl_Private_4" Text='<%# Eval("Url_Private")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="HIỂN THỊ" SortExpression="Url_Display">
                                                <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblUrl_Display_4" Text='<%# Eval("Url_Display")%>'  ></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                          
                                            <telerik:GridTemplateColumn HeaderText="SỬA">
                                                <HeaderStyle Width="5%" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <a class="datagridLinks" href='AdminUrlEdit.aspx?objid=<%#Utils.EncryptText(Eval("ID")) %>'
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
                                                DataField="ID" UniqueName="ID">
                                                <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </telerik:GridBoundColumn>
                                            <telerik:GridTemplateColumn HeaderText="TÊN MENU" SortExpression="Url_Text">
                                                <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblUrl_Text_3" Text='<%# Eval("Url_Text")%>'></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="URL" SortExpression="Url_Id">
                                                <HeaderStyle Width="30%" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblUrl_Id_3" Text='<%# Eval("Url_Id")%>'></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                              <telerik:GridTemplateColumn HeaderText="MENU CHỨC NĂNG" SortExpression="Url_Privilege">
                                                <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblUrl_Privilege_3" Text='<%# Eval("Url_Privilege")%>'  ></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="THỨ TỰ" SortExpression="Url_Order">
                                                <HeaderStyle Width="5%" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblUrl_Order_3" Text='<%# Eval("Url_Order")%>' Font-Bold="True"></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                              <telerik:GridTemplateColumn HeaderText="TRẠNG THÁI" SortExpression="Is_Locked">
                                        <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblIs_Locked_3" Text='<%# Eval("Is_Locked")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                             <telerik:GridTemplateColumn HeaderText="PHÂN QUYỀN RIÊNG" SortExpression="Url_Private">
                                        <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblUrl_Private_3" Text='<%# Eval("Url_Private")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                            <telerik:GridTemplateColumn HeaderText="HIỂN THỊ" SortExpression="Url_Display">
                                                <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="lblUrl_Display_3" Text='<%# Eval("Url_Display")%>'  ></asp:Label>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>
                                          
                                            <telerik:GridTemplateColumn HeaderText="SỬA">
                                                <HeaderStyle Width="5%" HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <a class="datagridLinks" href='AdminUrlEdit.aspx?objid=<%#Utils.EncryptText(Eval("ID")) %>'
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
                                    <telerik:GridBoundColumn SortExpression="Url_Text" HeaderText="TÊN MENU" HeaderButtonType="TextButton"
                                        DataField="Url_Text">
                                        <HeaderStyle HorizontalAlign="Center" Width="60%" />
                                        <ItemStyle HorizontalAlign="Left" Font-Bold="true" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn HeaderText="THỨ TỰ" SortExpression="Url_Order">
                                        <HeaderStyle Width="5%" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblUrl_Order" Font-Bold="true" Text='<%# Eval("Url_Order")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="TRẠNG THÁI" SortExpression="Is_Locked">
                                        <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblIs_Locked" Text='<%# Eval("Is_Locked")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="PHÂN QUYỀN RIÊNG" SortExpression="Url_Private">
                                        <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblUrl_Private" Text='<%# Eval("Url_Private")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="HIỂN THỊ" SortExpression="Url_Display">
                                        <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblUrl_Display" Text='<%# Eval("Url_Display")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                  
                                    <telerik:GridTemplateColumn HeaderText="SỬA">
                                        <HeaderStyle Width="5%" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <a class="datagridLinks" href='AdminUrlEdit.aspx?objid=<%# Utils.EncryptText(Eval("ID"))%>'
                                                title="Sửa đổi thông tin">
                                                <img border="0" src="/images/comment-edit-icon.png">
                                            </a>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </telerik:GridTableView>
                        </DetailTables>
                        <Columns>
                            <telerik:GridBoundColumn SortExpression="ID" HeaderText="MÃ KÊNH" HeaderButtonType="TextButton"
                                DataField="ID">
                                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                <ItemStyle Font-Bold="true" HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="KÊNH" SortExpression="Channel_Text">
                                <HeaderStyle Width="70%" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblChannel_Text" Text='<%# Eval("Channel_Text")%>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                               <telerik:GridTemplateColumn HeaderText="THƯ MỤC" SortExpression="Channel_Folder">
                                <HeaderStyle Width="20%" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblChannel_Folder" Text='<%# Eval("Channel_Folder")%>'></asp:Label>
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
