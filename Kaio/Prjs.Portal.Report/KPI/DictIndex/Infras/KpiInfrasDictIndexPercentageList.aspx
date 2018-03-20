<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="KpiInfrasDictIndexPercentageList.aspx.vb" Inherits="Prjs.Portal.Report.KpiInfrasDictIndexPercentageList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../../Styles/HQ.css" rel="stylesheet" type="text/css" />

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
                                        DataField="ID" Visible="false">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn HeaderText="TIÊU CHÍ">
                                        <HeaderStyle Width="30%" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblCriteria_Text3" Text='<%# Eval("Criteria_Text")%>' Font-Italic="true"></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="TỶ TRỌNG %">
                                        <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblPercentage3" Text='<%# Eval("Percentage")%>' Font-Bold="true"></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="GHI CHÚ">
                                        <HeaderStyle Width="45%" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblDescription3" Text='<%# Eval("Description")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="SỬA">
                                        <HeaderStyle Width="5%" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <a class="datagridLinks" href='KpiInfrasDictIndexPercentageEdit.aspx?objid=<%# Utils.EncryptText(Eval("ID"))%>'
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
                                    <telerik:GridTemplateColumn HeaderText="TIÊU CHÍ">
                                        <HeaderStyle Width="30%" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblCriteria_Text2" Text='<%# Eval("Criteria_Text")%>'  Font-Underline="true"></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="TỶ TRỌNG %">
                                        <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblPercentage2" Text='<%# Eval("Percentage")%>' Font-Bold="true" ForeColor="Blue"></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="GHI CHÚ">
                                        <HeaderStyle Width="45%" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblDescription2" Text='<%# Eval("Description")%>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="SỬA">
                                        <HeaderStyle Width="5%" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <a class="datagridLinks" href='KpiInfrasDictIndexPercentageEdit.aspx?objid=<%# Utils.EncryptText(Eval("ID"))%>'
                                                title="Sửa đổi thông tin">
                                                <img border="0" src="/images/comment-edit-icon.png">
                                            </a>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>

                            </telerik:GridTableView>
                        </DetailTables>
                        <Columns>
                            <telerik:GridBoundColumn SortExpression="ID" HeaderText="MÃ TIÊU CHÍ" HeaderButtonType="TextButton"
                                DataField="ID">
                                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                <ItemStyle Font-Bold="true" HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="TIÊU CHÍ">
                                <HeaderStyle Width="30%" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblCriteria_Text1" Text='<%# Eval("Criteria_Text")%>' Font-Bold="true" ></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="TỶ TRỌNG %">
                                <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblPercentage1" Text='<%# Eval("Percentage")%>' Font-Bold="true" ForeColor="Red"></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="GHI CHÚ">
                                <HeaderStyle Width="50%" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblDescription1" Text='<%# Eval("Description")%>'></asp:Label>
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
