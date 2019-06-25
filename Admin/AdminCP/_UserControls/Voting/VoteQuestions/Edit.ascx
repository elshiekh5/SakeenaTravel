<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Edit.ascx.cs" Inherits="AdminCP__UserControls_Voting_VoteQuestions_Edit" %>
<table class="MainTable" cellspacing="0" cellpadding="0" width="100%" border="0" >


				<tr>
					<td>
			<table class="SubTable" cellspacing="0" cellpadding="0" width="100%" border="0" >
				<tr>
					<td class="Result" align="center" colspan="2">
						<asp:Label id="lblResult" runat="server"></asp:Label>
					</td>
				</tr>
				<tr id="trLanguages" runat="server">
					<td class="text"><%= Resources.AdminText.Language %><span class="RequiredField"><asp:Label runat="server" Text="*" /></span></td>
					<td class="control">
						<asp:DropDownList ID="ddlLanguages" runat="server" CssClass="Controls"  />
						<asp:RequiredFieldValidator Display="Dynamic" id="rfvLanguages" InitialValue="-1" runat="server" ErrorMessage="*" ControlToValidate="ddlLanguages" ValidationGroup="Vote" Text="*"></asp:RequiredFieldValidator>

					</td>
				</tr>
				<tr>
					<td class="text"><asp:Label ID="Label1" Text="<%$ Resources:Vote,QuestionText %>" runat="server" /><span class="RequiredField"><asp:Label ID="Label2" runat="server" Text="*" /></span></td>
					<td class="Control">
						<asp:TextBox MaxLength="128" id="txtQuestionText" runat="server" CssClass="Controls" ValidationGroup="Vote"></asp:TextBox>
						<asp:RequiredFieldValidator Display="Dynamic" id="rfvQuestionText" runat="server" ErrorMessage="*" ControlToValidate="txtQuestionText" ValidationGroup="Vote" Text="*"></asp:RequiredFieldValidator>
					</td>
				</tr>
				<tr>
					<td class="text"><asp:Label Text="<%$ Resources:Vote,AnswersCount %>" runat="server" /><span class="RequiredField"><asp:Label ID="Label4" runat="server" Text="*" /></span></td>
					<td class="Control">
                            <asp:DropDownList ID="ddlAnswersCount" AutoPostBack="true" 
                                CssClass="SmallControls" ValidationGroup="Vote" runat="server" 
                                onselectedindexchanged="ddlAnswersCount_SelectedIndexChanged"></asp:DropDownList>
						    <asp:RequiredFieldValidator Display="Dynamic" id="rfvAnswersCount" runat="server" ErrorMessage="*" ControlToValidate="ddlAnswersCount" InitialValue="-1" ValidationGroup="Vote" Text="*"></asp:RequiredFieldValidator>
					</td>
				</tr>
				<tr>
					<td class="text"><asp:Label ID="Label5" Text="<%$ Resources:Vote,IsMain %>" runat="server" /><span class="RequiredField"><asp:Label ID="Label6" runat="server" Text="*" /></span></td>
					<td class="Control">
						<asp:CheckBox id="cbIsMain" CssClass="Controls" runat="server" ValidationGroup="Vote"></asp:CheckBox>
					</td>
				</tr>
				<tr>
					<td class="text"><asp:Label ID="Label7" Text="<%$ Resources:Vote,IsClosed %>" runat="server" /><span class="RequiredField"><asp:Label ID="Label8" runat="server" Text="*" /></span></td>
					<td class="Control">
						<asp:CheckBox id="cbIsClosed" CssClass="Controls" runat="server" ValidationGroup="Vote"></asp:CheckBox>
					</td>
				</tr>
				<asp:PlaceHolder ID="phAnswers" runat="server"></asp:PlaceHolder>
				<tr>
					<td class="Result" align="center" colspan="2">
                        <asp:Button ID="btnSave"  runat="server"   ValidationGroup="Vote" onclick="btnSave_Click"  SkinID="btnSave"   />
					</td>
				</tr>
				</table>
			</td>
		</tr>
	</table>