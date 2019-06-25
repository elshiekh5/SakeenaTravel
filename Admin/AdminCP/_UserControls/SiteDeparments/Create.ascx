<%@ Control Language="c#" AutoEventWireup="true" CodeFile="Create.ascx.cs" Inherits="SiteDeparments_Create" %>

			<%@ Register src="../MultiLanguages/MLangsDetails.ascx" tagname="MLangsDetails" tagprefix="uc1" %>
<table class="MainTable" cellspacing="0" cellpadding="0" width="100%" border="0" >
				<tr>
					<td>
			<table class="SubTable" cellspacing="0" cellpadding="0" width="100%" border="0" >
				<tr>
					<td class="Result" align="center" colspan="2">
						<asp:Label id="lblResult" runat="server"></asp:Label>
					</td>
				</tr>
				
				<tr id="trParents" runat="server" >
					<td class="text"><asp:Label ID="lblParents" Text="<%$ Resources:SiteDepartments,DepartmentID %>" runat="server" /></td>
					<td class="Control">
						<asp:DropDownList id="ddlParents" runat="server" CssClass="Controls" ></asp:DropDownList>
						<asp:RequiredFieldValidator ValidationGroup="SiteDeparments"  id="rfvDepartmentID"  ControlToValidate="ddlParents"  Display="Dynamic" runat="server" ErrorMessage="*" InitialValue="-1"  Text="*"></asp:RequiredFieldValidator>
					</td>
				</tr>
                
				<tr id="trPhotoExtension" runat="server" >
					<td class="text"><asp:Label ID="lblPhotoExtension" Text="<%$ Resources:SiteDepartments,PhotoExtension %>" runat="server" /></td>
					<td class="Control">
						<asp:FileUpload ID="fuPhoto" runat="server" CssClass="Controls"  />
						<asp:RequiredFieldValidator ValidationGroup="SiteDeparments" id="rfvPhoto" ControlToValidate="fuPhoto" Display="Dynamic"  runat="server" ErrorMessage="*"  Text="*"></asp:RequiredFieldValidator>

						 <asp:Label ID="lblPhotoAvailableExtension" runat="server" ></asp:Label>
					    <asp:RegularExpressionValidator ValidationGroup="SiteDeparments" Display="Dynamic"  ID="rxpPhoto" runat="server" ControlToValidate="fuPhoto"
                            ></asp:RegularExpressionValidator>
					</td>
				</tr>
				<tr id="trUrl" runat="server" >
					<td class="text"><asp:Label ID="lblUrl" Text="<%$ Resources:SiteDepartments,Url %>" runat="server" /></td>
					<td class="Control">
						<asp:TextBox MaxLength="128" id="txtUrl" runat="server" CssClass="Controls" ></asp:TextBox>
						<asp:RequiredFieldValidator ValidationGroup="SiteDeparments" id="rfvUrl" ControlToValidate="txtUrl" Display="Dynamic" runat="server" ErrorMessage="*"   Text="*"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator Visible="false" ValidationGroup="SiteDeparments" ID="revUrl" ControlToValidate="txtUrl" Display="Dynamic"    runat="server" Text="<%$ Resources:AdminText,InvalidUrl %>" ></asp:RegularExpressionValidator>
                        </td>
				</tr>
				<tr id="trRelatedModuleTypeID" runat="server" >
					<td class="text"><asp:Label ID="lblRelatedModuleTypeID" Text="<%$ Resources:SiteDepartments,RelatedModuleTypeID %>" runat="server" /></td>
					<td class="Control">
						<asp:DropDownList id="ddlRelatedModuleTypeID" runat="server" 
                            CssClass="Controls" AutoPostBack="True" 
                            onselectedindexchanged="ddlRelatedModuleTypeID_SelectedIndexChanged" ></asp:DropDownList>
					</td>
				</tr>
				<tr id="trRelatedPageID" runat="server" >
					<td class="text"><asp:Label ID="lblRelatedPageID" Text="<%$ Resources:SiteDepartments,RelatedPageID %>" runat="server" /></td>
					<td class="Control">
						<asp:DropDownList id="ddlRelatedPageID" runat="server" CssClass="Controls" ></asp:DropDownList>
					</td>
				</tr>
				<tr id="trIsAvailable" runat="server" >
					<td class="text"><asp:Label Text="<%$ Resources:SiteDepartments,IsAvailable %>" runat="server" /><span class="RequiredField"><asp:Label runat="server" Text="*" /></span></td>
					<td class="Control">
						<asp:CheckBox id="cbIsAvailable" Checked="true" CssClass="Controls" runat="server" ValidationGroup="SiteDeparments"></asp:CheckBox>
					</td>
				</tr>
				<tr>
					<td class="SubHeader" colspan="2"><asp:Label Text="<%$ Resources:AdminText,Details %>" runat="server" /></td>
				</tr>
				<tr  >
					<td class="Control" colspan="2">
                        <uc1:MLangsDetails ID="MLangsDetails1" runat="server"  ValidationGroup="SiteDeparments" />
                    </td>
				</tr>
				<tr>
					<td class="Result" align="center" colspan="2">
					      <asp:Button ID="btnSave"  runat="server"   ValidationGroup="SiteDeparments" onclick="btnSave_Click"  SkinID="btnSave"   />
					</td>
				</tr>
				</table>
			</td>
		</tr>
	</table>


