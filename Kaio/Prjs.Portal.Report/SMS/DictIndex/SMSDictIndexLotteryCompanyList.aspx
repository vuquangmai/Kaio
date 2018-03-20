<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SMSDictIndexLotteryCompanyList.aspx.vb" Inherits="Prjs.Portal.Report.SMSDictIndexLotteryCompanyList" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../../Styles/HQ.css" rel="stylesheet" type="text/css" />
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
                 <asp:TemplateColumn>
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderTemplate>
                               MÃ SMS
                            </HeaderTemplate>
                            <ItemTemplate>
                          <a class="datagridLinks" href='SMSDictIndexLotteryCompanyKeyword.aspx?objid=<%#Utils.EncryptText(Eval("Id")) %>&objtext=<%#Utils.EncryptText(Eval("Company_Text"))%>'
                                                        title="Quản lý mã SMS theo hợp đồng">
                                                        <img border="0" src="/images/SMS-icon.png" width="25px">
                                                    </a>
                            </ItemTemplate>

                        </asp:TemplateColumn>
                  
                        <asp:TemplateColumn HeaderText="TÊN CÔNG TY">
                            <ItemStyle Width="25%" HorizontalAlign="Left" />
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Company_Text")%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                          <asp:TemplateColumn HeaderText="MIỀN">
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Region_Text ")%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                          <asp:TemplateColumn HeaderText="NGÀY MỞ THƯỞNG">
                            <ItemStyle Width="35%" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Date_Result_Text")%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        
                      
                        <asp:TemplateColumn HeaderText="THỜI GIAN TẠO">
                            <ItemStyle HorizontalAlign="Center" Width="15%" />
                            <ItemTemplate>
                                <%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "Create_Time")).ToString("dd-MM-yyyy")%>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                   
                        <asp:TemplateColumn>
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderTemplate>
                                SỬA
                            </HeaderTemplate>
                            <ItemTemplate>
                                <a class="datagridLinks" title="Sửa" href='SMSDictIndexLotteryCompanyEdit.aspx?objid=<%# Utils.EncryptText(DataBinder.Eval(Container.DataItem, "ID")) %>'>
                                    <img border="0" src="/images/comment-edit-icon.png">
                                </a>
                            </ItemTemplate>

                        </asp:TemplateColumn>
                        <asp:TemplateColumn>
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderTemplate>
                                XÓA
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="deleter" runat="server" title="Xóa" BorderStyle="None"
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
