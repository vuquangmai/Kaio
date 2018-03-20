<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Banner.aspx.vb" Inherits="Prjs.Portal.Report.Administrator_Banner" %>

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
                   FrameSize = "165,12,*";
                   FrameStat = "Hide";
                   imgobj.src = catcollapseimg;
               }
               else {
                   FrameSize = "0,12,*";
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
                        <li><a href="../Index.aspx" target="MainFrame">HOME</a></li>
                       <li class="liselected" ><a href="../Administrator/Index.html?channel=1" target="MainFrame"    style="color: #666666">ADMMINISTRATOR</a></li>
                        <li><a href="../ScheduleOnline/Index.html?channel=2" target="MainFrame">LỊCH TRỰC</a></li>
                         <li><a href="../CallCenter/Index.html?channel=3" target="MainFrame">TỔNG ĐÀI</a></li>
                         <li><a href="../Correction/Index.html?channel=4" target="MainFrame">SỬA SAI</a></li>
                        <li><a href="../DiaryCCare/Index.html?channel=5" target="MainFrame">CHĂM SÓC K/H</a></li>
                          <li><a href="../Document/Index.html?channel=6" target="MainFrame">TÀI LIỆU</a></li>
                          <li><a href="../TeleSales/Index.html?channel=9" target="MainFrame">TELESALES</a></li>
                          <li><a href="../Grading/Index.html?channel=7" target="MainFrame">CHẤM ĐIỂM</a></li>
                        <li><a href="../SurveyInfo/Index.html?channel=12" target="_blank">SURVEY</a></li>
                          <li><a href="../Lingo/Index.html?channel=13" target="MainFrame" >LINGO</a></li>
                          <li><a href="../TestOnline/Index.html?channel=14" target="MainFrame" >TEST</a></li>
                        
                        <li><a href="#">HELP</a></li>
                    </ul>
                </div>
                <div class="bottom">
                   <div class="collapse">  <div  style="float: right; cursor: crosshair">
            <a href="JavaScript:Frame()"><img id="imgCat1"  alt="Hide" src="../Images/arrow-up.gif" /></a> 
        </div></div>
                    <asp:Label ID="lblCurrentTime" CssClass="RSS" runat="server">Thứ tư, 22-10-2014 </asp:Label>
                        
                        <div class="signout"> 
                           
                            <img alt="User Profile"  src="../Images/door-out-icon.png" width="15px"/>
                              <a target="_top" class="signout" href="/login.aspx"><asp:Label ID="lblSignOut" CssClass="contact" runat="server"> Sign out</asp:Label></a>
                        </div>
                           <div class="signout"> 
                           
                            <img alt="User Profile"  src="../Images/Clock-icon.png" width="15px"/>
                              <a target="_top" class="signout" href="#"><asp:Label ID="lblLastLogin" CssClass="contact" runat="server"></asp:Label></a>
                        </div>
                           <div class="signout"> 
                           
                            <img alt="User Profile"  src="../Images/Profile-icon.png" width="15px"/>
                              <a target="_top" class="signout" href="#"><asp:Label ID="lblUserName" CssClass="contact" runat="server"></asp:Label></a>
                        </div>
                    </div>
            </div>
        </div>
    </form>
</body>
</html>
