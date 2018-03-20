<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BilScratchCardWorkFollowEdit.aspx.vb" Inherits="Prjs.Portal.Report.BilScratchCardWorkFollowEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../../Styles/HQ.css" rel="stylesheet" type="text/css" />
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
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="txtTotal_Revenue">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="txtTotal_Debts" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="txtTotal_Payment_1">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="txtTotal_Debts" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="txtTotal_Payment_2">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="txtTotal_Debts" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="DropDownListStatus_Id_Current">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="PanelOption" />
                        <telerik:AjaxUpdatedControl ControlID="PanelNextAuto" />
                        <telerik:AjaxUpdatedControl ControlID="PanelNextManual" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="DropDownListNextTask">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="lblTask" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListTask" />
                        <telerik:AjaxUpdatedControl ControlID="PanelNextAuto" />
                        <telerik:AjaxUpdatedControl ControlID="PanelNextManual" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="DropDownListTask">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="lblTask_Order_Next_Manual" />
                        <telerik:AjaxUpdatedControl ControlID="lblTask_Text_Next_Manual" />
                        <telerik:AjaxUpdatedControl ControlID="lblDept_Text_Execute_Next_Manual" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBoxEndTaskManual" />
                        <telerik:AjaxUpdatedControl ControlID="lblHour_Implement_Next_Manual" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <div id="HQ">
            <div class="alert">
                <asp:Label ID="lbltitle" runat="server" CssClass="lbltitle"></asp:Label><br />
                <asp:Label ID="lblerror" runat="server" CssClass="lblerror"></asp:Label>
            </div>
            <div class="input" style="width: 90%">
                <fieldset id="fieldsetBound">
                    <legend>
                        <asp:Label ID="Label1" runat="server" CssClass="lblerror" ForeColor="White">THÔNG TIN HỢP ĐỒNG, ĐỐI TÁC</asp:Label></legend>
                    <table border="0" cellpadding="3" cellspacing="2" style="width: 100%">
                        <tr>
                            <td align="right" width="15%">
                                <asp:Label ID="Label27" runat="server" CssClass="label">Đối tác:</asp:Label>
                            </td>
                            <td align="left" width="35%">
                                <asp:Label ID="lblPartner_Text" runat="server" CssClass="label" Font-Bold="False"></asp:Label>
                            </td>
                            <td align="right" width="15%">
                                <asp:Label ID="Label26" runat="server" CssClass="label">Hợp đồng:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblContract_Code" runat="server" CssClass="label" Font-Bold="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label36" runat="server" CssClass="label">Mã đối tác:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblPartner_Code" runat="server" CssClass="label" Font-Bold="False"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label28" runat="server" CssClass="label">Tháng đối soát:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblMonth" runat="server" CssClass="label" Font-Bold="False"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label34" runat="server" CssClass="label">Tài khoản đăng nhập:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblAccount_Report" runat="server" CssClass="label" Font-Bold="False"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label31" runat="server" CssClass="label">Bộ phận kinh doanh:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblDept_Text_Biz" runat="server" CssClass="label" Font-Bold="False"></asp:Label>
                            </td>
                        </tr>
                    </table>




                </fieldset>
                <fieldset id="fieldset3">
                    <legend>
                        <asp:Label ID="Label5" runat="server" CssClass="lblerror" ForeColor="White">TIẾN ĐỘ THANH TOÁN</asp:Label></legend>


                    <table border="0" cellpadding="3" cellspacing="2" style="width: 100%">
                        <tr>
                            <td align="right" width="15%">
                                <asp:Label ID="Label7" runat="server" CssClass="label">Tổng doanh thu:</asp:Label>
                            </td>
                            <td align="left" width="15%">

                                <telerik:RadNumericTextBox ShowSpinButtons="true"
                                    IncrementSettings-InterceptArrowKeys="true"
                                    IncrementSettings-InterceptMouseWheel="true" LabelWidth="" runat="server"
                                    ID="txtTotal_Revenue" Width="120px" CssClass="txtContent" Culture="vi-VN"
                                    Font-Bold="True" Font-Names="Arial" Skin="Forest" AutoPostBack="True">
                                    <NumberFormat ZeroPattern="n" DecimalDigits="2" AllowRounding="False"></NumberFormat>
                                </telerik:RadNumericTextBox>
                            </td>
                            <td align="right" width="15%">&nbsp;</td>
                            <td align="left">&nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label12" runat="server" CssClass="label">Thanh toán lần 1:</asp:Label>
                            </td>
                            <td align="left">

                                <telerik:RadNumericTextBox ShowSpinButtons="true"
                                    IncrementSettings-InterceptArrowKeys="true"
                                    IncrementSettings-InterceptMouseWheel="true" LabelWidth="" runat="server"
                                    ID="txtTotal_Payment_1" Width="120px" CssClass="txtContent" Culture="vi-VN"
                                    Font-Bold="True" Font-Names="Arial" Skin="Forest" AutoPostBack="True" ForeColor="#0033CC">
                                    <NumberFormat ZeroPattern="n" DecimalDigits="2" AllowRounding="False"></NumberFormat>
                                </telerik:RadNumericTextBox>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label54" runat="server" CssClass="label">Tỷ lệ thanh toán lần 1:</asp:Label>
                            </td>
                            <td align="left">
                                 
                                <asp:TextBox ID="txtRatio_Payment_1" runat="server" CssClass="txtContent" Font-Bold="True" Width="50px"></asp:TextBox>
                                 
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label53" runat="server" CssClass="label">Thanh toán lần 2:</asp:Label>
                            </td>
                            <td align="left">

                                <telerik:RadNumericTextBox ShowSpinButtons="true"
                                    IncrementSettings-InterceptArrowKeys="true"
                                    IncrementSettings-InterceptMouseWheel="true" LabelWidth="" runat="server"
                                    ID="txtTotal_Payment_2" Width="120px" CssClass="txtContent" Culture="vi-VN"
                                    Font-Bold="True" Font-Names="Arial" Skin="Forest" AutoPostBack="True" ForeColor="#0033CC">
                                    <NumberFormat ZeroPattern="n" DecimalDigits="2" AllowRounding="False"></NumberFormat>
                                </telerik:RadNumericTextBox>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label55" runat="server" CssClass="label">Tỷ lệ thanh toán lần 2:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtRatio_Payment_2" runat="server" CssClass="txtContent" Font-Bold="True" Font-Italic="False" Width="50px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label14" runat="server" CssClass="label">Số tiền còn lại:</asp:Label>
                            </td>
                            <td align="left">

                                <telerik:RadNumericTextBox ShowSpinButtons="true"
                                    IncrementSettings-InterceptArrowKeys="true"
                                    IncrementSettings-InterceptMouseWheel="true" LabelWidth="" runat="server"
                                    ID="txtTotal_Debts" Width="120px" CssClass="txtContent" Culture="vi-VN"
                                    Font-Bold="True" Font-Names="Arial" Skin="Forest" ForeColor="Red">
                                    <NumberFormat ZeroPattern="n" DecimalDigits="2" AllowRounding="False"></NumberFormat>
                                </telerik:RadNumericTextBox>
                            </td>
                            <td align="right">&nbsp;</td>
                            <td align="left">&nbsp;</td>
                        </tr>
                    </table>
                </fieldset>
                <fieldset id="fieldset1">
                    <legend>
                        <asp:Label ID="Label2" runat="server" CssClass="lblerror" ForeColor="White">BƯỚC HIỆN TẠI</asp:Label></legend>
                    <table border="0" cellpadding="3" cellspacing="2" style="width: 100%">
                        <tr>
                            <td align="right" width="15%">
                                <asp:Label ID="Label29" runat="server" CssClass="label">Bước thực hiện:</asp:Label>
                            </td>
                            <td align="left" width="35%">
                                <asp:Label ID="lblTask_Order_Current" runat="server" CssClass="label" Font-Bold="False" ForeColor="Red"></asp:Label>
                            </td>
                            <td align="right" width="15%">
                                <asp:Label ID="Label30" runat="server" CssClass="label">Nội dung thực hiện:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblTask_Text_Curent" runat="server" CssClass="label" Font-Bold="True" ForeColor="#990000"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label32" runat="server" CssClass="label">Bộ phận thực hiện:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblDept_Text_Execute_Current" runat="server" CssClass="label" Font-Bold="True"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label33" runat="server" CssClass="label">Trạng thái thực hiện:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DropDownListStatus_Id_Current" runat="server" CssClass="droplist" AutoPostBack="True">
                                    <asp:ListItem Value="0">Chưa hoàn thành</asp:ListItem>
                                    <asp:ListItem Value="1">Hoàn thành</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label50" runat="server" CssClass="label">Thời gian định mức(giờ):</asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblHour_Implement_Current" runat="server" CssClass="label" Font-Bold="False"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label49" runat="server" CssClass="label">Ghi chú:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtComment_Current" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Height="40px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                            </td>
                        </tr>
                        </table>




                </fieldset>
                       <asp:Panel ID="PanelOption" runat="server">
                    <fieldset id="fieldset4">
                        <legend>
                            <asp:Label ID="Label8" runat="server" CssClass="lblerror" ForeColor="White">TÙY CHỌN</asp:Label></legend>


                        <table border="0" cellpadding="3" cellspacing="2" style="width: 100%">
                            <tr>
                                <td align="right" width="15%">
                                    <asp:Label ID="lblNextTask" runat="server" CssClass="label">Chuyển bước:</asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="DropDownListNextTask" runat="server" AutoPostBack="True" CssClass="droplist">
                                        <asp:ListItem Value="1">Tiếp theo</asp:ListItem>
                                        <asp:ListItem Value="2">Khác</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblTask" runat="server" CssClass="label">Chọn bước thực hiện:</asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="DropDownListTask" runat="server" AutoPostBack="True" CssClass="droplist" >
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </asp:Panel>
                <asp:Panel ID="PanelNextAuto" runat="server">
                    <fieldset id="fieldset2">
                        <legend>
                            <asp:Label ID="Label3" runat="server" CssClass="lblerror" ForeColor="White">BƯỚC TIẾP THEO (TỰ ĐỘNG)</asp:Label></legend>


                        <table border="0" cellpadding="3" cellspacing="2" style="width: 100%">
                            <tr>
                                <td align="right" width="15%">
                                    <asp:Label ID="Label4" runat="server" CssClass="label">Bước thực hiện:</asp:Label>
                                </td>
                                <td align="left" width="35%">
                                    <asp:Label ID="lblTask_Order_Next_Auto" runat="server" CssClass="label" Font-Bold="False" ForeColor="Red"></asp:Label>
                                </td>
                                <td align="right" width="15%">
                                    <asp:Label ID="Label6" runat="server" CssClass="label">Nội dung thực hiện:</asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblTask_Text_Next_Auto" runat="server" CssClass="label" Font-Bold="True" ForeColor="#990000"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label9" runat="server" CssClass="label">Bộ phận thực hiện:</asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblDept_Text_Execute_Next_Auto" runat="server" CssClass="label" Font-Bold="True"></asp:Label>
                                </td>
                                <td align="right">&nbsp;</td>
                                <td align="left">
                                    <asp:CheckBox ID="CheckBoxEndTaskAuto" runat="server" CssClass="checkbox" Enabled="False" Text="Bước kết thúc?" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label51" runat="server" CssClass="label">Thời gian định mức(giờ):</asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblHour_Implement_Next_Auto" runat="server" CssClass="label" Font-Bold="False"></asp:Label>
                                </td>
                                <td align="right">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                            </tr>
                        </table>
                    </fieldset>
                </asp:Panel>
                 <asp:Panel ID="PanelNextManual" runat="server">
                    <fieldset id="fieldset5">
                        <legend>
                            <asp:Label ID="Label10" runat="server" CssClass="lblerror" ForeColor="White">BƯỚC TIẾP THEO (TÙY CHỌN)</asp:Label></legend>


                        <table border="0" cellpadding="3" cellspacing="2" style="width: 100%">
                            <tr>
                                <td align="right" width="15%">
                                    <asp:Label ID="Label52" runat="server" CssClass="label">Bước thực hiện:</asp:Label>
                                </td>
                                <td align="left" width="35%">
                                    <asp:Label ID="lblTask_Order_Next_Manual" runat="server" CssClass="label" Font-Bold="False" ForeColor="Red"></asp:Label>
                                </td>
                                <td align="right" width="15%">
                                    <asp:Label ID="Label15" runat="server" CssClass="label">Nội dung thực hiện:</asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblTask_Text_Next_Manual" runat="server" CssClass="label" Font-Bold="True" ForeColor="#990000"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label17" runat="server" CssClass="label">Bộ phận thực hiện:</asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblDept_Text_Execute_Next_Manual" runat="server" CssClass="label" Font-Bold="True"></asp:Label>
                                </td>
                                <td align="right">&nbsp;</td>
                                <td align="left">
                                    <asp:CheckBox ID="CheckBoxEndTaskManual" runat="server" CssClass="checkbox" Enabled="False" Text="Bước kết thúc?" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="Label19" runat="server" CssClass="label">Thời gian định mức(giờ):</asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblHour_Implement_Next_Manual" runat="server" CssClass="label" Font-Bold="False"></asp:Label>
                                </td>
                                <td align="right">&nbsp;</td>
                                <td align="left">&nbsp;</td>
                            </tr>
                        </table>
                    </fieldset>
                </asp:Panel>
                
            </div>
            <div class="submmit">

                <asp:Button ID="btnUpdate" runat="server" CssClass="btnbackground"
                    Text="Ghi lại" />
                <asp:Button ID="btnReturn" runat="server" CssClass="btnbackground"
                    Text="Quay ra" />
            </div>
        </div>
    </form>
</body>
</html>
