<%@ Control Language="c#" AutoEventWireup="true" CodeFile="Update.ascx.cs" Inherits="Messages_Update" %>
<%@ Register Src="../Date.ascx" TagName="Date" TagPrefix="uc1" %>
<%@ Register Src="../HijriDate.ascx" TagName="HijriDate" TagPrefix="uc2" %>
<%@ Register TagPrefix="CE" Namespace="CuteEditor" Assembly="CuteEditor" %>
<table class="MainTable" cellspacing="0" cellpadding="0" width="100%" border="0">
    <tr>
        <td>
            <table class="SubTable" runat="server" id="tblControls" cellspacing="0" cellpadding="0"
                width="100%" border="0">
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
                <tr id="trCategoryID" runat="server">
                    <td class="text">
                        <asp:Label ID="lblCategoryID" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:DropDownList ID="ddlCategoryID" runat="server" CssClass="Controls" ValidationGroup="Messages" />
                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" runat="server"
                            ErrorMessage="*" ControlToValidate="ddlCategoryID" ValidationGroup="Messages"
                            Text="*" InitialValue="-1"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trSendingDate" runat="server">
                    <td class="text">
                        <asp:Label ID="lblSendingDate" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:Label ID="lblDate" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr id="trName" runat="server">
                    <td class="text">
                        <asp:Label ID="lblName" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="128" ID="txtName" runat="server" CssClass="Controls" ValidationGroup="Messages"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvName"
                            runat="server" ErrorMessage="*" ControlToValidate="txtName" ValidationGroup="Messages"
                            Text="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trNameSeparated" runat="server">
                    <td class="text">
                        <asp:Label ID="lblNameSeparated" runat="server" />
                    </td>
                    <td class="Control">
                        <table width="358" cellspacing="0" cellpadding="0" border="0">
                            <tr>
                                <td class="Control_small">
                                    <asp:TextBox MaxLength="128" ID="txtLName" Text="Last" runat="server" CssClass="Controls"
                                        Width="100px" ValidationGroup="Messages"></asp:TextBox>
                                    <asp:RequiredFieldValidator CssClass="Xourvalidation" InitialValue="Last" Display="Dynamic"
                                        ID="rfvLName" runat="server" ErrorMessage="Name is required" ControlToValidate="txtLName"
                                        ValidationGroup="Messages" Text="*"></asp:RequiredFieldValidator>
                                </td>
                                <td class="Control_small">
                                    <asp:TextBox MaxLength="128" ID="txtMname" Text="Middle" runat="server" CssClass="Controls"
                                        Width="100px" ValidationGroup="Messages"></asp:TextBox>
                                    <asp:RequiredFieldValidator CssClass="Xourvalidation" InitialValue="Middle" Display="Dynamic"
                                        ID="rfvMName" runat="server" ErrorMessage="Name is required" ControlToValidate="txtMname"
                                        ValidationGroup="Messages" Text="*"></asp:RequiredFieldValidator>
                                </td>
                                <td class="Control_small">
                                    <asp:TextBox MaxLength="128" ID="txtFName" Text="First" runat="server" CssClass="Controls"
                                        Width="100px" ValidationGroup="Messages"></asp:TextBox>
                                    <asp:RequiredFieldValidator CssClass="Xourvalidation" InitialValue="First" Display="Dynamic"
                                        ID="rfvFName" runat="server" ErrorMessage="Name is required" ControlToValidate="txtFName"
                                        ValidationGroup="Messages" Text="*"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="trJobID" runat="server">
                    <td class="text">
                        <asp:Label ID="lblJobID" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="128" ID="txtJobID" runat="server" CssClass="Controls" ValidationGroup="Messages"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvJobID"
                            runat="server" ErrorMessage="*" ControlToValidate="txtJobID" ValidationGroup="Messages"
                            Text="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trJobText" runat="server">
                    <td class="text">
                        <asp:Label ID="lblJobText" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="128" ID="txtJobText" runat="server" CssClass="Controls" ValidationGroup="Messages"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvJobText"
                            runat="server" ErrorMessage="*" ControlToValidate="txtJobText" ValidationGroup="Messages"
                            Text="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trCompany" runat="server">
                    <td class="text">
                        <asp:Label ID="lblCompany" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="128" ID="txtCompany" runat="server" CssClass="Controls" ValidationGroup="Messages"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvCompany"
                            runat="server" ErrorMessage="*" ControlToValidate="txtCompany" ValidationGroup="Messages"
                            Text="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trActivitiesID" runat="server">
                    <td class="text">
                        <asp:Label ID="lblActivitiesID" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:DropDownList ID="ddlActivitiesID" runat="server" CssClass="Controls" ValidationGroup="Messages">
                            <asp:ListItem Selected="True" Value="-1" Text="<%$ Resources:User,Choose %>"></asp:ListItem>
                            <asp:ListItem Value="1" Text="<%$ Resources:Messages,ActivitiesID_1 %>"></asp:ListItem>
                            <asp:ListItem Value="2" Text="<%$ Resources:Messages,ActivitiesID_2 %>"></asp:ListItem>
                            <asp:ListItem Value="3" Text="<%$ Resources:Messages,ActivitiesID_3 %>"></asp:ListItem>
                            <asp:ListItem Value="4" Text="<%$ Resources:Messages,ActivitiesID_4 %>"></asp:ListItem>
                            <asp:ListItem Value="5" Text="<%$ Resources:Messages,ActivitiesID_5 %>"></asp:ListItem>
                            <asp:ListItem Value="6" Text="<%$ Resources:Messages,ActivitiesID_6 %>"></asp:ListItem>
                            <asp:ListItem Value="7" Text="<%$ Resources:Messages,ActivitiesID_7 %>"></asp:ListItem>
                            <asp:ListItem Value="8" Text="<%$ Resources:Messages,ActivitiesID_8 %>"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvActivitiesID"
                            runat="server" ErrorMessage="*" ControlToValidate="ddlActivitiesID" InitialValue="-1"
                            ValidationGroup="Messages" Text="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trNationalityID" runat="server">
                    <td class="text">
                        <asp:Label ID="lblNationalityID" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:DropDownList ID="ddlNationalityID" runat="server" CssClass="Controls" ValidationGroup="Messages" />
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvNationalityID"
                            runat="server" ErrorMessage="<%$ Resources:User,RequiredField %>" ControlToValidate="ddlNationalityID"
                            ValidationGroup="Messages" Text="<%$ Resources:User,RequiredField %>" InitialValue="-1"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trCountryID" runat="server">
                    <td class="text">
                        <asp:Label ID="lblCountryID" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:DropDownList ID="ddlCountries" runat="server" CssClass="Controls" ValidationGroup="Messages" />
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvCountryID"
                            runat="server" ErrorMessage="*" ControlToValidate="ddlCountries" ValidationGroup="Messages"
                            Text="*" InitialValue="-1"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trEmpNo" runat="server">
                    <td class="text">
                        <asp:Label ID="lblEmpNo" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="8" ID="txtEmpNo" runat="server" CssClass="Controls" ValidationGroup="Messages"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvEmpNo"
                            runat="server" ErrorMessage="*" ControlToValidate="txtEmpNo" ValidationGroup="Messages"
                            Text="*"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator CssClass="ourvalidation" Display="Dynamic" ID="revDaysCount"
                            runat="server" ControlToValidate="txtEmpNo" ErrorMessage="<%$ Resources:Messages,EmpNoError %>"
                            ValidationGroup="Messages" ValidationExpression="\d*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr id="trCityID" runat="server" visible="false">
                    <td class="text">
                        <asp:Label ID="lblCityID" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:DropDownList ID="ddlCities" runat="server" CssClass="Controls" ValidationGroup="Messages">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Visible="false" Display="Dynamic"
                            ID="rfvCityID" runat="server" ErrorMessage="*" ControlToValidate="ddlCities"
                            InitialValue="-1" ValidationGroup="Messages" Text="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trUserCityName" runat="server">
                    <td class="text">
                        <asp:Label ID="lblUserCityName" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="32" ID="txtUserCityName" runat="server" CssClass="Controls"
                            ValidationGroup="Messages"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Visible="false" Display="Dynamic"
                            ID="rfvUserCityName" runat="server" ErrorMessage="*" ControlToValidate="txtUserCityName"
                            ValidationGroup="Messages" Text="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trEMail" runat="server">
                    <td class="text">
                        <asp:Label ID="lblEmail" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="128" ID="txtEMail" runat="server" CssClass="Controls" ValidationGroup="Messages"></asp:TextBox>
                        <asp:RegularExpressionValidator CssClass="ourvalidation" Display="Dynamic" ID="revEMail"
                            runat="server" ControlToValidate="txtEMail" ErrorMessage="" Text="<%$ Resources:MemberShip,InvalidEmail %>"
                            ValidationGroup="Messages" ValidationExpression="^([\w\-\.]+)@((\[([0-9]{1,3}\.){3}[0-9]{1,3}\])|(([\w\-]+\.)+)([a-zA-Z]{2,4}))$"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvEMail"
                            runat="server" ErrorMessage="*" ControlToValidate="txtEMail" ValidationGroup="Messages"
                            Text="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trPhotoExtension" runat="server">
                    <td class="text">
                        <asp:Label ID="lblPhotoExtension" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:FileUpload ID="fuPhoto" runat="server" CssClass="Controls" />
                        <asp:RequiredFieldValidator CssClass="ourvalidation" ValidationGroup="Messages" ID="rfvPhoto"
                            ControlToValidate="fuPhoto" Display="Dynamic" runat="server" ErrorMessage="*"
                            Text="*"></asp:RequiredFieldValidator>
                        <asp:CheckBox ID="cbPublishPhoto" CssClass="Controls"  runat="server" ValidationGroup="Messages">
                        </asp:CheckBox>
                        <asp:Label ID="lblPhotoAvailableExtension" runat="server"></asp:Label>
                        <asp:RegularExpressionValidator CssClass="ourvalidation" ValidationGroup="Messages"
                            ID="rxpPhoto" Display="Dynamic" runat="server" ControlToValidate="fuPhoto"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr runat="server" id="trPhotoPreview">
                    <td class="text">
                    </td>
                    <td class="Control">
                        <table id="PhotoContainer" runat="server" class="PhotoContainer" cellspacing="0"
                            cellpadding="0" border="0">
                            <tr id="trImgPhoto" runat="server">
                                <td class="Image" align="center">
                                    <a runat="server" id="ancor" href='' class="highslide" onclick="return hs.expand(this)">
                                        <asp:Image runat="server" ID="imgPhoto" ToolTip="<%$ Resources:User,ClickToEnlarge %>" />
                                    </a>
                                </td>
                            </tr>
                            <tr id="trDeletePhoto" runat="server">
                                <td class="Imagetext" align="center">
                                    <asp:ImageButton ID="ibtnDeletePhoto" ValidationGroup="DeletePhoto" runat="server"
                                        OnClick="ibtnDeletePhoto_Click" CssClass="ibtnUpdate" ImageUrl="/Content/images/spacer.gif" />
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
                            ValidationGroup="Messages"></asp:CheckBox>
                        <asp:Label ID="lblPhoto2AvailableExtension" runat="server"></asp:Label>
                        <asp:RegularExpressionValidator ValidationGroup="Messages" ID="rxpPhoto2" ControlToValidate="fuPhoto2"
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
                                    <a runat="server" id="a1" href='' class="highslide" onclick="return hs.expand(this)">
                                        <asp:Image runat="server" ID="imgPhoto2" ToolTip="<%$ Resources:AdminText,ClickToEnlage %>" />
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
                        <asp:CheckBox ID="cbPublishFile" CssClass="Controls"  runat="server" ValidationGroup="Messages">
                        </asp:CheckBox>
                        <asp:Label ID="lblFileAvailableExtension" runat="server"></asp:Label>
                        <asp:RegularExpressionValidator ValidationGroup="Messages" ID="rxpFile" ControlToValidate="fuFile"
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
                    </td>
                </tr>
                <tr id="trWidth" runat="server">
                    <td class="text">
                        <asp:Label ID="lblWidth" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="3" ID="txtWidth" runat="server" CssClass="Controls"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup="Messages" ID="rfvWidth" ControlToValidate="txtWidth"
                            Display="Dynamic" runat="server" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ValidationGroup="Messages" Display="Dynamic" ID="rxpWidth"
                            ValidationExpression="\d*" runat="server" ControlToValidate="txtWidth" ErrorMessage="<%= Resources.AdminText.InvalidNumericalData %>"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr id="trHeight" runat="server">
                    <td class="text">
                        <asp:Label ID="lblHeight" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="3" ID="txtHeight" runat="server" CssClass="Controls"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup="Messages" ID="rfvHeight" ControlToValidate="txtHeight"
                            Display="Dynamic" runat="server" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ValidationGroup="Messages" Display="Dynamic" ID="rxpHeight"
                            ValidationExpression="\d*" runat="server" ControlToValidate="txtHeight" ErrorMessage="<%= Resources.AdminText.InvalidNumericalData %>"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr id="trVideoExtension" runat="server">
                    <td class="text">
                        <asp:Label ID="lblVideoExtension" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:FileUpload ID="fuVideo" runat="server" CssClass="Controls" />
                        <asp:CheckBox ID="cbPublishVideo" CssClass="Controls"  runat="server" ValidationGroup="Messages">
                        </asp:CheckBox>
                        <asp:Label ID="lblVideoAvailableExtension" runat="server"></asp:Label>
                        <asp:RegularExpressionValidator ValidationGroup="Messages" ID="rxpVideo" ControlToValidate="fuVideo"
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
                                    <asp:TextBox MaxLength="16" ID="txtYoutubeCode" runat="server" CssClass="Controls"></asp:TextBox>
                                    <asp:RequiredFieldValidator ValidationGroup="Messages" ID="rfvYoutubeCode" ControlToValidate="txtYoutubeCode"
                                        Display="Dynamic" runat="server" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
                                    <asp:CheckBox ID="cbPublishYoutbe" CssClass="Controls"  runat="server"
                                        ValidationGroup="Messages"></asp:CheckBox>
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
                        <asp:CheckBox ID="cbPublishAudio" CssClass="Controls"  runat="server" ValidationGroup="Messages">
                        </asp:CheckBox>
                        <asp:Label ID="lblAudioAvailableExtension" runat="server"></asp:Label>
                        <asp:RegularExpressionValidator ValidationGroup="Messages" ID="rxpAudio" ControlToValidate="fuAudio"
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
                        <uc1:Date ID="ucItemDate" runat="server" ValidationGroup="Messages" />
                    </td>
                </tr>
                <tr id="trUrl" runat="server">
                    <td class="text">
                        <asp:Label ID="lblUrl" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="128" ID="txtUrl" runat="server" CssClass="Controls" ValidationGroup="Messages"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvUrl"
                            runat="server" ErrorMessage="*" ControlToValidate="txtUrl" ValidationGroup="Messages"
                            Text="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trTel" runat="server">
                    <td class="text">
                        <asp:Label ID="lblTel" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="13" ID="txtTel" runat="server" CssClass="Controls" ValidationGroup="Messages"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvTel"
                            runat="server" ErrorMessage="*" ControlToValidate="txtTel" ValidationGroup="Messages"
                            Text="*"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rxvTel" runat="server" ValidationGroup="Messages"
                            ControlToValidate="txtTel" ErrorMessage="<%$ Resources:User,InvalidNumericalData %>"
                            Display="Dynamic" CssClass="ourvalidation" ValidationExpression="\d*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr runat="server" id="trMobile">
                    <td class="text">
                        <asp:Label ID="lblMobile" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="32" ID="txtMobile" runat="server" CssClass="Controls" ValidationGroup="Messages"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvMobile"
                            runat="server" ErrorMessage="*" ControlToValidate="txtMobile" ValidationGroup="Messages"
                            Text="*"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rxvMobile" runat="server" ValidationGroup="Messages"
                            ControlToValidate="txtMobile" ErrorMessage="<%$ Resources:User,InvalidNumericalData %>"
                            Display="Dynamic" CssClass="ourvalidation" ValidationExpression="\d*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr id="trFax" runat="server">
                    <td class="text">
                        <asp:Label ID="lblFax" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="128" ID="txtFax" runat="server" CssClass="Controls" ValidationGroup="Messages"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvFax"
                            runat="server" ErrorMessage="*" ControlToValidate="txtFax" ValidationGroup="Messages"
                            Text="*"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rxvFax" runat="server" ValidationGroup="Messages"
                            ControlToValidate="txtFax" ErrorMessage="<%$ Resources:User,InvalidNumericalData %>"
                            Display="Dynamic" CssClass="ourvalidation" ValidationExpression="\d*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr id="trMailBox" runat="server">
                    <td class="text">
                        <asp:Label ID="lblMailBox" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="128" ID="txtMailBox" runat="server" CssClass="Controls" ValidationGroup="Messages"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvMailBox"
                            runat="server" ErrorMessage="*" ControlToValidate="txtMailBox" ValidationGroup="Messages"
                            Text="*"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rxvMailBox" runat="server" ValidationGroup="Messages"
                            ControlToValidate="txtMailBox" ErrorMessage="<%$ Resources:User,InvalidNumericalData %>"
                            Display="Dynamic" CssClass="ourvalidation" ValidationExpression="\d*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr id="trZipCode" runat="server">
                    <td class="text">
                        <asp:Label ID="lblZipCode" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="128" ID="txtZipCode" runat="server" CssClass="Controls" ValidationGroup="Messages"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvZipCode"
                            runat="server" ErrorMessage="*" ControlToValidate="txtZipCode" ValidationGroup="Messages"
                            Text="*"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rxvZipCode" runat="server" ValidationGroup="Messages"
                            ControlToValidate="txtZipCode" ErrorMessage="<%$ Resources:User,InvalidNumericalData %>"
                            Display="Dynamic" CssClass="ourvalidation" ValidationExpression="\d*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr id="trHasSmsService" runat="server">
                    <td class="text">
                        <asp:Label ID="lblHasSmsService" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:CheckBox ID="cbHasSmsService" runat="server" ValidationGroup="Messages"></asp:CheckBox>
                    </td>
                </tr>
                <tr id="trHasEmailService" runat="server">
                    <td class="text">
                        <asp:Label ID="lblHasEmailService" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:CheckBox ID="cbHasEmailService" runat="server" ValidationGroup="Messages"></asp:CheckBox>
                    </td>
                </tr>
                <tr id="trAgeRang" runat="server">
                    <td class="text">
                        <asp:Label ID="lblAgeRang" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:DropDownList ID="ddlAgeRang" runat="server" CssClass="Controls" ValidationGroup="Messages">
                            <asp:ListItem Selected="True" Value="-1" Text="<%$ Resources:User,Choose %>"></asp:ListItem>
                            <asp:ListItem Value="1" Text="<%$ Resources:Messages,AgeRang_1 %>"></asp:ListItem>
                            <asp:ListItem Value="2" Text="<%$ Resources:Messages,AgeRang_2 %>"></asp:ListItem>
                            <asp:ListItem Value="3" Text="<%$ Resources:Messages,AgeRang_3 %>"></asp:ListItem>
                            <asp:ListItem Value="4" Text="<%$ Resources:Messages,AgeRang_4 %>"></asp:ListItem>
                            <asp:ListItem Value="5" Text="<%$ Resources:Messages,AgeRang_5 %>"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvAgeRang"
                            runat="server" ErrorMessage="*" ControlToValidate="ddlAgeRang" InitialValue="-1"
                            ValidationGroup="Messages" Text="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trGender" runat="server">
                    <td class="text">
                        <asp:Label ID="lblGender" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:DropDownList ID="ddlGender" runat="server" CssClass="Controls" ValidationGroup="Messages">
                            <asp:ListItem Selected="True" Value="-1" Text="<%$ Resources:User,Choose %>"></asp:ListItem>
                            <asp:ListItem Value="1" Text="<%$ Resources:Messages,Gender_1 %>"></asp:ListItem>
                            <asp:ListItem Value="2" Text="<%$ Resources:Messages,Gender_2 %>"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvGender"
                            runat="server" ErrorMessage="*" ControlToValidate="ddlGender" InitialValue="-1"
                            ValidationGroup="Messages" Text="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trBirthDate" runat="server">
                    <td class="text">
                        <asp:Label ID="lblBirthDate" runat="server" />
                    </td>
                    <td class="Control">
                        <uc1:Date ID="ucDateBirthDate" runat="server" ValidationGroup="Messages" />
                    </td>
                </tr>
                <tr id="trSocialStatus" runat="server">
                    <td class="text">
                        <asp:Label ID="lblSocialStatus" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:DropDownList ID="ddlSocialStatus" runat="server" CssClass="Controls" ValidationGroup="Messages">
                            <asp:ListItem Selected="True" Value="-1" Text="<%$ Resources:User,Choose %>"></asp:ListItem>
                            <asp:ListItem Value="1" Text="<%$ Resources:Messages,SocialStatus_1 %>"></asp:ListItem>
                            <asp:ListItem Value="2" Text="<%$ Resources:Messages,SocialStatus_2 %>"></asp:ListItem>
                            <asp:ListItem Value="3" Text="<%$ Resources:Messages,SocialStatus_3 %>"></asp:ListItem>
                            <asp:ListItem Value="4" Text="<%$ Resources:Messages,SocialStatus_4 %>"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvSocialStatus"
                            runat="server" ErrorMessage="*" ControlToValidate="ddlSocialStatus" InitialValue="-1"
                            ValidationGroup="Messages" Text="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                
                <tr runat="server" id="trAddress">
                    <td class="text">
                        <asp:Label ID="lblAddress" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="256" ID="txtAddress" runat="server" TextMode="MultiLine"
                            CssClass="Controls" ValidationGroup="Messages" maxlengthS="256" onkeyup="return ismaxlength(this,document.forms[0].txtAddressLengthControler)"
                            onfocus="return ismaxlength(this,document.forms[0].txtAddressLengthControler)"></asp:TextBox>
                        <input type="text" class="Controls" name="txtAddressLengthControler" id="txtAddressLengthControler"
                            style="width: 40px;" disabled>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvAddress"
                            runat="server" ErrorMessage="*" ControlToValidate="txtAddress" ValidationGroup="Messages"
                            Text="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr runat="server" id="trJobTel">
                    <td class="text">
                        <asp:Label ID="lblJobTel" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="32" ID="txtJobTel" runat="server" CssClass="Controls" ValidationGroup="Messages"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvJobTel"
                            runat="server" ErrorMessage="*" ControlToValidate="txtJobTel" ValidationGroup="Messages"
                            Text="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trPrice" runat="server">
                    <td class="text">
                        <asp:Label ID="lblPrice" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="128" ID="txtPrice" runat="server" CssClass="Controls"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup="Messages" ID="rfvPrice" ControlToValidate="txtPrice"
                            Display="Dynamic" runat="server" ErrorMessage="*" Text="*"></asp:RequiredFieldValidator>
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
                                ControlToValidate="txtGoogleLatitude" ValidationGroup="Messages"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ValidationGroup="Messages" ControlToValidate="txtGoogleLatitude"
                                ID="RegularExpressionValidator2" ValidationExpression="[0-9]*\.?[0-9]*" Display="Dynamic"
                                runat="server" ErrorMessage="<%$ Resources:AdminText,InvalidEnteredValue %>"></asp:RegularExpressionValidator>
                        </div>
                        <div style="float: right">
                            <a id="A2" runat="server" href="/PopUps/GoogleMap.aspx" onclick="return hs.htmlExpand(this, { objectType: 'iframe', minHeight:'510' , height: '510' , width: '520' } )">
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
                                ControlToValidate="txtGoogleLongitude" ValidationGroup="Messages"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ValidationGroup="Messages" ID="RegularExpressionValidator1"
                                ControlToValidate="txtGoogleLongitude" ValidationExpression="[0-9]*\.?[0-9]*"
                                Display="Dynamic" runat="server" ErrorMessage="<%$ Resources:AdminText,InvalidEnteredValue %>"></asp:RegularExpressionValidator>
                        </div>
                        <div style="float: right">
                            <a id="A3" runat="server" href="/PopUps/GoogleMap.aspx" onclick="return hs.htmlExpand(this, { objectType: 'iframe', minHeight:'510' , height: '510' , width: '520' } )">
                                <img hspace="0" class='googleIcon' src="/Content/images/spacer.gif" alt="<%= Resources.AdminText.GoogleMapShow %>" /></a></div>
                    </td>
                </tr>
                <tr runat="server" id="trType">
                    <td class="text">
                        <asp:Label ID="lblType" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:DropDownList ID="ddlType" runat="server" CssClass="Controls">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvType"
                            runat="server" ErrorMessage="*" ControlToValidate="ddlType" ValidationGroup="Messages"
                            Text="*" InitialValue="-1"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trEducationLevel" runat="server">
                    <td class="text">
                        <asp:Label ID="lblEducationLevel" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:DropDownList ID="ddlEducationLevel" runat="server" CssClass="Controls" ValidationGroup="Messages">
                            <asp:ListItem Selected="True" Value="-1" Text="<%$ Resources:User,Choose %>"></asp:ListItem>
                            <asp:ListItem Value="1" Text=""></asp:ListItem>
                            <asp:ListItem Value="2" Text=""></asp:ListItem>
                            <asp:ListItem Value="3" Text=""></asp:ListItem>
                            <%--<asp:ListItem Value="4" Text="<%$ Resources:Messages,EducationLevel_4 %>"></asp:ListItem>
                            <asp:ListItem Value="5" Text="<%$ Resources:Messages,EducationLevel_5 %>"></asp:ListItem>--%>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvEducationLevel"
                            runat="server" ErrorMessage="*" ControlToValidate="ddlEducationLevel" InitialValue="-1"
                            ValidationGroup="Messages" Text="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trToItemID" runat="server">
                    <td class="text">
                        <asp:Label ID="lblToItemID" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:DropDownList ID="ddlItems" runat="server" CssClass="Controls">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvToItemID"
                            runat="server" ErrorMessage="*" ControlToValidate="ddlItems" ValidationGroup="Messages"
                            Text="*" InitialValue="-1"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trToUserID" runat="server">
                    <td class="text">
                        <asp:Label ID="lblToUserID" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:DropDownList ID="ddlToUserID" runat="server" CssClass="Controls" ValidationGroup="Messages" />
                    </td>
                </tr>
                <tr runat="server" id="trTitle">
                    <td class="text">
                        <asp:Label ID="lblTitle" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="128" ID="txtTitle" runat="server" CssClass="Controls" ValidationGroup="Messages"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvTitle"
                            runat="server" ErrorMessage="*" ControlToValidate="txtTitle" ValidationGroup="Messages"
                            Text="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trShortDescription" runat="server">
                    <td class="text">
                        <asp:Label ID="lblShortDescription" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="500" ID="txtShortDescription" runat="server" TextMode="MultiLine"
                            CssClass="Controls" maxlengthS="500" onkeyup="return ismaxlength(this,document.forms[0].txtShortDescriptionLengthControler)"
                            onfocus="return ismaxlength(this,document.forms[0].txtShortDescriptionLengthControler)"></asp:TextBox>
                        <input type="text" runat="server" class="Controls" id="txtSDLengthControler" style="width: 40px;"
                            disabled>
                        <asp:RequiredFieldValidator ID="rfvShortDescription" ControlToValidate="txtShortDescription"
                            CssClass="ourvalidation" ValidationGroup="Messages" runat="server" ErrorMessage="*"
                            Text="*" Display="Dynamic" />
                    </td>
                </tr>
                <tr id="trDetailsText" runat="server">
                    <td class="text">
                        <asp:Label ID="lblDetails" runat="server" />
                    </td>
                    <td class="Control">
                    </td>
                </tr>
                <tr id="trDetailsControl" runat="server">
                    <td class="DetailsControl" colspan="2">
                        <asp:TextBox ReadOnly="true" ID="txtDetails" runat="server" TextMode="MultiLine"
                            CssClass="DetailsControls" ValidationGroup="Messages" maxlengthS="1024" onkeyup="return ismaxlength(this,document.forms[0].txtDetailsLengthControler)"
                            onfocus="return ismaxlength(this,document.forms[0].txtDetailsLengthControler)"></asp:TextBox>
                        <CE:Editor ID="fckDetails" Height="500" Width="1000" EditorWysiwygModeCss="~/CuteSoft_Client/example.css"
                            runat="server">
                        </CE:Editor>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="rfvDetails" runat="server" ErrorMessage="*"
                            ControlToValidate="txtDetails" ValidationGroup="Messages" Text="*"></asp:RequiredFieldValidator>
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
                        <asp:CheckBox ID="CbIsMain" Checked="true" CssClass="Controls" runat="server"></asp:CheckBox>
                    </td>
                </tr>
                <tr id="trIsAvailable" runat="server">
                    <td class="text">
                        <asp:Label ID="lblIsAvailable" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:CheckBox ID="cbIsAvailable" Checked="true" CssClass="Controls" runat="server"
                            ValidationGroup="Messages"></asp:CheckBox>
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
                <tr id="trReplyText" runat="server">
                    <td class="text">
                        <asp:Label ID="lblReply" runat="server" />
                    </td>
                    <td class="Control">
                    </td>
                </tr>
                <tr id="trReply" runat="server">
                    <td class="DetailsControl" colspan="2">
                        <asp:TextBox ID="txtReply" runat="server" TextMode="MultiLine" CssClass="DetailsControls"
                            ValidationGroup="Messages"></asp:TextBox>
                        <CE:Editor ID="fckReply" Height="500" Width="1000" EditorWysiwygModeCss="~/CuteSoft_Client/example.css"
                            runat="server">
                        </CE:Editor>
                    </td>
                </tr>
                <tr id="trAttatch1" runat="server">
                    <td class="text">
                        <asp:Label ID="Label1s" Text="<%$ Resources:MailListAdmin,EmailAttatchFile1 %>" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:FileUpload ID="fuAttach1" runat="server" CssClass="Controls" ValidationGroup="MailListEmails" />
                        <asp:RegularExpressionValidator ID="regAttach1" runat="server" ControlToValidate="fuAttach1"
                            ValidationGroup="MailListEmails" ErrorMessage='<%$ Resources:MailListAdmin,EmailAttatchFileAvialableExtebtions %>'
                            ValidationExpression="(.*\.([pP][dD][fF])$)|(.*\.([dD][oO][cC])$)|(.*\.([dD][oO][cC][xX])$)|(.*\.([tT][xX][tT])$)|(.*\.([pP][nN][gG])$)|(.*\.([jJ][pP][gG])$)|(.*\.([gG][iI][fF])$)"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr id="trAttatch2" runat="server">
                    <td class="text">
                        <asp:Label ID="Label3" Text="<%$ Resources:MailListAdmin,EmailAttatchFile2 %>" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:FileUpload ID="fuAttach2" runat="server" CssClass="Controls" ValidationGroup="MailListEmails" />
                        <asp:RegularExpressionValidator ID="regAttach2" runat="server" ControlToValidate="fuAttach2"
                            ErrorMessage='<%$ Resources:MailListAdmin,EmailAttatchFileAvialableExtebtions %>'
                            ValidationGroup="MailListEmails" ValidationExpression="(.*\.([pP][dD][fF])$)|(.*\.([dD][oO][cC])$)|(.*\.([dD][oO][cC][xX])$)|(.*\.([tT][xX][tT])$)|(.*\.([pP][nN][gG])$)|(.*\.([jJ][pP][gG])$)|(.*\.([gG][iI][fF])$)"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr id="trAttatch3" runat="server">
                    <td class="text">
                        <asp:Label ID="Label5" Text="<%$ Resources:MailListAdmin,EmailAttatchFile3 %>" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:FileUpload ID="fuAttach3" runat="server" CssClass="Controls" ValidationGroup="MailListEmails" />
                        <asp:RegularExpressionValidator ID="regAttach3" runat="server" ControlToValidate="fuAttach3"
                            ValidationGroup="MailListEmails" ErrorMessage='<%$ Resources:MailListAdmin,EmailAttatchFileAvialableExtebtions %>'
                            ValidationExpression="(.*\.([pP][dD][fF])$)|(.*\.([dD][oO][cC])$)|(.*\.([dD][oO][cC][xX])$)|(.*\.([tT][xX][tT])$)|(.*\.([pP][nN][gG])$)|(.*\.([jJ][pP][gG])$)|(.*\.([gG][iI][fF])$)"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr id="trMetaKeyWords" runat="server">
                    <td class="text">
                        <asp:Label ID="lblMetaKeyWords" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="128" ID="txtMetaKeyWords" runat="server" CssClass="Controls"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Result" align="center" colspan="2">
                        <asp:Button ID="btnSave" runat="server" ValidationGroup="Messages" OnClick="btnSave_Click"
                            SkinID="btnSave" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
