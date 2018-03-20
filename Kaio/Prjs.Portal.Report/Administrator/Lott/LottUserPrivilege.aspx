<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="LottUserPrivilege.aspx.vb" Inherits="Prjs.Portal.Report.LottUserPrivilege" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
  <link href="../../Styles/HQ.css" rel="stylesheet" type="text/css" />
         <link href="../../Styles/RadTreeView.css" type="text/css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
     <div id="HQ">
          <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
    </telerik:RadStyleSheetManager>
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Transparency="30"
        MinDisplayTime="500">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager ID="AjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
    </telerik:RadAjaxManager>
  <div class="alert">
                   <asp:Label ID="lbltitle" runat="server" CssClass="lbltitle"></asp:Label> <br />
                 <asp:Label ID="lblerror" runat="server" CssClass="lblerror"></asp:Label>
            </div>
  <div  >
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
         
            <tr>
                <td align="center">
                    <asp:Image ID="imgroup" runat="server" ImageUrl="../../Images/Accept-Male-User-icon.png" />
                    <asp:Label ID="lblUser" runat="server" CssClass="label_title_object"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <td width="45%" align="left">
                                <asp:Label ID="Label1" runat="server" CssClass="label_title_treeview">» Danh mục các tỉnh được nhập kết quả</asp:Label>
                            </td>
                            <td>
                            </td>
                            <td width="45%" align="left">
                                <asp:Label ID="Label2" runat="server" CssClass="label_title_treeview">» Danh mục các tỉnh chưa được nhập kết quả</asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="left">
                                <telerik:RadTreeView runat="server" ID="RadTreeViewUrlActive" DataFieldID="ID"
                                    DataFieldParentID="Parent_Id" Skin="Hay" CheckBoxes="True" TriStateCheckBoxes="true"
                                    CheckChildNodes="true" Font-Names="Arial" Font-Size="8pt" >
                                    <DataBindings>
                                        <telerik:RadTreeNodeBinding TextField="Company_Name" ValueField="ID" />
                                    </DataBindings>
                                    <CollapseAnimation Duration="100" Type="OutQuint" />
                                    <ExpandAnimation Duration="100" />
                                </telerik:RadTreeView>
                            </td>
                            <td valign="top">
                            </td>
                            <td valign="top" align="left">
                                <telerik:RadTreeView runat="server" ID="RadTreeViewUrlDeactive" DataFieldID="ID"
                                       DataFieldParentID="Parent_Id" Skin="Hay" CheckBoxes="True" TriStateCheckBoxes="true"
                                    CheckChildNodes="true" Font-Names="Arial" Font-Size="8pt" >
                                    <DataBindings>
                                        <telerik:RadTreeNodeBinding TextField="Company_Name" ValueField="ID" />
                                    </DataBindings>
                                    <CollapseAnimation Duration="100" Type="OutQuint" />
                                    <ExpandAnimation Duration="100" />
                                </telerik:RadTreeView>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Button ID="btnCancel" runat="server" CssClass="btnbackground" Text="Gỡ bỏ" />
                            </td>
                            <td align="left">
                            </td>
                            <td align="left">
                                <asp:Button ID="btnUpdate" runat="server" CssClass="btnbackground" Text="Thêm menu" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="lblErorr1" runat="server" CssClass="lblerror"></asp:Label>
                            </td>
                            <td align="center">
                            </td>
                            <td align="left">
                                <asp:Label ID="lblErorr2" runat="server" CssClass="lblerror"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
            </div>
    
    </div>
    </form>
</body>
</html>