<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Clock.aspx.vb" Inherits="Prjs.Portal.Report.Clock" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    	<link rel="stylesheet" href="compiled/flipclock.css" />
    	<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
    	<script src="compiled/flipclock.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    	<div class="clock" style="margin:2em;"></div>
	<div class="message"></div>

	<script type="text/javascript">
		var clock;
		
		$(document).ready(function() {
			var clock;

			clock = $('.clock').FlipClock({
		        clockFace: 'DailyCounter',
		        autoStart: false,
		        callbacks: {
		        	stop: function() {
		        		$('.message').html('The clock has stopped!')
		        	}
		        }
		    });
				    
		    clock.setTime(220880);
		    clock.setCountdown(true);
		    clock.start();

		});
	</script>
	
    </div>
    </form>
</body>
</html>
