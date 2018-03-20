<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Banner.aspx.vb" Inherits="Prjs.Portal.Report.ContractInfo_Banner" %>

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
                        <li>
                            <asp:Label ID="lblAndroidAppsChannel" runat="server"><a href="../AndroidApps/Index.aspx?channel=2c7933ca0543877c0e975a0f40cd40cf" target="_parent">
                                <asp:Label ID="lblAndroidApps" runat="server"> </asp:Label></a></asp:Label></li>
                        <li>
                            <asp:Label ID="lblSMSChannel" runat="server"><a href="../SMS/Index.aspx?channel=ba8ae4752b10aad63de1500ff667c88e" target="_parent">
                                <asp:Label ID="lblSMS" runat="server"> </asp:Label></a></asp:Label></li>
                        <li>
                            <asp:Label ID="lblS2Channel" runat="server"><a href="../SubscriptionService/Index.aspx?channel=2f0d4815f8c0f79b340950ab78ef6adb" target="_parent">
                                <asp:Label ID="lblS2" runat="server"> </asp:Label></a></asp:Label></li>
                        <li>
                            <asp:Label ID="lblVinaboxChannel" runat="server"><a href="../Vinabox/Index.aspx?channel=a8c0149052789e5e705ba26084eeeafd" target="_parent">
                                <asp:Label ID="lblVinabox" runat="server"> </asp:Label></a></asp:Label></li>
                        <li>
                            <asp:Label ID="lblGamePortalChannel" runat="server"><a href="../GamePortal/Index.aspx?channel=6d4727b02e106f11324048cdc0b14f3b" target="_parent">
                                <asp:Label ID="lblGamePortal" runat="server"> </asp:Label></a></asp:Label></li>

                        <li>
                            <asp:Label ID="lblVishareChannel" runat="server"><a href="../Vishare/Index.aspx?channel=5f818ead0825e4562732b33acd78307d" target="_parent">
                                <asp:Label ID="lblVishare" runat="server"> </asp:Label></a></asp:Label></li>
                        <li>
                            <asp:Label ID="lblSimToolKitChannel" runat="server"><a href="../SimToolKit/Index.aspx?channel=53043b94b309e8e9c246d8b93da449a4" target="_parent">
                                <asp:Label ID="lblSimToolKit" runat="server"> </asp:Label></a></asp:Label></li>
                        <li>
                            <asp:Label ID="lblBillingChannel" runat="server"><a href="../Billing/Index.aspx?channel=841db316461eb28b0e62f687caeb744c" target="_parent">
                                <asp:Label ID="lblBilling" runat="server"> </asp:Label></a></asp:Label></li>
                        <li>
                            <asp:Label ID="lblCustomerInfoChannel" runat="server"><a href="../CustomerInfo/Index.aspx?channel=5f818ead0825e4562732b33acd78307d" target="_parent">
                                <asp:Label ID="lblCustomerInfo" runat="server"> </asp:Label></a></asp:Label></li>
                        <li>
                            <asp:Label ID="lblMGameChannel" runat="server"><a href="../MGame/Index.aspx?channel=0822a4af199e03c209d05c239ed6eaad" target="_parent">
                                <asp:Label ID="lblMGame" runat="server"> </asp:Label></a></asp:Label></li>
                        <li>
                            <asp:Label ID="lblKPIChannel" runat="server"><a href="../KPI/Index.aspx?channel=988a403a115e4c6ebfd8efdf83864b0a" target="_parent">
                                <asp:Label ID="lblKPI" runat="server"> </asp:Label></a></asp:Label></li>
                        <li class="liselected">
                            <asp:Label ID="lblContractChannel" runat="server"><a href="../ContractInfo/Index.aspx?channel=7ded01ff583d4f0a5a1212cec7dd1f4c" target="_parent" style="color: #377F44">
                                <asp:Label ID="lblContractInfo" runat="server"> </asp:Label></a></asp:Label></li>
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
