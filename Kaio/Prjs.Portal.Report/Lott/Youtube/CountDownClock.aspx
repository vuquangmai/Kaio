<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CountDonwClock.aspx.vb" Inherits="Prjs.Portal.Report.CountDonwClock" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../Scripts/jquery-1.7.1.min.js"></script>
		<script src="flipclock.js"></script>
   	<link rel="stylesheet" href="flipclock.css" />

</head>
<body>

    <form id="form1" runat="server">
     	<div class="clock" style="margin:2em;"></div>
	<div class="message"></div>

	<script type="text/javascript">
    
	    var offset = 0;
	    var now = new Date();
	    var date1815 = new Date(now.getFullYear(), now.getMonth(), now.getDate(), 18, 15, 0, 0);
	    var date1830 = new Date(now.getFullYear(), now.getMonth(), now.getDate(), 18, 30, 0, 0);
	    var date2400 = new Date(now.getFullYear(), now.getMonth(), now.getDate(), 23, 59, 59, 0);
	    var date0000 = new Date(now.getFullYear(), now.getMonth(), now.getDate(), 0, 0, 0, 0);
	    var T1 = date1815.getTime() - now.getTime();
	    var T2 = date1830.getTime() - now.getTime();
	    if (T1 > 0)//Nếu thời gian hiện tại chưa đến thời điểm bắt đầu quay kết quả
	    {
	        offset = T1;
	    } else if (T2 > 0)//  Nếu đang trong khoảng thời gian quay kết quả
	    {
	        offset = 0;
	    } else// Nếu đã quay xong
	    {

	        var T3 = date2400.getTime() - now.getTime();
	        var T4 = date1815.getTime() - date0000.getTime();
	        offset = (T3 + T4);
	    }



	    var clock;
		$(document).ready(function() {
			var clock;

			clock = $('.clock').FlipClock({
		        clockFace: 'DailyCounter',
		        autoStart: false,
		        callbacks: {
		        	stop: function() {
		        	    $('.message').html('The clock has stopped!')
		        	    $('.clock').hide();
		        	}
		        }
		    });
				    
			clock.setTime(3000);
		    clock.setCountdown(true);
		    clock.start();

		});
	</script>
   
    </form>
</body>
</html>
