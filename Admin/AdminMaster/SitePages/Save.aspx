<%@ Page Language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="Save.aspx.cs"
    Inherits="AdminModuleOptions_Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="">
        <asp:Label ID="lblResult" runat="server"></asp:Label>
    </div>
    <div class="arrowlistmenubig">
        <div class="menuheader expandable">
            «·»Ì«‰«  «·√”«”Ì…
        </div>
        <div class="categoryitems">
            <div class="items_contents_body">
                <table class='elssubcontainer' cellspacing="0" cellpadding="0" border="0">
                    
                   
                    
                     <tr>
                        <td class="Text-en">
                            Identifire
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="64" ID="txtIdentifire" runat="server" CssClass="Controls-en"
                                ValidationGroup="ItemsModulesOptions"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="rfvIdentifire" ControlToValidate="txtIdentifire" ValidationGroup="ItemsModulesOptions" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            PageID
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="11" ID="txtPageID" runat="server" CssClass="Controls-en"
                                ValidationGroup="ItemsModulesOptions"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPageID" ControlToValidate="txtPageID"  ValidationGroup="ItemsModulesOptions" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                                 <asp:RegularExpressionValidator Display="Dynamic" ID="RegularExpressionValidator1" runat="server"
                                ControlToValidate="txtPageID" ErrorMessage="" Text="<%$ Resources:AdminText,InvalidNumericalData %>"
                                ValidationGroup="ItemsModulesOptions" ValidationExpression="\d*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Page Title
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="64" ID="txtPageTitle" runat="server" CssClass="Controls-en"
                                ValidationGroup="ItemsModulesOptions"></asp:TextBox>
                        </td>
                    </tr>
                                       <tr>
                        <td class="Text-en">
                            Resource File
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="32" ID="txtResourceFile" runat="server" CssClass="Controls-en"
                                ValidationGroup="ItemsModulesOptions"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Default Resource File
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="32" ID="txtDefaultResourceFile" runat="server" CssClass="Controls-en"
                                ValidationGroup="ItemsModulesOptions"></asp:TextBox>
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="Text-en">
                            Add In Admin Menu Autmaticly
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbAddInAdminMenuAutmaticly" CssClass="Controls-en" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="Text-en">
                            Has Owen Folder
                        </td>
                        <td class="Control-en">
                             <asp:CheckBox ID="cbHasOwenFolder_User" Text="User" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbHasOwenFolder_Admin" Text="Admin" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="Text-en">
                           Module Special Path
                        </td>
                        <td class="Control-en">
                            <asp:TextBox  ID="txtModuleSpecialPath" runat="server" CssClass="Controls"
                                ValidationGroup="ItemsModulesOptions"></asp:TextBox>

                        </td>
                    </tr>


                    <tr>
                        <td class="Text-en">
                            Has Messages
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasMessages" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Show in Site Departments
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbShowInSiteDepartments"  CssClass="Controls-en"
                                runat="server" ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="Text-en">
                            Admin Note
                        </td>
                        <td class="Control-en">
                            <asp:TextBox ID="txtAdminNote" TextMode="MultiLine" Width="450" runat="server" CssClass="Controls-en"
                                ValidationGroup="ItemsModulesOptions"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            HasOwnerID
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasOwnerID" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="items_vontents_footer">
            </div>
        </div>
        
        <div class="menuheader expandable">
            ≈⁄œ«œ«  «·”ÌÊ
        </div>
        <div class="categoryitems">
            <div class="items_contents_body">
                <table class='elssubcontainer' cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="Text-en">
                            Has Meta KeyWords
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasMetaKeyWords" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Has Meta Description
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasMetaDescription" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="items_vontents_footer">
            </div>
        </div>

        <div class="menuheader expandable">
            «·⁄‰«’— «·√”«”Ì…
        </div>
        <div class="categoryitems">
            <div class="items_contents_body">
                <table class='elssubcontainer' cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="Text-en">
                            Title
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasTitle" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredTitle" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                            <asp:CheckBox ID="cbHasTitleInDetailsPage" CssClass="Controls-en" Text="HasTitleInDetailsPage"
                                runat="server" ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Short Description
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasShortDescription" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredShortDescription" CssClass="Controls-en" Text="Required"
                                runat="server" ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                            <asp:CheckBox ID="cbHasShortDescriptionInDetailsPage" CssClass="Controls-en" Text="InDetailsPage"
                                runat="server" ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Details
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasDetails" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredDetails" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                            <asp:CheckBox ID="cbDetailsInHtmlEditor" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions"
                                Text="HtmlEditor"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Photo
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasPhotoExtension" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredPhoto" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                            <asp:CheckBox ID="cbHasPublishPhoto" CssClass="Controls-en" Text="HasPublish" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Photo Available Extension
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="128" ID="txtPhotoAvailableExtension" runat="server" CssClass="Controls-en"
                                ValidationGroup="ItemsModulesOptions"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            PhotoMaxSize
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="9" ID="txtPhotoMaxSize" runat="server" CssClass="Controls-en"
                                ValidationGroup="ItemsModulesOptions"></asp:TextBox>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="revPhotoMaxSize" runat="server"
                                ControlToValidate="txtPhotoMaxSize" ErrorMessage="" Text="<%$ Resources:AdminText,InvalidNumericalData %>"
                                ValidationGroup="ItemsModulesOptions" ValidationExpression="^-?\d*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Author ID
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasAuthorID" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Author Name Text
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasAuthorName" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredAuthorName" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Item Date
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasItemDate" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredItemDate" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Date_Added
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasDate_Added" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Is Main
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasIsMain" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Priority
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasPriority" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            IsAvailable
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasIsAvailable" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            HasGoogleLatitude
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasGoogleLatitude" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredGoogleLatitude" CssClass="Controls-en" Text="Required"
                                runat="server" ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            HasGoogleLongitude
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasGoogleLongitude" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredGoogleLongitude" CssClass="Controls-en" Text="Required"
                                runat="server" ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            HasPrice
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasPrice" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredPrice" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            HasOnlyForRegisered
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasOnlyForRegisered" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    
                </table>
            </div>
            <div class="items_vontents_footer">
            </div>
        </div>
        <div class="menuheader expandable">
            »Ì«‰«  «·≈ ’«·
        </div>
        <div class="categoryitems">
            <div class="items_contents_body">
                <table class='elssubcontainer' cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="Text-en">
                            Address
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasAddress" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredAddress" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            MailBox
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasMailBox" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredMailBox" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            ZipCode
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasZipCode" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredZipCode" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Tels
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasTels" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredTels" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Fax
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasFax" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredFax" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Mobile
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasMobile" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredMobile" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Url
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasUrl" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredUrl" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Email
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasEmail" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredEmail" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="items_vontents_footer">
            </div>
        </div>
        <div class="menuheader expandable">
            »Ì«‰«  «·„·›« 
        </div>
        <div class="categoryitems">
            <div class="items_contents_body">
                <table class='elssubcontainer' cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="Text-en">
                            Youtube Code
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasYoutubeCode" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredYoutubeCode" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                            <asp:CheckBox ID="cbHasPublishYoutbe" CssClass="Controls-en" Text="HasPublish" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Video
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasVideoExtension" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredVideo" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                            <asp:CheckBox ID="cbHasPublishVideo" CssClass="Controls-en" Text="HasPublish" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Video Available Extension
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="128" ID="txtVideoAvailableExtension" runat="server" CssClass="Controls-en"
                                ValidationGroup="ItemsModulesOptions"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Video Max Size
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="9" ID="txtVideoMaxSize" runat="server" CssClass="Controls-en"
                                ValidationGroup="ItemsModulesOptions"></asp:TextBox>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="revVideoMaxSize" runat="server"
                                ControlToValidate="txtVideoMaxSize" ErrorMessage="" Text="<%$ Resources:AdminText,InvalidNumericalData %>"
                                ValidationGroup="ItemsModulesOptions" ValidationExpression="^-?\d*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Audio
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasAudioExtension" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredAudio" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                            <asp:CheckBox ID="cbHasPublishAudio" CssClass="Controls-en" Text="HasPublish" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Audio Available Extension
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="128" ID="txtAudioAvailableExtension" runat="server" CssClass="Controls-en"
                                ValidationGroup="ItemsModulesOptions"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Audio MaxSize
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="9" ID="txtAudioMaxSize" runat="server" CssClass="Controls-en"
                                ValidationGroup="ItemsModulesOptions"></asp:TextBox>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="revAudioMaxSize" runat="server"
                                ControlToValidate="txtAudioMaxSize" ErrorMessage="" Text="<%$ Resources:AdminText,InvalidNumericalData %>"
                                ValidationGroup="ItemsModulesOptions" ValidationExpression="^-?\d*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            File
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasFileExtension" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredFile" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                            <asp:CheckBox ID="cbHasPublishFile" CssClass="Controls-en" Text="HasPublish" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            File Available Extension
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="128" ID="txtFileAvailableExtension" runat="server" CssClass="Controls-en"
                                ValidationGroup="ItemsModulesOptions"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            File Max Size
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="9" ID="txtFileMaxSize" runat="server" CssClass="Controls-en"
                                ValidationGroup="ItemsModulesOptions"></asp:TextBox>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="revFileMaxSize" runat="server"
                                ControlToValidate="txtFileMaxSize" ErrorMessage="" Text="<%$ Resources:AdminText,InvalidNumericalData %>"
                                ValidationGroup="ItemsModulesOptions" ValidationExpression="^-?\d*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Height
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasHeight" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredHeight" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Width
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasWidth" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredWidth" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Photo2
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasPhoto2Extension" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredPhoto2" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                            <asp:CheckBox ID="cbHasPublishPhoto2" CssClass="Controls-en" Text="HasPublish" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Photo2 Available Extension
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="128" ID="txtPhoto2AvailableExtension" runat="server" CssClass="Controls-en"
                                ValidationGroup="ItemsModulesOptions"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Photo2 Max Size
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="9" ID="txtPhoto2MaxSize" runat="server" CssClass="Controls-en"
                                ValidationGroup="ItemsModulesOptions"></asp:TextBox>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="revPhoto2MaxSize" runat="server"
                                ControlToValidate="txtPhoto2MaxSize" ErrorMessage="" Text="<%$ Resources:AdminText,InvalidNumericalData %>"
                                ValidationGroup="ItemsModulesOptions" ValidationExpression="^-?\d*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Multi Photos
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasMultiPhotos" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="items_vontents_footer">
            </div>
        </div>
        <div class="menuheader expandable">
            Œœ„«  ≈÷«›Ì…
        </div>
        <div class="categoryitems">
            <div class="items_contents_body">
                <table class='elssubcontainer' cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="Text-en">
                            Visities Count
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasVisitiesCount" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Print
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasPrint" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Tel A Friend
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasTelFriend" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Save As Document
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasSaveAsDocument" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Comments
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasComments" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Share
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasShare" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            RSS
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasRSS" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Rating
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasRating" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="items_vontents_footer">
            </div>
        </div>
        <div class="menuheader expandable">
            «·—»ÿ »«·ﬁ«∆„… «·»—ÌœÌ…
        </div>
        <div class="categoryitems">
            <div class="items_contents_body">
                <table class='elssubcontainer' cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="Text-en">
                            Automatic Registration
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbMailListAutomaticRegistration" CssClass="Controls-en" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Sending Mail Activation
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbMailListSendingMailActivation" CssClass="Controls-en" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Automatic Activation
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbMailListAutomaticActivation" CssClass="Controls-en" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="items_vontents_footer">
            </div>
        </div>
        <div class="menuheader expandable">
            «·—»ÿ »ÃÊ«· «·„Êﬁ⁄
        </div>
        <div class="categoryitems">
            <div class="items_contents_body">
                <table class='elssubcontainer' cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="Text-en">
                            Automatic Registration
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbSmsAutomaticRegistration" CssClass="Controls-en" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Sending Sms Activation
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbSmsSendingSmsActivation" CssClass="Controls-en" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Automatic Activation
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbSmsAutomaticActivation" CssClass="Controls-en" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="items_vontents_footer">
            </div>
        </div>
        
        <div class="menuheader expandable">
            ≈⁄œ«œ«  „‘«—ﬂ«  «·“Ê«—
        </div>
        <div class="categoryitems">
            <div class="items_contents_body">
                <table class='elssubcontainer' cellspacing="0" cellpadding="0" border="0">
                <tr>
                        <td class="Text-en">
                           «·”„«Õ »„‘«—ﬂ«  «·“Ê«—
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbAllowVisitorsParticipations" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Users only can send
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbSendingOnlyByUsers" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Sender Name
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasSenderName" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredSenderName" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Sender EMail
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasSenderEMail" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredSenderEMail" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Sender CountryID
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasSenderCountryID" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredSenderCountryID" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Redirect To Member
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasRedirectToMember" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Member Role (send to ddl)
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="64" ID="txtMemberRole" runat="server" CssClass="Controls-en"
                                ValidationGroup="ItemsModulesOptions"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Reply
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasReply" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredReply" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                            <asp:CheckBox ID="cbReplyInHtmlEditor" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions"
                                Text="ReplyInHtmlEditor"></asp:CheckBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="items_vontents_footer">
            </div>
        </div>
        
        
    </div>
    <div style="">
        <asp:Button ID="btnSave" runat="server" ValidationGroup="ItemsModulesOptions" OnClick="btnSave_Click"
            SkinID="btnSave" /></div>
</asp:Content>
