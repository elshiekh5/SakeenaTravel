<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Show.ascx.cs" Inherits="AdminCP__UserControls_MailList_MailListArchive_Show" %>
<table class="MainTable" cellspacing="0" cellpadding="0" width="100%" border="0" >
				<tr>
					<td>
			<table class="SubTable" cellspacing="0" cellpadding="0" width="100%" border="0" >
				<tr>
					<td class="Result" align="center" colspan="2">
						<asp:Label id="lblResult" runat="server"></asp:Label>
					</td>
				</tr>
				<tr id="trGroups" runat="server">
					<td class="text"><asp:Label ID="Label2"  Text="<%$ Resources:MailListAdmin,Email_SendingDate %>" runat="server" /></td>
					<td class="text"><asp:Label ID="lblDate_Added" Text="" runat="server" /></td>
				</tr>
				<tr id="trTo" runat="server">
					<td class="text" width="100px"><asp:Label ID="Label4" Text="<%$ Resources:MailListAdmin,Email_SendingTo %>" runat="server" /></td>
					<td class="text">
                        <asp:Label ID="lblTo" runat="server" Text=""></asp:Label>
						</td>
				</tr>
				<tr>
					<td class="text"><asp:Label ID="Label1" Text="<%$ Resources:MailListAdmin,EmailSubject %>" runat="server" /></td>
					   <td class="text">
                        <asp:Label ID="lblSubject" runat="server" Text=""></asp:Label>
                    </td>
				</tr>

				<tr>
					<td class="text" colspan="2"><asp:Label ID="Label7" Text="<%$ Resources:MailListAdmin,EMailBody %>" runat="server" /></td>
					
				</tr>
				<tr>
				<td class="" colspan="2">
                        <asp:Label ID="lblbody" runat="server" Text=""></asp:Label>
						</td>
				</tr>
				
				</table>
			</td>
		</tr>
	</table>