<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="LottUsersList.aspx.vb" Inherits="Prjs.Portal.Report.LottUsersList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../../Styles/HQ.css" rel="stylesheet" type="text/css" />
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
            <div class="datagrid">
                <asp:DataGrid ID="DataGrid" runat="server" AllowPaging="True" AutoGenerateColumns="false"
                    CellPadding="0" CssClass="datagrid" EnableViewState="False" GridLines="None"
                    PagerStyle-Mode="NextPrev" PagerStyle-Visible="true" Width="100%" PageSize="200">
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
                        <asp:TemplateColumn Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderTemplate>
                                #
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblUser_Id" runat="server"   Text=' <%#DataBinder.Eval(Container.DataItem, "Id")%>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="TÊN ĐĂNG NHẬP">
                            <ItemStyle Width="15%" HorizontalAlign="Left" />
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "User_Name")%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="HỌ TÊN">
                            <ItemStyle Width="10%" HorizontalAlign="Left" />
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Full_Name")%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                       
                        <asp:TemplateColumn HeaderText="ĐIỆN THOẠI">
                            <ItemStyle Width="10%" HorizontalAlign="Left" />
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Telephone")%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="TRẠNG THÁI">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <%#DataBinder.Eval(Container.DataItem, "Status")%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="PHÒNG BAN">
                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Dept_Text")%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="NHÓM">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Group_Text")%>
                            </ItemTemplate>
                        </asp:TemplateColumn>

                        <asp:TemplateColumn HeaderText="THỜI GIAN TẠO">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "Create_Time")).ToString("dd-MM-yyyy")%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="QUYỀN BÁO CÁO">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <asp:DropDownList ID="DropDownListReport" runat="server" CssClass="droplist">
                                    <asp:ListItem Value="0">--Chọn--</asp:ListItem>
                                    <asp:ListItem Value="1">User</asp:ListItem>
                                    <asp:ListItem Value="2">All</asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn>
                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderTemplate>
                                QUYỀN NHẬP
                            </HeaderTemplate>
                            <ItemTemplate>
                                <a class="datagridLinks" title="Phân quyền nhập kết quả" href='LottUserPrivilege.aspx?objid=<%# Utils.EncryptText(DataBinder.Eval(Container.DataItem, "ID")) %>'>
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
                <asp:Button ID="btnUpdate" runat="server" CssClass="btnbackground" Font-Bold="False"
                    Text="Cập nhật" />
            </div>

        </div>
    </form>
</body>
</html>
