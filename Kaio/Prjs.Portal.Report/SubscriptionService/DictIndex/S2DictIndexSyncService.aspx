<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="S2DictIndexSyncService.aspx.vb" Inherits="Prjs.Portal.Report.S2DictIndexSyncService" %>

<%@ Register assembly="FilePickerControl" namespace="AWS.FilePicker" tagprefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../Styles/HQ.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
        <div id="HQ">
             <div class="alert">
                <asp:Label ID="lbltitle" runat="server" CssClass="lbltitle"></asp:Label><br />
                <asp:Label ID="lblerror" runat="server" CssClass="lblerror"></asp:Label>
            </div>
               <div class="input" style="border-width: 0px; width: 90%; background-color: #FFFFFF;">

                   <table class="auto-style1">
                       <tr>
                           <td width="30%" align="right">
                                    <asp:Label ID="Label7" runat="server" CssClass="label">File Excel:</asp:Label>
                                </td>
                           <td align="left">
    
                                    <cc2:FilePicker ID="UploadFile" runat="server" CssClass="txtContent" fpAllowedUploadFileExts="" fpPopupURL="../../FilePicker/FilePicker.aspx" fpPopupWidth="600" Width="50%"></cc2:FilePicker>
    
                           </td>
                       </tr>
                       <tr>
                           <td align="right">
                                    <asp:Label ID="Label8" runat="server" CssClass="label">Sheet:</asp:Label>
                                </td>
                           <td align="left">
                                    <asp:TextBox ID="txtSheet" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                        Width="120px" AutoPostBack="True" Font-Bold="True" ForeColor="#0033CC"></asp:TextBox>
                                </td>
                       </tr>
                       <tr>
                           <td align="right">
                                    &nbsp;</td>
                           <td align="left">
                <asp:Button ID="btnUpdate" runat="server" CssClass="btnbackground"
                    Text="Đồng ý" />
                                </td>
                       </tr>
                   </table>

               </div>
    
    </div>
    </form>
</body>
</html>
