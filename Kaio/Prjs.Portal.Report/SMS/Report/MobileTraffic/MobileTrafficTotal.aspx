<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MobileTrafficTotal.aspx.vb" Inherits="Prjs.Portal.Report.MobileTrafficTotal" %>

<%@ Register Assembly="ASPnetPagerV2_8" Namespace="ASPnetControls" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../../../Styles/HQ.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/LightStyle.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../../Js/Menu.js"></script>

    <title>Untitled Page</title>

</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <telerik:RadAjaxManager ID="AjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
        </telerik:RadAjaxManager>
        <div id="HQ">

            <div class="alert">
                <asp:Label ID="lbltitle" runat="server" CssClass="lbltitle"></asp:Label><br />
                <asp:Label ID="lblerror" runat="server" CssClass="lblerror"></asp:Label>
            </div>
            <div class="parametter" style="width: 50%;">
                <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                    <tr>
                        <td align="right" width="35%">
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
                            <asp:Label ID="Label33" runat="server" CssClass="label">Mạng:</asp:Label>
                        </td>
                        <td align="left">

                            <asp:DropDownList ID="DropDownListOperator" runat="server" CssClass="droplist" Font-Bold="False">
                                <asp:ListItem>--all--</asp:ListItem>
                                <asp:ListItem Value="VIETTEL">VIETTEL</asp:ListItem>
                                <asp:ListItem Value="VMS">VMS</asp:ListItem>
                                <asp:ListItem>GPC</asp:ListItem>
                                <asp:ListItem>VNM</asp:ListItem>
                                <asp:ListItem>GTEL</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label31" runat="server" CssClass="label">Dải số:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListRangOfShortCode" runat="server" CssClass="droplist" Font-Bold="False">
                                <asp:ListItem>--all--</asp:ListItem>
                                <asp:ListItem Value="99x">99x</asp:ListItem>
                                <asp:ListItem Value="8x79">8x79</asp:ListItem>
                                <asp:ListItem Value="6x66">6x66</asp:ListItem>
                                <asp:ListItem Value="8x99">8x99</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>

                    <tr>
                        <td align="right">
                            <asp:Label ID="Label32" runat="server" CssClass="label">Đầu số:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListShortCode" runat="server" CssClass="droplist" Font-Bold="False">
                            </asp:DropDownList>
                        </td>
                    </tr>

                </table>
            </div>
            <div class="submmit">
                <asp:Button ID="btnSearch" runat="server" CssClass="btnbackground"
                    Text="Tìm kiếm" />
                <asp:Button ID="btnExport" runat="server" CssClass="btnbackground"
                    Text="Báo cáo" />
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

                        <asp:TemplateColumn HeaderText="THÁNG">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>

                                <asp:Label ID="lblMonth" runat="server" CssClass="label"><%# DataBinder.Eval(Container.DataItem, "MonthData")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="MẠNG">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <asp:Label ID="Mobile_Operator" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Mobile_Operator")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="ĐẦU SỐ">
                            <ItemStyle Width="15%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="Short_Code" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Short_Code")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="MO GATEWAY">
                            <ItemStyle Width="10%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="MO" runat="server" CssClass="label" Font-Bold="true" ForeColor="#0033cc">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "MO"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="MT GATEWAY">
                            <ItemStyle Width="10%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="MT" runat="server" CssClass="label" Font-Bold="true" ForeColor="#006600">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "MT"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="CDR GATEWAY">
                            <ItemStyle HorizontalAlign="Right" Width="10%" />
                            <ItemTemplate>
                                <asp:Label ID="CDR" runat="server" CssClass="Right" Font-Bold="true" ForeColor="#ff3300">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "CDR"),0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="MO REPORT">
                            <ItemStyle Width="10%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="MO_Rpt" runat="server" CssClass="label" Font-Bold="true" ForeColor="#0033cc">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "MO_Rpt"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="MT REPORT">
                            <ItemStyle Width="10%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="MT_Rpt" runat="server" CssClass="label" Font-Bold="true" ForeColor="#006600">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "MT_Rpt"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="CDR REPORT">
                            <ItemStyle HorizontalAlign="Right" Width="10%" />
                            <ItemTemplate>
                                <asp:Label ID="CDR_Rpt" runat="server" CssClass="Right" Font-Bold="true" ForeColor="#ff3300">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "CDR_Rpt"), 0)%></asp:Label>
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
