<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="KpiBrDataFileList.aspx.vb" Inherits="Prjs.Portal.Report.KpiBrDataFileList" %>
<%@ Register Assembly="ASPnetPagerV2_8" Namespace="ASPnetControls" TagPrefix="cc1" %>

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
        </telerik:RadAjaxManager>
        <div id="HQ">
            <div class="alert">
                <asp:Label ID="lbltitle" runat="server" CssClass="lbltitle"></asp:Label><br />
                <asp:Label ID="lblerror" runat="server" CssClass="lblerror"></asp:Label>
            </div>
            <div class="input" style="width: 60%">
                <table border="0" cellpadding="2" cellspacing="1" style="width: 100%">
                    <tr>
                        <td align="right" width="30%">
                            <asp:Label ID="Label7" runat="server" CssClass="label">Năm:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListYear" runat="server" CssClass="droplist">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label26" runat="server" CssClass="label">Tháng:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListMonth" runat="server" CssClass="droplist">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label31" runat="server" CssClass="label">Dịch vụ:</asp:Label>
                        </td>
                        <td align="left">
                                        <asp:DropDownList ID="DropDownListService_Id" runat="server" CssClass="droplist">
                                            <asp:ListItem Value="0">--all--</asp:ListItem>
                                            <asp:ListItem Value="2">Brandname</asp:ListItem>
                                        </asp:DropDownList>
                        </td>
                    </tr>
                    </table>
            </div>
            <div class="submmit">
                <asp:Button ID="btnSearching" runat="server" CssClass="btnbackground"
                    Text="Tìm kiếm" />
                <asp:Button ID="btnExp" runat="server" CssClass="btnbackground"
                    Text="Báo cáo" />
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
                            <HeaderStyle HorizontalAlign="Center" Width="2%" />
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
                        <asp:TemplateColumn HeaderText="THÁNG">
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblYear" runat="server" CssClass="label" Font-Bold="true">   <%# DataBinder.Eval(Container.DataItem, "Month")%> </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="DỊCH VỤ">
                            <ItemStyle Width="15%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="TypeOf_Text" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "TypeOf_Text")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="TÊN FILE">
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="File_Name" runat="server" CssClass="label" Font-Bold="true">   <%# DataBinder.Eval(Container.DataItem, "File_Name")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                      
                        <asp:TemplateColumn HeaderText="DOWNLOAD">
                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                            <ItemTemplate>
                               
                                            <a href='../..<%# Eval("File_Url")%>'  title="Download"> <asp:Label ID="File_Url" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "File_Name")%></asp:Label> </a> 
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="THỜI GIAN TẠO">
                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                            <ItemTemplate>

                                                                <asp:Label ID="Create_Time" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Create_Time")%></asp:Label>

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
