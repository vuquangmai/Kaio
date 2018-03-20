<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SMSDictIndexKeywordDeclareEdit.aspx.vb" Inherits="Prjs.Portal.Report.SMSDictIndexKeywordDeclareEdit" %>
<%@ Register assembly="FilePickerControl" namespace="AWS.FilePicker" tagprefix="cc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../../Styles/HQ.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 100%;
            border-collapse: collapse;
        }
        .auto-style3 {
            height: 22px;
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
                <telerik:AjaxSetting AjaxControlID="DropDownListTypeOf_Ticket_Id">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="lblRouting_Url_Edit" />
                        <telerik:AjaxUpdatedControl ControlID="txtRouting_Url_Edit" />
                        <telerik:AjaxUpdatedControl ControlID="lblMT_Edit" />
                        <telerik:AjaxUpdatedControl ControlID="txtMT_Edit" />
                        <telerik:AjaxUpdatedControl ControlID="lblTotal_MT_Edit" />
                        <telerik:AjaxUpdatedControl ControlID="txtTotal_MT_Edit" />
                        <telerik:AjaxUpdatedControl ControlID="lblService_Text_Edit" />
                        <telerik:AjaxUpdatedControl ControlID="txtService_Text_Edit" />
                        <telerik:AjaxUpdatedControl ControlID="lblService_Description_Edit" />
                        <telerik:AjaxUpdatedControl ControlID="txtService_Description_Edit" />
                        <telerik:AjaxUpdatedControl ControlID="lblUserFile_Edit" />
                        <telerik:AjaxUpdatedControl ControlID="txtUserFile_Edit" />
                        <telerik:AjaxUpdatedControl ControlID="lblCate_Edit" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListCate1_Edit" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="DropDownListDepartment_Id">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="DropDownListPartner_Id" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="CheckBox99x">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="CheckBox996" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox997" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox998" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="CheckBox8x79">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="CheckBox8079" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox8179" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox8279" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox8379" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox8479" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox8579" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox8679" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox8779" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox8879" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="CheckBox6x66">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="CheckBox6066" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox6166" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox6266" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox6366" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox6466" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox6566" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox6666" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox6766" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="CheckBox8x99">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="CheckBox8099" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox8199" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox8299" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox8399" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox8499" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox8599" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox8699" />
                        <telerik:AjaxUpdatedControl ControlID="CheckBox8799" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <div id="HQ">
            <div class="alert">
                <asp:Label ID="lbltitle" runat="server" CssClass="lbltitle"></asp:Label><br />
                <asp:Label ID="lblerror" runat="server" CssClass="lblerror"></asp:Label>
            </div>
            <div class="input" style="width: 96%">
                <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                    <tr>
                        <td align="right" width="15%">
                                    <asp:Label ID="Label83" runat="server" CssClass="label">Thể loại:</asp:Label>
                        </td>
                        <td align="left">
                                    <asp:DropDownList ID="DropDownListTypeOf_Ticket_Id" runat="server" CssClass="droplist" AutoPostBack="True">
                                        <asp:ListItem Value="0">--Chọn--</asp:ListItem>
                                        <asp:ListItem Value="1">Khai báo mới</asp:ListItem>
                                        <asp:ListItem Value="2">Sửa thông tin đã đăng ký</asp:ListItem>
                                        <asp:ListItem Value="3">Xóa mã đã đăng ký</asp:ListItem>
                                    </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                                    <asp:Label ID="Label17" runat="server" CssClass="label">Phòng ban:</asp:Label>
                        </td>
                        <td align="left">
                                    <asp:DropDownList ID="DropDownListDepartment_Id" runat="server" CssClass="droplist" AutoPostBack="True">
                                    </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                                    <asp:Label ID="Label18" runat="server" CssClass="label">Đối tác sở hữu:</asp:Label>
                        </td>
                        <td align="left">
                                    <asp:DropDownList ID="DropDownListPartner_Id" runat="server" CssClass="droplist">
                                    </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                                        <asp:CheckBox ID="CheckBox99x" runat="server" AutoPostBack="True" CssClass="checkbox" Font-Bold="True" Text="99x" TextAlign="Left" />
                        </td>
                        <td align="left">
                                        <table class="auto-style1">
                                            <tr>
                                                <td width="10%">
                                                    <asp:CheckBox ID="CheckBox996" runat="server" CssClass="checkbox" Text="996" TextAlign="Left" />
                                                </td>
                                                <td width="10%">
                                                    <asp:CheckBox ID="CheckBox997" runat="server" CssClass="checkbox" Text="997" TextAlign="Left" />
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="CheckBox998" runat="server" CssClass="checkbox" Text="998" TextAlign="Left" />
                                                </td>
                                            </tr>
                                        </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                                        <asp:CheckBox ID="CheckBox8x79" runat="server" AutoPostBack="True" CssClass="checkbox" Font-Bold="True" Text="8x79" TextAlign="Left" />
                        </td>
                        <td align="left">
                                        <table class="auto-style1">
                                            <tr>
                                                <td width="10%">
                                                    <asp:CheckBox ID="CheckBox8079" runat="server" CssClass="checkbox" Text="8079" TextAlign="Left" />
                                                </td>
                                                <td width="10%">
                                                    <asp:CheckBox ID="CheckBox8179" runat="server" CssClass="checkbox" Text="8179" TextAlign="Left" />
                                                </td>
                                                <td width="10%">
                                                    <asp:CheckBox ID="CheckBox8279" runat="server" CssClass="checkbox" Text="8279" TextAlign="Left" />
                                                </td>
                                                <td width="10%">
                                                    <asp:CheckBox ID="CheckBox8379" runat="server" CssClass="checkbox" Text="8379" TextAlign="Left" />
                                                </td>
                                                <td width="10%">
                                                    <asp:CheckBox ID="CheckBox8479" runat="server" CssClass="checkbox" Text="8479" TextAlign="Left" />
                                                </td>
                                                <td width="10%">
                                                    <asp:CheckBox ID="CheckBox8579" runat="server" CssClass="checkbox" Text="8579" TextAlign="Left" />
                                                </td>
                                                <td width="10%">
                                                    <asp:CheckBox ID="CheckBox8679" runat="server" CssClass="checkbox" Text="8679" TextAlign="Left" />
                                                </td>
                                                <td width="10%">
                                                    <asp:CheckBox ID="CheckBox8779" runat="server" CssClass="checkbox" Text="8779" TextAlign="Left" />
                                                </td>
                                                <td>
                                                    <asp:CheckBox ID="CheckBox8879" runat="server" CssClass="checkbox" Text="8879" TextAlign="Left" />
                                                </td>
                                            </tr>
                                        </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                                        <asp:CheckBox ID="CheckBox6x66" runat="server" AutoPostBack="True" CssClass="checkbox" Font-Bold="True" Text="6x66" TextAlign="Left" />
                        </td>
                        <td align="left">
                              <table class="auto-style1">
                                            <tr>
                                                <td width="10%">
                                        <asp:CheckBox ID="CheckBox6066" runat="server" CssClass="checkbox" Text="6066" TextAlign="Left" />
                                                </td>
                                                <td width="10%">
                                        <asp:CheckBox ID="CheckBox6166" runat="server" CssClass="checkbox" Text="6166" TextAlign="Left" />
                                                </td>
                                                <td width="10%">
                                        <asp:CheckBox ID="CheckBox6266" runat="server" CssClass="checkbox" Text="6266" TextAlign="Left" />
                                                </td>
                                                <td width="10%">
                                        <asp:CheckBox ID="CheckBox6366" runat="server" CssClass="checkbox" Text="6366" TextAlign="Left" />
                                                </td>
                                                <td width="10%">
                                        <asp:CheckBox ID="CheckBox6466" runat="server" CssClass="checkbox" Text="6466" TextAlign="Left" />
                                                </td>
                                                <td width="10%">
                                        <asp:CheckBox ID="CheckBox6566" runat="server" CssClass="checkbox" Text="6566" TextAlign="Left" />
                                                </td>
                                                <td width="10%">
                                        <asp:CheckBox ID="CheckBox6666" runat="server" CssClass="checkbox" Text="6666" TextAlign="Left" />
                                                </td>
                                                <td>
                                        <asp:CheckBox ID="CheckBox6766" runat="server" CssClass="checkbox" Text="6766" TextAlign="Left" />
                                                </td>
                                            </tr>
                                        </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                                        <asp:CheckBox ID="CheckBox8x99" runat="server" AutoPostBack="True" CssClass="checkbox" Font-Bold="True" Text="8x99" TextAlign="Left" />
                        </td>
                        <td align="left">
                              <table class="auto-style1">
                                            <tr>
                                                <td width="10%">
                                        <asp:CheckBox ID="CheckBox8099" runat="server" CssClass="checkbox" Text="8099" TextAlign="Left" />
                                                </td>
                                                <td width="10%">
                                        <asp:CheckBox ID="CheckBox8199" runat="server" CssClass="checkbox" Text="8199" TextAlign="Left" />
                                                </td>
                                                <td width="10%">
                                        <asp:CheckBox ID="CheckBox8299" runat="server" CssClass="checkbox" Text="8299" TextAlign="Left" />
                                                </td>
                                                <td width="10%">
                                        <asp:CheckBox ID="CheckBox8399" runat="server" CssClass="checkbox" Text="8399" TextAlign="Left" />
                                                </td>
                                                <td width="10%">
                                        <asp:CheckBox ID="CheckBox8499" runat="server" CssClass="checkbox" Text="8499" TextAlign="Left" />
                                                </td>
                                                <td width="10%">
                                        <asp:CheckBox ID="CheckBox8599" runat="server" CssClass="checkbox" Text="8599" TextAlign="Left" />
                                                </td>
                                                <td width="10%">
                                        <asp:CheckBox ID="CheckBox8699" runat="server" CssClass="checkbox" Text="8699" TextAlign="Left" />
                                                </td>
                                                <td>
                                        <asp:CheckBox ID="CheckBox8799" runat="server" CssClass="checkbox" Text="8799" TextAlign="Left" />
                                                </td>
                                            </tr>
                                        </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label90" runat="server" CssClass="label">Định dạng MT:</asp:Label>
                        </td>
                        <td align="left">
                                    <asp:DropDownList ID="DropDownListTypeOf_MT_Id" runat="server" CssClass="droplist">
                                        <asp:ListItem Value="0">--Chọn--</asp:ListItem>
                                        <asp:ListItem Value="1">Text</asp:ListItem>
                                        <asp:ListItem Value="2">Wappush</asp:ListItem>
                                        <asp:ListItem Value="3">OTA</asp:ListItem>
                                        <asp:ListItem Value="4">OTB</asp:ListItem>
                                        <asp:ListItem Value="5">Text + Link</asp:ListItem>
                                    </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label7" runat="server" CssClass="label">Mã dịch vụ:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtKeyWord" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="50%" Font-Bold="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                                        <asp:Label ID="Label82" runat="server" CssClass="label">Định tuyến MO:</asp:Label>
                        </td>
                        <td align="left">
                            <table cellpadding="0" class="auto-style2">
                                <tr>
                                    <td width="40%">
                            <asp:TextBox ID="txtRouting_Url" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="90%" Font-Bold="False"></asp:TextBox>
                                    </td>
                                    <td align="right" width="20%">
                                        <asp:Label ID="lblRouting_Url_Edit" runat="server" CssClass="label" ForeColor="Red">Định tuyến MO thay đổi:</asp:Label>
                                    </td>
                                    <td>
                            <asp:TextBox ID="txtRouting_Url_Edit" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="90%" Font-Bold="False"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                                        <asp:Label ID="Label84" runat="server" CssClass="label">Nội dung MT:</asp:Label>
                        </td>
                        <td align="left">
                            <table cellpadding="0" class="auto-style2">
                                <tr>
                                    <td width="40%">
                            <asp:TextBox ID="txtMT" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="100%" Font-Bold="False" Height="38px" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                    <td align="right" width="20%">
                                        <asp:Label ID="lblMT_Edit" runat="server" CssClass="label" ForeColor="Red">Nội dung MT thay đổi:</asp:Label>
                                    </td>
                                    <td>
                            <asp:TextBox ID="txtMT_Edit" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="100%" Font-Bold="False" Height="38px" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style3">
                                        <asp:Label ID="Label87" runat="server" CssClass="label">Số lượng MT:</asp:Label>
                        </td>
                        <td align="left" class="auto-style3">
                            <table cellpadding="0" class="auto-style2">
                                <tr>
                                    <td width="40%">
                            <asp:TextBox ID="txtTotal_MT" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="50px" Font-Bold="True"></asp:TextBox>
                                    </td>
                                    <td align="right" width="20%">
                                        <asp:Label ID="lblTotal_MT_Edit" runat="server" CssClass="label" ForeColor="Red">Số lượng MT thay đổi:</asp:Label>
                                    </td>
                                    <td>
                            <asp:TextBox ID="txtTotal_MT_Edit" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="50px" Font-Bold="True"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                                        <asp:Label ID="Label88" runat="server" CssClass="label">Tên dịch vụ:</asp:Label>
                        </td>
                        <td align="left">
                        
                           <table cellpadding="0" class="auto-style2">
                                <tr>
                                    <td width="40%">
                            
                            <asp:TextBox ID="txtService_Text" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="90%" Font-Bold="False"></asp:TextBox>
                        
                                    </td>
                                    <td align="right" width="20%">
                                         
                                        <asp:Label ID="lblService_Text_Edit" runat="server" CssClass="label" ForeColor="Red">Tên dịch vụ thay đổi:</asp:Label>
                                         
                                    </td>
                                    <td>
                            
                            <asp:TextBox ID="txtService_Text_Edit" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="90%" Font-Bold="False"></asp:TextBox>
                        
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                                        <asp:Label ID="Label89" runat="server" CssClass="label">Mô tả dịch vụ:</asp:Label>
                        </td>
                        <td align="left">
                           <table cellpadding="0" class="auto-style2">
                                <tr>
                                    <td width="40%">
                            
                            <asp:TextBox ID="txtService_Description" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="90%" Font-Bold="False" Height="39px" TextMode="MultiLine"></asp:TextBox>
                            
                                    </td>
                                    <td align="right" width="20%">
                                         
                                        <asp:Label ID="lblService_Description_Edit" runat="server" CssClass="label" ForeColor="Red">Mô tả dịch vụ thay đổi:</asp:Label>
                                         
                                    </td>
                                    <td>
                            
                            <asp:TextBox ID="txtService_Description_Edit" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="90%" Font-Bold="False" Height="39px" TextMode="MultiLine"></asp:TextBox>
                            
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label85" runat="server" CssClass="label">File đính kèm:</asp:Label>
                        </td>
                        <td align="left">
                         <table cellpadding="0" class="auto-style2">
                                <tr>
                                    <td width="40%">
                            
                                <cc2:FilePicker ID="txtUserFile" runat="server" CssClass="txtContent" fpAllowedUploadFileExts="" fpPopupURL="../../FilePicker/FilePicker.aspx" fpPopupWidth="600" Width="80%"></cc2:FilePicker>
                            
                                    </td>
                                    <td align="right" width="20%">
                                         
                            <asp:Label ID="lblUserFile_Edit" runat="server" CssClass="label" ForeColor="Red">File đính kèm thay đổi:</asp:Label>
                                         
                                    </td>
                                    <td>
                            
                                <cc2:FilePicker ID="txtUserFile_Edit" runat="server" CssClass="txtContent" fpAllowedUploadFileExts="" fpPopupURL="../../FilePicker/FilePicker.aspx" fpPopupWidth="600" Width="80%"></cc2:FilePicker>
                            
                                    </td>
                                </tr>
                            </table>
                              </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label13" runat="server" CssClass="label">Nhóm dịch vụ:</asp:Label>
                       
                             </td>
                        <td align="left">
                               <table cellpadding="0" class="auto-style2">
                                <tr>
                                    <td width="40%">
                            
                            <asp:DropDownList ID="DropDownListCate_1" runat="server" CssClass="droplist">
                            </asp:DropDownList>
                            
                                    </td>
                                    <td align="right" width="20%">
                                         
                            <asp:Label ID="lblCate_Edit" runat="server" CssClass="label" ForeColor="Red">Nhóm dịch vụ thay đổi:</asp:Label>
                       
                                    </td>
                                    <td>
                            
                            <asp:DropDownList ID="DropDownListCate1_Edit" runat="server" CssClass="droplist">
                            </asp:DropDownList>
                            
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label14" runat="server" CssClass="label">Trạng thái:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListStatus_Id" runat="server" CssClass="droplist">
                                <asp:ListItem Value="1">Tạo mới</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label86" runat="server" CssClass="label">Nhóm xử lý:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListGroup_Handle_Id" runat="server" CssClass="droplist">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label9" runat="server" CssClass="label">Ghi chú:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtDescription" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Height="42px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="submmit">
                <asp:Button ID="btnUpdate" runat="server" CssClass="btnbackground"
                    Text="Ghi lại" />
                <asp:Button ID="btnDelete" runat="server" CssClass="btnbackground"
                    Text="Xóa bỏ" />
                <asp:Button ID="btnReturn" runat="server" CssClass="btnbackground"
                    Text="Quay ra" />
            </div>
        </div>
    </form>
</body>
</html>
