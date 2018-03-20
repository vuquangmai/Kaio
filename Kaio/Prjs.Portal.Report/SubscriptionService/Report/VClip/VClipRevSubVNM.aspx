<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="VClipRevSubVNM.aspx.vb" Inherits="Prjs.Portal.Report.VClipRevSubVNM" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="ASPnetPagerV2_8" Namespace="ASPnetControls" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
   <link href="../../../Styles/HQ.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/LightStyle.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/RadTreeView.css" type="text/css" rel="stylesheet" />

    <script language="javascript" type="text/javascript" src="../../../../Js/Menu3.js"></script>

    <style type="text/css">
        fieldset {
            display: block;
            border: 1px solid #BCDDAF;
            -moz-border-radius: 8px;
            -webkit-border-radius: 8px;
            border-radius: 8px;
        }

        legend {
            background: #377F44;
            border: solid 1px green;
            -webkit-border-radius: 8px;
            -moz-border-radius: 8px;
            border-radius: 8px;
        }

        
    </style>
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
                <asp:Label ID="lbltitle" runat="server" CssClass="lbltitle"></asp:Label><br />
                <asp:Label ID="lblerror" runat="server" CssClass="lblerror"></asp:Label>
            </div>


            <div class="input">
                <table width="100%">
                    <tr>
                        <td align="right" width="15%">
                            <asp:Label ID="lblTrang7" runat="server" CssClass="label">Từ ngày:</asp:Label>
                            &nbsp;
                        </td>
                        <td align="left" width="35%">
                            <telerik:RadDatePicker ID="RadFromDate" rMinDate="2006/01/01" runat="server"
                                ZIndex="30001" Culture="vi-VN" Skin="Forest">
                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"
                                    Skin="Forest">
                                </Calendar>

                                <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                            </telerik:RadDatePicker>
                        </td>
                        <td align="right" width="15%">
                            <asp:CheckBox ID="CheckBoxOperator" runat="server" CssClass="checkbox" Text="Mạng:"
                                TextAlign="Left" />
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListOperator" runat="server" CssClass="droplist">
                                <asp:ListItem>--all--</asp:ListItem>
                                <asp:ListItem>VNMOBILE</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="15%">
                            <asp:Label ID="lblTrang8" runat="server" CssClass="label">Đến ngày:</asp:Label>
                        </td>
                        <td align="left" width="35%">
                            <telerik:RadDatePicker ID="RadToDate" rMinDate="2006/01/01" runat="server"
                                ZIndex="30001" Culture="vi-VN" Skin="Forest">
                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"
                                    Skin="Forest">
                                </Calendar>

                                <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                            </telerik:RadDatePicker>
                        </td>
                        <td align="right" width="15%">
                            <asp:CheckBox ID="CheckBoxShortCode" runat="server" CssClass="checkbox" Text="Đầu số:"
                                TextAlign="Left" />
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListShortCode" runat="server" CssClass="droplist">
                                <asp:ListItem Value="--all--">--all--</asp:ListItem>
                                <asp:ListItem>949</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="15%">&nbsp;</td>
                        <td align="left" width="35%">

                            <asp:CheckBox ID="CheckBoxAllDate" runat="server" CssClass="checkbox" Text="Toàn thời gian" />

                        </td>
                        <td align="right" width="15%">
                            <asp:CheckBox ID="CheckBoxChannel" runat="server" CssClass="checkbox" Text="Kênh:"
                                TextAlign="Left" />
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListChannel" runat="server" CssClass="droplist">
                                <asp:ListItem Value="--all--">--all--</asp:ListItem>
                                <asp:ListItem>SMS</asp:ListItem>
                                <asp:ListItem>WAP</asp:ListItem>
                                <asp:ListItem>SUB</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">

                            <asp:Label ID="lblTrang11" runat="server" CssClass="label">Trạng thái:</asp:Label>
                        </td>
                        <td align="left">

                            <asp:DropDownList ID="DropDownListStatus" runat="server"
                                CssClass="droplist" AutoPostBack="True">
                                <asp:ListItem Value="1">Thành công</asp:ListItem>
                                <asp:ListItem Value="0">Lỗi</asp:ListItem>
                            </asp:DropDownList>

                        </td>
                        <td align="right">
                            <asp:CheckBox ID="CheckBoxPrice" runat="server" CssClass="checkbox" Text="Giá:"
                                TextAlign="Left" />
                        </td>
                        <td align="left">&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="right">

                            <asp:CheckBox ID="CheckBoxKeyword" runat="server" CssClass="checkbox" Text="Mã:"
                                TextAlign="Left" />
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtKeyword" runat="server" CssClass="txtContent" Width="60%"></asp:TextBox>
                        </td>
                        <td align="right">
                            <asp:CheckBox ID="CheckBoxMonth" runat="server" CssClass="checkbox" Text="Tháng:"
                                TextAlign="Left" />
                        </td>
                        <td align="left">&nbsp;
                                    </td>
                    </tr>
                    <tr>
                        <td align="right">

                            <asp:CheckBox ID="CheckBoxUser_Id" runat="server" CssClass="checkbox" Text="Số điện thoại:"
                                TextAlign="Left" />
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtUser_Id" runat="server" CssClass="txtContent" Width="60%"></asp:TextBox>
                        </td>
                        <td align="right">
                                    <asp:CheckBox ID="CheckBoxDate" runat="server" CssClass="checkbox" Text="Ngày:"
                                        TextAlign="Left" />
                        </td>
                        <td align="left">
                            <asp:CheckBox ID="CheckBoxHour" runat="server" CssClass="checkbox" Text="Giờ:"
                                TextAlign="Left" />
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


            <div class="submmit">

                <table style="width: 100%; border-collapse: collapse">
                    <tr>
                        <td>
                            <fieldset id="fieldset2">

                                <table width="100%">
                                    <tr>
                                        <td width="30%" align="right">
                                            <asp:Label ID="lblMO" runat="server" CssClass="label_parametter" Font-Italic="False">Doanh thu VMG (1):</asp:Label>
                                        </td>
                                        <td align="right" width="20%">
                                            <asp:Label ID="lblMoney_VMG_Telcos" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td align="right" width="30%">
                                            <asp:Label ID="lblMO5" runat="server" CssClass="label_parametter" Font-Italic="False">Tổng số CDR:</asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblTotalCDR" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True" ForeColor="Blue"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblMO1" runat="server" CssClass="label_parametter" Font-Italic="False">Doanh thu Telcos (2):</asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblMoney_Telcos_VMG" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td align="right">&nbsp;</td>
                                        <td align="right">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="lblMO0" runat="server" CssClass="label_parametter" Font-Italic="False">Khách hàng (3):</asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lblMoney_Ccare" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True"></asp:Label>
                                        </td>
                                        <td align="center">
                                            <asp:Label ID="lblMO14" runat="server" CssClass="label" Font-Italic="True">(1)+(2)=(3)</asp:Label>
                                        </td>
                                        <td align="center">&nbsp;</td>
                                    </tr>
                                </table>
                            </fieldset>

                        </td>


                    </tr>
                </table>
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
                                        <asp:TemplateColumn HeaderText="NĂM">
                                            <ItemTemplate>
                                                <%#DataBinder.Eval(Container.DataItem, "vyear")%>
                                            </ItemTemplate>
                                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="THÁNG">
                                            <ItemTemplate>
                                                <%#DataBinder.Eval(Container.DataItem, "month")%>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="NGÀY">
                                            <ItemTemplate>
                                                <%#DataBinder.Eval(Container.DataItem, "day")%>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="GIỜ">
                                            <ItemTemplate>
                                                <%#DataBinder.Eval(Container.DataItem, "hour")%>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="MÃ DỊCH VỤ">
                                            <ItemTemplate>
                                                <%#DataBinder.Eval(Container.DataItem, "command_code")%>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="ĐẦU SỐ">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "Service_ID")%>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="KÊNH">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "Registration_Channel")%>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="KHÁCH HÀNG">
                                            <ItemTemplate>
                                                <%# DataBinder.Eval(Container.DataItem, "User_ID")%>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        </asp:TemplateColumn>
                                          <asp:TemplateColumn HeaderText="TỔNG SỐ">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltotalCDR" runat="server" Font-Bold="true"  >         <%#Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "total"), 0)%></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" Width="10%" />
                                        </asp:TemplateColumn>
                                             <asp:TemplateColumn HeaderText="VMG">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltotalMoneyVMG" runat="server" Font-Bold="true" ForeColor="Blue">         <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "vVMG"), 0)%></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" Width="10%" />
                                        </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="GIÁ">
                                            <ItemTemplate>
                                                <asp:Label ID="Price" runat="server" Font-Bold="true" ForeColor="Blue">         <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "Price"), 0)%></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" Width="10%" />
                                        </asp:TemplateColumn>
                                             <asp:TemplateColumn HeaderText="VNM">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltotalMoneyVNM" runat="server" Font-Bold="true" ForeColor="red">         <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "vVNM"), 0)%></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" Width="10%" />
                                        </asp:TemplateColumn>
                                      
                                        <asp:TemplateColumn HeaderText="TỔNG">
                                            <ItemTemplate>
                                                <asp:Label ID="lblvMoney" runat="server" Font-Bold="true"  >         <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "vMoney"), 0)%></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" Width="10%" />
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
