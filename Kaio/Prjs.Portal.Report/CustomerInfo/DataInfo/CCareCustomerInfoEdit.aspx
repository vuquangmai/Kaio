<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CCareCustomerInfoEdit.aspx.vb" Inherits="Prjs.Portal.Report.CCareCustomerInfoEdit" %>
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
                <telerik:AjaxSetting AjaxControlID="DropDownListPROVINCE_ID">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="DropDownListDISTRICT_ID" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="ImagebtnCheck">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="lblerror" />
                        <telerik:AjaxUpdatedControl ControlID="txtUSER_ID" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListMOBILE_OPERATOR" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <div id="HQ">
            <div class="alert">
                <asp:Label ID="lbltitle" runat="server" CssClass="lbltitle"></asp:Label><br />
                <asp:Label ID="lblerror" runat="server" CssClass="lblerror"></asp:Label>
            </div>
            <div class="input" style="border-width: 0px; width: 96%; background-color: #FFFFFF;">
                <fieldset id="fieldsetBound">
                       <legend>
                        <asp:Label ID="Label1" runat="server" CssClass="lblerror">Thông tin khách hàng</asp:Label></legend>
                   <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                        <tr>
                            <td align="right" width="15%">
                                <asp:Label ID="Label26" runat="server" CssClass="label">Số điện thoại:</asp:Label>
                            </td>
                            <td align="left" width="35%">
                                <table cellpadding="0" cellspacing="0" class="auto-style2">
                                    <tr>
                                        <td width ="50%">
                                <asp:TextBox ID="txtUSER_ID" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="98%" Font-Bold="True" ForeColor="#0033CC"></asp:TextBox>
                                        </td>
                                        <td>
                                <asp:ImageButton ID="ImagebtnCheck" runat="server" AlternateText="Checking..." ImageUrl="~/Images/Search-24x24.png" />
                                        </td>
                                    </tr>
                                </table>
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
                                <asp:DropDownList ID="DropDownListPROVINCE_ID" runat="server" CssClass="droplist" AutoPostBack="True">
                                </asp:DropDownList>
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
                                <asp:Label ID="Label45" runat="server" CssClass="label">Quận/Huyện:</asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                <asp:DropDownList ID="DropDownListDISTRICT_ID" runat="server" CssClass="droplist">
                                    <asp:ListItem Value="0">--Chọn--</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="right" class="auto-style3">
                                <asp:Label ID="Label33" runat="server" CssClass="label">Mức cước:</asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                <asp:DropDownList ID="DropDownListFEES_ID" runat="server" CssClass="droplist">
                                </asp:DropDownList>
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
                                <asp:Label ID="Label34" runat="server" CssClass="label">Mức thu nhập:</asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                <asp:DropDownList ID="DropDownListINCOME_ID" runat="server" CssClass="droplist">
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td align="right" class="auto-style3">
                                <asp:Label ID="Label27" runat="server" CssClass="label">Nguồn dữ liệu:</asp:Label>
                            </td>
                            <td align="left" class="auto-style3">

                                <asp:DropDownList ID="DropDownListSOURCE_ID" runat="server" CssClass="droplist">
                                </asp:DropDownList>

                            </td>
                            <td align="right" class="auto-style3">
                                <asp:Label ID="Label37" runat="server" CssClass="label">Mạng:</asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                <asp:DropDownList ID="DropDownListMOBILE_OPERATOR" runat="server" CssClass="droplist" ForeColor="Red">
                                    <asp:ListItem Value="--Chọn--">--Chọn--</asp:ListItem>
                                    <asp:ListItem>VIETTEL</asp:ListItem>
                                    <asp:ListItem>VMS</asp:ListItem>
                                    <asp:ListItem>VNM</asp:ListItem>
                                    <asp:ListItem>VNP</asp:ListItem>
                                    <asp:ListItem>GTEL</asp:ListItem>
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
                                <asp:DropDownList ID="DropDownListSTATUS_ID" runat="server" CssClass="droplist">
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
                                <asp:Label ID="Label7" runat="server" CssClass="label">Ngành hàng:</asp:Label>
                            </td>
                            <td align="left" class="auto-style3">

                                <asp:CheckBoxList ID="CheckBoxListFIELD_ID" runat="server" CssClass="checkbox" RepeatColumns="3">
                                </asp:CheckBoxList>

                            </td>
                            <td align="right" class="auto-style3">
                                <asp:Label ID="Label28" runat="server" CssClass="label">Ghi chú:</asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                <asp:TextBox ID="txtREMARK" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="100%" Font-Bold="False" TextMode="MultiLine" Height="48px"></asp:TextBox>
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
            </div>
    </form>
</body>
</html>