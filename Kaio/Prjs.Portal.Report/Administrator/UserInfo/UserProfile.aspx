<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="UserProfile.aspx.vb" Inherits="Prjs.Portal.Report.UserProfile" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../../Styles/HQ.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../../Js/Menu.js"></script>
       <style type="text/css">
        fieldset
        {
            display:flexbox ;
            border: 1px solid #BCDDAF;
            -moz-border-radius: 6px;
            -webkit-border-radius: 6px;
            border-radius: 6px;
        }

        legend
        {
            background: #FF9;
            border: solid 1px green;
            -webkit-border-radius: 6px;
            -moz-border-radius: 6px;
            border-radius: 6px;
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
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Transparency="30"
            MinDisplayTime="500">
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            </telerik:RadScriptManager>
        </telerik:RadAjaxLoadingPanel>
        <telerik:RadAjaxManager ID="AjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="CheckBoxShowPass">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="txtNew_PassWord" />
                        <telerik:AjaxUpdatedControl ControlID="txtReType_PassWord" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <div id="HQ">
            <div class="alert">
                <asp:Label ID="lbltitle" runat="server" CssClass="lbltitle"></asp:Label><br />
                <asp:Label ID="lblerror" runat="server" CssClass="lblerror"></asp:Label>
            </div>
              <div class="userprofile"   >
               <a href="javascript:showSubcat('1');">
                    <img id="imgCat1" src="../../Images/collapse_thead_collapsed.gif" border="0" /></a> <a class="cateGrid" href="javascript:showSubcat('1');">
                        <asp:Label ID="Label11" runat="server"  CssClass="label" ForeColor="#999999" Font-Bold="False">1.Thay đổi mật khẩu</asp:Label>
                    </a>
                  </div>
                <div id="divCat1" class="userprofile" style="display: none">
                    <fieldset id="fieldsetBound" >
                        <legend>
                            <asp:Label ID="Label1" runat="server" CssClass="lblerror"></asp:Label></legend>
                        <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                    <tr>
                        <td align="right" width="30%">
                            <asp:Label ID="Label17" runat="server" CssClass="label">Mật khẩu cũ:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtOld_PassWord" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="40%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="20%">
                            <asp:Label ID="Label7" runat="server" CssClass="label">Mật khẩu mới:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtNew_PassWord" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="40%" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label15" runat="server" CssClass="label">Nhập lại mật khẩu:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtReType_PassWord" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                Width="40%" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            &nbsp;</td>
                        <td align="left">
                            <asp:CheckBox ID="CheckBoxShowPass" runat="server" AutoPostBack="True" CssClass="checkbox" Text="Hiển thị  ký tự" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            &nbsp;</td>
                        <td align="left">
                <asp:Button ID="btnResetPassWord" runat="server" CssClass="btnbackground"
                    Text="Đổi mật khẩu" />
                <asp:Button ID="btnReturn" runat="server" CssClass="btnbackground"
                    Text="Quay ra" />
                        </td>
                    </tr>
                    </table>
                     
                
                     
                    </fieldset>
                </div>
             <div class="userprofile"   >
               <a href="javascript:showSubcat('2');">
                    <img id="imgCat2" src="../../Images/collapse_thead_collapsed.gif" border="0" /></a> <a class="cateGrid" href="javascript:showSubcat('2');">
                        <asp:Label ID="Label2" runat="server"  CssClass="label" ForeColor="#999999" Font-Bold="False">2.Thông tin cá nhân</asp:Label>
                    </a>
                  </div>
             <div id="divCat2" class="userprofile" style="display: none">
                    <fieldset id="fieldset1" >
                        <legend>
                            <asp:Label ID="Label3" runat="server" CssClass="lblerror"></asp:Label></legend>
                      
                     
                
                     
                    </fieldset>
                </div>
             <div class="userprofile"   >
               <a href="javascript:showSubcat('3');">
                    <img id="imgCat3" src="../../Images/collapse_thead_collapsed.gif" border="0" /></a> <a class="cateGrid" href="javascript:showSubcat('3');">
                        <asp:Label ID="Label4" runat="server"  CssClass="label" ForeColor="#999999" Font-Bold="False">3.Menu truy cập</asp:Label>
                    </a>
                  </div>
             <div id="divCat3" class="userprofile" style="display: none">
                    <fieldset id="fieldset2" >
                        <legend></legend>
                         
                      
                     
                
                     
                    </fieldset>
                </div>
                <div class="userprofile"   >
               <a href="javascript:showSubcat('4');">
                    <img id="imgCat4" src="../../Images/collapse_thead_collapsed.gif" border="0" /></a> <a class="cateGrid" href="javascript:showSubcat('4');">
                        <asp:Label ID="Label5" runat="server"  CssClass="label" ForeColor="#999999" Font-Bold="False">4.Orther</asp:Label>
                    </a>
                  </div>
             <div id="divCat4" class="userprofile" style="display: none">
                    <fieldset id="fieldset3" >
                        <legend></legend>
                         
                      
                     
                
                     
                    </fieldset>
                </div>
        </div>
    </form>
</body>
</html>
