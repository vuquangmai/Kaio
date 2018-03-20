<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Index.aspx.vb" Inherits="Prjs.Portal.Report.Ccare_Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Kaio Report</title>
</head>
<frameset framespacing="0" border="0" frameborder="no" rows="55,*,20" name="MainFrame">
		<frame scrolling="no" noresize="noresize"  marginWidth="0" marginHeight="0" name="topFrame" src="Banner.aspx">
		<frameset id="frameset1"  framespacing="0" border="1" frameborder="no" cols="165,*"  bordercolor =blue  >
	
	<frameset framespacing="0" border="0" frameborder="no" rows="*,20">
	 
	<frame scrolling="no" noresize="noresize" marginheight="0" marginwidth="0" name="MenuleftFrame"  src="Menuleft.aspx"   >
	<frame scrolling="no" noresize="noresize" marginheight="0" marginwidth="0" name="MenuLeftFooterFrame"  src="MenuLeftFooter.aspx"   >
		</frameset>
	<frame scrolling="auto" noresize="noresize" marginheight="0" marginwidth="0" name="contentFrame"   style="border-top: 1px solid #ffffff;border-right: 1px solid #377F44;border-left: 1px solid #377F44;" >
	
	</frameset>
		<frame scrolling="no" noresize="noresize" name="bottomFrame" marginWidth="0" marginHeight="0"   src="Footer.aspx">
		</frameset>
</html>
