<%@ Page trace="False" Inherits="AWS.FilePicker.FileManager" CodeBehind="FilePicker.aspx.vb" Language="vb" AutoEventWireup="false" %>
<%@ Register TagPrefix="cc1" Namespace="ChrisDengler.WebUI.Components" Assembly="WebMsgBox" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.IO.Path" %>
<HTML>
	<HEAD>
		<TITLE>
			Kaio Jsc - Upload file
		</TITLE>
		<META http-equiv="Content-Type" content="text/html">
		<LINK href="styles.css" type="text/css" rel="stylesheet">
			<script language="javascript" src="menu.js"></script>
	</HEAD>
	<body>
		<form id="formExplorer" encType="multipart/form-data" runat="server">
			<table class="background" cellSpacing="2" cellPadding="2" width="100%" border="0">
				<tr>
					<td align="center" width="100%" colSpan="15">
						<table cellSpacing="7" cellPadding="0" border="0">
							<tr>
								<td class="buttonOff" onmouseover="changeBg(this,'buttonOn')" onmouseout="changeBg(this,'buttonOff')"><asp:imagebutton id="btnRoot" onclick="NavigateHome" runat="server" width="24" height="24" imageurl="Images/Root.gif"></asp:imagebutton></td>
								<td class="buttonOff" onmouseover="changeBg(this,'buttonOn')" onmouseout="changeBg(this,'buttonOff')"><asp:imagebutton id="btnNavigateUp" onclick="NavigateUp" runat="server" width="24" height="24" imageurl="Images/Up.gif"></asp:imagebutton></td>
								<td class="buttonOff" onmouseover="changeBg(this,'buttonOn')" onmouseout="changeBg(this,'buttonOff')"><asp:imagebutton id="btnCopy" onclick="Copy" runat="server" width="24" height="24" imageurl="Images/Copy.gif"></asp:imagebutton></td>
								<td class="buttonOff" onmouseover="changeBg(this,'buttonOn')" onmouseout="changeBg(this,'buttonOff')"><asp:imagebutton id="btnCut" onclick="Cut" runat="server" width="24" height="24" imageurl="Images/Cut.gif"></asp:imagebutton></td>
								<td class="buttonOff" onmouseover="changeBg(this,'buttonOn')" onmouseout="changeBg(this,'buttonOff')"><asp:imagebutton id="btnPaste" onclick="Paste" runat="server" width="24" height="24" imageurl="Images/Paste.gif"></asp:imagebutton></td>
								<td class="buttonOff" onmouseover="changeBg(this,'buttonOn')" onmouseout="changeBg(this,'buttonOff')"><asp:imagebutton id="btnNewFolder" onclick="NewFolder" runat="server" width="24" height="24" imageurl="Images/NewFolder.gif"></asp:imagebutton></td>
								<td class=buttonOff onmouseover="changeBg(this,'buttonOn')" 
          onclick="javascript: return confirm('<%=deleteConfirmation %>');" 
          onmouseout="changeBg(this,'buttonOff')"><asp:imagebutton id="btnDelete" onclick="Delete" runat="server" width="24" height="24" imageurl="Images/Delete.gif"></asp:imagebutton></td>
								<td class="buttonOff" onmouseover="changeBg(this,'buttonOn')" onmouseout="changeBg(this,'buttonOff')"><asp:imagebutton id="btnRefresh" onclick="Refresh" runat="server" width="24" height="24" imageurl="Images/Refresh.gif"></asp:imagebutton></td>
								<td class="buttonOff" onmouseover="changeBg(this,'buttonOn')" onmouseout="changeBg(this,'buttonOff')"><asp:imagebutton id="btnReserverCheck" onclick="ReverseCheck" runat="server" width="24" height="24"
										imageurl="Images/ReverseCheck.gif"></asp:imagebutton></td>
								<td class="buttonOff" onmouseover="changeBg(this,'buttonOn')" onmouseout="changeBg(this,'buttonOff')"><asp:imagebutton id="btnToggleThumbnails" onclick="ToggleThumbnails" runat="server" width="24" height="24"
										imageurl="Images/ThumbNail.gif"></asp:imagebutton></td>
								<td class="buttonOff" onmouseover="changeBg(this,'buttonOn')" onmouseout="changeBg(this,'buttonOff')"><asp:imagebutton id="btnUpload" onclick="ShowUpload" runat="server" width="24" height="24" imageurl="Images/Upload.gif"></asp:imagebutton></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td colSpan="15"><cc1:webmsgbox id="wmbMessage" runat="server" MsgBoxIcon="vbExclamation" Enabled="False"></cc1:webmsgbox>
						<div id="ProgressBarPanel" style="DISPLAY: none">
							<table align="center">
								<tr>
									<td><span class="languageSelector"><b><%=rm.GetString("LOC_LABEL_PLEASEWAIT")%>
											</b>
										</span><IMG id="ProgressBar" height="13" src="Images/Progress.gif" width="240" border="0">
									</td>
								</tr>
							</table>
						</div>
						<asp:panel id="PanelUpload" runat="server" CssClass="Panel" visible="false">
							<TABLE align="center">
								<TR align="center">
									<TD colSpan="2" height="30"><INPUT class="textBox" id="inputFileName" type="file" name="inputFileName" runat="server">
										<A href="javascript:ShowProgressBar('uploadfileLink')"><IMG height=24 
            alt='<%=rm.GetString("LOC_LABEL_UPLOAD_UPLOADFILE")%>' 
            src="Images/Save.gif" width=24 align=absMiddle border=0> </A>
										<asp:LinkButton id="uploadfileLink" onclick="uploadFile" runat="server" Visible="true" EnableViewState="False"></asp:LinkButton></TD>
								<TR align="left">
									<TD colSpan="2">
										<FIELDSET class="fieldset">
											<LEGEND>
												<B>
													<%=rm.GetString("LOC_LABEL_UPLOAD_IFZIPUPLOADED")%>
												</B>
											</LEGEND>
											<asp:RadioButtonList id="rblUploadOptions" runat="server" CssClass="radiolist" RepeatColumns="3">
												<asp:ListItem />
												<asp:ListItem />
												<asp:ListItem selected="true" />
											</asp:RadioButtonList>
										</FIELDSET><BR>
										<FIELDSET class="fieldset">
											<LEGEND>
												<B>
													<%=rm.GetString("LOC_LABEL_UPLOAD_OPTIONS")%>
												</B>
											</LEGEND>
											<NOBR>
												<asp:CheckBox id="chkSelectUponUpload" runat="server" Checked="True"></asp:CheckBox></NOBR><NOBR>
												<asp:CheckBox id="chkOverwrite" runat="server"></asp:CheckBox></NOBR><BR>
											<BR>
											<asp:Label id="lblUploadNote" runat="server"></asp:Label>
										</FIELDSET></TD>
								</TR>
							</TABLE>
						</asp:panel></td>
				</tr>
				<asp:placeholder id="phLanguageSelector" Runat="server"></asp:placeholder>
				<tr>
					<td colSpan="15"><asp:textbox id="txtCurrentPath" runat="server" CssClass="pathTextBox" ReadOnly="True"></asp:textbox></td>
				</tr>
				<tr>
					<td colSpan="15"><span class="info"><asp:label id=Info runat="server" Text='<b><%=rm.GetString("LOC_LABEL_INFO")%> </b>' cssClass="text"></asp:label>
						</span></td>
				</tr>
				<tr align="right">
					<td colSpan="14"></td>
					<td align="right"><A href="#Bottom"><IMG height=5 alt='<%=rm.GetString("LOC_LABEL_BOTTOM")%>' src="Images/Bottom.gif" width=9 align=bottom border=0 ></A></td>
				</tr>
				<tr>
					<td colSpan="15"><asp:datagrid id="dgExplorer" Runat="server" cssClass="fileFolderGrid" OnItemCommand="ItemCommand"
							CellPadding="2" Width="100%" GridLines="Horizontal" OnItemCreated="Created" OnUpdateCommand="Update" OnCancelCommand="Cancel"
							OnEditCommand="Edit" OnSortCommand="Sort" DataKeyField="Id" AllowSorting="True" BorderColor="#0053A5" AutoGenerateColumns="False">
							<ItemStyle BackColor="#FFFFFF"></ItemStyle>
							<AlternatingItemStyle BackColor="#CFDFE5"></AlternatingItemStyle>
							<Columns>
								<asp:TemplateColumn ItemStyle-HorizontalAlign="Center">
									<HeaderStyle CssClass="fileFolderGridHeader" Width="5%" HorizontalAlign="Center"></HeaderStyle>
									<ItemTemplate>
										<a name='<%# Container.DataItem("Id") %>'>
											<asp:CheckBox Id="chkSelected" Checked='<%# Container.DataItem("Chk") %>' runat='Server'/>
										</a>
									</ItemTemplate>
									<HeaderTemplate>
										<asp:CheckBox id="chkSelectAll" onclick="javascript:SelectAllCheckboxes(this);" runat="server"
											AutoPostBack="false" />
									</HeaderTemplate>
									<EditItemTemplate>
										<asp:CheckBox Id="chkSelected" Checked='<%# Container.DataItem("Chk") %>' runat='server'/>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn SortExpression="Name">
									<HeaderStyle Width="35%" CssClass="fileFolderGridHeader"></HeaderStyle>
									<ItemTemplate>
										<nobr>
											<asp:ImageButton runat="server" ImageAlign="Middle" ImageUrl = '<%# GetFileDirPictureUrl(Container.DataItem("Type"), Container.DataItem("Name"))%>' OnCommand='NavigateDown' ID="Icon" AlternateText='<%# Container.DataItem("Name") %>' CommandName='<%# Container.DataItem("Type") %>'>
											</asp:ImageButton>
											<asp:LinkButton Id="Name" CssClass="link" Text='<%# Container.DataItem("Name") %>' CommandName='<%# Container.DataItem("Type") %>' OnCommand='NavigateDown' runat='server'/>
										</nobr>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:TextBox Id="Name" CssClass='newNameTextBox' Text='<%# Container.DataItem("Name") %>' runat='server'/>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn SortExpression="Length">
									<HeaderStyle Width="15%" CssClass="fileFolderGridHeader"></HeaderStyle>
									<ItemTemplate>
										<asp:Label Id="Length" Text='<%# Container.DataItem("Length") %>' runat='server' CssClass='<%# DirectoryAlign(Container.DataItem("Type")) %>'/>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:Label Id="Length" Text='<%# Container.DataItem("Length") %>' runat='server' CssClass='<%# DirectoryAlign(Container.DataItem("Type")) %>'/>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn SortExpression="Updated">
									<HeaderStyle Width="20%" CssClass="fileFolderGridHeader"></HeaderStyle>
									<ItemTemplate>
										<asp:Label Runat="server" Text=' <%# Container.DataItem("Updated") %> ' ID="Updated"/>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:Label Runat="server" Text=' <%# Container.DataItem("Updated") %> ' ID="Label2"/>
									</EditItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn ItemStyle-HorizontalAlign="Center">
									<HeaderStyle Width="15%" CssClass="fileFolderGridHeader"></HeaderStyle>
									<ItemTemplate>
										<asp:ImageButton CommandName="Edit" runat="server" imageurl="Images/Rename.gif" width="24" height="16"
											id="btnRename" EnableViewState="False" /> 
										<asp:ImageButton CommandName="Download" runat="server" imageurl='<%#GetDownloadImageUrl(Container.DataItem("Type"))%>' width="24" height="16" id="btnDownload"/>
									</ItemTemplate>
									<EditItemTemplate>
										<asp:ImageButton CommandName="Update" runat="server" imageurl="Images/Ok.gif" id="btnRenameOk" EnableViewState="False" />
										<asp:ImageButton CommandName="Cancel" runat="server" imageurl="Images/Cancel.gif" id="btnRenameCancel"
											EnableViewState="False" />
									</EditItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid></td>
				</tr>
				<tr align="right">
					<td colSpan="14"></td>
					<td align="right"><A href="#Top"><IMG height=5 alt='<%=rm.GetString("LOC_LABEL_TOP")%>' src="Images/Top.gif" width=9 border=0 ></A></td>
				</tr>
			</table>
			<a name="#Bottom"></a>
		</form>
		
	</body>
</HTML>
