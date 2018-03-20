<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ChargingContractInfo.aspx.vb" Inherits="Prjs.Portal.Report.ChargingContractInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="FilePickerControl" Namespace="AWS.FilePicker" TagPrefix="cc2" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>#</title>
    <link href="../../Styles/HQ.css" rel="stylesheet" type="text/css" />
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
             color:white;
        }

        .fieldset1 {
            display: block;
            border: 1px solid #fab26a;
            -moz-border-radius: 8px;
            -webkit-border-radius: 8px;
            border-radius: 8px;
            margin-bottom: 3px;
        }

        .legend1 {
            background: #ffffff;
            border: solid 1px #fab26a;
            -webkit-border-radius: 8px;
            -moz-border-radius: 8px;
            border-radius: 8px;
            font-style: normal;
            font-weight: bold;
            color: #000000;
        }

        .auto-style1 {
            width: 100%;
            border-collapse: collapse;
        }
    </style>
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


            <div class="datagrid">
                <telerik:RadTabStrip ID="RadTabStrip1" runat="server" Font-Bold="True" MultiPageID="RadMultiPage1"
                    Skin="Sitefinity" Width="100%" Font-Italic="False" Font-Names="Arial" Font-Size="10pt" SelectedIndex="0">
                    <Tabs>
                        <telerik:RadTab runat="server" Text="Thông tin hợp đồng" Font-Names="Arial" Font-Size="10pt" Selected="True">
                        </telerik:RadTab>
                        <telerik:RadTab runat="server" Text="Đối soát, thanh toán" Font-Names="Arial" Font-Size="10pt">
                        </telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
                <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0" Width="100%">
                    <telerik:RadPageView ID="RadPageView2" runat="server" Width="100%">
                        <div align="left">



                            <fieldset id="fieldsetBasicInfo">
                                <legend>
                                    <asp:Label ID="Label2" runat="server" CssClass="label" Font-Italic="true">1. Thông tin cơ bản </asp:Label>
                                </legend>
                                <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                                    <tr>
                                        <td align="right" width="15%">
                                            <asp:Label ID="Label7" runat="server" CssClass="label">Phòng ban:</asp:Label>
                                        </td>
                                        <td align="left" width="35%">
                                            <asp:DropDownList ID="DropDownListDepartment_Id" runat="server" CssClass="droplist" AutoPostBack="True">
                                            </asp:DropDownList>
                                        </td>
                                        <td width="15%" align="right">
                                            <asp:Label ID="Label25" runat="server" CssClass="label">Dịch vụ hợp tác:</asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="DropDownListService_Id" runat="server" CssClass="droplist">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label16" runat="server" CssClass="label">Đối tác:</asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="DropDownListPartner_Id" runat="server" CssClass="droplist">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label19" runat="server" CssClass="label">Mô hình hợp tác:</asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="DropDownListCooperation_Id" runat="server" CssClass="droplist">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>

                                </table>
                            </fieldset>
                            <br />
                            <fieldset id="fieldset3">
                                <legend>
                                    <asp:Label ID="Label15" runat="server" CssClass="label" Font-Italic="true">2. Thông tin chi tiết</asp:Label>
                                </legend>
                                <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">

                                    <tr>
                                        <td align="right" width="15%">
                                            <asp:Label ID="Label30" runat="server" CssClass="label">Mã hợp đồng:</asp:Label>
                                        </td>
                                        <td align="left" width="35%">
                                            <asp:TextBox ID="txtContract_Code" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                Width="60%" AutoPostBack="True" Font-Bold="True" ForeColor="#0033CC"></asp:TextBox>
                                        </td>
                                        <td width="15%" align="right">
                                            <asp:Label ID="Label31" runat="server" CssClass="label">Ngày ký hợp đồng:</asp:Label>
                                        </td>
                                        <td align="left">
                                            <telerik:RadDatePicker ID="RadContract_Sign_Date" rMinDate="2006/01/01" runat="server"
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
                                        <td align="right">
                                            <asp:Label ID="Label32" runat="server" CssClass="label">Số hợp đồng:</asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtContract_Number" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                Width="60%"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label62" runat="server" CssClass="label">Ngày ký nghiệm thu:</asp:Label>
                                        </td>
                                        <td align="left">
                                            <telerik:RadDatePicker ID="RadLaunching_Date" rMinDate="2006/01/01" runat="server"
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
                                        <td align="right">
                                            <asp:Label ID="Label63" runat="server" CssClass="label">Tên hợp đồng:</asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtContract_Text" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                Width="100%" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label64" runat="server" CssClass="label">Ngày cung cấp dịch vụ:</asp:Label>
                                        </td>
                                        <td align="left">
                                            <telerik:RadDatePicker ID="RadAcceptance_Test_Date" rMinDate="2006/01/01" runat="server"
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
                                        <td align="right">
                                            <asp:Label ID="Label65" runat="server" CssClass="label">File hợp đồng:</asp:Label>
                                        </td>
                                        <td align="left">
                                            <cc2:FilePicker ID="ContractFile" runat="server" CssClass="txtContent" fpAllowedUploadFileExts="" fpPopupURL="../../FilePicker/FilePicker.aspx" fpPopupWidth="600" Width="50%"></cc2:FilePicker>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label66" runat="server" CssClass="label">Chu kỳ hợp đồng:</asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="DropDownListCycle_Contract" runat="server" CssClass="droplist">
                                                <asp:ListItem Value="0">--Chọn--</asp:ListItem>
                                                <asp:ListItem Value="1">6 tháng</asp:ListItem>
                                                <asp:ListItem Value="2">1 năm</asp:ListItem>
                                                <asp:ListItem Value="3">Không thời hạn</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>



                                </table>
                            </fieldset>
                            <br />
                            <fieldset id="fieldsetData">
                                <legend>
                                    <asp:Label ID="Label3" runat="server" CssClass="label" Font-Italic="True">3. Đối soát, Tỷ lệ phân chia</asp:Label>
                                </legend>
                                <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">

                                    <tr>
                                        <td align="right" width="15%">
                                            <asp:Label ID="Label13" runat="server" CssClass="label">Tỷ lệ đối soát lần 1:</asp:Label>
                                        </td>
                                        <td align="left" width="35%">
                                            <asp:TextBox ID="txtRatio_1" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                Width="10%" AutoPostBack="True" Font-Bold="True"></asp:TextBox>
                                            <asp:Label ID="Label69" runat="server" CssClass="label">%</asp:Label>
                                        </td>
                                        <td width="15%" align="right">
                                            <asp:Label ID="Label24" runat="server" CssClass="label">Tỷ lệ đối soát lần 2:</asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtRatio_2" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                Width="10%" AutoPostBack="True" Font-Bold="True"></asp:TextBox>
                                            <asp:Label ID="Label70" runat="server" CssClass="label">%</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label17" runat="server" CssClass="label">Phí chăm sóc khách hàng:</asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="DropDownListCcare_Cost" runat="server" CssClass="droplist">
                                                <asp:ListItem>0</asp:ListItem>
                                                <asp:ListItem>1</asp:ListItem>
                                                <asp:ListItem>2</asp:ListItem>
                                                <asp:ListItem>3</asp:ListItem>
                                                <asp:ListItem>4</asp:ListItem>
                                                <asp:ListItem>5</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label26" runat="server" CssClass="label">Doanh thu tối thiểu:</asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtMin_Revenue" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                Width="30%" AutoPostBack="True" Font-Bold="True">0</asp:TextBox>
                                        </td>
                                    </tr>



                                    <tr>
                                        <td align="right" colspan="4">
                                            <asp:DataGrid ID="DataGrid2" runat="server" AllowPaging="True" AutoGenerateColumns="false"
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
                                                            <asp:Label ID="lblOrder0" runat="server" CssClass="label"
                                                                Text='<%# Container.ItemIndex+1 %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>

                                                    </asp:TemplateColumn>

                                                    <asp:TemplateColumn HeaderText="DOANH THU TỐI THIỂU">
                                                        <ItemStyle Width="20%" HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "Min_Val")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="DOANH THU TỐI ĐA">
                                                        <ItemStyle Width="20%" HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "Max_Val")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="VIETTEL">
                                                        <ItemStyle Width="10%" HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "VIETTEL")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="VMS">
                                                        <ItemStyle Width="10%" HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "VMS")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="VNP">
                                                        <ItemStyle Width="10%" HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "VNP")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="VNM">
                                                        <ItemStyle Width="10%" HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "VNM")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="GTEL">
                                                        <ItemStyle Width="10%" HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "GTEL")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                </Columns>
                                                <PagerStyle HorizontalAlign="Right" NextPageText="" PageButtonCount="5" PrevPageText=""
                                                    Visible="False" />
                                            </asp:DataGrid>

                                        </td>
                                    </tr>



                                </table>
                            </fieldset>
                            <br />
                            <fieldset id="fieldsetSupport">
                                <legend>
                                    <asp:Label ID="Label4" runat="server" CssClass="label" Font-Italic="true">4. Đầu mối kinh doanh, kỹ thuật, đối soát thanh toán và CSHK  </asp:Label></legend>
                                <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                                    <tr>
                                        <td width="50%">
                                            <fieldset id="fieldset1">
                                                <legend>
                                                    <asp:Label ID="Label5" runat="server" CssClass="label" Font-Italic="False" BackColor="White" Font-Bold="True" ForeColor="#0033CC">VMG</asp:Label></legend>
                                                <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                                                    <tr>
                                                        <td align="right" width="20%">
                                                            <asp:Label ID="Label20" runat="server" CssClass="label">Người ký hợp đồng:</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtSurrogate_A" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                                Width="100%" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label21" runat="server" CssClass="label">Đầu mối kinh doanh:</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="DropDownListBusiness_Name_A" runat="server" CssClass="droplist" AutoPostBack="True">
                                                                <asp:ListItem Value="0">--Chọn--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label71" runat="server" CssClass="label">Chức vụ:</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtBusiness_Competence_A" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                                Width="60%" Font-Bold="False"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label22" runat="server" CssClass="label">Email kinh doanh:</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtBusiness_Email_A" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                                Width="60%" Font-Bold="False"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label23" runat="server" CssClass="label">Điện thoại kinh doanh:</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtBusiness_Mobile_A" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                                Width="30%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">&nbsp;</td>
                                                        <td align="left">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label37" runat="server" CssClass="label">Đầu mối kỹ thuật:</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="DropDownListTechnical_Name_A" runat="server" CssClass="droplist" AutoPostBack="True">
                                                                <asp:ListItem Value="0">--Chọn--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label72" runat="server" CssClass="label">Chức vụ:</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtTechnical_Competence_A" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                                Width="60%" Font-Bold="False"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label38" runat="server" CssClass="label">Email kỹ thuật:</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtTechnical_Email_A" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                                Width="60%" Font-Bold="False"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label39" runat="server" CssClass="label">Điện thoại kỹ thuật:</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtTechnical_Mobile_A" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                                Width="30%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">&nbsp;</td>
                                                        <td align="left">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label43" runat="server" CssClass="label">Đầu mối đối soát:</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="DropDownListData_Name_A" runat="server" CssClass="droplist" AutoPostBack="True">
                                                                <asp:ListItem Value="0">--Chọn--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label73" runat="server" CssClass="label">Chức vụ:</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtData_Competence_A" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                                Width="60%" Font-Bold="False"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label44" runat="server" CssClass="label">Email đối soát:</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtData_Email_A" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                                Width="60%" Font-Bold="False"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label45" runat="server" CssClass="label">Điện thoại đối soát:</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtData_Mobile_A" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                                Width="30%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">&nbsp;</td>
                                                        <td align="left">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label49" runat="server" CssClass="label">Đầu mối thanh toán:</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="DropDownListPayment_Name_A" runat="server" CssClass="droplist" AutoPostBack="True">
                                                                <asp:ListItem Value="0">--Chọn--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label74" runat="server" CssClass="label">Chức vụ:</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtPayment_Competence_A" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                                Width="60%" Font-Bold="False"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label50" runat="server" CssClass="label">Email thanh toán:</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtPayment_Email_A" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                                Width="60%" Font-Bold="False"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label51" runat="server" CssClass="label">Điện thoại thanh toán:</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtPayment_Mobile_A" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                                Width="30%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">&nbsp;</td>
                                                        <td align="left">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label55" runat="server" CssClass="label">Đầu mối CSKH:</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:DropDownList ID="DropDownListCcare_Name_A" runat="server" CssClass="droplist" AutoPostBack="True">
                                                                <asp:ListItem Value="0">--Chọn--</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label75" runat="server" CssClass="label">Chức vụ:</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtCcare_Competence_A" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                                Width="60%" Font-Bold="False"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label56" runat="server" CssClass="label">Email CSKH:</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtCcare_Email_A" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                                Width="60%" Font-Bold="False"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label57" runat="server" CssClass="label">Điện thoại CSKH:</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtCcare_Mobile_A" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                                Width="30%"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                </table>
                                            </fieldset>
                                        </td>
                                        <td>
                                            <fieldset id="fieldset2">
                                                <legend>
                                                    <asp:Label ID="Label6" runat="server" CssClass="label" Font-Italic="False" BackColor="White" Font-Bold="True" ForeColor="#0033CC">ĐỐI TÁC</asp:Label></legend>
                                                <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">
                                                    <tr>
                                                        <td align="right" width="20%">
                                                            <asp:Label ID="Label33" runat="server" CssClass="label">Người ký hợp đồng:</asp:Label>
                                                        </td>
                                                        <td align="center">
                                                            <asp:TextBox ID="txtSurrogate_B" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                                Width="100%" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label34" runat="server" CssClass="label">Đầu mối kinh doanh:</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtBusiness_Name_B" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                                Width="60%"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label76" runat="server" CssClass="label">Chức vụ:</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtBusiness_Competence_B" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                                Width="60%" Font-Bold="False"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label35" runat="server" CssClass="label">Email kinh doanh:</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtBusiness_Email_B" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                                Width="60%" Font-Bold="False"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label36" runat="server" CssClass="label">Điện thoại kinh doanh:</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtBusiness_Mobile_B" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                                Width="30%"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td align="right">&nbsp;</td>
                                                        <td align="left">&nbsp;</td>
                                                    </tr>

                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label40" runat="server" CssClass="label">Đầu mối kỹ thuật:</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtTechnical_Name_B" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                                Width="60%"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label77" runat="server" CssClass="label">Chức vụ:</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtTechnical_Competence_B" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                                Width="60%" Font-Bold="False"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label41" runat="server" CssClass="label">Email kỹ thuật:</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtTechnical_Email_B" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                                Width="60%" Font-Bold="False"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label42" runat="server" CssClass="label">Điện thoại kỹ thuật:</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtTechnical_Mobile_B" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                                Width="30%"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td align="right">&nbsp;</td>
                                                        <td align="left">&nbsp;</td>
                                                    </tr>

                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label8" runat="server" CssClass="label">Đầu mối đối soát:</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtData_Name_B" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                                Width="60%"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label78" runat="server" CssClass="label">Chức vụ:</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtData_Competence_B" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                                Width="60%" Font-Bold="False"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label9" runat="server" CssClass="label">Email đối soát:</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtData_Email_B" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                                Width="60%" Font-Bold="False"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label10" runat="server" CssClass="label">Điện thoại đối soát:</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtData_Mobile_B" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                                Width="30%"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td align="right">&nbsp;</td>
                                                        <td align="left">&nbsp;</td>
                                                    </tr>

                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label52" runat="server" CssClass="label">Đầu mối thanh toán:</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtPayment_Name_B" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                                Width="60%"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label79" runat="server" CssClass="label">Chức vụ:</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtPayment_Competence_B" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                                Width="60%" Font-Bold="False"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label53" runat="server" CssClass="label">Email thanh toán:</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtPayment_Email_B" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                                Width="60%" Font-Bold="False"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label54" runat="server" CssClass="label">Điện thoại thanh toán:</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtPayment_Mobile_B" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                                Width="30%"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td align="right">&nbsp;</td>
                                                        <td align="left">&nbsp;</td>
                                                    </tr>

                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label58" runat="server" CssClass="label">Đầu mối CSKH:</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtCcare_Name_B" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                                Width="60%"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label80" runat="server" CssClass="label">Chức vụ:</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtCcare_Competence_B" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                                Width="60%" Font-Bold="False"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label59" runat="server" CssClass="label">Email CSKH:</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtCcare_Email_B" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                                Width="60%" Font-Bold="False"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="Label60" runat="server" CssClass="label">Điện thoại CSKH:</asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtCcare_Mobile_B" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                                                Width="30%"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                </table>
                                            </fieldset>
                                        </td>

                                    </tr>
                                </table>

                            </fieldset>
                            <br />
                            <fieldset id="fieldsetAppendix">
                                <legend>
                                    <asp:Label ID="Label11" runat="server" CssClass="label" Font-Italic="true">5. Phụ lục hợp đồng </asp:Label>
                                </legend>
                                <table border="0" cellpadding="1" cellspacing="1" style="width: 100%">

                                    <tr>
                                        <td align="left">
                                            <asp:DataGrid ID="DataGrid" runat="server" AllowPaging="True" AutoGenerateColumns="false"
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
                                                            <asp:Label ID="lblOrder" runat="server" CssClass="label"
                                                                Text='<%# Container.ItemIndex+1 %>'>
                                                            </asp:Label>
                                                        </ItemTemplate>

                                                    </asp:TemplateColumn>

                                                    <asp:TemplateColumn HeaderText="SỐ PHỤ LỤC">
                                                        <ItemStyle Width="10%" HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "Appendix_Number")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="NGÀY KÝ">
                                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                                        <ItemTemplate>
                                                            <%#  datetime.Parse(DataBinder.Eval(Container.DataItem, "Appendix_Date")).ToString("dd-MM-yyyy")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="NỘI DUNG PHỤ LỤC">
                                                        <ItemStyle HorizontalAlign="Left" Width="70%" />
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "Appendix_Info")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                </Columns>
                                                <PagerStyle HorizontalAlign="Right" NextPageText="" PageButtonCount="5" PrevPageText=""
                                                    Visible="False" />
                                            </asp:DataGrid>

                                        </td>
                                    </tr>

                                </table>
                            </fieldset>
                            <table cellpadding="0" class="auto-style1">
                                <tr>
                                    <td width="20%" align="right">
                                        <asp:Label ID="Label61" runat="server" CssClass="label">Trạng thái hợp đồng:</asp:Label>
                                    </td>
                                    <td align="left" width="30%">
                                        <asp:DropDownList ID="DropDownListContract_Status" runat="server" CssClass="droplist">
                                            <asp:ListItem Value="1">Hợp tác</asp:ListItem>
                                            <asp:ListItem Value="0">Dừng</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td align="right" width="10%">
                                        <asp:Label ID="Label12" runat="server" CssClass="label">Ghi chú:</asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtDescription" runat="server" AutoCompleteType="Disabled" CssClass="txtContent"
                                            Height="40px" TextMode="MultiLine" Width="98%"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>



                        </div>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="RadPageView3" runat="server" Width="100%">
                        <div class="datagrid">

                            <telerik:RadGrid ID="RadGrid" runat="server" Width="100%" ShowStatusBar="true" StatusBarSettings-ReadyText="Kaio Corp"
                                SortingSettings-SortedBackColor="Azure" AutoGenerateColumns="False"
                                PageSize="100" AllowSorting="True" AllowMultiRowSelection="False" AllowPaging="True"
                                Skin="Hay">
                                <HeaderStyle Font-Names="Arial" Font-Size="8pt" />
                                <ItemStyle Font-Names="Arial" Font-Size="8pt" ForeColor="Black" />
                                <PagerStyle Mode="NumericPages"></PagerStyle>
                                <SortingSettings SortedBackColor="Azure" />
                                <ClientSettings>
                                    <Selecting AllowRowSelect="True" />
                                </ClientSettings>
                                <AlternatingItemStyle Font-Names="Arial" Font-Size="8pt" ForeColor="Black" />
                                <GroupHeaderItemStyle Font-Bold="False" Font-Size="8pt" Font-Underline="False"
                                    HorizontalAlign="Center" Font-Names="Arial" ForeColor="Black" />
                                <GroupPanel Font-Size="9pt">
                                </GroupPanel>
                                <MasterTableView Width="100%" DataKeyNames="ID" AllowMultiColumnSorting="True">
                                    <DetailTables>
                                        <telerik:GridTableView DataKeyNames="ID" Name="Orders" Width="100%">

                                            <Columns>
                                                <telerik:GridBoundColumn SortExpression="ID" HeaderText="MÃ" HeaderButtonType="TextButton"
                                                    DataField="ID" Visible="false">
                                                    <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                                    <ItemStyle Font-Bold="true" HorizontalAlign="Center" />
                                                </telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn HeaderText="BƯỚC" SortExpression="Task_Order_Current">
                                                    <HeaderStyle Width="5%" HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblTask_Order_Current_2" Text='<%# Eval("Task_Order_Current")%>' CssClass="label"></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="NỘI DUNG THỰC HIỆN" SortExpression="Task_Text_Curent">
                                                    <HeaderStyle Width="35%" HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblTask_Text_Curent_2" Text='<%# Eval("Task_Text_Curent")%>' CssClass="label"></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="THỰC HIỆN" SortExpression="Task_Text_Curent">
                                                    <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblDept_Text_Execute_Current_2" Text='<%# Eval("Dept_Text_Execute_Current")%>' CssClass="label"></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="TRẠNG THÁI ">
                                                    <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblStatus_Text_2" CssClass="label"><%# Eval("Status_Text")%> </asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>
                                                <telerik:GridTemplateColumn HeaderText="T/G ĐỊNH MỨC">
                                                    <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lbHour_Implement_Current_2" Text='<%# Eval("Hour_Implement_Current")%>' CssClass="label"></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>

                                                <telerik:GridTemplateColumn HeaderText="GHI CHÚ">
                                                    <HeaderStyle Width="20%" HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="lblDescription_2" Text='<%# Eval("Description")%>' CssClass="label"></asp:Label>
                                                    </ItemTemplate>
                                                </telerik:GridTemplateColumn>

                                            </Columns>
                                        </telerik:GridTableView>
                                    </DetailTables>
                                    <Columns>
                                        <telerik:GridBoundColumn SortExpression="ID" HeaderText="MÃ" HeaderButtonType="TextButton"
                                            DataField="ID" Visible="false">
                                            <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                            <ItemStyle Font-Bold="true" HorizontalAlign="Center" />
                                        </telerik:GridBoundColumn>

                                        <telerik:GridTemplateColumn HeaderText="THÁNG">
                                            <HeaderStyle Width="5%" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblMonth_1" CssClass="label" ForeColor="#cc0000"><%# Eval("Month")%>/<%# Eval("Year")%></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="BƯỚC" SortExpression="Task_Order_Current">
                                            <HeaderStyle Width="5%" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblTask_Order_Current_1" CssClass="label"><%# Eval("Task_Order_Current")%>/<%# Eval("Total_Task")%></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="NỘI DUNG THỰC HIỆN" SortExpression="Task_Text_Curent">
                                            <HeaderStyle Width="35%" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblTask_Text_Curent_1" Text='<%# Eval("Task_Text_Curent")%>' CssClass="label"></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="THỰC HIỆN" SortExpression="Task_Text_Curent">
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblDept_Text_Execute_Current_1" Text='<%# Eval("Dept_Text_Execute_Current")%>' CssClass="label"></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="TRẠNG THÁI ">
                                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblStatus_Text_1" CssClass="label"><%# Eval("Status_Text")%> </asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="TỔNG T/G ĐỊNH MỨC">
                                            <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblTotal_Hour_Implement_1" Text='<%# Eval("Total_Hour_Implement")%>' CssClass="label"></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridTemplateColumn HeaderText="T/G CẬP NHẬT">
                                            <HeaderStyle Width="15%" HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblUpdate_Time_1" Text='<%#  datetime.Parse(Eval("Update_Time")).ToString("dd/MM/yyyy hh:mm:ss")%>' CssClass="label"></asp:Label>
                                            </ItemTemplate>
                                        </telerik:GridTemplateColumn>

                                    </Columns>
                                </MasterTableView>
                            </telerik:RadGrid>



                        </div>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>


            </div>
        </div>
    </form>
</body>
</html>
