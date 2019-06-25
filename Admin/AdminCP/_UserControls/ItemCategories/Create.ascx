<%@ Control Language="c#" AutoEventWireup="true" CodeFile="Create.ascx.cs" Inherits="ItemCategories_Create" %>

			<%@ Register src="../Date.ascx" tagname="Date" tagprefix="uc2" %>
<%@ Register src="../MultiLanguages/MLangsDetails.ascx" tagname="MLangsDetails" tagprefix="uc1" %>
<table class="MainTable" cellspacing="0" cellpadding="0" width="100%" border="0" >
				<tr>
					<td>
			<table class="SubTable" cellspacing="0" cellpadding="0" width="100%" border="0" >
			<tr>
					<td class="Result" align="center" colspan="2">
						<asp:Label id="lblCategoryAdminNote" runat="server"></asp:Label>
					</td>
				</tr>
				<tr>
					<td class="Result" align="center" colspan="2">
						<asp:Label id="lblResult" runat="server"></asp:Label>
					</td>
				</tr>
				
				<tr id="trParents" runat="server" >
					<td class="text"><asp:Label ID="lblCategoryID" runat="server" /></td>
					<td class="Control">
						<asp:DropDownList id="ddlParents" runat="server" CssClass="Controls" ></asp:DropDownList>
						<asp:RequiredFieldValidator ValidationGroup="Items"  id="rfvCategoryID"  ControlToValidate="ddlParents"  Display="Dynamic" runat="server" ErrorMessage="*" InitialValue="-1"  Text="*"></asp:RequiredFieldValidator>
					</td>
				</tr>
                
				<tr id="trPhotoExtension" runat="server" >
					<td class="text"><asp:Label ID="lblPhotoExtension" runat="server" /></td>
					<td class="Control">
						<asp:FileUpload ID="fuPhoto" runat="server" CssClass="Controls"  />
						<asp:RequiredFieldValidator ValidationGroup="Items" id="rfvPhoto" ControlToValidate="fuPhoto" Display="Dynamic"  runat="server" ErrorMessage="*"  Text="*"></asp:RequiredFieldValidator>
						<asp:CheckBox ID="cbPublishPhoto" CssClass="Controls"  runat="server" ValidationGroup="Items"></asp:CheckBox>
						 <asp:Label ID="lblPhotoAvailableExtension" runat="server" ></asp:Label>
					    <asp:RegularExpressionValidator ValidationGroup="Items" Display="Dynamic"  ID="rxpPhoto" runat="server" ControlToValidate="fuPhoto"
                            ></asp:RegularExpressionValidator>
					</td>
				</tr>
				 <tr id="trPhoto2Extension" runat="server">
                    <td class="text">
                        <asp:Label ID="lblPhoto2Extension" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:FileUpload ID="fuPhoto2" runat="server" CssClass="Controls" />
                        <asp:RequiredFieldValidator ValidationGroup="Items" ID="rfvPhoto2" ControlToValidate="fuPhoto2"
                            Display="Dynamic" runat="server" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                        <asp:CheckBox ID="cbPublishPhoto2" CssClass="Controls"  runat="server"
                            ValidationGroup="Items"></asp:CheckBox>
                        <asp:Label ID="lblPhoto2AvailableExtension" runat="server"></asp:Label>
                        <asp:RegularExpressionValidator ValidationGroup="Items" Display="Dynamic" ID="rxpPhoto2"
                            runat="server" ControlToValidate="fuPhoto2"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr id="trFileExtension" runat="server">
                    <td class="text">
                        <asp:Label ID="lblFileExtension" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:FileUpload ID="fuFile" runat="server" CssClass="Controls" />
                        <asp:RequiredFieldValidator ValidationGroup="Items" ID="rfvFile" ControlToValidate="fuFile"
                            Display="Dynamic" runat="server" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                        <asp:CheckBox ID="cbPublishFile" CssClass="Controls"  runat="server" ValidationGroup="Items">
                        </asp:CheckBox>
                        <asp:Label ID="lblFileAvailableExtension" runat="server"></asp:Label>
                        <asp:RegularExpressionValidator ValidationGroup="Items" Display="Dynamic" ID="rxpFile"
                            runat="server" ControlToValidate="fuFile"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr id="trWidth" runat="server">
                    <td class="text">
                        <asp:Label ID="lblWidth" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="3" ID="txtWidth" runat="server" CssClass="Controls"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup="Items" ID="rfvWidth" ControlToValidate="txtWidth"
                            Display="Dynamic" runat="server" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ValidationGroup="Items" Display="Dynamic" ID="rxpWidth"
                            ValidationExpression="\d*" runat="server" ControlToValidate="txtWidth" ErrorMessage="<%= Resources.AdminText.InvalidNumericalData %>"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr id="trHeight" runat="server">
                    <td class="text">
                        <asp:Label ID="lblHeight" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="3" ID="txtHeight" runat="server" CssClass="Controls"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup="Items" ID="rfvHeight" ControlToValidate="txtHeight"
                            Display="Dynamic" runat="server" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ValidationGroup="Items" Display="Dynamic" ID="rxpHeight"
                            ValidationExpression="\d*" runat="server" ControlToValidate="txtHeight" ErrorMessage="<%= Resources.AdminText.InvalidNumericalData %>"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr id="trVideoExtension" runat="server">
                    <td class="text">
                        <asp:Label ID="lblVideoExtension" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:FileUpload ID="fuVideo" runat="server" CssClass="Controls" />
                        <asp:RequiredFieldValidator ValidationGroup="Items" ID="rfvVideo" ControlToValidate="fuVideo"
                            Display="Dynamic" runat="server" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                        <asp:CheckBox ID="cbPublishVideo" CssClass="Controls"  runat="server" ValidationGroup="Items">
                        </asp:CheckBox>
                        <asp:Label ID="lblVideoAvailableExtension" runat="server"></asp:Label>
                        <asp:RegularExpressionValidator ValidationGroup="Items" Display="Dynamic" ID="rxpVideo"
                            runat="server" ControlToValidate="fuVideo"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr id="trYoutubeCode" runat="server">
                    <td class="text">
                        <asp:Label ID="lblYoutubeCode" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="256" ID="txtYoutubeCode" runat="server" CssClass="Controls"
                            ValidationGroup="Items"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup="Items" ID="rfvYoutubeCode" ControlToValidate="txtYoutubeCode"
                            Display="Dynamic" runat="server" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                        <asp:CheckBox ID="cbPublishYoutbe" CssClass="Controls"  runat="server"
                            ValidationGroup="Items"></asp:CheckBox>
                    </td>
                </tr>
                <tr id="trAudioExtension" runat="server">
                    <td class="text">
                        <asp:Label ID="lblAudioExtension" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:FileUpload ID="fuAudio" runat="server" CssClass="Controls" />
                        <asp:RequiredFieldValidator ValidationGroup="Items" ID="rfvAudio" ControlToValidate="fuAudio"
                            Display="Dynamic" runat="server" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                        <asp:CheckBox ID="cbPublishAudio" CssClass="Controls"  runat="server" ValidationGroup="Items">
                        </asp:CheckBox>
                        <asp:Label ID="lblAudioAvailableExtension" runat="server"></asp:Label>
                        <asp:RegularExpressionValidator ValidationGroup="Items" Display="Dynamic" ID="rxpAudio"
                            runat="server" ControlToValidate="fuAudio"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                
                <tr id="trItemDate" runat="server">
                    <td class="text">
                        <asp:Label ID="lblItemDate" runat="server" />
                    </td>
                    <td class="Control">
                        <uc2:Date ID="ucItemDate" runat="server" ValidationGroup="Items" />
                    </td>
                </tr>
                <tr id="trGoogleLatitude" runat="server">
                    <td class="text">
                        <asp:Label ID="lblGoogleLatitude" runat="server" />
                    </td>
                    <td class="Control" valign="middle">
                        <div style="float: right">
                            <asp:TextBox CssClass="Controls" MaxLength="64" ID="txtGoogleLatitude" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvGoogleLatitude" runat="server" ErrorMessage="*"
                                ControlToValidate="txtGoogleLatitude" ValidationGroup="Items"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ValidationGroup="Items" ControlToValidate="txtGoogleLatitude"
                                ID="RegularExpressionValidator2" ValidationExpression="[0-9]*\.?[0-9]*" Display="Dynamic"
                                runat="server" ErrorMessage="<%$ Resources:AdminText,InvalidEnteredValue %>"></asp:RegularExpressionValidator>
                        </div>
                        <div style="float: right">
                            <a id="A1" runat="server" href="/PopUps/GoogleMap.aspx" onclick="return hs.htmlExpand(this, { objectType: 'iframe', minHeight:'510' , height: '510' , width: '520' } )">
                                <img hspace="0" class='googleIcon' src="/Content/images/spacer.gif" alt="<%= Resources.AdminText.GoogleMapShow %>" /></a></div>
                    </td>
                </tr>
                <tr id="trGoogleLongitude" runat="server">
                    <td class="text">
                        <asp:Label ID="lblGoogleLongitude" runat="server" />
                    </td>
                    <td class="Control" valign="middle">
                        <div style="float: right">
                            <asp:TextBox CssClass="Controls" MaxLength="64" ID="txtGoogleLongitude" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvGoogleLongitude" runat="server" ErrorMessage="*"
                                ControlToValidate="txtGoogleLongitude" ValidationGroup="Items"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ValidationGroup="Items" ID="RegularExpressionValidator1"
                                ControlToValidate="txtGoogleLongitude" ValidationExpression="[0-9]*\.?[0-9]*"
                                Display="Dynamic" runat="server" ErrorMessage="<%$ Resources:AdminText,InvalidEnteredValue %>"></asp:RegularExpressionValidator>
                        </div>
                        <div style="float: right">
                            <a id="A2" runat="server" href="/PopUps/GoogleMap.aspx" onclick="return hs.htmlExpand(this, { objectType: 'iframe', minHeight:'510' , height: '510' , width: '520' } )">
                                <img hspace="0" class='googleIcon' src="/Content/images/spacer.gif" alt="<%= Resources.AdminText.GoogleMapShow %>" /></a></div>
                    </td>
                </tr>
                <tr id="trPriority" runat="server">
                    <td class="text">
                        <asp:Label ID="lblPriority" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:DropDownList ID="ddlPriority" runat="server" CssClass="Controls">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr id="trHasIsMain" runat="server">
                    <td class="text">
                        <asp:Label ID="lblIsMain" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:CheckBox ID="CbIsMain" CssClass="Controls" runat="server"></asp:CheckBox>
                    </td>
                </tr>
                <tr id="trIsAvailable" runat="server">
                    <td class="text">
                        <asp:Label ID="lblIsAvailable" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:CheckBox ID="cbIsAvailable" Checked="true" CssClass="Controls" runat="server">
                        </asp:CheckBox>
                    </td>
                </tr>
                <tr id="trOnlyForRegisered" runat="server">
                    <td class="text">
                        <asp:Label ID="lblOnlyForRegisered" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:CheckBox ID="cbOnlyForRegisered" Checked="false" CssClass="Controls" runat="server">
                        </asp:CheckBox>
                    </td>
                </tr>
				
				<tr>
					<td class="SubHeader" colspan="2"><%= Resources.AdminText.Details%>
					
                    </td>
				</tr>
				<tr  >
					<td class="Control" colspan="2">
					<uc1:MLangsDetails ID="MLangsDetails1" runat="server" ValidationGroup="Items" />
                    </td>
				</tr>
				<tr>
					<td class="Result" align="center" colspan="2">
					      <asp:Button ID="btnSave"  runat="server"   ValidationGroup="Items" onclick="btnSave_Click"  SkinID="btnSave"   />
					</td>
				</tr>
				</table>
			</td>
		</tr>
	</table>

