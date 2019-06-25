<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Edit.ascx.cs" Inherits="Admin_ItemsComments_Edit" %>

<table class="MainTable" cellspacing="0" cellpadding="0" width="100%" border="0" >
				<tr>
					<td>
			<table class="SubTable" cellspacing="0" cellpadding="0" width="100%" border="0" >
				<tr>
					<td class="Result" align="center" colspan="2">
						<asp:Label id="lblResult" runat="server"></asp:Label>
					</td>
				</tr>
				
				<tr id="trSenderName" runat="server" >
					<td class="text"><asp:Label ID="Label1" Text="<%$ Resources:Comments,Name %>" runat="server" /><span class="RequiredField"><asp:Label ID="Label2" runat="server" Text="*" /></span></td>
					<td class="Control">
						<asp:TextBox MaxLength="255" Enabled="false" id="txtSenderName" runat="server" CssClass="Controls" ValidationGroup="Comments" ></asp:TextBox>
						<asp:RequiredFieldValidator Display="Dynamic" id="rfvSenderName" runat="server" ErrorMessage="*" ControlToValidate="txtSenderName" ValidationGroup="Comments" Text="*"></asp:RequiredFieldValidator>
					</td>
				</tr>
				
				
				<tr id="trSendingDate" runat="server" >
					<td class="text"><asp:Label ID="Label3" Text="<%$ Resources:Comments,SendingDate %>" runat="server" /><span class="RequiredField"><asp:Label ID="Label4" runat="server" Text="*" /></span></td>
					<td class="Control">
                        <asp:Label ID="lblDate" runat="server" Text=""></asp:Label>
					</td>
				</tr>
				<tr id="trSenderEmail" runat="server" >
					<td class="text"><asp:Label ID="Label5" Text="<%$ Resources:Comments,Email %>" runat="server" /><span class="RequiredField"><asp:Label ID="Label6" runat="server" Text="*" /></span></td>
					<td class="Control">
						<asp:TextBox MaxLength="100" Enabled="false" id="txtSenderEmail" runat="server" CssClass="Controls" ValidationGroup="Comments"></asp:TextBox>
						<asp:RegularExpressionValidator Display="Dynamic" ID="revSenderEmail" runat="server" ControlToValidate="txtSenderEmail" ErrorMessage="" ValidationGroup="Comments" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
						<asp:RequiredFieldValidator Display="Dynamic" id="rfvSenderEmail" runat="server" ErrorMessage="*" ControlToValidate="txtSenderEmail" ValidationGroup="Comments" Text="*"></asp:RequiredFieldValidator>
					</td>
				</tr>
				<tr id="trCommentTitle" runat="server" >
					<td class="text"><asp:Label ID="Label7" Text="<%$ Resources:Comments,Title %>" runat="server" /><span class="RequiredField"><asp:Label ID="Label8" runat="server" Text="*" /></span></td>
					<td class="Control">
						<asp:TextBox MaxLength="200" id="txtCommentTitle" runat="server"  CssClass="Controls" ValidationGroup="Comments"  ></asp:TextBox>
						
						<asp:RequiredFieldValidator Display="Dynamic" id="rfvCommentTitle" runat="server" ErrorMessage="*" ControlToValidate="txtCommentTitle" ValidationGroup="Comments" Text="*"></asp:RequiredFieldValidator>
					</td>
				</tr>
				<tr id="trCommentText" runat="server" >
					<td class="text"><asp:Label ID="Label9" Text="<%$ Resources:Comments,TheComment %>" runat="server" /><span class="RequiredField"><asp:Label ID="Label10" runat="server" Text="*" /></span></td>
					<td class="Control">
						<asp:TextBox MaxLength="1000" id="txtCommentText" runat="server" 
                            TextMode="MultiLine" CssClass="Controls" ValidationGroup="Comments"  
                            maxlengthS="1000" 
                            onkeyup="return ismaxlength(this,document.forms[0].txtCommentTextLengthControler)"  
                            onfocus="return ismaxlength(this,document.forms[0].txtCommentTextLengthControler)" 
                            Height="220px" Width="294px"></asp:TextBox>
						<input type="text"  class="Controls"  name="txtCommentTextLengthControler" id="txtCommentTextLengthControler" style="width: 40px;"  disabled>
						<asp:RequiredFieldValidator Display="Dynamic" id="rfvCommentText" runat="server" ErrorMessage="*" ControlToValidate="txtCommentText" ValidationGroup="Comments" Text="*"></asp:RequiredFieldValidator>
					</td>
				</tr>
				<tr id="trIsActive" runat="server" >
					<td class="text"><asp:Label ID="Label11" Text="<%$ Resources:Comments,Activate %>" runat="server" /><span class="RequiredField"><asp:Label ID="Label12" runat="server" Text="*" /></span></td>
					<td class="Control">
						<asp:CheckBox id="cbIsActive" CssClass="Controls" runat="server" ValidationGroup="Comments"></asp:CheckBox>
					</td>
				</tr>
				
				
				<tr>
					<td class="Result" align="center" colspan="2">
					      <asp:Button ID="btnSave"  runat="server"   ValidationGroup="Comments" onclick="btnSave_Click"  SkinID="btnSave"   />
					</td>
				</tr>
				</table>
			</td>
		</tr>
	</table>