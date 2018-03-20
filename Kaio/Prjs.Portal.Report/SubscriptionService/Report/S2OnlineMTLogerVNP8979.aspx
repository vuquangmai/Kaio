<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="S2OnlineMTLogerVNP8979.aspx.vb" Inherits="Prjs.Portal.Report.S2OnlineMTLogerVNP8979" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="ASPnetPagerV2_8" Namespace="ASPnetControls" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../../Styles/HQ.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/LightStyle.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/RadTreeView.css" type="text/css" rel="stylesheet" />

    <script language="javascript" type="text/javascript" src="../../../Js/Menu3.js"></script>
    <script type="text/javascript">
        function IsDetail(contract_code, year, month) {
            window.open("../DictIndex/S2ContractInfo.aspx?objid=" + contract_code + "&year=" + year + "&month=" + month, "Bil_S2_Info", "location=no,directories=no,left=0,top=0,height=900,width=1000,status=no,scrollbars=yes,toolbars=no,menubar=no,resizable=yes");
        }
    </script>
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
        .auto-style1 {
            width: 100%;
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

            </AjaxSettings>
        </telerik:RadAjaxManager>
        <div id="HQ">
            <div class="alert">
                <asp:Label ID="lbltitle" runat="server" CssClass="lbltitle"></asp:Label><br />
                <asp:Label ID="lblerror" runat="server" CssClass="lblerror"></asp:Label>
            </div>
            <a href="javascript:showSubcat('1');">
                <img id="imgCat1" src="../../Images/collapse_thead.gif" border="0" alt="" />
            </a>
            <div id="divCat1" style="visibility: visible">
                <div class="input">
                    <table width="100%">
                        <tr>
                            <td align="right" width="15%">
                                <asp:Label ID="lblTrang7" runat="server" CssClass="label">Năm:</asp:Label>
                            </td>
                            <td align="left" width="20%">
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
                                <asp:CheckBox ID="CheckBoxPartnerId" runat="server" CssClass="checkbox" Text="Đối tác:" TextAlign="Left" />
                            </td>
                            <td align="left">
                                        <telerik:RadComboBox ID="RadDropDownListPartner_Id" runat="server" AutoPostBack="True" Skin="Hay" Width="98%">
                                        </telerik:RadComboBox>


                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblTrang8" runat="server" CssClass="label">Tháng:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="DropDownListMonth" runat="server" CssClass="droplist"
                                    AutoPostBack="True">
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>5</asp:ListItem>
                                    <asp:ListItem>6</asp:ListItem>
                                    <asp:ListItem>7</asp:ListItem>
                                    <asp:ListItem>8</asp:ListItem>
                                    <asp:ListItem>9</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>11</asp:ListItem>
                                    <asp:ListItem>12</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td align="right">
                                <asp:CheckBox ID="CheckBoxService_Id" runat="server" CssClass="checkbox" Text="Dịch vụ:" TextAlign="Left" />
                            </td>
                            <td align="left">
                               
                                        <telerik:RadComboBox ID="RadDropDownListService_Id" runat="server" Skin="Hay" Width="98%">
                                        </telerik:RadComboBox>
                                    
                            </td>
                        </tr>
                        <tr>
                            <td align="right" >
                                <asp:Label ID="lblTrang9" runat="server" CssClass="label">Từ ngày:</asp:Label>
                            </td>
                            <td align="left">
                                <table cellpadding="0" cellspacing="0" class="auto-style1">
                                    <tr>
                                        <td width="20px">
                              <asp:DropDownList ID="DropDownListFromDate" runat="server" CssClass="droplist">
                                            </asp:DropDownList>
                               
                                        </td>
                                        <td width="50px">
                            <asp:Label ID="lblTrang11" runat="server" CssClass="label"> đến ngày:</asp:Label>
                                        </td>
                                        <td>  <asp:DropDownList ID="DropDownListToDate" runat="server" CssClass="droplist">
                                            </asp:DropDownList></td>
                                    </tr>
                                </table>
                            </td>
                            <td align="right">
                                <asp:CheckBox ID="CheckBoxUser_Id" runat="server" CssClass="checkbox" Text="Số điện thoại:" TextAlign="Left" />
                            </td>
                            <td align="left">
                               <asp:TextBox ID="txtUser_Id" runat="server" AutoCompleteType="Disabled" CssClass="txtContent" Font-Bold="True" ForeColor="#0033CC" Width="30%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                &nbsp;</td>
                            <td align="left">
                                <asp:CheckBox ID="CheckBoxAllDate" runat="server" Checked="True" CssClass="checkbox" Text="Cả tháng" />
                            </td>
                            <td align="right">
                                <asp:CheckBox ID="CheckBoxDate" runat="server" CssClass="checkbox" Text="Ngày:" TextAlign="Left" />
                            </td>
                            <td align="left">


                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="lblTrang12" runat="server" CssClass="label">Trạng thái:</asp:Label>
                                &nbsp;
                            </td>
                            <td align="left">
                                <telerik:RadComboBox ID="RadDropDownListStatus" runat="server"  Skin="Hay" Width="90px">
                                    <Items>
                                        <telerik:RadComboBoxItem Text="Thành công" Value="1" />
                                        <telerik:RadComboBoxItem Text="Lỗi" Value="0" />
                                    </Items>
                                </telerik:RadComboBox>

                            </td>
                            <td align="right">
                                <asp:CheckBox ID="CheckBoxHour" runat="server" CssClass="checkbox" Text="Giờ:" TextAlign="Left" />
                            </td>
                            <td align="left">
                                &nbsp;</td>
                        </tr>
                        </table>
                </div>
                <div class="submmit">
                    <asp:Button ID="btnSearch" runat="server" CssClass="btnbackground"
                        Text="Tìm kiếm" />
                    <asp:Button ID="btnExport" runat="server" CssClass="btnbackground"
                        Text="Báo cáo" />
                </div>
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
                                <asp:Label ID="lblvMonth" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "vMonth")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="NGÀY">
                            <ItemStyle Width="5%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblDay" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "vDate")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    
                        <asp:TemplateColumn HeaderText="ĐỐI TÁC">
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblvPartnerName" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "vPartnerName")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="DỊCH VỤ">
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="lblvService_Name" runat="server" CssClass="label"> <%# DataBinder.Eval(Container.DataItem, "vService_Name")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                          
                          <asp:TemplateColumn HeaderText="TỔNG MT">
                            <ItemStyle Width="5%" HorizontalAlign="Right" />
                            <ItemTemplate>
                                <asp:Label ID="lblTotal" runat="server" CssClass="label" Font-Bold="true">   <%# Utils.FormatDecimal(DataBinder.Eval(Container.DataItem, "Total"), 0)%></asp:Label>
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
