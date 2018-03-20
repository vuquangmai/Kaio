<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Menuleft.aspx.vb" Inherits="Prjs.Portal.Report.ContractInfo_Menuleft" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
      <link href="../Styles/HQ.css" type="text/css" rel="stylesheet" />
      <link href="../Styles/RadTreeView.css" type="text/css" rel="stylesheet" />
    
</head>
<body bgcolor="#BCDDAF"   >
    <form id="form1" runat="server">
    <div>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <div>
       <telerik:RadTreeView ID="RadMenuList" runat="server" DataFieldID="ID" 
                    DataFieldParentID="Parent_Id" SingleExpandPath="true" Skin="Telerik" 
                    Font-Bold="False" Font-Names="Arial" ForeColor="#333333"
                    Font-Size="8pt">
                    <DataBindings>
                        <telerik:RadTreeNodeBinding TextField="Url_Text" ImageUrlField="Url_Image"/>
                        <telerik:RadTreeNodeBinding Depth="1" NavigateUrlField="Url_Id" Target="contentFrame"  TextField="Url_Text" />
                         
                    </DataBindings>
                    <CollapseAnimation Duration="100" Type="OutQuint" />
                    <ExpandAnimation Duration="100" />
                </telerik:RadTreeView>
        </div>
      
       </div>
    </form>
</body>
</html>
