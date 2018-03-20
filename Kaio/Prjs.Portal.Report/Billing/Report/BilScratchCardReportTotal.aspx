<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BilScratchCardReportTotal.aspx.vb" Inherits="Prjs.Portal.Report.BilScratchCardReportTotal" %>
<%@ Register Assembly="ASPnetPagerV2_8" Namespace="ASPnetControls" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../../Styles/HQ.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/LightStyle.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../../Js/Menu.js"></script>

    <title>Untitled Page</title>
     
    </head>
<body>
    <form id="form1" runat="server">
         <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            </telerik:RadScriptManager>
        <telerik:RadAjaxManager ID="AjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="DropDownListPARTNER_ID">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="DropDownListBRAND_NAME" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="DropDownListPROVINCE_ID">
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
          <div id="HQ">
            
            <div class="alert">
                <asp:Label ID="lbltitle" runat="server" CssClass="lbltitle"></asp:Label><br />
                <asp:Label ID="lblerror" runat="server" CssClass="lblerror"></asp:Label>
            </div>
               <div class="parametter" style="width: 90%;">
                <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                        <tr>
                            <td align="right" width="10%">
                            <asp:Label ID="Label7" runat="server" CssClass="label">Năm:</asp:Label>
                            </td>
                            <td align="left" width="20%">
                            <asp:DropDownList ID="DropDownListYear" runat="server" CssClass="droplist">
                            </asp:DropDownList>
                            </td>
                            <td width="15%" align="right">
                                            <asp:CheckBox ID="CheckBoxTask_Id" runat="server" CssClass="checkbox" Text="Bước thực hiện:" TextAlign="Left" />
                            </td>
                            <td align="left">

                                <asp:DropDownList ID="DropDownListTask_Id" runat="server" CssClass="droplist">
                                </asp:DropDownList>

                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                            <asp:Label ID="Label26" runat="server" CssClass="label">Tháng:</asp:Label>
                            </td>
                            <td align="left">
                         
                                  <telerik:RadComboBox ID="DropDownListMonth" runat="server"   CheckBoxes="true" EnableCheckAllItemsCheckBox="True"     Width="70px"                                              Skin="WebBlue">
                                                    <Items>
                                                        <telerik:RadComboBoxItem Text="1" />
                                                        <telerik:RadComboBoxItem Text="2" />
                                                        <telerik:RadComboBoxItem Text="3" />
                                                        <telerik:RadComboBoxItem Text="4" />
                                                        <telerik:RadComboBoxItem Text="5"  />
                                                        <telerik:RadComboBoxItem Text="6" />
                                                        <telerik:RadComboBoxItem Text="7" />
                                                        <telerik:RadComboBoxItem Text="8" />
                                                        <telerik:RadComboBoxItem Text="9" />
                                                        <telerik:RadComboBoxItem Text="10" />
                                                        <telerik:RadComboBoxItem Text="11" />
                                                        <telerik:RadComboBoxItem Text="12" />
                                                    </Items>
                                                    <Localization AllItemsCheckedString="--all--" CheckAllString="--all--" />
                                       </telerik:RadComboBox>
                            </td>
                            <td width="15%" align="right">
                                            <asp:CheckBox ID="CheckBoxDept_Id_Execute_Current" runat="server" CssClass="checkbox" Text="Bộ phận thực hiện:" TextAlign="Left" />
                            </td>
                            <td align="left">

                            <asp:DropDownList ID="DropDownListDept_Id_Execute_Current" runat="server" CssClass="droplist">
                            </asp:DropDownList>

                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                            <asp:Label ID="Label31" runat="server" CssClass="label">Loại đối tác:</asp:Label>
                            </td>
                            <td align="left">
                            <asp:DropDownList ID="DropDownListTypeOfPartner" runat="server" CssClass="droplist" Font-Bold="False">
                                <asp:ListItem>--all--</asp:ListItem>
                                <asp:ListItem Value="1">Telcos</asp:ListItem>
                                <asp:ListItem Value="0">Sub CPs</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                            <td width="15%" align="right">
                                            <asp:CheckBox ID="CheckBoxStatus_Id" runat="server" CssClass="checkbox" Text="Trạng thái:" TextAlign="Left" />
                            </td>
                            <td align="left">

                                <asp:DropDownList ID="DropDownListStatus_Id" runat="server" CssClass="droplist">
                                    <asp:ListItem Value="-1">--all--</asp:ListItem>
                                    <asp:ListItem Value="1">Hoàn thành</asp:ListItem>
                                    <asp:ListItem Value="0">Chưa hoàn thành</asp:ListItem>
                                </asp:DropDownList>

                            </td>
                        </tr>
                        
                        <tr>
                            <td align="right" width="15%">
                                            <asp:CheckBox ID="CheckBoxPartner_Id" runat="server" CssClass="checkbox" Text="Đối tác:" TextAlign="Left" />
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DropDownListPartner_Id" runat="server" CssClass="droplist" Font-Bold="False">
                                </asp:DropDownList>
                            </td>
                            <td width="15%" align="right">
                                            <asp:CheckBox ID="CheckBoxStatus_Debts_Id" runat="server" CssClass="checkbox" Text="Công nợ:" TextAlign="Left" />
                            </td>
                            <td align="left">

                            <asp:DropDownList ID="DropDownListPayment" runat="server" CssClass="droplist">
                                <asp:ListItem Value="-1">--all--</asp:ListItem>
                                <asp:ListItem Value="0">Chưa thanh toán</asp:ListItem>
                                <asp:ListItem Value="1">Thanh toán 1 phần</asp:ListItem>
                                <asp:ListItem Value="2">Thanh toán hết</asp:ListItem>
                            </asp:DropDownList>
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
                   <div class="submmit">
                       <asp:Panel ID="Panel1" runat="server">
                                <table  width="20%">
                           <tr>
                               <td   width="50%" align="right">
                            <asp:Label ID="Label27" runat="server" CssClass="label">Số tiền đã thanh toán:</asp:Label>
                               </td>
                               <td align="right"  >
                            <asp:Label ID="lblTotal_Payment" runat="server" CssClass="label" Font-Bold="True" ForeColor="#0000CC"></asp:Label>
                               </td>
                           </tr>
                           <tr>
                               <td align="right"  >
                            <asp:Label ID="Label28" runat="server" CssClass="label">Số tiền còn nợ:</asp:Label>
                               </td>
                               <td align="right"  >
                            <asp:Label ID="lblTotal_Debts" runat="server" CssClass="label" Font-Bold="True" ForeColor="Red"></asp:Label>
                                   
                               </td>
                           </tr>
                           <tr>
                               <td align="right"  >
                            <asp:Label ID="Label29" runat="server" CssClass="label">Doanh thu tổng:</asp:Label>
                               </td>
                               <td align="right"  >
                            <asp:Label ID="lblTotal_Revenue" runat="server" CssClass="label" Font-Bold="True"></asp:Label>
                               </td>
                           </tr>
                       </table>
                                   </asp:Panel>
                  
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
                        <asp:TemplateColumn HeaderText="NĂM">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblYEAR" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Year")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                          <asp:TemplateColumn HeaderText="THÁNG">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                
                                <asp:Label ID="lblMonth" runat="server" CssClass="label"><%# DataBinder.Eval(Container.DataItem, "Month")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                          <asp:TemplateColumn HeaderText="ĐỐI TÁC">
                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                            <ItemTemplate>
                                <asp:Label ID="lblPartner_Text" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Partner_Text")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                              <asp:TemplateColumn HeaderText="NỘI DUNG THỰC HIỆN">
                            <ItemStyle Width="15%" HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label ID="lblTask_Text_Curent" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Task_Text_Curent")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="TRẠNG THÁI">
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblStatus_Text" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Status_Text")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                         <asp:TemplateColumn HeaderText="CÔNG NỢ">
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblStatus_Debts_Text" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Status_Debts_Text")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="BỘ PHẬN THỰC HIỆN">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <asp:Label ID="lblDept_Text_Execute_Current" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Dept_Text_Execute_Current")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                     <asp:TemplateColumn HeaderText="DOANH THU">
                            <ItemStyle HorizontalAlign="Right" Width="10%" />
                            <ItemTemplate>
                                <asp:Label ID="lblTotal_Revenue" runat="server" CssClass="label" Font-Bold="true">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "Total_Revenue"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                           <asp:TemplateColumn HeaderText="THANH TOÁN">
                            <ItemStyle HorizontalAlign="Right" Width="10%" />
                            <ItemTemplate>
                                <asp:Label ID="lblTotal_Payment" runat="server" CssClass="label" Font-Bold="true">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "Total_Payment"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                           <asp:TemplateColumn HeaderText="CÔNG NỢ">
                            <ItemStyle HorizontalAlign="Right" Width="10%" />
                            <ItemTemplate>
                                <asp:Label ID="lblTotal_Debts" runat="server" CssClass="label" Font-Bold="true">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "Total_Debts"), 0)%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                           <asp:TemplateColumn HeaderText="TỔNG">
                            <ItemStyle HorizontalAlign="Right" Width="10%" />
                            <ItemTemplate>
                                <asp:Label ID="lblTOTAL" runat="server" CssClass="label" Font-Bold="true">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "vTotal"), 0)%></asp:Label>
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