<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ChargingDictIndexUrlList.aspx.vb" Inherits="Prjs.Portal.Report.ChargingDictIndexUrlList" %>
<%@ Register Assembly="ASPnetPagerV2_8" Namespace="ASPnetControls" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../../Styles/HQ.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/LightStyle.css" rel="stylesheet" type="text/css" />
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="HQ">
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
            </telerik:RadScriptManager>
            <div class="alert">
                <asp:Label ID="lbltitle" runat="server" CssClass="lbltitle"></asp:Label><br />
                <asp:Label ID="lblerror" runat="server" CssClass="lblerror"></asp:Label>
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
                        <asp:TemplateColumn HeaderText="ACCOUNT">
                            <ItemStyle Width="5%" HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label ID="lblUrl" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Url")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="TRẠNG THÁI">
                            <ItemStyle HorizontalAlign="Center" Width="8%" />
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Status")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="MÃ">
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                            <ItemTemplate>
                                <asp:Label ID="lblUrl_Code" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Url_Code")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                             <asp:TemplateColumn HeaderText="TỶ LỆ SAU TELCOS">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <table width="100%">
                                    <tr>
                                        <td align="center"><asp:Label ID="lblRatio_After_VIETTEL" runat="server" CssClass="label" Font-Bold ="true" >VIETTEL: </asp:Label></td>
                                            <td align="right"><asp:Label ID="Label1" runat="server" CssClass="label" Font-Bold ="true" >  <%# DataBinder.Eval(Container.DataItem, "Ratio_After_VIETTEL")%></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td align="center"><asp:Label ID="Label2" runat="server" CssClass="label" Font-Bold ="true" >VMS: </asp:Label></td>
                                            <td align="right"><asp:Label ID="Label3" runat="server" CssClass="label" Font-Bold ="true" >  <%# DataBinder.Eval(Container.DataItem, "Ratio_After_VMS")%></asp:Label></td>
                                    </tr>
                                       <tr>
                                        <td align="center"><asp:Label ID="Label4" runat="server" CssClass="label" Font-Bold ="true" >VNP: </asp:Label></td>
                                            <td align="right"><asp:Label ID="Label5" runat="server" CssClass="label" Font-Bold ="true" >  <%# DataBinder.Eval(Container.DataItem, "Ratio_After_VNP")%></asp:Label></td>
                                    </tr>
                                         <tr>
                                        <td align="center"><asp:Label ID="Label6" runat="server" CssClass="label" Font-Bold ="true" >VNM: </asp:Label></td>
                                            <td align="right"><asp:Label ID="Label7" runat="server" CssClass="label" Font-Bold ="true" >  <%# DataBinder.Eval(Container.DataItem, "Ratio_After_VNM")%></asp:Label></td>
                                    </tr>
                                </table>
                                
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="TỶ LỆ SAU VMG">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                  <table width="100%">
                                       <tr>
                                        <td align="center"><asp:Label ID="Label8" runat="server" CssClass="label" Font-Bold ="true" >VIETTEL: </asp:Label></td>
                                            <td align="right"><asp:Label ID="Label9" runat="server" CssClass="label" Font-Bold ="true" >  <%# DataBinder.Eval(Container.DataItem, "Ratio_After_VMG_VIETTEL")%></asp:Label></td>
                                    </tr>
                                         <tr>
                                        <td align="center"><asp:Label ID="Label10" runat="server" CssClass="label" Font-Bold ="true" >VMS: </asp:Label></td>
                                            <td align="right"><asp:Label ID="Label11" runat="server" CssClass="label" Font-Bold ="true" >  <%# DataBinder.Eval(Container.DataItem, "Ratio_After_VMG_VMS")%></asp:Label></td>
                                    </tr>
                                           <tr>
                                        <td align="center"><asp:Label ID="Label12" runat="server" CssClass="label" Font-Bold ="true" >VNP: </asp:Label></td>
                                            <td align="right"><asp:Label ID="Label13" runat="server" CssClass="label" Font-Bold ="true" >  <%# DataBinder.Eval(Container.DataItem, "Ratio_After_VMG_VNP")%></asp:Label></td>
                                    </tr>
                                             <tr>
                                        <td align="center"><asp:Label ID="Label14" runat="server" CssClass="label" Font-Bold ="true" >VNM: </asp:Label></td>
                                            <td align="right"><asp:Label ID="Label15" runat="server" CssClass="label" Font-Bold ="true" >  <%# DataBinder.Eval(Container.DataItem, "Ratio_After_VMG_VNM")%></asp:Label></td>
                                    </tr>
                                  </table>
                            
                            </ItemTemplate>
                        </asp:TemplateColumn>
                           <asp:TemplateColumn HeaderText="ĐỐI TÁC">
                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                            <ItemTemplate>
                                <asp:Label ID="lblPartner_Text" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Partner_Text")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                           <asp:TemplateColumn HeaderText="MÃ ĐỐI TÁC">
                            <ItemStyle HorizontalAlign="Center" Width="6%" />
                            <ItemTemplate>
                                <asp:Label ID="lblPartner_Code" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Partner_Code")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="NGƯỜI TẠO">
                            <ItemStyle HorizontalAlign="Center" Width="6%" />
                            <ItemTemplate>
                                <asp:Label ID="lblCreate_By_Text" runat="server" CssClass="label">   <%# DataBinder.Eval(Container.DataItem, "Create_By_Text")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="THỜI GIAN TẠO">
                            <ItemStyle HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                
                                <asp:Label ID="lblCreate_Time" runat="server" CssClass="label"><%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "Create_Time")).ToString("dd-MM-yyyy")%></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="GHI CHÚ">
                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Description")%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn>
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderTemplate>
                                SỬA
                            </HeaderTemplate>
                            <ItemTemplate>
                                <a class="datagridLinks" title="Sửa đổi thông tin" href='ChargingDictIndexUrlEdit.aspx?objid=<%# Utils.EncryptText(DataBinder.Eval(Container.DataItem, "ID")) %>'>
                                    <img border="0" src="/images/comment-edit-icon.png">
                                </a>
                            </ItemTemplate>

                        </asp:TemplateColumn>
                        <asp:TemplateColumn>
                            <HeaderStyle HorizontalAlign="Center" Width="3%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderTemplate>
                                XÓA
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="deleter" runat="server" title="xóa thông tin" BorderStyle="None"
                                    CausesValidation="False" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID")%>'
                                    ImageAlign="absmiddle" ImageUrl="~/Images/del.gif" OnCommand="DelData" />
                            </ItemTemplate>

                        </asp:TemplateColumn>
                    </Columns>
                    <PagerStyle HorizontalAlign="Right" NextPageText="" PageButtonCount="5" PrevPageText=""
                        Visible="False" />
                </asp:DataGrid>

            </div>
            <div class="submmit">
                <asp:Button ID="btnAdd" runat="server" CssClass="btnbackground" Font-Bold="False"
                    Text="Thêm" />
            </div>

        </div>
    </form>
</body>
</html>
