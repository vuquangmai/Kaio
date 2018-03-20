<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Index.aspx.vb" Inherits="Prjs.Portal.Report.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Kaio Report</title>
    <link href="Styles/HQ.css" rel="stylesheet" type="text/css" />
    <link href="Styles/Channel.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" media="all" href="Themes/Stylet1.css" />

    <script type='text/javascript' src="Themes/jquery.js"></script>
    <script type='text/javascript' src="Themes/jquery.prettyPhoto.js"></script>
    <script type='text/javascript' src="Themes/custom.js"></script>
    <script type="text/javascript">
        function UserProfile() {
            window.open("/Administrator/UserInfo/UserProfile.aspx", "User_Change_PassWord", "location=no,directories=no,left=0,top=0,height=400,width=800,status=no,scrollbars=yes,toolbars=no,menubar=no,resizable=yes");
        }
    </script>
</head>
<body>

    <form id="form1" runat="server">
        <div id="wrap">
            <div id="header">
                <div class="headercontent">
                    <div class="logo">
                        &nbsp;</div>
                    <img src="Images/Header.png" alt="http://Kaio.club/" border="0" />
                </div>
            </div>
            <div id="menu">
                <div class="menucontent">
                    <div class="top">
                        <ul>
                            <li class="liselected"><a href="../Index.aspx" target="_self" style="color: #377F44">
                                <asp:Label ID="lblHome" runat="server"> </asp:Label></a></li>
                            <li>
                                <asp:Label ID="lblAdministratorChannel" runat="server"><a href="../Administrator/Index.aspx?channel=2ba3a3fd0d3773d2d02cadbc708f7a3d" target="_self">
                                    <asp:Label ID="lblAdministrator" runat="server"> </asp:Label></a></asp:Label></li>
                            <li>
                                <asp:Label ID="lblAndroidAppsChannel" runat="server"><a href="../AndroidApps/Index.aspx?channel=2c7933ca0543877c0e975a0f40cd40cf" target="_self">
                                    <asp:Label ID="lblAndroidApps" runat="server"> </asp:Label></a></asp:Label></li>
                            <li>
                                <asp:Label ID="lblCcareChannel" runat="server"><a href="../Ccare/Index.aspx?channel=ba8ae4752b10aad63de1500ff667c88e" target="_self">
                                    <asp:Label ID="lblCcare" runat="server"> </asp:Label></a></asp:Label></li>
                           
                        </ul>
                    </div>
                    <div class="bottom" style="margin-left: 5px">

                        <asp:Label ID="lblCurrentTime" CssClass="RSS" runat="server">Thứ tư, 18-05-2016</asp:Label>
                        <div class="UserInfo">

                            <img alt="User Profile" src="Images/door-out-icon.png" width="15px" />
                            <a target="_top" href="/login.aspx">
                                <asp:Label ID="lblSignOut" CssClass="Label" runat="server"> Sign out</asp:Label></a>
                        </div>
                        <div class="UserInfo">

                            <img alt="User Profile" src="Images/Clock-icon.png" width="15px" />
                            <a target="_top" href="#">
                                <asp:Label ID="lblLastLogin" CssClass="Label" runat="server"></asp:Label></a>
                        </div>
                        <div class="UserInfo">

                            <img alt="User Profile" src="Images/Profile-icon.png" width="15px" />
                            <a target="_top" href="JavaScript:UserProfile()">
                                <asp:Label ID="lblUserName" CssClass="Label" runat="server"></asp:Label></a>

                        </div>
                    </div>
                </div>
            </div>
            <div id="content">
                <div class="container">
                    <div class="left">

                        <table width="100%" cellpadding="5" cellspacing="5">
                            <tr>
                                <td>
                                    <asp:Panel ID="PanelAdministrator" runat="server" BorderWidth="0">
                                        <div class="hover-border">
                                            <div class="media well hover-border-inner">
                                                <div class="media-body">
                                                    <div class="boxgrid slideright">
                                                        <img src="Images/Administrator.gif" class="cover wp-post-image" alt="Quản trị hệ thống" />
                                                        <h2>QUẢN TRỊ HỆ THỐNG</h2>
                                                        <p>
                                                            - Quản lý account
                            <br />
                                                            - Phân quyền truy cập
                            <br />
                                                            - Hỗ trợ:
                                                        </p>
                                                        <asp:Label ID="lblAdministratorNext" CssClass="Label" runat="server"><a href="../Administrator/Index.aspx?channel=2ba3a3fd0d3773d2d02cadbc708f7a3d" target="_self">
                                                            <asp:Label ID="lblAdministratorNext1" CssClass="Label" runat="server" Text=" »»»Chuyển kênh»»»" Font-Size="11px" ForeColor="#00CC99" Font-Bold="False" BackColor="#0C6491"></asp:Label></a></asp:Label>


                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </asp:Panel>
                                </td>
                                <td>
                                    <asp:Panel ID="PanelAndroidApps" runat="server" BorderWidth="0">
                                        <div class="hover-border">
                                            <div class="media well hover-border-inner">
                                                <div class="media-body">
                                                    <div class="boxgrid slideright">
                                                        <img src="Images/android-market-icon.gif" class="cover wp-post-image" alt="Android Apps" />
                                                        <h2>ANDROID APP</h2>
                                                        <p>
                                                            - ADK Apps
                            <br />
                                                            - Info,...
                            <br />
                                                            - Support:
                                                        </p>
                                                        <asp:Label ID="lblAndroidAppsNext" CssClass="Label" runat="server"><a href="../AndroidApps/Index.aspx?channel=2c7933ca0543877c0e975a0f40cd40cf" target="_self">
                                                            <asp:Label ID="lblAndroidAppsNext1" CssClass="Label" runat="server" Text=" »»»Chuyển kênh»»»" Font-Size="11px" ForeColor="#00CC99" Font-Bold="False" BackColor="#0C6491"></asp:Label></a></asp:Label>


                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </asp:Panel>
                                </td>

                                <td>
                                    <asp:Panel ID="PanelCcare" runat="server" BorderWidth="0">

                                        <div class="hover-border">
                                            <div class="media well hover-border-inner">
                                                <div class="media-body">
                                                    <div class="boxgrid slideright">
                                                        <img src="Images/Ccare.gif" class="cover wp-post-image" alt="Customer Care" />
                                                        <h2>Customer Care</h2>
                                                        <p>
                                                            - Thông tin chăm sóc khách hàng.
                            <br />
                                                            - Báo cáo thống kê
                                                                                        <br />
                                                            - Other,..
                            <br />

                                                        </p>
                                                        <asp:Label ID="lblCcareNext" CssClass="Label" runat="server"><a href="../Ccare/Index.aspx?channel=ba8ae4752b10aad63de1500ff667c88e" target="_self">
                                                            <asp:Label ID="lblCcareNext1" CssClass="Label" runat="server" Text=" »»»Chuyển kênh»»»" Font-Size="11px" ForeColor="#00CC99" Font-Bold="False" BackColor="#0C6491"></asp:Label></a></asp:Label>


                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </asp:Panel>
                                </td>
                                <td>
                                    <asp:Panel ID="PanelBilling" runat="server" BorderWidth="0">

                                        <div class="hover-border">
                                            <div class="media well hover-border-inner">
                                                <div class="media-body">
                                                    <div class="boxgrid slideright">
                                                        <img src="Images/Other.gif" class="cover wp-post-image" alt="Other" />
                                                        <h2>OTHERS</h2>
                                                        <p>
                                                            - Other
                            <br />
                                                            - Other
                            <br />

                                                            <br />

                                                        </p>
                                                        <asp:Label ID="lblBillingNext" CssClass="Label" runat="server"><a href="../Billing/Index.aspx?channel=841db316461eb28b0e62f687caeb744c">
                                                            <asp:Label ID="lblBillingNext1" CssClass="Label" runat="server" Text=" »»»Chuyển kênh»»»" Font-Size="11px" ForeColor="#00CC99" Font-Bold="False" BackColor="#0C6491"></asp:Label></a></asp:Label>


                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <!--
                            <tr>
                                <td>
                                    <asp:Panel ID="PanelS2" runat="server" BorderWidth="0">
                                        <div class="hover-border">
                                            <div class="media well hover-border-inner">
                                                <div class="media-body">
                                                    <div class="boxgrid slidedown">
                                                        <img src="Images/S2.gif" class="cover wp-post-image" alt="S2" />
                                                        <h2>SUBSCRIPTION SERVICE</h2>
                                                        <p>
                                                            - Dịch vụ S2: VMS, VIETTEL, VNP, VNM
                            <br />
                                                            - Báo cáo phân tích, thống kê
                            <br />
                                                            - Thông tin dịch vụ,...
                            <br />

                                                        </p>
                                                        <asp:Label ID="lblS2Next" CssClass="Label" runat="server"><a href="../SubscriptionService/Index.aspx?channel=5f818ead0825e4562732b33acd78307d" target="_self">
                                                            <asp:Label ID="lblS2Next1" CssClass="Label" runat="server" Text=" »»»Chuyển kênh»»»" Font-Size="11px" ForeColor="#00CC99" Font-Bold="False" BackColor="#0C6491"></asp:Label></a></asp:Label>


                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </asp:Panel>
                                </td>
                                <td>
                                    <asp:Panel ID="PanelVinabox" runat="server" BorderWidth="0">

                                        <div class="hover-border">
                                            <div class="media well hover-border-inner">
                                                <div class="media-body">
                                                    <div class="boxgrid slidedown">
                                                        <img src="Images/Vinabox.gif" class="cover wp-post-image" alt="Vinabox" />
                                                        <h2>VINABOX</h2>
                                                        <p>
                                                            - Thông tin dịch vụ
                            <br />
                                                            - Báo cáo phân tích, thống kê
                            <br />

                                                            <br />

                                                        </p>
                                                        <asp:Label ID="lblVinaboxNext" CssClass="Label" runat="server"><a href="../Vinabox/Index.aspx?channel=a8c0149052789e5e705ba26084eeeafd" target="_self">
                                                            <asp:Label ID="lblVinaboxNext1" CssClass="Label" runat="server" Text=" »»»Chuyển kênh»»»" Font-Size="11px" ForeColor="#00CC99" Font-Bold="False" BackColor="#0C6491"></asp:Label></a></asp:Label>


                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </asp:Panel>
                                </td>
                                <td>
                                    <asp:Panel ID="PanelVishare" runat="server" BorderWidth="0">

                                        <div class="hover-border">
                                            <div class="media well hover-border-inner">
                                                <div class="media-body">
                                                    <div class="boxgrid slidedown">
                                                        <img src="Images/Vishare.gif" class="cover wp-post-image" alt="Vishare" />
                                                        <h2>VISHARE</h2>
                                                        <p>
                                                            - Thông tin dịch vụ
                            <br />
                                                            - Báo cáo phân tích, thống kê
                            <br />

                                                            <br />

                                                        </p>
                                                        <asp:Label ID="lblVishareNext" CssClass="Label" runat="server"><a href="../Vishare/Index.aspx?channel=5f818ead0825e4562732b33acd78307d" target="_self">
                                                            <asp:Label ID="lblVishareNext1" CssClass="Label" runat="server" Text=" »»»Chuyển kênh»»»" Font-Size="11px" ForeColor="#00CC99" Font-Bold="False" BackColor="#0C6491"></asp:Label></a></asp:Label>


                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </asp:Panel>
                                </td>
                                <td>
                                    <asp:Panel ID="PanelCharging" runat="server" BorderWidth="0">

                                        <div class="hover-border">
                                            <div class="media well hover-border-inner">
                                                <div class="media-body">
                                                    <div class="boxgrid slidedown">
                                                        <img src="Images/Charging.gif" class="cover wp-post-image" alt="Charging" />
                                                        <h2>CHARGING</h2>
                                                        <p>
                                                            - Thẻ cào VMS, VIETTEL, VNP, FPT,...
                            <br />
                                                            - Báo cáo, thống kê
                            <br />

                                                            <br />

                                                        </p>
                                                        <asp:Label ID="lblChargingNext" CssClass="Label" runat="server"><a href="../Charging/Index.aspx?channel=2acb068a481d6b561b0b5c803f15230a" target="_self">
                                                            <asp:Label ID="lblChargingNext1" CssClass="Label" runat="server" Text=" »»»Chuyển kênh»»»" Font-Size="11px" ForeColor="#00CC99" Font-Bold="False" BackColor="#0C6491"></asp:Label></a></asp:Label>


                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="PanelGamePortal" runat="server" BorderWidth="0">

                                        <div class="hover-border">
                                            <div class="media well hover-border-inner">
                                                <div class="media-body">
                                                    <div class="boxgrid slideright">
                                                        <img src="Images/Game.gif" class="cover wp-post-image" alt="Game Portal" />
                                                        <h2>GAME PORTAL</h2>
                                                        <p>
                                                            - Thông tin dịch vụ
                            <br />
                                                            - Báo cáo phân tích, thống kê
                            <br />

                                                            <br />

                                                        </p>
                                                        <asp:Label ID="lblGamePortalNext" CssClass="Label" runat="server"><a href="../GamePortal/Index.aspx?channel=6d4727b02e106f11324048cdc0b14f3b">
                                                            <asp:Label ID="lblGamePortalNext1" CssClass="Label" runat="server" Text=" »»»Chuyển kênh»»»" Font-Size="11px" ForeColor="#00CC99" Font-Bold="False" BackColor="#0C6491"></asp:Label></a></asp:Label>


                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </asp:Panel>
                                </td>
                                <td>
                                    <asp:Panel ID="PanelSimToolKit" runat="server" BorderWidth="0">

                                        <div class="hover-border">
                                            <div class="media well hover-border-inner">
                                                <div class="media-body">
                                                    <div class="boxgrid slideright">
                                                        <img src="Images/STK.gif" class="cover wp-post-image" alt="STK" />
                                                        <h2>SIM TOOL KIT</h2>
                                                        <p>
                                                            - Thông tin dịch vụ
                            <br />
                                                            - Báo cáo phân tích, thống kê
                            <br />

                                                            <br />

                                                        </p>
                                                        <asp:Label ID="lblSTKNext" CssClass="Label" runat="server"><a href="../SimToolKit/Index.aspx?channel=5f818ead0825e4562732b33acd78307d">
                                                            <asp:Label ID="lblSTKNext1" CssClass="Label" runat="server" Text=" »»»Chuyển kênh»»»" Font-Size="11px" ForeColor="#00CC99" Font-Bold="False" BackColor="#0C6491"></asp:Label></a></asp:Label>


                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </asp:Panel>
                                </td>
                                <td>
                                    <asp:Panel ID="PanelB2C" runat="server" BorderWidth="0">

                                        <div class="hover-border">
                                            <div class="media well hover-border-inner">
                                                <div class="media-body">
                                                    <div class="boxgrid slideright">
                                                        <img src="Images/B2C.gif" class="cover wp-post-image" alt="B2C" />
                                                        <h2>KHÁCH HÀNG B2C</h2>
                                                        <p>
                                                            - Thông tin khách hàng
                            <br />
                                                            - Báo cáo phân tích, thống kê
                            <br />

                                                            <br />

                                                        </p>
                                                        <asp:Label ID="lblB2CNext" CssClass="Label" runat="server"><a href="../CustomerInfo/Index.aspx?channel=97b851381117d8131466b420b991aeeb">
                                                            <asp:Label ID="lblB2CNext1" CssClass="Label" runat="server" Text=" »»»Chuyển kênh»»»" Font-Size="11px" ForeColor="#00CC99" Font-Bold="False" BackColor="#0C6491"></asp:Label></a></asp:Label>


                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </asp:Panel>
                                </td>
                                <td>
                                    <asp:Panel ID="PanelMGame" runat="server" BorderWidth="0">

                                        <div class="hover-border">
                                            <div class="media well hover-border-inner">
                                                <div class="media-body">
                                                    <div class="boxgrid slidedown">
                                                        <img src="Images/MGame.png" class="cover wp-post-image" alt="M - Game" />
                                                        <h2>DỊCH VỤ M-GAME</h2>
                                                        <p>
                                                            - Thông tin khách hàng
                            <br />
                                                            - Báo cáo phân tích, thống kê
                            <br />

                                                            <br />

                                                        </p>
                                                        <asp:Label ID="lblMGameNext" CssClass="Label" runat="server"><a href="../MGame/Index.aspx?channel=0822a4af199e03c209d05c239ed6eaad">
                                                            <asp:Label ID="lblMGameNext1" CssClass="Label" runat="server" Text=" »»»Chuyển kênh»»»" Font-Size="11px" ForeColor="#00CC99" Font-Bold="False" BackColor="#0C6491"></asp:Label></a></asp:Label>


                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="PanelKPI" runat="server" BorderWidth="0">
                                        <div class="hover-border">
                                            <div class="media well hover-border-inner">
                                                <div class="media-body">
                                                    <div class="boxgrid slidedown">
                                                        <img src="Images/KPI.gif" class="cover wp-post-image" alt="KPI" />
                                                        <h2>KEY PERFORMANCE INDICATOR</h2>
                                                        <p>
                                                            - Thông tin dịch vụ
                            <br />
                                                            - KPI Dịch vụ
                            <br />

                                                            <br />

                                                        </p>
                                                        <asp:Label ID="lblKPINext" CssClass="Label" runat="server"><a href="../KPI/Index.aspx?channel=988a403a115e4c6ebfd8efdf83864b0a">
                                                            <asp:Label ID="lblKPINext1" CssClass="Label" runat="server" Text=" »»»Chuyển kênh»»»" Font-Size="11px" ForeColor="#00CC99" Font-Bold="False" BackColor="#0C6491"></asp:Label></a></asp:Label>


                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </asp:Panel>
                                </td>
                                <td>
                                    <asp:Panel ID="PanelContract" runat="server" BorderWidth="0">
                                        <div class="hover-border">
                                            <div class="media well hover-border-inner">
                                                <div class="media-body">
                                                    <div class="boxgrid slidedown">
                                                        <img src="Images/contract.gif" class="cover wp-post-image" alt="KPI" />
                                                        <h2>HỢP ĐỒNG, CÔNG VĂN</h2>
                                                        <p>
                                                            - Quản lý hợp đồng dịch vụ
                            <br />
                                                            - Công văn đến, công văn đi
                            <br />

                                                            <br />

                                                        </p>
                                                        <asp:Label ID="lblContractNext" CssClass="Label" runat="server"><a href="../Contract/Index.aspx?channel=7ded01ff583d4f0a5a1212cec7dd1f4c">
                                                            <asp:Label ID="lblContractNext1" CssClass="Label" runat="server" Text=" »»»Chuyển kênh»»»" Font-Size="11px" ForeColor="#00CC99" Font-Bold="False" BackColor="#0C6491"></asp:Label></a></asp:Label>


                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                    </asp:Panel>
                                </td>
                                <td></td>
                                <td></td>
                            </tr>
                            -->
                        </table>

                    </div>
                </div>
            </div>
            <!--End of content-->

        </div>
    </form>

</body>
</html>
