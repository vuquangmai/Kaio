<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CCareCustomerInfo.aspx.vb" Inherits="Prjs.Portal.Report.CCareCustomerInfo" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../../Styles/HQ.css" rel="stylesheet" type="text/css" />
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
                <telerik:AjaxSetting AjaxControlID="txtUSER_ID">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="txtUSER_ID" />
                        <telerik:AjaxUpdatedControl ControlID="DropDownListMOBILE_OPERATOR" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
                <telerik:AjaxSetting AjaxControlID="DropDownListPARTNER_ID">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="DropDownListBRAND_NAME" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <div id="HQ">
            <div class="alert">
                <asp:Label ID="lbltitle" runat="server" CssClass="lbltitle"></asp:Label><br />
                <asp:Label ID="lblerror" runat="server" CssClass="lblerror"></asp:Label>
            </div>
            <div class="input" style="border-width: 0px; width: 99%; background-color: #FFFFFF;">
                <fieldset id="fieldsetBound">
                       <legend>
                        <asp:Label ID="Label1" runat="server" CssClass="lblerror">Thông tin chi tiết</asp:Label></legend>
                   <table border="0" cellpadding="3" cellspacing="3" style="width: 100%">
                        <tr>
                            <td align="right" width="15%">
                                <asp:Label ID="Label26" runat="server" CssClass="label">Số điện thoại:</asp:Label>
                            </td>
                            <td align="left" width="35%">
                                <asp:Label ID="lblUSER_ID" runat="server" CssClass="label"></asp:Label>
                            </td>
                            <td width="15%" align="right">
                                <asp:Label ID="Label36" runat="server" CssClass="label">Mã khách hàng:</asp:Label>
                            </td>
                            <td align="left">
                                <asp:Label ID="lblID" runat="server" CssClass="label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                <asp:Label ID="Label29" runat="server" CssClass="label">Nội dung MT:</asp:Label>
                            </td>
                            <td align="left" width="35%">
                                <asp:Label ID="lblMT" runat="server" CssClass="label"></asp:Label>
                            </td>
                            <td width="15%" align="right">
                                <asp:Label ID="Label30" runat="server" CssClass="label">Họ tên:</asp:Label>
                            </td>
                            <td align="left">

                                <asp:Label ID="lblCUSTOMER_NAME" runat="server" CssClass="label"></asp:Label>

                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="15%">
                                <asp:Label ID="Label6" runat="server" CssClass="label">Đối tác:</asp:Label>
                            </td>
                            <td align="left" width="35%">
                                <asp:Label ID="lblPARTNER_TEXT" runat="server" CssClass="label"></asp:Label>
                            </td>
                            <td width="15%" align="right">
                                <asp:Label ID="Label16" runat="server" CssClass="label">Ngày sinh:</asp:Label>
                            </td>
                            <td align="left">

                            
                                <asp:Label ID="lblBIRTH_DAY" runat="server" CssClass="label"></asp:Label>

                            
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="auto-style3">
                                <asp:Label ID="Label3" runat="server" CssClass="label">Brand name:</asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                <asp:Label ID="lblBRAND_NAME" runat="server" CssClass="label"></asp:Label>
                            </td>
                            <td align="right" class="auto-style3">
                                <asp:Label ID="Label31" runat="server" CssClass="label">Địa chỉ:</asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                <asp:Label ID="lblADDRESS" runat="server" CssClass="label"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td align="right" class="auto-style3">
                                <asp:Label ID="Label5" runat="server" CssClass="label">Tỉnh/Thành:</asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                <asp:Label ID="lblPROVINCE_TEXT" runat="server" CssClass="label"></asp:Label>
                            </td>
                            <td align="right" class="auto-style3">
                                <asp:Label ID="Label32" runat="server" CssClass="label">Email:</asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                <asp:Label ID="lblEMAIL_ADDRESS" runat="server" CssClass="label"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td align="right" class="auto-style3">
                                <asp:Label ID="Label8" runat="server" CssClass="label">Giới tính:</asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                <asp:Label ID="lblSEX_TEXT" runat="server" CssClass="label"></asp:Label>
                            </td>
                            <td align="right" class="auto-style3">
                                <asp:Label ID="Label33" runat="server" CssClass="label">Mức cước:</asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                <asp:Label ID="lblFEES_TEXT" runat="server" CssClass="label"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td align="right" class="auto-style3">
                                <asp:Label ID="Label7" runat="server" CssClass="label">Ngành hàng:</asp:Label>
                            </td>
                            <td align="left" class="auto-style3">

                                <asp:Label ID="lblFIELD_TEXT" runat="server" CssClass="label"></asp:Label>

                            </td>
                            <td align="right" class="auto-style3">
                                <asp:Label ID="Label34" runat="server" CssClass="label">Mức thu nhập:</asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                <asp:Label ID="lblINCOME_TEXT" runat="server" CssClass="label"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td align="right" class="auto-style3">
                                <asp:Label ID="Label27" runat="server" CssClass="label">Nguồn dữ liệu:</asp:Label>
                            </td>
                            <td align="left" class="auto-style3">

                                <asp:Label ID="lblSOURCE_TEXT" runat="server" CssClass="label"></asp:Label>

                            </td>
                            <td align="right" class="auto-style3">
                                <asp:Label ID="Label37" runat="server" CssClass="label">Mạng:</asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                <asp:Label ID="lblMOBILE_OPERATOR" runat="server" CssClass="label"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td align="right" class="auto-style3">
                                <asp:Label ID="Label4" runat="server" CssClass="label">Từ khóa:</asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                <asp:Label ID="lblKEY_WORD" runat="server" CssClass="label"></asp:Label>
                            </td>
                            <td align="right" class="auto-style3">
                                <asp:Label ID="Label35" runat="server" CssClass="label">Độ chính xác:</asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                <asp:Label ID="lblEXACTLY_RATE" runat="server" CssClass="label"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td align="right" class="auto-style3">
                                <asp:Label ID="Label43" runat="server" CssClass="label">Nhóm khách hàng:</asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                <asp:Label ID="lblGROUP_TEXT" runat="server" CssClass="label"></asp:Label>
                            </td>
                            <td align="right" class="auto-style3">
                                <asp:Label ID="Label44" runat="server" CssClass="label">Trạng thái:</asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                <asp:Label ID="lblSTATUS_TEXT" runat="server" CssClass="label"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td align="right" class="auto-style3">
                                <asp:Label ID="Label28" runat="server" CssClass="label">Ghi chú:</asp:Label>
                            </td>
                            <td align="left" class="auto-style3">
                                <asp:Label ID="lblREMARK" runat="server" CssClass="label"></asp:Label>
                            </td>
                            <td align="right" class="auto-style3">
                                &nbsp;</td>
                            <td align="left" class="auto-style3">
                                &nbsp;</td>
                        </tr>

                    </table>
                </fieldset>
                 
                    <fieldset id="fieldset1">
                         <legend>
                        <asp:Label ID="Label2" runat="server" CssClass="lblerror">Bản ghi liên quan trong bảng chính thức</asp:Label></legend>
                            <div class="datagrid">
                         <asp:DataGrid ID="DataGrid_1" runat="server" AllowPaging="True" AutoGenerateColumns="false"
                            CellPadding="0" CssClass="datagrid" EnableViewState="False" GridLines="None"
                            PagerStyle-Mode="NextPrev" PagerStyle-Visible="true" Width="100%" PageSize="3">
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
                                <asp:TemplateColumn HeaderText="ĐIỆN THOẠI">
                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblUSER_ID" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "USER_ID")%></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="MẠNG">
                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblMOBILE_OPERATOR" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "MOBILE_OPERATOR")%></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="MÃ KHÁCH HÀNG">
                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblPARTNER_TEXT" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "CUSTOMER_CODE")%></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="HỌ TÊN">
                                    <ItemStyle HorizontalAlign="Center" Width="15%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCUSTOMER_NAME" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "CUSTOMER_NAME")%></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="TỈNH THÀNH">
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblPROVINCE_TEXT" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "PROVINCE_TEXT")%></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="ĐỘ CHÍNH XÁC">
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblEXACTLY_RATE" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "EXACTLY_RATE")%></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>

                                <asp:TemplateColumn HeaderText="CẬP NHẬT">
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    <ItemTemplate>

                                        <asp:Label ID="lblUPDATE_TIME" runat="server" CssClass="label"><%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "UPDATE_TIME")).ToString("dd-MM-yyyy")%></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="GHI CHÚ">
                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblREMARK" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "REMARK")%></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                         
                            </Columns>
                            <PagerStyle HorizontalAlign="Right" NextPageText="" PageButtonCount="5" PrevPageText=""
                                Visible="False" />
                        </asp:DataGrid>
                                </div>
                    </fieldset>
              <fieldset id="fieldset2">
                         <legend>
                        <asp:Label ID="Label9" runat="server" CssClass="lblerror">Bản ghi liên quan trong bảng gọi</asp:Label></legend>
                              <div class="datagrid">
                        <asp:DataGrid ID="DataGrid_2" runat="server" AllowPaging="True" AutoGenerateColumns="false"
                            CellPadding="0" CssClass="datagrid" EnableViewState="False" GridLines="None"
                            PagerStyle-Mode="NextPrev" PagerStyle-Visible="true" Width="100%" PageSize="5">
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
                                        <asp:Label ID="lblOrder_2" runat="server" CssClass="label"
                                            Text='<%# Container.ItemIndex+1 %>'>
                                        </asp:Label>
                                    </ItemTemplate>

                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="ĐIỆN THOẠI">
                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblUSER_ID_2" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "USER_ID")%></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="MẠNG">
                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblMOBILE_OPERATOR_2" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "MOBILE_OPERATOR")%></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="MÃ KHÁCH HÀNG">
                                    <ItemStyle Width="10%" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblPARTNER_TEXT_2" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "CUSTOMER_CODE")%></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="HỌ TÊN">
                                    <ItemStyle HorizontalAlign="Center" Width="15%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCUSTOMER_NAME_2" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "CUSTOMER_NAME")%></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="TỈNH THÀNH">
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblPROVINCE_TEXT_2" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "PROVINCE_TEXT")%></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="ĐỘ CHÍNH XÁC">
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblEXACTLY_RATE_2" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "EXACTLY_RATE")%></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>

                                <asp:TemplateColumn HeaderText="CẬP NHẬT">
                                    <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    <ItemTemplate>

                                        <asp:Label ID="lblUPDATE_TIME_2" runat="server" CssClass="label"><%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "UPDATE_TIME")).ToString("dd-MM-yyyy")%></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                                <asp:TemplateColumn HeaderText="GHI CHÚ">
                                    <ItemStyle HorizontalAlign="Left" Width="20%" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblREMARK_2" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "REMARK")%></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                             
                            </Columns>
                            <PagerStyle HorizontalAlign="Right" NextPageText="" PageButtonCount="5" PrevPageText=""
                                Visible="False" />
                        </asp:DataGrid>

                    </div>
                    </fieldset>
                 <fieldset id="fieldset3">
                         <legend>
                        <asp:Label ID="Label10" runat="server" CssClass="lblerror">Bản ghi liên quan trong bảng import</asp:Label></legend>
                      <div class="datagrid">
                    <asp:DataGrid ID="DataGrid_3" runat="server" AllowPaging="True" AutoGenerateColumns="false"
                        CellPadding="0" CssClass="datagrid" EnableViewState="False" GridLines="None"
                        PagerStyle-Mode="NextPrev" PagerStyle-Visible="true" Width="100%">
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
                                    <asp:Label ID="lblOrder_3" runat="server" CssClass="label"
                                        Text='<%# Container.ItemIndex+1 %>'>
                                    </asp:Label>
                                </ItemTemplate>

                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="ĐIỆN THOẠI">
                                <ItemStyle Width="10%" HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUSER_ID_3" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "USER_ID")%></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="MẠNG">
                                <ItemStyle Width="10%" HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblMOBILE_OPERATOR_3" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "MOBILE_OPERATOR")%></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="MÃ KHÁCH HÀNG">
                                <ItemStyle Width="10%" HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPARTNER_TEXT_3" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "CUSTOMER_CODE")%></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="HỌ TÊN">
                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCUSTOMER_NAME_3" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "CUSTOMER_NAME")%></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="TỈNH THÀNH">
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPROVINCE_TEXT_3" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "PROVINCE_TEXT")%></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="ĐỘ CHÍNH XÁC">
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                <ItemTemplate>
                                    <asp:Label ID="lblEXACTLY_RATE_3" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "EXACTLY_RATE")%></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>

                            <asp:TemplateColumn HeaderText="CẬP NHẬT">
                                <ItemStyle HorizontalAlign="Center" Width="10%" />
                                <ItemTemplate>

                                    <asp:Label ID="lblUPDATE_TIME_3" runat="server" CssClass="label"><%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "UPDATE_TIME")).ToString("dd-MM-yyyy")%></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="GHI CHÚ">
                                <ItemStyle HorizontalAlign="Left" Width="20%" />
                                <ItemTemplate>
                                    <asp:Label ID="lblREMARK_3" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "REMARK")%></asp:Label>
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