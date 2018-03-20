<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AndroidAppsDictIndexList.aspx.vb" Inherits="Prjs.Portal.Report.AndroidAppsDictIndexList" %>
<%@ Register Assembly="ASPnetPagerV2_8" Namespace="ASPnetControls" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../../Styles/HQ.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/LightStyle.css" rel="stylesheet" type="text/css" />
    <title>Untitled Page</title>
        <script type="text/javascript" src="../../Scripts/jquery-1.7.1.js"></script>
    <script type="text/javascript">

        $(document).ready(function () {

            $('code').click(function () {
                if (document.selection) {
                    var block = document.body.createTextRange();
                    block.moveToElementText($(this)[0]);
                    block.select();

                } else {
                    var block = document.createRange();
                    block.setStartBefore($(this)[0]);
                    block.setEndAfter($(this)[0]);
                    window.getSelection().addRange(block);
                }
                document.execCommand('copy')

            });
        });
    </script>
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
                                        <asp:Label ID="Label1" runat="server" CssClass="label">Trạng thái:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DropDownListStatus_Id" runat="server" CssClass="droplist">
                                            <asp:ListItem Value="-1">--all--</asp:ListItem>
                                            <asp:ListItem Value="0">Online</asp:ListItem>
                                            <asp:ListItem Value="1">Removed</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label2" runat="server" CssClass="label">App Id:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtApp_Id" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                            Width="80%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label3" runat="server" CssClass="label">Số lần crawler:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtCrawler_Num" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                            Width="50px"></asp:TextBox>
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
                                <tr>
                                    <td align="right">
                                        &nbsp;</td>
                                    <td align="left">
                                        <asp:Label ID="lblTotal" runat="server" CssClass="lblerror"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
              <div class="pager">
              <cc1:PagerV2_8 ID="pager1" runat="server" OnCommand="pager_Command" GenerateGoToSection="true"
                Font-Size="10pt" PageSize="300" />
               
        </div>
            <div class="datagrid">
                <asp:DataGrid ID="DataGrid" runat="server" AllowPaging="True" AutoGenerateColumns="false"
                    CellPadding="0" CssClass="datagrid" EnableViewState="False" GridLines="None"
                    PagerStyle-Mode="NextPrev" PagerStyle-Visible="true" Width="100%" PageSize="300">
                    <HeaderStyle CssClass="datagridHeader" />
                    <AlternatingItemStyle CssClass="datagridAlternatingItemStyle" />
                    <ItemStyle CssClass="datagridItemStyle" />
                    <Columns>
                        <asp:TemplateColumn>
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
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
                        <asp:TemplateColumn HeaderText="APP">
                            <ItemStyle Width="35%" HorizontalAlign="Left" />
                            <ItemTemplate>
                                <code>
                                <asp:Label ID="lblApp_Id" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "App_Id")%></asp:Label>
                                    </code>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="TRẠNG THÁI">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <asp:Label ID="lblStatus_Id" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Status_Id")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        
                      
                        <asp:TemplateColumn HeaderText="NGÀY IMPORT">
                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                            <ItemTemplate>
                              
                                <asp:Label ID="lblSync_Date" runat="server" CssClass="label"><%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "Sync_Date")).ToString("dd-MM-yyyy")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                               <asp:TemplateColumn HeaderText="NGÀY CRAWL">
                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                            <ItemTemplate>
                                <asp:Label ID="lbCrawler_Date" runat="server" CssClass="label" >   <%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "Crawler_Date")).ToString("dd-MM-yyyy")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="SỐ LẦN CRAWL">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                 <asp:Label ID="lbCrawler_Num" runat="server" CssClass="label" Font-Bold="true" >   <%# DataBinder.Eval(Container.DataItem, "Crawler_Num")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn>
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderTemplate>
                                SỬA
                            </HeaderTemplate>
                            <ItemTemplate>
                                <a class="datagridLinks" title="Sửa đổi thông tin" href='AndroidAppsDictIndexEdit.aspx?objid=<%# Utils.EncryptText(DataBinder.Eval(Container.DataItem, "ID")) %>'>
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
