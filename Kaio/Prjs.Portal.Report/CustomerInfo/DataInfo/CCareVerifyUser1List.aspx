<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CCareVerifyUser1List.aspx.vb" Inherits="Prjs.Portal.Report.CCareVerifyUser1List" %>
<%@ Register Assembly="ASPnetPagerV2_8" Namespace="ASPnetControls" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../../Styles/HQ.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/LightStyle.css" rel="stylesheet" type="text/css" />
    <title>Untitled Page</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
.RadPicker{vertical-align:middle}.RadPicker{vertical-align:middle}.RadPicker{vertical-align:middle}.RadPicker .rcTable{table-layout:auto}.RadPicker .rcTable{table-layout:auto}.RadPicker .rcTable{table-layout:auto}.RadPicker .RadInput{vertical-align:baseline}.RadPicker .RadInput{vertical-align:baseline}.RadPicker .RadInput{vertical-align:baseline}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle;width:160px}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle;width:160px}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle;width:160px}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle;width:160px}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle;width:160px}
        .auto-style2 {
            width: 100%;
            border-style: none;
            border-color: inherit;
            border-width: 0;
            margin: 0;
            padding: 0;
        }
        .auto-style3 {
            width: 100%;
            vertical-align: middle;
        }
    </style>
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
                                        <asp:Label ID="Label1" runat="server" CssClass="label">Mạng:</asp:Label>
                                    </td>
                                    <td align="left">
                                <asp:DropDownList ID="DropDownListMOBILE_OPERATOR" runat="server" CssClass="droplist">
                                    <asp:ListItem Value="--all--">--all--</asp:ListItem>
                                    <asp:ListItem>VIETTEL</asp:ListItem>
                                    <asp:ListItem>VMS</asp:ListItem>
                                    <asp:ListItem>VNM</asp:ListItem>
                                    <asp:ListItem>VNP</asp:ListItem>
                                </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label4" runat="server" CssClass="label">Thời gian cập nhật:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <table cellpadding="0" cellspacing="0" class="auto-style1">
                                            <tr>
                                                <td width="150">
                                    <telerik:RadDatePicker ID="RadFromDate" rMinDate="2006/01/01" runat="server"
                                        ZIndex="30001" Culture="vi-VN" Skin="Forest">
                                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"
                                            Skin="Forest">
                                        </Calendar>

                                        <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

                                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                    </telerik:RadDatePicker>
                                                </td>
                                                <td width="50">
                                        <asp:Label ID="Label5" runat="server" CssClass="label">đến</asp:Label>
                                                </td>
                                                <td>
                                    <telerik:RadDatePicker ID="RadToDate" rMinDate="2006/01/01" runat="server"
                                        ZIndex="30001" Culture="vi-VN" Skin="Forest">
                                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"
                                            Skin="Forest">
                                        </Calendar>

                                        <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

                                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                    </telerik:RadDatePicker>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label6" runat="server" CssClass="label">Nhóm khách hàng:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtGroup_Text" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                            Width="50%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label7" runat="server" CssClass="label">Từ khóa:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtKey_Word" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                            Width="50%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="Label3" runat="server" CssClass="label">Số điện thoại:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtUser_Id" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                            Width="30%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        &nbsp;</td>
                                    <td align="left">
                <asp:Button ID="btnSearch" runat="server" CssClass="btnbackground" Font-Bold="False"
                    Text="Tìm kiếm" />
                <asp:Button ID="btnExport" runat="server" CssClass="btnbackground" Font-Bold="False"
                    Text="Báo cáo" />
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
                        <asp:TemplateColumn HeaderText="ĐIỆN THOẠI">
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblUSER_ID" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "USER_ID")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                              <asp:TemplateColumn HeaderText="MẠNG">
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblMOBILE_OPERATOR" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "MOBILE_OPERATOR")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="MÃ KHÁCH HÀNG">
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblPARTNER_TEXT" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "CUSTOMER_CODE")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="HỌ TÊN">
                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                            <ItemTemplate>
                                <asp:Label ID="lblCUSTOMER_NAME" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "CUSTOMER_NAME")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                              <asp:TemplateColumn HeaderText="TỈNH THÀNH">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <asp:Label ID="lblPROVINCE_TEXT" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "PROVINCE_TEXT")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="ĐỘ CHÍNH XÁC">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <asp:Label ID="lblEXACTLY_RATE" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "EXACTLY_RATE")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                      
                        <asp:TemplateColumn HeaderText="CẬP NHẬT">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                
                                <asp:Label ID="lblUPDATE_TIME" runat="server" CssClass="label"><%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "UPDATE_TIME")).ToString("dd-MM-yyyy")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                          <asp:TemplateColumn HeaderText="GHI CHÚ">
                            <ItemStyle HorizontalAlign="Left" Width="20%" />
                            <ItemTemplate>
                                <asp:Label ID="lblREMARK" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "REMARK")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn>
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderTemplate>
                                GỌI
                            </HeaderTemplate>
                            <ItemTemplate>
                                <a class="datagridLinks" title="Gọi điện xác minh" href='CCareVerifyUser2.aspx?objid=<%# Utils.EncryptText(DataBinder.Eval(Container.DataItem, "ID")) %>'>
                                    <img border="0" src="/images/music-icon.png">
                                </a>
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