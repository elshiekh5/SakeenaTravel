<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Save.ascx.cs" Inherits="AdminCP__UserControls_Advertisments_Save" %>
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
					<td class="text"><%= Resources.AdminText.Language %><span class="RequiredField"><asp:Label ID="Label3" runat="server" Text="*" /></span></td>
					<td class="control">
						<asp:DropDownList ID="ddlLanguages" runat="server" CssClass="Controls"  />
						<asp:RequiredFieldValidator Display="Dynamic" id="rfvLanguages" InitialValue="-1" runat="server" ErrorMessage="*" ControlToValidate="ddlLanguages" ValidationGroup="Advertisments" Text="*"></asp:RequiredFieldValidator>

					</td>
				</tr>
				<tr>
					<td class="text"><asp:Label ID="Label1" Text="<%$ Resources:Advertisments,PlaceID %>" runat="server" /><span class="RequiredField"><asp:Label ID="Label2" runat="server" Text="*" /></span></td>
					<td class="Control">
						<asp:DropDownList id="ddlAdvPlaces" runat="server" CssClass="Controls" ValidationGroup="Advertisments"></asp:DropDownList>
						<asp:RequiredFieldValidator Display="Dynamic" id="rfvPlaceID" runat="server" ErrorMessage="*" ControlToValidate="ddlAdvPlaces" InitialValue="-1" ValidationGroup="Advertisments" Text="*"></asp:RequiredFieldValidator>
					</td>
				</tr>
				<tr>
					<td class="text"><asp:Label  Text="<%$ Resources:Advertisments,Url %>" runat="server" /><span class="RequiredField"><asp:Label ID="Label4" runat="server" Text="*" /></span></td>
					<td class="Control">
						<asp:TextBox MaxLength="256" id="txtUrl" runat="server"  CssClass="Controls" ValidationGroup="Advertisments"  maxlengthS="256" onkeyup="return ismaxlength(this,document.forms[0].txtUrlLengthControler)"  onfocus="return ismaxlength(this,document.forms[0].txtUrlLengthControler)"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td class="text"><asp:Label ID="Label5" Text="<%$ Resources:Advertisments,FileExtension %>" runat="server" /><span class="RequiredField"><asp:Label ID="Label6" runat="server" Text="*" /></span></td>
					<td class="Control">
						<asp:FileUpload ID="fuFile" runat="server" CssClass="Controls"  />
						<asp:HyperLink ID="hlFile" runat="server"   />
                        <%= Resources.AdminText.NotSuportedFileExtention + Resources.Advertisments.AdFileAvailableExtension%>
					</td>
				</tr>
				<tr id="trAdvertisePreview" runat="server">
					<td class="text"></td>
					<td class="Control">
                        <asp:Literal ID="ltrAdvertiseFile" runat="server"></asp:Literal>
					</td>
				</tr>
                <% if (false)
                   { %>
				
				<tr id="trWeight" runat="server">
					<td class="text"><asp:Label ID="Label7" Text="<%$ Resources:Advertisments,Weight %>" runat="server" /></td>
					<td class="Control">
						<asp:DropDownList id="ddlWeight" runat="server" CssClass="Controls" ValidationGroup="Advertisments">
						<asp:ListItem Text="1" Value="1"></asp:ListItem>
						<asp:ListItem Text="2" Value="2"></asp:ListItem>
						<asp:ListItem Text="3" Value="3"></asp:ListItem>
						<asp:ListItem Text="4" Value="4"></asp:ListItem>
						<asp:ListItem Text="5"  Value="5"></asp:ListItem>
						<asp:ListItem Text="6" Value="6"></asp:ListItem>
						<asp:ListItem Text="7" Value="7"></asp:ListItem>
						<asp:ListItem Text="8" Value="8"></asp:ListItem>
						<asp:ListItem Text="9" Value="9"></asp:ListItem>
						<asp:ListItem Text="10" Value="10"></asp:ListItem>
						</asp:DropDownList>
					</td>
				</tr>
				<tr id="trMaxApperance" runat="server">
					<td class="text"><asp:Label ID="Label8" Text="<%$ Resources:Advertisments,MaxApperance %>" runat="server" /></td>
					<td class="Control">
						<asp:TextBox MaxLength="9" id="txtMaxApperance" runat="server" CssClass="Controls" ValidationGroup="Advertisments"></asp:TextBox>
						<asp:RegularExpressionValidator Display="Dynamic" ID="revMaxApperance" runat="server" ControlToValidate="txtMaxApperance" ErrorMessage="" ValidationGroup="Advertisments" ValidationExpression="\d*"></asp:RegularExpressionValidator>
					</td>
				</tr>
				<tr id="trMaxClicks" runat="server">
					<td class="text"><asp:Label ID="Label9" Text="<%$ Resources:Advertisments,MaxClicks %>" runat="server" /></td>
					<td class="Control">
						<asp:TextBox MaxLength="9" id="txtMaxClicks" runat="server" CssClass="Controls" ValidationGroup="Advertisments"></asp:TextBox>
						<asp:RegularExpressionValidator Display="Dynamic" ID="revMaxClicks" runat="server" ControlToValidate="txtMaxClicks" ErrorMessage="" ValidationGroup="Advertisments" ValidationExpression="\d*"></asp:RegularExpressionValidator>
					</td>
				</tr>
                <%} %>
				<tr id="trTitle" runat="server">
					<td class="text"><asp:Label ID="Label10" Text="<%$ Resources:Advertisments,Title %>" runat="server" /></td>
					<td class="Control">
						<asp:TextBox MaxLength="256" id="txtTitle" runat="server"  CssClass="Controls" ValidationGroup="Advertisments"  maxlengthS="256" onkeyup="return ismaxlength(this,document.forms[0].txtTitleLengthControler)"  onfocus="return ismaxlength(this,document.forms[0].txtTitleLengthControler)"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td class="text"><asp:Label ID="Label11" Text="<%$ Resources:Advertisments,IsActive %>" runat="server" /><span class="RequiredField"><asp:Label ID="Label12" runat="server" Text="*" /></span></td>
					<td class="Control">
						<asp:CheckBox id="cbIsActive" CssClass="Controls" runat="server" ValidationGroup="Advertisments"></asp:CheckBox>
					</td>
				</tr>
				<tr id="trIsSmallAd" runat="server">
					<td class="text"><asp:Label ID="Label13" Text="<%$ Resources:Advertisments,IsSmall %>" runat="server" /></td>
					<td class="Control">
						<asp:CheckBox id="cbIsSmall" CssClass="Controls" runat="server" ValidationGroup="Advertisments"></asp:CheckBox>
					</td>
				</tr>				
				<tr>
					<td class="Result" align="center" colspan="2">
                        <asp:Button ID="btnSave"  runat="server"   ValidationGroup="Advertisments" onclick="btnSave_Click"  SkinID="btnSave"   />
					</td>
				</tr>
				</table>
			</td>
		</tr>
	</table>