<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AccessDenied.aspx.vb" Inherits="Prjs.Portal.Report.AccessDenied" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Kaio Report - Access Denied</title>
    <link href="Styles/Error.css" rel="stylesheet" type="text/css" />
        <script language="javascript" type="text/javascript"  src="Js/xp_progress.js">
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div align="center" >
    <div align="center">
		<div id="outline">
		<div id="errorboxoutline">
			<div id="errorboxheader">Access Denied</div>
			<div id="errorboxbody">
			<p><strong>You may not be able to visit this page because of:</strong></p>
				<ol>
					<li>an <strong>out-of-date bookmark/favourite</strong></li>
					<li>a search engine that has an <strong>out-of-date listing for this site</strong></li>
					<li>a <strong>mistyped address</strong></li>
					<li>you have <strong>no access</strong> to this page</li>
					<li>The requested resource was not found.</li>
					<li>An error has occurred while processing your request.</li>
				</ol>
			<p><strong>Please try one of the following pages:</strong></p>
			<p>
				<ul>
					<li><a href="/login.aspx" title="Go to the Login Page">Login</a></li>
				</ul>
			</p>
			<p>If difficulties persist, please contact the System Administrator of this site.</p>
			<div id="techinfo">
			<p>AdsnetCorp </p>
			<p>
							</p>
			</div>
			</div>
		</div>
		</div>
	</div>
    </div>
    </form>
</body>
</html>
