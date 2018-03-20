<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CCareImportBlackList.aspx.vb" Inherits="Prjs.Portal.Report.CCareImportBlackList" %>
<%@ Register Assembly="FilePickerControl" Namespace="AWS.FilePicker" TagPrefix="cc2" %>
<%@ Register Assembly="ASPnetPagerV2_8" Namespace="ASPnetControls" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../../Styles/HQ.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/LightStyle.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        fieldset
        {
            display: block;
            border: 1px solid #BCDDAF;
            -moz-border-radius: 8px;
            -webkit-border-radius: 8px;
            border-radius: 8px;
        }

        legend
        {
            background: #FF9;
            border: solid 1px green;
            -webkit-border-radius: 8px;
            -moz-border-radius: 8px;
            border-radius: 8px;
        }

        </style>
</head>
<body>
    <form id="form1" runat="server">
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Transparency="30"
            MinDisplayTime="500">
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            </telerik:RadScriptManager>
        </telerik:RadAjaxLoadingPanel>
        <telerik:RadAjaxManager ID="AjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="DropDownListPARTNER_ID">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="DropDownListBRAND_NAME" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="DropDownListPROVINCE_ID">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="DropDownListDISTRICT_ID" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <div id="HQ">
            <div class="alert">
                <asp:Label ID="lbltitle" runat="server" CssClass="lbltitle"></asp:Label><br />
                <asp:Label ID="lblerror" runat="server" CssClass="lblerror"></asp:Label>
            </div>
          
                 
              
                 <div class="input">
                <table border="0" cellpadding="2" cellspacing="1" style="width: 100%">
                    <tr>
                        <td align="right" width="20%">
                            <asp:Label ID="Label7" runat="server" CssClass="label">File Import:</asp:Label>
                        </td>
                        <td align="left">
                                <cc2:FilePicker ID="txtUserFile" runat="server" CssClass="txtContent" fpAllowedUploadFileExts="" fpPopupURL="../../FilePicker/FilePicker.aspx" fpPopupWidth="600" Width="80%"></cc2:FilePicker>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="20%">
                                <asp:Label ID="Label45" runat="server" CssClass="label">Sheet:</asp:Label>
                        </td>
                        <td align="left">
                                <asp:TextBox ID="txtSheet" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="10%" Font-Bold="False">Sheet1</asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label9" runat="server" CssClass="label">Ghi chú:</asp:Label>
                        </td>
                        <td align="left">
                                <asp:TextBox ID="txtDescription" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="80%" Font-Bold="False" Height="30px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="submmit">
                <asp:Button ID="btnImport" runat="server" CssClass="btnbackground"
                    Text="Ghi lại" />
                <asp:Button ID="btnReturn" runat="server" CssClass="btnbackground"
                    Text="Quay ra" />
            </div>
              
             
                    <div class="pager">
                <cc1:PagerV2_8 ID="pager1" runat="server" OnCommand="pager_Command" GenerateGoToSection="true"
                    Font-Size="10pt" PageSize="50" />

            </div>
            <div class="datagrid">
                  <asp:DataGrid ID="DataGrid" runat="server" AllowPaging="True" AutoGenerateColumns="false"
                    CellPadding="0" CssClass="datagrid" EnableViewState="False" GridLines="None"
                    PagerStyle-Mode="NextPrev" PagerStyle-Visible="true" Width="100%" PageSize="50">
                    <HeaderStyle CssClass="datagridHeader" />
                    <AlternatingItemStyle CssClass="datagridAlternatingItemStyle" />
                    <ItemStyle CssClass="datagridItemStyle" />
                    <Columns>
                        <asp:TemplateColumn>
                            <HeaderStyle HorizontalAlign="Center" Width="2%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderTemplate>
                                #
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblOrder" runat="server" CssClass="label"
                                    Text='<%# Container.ItemIndex+1 %>'>
                                </asp:Label>
                            </ItemTemplate>

                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="SỐ ĐIỆN THOẠI">
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblUSER_ID" runat="server" CssClass="label" Font-Bold="true">   <%# DataBinder.Eval(Container.DataItem, "USER_ID")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="MẠNG">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <asp:Label ID="lblMOBILE_OPERATOR" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "MOBILE_OPERATOR")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                           <asp:TemplateColumn HeaderText="NGƯỜI CẬP NHẬT">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <asp:Label ID="lblUPDATE_BY_TEXT" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "UPDATE_BY_TEXT")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>

                        <asp:TemplateColumn HeaderText="THỜI GIAN CẬP NHẬT">
                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                            <ItemTemplate>

                                <asp:Label ID="lblUPDATE_TIME" runat="server" CssClass="label"><%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "UPDATE_TIME")).ToString("dd-MM-yyyy")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="GHI CHÚ">
                            <ItemStyle HorizontalAlign="Left" Width="40%" />
                            <ItemTemplate>
                                <asp:Label ID="lblDESCRIPTION" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "DESCRIPTION")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn>
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderTemplate>
                                SỬA
                            </HeaderTemplate>
                            <ItemTemplate>
                                <a class="datagridLinks" title="Sửa đổi" href='CcareDictIndexRefuseEdit.aspx?objid=<%# Utils.EncryptText(DataBinder.Eval(Container.DataItem, "ID")) %>'>
                                    <img border="0" src="/images/comment-edit-icon.png">
                                </a>
                            </ItemTemplate>

                        </asp:TemplateColumn>
                        <asp:TemplateColumn>
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderTemplate>
                                XÓA
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="deleter" runat="server" title="Xóa" BorderStyle="None"
                                    CausesValidation="False" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID")%>'
                                    ImageAlign="absmiddle" ImageUrl="~/Images/del.gif" OnCommand="DelData" />
                            </ItemTemplate>

                        </asp:TemplateColumn>
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" NextPageText="" PageButtonCount="5" PrevPageText=""
                        Visible="False" />
                </asp:DataGrid>

            </div>
              
             
            </div>
    </form>
</body>
</html>