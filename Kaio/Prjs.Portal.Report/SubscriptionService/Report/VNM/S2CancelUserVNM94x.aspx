<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="S2CancelUserVNM94x.aspx.vb" Inherits="Prjs.Portal.Report.S2CancelUserVNM94x" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="ASPnetPagerV2_8" Namespace="ASPnetControls" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <link href="../../../Styles/HQ.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/LightStyle.css" rel="stylesheet" type="text/css" />
    <link href="../../../Styles/RadTreeView.css" type="text/css" rel="stylesheet" />

    <script language="javascript" type="text/javascript" src="../../../../Js/Menu3.js"></script>
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

        .RadPicker {
            vertical-align: middle;
        }

        .RadPicker {
            vertical-align: middle;
        }

        .RadPicker {
            vertical-align: middle;
        }

            .RadPicker .rcTable {
                table-layout: auto;
            }

            .RadPicker .rcTable {
                table-layout: auto;
            }

            .RadPicker .rcTable {
                table-layout: auto;
            }

            .RadPicker .RadInput {
                vertical-align: baseline;
            }

            .RadPicker .RadInput {
                vertical-align: baseline;
            }

            .RadPicker .RadInput {
                vertical-align: baseline;
            }

        .RadInput_Default {
            font: 12px "segoe ui",arial,sans-serif;
        }

        .RadInput {
            vertical-align: middle;
            width: 160px;
        }

        .RadInput_Default {
            font: 12px "segoe ui",arial,sans-serif;
        }

        .RadInput {
            vertical-align: middle;
            width: 160px;
        }

        .RadInput_Default {
            font: 12px "segoe ui",arial,sans-serif;
        }

        .RadInput {
            vertical-align: middle;
            width: 160px;
        }

        .RadInput_Default {
            font: 12px "segoe ui",arial,sans-serif;
        }

        .RadInput {
            vertical-align: middle;
            width: 160px;
        }

        .RadInput_Default {
            font: 12px "segoe ui",arial,sans-serif;
        }

        .RadInput {
            vertical-align: middle;
            width: 160px;
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
            
          
                <div class="input" style="width: 40%">
                    <table width="100%">
                        <tr>
                            <td align="right" width="30%">
                                <asp:Label ID="lblTrang13" runat="server" CssClass="label">Số điện thoại:</asp:Label>
                            </td>
                            <td align="left">


                                <asp:TextBox ID="txtUser_Id" runat="server" AutoCompleteType="Disabled" CssClass="txtContent" Font-Bold="True" ForeColor="#0033CC" Width="60%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="30%">
                                &nbsp;</td>
                            <td align="left">
                    <asp:Button ID="btnSearch" runat="server" CssClass="btnbackground"
                        Text="Tìm kiếm" />
                    <asp:Button ID="btnExport" runat="server" CssClass="btnbackground"
                        Text="Báo cáo" />
                            </td>
                        </tr>
                    </table>
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
                                               <asp:TemplateColumn HeaderText="MÃ">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "UserID")%>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="8%" />
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="SỐ ĐIỆN THOẠI">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "Msisdn")%>
                                                </ItemTemplate>
                                                <ItemStyle Width="8%" HorizontalAlign="Center" />
                                            </asp:TemplateColumn>
                                         
                                            <asp:TemplateColumn HeaderText="DỊCH VỤ">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "ServiceName")%>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="8%" />
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="REF NAME">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "RefName")%>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="8%" />
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="THỜI GIAN ĐĂNG KÝ">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "RegisteredTime")%>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="8%" />
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="KÊNH ĐĂNG KÝ">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "Registration_Channel")%>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                                            </asp:TemplateColumn>
                                          <asp:TemplateColumn>
                                                <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderTemplate>
                                                    HỦY 
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="deleter" runat="server" AlternateText="Delete" BorderStyle="None"
                                                        CausesValidation="False" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "UserID")%>'
                                                        ImageAlign="absmiddle" ImageUrl="/images/del.gif" OnCommand="DelData" />
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
