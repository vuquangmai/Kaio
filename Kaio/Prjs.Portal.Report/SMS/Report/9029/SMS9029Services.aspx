<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SMS9029Services.aspx.vb" Inherits="Prjs.Portal.Report.SMS9029Services" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="ASPnetPagerV2_8" Namespace="ASPnetControls" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../../../Styles/HQ.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/LightStyle.css" rel="stylesheet" type="text/css" />
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
                                    <asp:Label ID="lblTrang9" runat="server" CssClass="label">Dịch vụ:</asp:Label>
                                </td>
                                <td align="left">
                            
                                    <asp:TextBox ID="txtService_Name" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                        Width="80%"></asp:TextBox>
                            
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblTrang10" runat="server" CssClass="label">Mã đăng ký:</asp:Label>
                                </td>
                                <td align="left">
                            
                                    <asp:TextBox ID="txtRegister_Syntax" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                        Width="80%"></asp:TextBox>
                            
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblTrang11" runat="server" CssClass="label">Tổng số:</asp:Label>
                                </td>
                                <td align="left">
               <asp:Label ID="lblTotal" runat="server" CssClass="lblerror"></asp:Label>
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

                            <asp:DataGrid ID="DataGrid" runat="server" AutoGenerateColumns="false" CellPadding="0"
                                        CssClass="datagrid" EnableViewState="False" GridLines="None" PagerStyle-Mode="NextPrev"
                                        PagerStyle-Visible="true" Width="100%" PageSize="120">
                                        <HeaderStyle CssClass="datagridHeader" />
                                        <AlternatingItemStyle CssClass="datagridAlternatingItemStyle" />
                                        <ItemStyle CssClass="datagridItemStyle" />
                                        <Columns>
                                            <asp:TemplateColumn>
                                                <HeaderTemplate>
                                                    #
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOrder" runat="server" Font-Names="Tahoma" Font-Size="8pt" ForeColor="DimGray"
                                                        Text="<%# Container.ItemIndex+1 %>"> </asp:Label>
                                                </ItemTemplate>
                                               
                                                <HeaderStyle HorizontalAlign="Center" Width="2%" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="MÃ DỊCH VỤ">
                                                <ItemTemplate>
                                                    <%# DataBinder.Eval(Container.DataItem, "ServiceCode")%>
                                                </ItemTemplate>
                                                <ItemStyle Width="15%" HorizontalAlign="Left" />
                                            </asp:TemplateColumn>
                                                
                                        
                                            <asp:TemplateColumn HeaderText="TÊN DỊCH VỤ">
                                                <ItemTemplate>
                                                    <%# DataBinder.Eval(Container.DataItem, "ServiceName")%>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="30%" />
                                            </asp:TemplateColumn>
                                        
                                           <asp:TemplateColumn HeaderText="MÔ TẢ DỊCH VỤ">
                                                <ItemTemplate>
                                                    <%# DataBinder.Eval(Container.DataItem, "ServiceDesc")%>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="40%" />
                                            </asp:TemplateColumn>
                                              <asp:TemplateColumn HeaderText="GIÁ">
                                                <ItemTemplate>
                                                    <%# DataBinder.Eval(Container.DataItem, "TotalAmount")%>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="10%" />
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
