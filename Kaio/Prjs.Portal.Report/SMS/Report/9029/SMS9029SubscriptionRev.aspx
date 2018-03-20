<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SMS9029SubscriptionRev.aspx.vb" Inherits="Prjs.Portal.Report.SMS9029SubscriptionRev" %>

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
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="DropDownListMonth">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="DropDownListFromDate" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListToDate" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <div id="HQ">
            <div class="alert">
                <asp:Label ID="lblTitle" runat="server" CssClass="lbltitle"></asp:Label><br />
                <asp:Label ID="lblerror" runat="server" CssClass="lblerror"></asp:Label>
            </div>
            <div class="parametter">
                <table width="100%">
                    <tr>
                        <td align="right" width="20%">
                            <asp:Label ID="lblTrang7" runat="server" CssClass="label">Năm:</asp:Label>
                        </td>
                        <td align="left" width="30%">
                            <asp:DropDownList ID="DropDownListYear" runat="server" CssClass="droplist">
                                <asp:ListItem>2009</asp:ListItem>
                                <asp:ListItem>2010</asp:ListItem>
                                <asp:ListItem>2011</asp:ListItem>
                                <asp:ListItem>2012</asp:ListItem>
                                <asp:ListItem>2013</asp:ListItem>
                                <asp:ListItem>2014</asp:ListItem>
                                <asp:ListItem>2015</asp:ListItem>
                                <asp:ListItem>2016</asp:ListItem>
                                <asp:ListItem>2017</asp:ListItem>
                                <asp:ListItem>2018</asp:ListItem>
                                <asp:ListItem>2019</asp:ListItem>
                                <asp:ListItem>2020</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="right" width="20%">
                            <asp:CheckBox ID="CheckBoxPartnerId" runat="server"
                                CssClass="checkbox" Text="Đối tác:"
                                TextAlign="Left" />
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListPartnerId" runat="server" CssClass="droplist">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="15%">
                            <asp:Label ID="lblTrang8" runat="server" CssClass="label">Tháng:</asp:Label>
                        </td>
                        <td align="left" width="35%">
                            <asp:DropDownList ID="DropDownListMonth" runat="server" CssClass="droplist" AutoPostBack="True">
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem>8</asp:ListItem>
                                <asp:ListItem>9</asp:ListItem>
                                <asp:ListItem>10</asp:ListItem>
                                <asp:ListItem>11</asp:ListItem>
                                <asp:ListItem>12</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="right" width="15%">
                            <asp:CheckBox ID="CheckBoxChannel" runat="server" CssClass="checkbox" Text="Kênh:"
                                TextAlign="Left" />
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListChannel" runat="server" CssClass="droplist">
                                <asp:ListItem>--all--</asp:ListItem>
                                <asp:ListItem>SMS</asp:ListItem>
                                <asp:ListItem>WAP</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblTrang9" runat="server" CssClass="label">Từ ngày:</asp:Label>
                        </td>
                        <td align="left">

                            <table cellpadding="0" cellspacing="0" class="style1">
                                <tr>
                                    <td width="20px">
                                        <asp:DropDownList ID="DropDownListFromDate" runat="server" CssClass="droplist">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="center" width="20px">
                                        <asp:Label ID="lblTrang10" runat="server" CssClass="label">đến:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DropDownListToDate" runat="server" CssClass="droplist">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="right">
                            <asp:CheckBox ID="CheckBoxTypeOf" runat="server" CssClass="checkbox" Text="Thể loại:"
                                TextAlign="Left" />
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListTypeOf" runat="server" CssClass="droplist">
                                <asp:ListItem>--all--</asp:ListItem>
                                <asp:ListItem Value="1">Đăng ký</asp:ListItem>
                                <asp:ListItem Value="2">Hủy</asp:ListItem>
                                <asp:ListItem Value="3">Gia hạn</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">&nbsp;
                        </td>
                        <td align="char">

                            <asp:CheckBox ID="CheckBoxAllDate" runat="server" CssClass="checkbox"
                                Text="Toàn thời gian" />

                        </td>
                        <td align="right">
                            <asp:CheckBox ID="CheckBoxPrice" runat="server" CssClass="checkbox" Text="Đơn giá:"
                                TextAlign="Left" />
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txChargedFee" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="50%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblTrang12" runat="server" CssClass="label">Trạng thái:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListStatus" runat="server" CssClass="droplist">
                                <asp:ListItem Value="1">Thành công</asp:ListItem>
                                <asp:ListItem Value="0">Lỗi</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            <asp:CheckBox ID="CheckBoxKeyword" runat="server" CssClass="checkbox" Text="Mã:"
                                TextAlign="Left" />
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtDetail" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="50%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">&nbsp;</td>
                        <td align="left">&nbsp;</td>
                        <td align="right">
                            <asp:CheckBox ID="CheckBoxMonth" runat="server" CssClass="checkbox" Text="Tháng:"
                                TextAlign="Left" />
                        </td>
                        <td align="left">
                            <asp:CheckBox ID="CheckBoxDate" runat="server" CssClass="checkbox" Text="Ngày:" TextAlign="Left" />
                            <asp:CheckBox ID="CheckBoxHour" runat="server" CssClass="checkbox" Text="Giờ:" TextAlign="Left" />
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
                <div class="submmit">
                  <fieldset id="fieldset2" class="fieldset_data_info">

                    <table width="200px">
                        <tr>
                            <td width="50%" align="left">

                                <asp:Label ID="Label4" runat="server" CssClass="label">Tổng số CDR:</asp:Label>
                            </td>
                            <td width="50%" align="right">
                                <asp:Label ID="lblTotalCDR" runat="server" CssClass="label" Font-Bold="True"
                                    ForeColor="Blue"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">

                                <asp:Label ID="Label8" runat="server" CssClass="label">Doanh thu tổng:</asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="lblTotalMoney" runat="server" CssClass="label" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </div>
            
            <div class="pager">
                <cc1:PagerV2_8 ID="pager1" runat="server" OnCommand="pager_Command" GenerateGoToSection="true"
                    Font-Size="10pt" PageSize="50" />

            </div>
            <div class="datagrid">
                <asp:DataGrid ID="DataGrid" runat="server" AutoGenerateColumns="false" CellPadding="0"
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
                        <asp:TemplateColumn HeaderText="NĂM">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "vYear")%>
                            </ItemTemplate>
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="THÁNG">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "vMonth")%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="NGÀY">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "vDay")%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="GIỜ">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "vHour")%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="THỂ LOẠI">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "TypeOf")%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="MÃ">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Detail")%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="KÊNH">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Channel")%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="ĐƠN GIÁ">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "ChargedFee")%>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="CDR">
                            <ItemTemplate>
                                <asp:Label ID="TotalCDR" runat="server" Font-Bold="True">         <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "TotalCDR"), 0)%></asp:Label>

                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="TỔNG">
                            <ItemTemplate>
                                <asp:Label ID="TotalMoney" runat="server" Font-Bold="True">         <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "TotalMoney"), 0)%></asp:Label>

                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="5%" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="VMG">
                            <ItemTemplate>
                                <asp:Label ID="vMoneyVMG" runat="server" Font-Bold="True">         <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "vMoneyVMG"), 0)%></asp:Label>

                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="5%" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="VIETTEL">
                            <ItemTemplate>
                                <asp:Label ID="vMoneyViettel" runat="server" Font-Bold="True" ForeColor="Red">         <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "vMoneyViettel"), 0)%></asp:Label>

                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" Width="5%" />
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="ĐỐI TÁC">
                            <ItemTemplate>
                                <asp:Label ID="lblPartnerName" runat="server">         <%# DataBinder.Eval(Container.DataItem, "PartnerName")%></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="8%" />
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
