<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="BilScratchCardWorkFollowList.aspx.vb" Inherits="Prjs.Portal.Report.BilScratchCardWorkFollowList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../Styles/HQ.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function IsDetail(contractId, year, month) {
            window.open("../../Charging/DictIndex/ChargingContractInfo.aspx?objid=" + contractId + "&year=" + year + "&month=" + month, "Bil_Scratch_Info", "location=no,directories=no,left=0,top=0,height=900,width=1000,status=no,scrollbars=yes,toolbars=no,menubar=no,resizable=yes");
        }

    </script>
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
            <div class="input" style="width: 90%">
                <table border="0" cellpadding="2" cellspacing="1" style="width: 100%">
                    <tr>
                        <td align="right" width="10%">
                            <asp:Label ID="Label7" runat="server" CssClass="label">Năm:</asp:Label>
                        </td>
                        <td align="left" width="40%">
                            <asp:DropDownList ID="DropDownListYear" runat="server" CssClass="droplist">
                            </asp:DropDownList>
                        </td>
                        <td align="right" width="15%">
                            <asp:Label ID="Label29" runat="server" CssClass="label">Số hợp đồng:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtContract_Number" runat="server" AutoCompleteType="Disabled" CssClass="txtContent" Width="80%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label26" runat="server" CssClass="label">Tháng:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListMonth" runat="server" CssClass="droplist" AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label30" runat="server" CssClass="label">Mã hợp đồng:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtContract_Code" runat="server" AutoCompleteType="Disabled" CssClass="txtContent" Width="80%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label27" runat="server" CssClass="label">Đối tác (chọn):</asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListPartner_Id" runat="server" CssClass="droplist" Font-Bold="False">
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label31" runat="server" CssClass="label">Loại đối tác:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListTypeOfPartner" runat="server" CssClass="droplist" Font-Bold="False">
                                <asp:ListItem>--all--</asp:ListItem>
                                <asp:ListItem Value="1">Telcos</asp:ListItem>
                                <asp:ListItem Value="0">Sub CPs</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label28" runat="server" CssClass="label">Đối tác (nhập):</asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtPartner_Text" runat="server" AutoCompleteType="Disabled" CssClass="txtContent" Width="80%"></asp:TextBox>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label32" runat="server" CssClass="label">Bộ phận thực hiện:</asp:Label>
                        </td>
                        <td align="left">

                            <asp:DropDownList ID="DropDownListDept_Id_Execute_Current" runat="server" CssClass="droplist">
                            </asp:DropDownList>

                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label34" runat="server" CssClass="label">Doanh thu:</asp:Label>
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="DropDownListHave_Revenue" runat="server" CssClass="droplist">
                                <asp:ListItem Value="Y">Phát sinh doanh thu</asp:ListItem>
                                <asp:ListItem Value="N">Không phát sinh doanh thu</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            <asp:Label ID="Label33" runat="server" CssClass="label">Bước thực hiện:</asp:Label>
                        </td>
                        <td align="left">

                            <asp:DropDownList ID="DropDownListTask_Id" runat="server" CssClass="droplist">
                            </asp:DropDownList>

                        </td>
                    </tr>
                </table>
            </div>
            <div class="submmit">
                <asp:Button ID="btnSearching" runat="server" CssClass="btnbackground"
                    Text="Tìm kiếm" />
                <asp:Button ID="btnExp" runat="server" CssClass="btnbackground"
                    Text="Báo cáo" />
            </div>
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
                                        <HeaderStyle Width="25%" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblTask_Text_Curent_2" Text='<%# Eval("Task_Text_Curent")%>' CssClass="label"></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="THỰC HIỆN" SortExpression="Task_Text_Curent">
                                        <HeaderStyle Width="7%" HorizontalAlign="Center" />
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

                                    <telerik:GridTemplateColumn HeaderText="CẬP NHẬT" SortExpression="Status_Text">
                                        <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblUpdate_By_Text_2" Text='<%# Eval("Update_By_Text")%>' CssClass="label"></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="T/G CẬP NHẬT">
                                        <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblUpdate_Time_2" Text='<%#  datetime.Parse(Eval("Update_Time")).ToString("dd/MM/yyyy hh:mm:ss")%>' CssClass="label"></asp:Label>
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
                            <telerik:GridTemplateColumn HeaderText="#">
                                <HeaderStyle Width="2%" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Right" />
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblOrder" Font-Bold="true" Text='<%# Container.ItemIndex+1 %>' CssClass="label"></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="HỢP ĐỒNG" SortExpression="Contract_Code">
                                <HeaderStyle Width="5%" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <a href="JavaScript:IsDetail('<%#Eval("Contract_Code")%>','<%#Eval("Year")%>','<%#Eval("Month")%>')" title="Thông tin chi tiết">
                                    <asp:Label ID="lblContract_Code_1" runat="server" CssClass="label">   <%# Eval("Contract_Code")%></asp:Label></a>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>

                            <telerik:GridTemplateColumn HeaderText="ĐỐI TÁC" SortExpression="Partner_Text">
                                <HeaderStyle Width="25%" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblPartner_Text_1" Text='<%# Eval("Partner_Text")%>' CssClass="label" Font-Bold="true" ></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
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
                                    <asp:Label runat="server" ID="lblTask_Order_Current_1" Font-Bold="true" CssClass="label"><%# Eval("Task_Order_Current")%>/<%# Eval("Total_Task")%></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="NỘI DUNG THỰC HIỆN" SortExpression="Task_Text_Curent">
                                <HeaderStyle Width="25%" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblTask_Text_Curent_1" Text='<%# Eval("Task_Text_Curent")%>' CssClass="label"></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="THỰC HIỆN" SortExpression="Task_Text_Curent">
                                <HeaderStyle Width="7%" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblDept_Text_Execute_Current_1" Text='<%# Eval("Dept_Text_Execute_Current")%>' CssClass="label"></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="TRẠNG THÁI ">
                                <HeaderStyle Width="8%" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblStatus_Text_1" CssClass="label"><%# Eval("Status_Text")%> </asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                           
                            <telerik:GridTemplateColumn HeaderText="T/G CẬP NHẬT">
                                <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblUpdate_Time_1" Text='<%#  datetime.Parse(Eval("Update_Time")).ToString("dd/MM/yyyy hh:mm:ss")%>' CssClass="label"></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="#">
                                <HeaderStyle Width="3%" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblDept_Id_Execute_Current_1" Visible='<%# SetVisiblIcon(Eval("Dept_Id_Execute_Current"))%>' CssClass="label">
                                                          <a class="datagridLinks" href='BilScratchCardWorkFollowEdit.aspx?objid=<%#Utils.EncryptText(Eval("ID")) %>'
                                                        title="Cập nhật thông tin">
                                                        <img border="0" src="/images/comment-edit-icon.png">
                                                    </a>

                                    </asp:Label>

                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>



            </div>
        </div>
    </form>
</body>
</html>
