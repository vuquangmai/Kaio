<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="Prjs.Portal.Report.Login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title> Kaio Report</title>
    <link href="Styles/HQ.css" rel="stylesheet" type="text/css" />
     
</head>
<body>
    <form id="form1" runat="server">
    <div   id="login"  >
              
                    <table cellspacing="0" id="tbl2"  class="table" runat="server">
                     
                            <tr>
                                <td colspan="2" class="title" align="center" >
                                    <div class="new_title">Kaio CUSTOMER CARE LOGIN</div> 
                                </td>
                            </tr>
                            <tr>
                                <td width="95" class="body" style="height: 151px">
                                    <img src="/images/login.jpg" />
                                </td>
                                <td class="body" style="height: 151px">
                                    <asp:Label ID="Label2" runat="server" CssClass="info">  Please enter your User name and Password below.</asp:Label>
                                    <table class="login_form" id="tbl3" runat="server">
                                        <tr>
                                            <td align="right">
                                                <div class="new_title">User name:</div>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtUserName" runat="server" Width="140px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                 <div class="new_title">Password:</div>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPassword" runat="server" Width="140px" TextMode="Password"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td />
                                            <td align="left">
                                                <div class="rem"><asp:CheckBox ID="ckRemember" runat="server" Text="Remember Password" /></div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td />
                                            <td align="left">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td id="login_error" colspan="2" align="center">
                                                <asp:Button ID="btnLogin" runat="server" CssClass="btnSignin" Text="Sign in" 
                                                    OnClick="btnLOGIN_Click" Height="25px" Width="100px" Font-Bold="true" Font-Names="Arial" Font-Size="11px"   />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td   colspan="2">
                                                <asp:Label ID="lblinfo" runat="server"></asp:Label>
                                                </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" valign="top">
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td align="center">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:Label ID="Label1" runat="server" CssClass="copyright">© 2017 Kaio Club</asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                     
                    </table>
             
        
      
    </div>
    
    </form>
</body>
</html>
