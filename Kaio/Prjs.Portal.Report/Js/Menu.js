var catimg = "../../Images/collapse_thead.gif";
var catcollapseimg = "../../Images/collapse_thead_collapsed.gif";
var mystatus = "cat";
var viewstack = new Array();
var mystack = new Array();
var viewtop = 0;
function showSubcat(id){//turn on|off sub-categories in top-level caterories 
	divobj = document.getElementById("divCat"+id);
	imgobj = document.getElementById("imgCat"+id);
	if (divobj.style.visibility=="visible"){
		divobj.style.visibility="hidden";
		divobj.style.display = "none";
		imgobj.src = catcollapseimg;
	} else {
		divobj.style.visibility="visible";
		divobj.style.display = "";
		imgobj.src = catimg;
	}
}//end of showSubcat
function catmHover(obj){
	obj.style.border = "1px solid #CCE6FF";
	obj.style.background = "#FFFFF0";
}
function catmOut(obj){
	obj.style.border = "";
	obj.style.background = "";
}
function showCat(id,page,txtsearch){
	if (!page) page =1;
	if (!txtsearch) txtsearch="";
	// find div Product
	obj = document.getElementById("divProduct");
	if (!obj) {
		return;
	}
	obj.style.visibility = "visible"; 
	obj.innerHTML = "Loading...";
	// find div Catalog
	obj = document.getElementById("divCatalog");
	if (!obj) {
		return;
	}
	obj.style.visibility = "visible";
	// save catid
	obj = document.getElementById("catid");
	if (obj) obj.value = id;
	// show products
	url = "../public/products.list.php?catid="+id+"&page="+page+"&search="+escape(txtsearch);
	getData(url, "divProduct");
	// show catalog
	url = "../public/categories.list.php?catid="+id;
	getDatax(url, "divCatalog");
}
function showProduct(id){
	obj = document.getElementById("divProduct");
	if (!obj) {
		return;
	}
	getData("../public/products.view.php?key="+id, "divProduct");
}//end of showProduct
function order(){
	q = document.getElementById("quantity");
	if (!q) return;
	if (parseInt(q.value)==0) {
		alert("Please enter the quantity !");
		q.focus();
		return;
	}
	p = document.getElementById("productid");
	if (!p) return;
	//window.location.href="product.order.php?id="+p.value+"&quantity="+q.value;
}
function showCatalog(){
	if (mystatus=="cat") return;
	objDiv = document.getElementById("divMain");
	objCat = document.getElementById("savedCatalog");
	objRes = document.getElementById("savedResources");
	if (objCat.value=="") {
		return;
	}
	objRes.value = objDiv.innerHTML;
	objDiv.innerHTML=objCat.value;
	mystatus = "cat";
}
function showResources(){
	if (mystatus=="res") return;
	objDiv = document.getElementById("divMain");
	objRes = document.getElementById("savedResources");
	objCat = document.getElementById("savedCatalog");
	objCat.value = objDiv.innerHTML;
	objDiv.innerHTML=objRes.value;
	if (document.getElementById("divContent").innerHTML=="") {
		getData("../public/news.topicitems.php", "divContent");
	}
	mystatus="res";
}
function showPSearch(txt, p){
	if (!p) p=1;
	obj = document.getElementById("divCatalog");
	if (!obj) return;
	obj.style.visibility = "visible";
	getData("../public/products.search.php?q="+txt+"&p="+p, "divProduct");
	getDatax("../public/products.search.pages.php?q="+txt+"&p="+p, "divCatalog");
}
function addStack(){
	viewtop+=1; 
	viewstack[viewtop] = document.getElementById("divMain").innerHTML;
	mystack[viewtop] = mystatus;
}
function viewBack(){
	if (viewtop==1) {
		window.location.reload();	
		return;
	}
	viewtop-=1;
	document.getElementById("divMain").innerHTML=viewstack[viewtop];
	mystatus = mystack[viewtop];
}