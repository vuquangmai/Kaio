<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CCareImportUserComplete1.aspx.vb" Inherits="Prjs.Portal.Report.CCareImportUserComplete1" %>
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
          background: #377F44;
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
            <div class="input" style="border-width: 0px; width: 98%; background-color: #FFFFFF;">
                   <fieldset id="fieldsetBound">
                       <legend>
                        <asp:Label ID="Label1" runat="server" CssClass="lblerror" ForeColor="White">THÔNG TIN IMPORT</asp:Label></legend>
                   <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                        <tr>
                            <td align="right" width="15%">
                                <asp:Label ID="Label26" runat="server" CssClass="label">File dữ liệu:</asp:Label>
                            </td>
                            <td align="left" width="35%">
                                <cc2:FilePicker ID="txtUserFile" runat="server" CssClass="txtContent" fpAllowedUploadFileExts="" fpPopupURL="../../FilePicker/FilePicker.aspx" fpPopupWidth="600" Width="80%"></cc2:FilePicker>
                            </td>
                            <td width="15%" align="right">
                                <asp:Label ID="Label6" runat="server" CssClass="label">Đối tác:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DropDownListPARTNER_ID" runat="server" CssClass="droplist" Font-Bold="True" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                <asp:Label ID="Label45" runat="server" CssClass="label">Sheet:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtSheet" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="20%" Font-Bold="False">Sheet1</asp:TextBox>
                            </td>
                            <td width="15%" align="right">
                                <asp:Label ID="Label3" runat="server" CssClass="label">Brand name:</asp:Label>
                            </td>
                            <td align="left">

                                <asp:DropDownList ID="DropDownListBRAND_NAME" runat="server" CssClass="droplist" AutoPostBack="True">
                                    <asp:ListItem Value="0">--Chọn--</asp:ListItem>
                                </asp:DropDownList>

                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                <asp:Label ID="Label43" runat="server" CssClass="label">Nhóm khách hàng:</asp:Label>
                            </td>
                            <td align="left">

                                <asp:TextBox ID="txtGROUP_TEXT" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="50%" Font-Bold="True"></asp:TextBox>

                            </td>
                            <td width="15%" align="right">
                                <asp:Label ID="Label27" runat="server" CssClass="label">Nguồn dữ liệu:</asp:Label>
                            </td>
                            <td align="left">

                                <asp:DropDownList ID="DropDownListSOURCE_ID" runat="server" CssClass="droplist" AutoPostBack="True">
                                </asp:DropDownList>

                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                <asp:Label ID="Label4" runat="server" CssClass="label">Từ khóa:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtKEY_WORD" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="50%" Font-Bold="True"></asp:TextBox>
                            </td>
                            <td width="15%" align="right">
                                &nbsp;</td>
                            <td align="left">

                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                <asp:Label ID="Label29" runat="server" CssClass="label">Nội dung MT:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtMT" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                    Width="100%" Font-Bold="False" Height="36px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td width="15%" align="right">
                                &nbsp;</td>
                            <td align="left">

                                     &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                <asp:Label ID="Label7" runat="server" CssClass="label">Ngành hàng:</asp:Label>
                            </td>
                            <td align="left" colspan="3">

                                <asp:CheckBoxList ID="CheckBoxListFIELD_ID" runat="server" CssClass="checkbox" RepeatColumns="8">
                                </asp:CheckBoxList>

                            </td>
                        </tr>
                        
                    </table>
                </fieldset>
                <div class="submmit">
                    <asp:Button ID="btnUpdate" runat="server" CssClass="btnbackground"
                        Text="Import" />
                    <asp:Button ID="btnExport" runat="server" CssClass="btnbackground"
                        Text="Báo cáo" />
                </div>
                <fieldset id="fieldset2">
                    <legend>
                        <asp:Label ID="Label9" runat="server" CssClass="lblerror" ForeColor="White">FILE ĐÃ IMPORT</asp:Label></legend>
                    <div class="pager">
                        <cc1:PagerV2_8 ID="pager1" runat="server" OnCommand="pager_Command" GenerateGoToSection="true"
                            Font-Size="10pt" PageSize="100" />

                    </div>
                    <div class="datagrid">
                        <asp:DataGrid ID="DataGrid" runat="server" AllowPaging="True" AutoGenerateColumns="false"
                            CellPadding="0" CssClass="datagrid" EnableViewState="False" GridLines="None"
                            PagerStyle-Mode="NextPrev" PagerStyle-Visible="true" Width="100%" PageSize="100">
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
                                <asp:TemplateColumn HeaderText="NỘI DUNG MT">
                                    <ItemStyle Width="30%" HorizontalAlign="Left" />
                                    <ItemTemplate>
                                       <a     href="#" title= '<%# DataBinder.Eval(Container.DataItem, "MTFull")%>'><asp:Label ID="lblMT" runat="server" CssClass="label"> <%# DataBinder.Eval(Container.DataItem, "MT")%></asp:Label></a> 
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                     <asp:TemplateColumn HeaderText="TỪ KHÓA">
                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblKEY_IMPORT" runat="server" CssClass="label">  <%# DataBinder.Eval(Container.DataItem, "KEY_WORD")%></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                     <asp:TemplateColumn HeaderText="NHÓM">
                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblGROUP_TEXT" runat="server" CssClass="label">  <%# DataBinder.Eval(Container.DataItem, "GROUP_TEXT")%></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                     <asp:TemplateColumn HeaderText="THỜI GIAN IMPORT">
                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCREATE_TIME" runat="server" CssClass="label">  <%# DataBinder.Eval(Container.DataItem, "CREATE_TIME")%></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="NGƯỜI IMPORT">
                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCREATE_BY_TEXT" runat="server" CssClass="label">  <%# DataBinder.Eval(Container.DataItem, "CREATE_BY_TEXT")%></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>

                                <asp:TemplateColumn HeaderText="TRẠNG THÁI FILE">
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFILE_STATUS_TEXT" runat="server" CssClass="label"  ForeColor="#ff3300"> <%# DataBinder.Eval(Container.DataItem, "FILE_STATUS_TEXT")%></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                   <asp:TemplateColumn HeaderText="TÊN FILE">
                                    <ItemStyle HorizontalAlign="Right" Width="15%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblFILE_IMPORT" runat="server" CssClass="label" > <%# DataBinder.Eval(Container.DataItem, "FILE_IMPORT")%></asp:Label>
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
                </fieldset>
            </div>
            </div>
    </form>
</body>
</html>
