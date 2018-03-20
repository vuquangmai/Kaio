<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CcareDictIndexRefuseList.aspx.vb" Inherits="Prjs.Portal.Report.CcareDictIndexRefuseList" %>
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
                                    <td align="right" width="30%">
                                        <asp:Label ID="Label3" runat="server" CssClass="label">Số điện thoại:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtUser_Id" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                            Width="40%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">&nbsp;</td>
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
                        <asp:TemplateColumn HeaderText="SỐ ĐIỆN THOẠI">
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblUSER_ID" runat="server" CssClass="label" Font-Bold="true">   <%# DataBinder.Eval(Container.DataItem, "USER_ID")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="MẠNG">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <asp:Label ID="lblMOBILE_OPERATOR" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "MOBILE_OPERATOR")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                           <asp:TemplateColumn HeaderText="NGƯỜI CẬP NHẬT">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <asp:Label ID="lblUPDATE_BY_TEXT" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "UPDATE_BY_TEXT")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>

                        <asp:TemplateColumn HeaderText="THỜI GIAN CẬP NHẬT">
                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                            <ItemTemplate>

                                <asp:Label ID="lblUPDATE_TIME" runat="server" CssClass="label"><%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "UPDATE_TIME")).ToString("dd-MM-yyyy")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="GHI CHÚ">
                            <ItemStyle HorizontalAlign="Left" Width="40%" />
                            <ItemTemplate>
                                <asp:Label ID="lblDESCRIPTION" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "DESCRIPTION")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn>
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderTemplate>
                                SỬA
                            </HeaderTemplate>
                            <ItemTemplate>
                                <a class="datagridLinks" title="Sửa đổi" href='CcareDictIndexRefuseEdit.aspx?objid=<%# Utils.EncryptText(DataBinder.Eval(Container.DataItem, "ID")) %>'>
                                    <img border="0" src="/images/comment-edit-icon.png">
                                </a>
                            </ItemTemplate>

                        </asp:TemplateColumn>
                        <asp:TemplateColumn>
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderTemplate>
                                XÓA
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="deleter" runat="server" title="Xóa" BorderStyle="None"
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