<%@ Page language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="Save.aspx.cs" Inherits="AdminAdvPlaces_Update"  %>

 <asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

			<table class="MainTable" cellspacing="0" cellpadding="0" width="100%" border="0" >
				
				<tr>
					<td>
			<table class="SubTable" cellspacing="0" cellpadding="0" width="100%" border="0" >
				<tr>
					<td class="Result" align="center" colspan="2">
						<asp:Label id="lblResult" runat="server"></asp:Label>
					</td>
				</tr>
				<tr>
					<td class="text"><asp:Label ID="Label1" Text="<%$ Resources:Advertisments,AdvPlaces_PlaceID %>" runat="server" /><span class="RequiredField"><asp:Label ID="Label2" runat="server" Text="*" /></span></td>
					<td class="Control">
						<asp:TextBox MaxLength="3" id="txtPlaceID" runat="server" CssClass="SmallControls"  ValidationGroup="AdvPlaces"></asp:TextBox>
						<asp:RequiredFieldValidator Display="Dynamic" id="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtPlaceID" ValidationGroup="AdvPlaces" Text="*"></asp:RequiredFieldValidator>
					</td>
				</tr>
				<tr >
					<td class="text"><asp:Label Text="<%$ Resources:Advertisments,AdvPlaces_PlaceIdentifier %>" runat="server" /><span class="RequiredField"><asp:Label runat="server" Text="*" /></span></td>
					<td class="Control">
						<asp:TextBox MaxLength="32" id="txtPlaceIdentifier" runat="server" CssClass="Controls" ValidationGroup="AdvPlaces"></asp:TextBox>
						<asp:RequiredFieldValidator Display="Dynamic" id="rfvPlaceIdentifier" runat="server" ErrorMessage="*" ControlToValidate="txtPlaceIdentifier" ValidationGroup="AdvPlaces" Text="*"></asp:RequiredFieldValidator>
					</td>
				</tr>
                <tr >
					<td class="text"><asp:Label ID="Label5" Text="<%$ Resources:Advertisments,AdvPlaces_PlaceType %>" runat="server" /><span class="RequiredField"><asp:Label ID="Label6" runat="server" Text="*" /></span></td>
					<td class="Control">
                        <asp:DropDownList ID="ddlPlaceType" runat="server" CssClass="Controls" ValidationGroup="AdvPlaces" >
                        <asp:ListItem Value="1" Text="ÇáãæÞÚ ÇáÑÆíÓí" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="2" Text="ÇáãæÇÞÚ ÇáÝÑÚíÉ"></asp:ListItem>
                        </asp:DropDownList>

					</td>
				</tr>
				<tr id="trTitle" runat="server">
					<td class="text"><asp:Label Text="<%$ Resources:Advertisments,AdvPlaces_Title %>" runat="server" /><span class="RequiredField"><asp:Label runat="server" Text="*" /></span></td>
					<td class="Control">
						<asp:TextBox MaxLength="64" id="txtTitle" runat="server" CssClass="Controls" ValidationGroup="AdvPlaces"></asp:TextBox>
						<asp:RequiredFieldValidator Display="Dynamic" id="rfvTitle" runat="server" ErrorMessage="*" ControlToValidate="txtTitle" ValidationGroup="AdvPlaces" Text="*"></asp:RequiredFieldValidator>
					</td>
				</tr>
				<tr id="trWidth" runat="server">
					<td class="text"><asp:Label Text="<%$ Resources:Advertisments,AdvPlaces_Width %>" runat="server" /><span class="RequiredField"><asp:Label runat="server" Text="*" /></span></td>
					<td class="Control">
						<asp:TextBox MaxLength="9" id="txtWidth" runat="server" CssClass="SmallControls" ValidationGroup="AdvPlaces"></asp:TextBox>
						<asp:RegularExpressionValidator Display="Dynamic" ID="revWidth" runat="server" ControlToValidate="txtWidth" ErrorMessage="" ValidationGroup="AdvPlaces" ValidationExpression="\d*"></asp:RegularExpressionValidator>
						<asp:RequiredFieldValidator Display="Dynamic" id="rfvWidth" runat="server" ErrorMessage="*" ControlToValidate="txtWidth" ValidationGroup="AdvPlaces" Text="*"></asp:RequiredFieldValidator>
					</td>
				</tr>
				<tr id="trHeight" runat="server">
					<td class="text"><asp:Label Text="<%$ Resources:Advertisments,AdvPlaces_Height %>" runat="server" /><span class="RequiredField"><asp:Label runat="server" Text="*" /></span></td>
					<td class="Control">
						<asp:TextBox MaxLength="9" id="txtHeight" runat="server" CssClass="SmallControls" ValidationGroup="AdvPlaces"></asp:TextBox>
						<asp:RegularExpressionValidator Display="Dynamic" ID="revHeight" runat="server" ControlToValidate="txtHeight" ErrorMessage="" ValidationGroup="AdvPlaces" ValidationExpression="\d*"></asp:RegularExpressionValidator>
						<asp:RequiredFieldValidator Display="Dynamic" id="rfvHeight" runat="server" ErrorMessage="*" ControlToValidate="txtHeight" ValidationGroup="AdvPlaces" Text="*"></asp:RequiredFieldValidator>
					</td>
				</tr>
				<tr id="trDefaultFilePath" runat="server">
					<td class="text"><asp:Label Text="<%$ Resources:Advertisments,AdvPlaces_DefaultFilePath %>" runat="server" /></td>
					<td class="Control">
						<asp:TextBox MaxLength="128" id="txtDefaultFilePath" runat="server" CssClass="Controls" ValidationGroup="AdvPlaces"></asp:TextBox>
					</td>
				</tr>
				
				<tr id="trIsRandom" runat="server">
					<td class="text"><asp:Label Text="<%$ Resources:Advertisments,AdvPlaces_IsRandom %>" runat="server" /></td>
					<td class="Control">
						<asp:CheckBox id="cbIsRandom" CssClass="Controls" runat="server" ValidationGroup="AdvPlaces"></asp:CheckBox>
					</td>
				</tr>
				<tr id="trEnableSeparatedAd" runat="server">
					<td class="text"><asp:Label Text="<%$ Resources:Advertisments,Adv_EnableSeparatedAd %>" runat="server" /></td>
					<td class="Control">
						<asp:CheckBox id="cbEnableSeparatedAd" CssClass="Controls" runat="server" ValidationGroup="AdvPlaces"></asp:CheckBox>
					</td>
				</tr>
				<tr id="trEnableSeparatedCount" runat="server">
					<td class="text"><asp:Label ID="Label3" Text="<%$ Resources:Advertisments,AdvPlaces_EnableSeparatedCount %>" runat="server" /><span class="RequiredField"><asp:Label ID="Label4" runat="server" Text="*" /></span></td>
					<td class="Control">
						<asp:TextBox MaxLength="9" id="txtEnableSeparatedCount" runat="server" CssClass="SmallControls" ValidationGroup="AdvPlaces"></asp:TextBox>
						<asp:RegularExpressionValidator Display="Dynamic" ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEnableSeparatedCount" ErrorMessage="" ValidationGroup="AdvPlaces" ValidationExpression="\d*"></asp:RegularExpressionValidator>
						<asp:RequiredFieldValidator Display="Dynamic" id="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtEnableSeparatedCount" ValidationGroup="AdvPlaces" Text="*"></asp:RequiredFieldValidator>
					</td>
				</tr>
				<tr>
					<td class="Result" align="center" colspan="2">
                        <asp:Button ID="btnSave"  runat="server"   ValidationGroup="AdvPlaces" onclick="btnSave_Click"  SkinID="btnSave"   />
					</td>
				</tr>
				</table>
			</td>
		</tr>
	</table>
</asp:Content>

