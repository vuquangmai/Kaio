 function bgOn(Obj,bdcolor,bgcolor)
 {
  Obj.style.border=bdcolor;
  Obj.style.backgroundColor=bgcolor;
 }

 function bgOff(Obj,bdcolor,bgcolor)
 {
  Obj.style.border=bdcolor;
  Obj.style.backgroundColor=bgcolor;
 }

 function changeBg(Obj, strCssClass)
 {
	Obj.className = strCssClass;
 }

 function SPB()
 {
  //formExplorer.ProgressBar.src = "progress.gif";
  setTimeout('SPB()', 1250);
 }

 function ShowProgressBar(CallFunction)
 {

	//objPanelUpload = document.getElementById("PanelUpload");
    //objPanelUpload.style.display = "none";

	//objProgressBar = document.getElementById("ProgressBar");
	//objProgressBar.src = "progress.gif";
	//objProgressBar.style.display = "block";

    //formExplorer.ProgressBar.src = "progress.gif";	
    //formExplorer.ProgressBar.style.display = 'block';

	objProgressBarPanel = document.getElementById("ProgressBarPanel");
	objProgressBarPanel.style.display = "block";
    //ProgressBarPanel.style.display = 'block';

    setTimeout('SPB()', 1000);

  __doPostBack(CallFunction,'');
  
 }
 
    //-------------------------------------------------------------
    // Select all the checkboxes (Hotmail style)
    //-------------------------------------------------------------
    function SelectAllCheckboxes(theBox){
    
		xState=theBox.checked;    
        elm=theBox.form.elements;
        for(i=0;i<elm.length;i++)
        if(elm[i].type=="checkbox" && elm[i].id!=theBox.id)
            {
            //elm[i].click();
            if(elm[i].checked!=xState)
            elm[i].click();
            //elm[i].checked=xState;
            }
    }
