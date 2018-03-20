<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Viettel8x62RegisteredUsers.aspx.vb" Inherits="Prjs.Portal.Report.Viettel8x62RegisteredUsers" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="ASPnetPagerV2_8" Namespace="ASPnetControls" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../../Styles/HQ.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/LightStyle.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/RadTreeView.css" type="text/css" rel="stylesheet" />

    <script language="javascript" type="text/javascript" src="../../../Js/Menu3.js"></script>

    <style type="text/css">
        fieldset {
            display: block;
            border: 1px solid #BCDDAF;
            -moz-border-radius: 8px;
            -webkit-border-radius: 8px;
            border-radius: 8px;
        }

        legend {
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
                <telerik:AjaxSetting AjaxControlID="DropDownListMonth">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="DropDownListFromDate" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListToDate" />
                    </UpdatedControls>
                </telerik:AjaxSetting>

                <telerik:AjaxSetting AjaxControlID="RadDropListMobile_Operator">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="RadDropDownListService_Id" />
                    </UpdatedControls>
                </telerik:AjaxSetting>

            </AjaxSettings>
        </telerik:RadAjaxManager>
        <div id="HQ">
            <div class="alert">
                <asp:Label ID="lbltitle" runat="server" CssClass="lbltitle"></asp:Label><br />
                <asp:Label ID="lblerror" runat="server" CssClass="lblerror"></asp:Label>
            </div>


            <div class="input" style="width: 50%">
                <table width="100%">
                    <tr>
                        <td align="right" width="30%">
                            <asp:Label ID="lblTrang7" runat="server" CssClass="label">Từ ngày;</asp:Label>
                        </td>
                        <td align="left">
                            <telerik:RadDatePicker ID="RadDatePickerFromDate" Width="150px" runat="server" Skin="Hay" Culture="vi-VN">
                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" Skin="Hay"></Calendar>

                                <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                            </telerik:RadDatePicker>


                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblTrang8" runat="server" CssClass="label">Đến ngày:</asp:Label>
                        </td>
                        <td align="left">
                            <telerik:RadDatePicker ID="RadDatePickerToDate" Width="150px" runat="server" Skin="Hay" Culture="vi-VN">
                                <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x" Skin="Hay"></Calendar>

                                <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

                                <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                            </telerik:RadDatePicker>



                        </td>
                    </tr>
                    <tr>
                        <td align="right">&nbsp;</td>
                        <td align="left">
                            <asp:CheckBox ID="CheckBoxAllDate" runat="server" CssClass="checkbox" Text="Toàn thời gian" Checked="True" />



                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblTrang9" runat="server" CssClass="label">Dịch vụ:</asp:Label>
                        </td>
                        <td align="left">
                            <telerik:RadComboBox ID="RadDropDownListService_Id" runat="server" CheckBoxes="true" EnableCheckAllItemsCheckBox="True" Skin="Hay" Width="90%">
                                 <Localization AllItemsCheckedString="--all--" CheckAllString="--all--" />
                            </telerik:RadComboBox>


                        </td>
                    </tr>
                </table>
            </div>
            <div class="submmit">
                <asp:Button ID="btnSearch" runat="server" CssClass="btnbackground"
                    Text="Tìm kiếm" />
                <asp:Button ID="btnExport" runat="server" CssClass="btnbackground"
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
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
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

                       
                        <asp:TemplateColumn HeaderText="KHÁCH HÀNG">
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lbUser_ID" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "User_ID")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="ĐẦU SỐ">
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lbShort_Code" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Short_Code")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="MÃ DỊCH VỤ">
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblCommand_Code" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Command_Code")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="DỊCH VỤ">
                            <ItemStyle Width="40%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblService_Name" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Service_Name")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="KÊNH ĐĂNG KÝ">
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblTotalMoney" runat="server" ><%# DataBinder.Eval(Container.DataItem, "Registration_Channel")%>  </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="T/G ĐĂNG KÝ">
                            <ItemStyle Width="15%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                   <asp:Label ID="lblRegisteredTime" runat="server" CssClass="label"> <%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "RegisteredTime")).ToString("dd-MM-yyyy hh:mm:ss")%> </asp:Label>
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
