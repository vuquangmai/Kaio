<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CCareVerifyUser2.aspx.vb" Inherits="Prjs.Portal.Report.CCareVerifyUser2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../../Styles/HQ.css" rel="stylesheet" type="text/css" />
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

        .auto-style2
        {
            width: 100%;
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
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="txtUSER_ID">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="txtUSER_ID" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListMOBILE_OPERATOR" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="DropDownListPARTNER_ID">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="DropDownListBRAND_NAME" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="DropDownListSTATUS_ID">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="CheckBoxMove" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="DropDownListPROVINCE_ID">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="DropDownListDISTRICT_ID" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <div id="HQ">
            <div class="alert">
                <asp:Label ID="lbltitle" runat="server" CssClass="lbltitle"></asp:Label><br />
                <asp:Label ID="lblerror" runat="server" CssClass="lblerror"></asp:Label>
            </div>
            <div class="input" style="border-width: 0px; width: 99%; background-color: #FFFFFF;">
                <fieldset id="fieldsetBound">
                    <legend>
                        <asp:Label ID="Label1" runat="server" CssClass="lblerror">Thông tin khách hàng</asp:Label></legend>
                    <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                        <tr>
                            <td align="right" width="15%">
                                <asp:Label ID="Label26" runat="server" CssClass="label">Số điện thoại:</asp:Label>
                            </td>
                            <td align="left" width="35%">
                                <asp:TextBox ID="txtUSER_ID" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="50%" Font-Bold="True" ForeColor="#0033CC" AutoPostBack="True"></asp:TextBox>
                            </td>
                            <td width="15%" align="right">
                                <asp:Label ID="Label36" runat="server" CssClass="label">Mã khách hàng:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtCUSTOMER_CODE" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="20%" Font-Bold="False" ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                <asp:Label ID="Label29" runat="server" CssClass="label">Nội dung MT:</asp:Label>
                            </td>
                            <td align="left" width="35%">
                                <asp:TextBox ID="txtMT" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="100%" Font-Bold="False" Height="58px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td width="15%" align="right">
                                <asp:Label ID="Label30" runat="server" CssClass="label">Họ tên:</asp:Label>
                            </td>
                            <td align="left">

                                <asp:TextBox ID="txtCUSTOMER_NAME" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="80%" Font-Bold="False"></asp:TextBox>

                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                <asp:Label ID="Label6" runat="server" CssClass="label">Đối tác:</asp:Label>
                            </td>
                            <td align="left" width="35%">
                                <asp:DropDownList ID="DropDownListPARTNER_ID" runat="server" CssClass="droplist" Font-Bold="True" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                            <td width="15%" align="right">
                                <asp:Label ID="Label16" runat="server" CssClass="label">Ngày sinh:</asp:Label>
                            </td>
                            <td align="left">

                                <table cellpadding="0" cellspacing="1" class="auto-style2">
                                    <tr>
                                        <td width="10%">
                                            <asp:DropDownList ID="DropDownListDAY" runat="server" CssClass="droplist">
                                            </asp:DropDownList>
                                        </td>
                                        <td width="10%">
                                            <asp:DropDownList ID="DropDownListMONTH" runat="server" CssClass="droplist">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListYEAR" runat="server" CssClass="droplist">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="auto-style3">
                                <asp:Label ID="Label3" runat="server" CssClass="label">Brand name:</asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                <asp:DropDownList ID="DropDownListBRAND_NAME" runat="server" CssClass="droplist" AutoPostBack="True">
                                    <asp:ListItem Value="0">--Chọn--</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="right" class="auto-style3">
                                <asp:Label ID="Label31" runat="server" CssClass="label">Địa chỉ:</asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                <asp:TextBox ID="txtADDRESS" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="100%" Font-Bold="False"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td align="right" class="auto-style3">
                                <asp:Label ID="Label5" runat="server" CssClass="label">Tỉnh/Thành:</asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                <table class="auto-style2">
                                    <tr>
                                        <td>
                                <asp:DropDownList ID="DropDownListPROVINCE_ID" runat="server" CssClass="droplist" AutoPostBack="True">
                                </asp:DropDownList>
                                        </td>
                                        <td>
                                <asp:Label ID="Label46" runat="server" CssClass="label">Quận/Huyện:</asp:Label>
                                        </td>
                                        <td>
                                <asp:DropDownList ID="DropDownListDISTRICT_ID" runat="server" CssClass="droplist">
                                    <asp:ListItem Value="0">--Chọn--</asp:ListItem>
                                </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td align="right" class="auto-style3">
                                <asp:Label ID="Label32" runat="server" CssClass="label">Email:</asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                <asp:TextBox ID="txtEMAIL_ADDRESS" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="50%" Font-Bold="False"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td align="right" class="auto-style3">
                                <asp:Label ID="Label8" runat="server" CssClass="label">Giới tính:</asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                <asp:DropDownList ID="DropDownListSEX" runat="server" CssClass="droplist">
                                    <asp:ListItem Value="0">--Chọn--</asp:ListItem>
                                    <asp:ListItem Value="1">Nam</asp:ListItem>
                                    <asp:ListItem Value="2">Nữ</asp:ListItem>
                                    <asp:ListItem Value="3">Chưa xác định</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="right" class="auto-style3">
                                <asp:Label ID="Label33" runat="server" CssClass="label">Mức cước:</asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                <asp:DropDownList ID="DropDownListFEES_ID" runat="server" CssClass="droplist" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td align="right" class="auto-style3">
                                <asp:Label ID="Label7" runat="server" CssClass="label">Ngành hàng:</asp:Label>
                            </td>
                            <td align="left" class="auto-style3">

                                <asp:CheckBoxList ID="CheckBoxListFIELD_ID" runat="server" CssClass="checkbox" RepeatColumns="3">
                                </asp:CheckBoxList>

                            </td>
                            <td align="right" class="auto-style3">
                                <asp:Label ID="Label34" runat="server" CssClass="label">Mức thu nhập:</asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                <asp:DropDownList ID="DropDownListINCOME_ID" runat="server" CssClass="droplist" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td align="right" class="auto-style3">
                                <asp:Label ID="Label27" runat="server" CssClass="label">Nguồn dữ liệu:</asp:Label>
                            </td>
                            <td align="left" class="auto-style3">

                                <asp:DropDownList ID="DropDownListSOURCE_ID" runat="server" CssClass="droplist" AutoPostBack="True">
                                </asp:DropDownList>

                            </td>
                            <td align="right" class="auto-style3">
                                <asp:Label ID="Label37" runat="server" CssClass="label">Mạng:</asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                <asp:DropDownList ID="DropDownListMOBILE_OPERATOR" runat="server" CssClass="droplist">
                                    <asp:ListItem Value="--Chọn--">--Chọn--</asp:ListItem>
                                    <asp:ListItem>VIETTEL</asp:ListItem>
                                    <asp:ListItem>VMS</asp:ListItem>
                                    <asp:ListItem>VNM</asp:ListItem>
                                    <asp:ListItem>VNP</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td align="right" class="auto-style3">
                                <asp:Label ID="Label4" runat="server" CssClass="label">Từ khóa:</asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                <asp:TextBox ID="txtKEY_WORD" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="50%" Font-Bold="True"></asp:TextBox>
                            </td>
                            <td align="right" class="auto-style3">
                                <asp:Label ID="Label35" runat="server" CssClass="label">Độ chính xác:</asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                <asp:DropDownList ID="DropDownListEXACTLY_RATE" runat="server" CssClass="droplist">
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td align="right" class="auto-style3">
                                <asp:Label ID="Label43" runat="server" CssClass="label">Nhóm khách hàng:</asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                <asp:TextBox ID="txtGROUP_TEXT" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="50%" Font-Bold="True"></asp:TextBox>
                            </td>
                            <td align="right" class="auto-style3">
                                <asp:Label ID="Label44" runat="server" CssClass="label">Trạng thái:</asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                <asp:DropDownList ID="DropDownListSTATUS_ID" runat="server" CssClass="droplist" AutoPostBack="True">
                                    <asp:ListItem Value="0">--Chọn--</asp:ListItem>
                                    <asp:ListItem Value="1">New</asp:ListItem>
                                    <asp:ListItem Value="2">Call</asp:ListItem>
                                    <asp:ListItem Value="3">Invalid</asp:ListItem>
                                    <asp:ListItem Value="4">Done</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td align="right" class="auto-style3">
                                <asp:Label ID="Label28" runat="server" CssClass="label">Ghi chú:</asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                <asp:TextBox ID="txtREMARK" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="100%" Font-Bold="False" TextMode="MultiLine" Height="48px"></asp:TextBox>
                            </td>
                            <td align="right" class="auto-style3">
                                <asp:Label ID="Label45" runat="server" CssClass="label">Tùy chọn:</asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                <table cellpadding="0" cellspacing="0" class="auto-style2">
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="CheckBoxMove" runat="server" CssClass="checkbox" Text="Chuyển sang bảng chính thức" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="CheckBoxDel" runat="server" CssClass="checkbox" Text="Xóa bảng gọi" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="CheckBoxDelTheSame" runat="server" CssClass="checkbox" Text="Xóa số liên quan" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>

                    </table>
                </fieldset>

                <div class="submmit">
                    <asp:Button ID="btnUpdate" runat="server" CssClass="btnbackground"
                        Text="Ghi lại" />
                    <asp:Button ID="btnDelete" runat="server" CssClass="btnbackground"
                        Text="Xóa bỏ" />
                    <asp:Button ID="btnReturn" runat="server" CssClass="btnbackground"
                        Text="Quay ra" />
                </div>
            </div>
            <div class="input" style="border-width: 0px; width: 99%; background-color: #FFFFFF;">
                <fieldset id="fieldset1">
                    <legend>
                        <asp:Label ID="Label2" runat="server" CssClass="lblerror">Bản ghi liên quan trong bảng chính thức</asp:Label></legend>
                    <div class="datagrid">
                        <asp:DataGrid ID="DataGrid_1" runat="server" AllowPaging="True" AutoGenerateColumns="false"
                            CellPadding="0" CssClass="datagrid" EnableViewState="False" GridLines="None"
                            PagerStyle-Mode="NextPrev" PagerStyle-Visible="true" Width="100%" PageSize="3">
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
                </fieldset>
                <fieldset id="fieldset2">
                    <legend>
                        <asp:Label ID="Label9" runat="server" CssClass="lblerror">Bản ghi liên quan trong bảng gọi </asp:Label></legend>
                    <div class="datagrid">
                        <asp:DataGrid ID="DataGrid_2" runat="server" AllowPaging="True" AutoGenerateColumns="false"
                            CellPadding="0" CssClass="datagrid" EnableViewState="False" GridLines="None"
                            PagerStyle-Mode="NextPrev" PagerStyle-Visible="true" Width="100%" PageSize="5">
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
                                        <asp:Label ID="lblOrder_2" runat="server" CssClass="label"
                                            Text='<%# Container.ItemIndex+1 %>'>
                                        </asp:Label>
                                    </ItemTemplate>

                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="ĐIỆN THOẠI">
                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblUSER_ID_2" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "USER_ID")%></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="MẠNG">
                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblMOBILE_OPERATOR_2" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "MOBILE_OPERATOR")%></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="MÃ KHÁCH HÀNG">
                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblPARTNER_TEXT_2" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "CUSTOMER_CODE")%></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="HỌ TÊN">
                                    <ItemStyle HorizontalAlign="Center" Width="15%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCUSTOMER_NAME_2" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "CUSTOMER_NAME")%></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="TỈNH THÀNH">
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblPROVINCE_TEXT_2" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "PROVINCE_TEXT")%></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="ĐỘ CHÍNH XÁC">
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblEXACTLY_RATE_2" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "EXACTLY_RATE")%></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>

                                <asp:TemplateColumn HeaderText="CẬP NHẬT">
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    <ItemTemplate>

                                        <asp:Label ID="lblUPDATE_TIME_2" runat="server" CssClass="label"><%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "UPDATE_TIME")).ToString("dd-MM-yyyy")%></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="GHI CHÚ">
                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblREMARK_2" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "REMARK")%></asp:Label>
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
                </fieldset>
            </div>
            <div class="input" style="border-width: 0px; width: 99%; background-color: #FFFFFF;">
          

            <fieldset id="fieldset4">
                <legend>
                    <asp:Label ID="Label11" runat="server" CssClass="lblerror">Bản ghi liên quan trong bảng import </asp:Label></legend>
                <div class="datagrid">
                    <asp:DataGrid ID="DataGrid_3" runat="server" AllowPaging="True" AutoGenerateColumns="false"
                        CellPadding="0" CssClass="datagrid" EnableViewState="False" GridLines="None"
                        PagerStyle-Mode="NextPrev" PagerStyle-Visible="true" Width="100%">
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
                                    <asp:Label ID="lblOrder_3" runat="server" CssClass="label"
                                        Text='<%# Container.ItemIndex+1 %>'>
                                    </asp:Label>
                                </ItemTemplate>

                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="ĐIỆN THOẠI">
                                <ItemStyle Width="10%" HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUSER_ID_3" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "USER_ID")%></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="MẠNG">
                                <ItemStyle Width="10%" HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblMOBILE_OPERATOR_3" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "MOBILE_OPERATOR")%></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="MÃ KHÁCH HÀNG">
                                <ItemStyle Width="10%" HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPARTNER_TEXT_3" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "CUSTOMER_CODE")%></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="HỌ TÊN">
                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCUSTOMER_NAME_3" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "CUSTOMER_NAME")%></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="TỈNH THÀNH">
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPROVINCE_TEXT_3" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "PROVINCE_TEXT")%></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="ĐỘ CHÍNH XÁC">
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                <ItemTemplate>
                                    <asp:Label ID="lblEXACTLY_RATE_3" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "EXACTLY_RATE")%></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>

                            <asp:TemplateColumn HeaderText="CẬP NHẬT">
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                <ItemTemplate>

                                    <asp:Label ID="lblUPDATE_TIME_3" runat="server" CssClass="label"><%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "UPDATE_TIME")).ToString("dd-MM-yyyy")%></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="GHI CHÚ">
                                <ItemStyle HorizontalAlign="Left" Width="20%" />
                                <ItemTemplate>
                                    <asp:Label ID="lblREMARK_3" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "REMARK")%></asp:Label>
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
            </fieldset>

              </div>
        </div>

    </form>
</body>
</html>
