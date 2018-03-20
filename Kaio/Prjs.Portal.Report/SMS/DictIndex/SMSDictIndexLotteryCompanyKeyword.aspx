<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SMSDictIndexLotteryCompanyKeyword.aspx.vb" Inherits="Prjs.Portal.Report.SMSDictIndexLotteryCompanyKeyword" %>
<%@ Register Assembly="FilePickerControl" Namespace="AWS.FilePicker" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../../Styles/HQ.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../../Js/Menu.js"></script>
    <style type="text/css">
        fieldset
        {
            display: block;
            border: 1px solid #BCDDAF;
            -moz-border-radius: 8px;
            -webkit-border-radius: 8px;
            border-radius: 8px;
        }

        legend
        {
            background: #FF9;
            border: solid 1px green;
            -webkit-border-radius: 8px;
            -moz-border-radius: 8px;
            border-radius: 8px;
        }

        .auto-style1
        {
            width: 100%;
            border-collapse: collapse;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
     <div id="HQ">
          <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Transparency="30"
            MinDisplayTime="500">
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            </telerik:RadScriptManager>
        </telerik:RadAjaxLoadingPanel>
        <telerik:RadAjaxManager ID="AjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="DropDownListRangeShortCode">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="DropDownListShortCode" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
              <div class="alert">
                <asp:Label ID="lbltitle" runat="server" CssClass="lbltitle"></asp:Label><br />
                <asp:Label ID="lblerror" runat="server" CssClass="lblerror"></asp:Label>
            </div>
         <fieldset id="fieldset5">
                        <legend>
                            <asp:Label ID="lblCompanyText" runat="server" CssClass="lblerror">THÔNG TIN MÃ SMS THEO CÔNG TY XỔ SỐ</asp:Label>
                        </legend>
                        <div class="submmit">
                            <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                                <tr>
                                    <td width="10%" align="right">
                                        <asp:Label ID="Label81" runat="server" CssClass="label">Dải số:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DropDownListRangeShortCode" runat="server" CssClass="droplist" Font-Bold="True" AutoPostBack="True">
                                            <asp:ListItem>--all--</asp:ListItem>
                                            <asp:ListItem>99x</asp:ListItem>
                                            <asp:ListItem>8x79</asp:ListItem>
                                            <asp:ListItem>8x99</asp:ListItem>
                                            <asp:ListItem>8x76</asp:ListItem>
                                            <asp:ListItem>6x66</asp:ListItem>
                                            <asp:ListItem>6x35</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="10%" align="right">
                                        <asp:Label ID="Label27" runat="server" CssClass="label">Đầu số:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="DropDownListShortCode" runat="server" CssClass="droplist" Font-Bold="True">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label29" runat="server" CssClass="label">Mã dịch vụ:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtKeyword" runat="server" AutoCompleteType="Disabled" CssClass="txtContent" Font-Bold="True" Height="50px" TextMode="MultiLine" Width="99%"></asp:TextBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td align="right">&nbsp;</td>
                                    <td align="left">
                                        <asp:Label ID="Label82" runat="server" CssClass="label" Font-Italic="True" ForeColor="Gray">Lưu ý: Các mã cách nhau bởi dấu ;</asp:Label>
                                    </td>
                                </tr>

                            </table>
                        </div>

                        <div class="submmit">

                            <asp:Button ID="btnUpdate" runat="server" CssClass="btnbackground" Font-Bold="True" Text="Ghi lại" />
                            <asp:Button ID="btnDelete" runat="server" CssClass="btnbackground" Font-Bold="True" Text="Xóa" />

                        </div>
                        <div class="submmit">

                            <asp:DataGrid ID="DataGridConfig" runat="server" AllowPaging="True" AutoGenerateColumns="false"
                                CellPadding="0" CssClass="datagrid" EnableViewState="False" GridLines="None"
                                PagerStyle-Mode="NextPrev" PagerStyle-Visible="true" Width="100%" PageSize="30">
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
                                            <asp:Label ID="lblOrder1" runat="server" CssClass="label"
                                                Text='<%# Container.ItemIndex+1 %>'>
                                            </asp:Label>
                                        </ItemTemplate>

                                    </asp:TemplateColumn>

                                    <asp:TemplateColumn HeaderText="ĐẦU SỐ">
                                        <ItemStyle Width="5%" HorizontalAlign="Center" />
                                        <ItemTemplate>

                                            <asp:Label ID="lblShort_Code3" runat="server" CssClass="label" Font-Bold="true"> <%# DataBinder.Eval(Container.DataItem, "Short_Code")%>
                                            </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>

                                    <asp:TemplateColumn HeaderText="MÃ DỊCH VỤ SMS">
                                        <ItemStyle Width="85%" HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container.DataItem, "Key_Word")%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn>
                                        <HeaderStyle HorizontalAlign="Center" Width="3%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            SỬA
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="Editer3" runat="server" title="Edit" BorderStyle="None"
                                                CausesValidation="False" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID")%>'
                                                ImageAlign="absmiddle" ImageUrl="~/Images/comment-edit-icon.png" OnCommand="EditConfig" />
                                        </ItemTemplate>

                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn>
                                        <HeaderStyle HorizontalAlign="Center" Width="3%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            XÓA
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="deleter" runat="server" title="Delete" BorderStyle="None"
                                                CausesValidation="False" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID")%>'
                                                ImageAlign="absmiddle" ImageUrl="~/Images/del.gif" OnCommand="DelConfig" />
                                        </ItemTemplate>

                                    </asp:TemplateColumn>
                                </Columns>
                                <PagerStyle HorizontalAlign="Right" NextPageText="" PageButtonCount="5" PrevPageText=""
                                    Visible="False" />
                            </asp:DataGrid>

                        </div>
                    </fieldset>
    </div>
    </form>
</body>
</html>
