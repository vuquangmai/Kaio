<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CCareVerifyUser1.aspx.vb" Inherits="Prjs.Portal.Report.CCareVerifyUser1" %>

<%@ Register Assembly="FilePickerControl" Namespace="AWS.FilePicker" TagPrefix="cc2" %>
<%@ Register Assembly="ASPnetPagerV2_8" Namespace="ASPnetControls" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../../Styles/HQ.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/LightStyle.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../../Js/Menu.js"></script>
    <script type="text/javascript">
        function IsDetail(CustomerId) {
            window.open("CCareCustomerInfo.aspx?type=import&objid=" + CustomerId, "b2c_detail", "location=no,directories=no,left=0,top=0,height=600,width=900,status=no,scrollbars=yes,toolbars=no,menubar=no,resizable=yes");
        }

           </script>
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

        .fieldset1
        {
            background: #FFFFFF;
            display: block;
            border: 1px solid #fab26a;
            -moz-border-radius: 8px;
            -webkit-border-radius: 8px;
            border-radius: 8px;
            margin-bottom: 3px;
        }

        .legend1
        {
            background: #FF9;
            border: solid 1px #fab26a;
            -webkit-border-radius: 8px;
            -moz-border-radius: 8px;
            border-radius: 8px;
            font-style: normal;
            font-weight: bold;
            color: #000000;
        }


        .RadPicker
        {
            vertical-align: middle;
        }

        .RadPicker
        {
            vertical-align: middle;
        }

        .RadPicker
        {
            vertical-align: middle;
        }

            .RadPicker .rcTable
            {
                table-layout: auto;
            }

            .RadPicker .rcTable
            {
                table-layout: auto;
            }

            .RadPicker .rcTable
            {
                table-layout: auto;
            }

            .RadPicker .RadInput
            {
                vertical-align: baseline;
            }

            .RadPicker .RadInput
            {
                vertical-align: baseline;
            }

            .RadPicker .RadInput
            {
                vertical-align: baseline;
            }

        .RadInput_Default
        {
            font: 12px "segoe ui",arial,sans-serif;
        }

        .RadInput
        {
            vertical-align: middle;
            width: 160px;
        }

        .RadInput_Default
        {
            font: 12px "segoe ui",arial,sans-serif;
        }

        .RadInput
        {
            vertical-align: middle;
            width: 160px;
        }

        .RadInput_Default
        {
            font: 12px "segoe ui",arial,sans-serif;
        }

        .RadInput
        {
            vertical-align: middle;
            width: 160px;
        }

        .RadInput_Default
        {
            font: 12px "segoe ui",arial,sans-serif;
        }

        .RadInput
        {
            vertical-align: middle;
            width: 160px;
        }

        .RadInput_Default
        {
            font: 12px "segoe ui",arial,sans-serif;
        }

        .RadInput
        {
            vertical-align: middle;
            width: 160px;
        }

        .auto-style1
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
                <telerik:AjaxSetting AjaxControlID="DropDownListPARTNER_ID">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="DropDownListBRAND_NAME" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="DropDownListPROVINCE_ID">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="DropDownListDISTRICT_ID" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="DropDownListPARTNER_ID_Add">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="DropDownListBRAND_NAME_Add" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="DropDownListSTATUS_ID_Add">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="CheckBoxSaveCall" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="DropDownListPROVINCE_ID_Add">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="DropDownListDISTRICT_ID_Add" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <div id="HQ">
            <div class="alert">
                <asp:Label ID="lbltitle" runat="server" CssClass="lbltitle"></asp:Label><br />
                <asp:Label ID="lblerror" runat="server" CssClass="lblerror"></asp:Label>
            </div>
            <div class="input" style="border-width: 0px; width: 99%; background-color: #FFFFFF; text-align: left;" ">
                 <a href="javascript:showSubcat('1');">
                    <img id="imgCat1" src="../../Images/collapse_thead.gif" border="0" alt="" /></a> <a class="cateGrid" href="javascript:showSubcat('1');">
                        <asp:Label ID="Label16" runat="server"  CssClass="label" ForeColor="#666666">Thông tin tìm kiếm</asp:Label>
                    </a>
                   <div id="divCat1"  style="visibility: visible">
                <fieldset id="fieldsetBound" class="fieldset1">
                    <legend class="legend1"></legend>
                        
                    <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                        <tr>
                            <td align="right" width="15%">
                                <asp:Label ID="Label43" runat="server" CssClass="label">Từ ngày:</asp:Label>
                            </td>
                            <td align="left" width="35%">
                                <table cellpadding="0" cellspacing="0" width="100%"  >
                                    <tr>
                                        <td width="120px">
                                    <telerik:RadDatePicker ID="RadFromDate" rMinDate="2006/01/01" runat="server"
                                        ZIndex="30001" Culture="vi-VN" Skin="Forest" Width="125px">
                                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"
                                            Skin="Forest">
                                        </Calendar>

                                        <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

                                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                    </telerik:RadDatePicker>
                                        </td>
                                        <td align="center" width="50px">
                                <asp:Label ID="Label44" runat="server" CssClass="label">đến ngày:</asp:Label>
                                        </td>
                                        <td>
                                    <telerik:RadDatePicker ID="RadToDate" rMinDate="2006/01/01" runat="server"
                                        ZIndex="30001" Culture="vi-VN" Skin="Forest" Width="125px">
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
                            <td width="15%" align="right">
                                <asp:Label ID="Label37" runat="server" CssClass="label">Mạng:</asp:Label>
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
                            <td align="right" width="15%">
                                <asp:Label ID="Label45" runat="server" CssClass="label">Loại thời gian:</asp:Label>
                            </td>
                            <td align="left" width="35%">
                                <asp:DropDownList ID="DropDownListTypeOfTime" runat="server" CssClass="droplist" Font-Bold="False">
                                    <asp:ListItem Value="CREATE_TIME">Khởi tạo</asp:ListItem>
                                    <asp:ListItem Value="UPDATE_TIME">Cập nhật</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td width="15%" align="right">
                                <asp:Label ID="Label26" runat="server" CssClass="label">Số điện thoại:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtUSER_ID" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="50%" Font-Bold="True" ForeColor="#0033CC"></asp:TextBox>
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
                                <asp:Label ID="Label30" runat="server" CssClass="label">Họ tên:</asp:Label>
                            </td>
                            <td align="left">

                                <table cellpadding="0" cellspacing="0" class="auto-style1">
                                    <tr>
                                        <td>

                                <asp:TextBox ID="txtCUSTOMER_NAME" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="80%" Font-Bold="False"></asp:TextBox>

                                        </td>
                                        <td width="20%">
                                            <asp:CheckBox ID="CheckBoxCUSTOMER_NAME" runat="server" CssClass="checkbox" Text="Tương đối" />
                                        </td>
                                    </tr>
                                </table>

                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                <asp:Label ID="Label3" runat="server" CssClass="label">Brand name:</asp:Label>
                            </td>
                            <td align="left" width="35%">
                                <table cellpadding="0"  cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                <asp:DropDownList ID="DropDownListBRAND_NAME" runat="server" CssClass="droplist">
                                    <asp:ListItem Value="0">--all--</asp:ListItem>
                                </asp:DropDownList>
                                        </td>
                                        <td width="20%">
                                            <asp:CheckBox ID="CheckBoxBRAND_NAME" runat="server" CssClass="checkbox" Text="Tương đối" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="15%" align="right">
                                <asp:Label ID="Label8" runat="server" CssClass="label">Giới tính:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DropDownListSEX" runat="server" CssClass="droplist">
                                    <asp:ListItem Value="-1">--all--</asp:ListItem>
                                    <asp:ListItem Value="1">Nam</asp:ListItem>
                                    <asp:ListItem Value="2">Nữ</asp:ListItem>
                                    <asp:ListItem Value="0">Chưa xác định</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                <asp:Label ID="Label29" runat="server" CssClass="label">Nội dung MT:</asp:Label>
                            </td>
                            <td align="left" width="35%">
                               <table cellpadding="0"  cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                <asp:TextBox ID="txtMT" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="98%" Font-Bold="False" Height="58px" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                        <td width="20%">
                                            <asp:CheckBox ID="CheckBoxMT" runat="server" CssClass="checkbox" Text="Tương đối" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="15%" align="right">
                                <asp:Label ID="Label52" runat="server" CssClass="label">Tuổi từ:</asp:Label>
                            </td>
                            <td align="left">
                               <table cellpadding="0"  cellspacing="0" width="100%">
                                    <tr>
                                        <td width="50px">
                                <asp:TextBox ID="txtFromYear" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="50px" Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td align="center" width="10%">
                                <asp:Label ID="Label53" runat="server" CssClass="label">đến</asp:Label>
                                        </td>
                                        <td>
                                <asp:TextBox ID="txtToYear" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="50px" Font-Bold="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                <asp:Label ID="Label4" runat="server" CssClass="label">Từ khóa:</asp:Label>
                            </td>
                            <td align="left" width="35%">
                               <table cellpadding="0"  cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                <asp:TextBox ID="txtKEY_WORD" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="98%" Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td width="20%">
                                            <asp:CheckBox ID="CheckBoxKEY_WORD" runat="server" CssClass="checkbox" Text="Tương đối" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="15%" align="right">
                                <asp:Label ID="Label5" runat="server" CssClass="label">Tỉnh/Thành:</asp:Label>
                            </td>
                            <td align="left">
                                <table class="auto-style1">
                                    <tr>
                                        <td>
                                <asp:DropDownList ID="DropDownListPROVINCE_ID" runat="server" CssClass="droplist" AutoPostBack="True">
                                </asp:DropDownList>
                                        </td>
                                        <td>
                                <asp:Label ID="Label57" runat="server" CssClass="label">Quận/Huyện:</asp:Label>
                                        </td>
                                        <td>
                                <asp:DropDownList ID="DropDownListDISTRICT_ID" runat="server" CssClass="droplist">
                                    <asp:ListItem Value="0">--all--</asp:ListItem>
                                </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                <asp:Label ID="Label46" runat="server" CssClass="label">Mã nhóm:</asp:Label>
                            </td>
                            <td align="left" width="35%">
                                <table cellpadding="0"  cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                <asp:TextBox ID="txtGROUP_TEXT" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="98%" Font-Bold="True"></asp:TextBox>
                                        </td>
                                        <td width="20%">
                                            <asp:CheckBox ID="CheckBoxGROUP_TEXT" runat="server" CssClass="checkbox" Text="Tương đối" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="15%" align="right">
                                <asp:Label ID="Label31" runat="server" CssClass="label">Địa chỉ:</asp:Label>
                            </td>
                            <td align="left">

                                <table cellpadding="0"  cellspacing="0" width="100%">
                                    <tr>
                                        <td>
                                <asp:TextBox ID="txtADDRESS" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="98%" Font-Bold="False"></asp:TextBox>
                                        </td>
                                        <td width="20%">
                                            <asp:CheckBox ID="CheckBoxADDRESS" runat="server" CssClass="checkbox" Text="Tương đối" />
                                        </td>
                                    </tr>
                                </table>

                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                <asp:Label ID="Label27" runat="server" CssClass="label">Nguồn dữ liệu:</asp:Label>
                            </td>
                            <td align="left" width="35%">

                                <asp:DropDownList ID="DropDownListSOURCE_ID" runat="server" CssClass="droplist">
                                </asp:DropDownList>

                            </td>
                            <td width="15%" align="right">
                                <asp:Label ID="Label32" runat="server" CssClass="label">Email:</asp:Label>
                            </td>
                            <td align="left">

                          
                                <asp:TextBox ID="txtEMAIL_ADDRESS" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="50%" Font-Bold="False"></asp:TextBox>

                          
                            </td>
                        </tr>
                        <tr>
                            <td align="right"  >
                                <asp:Label ID="Label47" runat="server" CssClass="label">Trạng thái:</asp:Label>
                            </td>
                            <td align="left"  >
                                <asp:DropDownList ID="DropDownListSTATUS_ID" runat="server" CssClass="droplist">
                                    <asp:ListItem Value="0">--all--</asp:ListItem>
                                    <asp:ListItem Value="1">New</asp:ListItem>
                                    <asp:ListItem Value="2">Call</asp:ListItem>
                                    <asp:ListItem Value="3">Invalid</asp:ListItem>
                                    <asp:ListItem Value="4">Done</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="right"  >
                                <asp:Label ID="Label33" runat="server" CssClass="label">Mức cước:</asp:Label>
                            </td>
                            <td align="left"  >
                                <asp:DropDownList ID="DropDownListFEES_ID" runat="server" CssClass="droplist">
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td align="right"  >
                                <asp:Label ID="Label48" runat="server" CssClass="label">Lần lặp:</asp:Label>
                            </td>
                            <td align="left"  >
                               <table cellpadding="0"  cellspacing="0" width="100%">
                                    <tr>
                                        <td width="10%">
                                <asp:DropDownList ID="DropDownListDUPLICATE_NUMBER" runat="server" CssClass="droplist">
                                    <asp:ListItem>&gt;=</asp:ListItem>
                                    <asp:ListItem>=</asp:ListItem>
                                    <asp:ListItem>&lt;=</asp:ListItem>
                                </asp:DropDownList>
                                        </td>
                                        <td>
                                <asp:TextBox ID="txtDUPLICATE_NUMBER" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="20%" Font-Bold="True"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td align="right"  >
                                <asp:Label ID="Label34" runat="server" CssClass="label">Mức thu nhập:</asp:Label>
                            </td>
                            <td align="left" >
                                <asp:DropDownList ID="DropDownListINCOME_ID" runat="server" CssClass="droplist">
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td align="right"  >
                                <asp:Label ID="Label49" runat="server" CssClass="label">Độ chính xác:</asp:Label>
                            </td>
                            <td align="left"  >
                                <table cellpadding="0"  cellspacing="0" width="100%">
                                    <tr>
                                        <td width="10%">
                                <asp:DropDownList ID="DropDownListEXACTLY_RATE" runat="server" CssClass="droplist">
                                    <asp:ListItem>&gt;=</asp:ListItem>
                                    <asp:ListItem>=</asp:ListItem>
                                    <asp:ListItem>&lt;=</asp:ListItem>
                                </asp:DropDownList>
                                        </td>
                                        <td>
                                <asp:DropDownList ID="DropDownListEXACTLY_RATE_NUMBER" runat="server" CssClass="droplist">
                                </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td align="right"  >
                                <asp:Label ID="Label36" runat="server" CssClass="label">Mã khách hàng:</asp:Label>
                            </td>
                            <td align="left"  >
                                <asp:TextBox ID="txtCUSTOMER_CODE" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="50%" Font-Bold="False"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td align="right"  >
                                <asp:Label ID="Label50" runat="server" CssClass="label">Top:</asp:Label>
                            </td>
                            <td align="left"  >

                                <asp:TextBox ID="txtTOP" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="20%" Font-Bold="True"></asp:TextBox>

                            </td>
                            <td align="right"  >
                                <asp:Label ID="Label28" runat="server" CssClass="label">Ghi chú:</asp:Label>
                            </td>
                            <td align="left"  >
                                <table cellpadding="0" cellspacing="0" class="auto-style1">
                                    <tr>
                                        <td>
                                <asp:TextBox ID="txtREMARK" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="98%" Font-Bold="False" TextMode="MultiLine" Height="48px"></asp:TextBox>
                                        </td>
                                        <td width="20%">
                                            <asp:CheckBox ID="CheckBoxREMARK" runat="server" CssClass="checkbox" Text="Tương đối" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>

                        <tr>
                            <td align="right"  >
                                <asp:Label ID="Label7" runat="server" CssClass="label">Ngành hàng:</asp:Label>
                            </td>
                            <td align="left"  >

                                <asp:CheckBoxList ID="CheckBoxListFIELD_ID" runat="server" CssClass="checkbox" RepeatColumns="5">
                                </asp:CheckBoxList>

                            </td>
                            <td align="right"  >
                                <asp:Label ID="Label51" runat="server" CssClass="label">Sắp xếp:</asp:Label>
                            </td>
                            <td align="left"  >
                                <table cellpadding="0" cellspacing="0" class="auto-style1">
                                    <tr>
                                        <td width="30%">
                                <asp:DropDownList ID="DropDownListOrderField" runat="server" CssClass="droplist">
                                    <asp:ListItem>--Chọn--</asp:ListItem>
                                    <asp:ListItem>Độ chính xác</asp:ListItem>
                                    <asp:ListItem Value="DUPLICATE_NUMBER">Số lần lặp</asp:ListItem>
                                    <asp:ListItem Value="CREATE_TIME">Khởi tạo</asp:ListItem>
                                </asp:DropDownList>
                                        </td>
                                        <td>
                                <asp:DropDownList ID="DropDownListOrder" runat="server" CssClass="droplist">
                                    <asp:ListItem Value="ASC">Tăng dần</asp:ListItem>
                                    <asp:ListItem Value="DESC">Giảm dần</asp:ListItem>
                                </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>

                        </table>
                </fieldset>
                <div class="submmit">
                    <asp:Button ID="btnSearch" runat="server" CssClass="btnbackground"
                        Text="Tìm kiếm" />
                    <asp:Button ID="btnExport" runat="server" CssClass="btnbackground"
                        Text="Báo cáo" />
                </div>
                       </div>
                   <a href="javascript:showSubcat('2');">
                    <img id="imgCat2" src="../../Images/collapse_thead_collapsed.gif" border="0" /></a><a class="cateGrid" href="javascript:showSubcat('2');">
                        <asp:Label ID="Label35" runat="server"   CssClass="label" ForeColor="#666666">Bổ sung thông tin</asp:Label></a>
                <div id="divCat2" style=" display:none ">  
                <fieldset id="fieldset1">
                    <legend>
                        <asp:Label ID="Label2" runat="server" CssClass="lblerror"></asp:Label></legend>
                    <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                        <tr>
                            <td align="right" width="15%">
                                <asp:Label ID="Label10" runat="server" CssClass="label">Số điện thoại:</asp:Label>
                            </td>
                            <td align="left" width="35%">
                                <asp:TextBox ID="txtUSER_ID_Add" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="50%" Font-Bold="True" ForeColor="#0033CC"></asp:TextBox>
                            </td>
                            <td width="15%" align="right">
                                <asp:Label ID="Label11" runat="server" CssClass="label">Mã khách hàng:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtCUSTOMER_CODE_Add" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="50%" Font-Bold="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                <asp:Label ID="Label12" runat="server" CssClass="label">Nội dung MT:</asp:Label>
                            </td>
                            <td align="left" width="35%">
                                <asp:TextBox ID="txtMT_Add" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="100%" Font-Bold="False" Height="58px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td width="15%" align="right">
                                <asp:Label ID="Label13" runat="server" CssClass="label">Họ tên:</asp:Label>
                            </td>
                            <td align="left">

                                <asp:TextBox ID="txtCUSTOMER_NAME_Add" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="80%" Font-Bold="False"></asp:TextBox>

                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                <asp:Label ID="Label14" runat="server" CssClass="label">Đối tác:</asp:Label>
                            </td>
                            <td align="left" width="35%">
                                <asp:DropDownList ID="DropDownListPARTNER_ID_Add" runat="server" CssClass="droplist" Font-Bold="True" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                            <td width="15%" align="right">
                                <asp:Label ID="Label15" runat="server" CssClass="label">Ngày sinh:</asp:Label>
                            </td>
                            <td align="left">

                                <table cellpadding="0" cellspacing="1" class="auto-style2">
                                    <tr>
                                        <td width="10%">
                                            <asp:DropDownList ID="DropDownListDAY_Add" runat="server" CssClass="droplist">
                                            </asp:DropDownList>
                                        </td>
                                        <td width="10%">
                                            <asp:DropDownList ID="DropDownListMONTH_Add" runat="server" CssClass="droplist">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="DropDownListYEAR_Add" runat="server" CssClass="droplist">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="right"  >
                                <asp:Label ID="Label17" runat="server" CssClass="label">Brand name:</asp:Label>
                            </td>
                            <td align="left"  >
                                <asp:DropDownList ID="DropDownListBRAND_NAME_Add" runat="server" CssClass="droplist">
                                    <asp:ListItem Value="0">--Chọn--</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="right"  >
                                <asp:Label ID="Label18" runat="server" CssClass="label">Địa chỉ:</asp:Label>
                            </td>
                            <td align="left"  >
                                <asp:TextBox ID="txtADDRESS_Add" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="100%" Font-Bold="False"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td align="right"  >
                                <asp:Label ID="Label19" runat="server" CssClass="label">Tỉnh/Thành:</asp:Label>
                            </td>
                            <td align="left"  >
                                <table class="auto-style1">
                                    <tr>
                                        <td>
                                <asp:DropDownList ID="DropDownListPROVINCE_ID_Add" runat="server" CssClass="droplist" AutoPostBack="True">
                                </asp:DropDownList>
                                        </td>
                                        <td>
                                <asp:Label ID="Label58" runat="server" CssClass="label">Quận/Huyện:</asp:Label>
                                        </td>
                                        <td>
                                <asp:DropDownList ID="DropDownListDISTRICT_ID_Add" runat="server" CssClass="droplist">
                                    <asp:ListItem Value="0">--Chọn--</asp:ListItem>
                                </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td align="right"  >
                                <asp:Label ID="Label20" runat="server" CssClass="label">Email:</asp:Label>
                            </td>
                            <td align="left"  >
                                <asp:TextBox ID="txtEMAIL_ADDRESS_Add" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="50%" Font-Bold="False"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td align="right"  >
                                <asp:Label ID="Label21" runat="server" CssClass="label">Giới tính:</asp:Label>
                            </td>
                            <td align="left"  >
                                <asp:DropDownList ID="DropDownListSEX_Add" runat="server" CssClass="droplist">
                                    <asp:ListItem Value="-1">--Chọn--</asp:ListItem>
                                    <asp:ListItem Value="1">Nam</asp:ListItem>
                                    <asp:ListItem Value="2">Nữ</asp:ListItem>
                                    <asp:ListItem Value="0">Chưa xác định</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="right"  >
                                <asp:Label ID="Label22" runat="server" CssClass="label">Mức cước:</asp:Label>
                            </td>
                            <td align="left"  >
                                <asp:DropDownList ID="DropDownListFEES_ID_Add" runat="server" CssClass="droplist">
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td align="right"  >
                                <asp:Label ID="Label23" runat="server" CssClass="label">Ngành hàng:</asp:Label>
                            </td>
                            <td align="left"  >

                                <asp:CheckBoxList ID="CheckBoxListFIELD_ID_Add" runat="server" CssClass="checkbox" RepeatColumns="3">
                                </asp:CheckBoxList>

                            </td>
                            <td align="right"  >
                                <asp:Label ID="Label24" runat="server" CssClass="label">Mức thu nhập:</asp:Label>
                            </td>
                            <td align="left"  >
                                <asp:DropDownList ID="DropDownListINCOME_ID_Add" runat="server" CssClass="droplist">
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td align="right"  >
                                <asp:Label ID="Label25" runat="server" CssClass="label">Nguồn dữ liệu:</asp:Label>
                            </td>
                            <td align="left"  >

                                <asp:DropDownList ID="DropDownListSOURCE_ID_Add" runat="server" CssClass="droplist">
                                </asp:DropDownList>

                            </td>
                            <td align="right"  >
                                <asp:Label ID="Label38" runat="server" CssClass="label">Mạng:</asp:Label>
                            </td>
                            <td align="left"  >
                                <asp:DropDownList ID="DropDownListMOBILE_OPERATOR_Add" runat="server" CssClass="droplist">
                                    <asp:ListItem Value="0">--Chọn--</asp:ListItem>
                                    <asp:ListItem>VIETTEL</asp:ListItem>
                                    <asp:ListItem>VMS</asp:ListItem>
                                    <asp:ListItem>VNM</asp:ListItem>
                                    <asp:ListItem>VNP</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td align="right"  >
                                <asp:Label ID="Label39" runat="server" CssClass="label">Từ khóa:</asp:Label>
                            </td>
                            <td align="left"  >
                                <asp:TextBox ID="txtKEY_WORD_Add" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="50%" Font-Bold="True" ForeColor="#0033CC"></asp:TextBox>
                            </td>
                            <td align="right"  >
                                <asp:Label ID="Label40" runat="server" CssClass="label">Độ chính xác:</asp:Label>
                            </td>
                            <td align="left"  >
                                <asp:DropDownList ID="DropDownListEXACTLY_RATE_Add" runat="server" CssClass="droplist">
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td align="right"  >
                                <asp:Label ID="Label55" runat="server" CssClass="label">Mã nhóm:</asp:Label>
                            </td>
                            <td align="left"  >
                                <asp:TextBox ID="txtGROUP_TEXT_Add" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="50%" Font-Bold="True"></asp:TextBox>
                            </td>
                            <td align="right"  >
                                <asp:Label ID="Label56" runat="server" CssClass="label">Trạng thái:</asp:Label>
                            </td>
                            <td align="left"  >
                                <asp:DropDownList ID="DropDownListSTATUS_ID_Add" runat="server" CssClass="droplist"  AutoPostBack="true">
                                    <asp:ListItem Value="0">--Chọn--</asp:ListItem>
                                    <asp:ListItem Value="1">New</asp:ListItem>
                                    <asp:ListItem Value="2">Call</asp:ListItem>
                                    <asp:ListItem Value="3">Invalid</asp:ListItem>
                                    <asp:ListItem Value="4">Done</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td align="right"  >
                                <asp:Label ID="Label41" runat="server" CssClass="label">Ghi chú:</asp:Label>
                            </td>
                            <td align="left"  >
                                <asp:TextBox ID="txtREMARK_Add" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="100%" Font-Bold="False" TextMode="MultiLine" Height="48px"></asp:TextBox>
                            </td>
                            <td align="right"  >
                                <asp:Label ID="Label54" runat="server" CssClass="label">Tùy chọn:</asp:Label>
                            </td>
                            <td align="left"  >
                                            <table class="auto-style1">
                                                <tr>
                                                    <td>
                                            <asp:CheckBox ID="CheckBoxDelImport" runat="server" CssClass="checkbox" Text="Xóa bảng tạm" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                            <asp:CheckBox ID="CheckBoxSaveCall" runat="server" CssClass="checkbox" Text="Lưu bảng gọi điện" />
                                                    </td>
                                                </tr>
                                                      <tr>
                                                    <td>
                                            <asp:CheckBox ID="CheckBoxSaveDone" runat="server" CssClass="checkbox" Text="Lưu bảng chính thức" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                            <asp:CheckBox ID="CheckBoxDelThesame" runat="server" CssClass="checkbox" Text="Xóa số liên quan" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                        </tr>

                    </table>
                </fieldset>
                <div class="submmit">
                    <asp:Button ID="btnUpdate" runat="server" CssClass="btnbackground"
                        Text="Cập nhật trang" />
                    <asp:Button ID="btnUpdateAll" runat="server" CssClass="btnbackground"
                        Text="Cập nhật all" />
                    <asp:Button ID="btnDeletePage" runat="server" CssClass="btnbackground"
                        Text="Xóa trang" />
                    <asp:Button ID="btnDeleteAll" runat="server" CssClass="btnbackground"
                        Text="Xóa all" />
                </div>
                </div>
                  <a href="javascript:showSubcat('3');">
                    <img id="imgCat3" src="../../Images/collapse_thead_collapsed.gif"  alt="" border="0" /></a><a class="cateGrid" href="javascript:showSubcat('3');">
                        <asp:Label ID="Label42" runat="server"   CssClass="label" ForeColor="#666666">Danh sách khách hàng</asp:Label> <asp:Label ID="lblTotal" runat="server"   CssClass="label" ForeColor="red"> </asp:Label></a>
                  <div id="divCat3" style=" display:none "> 
              
                    <div class="pager">
                        <cc1:PagerV2_8 ID="pager1" runat="server" OnCommand="pager_Command" GenerateGoToSection="true"
                            Font-Size="10pt" PageSize="100" />

                    </div>
                    <div class="datagrid">
                        <asp:DataGrid ID="DataGrid" runat="server" AllowPaging="True" AutoGenerateColumns="false"
                            CellPadding="0" CssClass="datagrid" EnableViewState="False" GridLines="None"
                            PagerStyle-Mode="NextPrev" PagerStyle-Visible="true" Width="100%" PageSize="100">
                            <HeaderStyle CssClass="datagridHeader" />
                            <AlternatingItemStyle CssClass="datagridAlternatingItemStyle" />
                            <ItemStyle CssClass="datagridItemStyle" />
                            <Columns>
                                       <asp:TemplateColumn>
                                        <HeaderStyle HorizontalAlign="Center" Width="3%" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderTemplate>
                                            <input id="Check_All" name="Check_All" onclick="CheckAll_Click(this)" type="checkbox"> </input>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <input id="chkActive" runat="server" name="Add" value='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                                type="checkbox" onclick="Toggle(this)" />
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="KHÁCH HÀNG"   Visible="false">
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblUser_Id" runat="server" CssClass="label" Text='<%# DataBinder.Eval(Container.DataItem, "USER_ID")%>'>  </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="MÃ">
                                    <ItemStyle Width="3%" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblID" runat="server" CssClass="label"> <%# DataBinder.Eval(Container.DataItem, "ID")%></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="MÃ NHÓM">
                                    <ItemStyle Width="5%" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblGROUP_TEXT" runat="server" CssClass="label">  <%# DataBinder.Eval(Container.DataItem, "GROUP_TEXT")%></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="KHÁCH HÀNG">
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    <ItemTemplate>
                                          <asp:Label ID="lblUSER_ID_View" runat="server" CssClass="ItemsText">
                                                                      <a href="JavaScript:IsDetail('<%#Utils.EncryptText(DataBinder.Eval(Container.DataItem, "ID"))%>')"
                                            class="itemMenu" title="Thông tin chi tiết" ><%# DataBinder.Eval(Container.DataItem, "USER_ID")%> </a>
                                            </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="NỘI DUNG">
                                    <ItemStyle HorizontalAlign="Left" Width="15%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblMT" runat="server" CssClass="label"  > <%# DataBinder.Eval(Container.DataItem, "MT")%></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="BRAND">
                                    <ItemStyle HorizontalAlign="Left" Width="5%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblBRAND_NAME" runat="server" CssClass="label"  > <%# DataBinder.Eval(Container.DataItem, "BRAND_NAME")%></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                      <asp:TemplateColumn HeaderText="NGÀNH HÀNG">
                                    <ItemStyle HorizontalAlign="Center" Width="15%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFIELD_TEXT" runat="server" CssClass="label"  > <%# DataBinder.Eval(Container.DataItem, "FIELD_TEXT")%></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                   <asp:TemplateColumn HeaderText="NGUỒN">
                                    <ItemStyle HorizontalAlign="Left" Width="5%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblSOURCE_TEXT" runat="server" CssClass="label"  > <%# DataBinder.Eval(Container.DataItem, "SOURCE_TEXT")%></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                   <asp:TemplateColumn HeaderText="TRẠNG THÁI">
                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblSTATUS_TEXT" runat="server" CssClass="label"  > <%# DataBinder.Eval(Container.DataItem, "STATUS_TEXT")%></asp:Label>
                                    </ItemTemplate>

                                </asp:TemplateColumn>
                                  <asp:TemplateColumn HeaderText="TÊN">
                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCUSTOMER_NAME" runat="server" CssClass="label"  > <%# DataBinder.Eval(Container.DataItem, "CUSTOMER_NAME")%></asp:Label>
                                    </ItemTemplate>

                                </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="GIỚI TÍNH">
                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblSEX_TEXT" runat="server" CssClass="label"  > <%# DataBinder.Eval(Container.DataItem, "SEX_TEXT")%></asp:Label>
                                    </ItemTemplate>

                                </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="TỈNH">
                                    <ItemStyle HorizontalAlign="Left" Width="5%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblPROVINCE_TEXT" runat="server" CssClass="label"  > <%# DataBinder.Eval(Container.DataItem, "PROVINCE_TEXT")%></asp:Label>
                                    </ItemTemplate>

                                </asp:TemplateColumn>
                                   <asp:TemplateColumn HeaderText="CƯỚC">
                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFEES_TEXT" runat="server" CssClass="label"  > <%# DataBinder.Eval(Container.DataItem, "FEES_TEXT")%></asp:Label>
                                    </ItemTemplate>

                                </asp:TemplateColumn>
                                   <asp:TemplateColumn HeaderText="THU NHẬP">
                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblINCOME_TEXT" runat="server" CssClass="label"  > <%# DataBinder.Eval(Container.DataItem, "INCOME_TEXT")%></asp:Label>
                                    </ItemTemplate>

                                </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="ĐỘ CX">
                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblEXACTLY_RATE" runat="server" CssClass="label"  > <%# DataBinder.Eval(Container.DataItem, "EXACTLY_RATE")%></asp:Label>
                                    </ItemTemplate>

                                </asp:TemplateColumn>
                                   <asp:TemplateColumn HeaderText="LẶP">
                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblDUPLICATE_NUMBER" runat="server" CssClass="label"  > <%# DataBinder.Eval(Container.DataItem, "DUPLICATE_NUMBER")%></asp:Label>
                                    </ItemTemplate>

                                </asp:TemplateColumn>
                            </Columns>
                            <PagerStyle HorizontalAlign="Right" NextPageText="" PageButtonCount="5" PrevPageText=""
                                Visible="False" />
                        </asp:DataGrid>

                    </div>
                
             </div>
        </div>
      </div>
    </form>
      <script type="text/javascript">
          var gridActive = document.getElementById('DataGrid');
          function CheckAll_Click(e) {
              if (e.checked) {
                  Check_All();
              }
              else {
                  Clear_All();
              }
          }
          function Check_All() {
              var chkList = gridActive.getElementsByTagName('input');
              for (var i = 0; i < chkList.length; i++) {
                  chkList[i].checked = true;
              }
          }
          function Clear_All() {
              var chkList = gridActive.getElementsByTagName('input');
              for (var i = 0; i < chkList.length; i++) {
                  chkList[i].checked = false;
              }
          }
    </script>
</body>
</html>
