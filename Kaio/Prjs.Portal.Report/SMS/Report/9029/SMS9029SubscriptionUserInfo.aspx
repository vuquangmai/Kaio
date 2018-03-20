<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SMS9029SubscriptionUserInfo.aspx.vb" Inherits="Prjs.Portal.Report.SMS9029SubscriptionUserInfo" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="ASPnetPagerV2_8" Namespace="ASPnetControls" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../../../Styles/HQ.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/LightStyle.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        function CancelService(vId)
        { window.open("http://vigame.com.vn/cancel.aspx?msisdn=" + vId, "Cancel", "location=no,directories=no,left=100,top=0,height=300,width=700,status=no,scrollbars=yes,toolbars=no,menubar=no,resizable=yes"); }

</script>
</head>
<body>
    <form id="form1" runat="server">
     <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Transparency="30"
            MinDisplayTime="500">
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            </telerik:RadScriptManager>
        </telerik:RadAjaxLoadingPanel>
        <telerik:RadAjaxManager ID="AjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
        </telerik:RadAjaxManager>
        <div id="HQ">
            <div class="alert">
                <asp:Label ID="lblTitle" runat="server" CssClass="lbltitle"></asp:Label><br />
                <asp:Label ID="lblerror" runat="server" CssClass="lblerror"></asp:Label>
            </div>
            <div class="parametter">
                <table width="100%">
                    <tr>
                        <td align="right" width="30%">
                            <asp:Label ID="lblTrang9" runat="server" CssClass="label">Số điện thoại:</asp:Label>
                        </td>
                        <td align="left">

                            <asp:TextBox ID="txtUser_Id" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="60%"></asp:TextBox>

                        </td>
                    </tr>
                </table>
            </div>

            <div class="submmit">
                <asp:Button ID="btnSearching" runat="server" CssClass="btnbackground"
                    Text="Tìm kiếm" />
                <asp:Button ID="btnExport" runat="server" CssClass="btnbackground"
                    Text="Báo cáo" />
            </div>
            <div class="pager">
                <cc1:PagerV2_8 ID="pager1" runat="server" OnCommand="pager_Command" GenerateGoToSection="true"
                    Font-Size="10pt" PageSize="50" />

            </div>
            <div class="datagrid">

                <asp:DataGrid ID="GridData" runat="server" AutoGenerateColumns="false" CellPadding="0"
                    CssClass="datagrid" EnableViewState="False" GridLines="None" PagerStyle-Mode="NextPrev"
                    PagerStyle-Visible="true" Width="100%" PageSize="50">
                    <HeaderStyle CssClass="datagridHeader" />
                    <AlternatingItemStyle CssClass="datagridAlternatingItemStyle" />
                    <ItemStyle CssClass="datagridItemStyle" />
                    <Columns>
                        <asp:TemplateColumn>
                            <HeaderTemplate>
                                #
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblOrder" runat="server" CssClass="label"
                                    Text="<%# Container.ItemIndex+1 %>"> </asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="2%" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="SỐ ĐIỆN THOẠI">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Msisdn")%>
                            </ItemTemplate>
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="T/G ĐĂNG KÝ">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "RegisterTime")%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="KÊNH ĐĂNG KÝ">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "RegisterChannel")%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="THỜI GIAN HỦY">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "CancelTime")%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="KÊNH HỦY">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "CancelChannel")%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="NỘI DUNG">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Detail")%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="TRẠNG THÁI">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "StatusText")%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:TemplateColumn>

                        <asp:TemplateColumn HeaderText="ĐỐI TÁC">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "PartnerName")%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="HỦY">
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" />


                            <ItemTemplate>
                                <a href="JavaScript:CancelService('<%#DataBinder.Eval(Container.DataItem, "Msisdn") %>')"
                                    title="Hủy dịch vụ" class="cateGrid">
                                    <img border="0" src="/images/del.gif">
                                </a>
                            </ItemTemplate>


                        </asp:TemplateColumn>
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" NextPageText="" PageButtonCount="5" PrevPageText=""
                        Visible="False" />
                </asp:DataGrid>

            </div>
        </div>
    </form>
</body>
</html>
