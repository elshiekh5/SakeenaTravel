<%@ Control Language="c#" AutoEventWireup="true" CodeFile="Update.ascx.cs" Inherits="ItemCategories_Update" %>

<%@ Register src="../MultiLanguages/MLangsDetails.ascx" tagname="MLangsDetails" tagprefix="uc1" %>
<%@ Register Src="../Date.ascx" TagName="Date" TagPrefix="uc2" %>

			<table class="MainTable" cellspacing="0" cellpadding="0" width="100%" border="0">
    <tr>
        <td>
            <table class="SubTable" cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr>
                    <td class="Result" align="center" colspan="2">
                        <asp:Label ID="lblAdminNote" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="Result" align="center" colspan="2">
                        <asp:Label ID="lblResult" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="trParents" runat="server" >
					<td class="text"><asp:Label ID="lblParents" Text="<%$ Resources:Items,CategoryID %>" runat="server" /></td>
					<td class="Control">
						<asp:DropDownList id="ddlParents" runat="server" CssClass="Controls" ></asp:DropDownList>
						<asp:RequiredFieldValidator ValidationGroup="Items"  id="rfvCategoryID"  ControlToValidate="ddlParents"  Display="Dynamic" runat="server" ErrorMessage="*" InitialValue="-1"  Text="*"></asp:RequiredFieldValidator>
					</td>
				</tr>
                <tr id="trPhotoExtension" runat="server">
                    <td class="text">
                        <asp:Label ID="lblPhotoExtension" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:FileUpload ID="fuPhoto" runat="server" CssClass="Controls" />
                        <asp:CheckBox ID="cbPublishPhoto" CssClass="Controls"  runat="server" ValidationGroup="Items">
                        </asp:CheckBox>
                        <asp:Label ID="lblPhotoAvailableExtension" runat="server"></asp:Label>
                        <asp:RegularExpressionValidator ValidationGroup="Items" ID="rxpPhoto" ControlToValidate="fuPhoto"
                            runat="server" Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr runat="server" id="trPhotoPreview">
                    <td class="text">
                    </td>
                    <td class="control">
                        <table id="PhotoContainer" runat="server" class="PhotoContainer" cellspacing="0"
                            cellpadding="0" border="0">
                            <tr id="trImgPhoto" runat="server">
                                <td class="Image" align="center">
                                    <a runat="server" id="ancor" href='' class="highslide" onclick="return hs.expand(this)">
                                        <asp:Image runat="server" ID="imgPhoto" ToolTip="<%$ Resources:AdminText,ClickToEnlage %>" />
                                    </a>
                                </td>
                            </tr>
                            <tr id="trDeletePhoto" runat="server">
                                <td class="Imagetext">
                                    <asp:Button ID="btnDeletePhoto" runat="server" ValidationGroup="DeletePhoto" OnClick="btnDeletePhoto_Click"
                                        CssClass="btnDeletePhoto" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="trPhoto2Extension" runat="server">
                    <td class="text">
                        <asp:Label ID="lblPhoto2Extension" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:FileUpload ID="fuPhoto2" runat="server" CssClass="Controls" />
                        <asp:CheckBox ID="cbPublishPhoto2" CssClass="Controls"  runat="server"
                            ValidationGroup="Items"></asp:CheckBox>
                        <asp:Label ID="lblPhoto2AvailableExtension" runat="server"></asp:Label>
                        <asp:RegularExpressionValidator ValidationGroup="Items" ID="rxpPhoto2" ControlToValidate="fuPhoto2"
                            Display="Dynamic" runat="server"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr id="trPhoto2Preview" runat="server">
                    <td class="text">
                    </td>
                    <td class="control">
                        <table id="Photo2Container" runat="server" class="PhotoContainer" cellspacing="0"
                            cellpadding="0" border="0">
                            <tr id="trImgPhoto2" runat="server">
                                <td class="Image" align="center">
                                    <a runat="server" id="aImgPhoto2Viewer" href='' class="highslide" onclick="return hs.expand(this)">
                                        <asp:Image runat="server" ID="imgPhoto2" ToolTip="<%$ Resources:AdminText,ClickToEnlage %>" Style="width: 100px;
                                            height: 100px;" />
                                    </a>
                                </td>
                            </tr>
                            <tr id="tr4" runat="server">
                                <td class="Imagetext">
                                    <asp:Button ID="btnDeletePhoto2" runat="server" ValidationGroup="DeletePhoto2" OnClick="btnDeletePhoto2_Click"
                                        CssClass="btnDeletePhoto" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="trFileExtension" runat="server">
                    <td class="text">
                        <asp:Label ID="lblFileExtension" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:FileUpload ID="fuFile" runat="server" CssClass="Controls" />
                        <asp:CheckBox ID="cbPublishFile" CssClass="Controls"  runat="server" ValidationGroup="Items">
                        </asp:CheckBox>
                        <asp:Label ID="lblFileAvailableExtension" runat="server"></asp:Label>
                        <asp:RegularExpressionValidator ValidationGroup="Items" ID="rxpFile" ControlToValidate="fuFile"
                            Display="Dynamic" runat="server"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr id="trFilePreview" runat="server">
                    <td class="text">
                    </td>
                    <td class="Control">
                        <a id="hlFile" target="_blank" runat="server">
                            <img src='/Content/AdminDesign/Ar/css/images/buttons/download.gif' border="0" /></a>
                        <asp:ImageButton ID="ibtnDeleteFile" runat="server" ValidationGroup="DeleteFile"
                            OnClick="ibtnDeleteFile_Click" ImageUrl="/Content/AdminDesign/Ar/css/images/buttons/delete.gif" />
                        <br />
                        <%=Banner %>
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
                        <asp:CheckBox ID="cbPublishVideo" CssClass="Controls"  runat="server" ValidationGroup="Items">
                        </asp:CheckBox>
                        <asp:Label ID="lblVideoAvailableExtension" runat="server"></asp:Label>
                        <asp:RegularExpressionValidator ValidationGroup="Items" ID="rxpVideo" ControlToValidate="fuVideo"
                            Display="Dynamic" runat="server"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr id="trVideoPreview" runat="server">
                    <td class="text">
                    </td>
                    <td class="Control">
                        <a id="hlVideo" target="_blank" runat="server">
                            <img src='/Content/AdminDesign/Ar/css/images/buttons/download.gif' border="0" /></a>
                        <asp:ImageButton ID="ibtnDeleteVideo" runat="server" ValidationGroup="DeleteVideo"
                            OnClick="ibtnDeleteVideo_Click" ImageUrl="/Content/AdminDesign/Ar/css/images/buttons/delete.gif" />
                    </td>
                </tr>
                <tr id="trYoutubeCode" runat="server">
                    <td class="text">
                        <asp:Label ID="lblYoutubeCode" runat="server" />
                    </td>
                    <td class="Control">
                        <table>
                            <tr>
                                <td>
                                    <asp:TextBox MaxLength="256" ID="txtYoutubeCode" runat="server" CssClass="Controls"></asp:TextBox>
                                    <asp:RequiredFieldValidator ValidationGroup="Items" ID="rfvYoutubeCode" ControlToValidate="txtYoutubeCode"
                                        Display="Dynamic" runat="server" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                                    <asp:CheckBox ID="cbPublishYoutbe" CssClass="Controls"  runat="server"
                                        ValidationGroup="Items"></asp:CheckBox>
                                </td>
                                <td>
                                    <a runat="server" id="aYoutube" onclick="return hs.htmlExpand(this, { objectType: 'iframe', minHeight:'457' , height: '457' , width: '577' } )">
                                        <img hspace="0" class="youtubeviewer" src="/Content/images/spacer.gif"
                                            border="0" alt="" /></a>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="trAudioExtension" runat="server">
                    <td class="text">
                        <asp:Label ID="lblAudioExtension" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:FileUpload ID="fuAudio" runat="server" CssClass="Controls" />
                        <asp:CheckBox ID="cbPublishAudio" CssClass="Controls"  runat="server" ValidationGroup="Items">
                        </asp:CheckBox>
                        <asp:Label ID="lblAudioAvailableExtension" runat="server"></asp:Label>
                        <asp:RegularExpressionValidator ValidationGroup="Items" ID="rxpAudio" ControlToValidate="fuAudio"
                            Display="Dynamic" runat="server"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr id="trAudioPreview" runat="server">
                    <td class="text">
                    </td>
                    <td class="Control">
                        <a id="hlAudio" target="_blank" runat="server">
                            <img src='/Content/AdminDesign/Ar/css/images/buttons/download.gif' border="0" /></a>
                        <asp:ImageButton ID="ibtnDeleteAudio" runat="server" ValidationGroup="DeleteAudio"
                            OnClick="ibtnDeleteAudio_Click" ImageUrl="/Content/AdminDesign/Ar/css/images/buttons/delete.gif" />
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
                            <a id="aGoogleLatitudeViewer" runat="server" href="/PopUps/GoogleMap.aspx" onclick="return hs.htmlExpand(this, { objectType: 'iframe', minHeight:'510' , height: '510' , width: '520' } )">
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
                            <a id="aGoogleLongitudeViewer" runat="server" href="/PopUps/GoogleMap.aspx" onclick="return hs.htmlExpand(this, { objectType: 'iframe', minHeight:'510' , height: '510' , width: '520' } )">
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
                        <asp:CheckBox ID="CbIsMain"  CssClass="Controls" runat="server"></asp:CheckBox>
                    </td>
                </tr>
                <tr id="trIsAvailable" runat="server">
                    <td class="text">
                        <asp:Label ID="lblIsAvailable" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:CheckBox ID="cbIsAvailable" CssClass="Controls" runat="server"></asp:CheckBox>
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
                    <td class="SubHeader" colspan="2">
                        <%= Resources.AdminText.Details%>
                    </td>
                </tr>
                <tr>
                    <td class="Control" colspan="2">
                        <uc1:MLangsDetails ID="MLangsDetails1" runat="server" ValidationGroup="Items" />
                    </td>
                </tr>
                <tr>
                    <td class="Result" align="center" colspan="2">
                        <asp:Button ID="btnSave" runat="server" ValidationGroup="Items" OnClick="btnSave_Click"
                            SkinID="btnSave" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>



