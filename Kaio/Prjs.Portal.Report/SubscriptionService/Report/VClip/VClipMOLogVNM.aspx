﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="VClipMOLogVNM.aspx.vb" Inherits="Prjs.Portal.Report.VClipMOLogVNM" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="ASPnetPagerV2_8" Namespace="ASPnetControls" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
   <link href="../../../Styles/HQ.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/LightStyle.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/RadTreeView.css" type="text/css" rel="stylesheet" />

    <script language="javascript" type="text/javascript" src="../../../../Js/Menu3.js"></script>
    
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
        </telerik:RadAjaxManager>
        <div id="HQ">
            <div class="alert">
                <asp:Label ID="lbltitle" runat="server" CssClass="lbltitle"></asp:Label><br />
                <asp:Label ID="lblerror" runat="server" CssClass="lblerror"></asp:Label>
            </div>
            
          
                <div class="input" style="width: 50%">
                       <table width="100%">
                            <tr>
                                <td align="right" width="15%">
                                    &nbsp;
                                    <asp:Label ID="lblTrang7" runat="server" CssClass="label">Từ ngày:</asp:Label>
                                </td>
                                <td align="left" width="35%">
                                <telerik:RadDatePicker ID="RadFromDate" rMinDate="2006/01/01" runat="server"
                                    ZIndex="30001" Culture="vi-VN" Skin="Forest">
                                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"
                                        Skin="Forest">
                                    </Calendar>

                                    <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

                                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                </telerik:RadDatePicker>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="15%">
                                    <asp:Label ID="lblTrang8" runat="server" CssClass="label">Đến ngày:</asp:Label>
                                </td>
                                <td align="left" width="35%">
                                <telerik:RadDatePicker ID="RadToDate" rMinDate="2006/01/01" runat="server"
                                    ZIndex="30001" Culture="vi-VN" Skin="Forest">
                                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" ViewSelectorText="x"
                                        Skin="Forest">
                                    </Calendar>

                                    <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%"></DateInput>

                                    <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                </telerik:RadDatePicker>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="15%">
                                    &nbsp;</td>
                                <td align="left" width="35%">

                                <asp:CheckBox ID="CheckBoxAllDate" runat="server" CssClass="checkbox" Text="Toàn thời gian" />

                                         </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblTrang11" runat="server" CssClass="label">Số điện thoại:</asp:Label>
                             </td>
                                <td align="left">
                                
                                    <asp:TextBox ID="txtUser_Id" runat="server" CssClass="txtContent" Width="40%"></asp:TextBox>
                                
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
           
           
            <div   class="submmit"  >

                <table style="width: 100%; border-collapse: collapse">
                    <tr>
                        <td> 
                            <fieldset id="fieldset2">
                                
                                <table width="100%">
                                    <tr>
                                        <td width="50%" align="right">
                                            <asp:Label ID="lblMO" runat="server" CssClass="label_parametter" Font-Italic="False">Tổng số:</asp:Label>
                                        </td>
                                        <td align="justify">
                                            <asp:Label ID="lblTotal" runat="server" CssClass="label" Font-Italic="False" Font-Bold="True"></asp:Label>
                                        </td>
                                    </tr>
                                    </table>
                            </fieldset>

                        </td>
                     

                    </tr>
                </table>
            </div>
            <div class="pager">
                <cc1:PagerV2_8 ID="pager1" runat="server" OnCommand="pager_Command" GenerateGoToSection="true"
                    Font-Size="10pt" PageSize="120" />

            </div>
            <div class="datagrid">

                       <asp:DataGrid ID="DataGrid" runat="server" AutoGenerateColumns="false" CellPadding="0"
                                        CssClass="datagrid" EnableViewState="False" GridLines="None" PagerStyle-Mode="NextPrev"
                                        PagerStyle-Visible="true" Width="100%" PageSize="120">
                                        <HeaderStyle CssClass="datagridHeader" />
                                        <AlternatingItemStyle CssClass="datagridAlternatingItemStyle" />
                                        <ItemStyle CssClass="datagridItemStyle" />
                                             <Columns>
                                            <asp:TemplateColumn>
                                                <HeaderTemplate>
                                                    #
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOrder" runat="server" Font-Names="Tahoma" Font-Size="8pt" ForeColor="DimGray"
                                                        Text="<%# Container.ItemIndex+1 %>"> </asp:Label>
                                                </ItemTemplate>
                                               
                                                <HeaderStyle HorizontalAlign="Center" Width="2%" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="KHÁCH HÀNG">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "User_ID")%>
                                                </ItemTemplate>
                                                <ItemStyle Width="10%" HorizontalAlign="Center" />
                                            </asp:TemplateColumn>
                                               <asp:TemplateColumn HeaderText="MẠNG">
                                                <ItemTemplate>
                                                    <%# DataBinder.Eval(Container.DataItem, "Operator")%>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="REQUEST ID">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "Request_ID")%>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="ĐẦU SỐ">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "Service_ID")%>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="MÃ DỊCH VỤ">
                                                <ItemTemplate>
                                                    <%# DataBinder.Eval(Container.DataItem, "Command_Code")%>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="NỘI DUNG TIN NHẮN">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "Message")%>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Left" Width="20%" />
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="THỜI GIAN">
                                                <ItemTemplate>
                                                    <%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "RequestDate")).ToString("dd-MM-yyyy HH:mm:ss")%>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="10%" />
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