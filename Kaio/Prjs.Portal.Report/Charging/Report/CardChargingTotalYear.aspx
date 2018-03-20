<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CardChargingTotalYear.aspx.vb" Inherits="Prjs.Portal.Report.CardChargingTotalYear" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="ASPnetPagerV2_8" Namespace="ASPnetControls" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../Styles/HQ.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/LightStyle.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/RadTreeView.css" type="text/css" rel="stylesheet" />
   
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

            </AjaxSettings>
        </telerik:RadAjaxManager>
        <div id="HQ">
            <div class="alert">
                <asp:Label ID="lbltitle" runat="server" CssClass="lbltitle"></asp:Label><br />
                <asp:Label ID="lblerror" runat="server" CssClass="lblerror"></asp:Label>
            </div>
            <div class="input">
                   <table width="100%">
                                <tr>
                                    <td align="right" width="15%">
                                        <asp:Label ID="lblTrang7" runat="server" CssClass="label">Năm:</asp:Label>
                                    </td>
                                    <td align="left" width="35%">
                                        <asp:DropDownList ID="DropDownListYear" runat="server" CssClass="droplist">
                                            <asp:ListItem>2015</asp:ListItem>
                                            <asp:ListItem>2016</asp:ListItem>
                                            <asp:ListItem>2017</asp:ListItem>
                                            <asp:ListItem>2018</asp:ListItem>
                                            <asp:ListItem>2019</asp:ListItem>
                                            <asp:ListItem>2020</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="right" width="15%">
                                        <asp:CheckBox ID="CheckBoxCard_Type" runat="server" CssClass="checkbox" Text="Loại thẻ:"
                                            TextAlign="Left" />
                                    </td>
                                    <td align="left">
                                        <telerik:RadComboBox ID="RadDropDownListCard_Type" runat="server" CheckBoxes="true" EnableCheckAllItemsCheckBox="True" Skin="Hay" Width="150px">
                                            <CollapseAnimation Type="None" />
                                            <Localization AllItemsCheckedString="--all--" CheckAllString="--all--" />
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblTrang12" runat="server" CssClass="label">Trạng thái:</asp:Label>
                                    </td>
                                    <td align="left">
                                 
                                        <telerik:RadComboBox ID="RadDropDownListStatus" runat="server" Skin="Hay" Width="100px">
                                            <Items>
                                                <telerik:RadComboBoxItem Text="Thành công" Value="0" />
                                                <telerik:RadComboBoxItem Text="Lỗi" Value="1" />
                                            </Items>
                                        </telerik:RadComboBox>
                                     
                                    </td>
                                    <td align="right">
                                        <asp:CheckBox ID="CheckBoxPartner" runat="server" CssClass="checkbox" Text="Đối tác:"
                                            TextAlign="Left" />
                                    </td>
                                    <td align="left">
                                        <telerik:RadComboBox ID="RadDropDownListPartner" runat="server" CheckBoxes="true" EnableCheckAllItemsCheckBox="True" Skin="Hay" Width="80%">
                                            <Items>
                                                <telerik:RadComboBoxItem Text="VIETTEL" Value="VIETTEL" />
                                                <telerik:RadComboBoxItem Text="VMS" Value="VMS" />
                                                <telerik:RadComboBoxItem Text="VNP" Value="VNP" />
                                                <telerik:RadComboBoxItem Text="VNM" Value="VNM" />
                                                <telerik:RadComboBoxItem Text="GTEL" Value="GTEL" />
                                            </Items>
                                            <Localization AllItemsCheckedString="--all--" CheckAllString="--all--" />
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:CheckBox ID="CheckBoxMonth" runat="server" CssClass="checkbox" Text="Tháng:"
                                            TextAlign="Left" />
                                    </td>
                                    <td align="left" width="35%">
                                        <telerik:RadComboBox ID="RadDropDownListMonth" runat="server" CheckBoxes="True" EnableCheckAllItemsCheckBox="True" Skin="Hay" Width="70px" >
                                               <Items>
                                                <telerik:RadComboBoxItem Text="1" Value="01" />
                                                <telerik:RadComboBoxItem Text="2" Value="02" />
                                                <telerik:RadComboBoxItem Text="3" Value="03" />
                                                <telerik:RadComboBoxItem Text="4" Value="04" />
                                                <telerik:RadComboBoxItem Text="5" Value="05" />
                                                <telerik:RadComboBoxItem Text="6" Value="06" />
                                                <telerik:RadComboBoxItem Text="7" Value="07" />
                                                <telerik:RadComboBoxItem Text="8" Value="08" />
                                                <telerik:RadComboBoxItem Text="9" Value="09" />
                                                <telerik:RadComboBoxItem Text="10" Value="10" />
                                                <telerik:RadComboBoxItem Text="11" Value="11" />
                                                <telerik:RadComboBoxItem Text="12" Value="12" />
                                            </Items>
                                            <Localization AllItemsCheckedString="--all--" CheckAllString="--all--" />
                                        </telerik:RadComboBox>
                                     
                                    </td>
                                    <td align="right">
                                        <asp:CheckBox ID="CheckBoxChannel" runat="server" CssClass="checkbox" Text="Kênh:"
                                            TextAlign="Left" />
                                    </td>
                                    <td align="left">
                                        <telerik:RadComboBox ID="RadDropDownListChannel" runat="server" CheckBoxes="True" EnableCheckAllItemsCheckBox="True" Skin="Hay" Width="90px" AutoPostBack="True">
                                            <Items>
                                                <telerik:RadComboBoxItem runat="server" Text="VTT" Value="VTT" />
                                                <telerik:RadComboBoxItem runat="server" Text="VMS" Value="VMS" />
                                                <telerik:RadComboBoxItem runat="server" Text="VNP" Value="VMS" />
                                                <telerik:RadComboBoxItem runat="server" Text="VNM" Value="VNM" />
                                                   </Items>
                                            <Localization AllItemsCheckedString="--all--" CheckAllString="--all--" />
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        &nbsp;</td>
                                    <td align="left">
                                    
                                        &nbsp;</td>
                                    <td align="right">
                                        <asp:CheckBox ID="CheckBoxPriceUnit" runat="server" CssClass="checkbox" Text="Mệnh giá thẻ:"
                                            TextAlign="Left" />
                                    </td>
                                    <td align="left">
                                        
                                                <telerik:RadComboBox ID="RadDropDownListPriceUnit" runat="server" CheckBoxes="true" EnableCheckAllItemsCheckBox="True" Skin="Hay" Width="90px">
                                                      <Items>
                                                <telerik:RadComboBoxItem runat="server" Text="10.000" Value="10000" />
                                                <telerik:RadComboBoxItem runat="server" Text="20.000" Value="20000" />
                                                <telerik:RadComboBoxItem runat="server" Text="30.000" Value="30.000" />
                                                <telerik:RadComboBoxItem runat="server" Text="50.000" Value="50.000" />
                                                <telerik:RadComboBoxItem runat="server" Text="100.000" Value="100000" />
                                                <telerik:RadComboBoxItem runat="server" Text="200.000" Value="200000" />
                                                <telerik:RadComboBoxItem runat="server" Text="500.000" Value="500000" />
                                                   </Items>
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
                            <asp:TemplateColumn HeaderText="ĐỐI TÁC">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblDepartment_Text" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "vSubcp_name")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="NĂM">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblvYear" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "vYear")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="THÁNG">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblvMonth" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "vMonth")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                  
                              <asp:TemplateColumn HeaderText="LOẠI THẺ">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblvCardName" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "vCardName")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="KÊNH">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblvChannel" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "vChannel")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="TRẠNG THÁI">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblvStatus" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "vStatus")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>

                        <asp:TemplateColumn HeaderText="MỆNH GIÁ">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblvCardAmount" runat="server" CssClass="label" Font-Bold="true"> <%# DataBinder.Eval(Container.DataItem, "vCardAmount")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="SỐ LƯỢNG">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblvTotal_Card" runat="server" CssClass="label" Font-Bold="true">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "vTotal_Card"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="DOANH THU">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblvTotal_Amount" runat="server" CssClass="label" Font-Bold="true" >   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "vTotal_Amount"), 0)%></asp:Label>
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
