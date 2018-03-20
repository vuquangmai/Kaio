<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Banner.aspx.vb" Inherits="Prjs.Portal.Report.Ccare_Banner" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>#</title>
    <link href="../Styles/HQ.css" type="text/css" rel="stylesheet" />
    <script language="javascript" type="text/javascript">
        function Frame() {
            var catimg = "../Images/arrow-down.gif";
            var catcollapseimg = "../Images/arrow-up.gif";
            imgobj = document.getElementById("imgCat1");
            if (FrameStat == "Show") {
                FrameSize = "165,*";
                FrameStat = "Hide";
                imgobj.src = catcollapseimg;
            }
            else {
                FrameSize = "0,*";
                FrameStat = "Show";
                imgobj.src = catimg;
            }
            window.parent.frameset1.cols = FrameSize;
        }
        onLoad = FrameStat = "Hide";
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="menu">
            <div class="menucontent">
                <div class="top">
                    <ul>
                        <li><a href="../Index.aspx" target="_parent">
                            <asp:Label ID="lblHome" runat="server"> </asp:Label></a></li>
                        <li>
                            <asp:Label ID="lblAdministratorChannel" runat="server"><a href="../Administrator/Index.aspx?channel=2ba3a3fd0d3773d2d02cadbc708f7a3d" target="_parent">
                                <asp:Label ID="lblAdministrator" runat="server"> </asp:Label></a></asp:Label></li>
                        <li class="liselected">
                            <asp:Label ID="lblAndroidAppsChannel" runat="server"><a href="../AndroidApps/Index.aspx?channel=2c7933ca0543877c0e975a0f40cd40cf" target="_parent" style="color: #377F44">
                                <asp:Label ID="lblAndroidApps" runat="server"> </asp:Label></a></asp:Label></li>
                        <li>
                            <asp:Label ID="lblCcareChannel" runat="server"><a href="../Ccare/Index.aspx?channel=ba8ae4752b10aad63de1500ff667c88e" target="_parent">
                                <asp:Label ID="lblCcare" runat="server"> </asp:Label></a></asp:Label></li>
                     
                    </ul>
                </div>
                <div class="bottom">
                    <div class="collapse">
                        <div style="float: right; cursor: crosshair">
                            <a href="JavaScript:Frame()">
                                <img id="imgCat1" alt="Hide" src="../Images/arrow-up.gif" /></a>
                        </div>
                    </div>
                    <asp:Label ID="lblCurrentTime" CssClass="RSS" runat="server">Thứ tư, 22-10-2014 </asp:Label>

                    <div class="UserInfo">

                        <img alt="User Profile" src="../Images/door-out-icon.png" width="15px" />
                        <a target="_top" href="/login.aspx">
                            <asp:Label ID="lblSignOut" CssClass="Label" runat="server"> Sign out</asp:Label></a>
                    </div>
                    <div class="UserInfo">

                        <img alt="User Profile" src="../Images/Clock-icon.png" width="15px" />
                        <a target="_top" href="#">
                            <asp:Label ID="lblLastLogin" CssClass="Label" runat="server"></asp:Label></a>
                    </div>
                    <div class="UserInfo">

                        <img alt="User Profile" src="../Images/Profile-icon.png" width="15px" />
                        <a target="_top" href="#">
                            <asp:Label ID="lblUserName" CssClass="Label" runat="server"></asp:Label></a>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
