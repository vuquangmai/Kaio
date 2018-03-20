<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SplitOut.aspx.vb" Inherits="Prjs.Portal.Report.a" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
<body bgcolor="#BBDDAE">
    <form id="form1" runat="server">
     
      <div  style="float: right; cursor: crosshair">
            <a href="JavaScript:Frame()"><img id="imgCat1"  alt="Hide" src="../Images/arrow-up.gif" /></a> 
        </div>
     
    </form>
</body>
</html>
