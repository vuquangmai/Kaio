<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="S2DictIndexVNMServiceList.aspx.vb" Inherits="Prjs.Portal.Report.S2DictIndexVNMServiceList" %>
<%@ Register Assembly="ASPnetPagerV2_8" Namespace="ASPnetControls" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../../Styles/HQ.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/LightStyle.css" rel="stylesheet" type="text/css" />
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
               <div class="parametter">
                <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
                    <tr>
                        <td align="center">
                            <table border="0" cellpadding="2" cellspacing="2" style="width: 100%">
                                <tr>
                                    <td align="right" width="20%">
                                        <asp:Label ID="Label1" runat="server" CssClass="label">Đối tác:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DropDownListWeek" runat="server" CssClass="droplist" AutoPostBack="True">
                                            <asp:ListItem>--all--</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label2" runat="server" CssClass="label">Mã dịch vụ:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtFullName0" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                            Width="80%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label3" runat="server" CssClass="label">Cú pháp đăng ký:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtFullName" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                            Width="80%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        &nbsp;</td>
                                    <td align="left">
                <asp:Button ID="btnSearch" runat="server" CssClass="btnbackground" Font-Bold="False"
                    Text="Tìm kiếm" />
                <asp:Button ID="btnAdd" runat="server" CssClass="btnbackground" Font-Bold="False"
                    Text="Thêm mới" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
              <div class="pager">
              <cc1:PagerV2_8 ID="pager1" runat="server" OnCommand="pager_Command" GenerateGoToSection="true"
                Font-Size="10pt" PageSize="500" />
               
        </div>
            <div class="datagrid">
                <asp:DataGrid ID="DataGrid" runat="server" AllowPaging="True" AutoGenerateColumns="false"
                    CellPadding="0" CssClass="datagrid" EnableViewState="False" GridLines="None"
                    PagerStyle-Mode="NextPrev" PagerStyle-Visible="true" Width="100%" PageSize="500">
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
                        <asp:TemplateColumn HeaderText="MÃ DỊCH VỤ">
                            <ItemStyle Width="10%" HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label ID="lblService_Id" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Service_Id")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="TÊN DỊCH VỤ">
                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                            <ItemTemplate>
                                <asp:Label ID="lblService_Text" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Service_Text")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="GIÁ">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                <asp:Label ID="lblPricing" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Pricing")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="ĐĂNG KÝ">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <asp:Label ID="lblSubscription_Command_Word" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Subscription_Command_Word")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="HỦY">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <asp:Label ID="lblUnsubscription_Command_Word" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Unsubscription_Command_Word")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                           <asp:TemplateColumn HeaderText="ĐỐI TÁC">
                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                            <ItemTemplate>
                                <asp:Label ID="lblPartner_Text" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Partner_Text")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                           <asp:TemplateColumn HeaderText="MÃ ĐỐI TÁC">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                <asp:Label ID="lblPartner_Code" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Partner_Code")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                      
                        <asp:TemplateColumn HeaderText="THỜI GIAN TẠO">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                
                                <asp:Label ID="lblCreate_Time" runat="server" CssClass="label"><%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "Create_Time")).ToString("dd-MM-yyyy")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                
                        <asp:TemplateColumn>
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderTemplate>
                                SỬA
                            </HeaderTemplate>
                            <ItemTemplate>
                                <a class="datagridLinks" title="Sửa đổi thông tin" href='S2DictIndexVNMServiceEdit.aspx?objid=<%# Utils.EncryptText(DataBinder.Eval(Container.DataItem, "ID")) %>'>
                                    <img border="0" src="/images/comment-edit-icon.png">
                                </a>
                            </ItemTemplate>

                        </asp:TemplateColumn>
                        <asp:TemplateColumn>
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderTemplate>
                                XÓA
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="deleter" runat="server" title="xóa thông tin" BorderStyle="None"
                                    CausesValidation="False" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID")%>'
                                    ImageAlign="absmiddle" ImageUrl="~/Images/del.gif" OnCommand="DelData" />
                            </ItemTemplate>

                        </asp:TemplateColumn>
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" NextPageText="" PageButtonCount="5" PrevPageText=""
                        Visible="False" />
                </asp:DataGrid>

            </div>
            <div class="submmit">
            </div>

        </div>
    </form>
</body>
</html>
