<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="KpiInfrasDictIndexAlertList.aspx.vb" Inherits="Prjs.Portal.Report.KpiInfrasDictIndexAlertList" %>
<%@ Register Assembly="ASPnetPagerV2_8" Namespace="ASPnetControls" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../../../Styles/HQ.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/LightStyle.css" rel="stylesheet" type="text/css" />
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="HQ">
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            </telerik:RadScriptManager>
            <div class="alert">
                <asp:Label ID="lbltitle" runat="server" CssClass="lbltitle"></asp:Label><br />
                <asp:Label ID="lblerror" runat="server" CssClass="lblerror"></asp:Label>
            </div>
            <div class="pager">
                <cc1:PagerV2_8 ID="pager1" runat="server" OnCommand="pager_Command" GenerateGoToSection="true"
                    Font-Size="10pt" PageSize="50" />

            </div>
            <div class="datagrid">
                <asp:DataGrid ID="DataGrid" runat="server" AllowPaging="True" AutoGenerateColumns="false"
                    CellPadding="0" CssClass="datagrid" EnableViewState="False" GridLines="None"
                    PagerStyle-Mode="NextPrev" PagerStyle-Visible="true" Width="100%" PageSize="50">
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
                                <asp:Label ID="lblOrder" runat="server" CssClass="label"
                                    Text='<%# Container.ItemIndex+1 %>'>
                                </asp:Label>
                            </ItemTemplate>

                        </asp:TemplateColumn>
                         
                        <asp:TemplateColumn HeaderText="TIÊU CHÍ">
                            <ItemStyle Width="15%" HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label ID="Criteria_Text" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Criteria_Text")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="NGƯỠNG CHUẨN">
                            <ItemStyle HorizontalAlign="Center" Width="8%" />
                            <ItemTemplate>
                                <asp:Label ID="Standar_Threshold_Handle" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Standar_Threshold_Handle")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="ĐƠN VỊ TÍNH">
                            <ItemStyle HorizontalAlign="Center" Width="8%" />
                            <ItemTemplate>
                                <asp:Label ID="TypeOf_Unit" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "TypeOf_Unit")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                      
                        <asp:TemplateColumn HeaderText="BƯỚC NHẢY">
                            <ItemStyle HorizontalAlign="Center" Width="8%" />
                            <ItemTemplate>
                                <asp:Label ID="Standar_Threshold_Handle_Over" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Standar_Threshold_Handle_Over")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="ĐIỂM TRỪ QUÁ NGƯỠNG CHUẨN">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <asp:Label ID="Decrease_Percent" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Decrease_Percent")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                          
                        <asp:TemplateColumn HeaderText="CẬP NHẬT">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>

                                <asp:Label ID="lblCreate_Time" runat="server" CssClass="label"><%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "Update_Time")).ToString("dd-MM-yyyy")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="GHI CHÚ">
                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Description")%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn>
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderTemplate>
                                SỬA
                            </HeaderTemplate>
                            <ItemTemplate>
                                <a class="datagridLinks" title="Sửa đổi thông tin" href='KpiInfrasDictIndexAlertEdit.aspx?objid=<%# Utils.EncryptText(DataBinder.Eval(Container.DataItem, "ID")) %>'>
                                    <img border="0" src="/images/comment-edit-icon.png">
                                </a>
                            </ItemTemplate>

                        </asp:TemplateColumn>
                        
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" NextPageText="" PageButtonCount="5" PrevPageText=""
                        Visible="False" />
                </asp:DataGrid>

            </div>
            <div class="submmit">
                <asp:Button ID="btnAdd" runat="server" CssClass="btnbackground" Font-Bold="False"
                    Text="Thêm Url" />
            </div>

        </div>
    </form>
</body>
</html>
