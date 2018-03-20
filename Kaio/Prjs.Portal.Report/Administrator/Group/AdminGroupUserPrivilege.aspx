<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AdminGroupUserPrivilege.aspx.vb" Inherits="Prjs.Portal.Report.AdminGroupUserPrivilege" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
  <link href="../../Styles/HQ.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="HQ">
         <div class="alert">
                <asp:Label ID="lbltitle" runat="server" CssClass="lbltitle"></asp:Label><br />
                <asp:Label ID="lblerror" runat="server" CssClass="lblerror"></asp:Label>
            </div>
         <div class="alert">
              <asp:Image ID="imgroup" runat="server" ImageUrl="~/images/user-group-icon.png" />
                    <asp:Label ID="lblgroupUser" runat="server" CssClass="label_title_object"></asp:Label>
         </div>
        <div class="datagrid">
         
                <asp:DataGrid ID="grddata" runat="server" AllowPaging="True" AutoGenerateColumns="false"
                                        CellPadding="0" CssClass="datagrid" EnableViewState="False" GridLines="None"
                                        PagerStyle-Mode="NextPrev" PagerStyle-Visible="true" Width="100%" 
                                        PageSize="500">
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
                                                    <asp:Label ID="lblOrder" runat="server"  
                                                        Text='<%# Container.ItemIndex+1 %>'>
                                                    </asp:Label>
                                                </ItemTemplate>
                                             
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="#" Visible="False">
                                                <ItemStyle HorizontalAlign="Left" Width="5%" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblfunid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ID") %>'>   </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="#" Visible="False">
                                                <ItemStyle HorizontalAlign="Left" Width="5%" />
                                                <ItemTemplate>
                                                    <asp:Label ID="funvalue" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Privilege_Val")%>'>   </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                              <asp:TemplateColumn HeaderText="KÊNH">
                                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                                                <ItemTemplate>
                                                    <asp:Label ID="moduleName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Channel_Text")%>'>   </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="TÊN MENU">
                                                <ItemStyle HorizontalAlign="Left" Width="30%" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblitemName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Url_Text")%>'>   </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                          
                                            <asp:TemplateColumn HeaderText="URL">
                                                <ItemStyle HorizontalAlign="Left" Width="45%" />
                                                <ItemTemplate>
                                                    <asp:Label ID="itemUrl" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Url_Id")%>'>   </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="#" Visible="False">
                                                <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lblmaxvalues" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MaxValues") %>'>
                                                    </asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="QUYỀN HẠN">
                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="DropDownListFunction" runat="server" CssClass="droplist" Width="80%"
                                                        SelectedValue='<%# DataBinder.Eval(Container.DataItem, "Privilege_Val")%>'>
                                                        <asp:ListItem Value="1">Xem</asp:ListItem>
                                                        <asp:ListItem Value="2">Sửa</asp:ListItem>
                                                        <asp:ListItem Value="3">X&#243;a</asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                        </Columns>
                                        <PagerStyle HorizontalAlign="Right" NextPageText="" PageButtonCount="5" PrevPageText=""
                                            Visible="False" />
                                    </asp:DataGrid>
        </div>
          <div class="submmit">
                 <asp:Button ID="btnUpdate" runat="server" CssClass="btnbackground" Font-Bold="False"
                        Text="Lưu lại" />
                    <asp:Button ID="btnReturn" runat="server" CssClass="btnbackground" Font-Bold="False"
                        Text="Quay ra" />
            </div>
    </div>
    </form>
</body>
</html>
