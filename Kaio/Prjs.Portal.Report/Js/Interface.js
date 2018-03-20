	var ImageLoaded=0;
	function LoadImages()
	{
		if (ImageLoaded==0) 
		{
			Normal=new Array;
			Normal[0] = new Image; Normal[0].src = "/Images/Lock_icon_nomal.gif";
			Normal[1] = new Image; Normal[1].src = "/Images/Apps_time_nomal.gif";
			Normal[2] = new Image; Normal[2].src = "/Images/Art_supplies_nomal.gif";
			Normal[3] = new Image; Normal[3].src = "/Images/Summer_group_nomal.gif";
			Normal[4] = new Image; Normal[4].src = "/Images/receptionist_nomal.gif";
			Normal[5] = new Image; Normal[5].src = "/Images/application_nomal.gif";
			Normal[6] = new Image; Normal[6].src = "/Images/Library_Folder.gif";
			Normal[7] = new Image; Normal[7].src = "/Images/DiaryCustomerCare.gif";
			Normal[9] = new Image; Normal[9].src = "/Images/TeleSales_normal.gif";
			Normal[10] = new Image; Normal[10].src = "/Images/ServiceInfo_nomal.gif";
			Normal[11] = new Image; Normal[11].src = "/Images/Alert_normal.gif";
			Normal[12] = new Image; Normal[12].src = "/Images/Survey_normal.gif";
			Normal[13] = new Image; Normal[13].src = "/Images/Lingo_normal.gif";
			Normal[14] = new Image; Normal[14].src = "/Images/Test_normal.gif";
			Normal[15] = new Image; Normal[15].src = "/Images/Ticket_normal.gif";
            MouseOver=new Array;
			MouseOver[0] = new Image; MouseOver[0].src = "/Images/Lock_icon_over.gif";
			MouseOver[1] = new Image; MouseOver[1].src = "/Images/Apps_time_over.gif";
			MouseOver[2] = new Image; MouseOver[2].src = "/Images/Art_supplies_over.gif";
			MouseOver[3] = new Image; MouseOver[3].src = "/Images/Summer_group_over.gif";
			MouseOver[4] = new Image; MouseOver[4].src = "/Images/receptionist_over.gif";
			MouseOver[5] = new Image; MouseOver[5].src = "/Images/application_over.gif";
			MouseOver[6] = new Image; MouseOver[6].src = "/Images/Library_Folder_over.gif";
			MouseOver[7] = new Image; MouseOver[7].src = "/Images/DiaryCustomerCare_over.gif";
			MouseOver[9] = new Image; MouseOver[9].src = "/Images/Telesales_over.gif";
			MouseOver[10] = new Image; MouseOver[10].src = "/Images/ServiceInfo_over.gif";
			MouseOver[11] = new Image; MouseOver[11].src = "/Images/Alert_over.gif";
			MouseOver[12] = new Image; MouseOver[12].src = "/Images/Survey_over.gif";
			MouseOver[13] = new Image; MouseOver[13].src = "/Images/Lingo_over.gif";
			MouseOver[14] = new Image; MouseOver[14].src = "/Images/Test_over.gif";
			MouseOver[15] = new Image; MouseOver[15].src = "/Images/Ticket_over.gif";

			ImageLoaded=1;
		}
	}
	function FunctionButtonMouseIn(image,index)
   {
		image.src=MouseOver[index].src;
		image.className="FunctionButtonOver";		
   }
	function FunctionButtonMouseOut(image,index)
   {
		image.src=Normal[index].src;
		image.className="FunctionButtonNormal";		
   }
   function CallAdminPage()
   {
       window.parent.location = "/Administrator/index.html?channel=1";
   }
   function CallSchedulePage()
   {
       window.parent.location = "/ScheduleOnline/index.html?channel=2";
   }
   function CallCenterPage() {
       window.parent.location = "/CallCenter/index.html?channel=3";
   }
   function CorrectionPage() {
       window.parent.location = "/Correction/index.html?channel=4";
   }
   function CallDiaryPage() {
       window.parent.location = "/DiaryCCare/index.html?channel=5";
   }
   function CallDocumentPage() {
       window.parent.location = "/Document/index.html?channel=6";
   }
   function CallTeleSalesPage() {
       window.parent.location = "/TeleSales/index.html?channel=9";
   } 
     function CallGradingPage()
   {
       window.parent.location = "/Grading/index.html?channel=7";
   }
   function CallServiceInfoPage() {
       window.parent.location = "/ServiceInfo/index.html?channel=10";
   }
   function CallAlertPage() {
       window.parent.location = "/NetAlerter/index.html?channel=11";
   }
   function CallSurveyPage() {
       window.parent.location = "/SurveyInfo/index.html?channel=12";
   }
   function CallLingoPage() {
       window.parent.location = "/Lingo/index.html?channel=13";
   }
   function CallTestOnlinePage() {
       window.parent.location = "/TestOnline/index.html?channel=14";
   }
   function CallTicketBrandPage() {
       window.parent.location = "/TicketBrand/index.html?channel=15";
   }
   function CallHelpPage() {
       window.parent.location = "/Insas/Documents/Customer Care's Portal .doc";
   } 