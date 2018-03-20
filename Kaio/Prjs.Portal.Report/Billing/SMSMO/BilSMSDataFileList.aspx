<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BilSMSDataFileList.aspx.vb" Inherits="Prjs.Portal.Report.BilSMSDataFileList" %>
<%@ Register Assembly="ASPnetPagerV2_8" Namespace="ASPnetControls" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../Styles/HQ.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/LightStyle.css" rel="stylesheet" type="text/css" />

    </head>
<body>
    <form id="form1" runat="server">
        <telerik:RadStyleSheetManager ID="RadStyleSheetManager1" runat="server">
        </telerik:RadStyleSheetManager>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
        </telerik:RadScriptManager>
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Transparency="30"
            MinDisplayTime="500">
        </telerik:RadAjaxLoadingPanel>
        <telerik:RadAjaxManager ID="AjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="DropDownListWeek">
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="RadGrid">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadGrid" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <div id="HQ">
            <div class="alert">
                <asp:Label ID="lbltitle" runat="server" CssClass="lbltitle"></asp:Label><br />
                <asp:Label ID="lblerror" runat="server" CssClass="lblerror"></asp:Label>
            </div>
            <div class="input" style="width: 90%">
                <table border="0" cellpadding="2" cellspacing="1" style="width: 100%">
                    <tr>
                        <td align="right" width="10%">
                            <asp:Label ID="Label7" runat="server" CssClass="label">Năm:</asp:Label>
                        </td>
                        <td align="left" width="40%">
                            <asp:DropDownList ID="DropDownListYear" runat="server" CssClass="droplist">
                            </asp:DropDownList>
                        </td>
                        <td align="right" width="15%">
                            <asp:Label ID="Label29" runat="server" CssClass="label">Số hợp đồng:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtContract_Number" runat="server" AutoCompleteType="Disabled" CssClass="txtContent" Width="80%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label26" runat="server" CssClass="label">Tháng:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListMonth" runat="server" CssClass="droplist" AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label30" runat="server" CssClass="label">Mã hợp đồng:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtContract_Code" runat="server" AutoCompleteType="Disabled" CssClass="txtContent" Width="80%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label31" runat="server" CssClass="label">Phòng ban:</asp:Label>
                        </td>
                        <td align="left">
                                        <asp:DropDownList ID="DropDownListDepartment_Id" runat="server" CssClass="droplist" AutoPostBack="True">
                                            <asp:ListItem>--all--</asp:ListItem>
                                        </asp:DropDownList>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label28" runat="server" CssClass="label">Đối tác (nhập):</asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtPartner_Text" runat="server" AutoCompleteType="Disabled" CssClass="txtContent" Width="80%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label27" runat="server" CssClass="label">Đối tác (chọn):</asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListPartner_Id" runat="server" CssClass="droplist" Font-Bold="False">
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            &nbsp;</td>
                        <td align="left">

                            &nbsp;</td>
                    </tr>
                    </table>
            </div>
            <div class="submmit">
                <asp:Button ID="btnSearching" runat="server" CssClass="btnbackground"
                    Text="Tìm kiếm" />
                <asp:Button ID="btnExp" runat="server" CssClass="btnbackground"
                    Text="Báo cáo" />
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
                        <asp:TemplateColumn HeaderText="THÁNG">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblYear" runat="server" CssClass="label" Font-Bold="true">   <%# DataBinder.Eval(Container.DataItem, "Month")%> </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="ĐỐI TÁC">
                            <ItemStyle Width="20%" HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label ID="lblPartner_Text" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Partner_Text")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="MÃ ĐỐI TÁC">
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblPartner_Code" runat="server" CssClass="label" Font-Bold="true">   <%# DataBinder.Eval(Container.DataItem, "Partner_Code")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="MÃ HỢP ĐỒNG">
                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                            <ItemTemplate>
                                <asp:Label ID="lblContract_Code" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Contract_Code")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                       
                        <asp:TemplateColumn HeaderText="FILE TẠM TÍNH">
                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                            <ItemTemplate>
                               
                                            <a href='../..<%# Eval("File_Url") %>'  title="Download"> <asp:Label ID="lblFile_Name_1" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "File_Name_1")%></asp:Label> </a> 
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="FILE QUYẾT TOÁN">
                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                            <ItemTemplate>

                                                                <asp:Label ID="lblFile_Name_2" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "File_Name_2")%></asp:Label>

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
