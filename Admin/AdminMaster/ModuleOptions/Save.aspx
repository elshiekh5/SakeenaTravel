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
                        <td class="Control-en" colspan="2">
                            <table class='elssubcontainer' cellspacing="0" cellpadding="0" border="0" style="margin: 3px 0px 3px 3px;
                                width: 100%; border: 1px solid #cccccc;">
                                <tr>
                                    <td class="Text-en">
                                        Static
                                        <br />
                                        <span style="font-weight: normal">(from 1 to 9)</span>
                                    </td>
                                    <td class="Control-en">
                                        SitePages = 1, StaticContents = 2
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Text-en">
                                        Items Modules
                                        <br />
                                        <span style="font-weight: normal">(from 10 to 100)</span>
                                    </td>
                                    <td class="Control-en">
                                        Authors = 10,About_Us = 11
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Text-en">
                                        Galleries Modules
                                        <br />
                                        <span style="font-weight: normal">(from 101 to 200)</span>
                                    </td>
                                    <td class="Control-en">
                                        PhotoGallery = 101
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Text-en">
                                        Messages Modules (forms)
                                        <br />
                                        <span style="font-weight: normal">(from 501 to 600)</span>
                                    </td>
                                    <td class="Control-en">
                                        Contact_Us = 501, Consulting_Services = 502, VisitorSigns = 503
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Text-en">
                                        Users Modules (forms):
                                        <br />
                                        <span style="font-weight: normal">(from 601 to 700)</span>
                                    </td>
                                    <td class="Control-en">
                                        Registration_User = 601,Registration_Consultant = 602
                                    </td>
                                </tr>
                                <tr>
                                    <td class="Text-en">
                                        Special Modules:
                                        <br />
                                        <span style="font-weight: normal">(from 1001 to 1100)</span>
                                    </td>
                                    <td class="Control-en">
                                        MailList = 1001, SMS = 1002, Vote = 1003, Advertisments = 1004
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Identifire
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="64" ID="txtIdentifire" runat="server" CssClass="Controls-en"
                                ValidationGroup="ItemsModulesOptions"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvIdentifire" ControlToValidate="txtIdentifire"
                                ValidationGroup="ItemsModulesOptions" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            ModuleTypeID
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="11" ID="txtModuleTypeID" runat="server" CssClass="Controls-en"
                                ValidationGroup="ItemsModulesOptions"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvModuleTypeID" ControlToValidate="txtModuleTypeID"
                                ValidationGroup="ItemsModulesOptions" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="RegularExpressionValidator1"
                                runat="server" ControlToValidate="txtModuleTypeID" ErrorMessage="" Text="<%$ Resources:AdminText,InvalidNumericalData %>"
                                ValidationGroup="ItemsModulesOptions" ValidationExpression="\d*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Module Type
                        </td>
                        <td class="Control-en">
                            <asp:DropDownList ID="ddlModuleType" runat="server" CssClass="Controls-en" ValidationGroup="ItemsModulesOptions">
                            </asp:DropDownList>
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
                            Has Special Admin Text 
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasSpecialAdminText" CssClass="Controls-en" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Module Title
                        </td>
                        <td class="Control-en">
                            Arabic
                            <asp:TextBox MaxLength="64" ID="txtModuleTitleArabic" runat="server" CssClass="Controls-en"
                                ValidationGroup="ItemsModulesOptions"></asp:TextBox>
                            English
                            <asp:TextBox MaxLength="64" ID="txtModuleTitleEnglish" runat="server" CssClass="Controls-en"
                                ValidationGroup="ItemsModulesOptions"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Module Admin Special Title
                        </td>
                        <td class="Control-en">
                            Arabic
                            <asp:TextBox MaxLength="64" ID="txtModuleAdminSpecialTitleArabic" runat="server" CssClass="Controls-en"
                                ValidationGroup="ItemsModulesOptions"></asp:TextBox>
                            English
                            <asp:TextBox MaxLength="64" ID="txtModuleAdminSpecialTitleEnglish" runat="server" CssClass="Controls-en"
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
                            Desplay Categories InAdmin Menu
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbDisplayCategoriesInAdminMenue" CssClass="Controls-en" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Module RelatedPageID
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="9" ID="txtModuleRelatedPageID" runat="server" CssClass="Controls-en"
                                ValidationGroup="ItemsModulesOptions"></asp:TextBox>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="revModuleRelatedPageID" runat="server"
                                ControlToValidate="txtModuleRelatedPageID" ErrorMessage="" Text="<%$ Resources:AdminText,InvalidNumericalData %>"
                                ValidationGroup="ItemsModulesOptions" ValidationExpression="^-?\d*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Allow Duplicate Titles
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbAllowDublicateTitlesInItems" Text="Items" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbAllowDublicateTitlesInCategories" Text="Categories" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
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
                            Messages Module ID
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="64" ID="txtMessagesModuleID" runat="server" CssClass="SmallControls"
                                ValidationGroup="ItemsModulesOptions"></asp:TextBox>
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
                            ListID
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="64" ID="txtListID" runat="server" CssClass="SmallControls"
                                ValidationGroup="ItemsModulesOptions"></asp:TextBox>
                        </td>
                    </tr>
                    
                    
                    
                    
                    
                    <tr>
                        <td class="Text-en">
                            ⁄œœ ⁄‰«’— ’›Õ… «·„ÊœÌÊ·
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="64" ID="txtPageItemCount_UserDefault" runat="server" CssClass="SmallControls"
                                ValidationGroup="ItemsModulesOptions"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            ⁄œœ ⁄‰«’— ’›Õ… «·√œ„‰
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="64" ID="txtPageItemCount_AdminDefault" runat="server" CssClass="SmallControls"
                                ValidationGroup="ItemsModulesOptions"></asp:TextBox>
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="Text-en">
                            List Has Date
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbListHasDate" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
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
                     <tr>
                        <td class="Text-en">
                           «·”„«Õ »«·»ÕÀ œ«Œ· «·„ÊœÌÊ·
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasSearch" CssClass="Controls-en" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
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
                            Module Meta KeyWords
                        </td>
                        <td class="Control-en">
                            <asp:TextBox ID="txtModuleMetaKeyWords" TextMode="MultiLine" Width="450" runat="server" CssClass="Controls-en"
                                ValidationGroup="ItemsModulesOptions"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Module Meta Description
                        </td>
                        <td class="Control-en">
                            <asp:TextBox ID="txtModuleMetaDescription" TextMode="MultiLine" Width="450" runat="server" CssClass="Controls-en"
                                ValidationGroup="ItemsModulesOptions"></asp:TextBox>
                        </td>
                    </tr>
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
            »Ì«‰«  «· ’‰Ì›« 
        </div>
        <div class="categoryitems">
            <div class="items_contents_body">
                <table class='elssubcontainer' cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td colspan="2" class="smallSubHeader">
                            »Ì«‰«  «· ’‰Ì›«  «·√”«”Ì…
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Category Level
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="9" ID="txtCategoryLevel" runat="server" CssClass="Controls-en"
                                ValidationGroup="ItemsModulesOptions"></asp:TextBox>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="revCategoryLevel" runat="server"
                                ControlToValidate="txtCategoryLevel" ErrorMessage="" Text="<%$ Resources:AdminText,InvalidNumericalData %>"
                                ValidationGroup="ItemsModulesOptions" ValidationExpression="^-?\d*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Title
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbCategoryHasTitle" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbCategoryRequiredTitle" CssClass="Controls-en" Text="Required"
                                runat="server" ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Short Description
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbCategoryHasShortDescription" CssClass="Controls-en" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                            <asp:CheckBox ID="cbCategoryRequiredShortDescription" CssClass="Controls-en" Text="Required"
                                runat="server" ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Details
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbCategoryHasDetails" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbCategoryRequiredDetails" CssClass="Controls-en" Text="Required"
                                runat="server" ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                            <asp:CheckBox ID="cbCategoryDetailsInHtmlEditor" CssClass="Controls-en" runat="server"
                                ValidationGroup="ItemsModulesOptions" Text="HtmlEditor"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Photo
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbCategoryHasPhotoExtension" CssClass="Controls-en" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                            <asp:CheckBox ID="cbCategoryRequiredPhoto" CssClass="Controls-en" Text="Required"
                                runat="server" ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                            <asp:CheckBox ID="cbCategoryHasPublishPhoto" CssClass="Controls-en" Text="HasPublish"
                                runat="server" ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Available Extension
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="128" ID="txtCategoryPhotoAvailableExtension" runat="server"
                                CssClass="Controls-en" ValidationGroup="ItemsModulesOptions"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            PhotoMaxSize
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="9" ID="txtCategoryPhotoMaxSize" runat="server" CssClass="Controls-en"
                                ValidationGroup="ItemsModulesOptions"></asp:TextBox>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="revCategoryPhotoMaxSize" runat="server"
                                ControlToValidate="txtCategoryPhotoMaxSize" ErrorMessage="" Text="<%$ Resources:AdminText,InvalidNumericalData %>"
                                ValidationGroup="ItemsModulesOptions" ValidationExpression="^-?\d*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="smallSubHeader">
                            »Ì«‰«  «· ’‰Ì›«  «·≈÷«›Ì…
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Google Latitude
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbCategoryHasGoogleLatitude" CssClass="Controls-en" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                            <asp:CheckBox ID="cbCategoryRequiredGoogleLatitude" CssClass="Controls-en" Text="Required"
                                runat="server" ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Google Longitude
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbCategoryHasGoogleLongitude" CssClass="Controls-en" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                            <asp:CheckBox ID="cbCategoryRequiredGoogleLongitude" CssClass="Controls-en" Text="Required"
                                runat="server" ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Item Date
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbCategoryHasItemDate" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbCategoryRequiredItemDate" CssClass="Controls-en" Text="Required"
                                runat="server" ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Date_Added
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbCategoryHasDate_Added" CssClass="Controls-en" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Is Main
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbCategoryHasIsMain" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Priority
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbCategoryHasPriority" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            IsAvailable
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbCategoryHasIsAvailable" CssClass="Controls-en" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Visities Count
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbCategoryHasVisitiesCount" CssClass="Controls-en" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            OnlyForRegisered
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbCategoryHasOnlyForRegisered" CssClass="Controls-en" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            OwnerID
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbCategoryHasOwnerID" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="smallSubHeader">
                            »Ì«‰«  „·›«  «· ’‰Ì›« 
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Youtube Code
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbCategoryHasYoutubeCode" CssClass="Controls-en" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                            <asp:CheckBox ID="cbCategoryRequiredYoutubeCode" CssClass="Controls-en" Text="Required"
                                runat="server" ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                            <asp:CheckBox ID="cbCategoryHasPublishYoutbe" CssClass="Controls-en" Text="HasPublish"
                                runat="server" ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Video
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbCategoryHasVideoExtension" CssClass="Controls-en" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                            <asp:CheckBox ID="cbCategoryRequiredVideo" CssClass="Controls-en" Text="Required"
                                runat="server" ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                            <asp:CheckBox ID="cbCategoryHasPublishVideo" CssClass="Controls-en" Text="HasPublish"
                                runat="server" ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Video Available Extension
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="128" ID="txtCategoryVideoAvailableExtension" runat="server"
                                CssClass="Controls-en" ValidationGroup="ItemsModulesOptions"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Video Max Size
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="9" ID="txtCategoryVideoMaxSize" runat="server" CssClass="Controls-en"
                                ValidationGroup="ItemsModulesOptions"></asp:TextBox>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="revCategoryVideoMaxSize" runat="server"
                                ControlToValidate="txtCategoryVideoMaxSize" ErrorMessage="" Text="<%$ Resources:AdminText,InvalidNumericalData %>"
                                ValidationGroup="ItemsModulesOptions" ValidationExpression="^-?\d*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Audio
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbCategoryHasAudioExtension" CssClass="Controls-en" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                            <asp:CheckBox ID="cbCategoryRequiredAudio" CssClass="Controls-en" Text="Required"
                                runat="server" ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                            <asp:CheckBox ID="cbCategoryHasPublishAudio" CssClass="Controls-en" Text="HasPublish"
                                runat="server" ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Audio Available Extension
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="128" ID="txtCategoryAudioAvailableExtension" runat="server"
                                CssClass="Controls-en" ValidationGroup="ItemsModulesOptions"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Audio MaxSize
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="9" ID="txtCategoryAudioMaxSize" runat="server" CssClass="Controls-en"
                                ValidationGroup="ItemsModulesOptions"></asp:TextBox>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="revCategoryAudioMaxSize" runat="server"
                                ControlToValidate="txtCategoryAudioMaxSize" ErrorMessage="" Text="<%$ Resources:AdminText,InvalidNumericalData %>"
                                ValidationGroup="ItemsModulesOptions" ValidationExpression="^-?\d*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            File
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbCategoryHasFileExtension" CssClass="Controls-en" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                            <asp:CheckBox ID="cbCategoryRequiredFile" CssClass="Controls-en" Text="Required"
                                runat="server" ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                            <asp:CheckBox ID="cbCategoryHasPublishFile" CssClass="Controls-en" Text="HasPublish"
                                runat="server" ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            File Available Extension
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="128" ID="txtCategoryFileAvailableExtension" runat="server"
                                CssClass="Controls-en" ValidationGroup="ItemsModulesOptions"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            File Max Size
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="9" ID="txtCategoryFileMaxSize" runat="server" CssClass="Controls-en"
                                ValidationGroup="ItemsModulesOptions"></asp:TextBox>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="revCategoryFileMaxSize" runat="server"
                                ControlToValidate="txtCategoryFileMaxSize" ErrorMessage="" Text="<%$ Resources:AdminText,InvalidNumericalData %>"
                                ValidationGroup="ItemsModulesOptions" ValidationExpression="^-?\d*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Height
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbCategoryHasHeight" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbCategoryRequiredHeight" CssClass="Controls-en" Text="Required"
                                runat="server" ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Width
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbCategoryHasWidth" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbCategoryRequiredWidth" CssClass="Controls-en" Text="Required"
                                runat="server" ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Photo2
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbCategoryHasPhoto2Extension" CssClass="Controls-en" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                            <asp:CheckBox ID="cbCategoryRequiredPhoto2" CssClass="Controls-en" Text="Required"
                                runat="server" ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                            <asp:CheckBox ID="cbCategoryHasPublishPhoto2" CssClass="Controls-en" Text="HasPublish"
                                runat="server" ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Photo2 Available Extension
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="128" ID="txtCategoryPhoto2AvailableExtension" runat="server"
                                CssClass="Controls-en" ValidationGroup="ItemsModulesOptions"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Photo2 Max Size
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="9" ID="txtCategoryPhoto2MaxSize" runat="server" CssClass="Controls-en"
                                ValidationGroup="ItemsModulesOptions"></asp:TextBox>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="revCategoryPhoto2MaxSize" runat="server"
                                ControlToValidate="txtCategoryPhoto2MaxSize" ErrorMessage="" Text="<%$ Resources:AdminText,InvalidNumericalData %>"
                                ValidationGroup="ItemsModulesOptions" ValidationExpression="^-?\d*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="smallSubHeader">
                            »Ì«‰«  ⁄—÷ «· ’‰Ì›« 
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Category Intro
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasCategoryIntro" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            ListID
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="64" ID="txtCategoryListID" runat="server" CssClass="SmallControls"
                                ValidationGroup="ItemsModulesOptions"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            ⁄œœ ⁄‰«’— ’›Õ… «· ’‰Ì›« 
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="64" ID="txtCategoryPageItemCount_UserDefault" runat="server" CssClass="SmallControls"
                                ValidationGroup="ItemsModulesOptions"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                               ⁄œœ ⁄‰«’— ’›Õ… «· ’‰Ì›«  ›Ì «·√œ„‰
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="64" ID="txtCategoryPageItemCount_AdminDefault" runat="server"
                                CssClass="SmallControls" ValidationGroup="ItemsModulesOptions" Text="25"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="smallSubHeader">
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Admin Note
                        </td>
                        <td class="Control-en">
                            <asp:TextBox ID="txtCategoryAdminNote" TextMode="MultiLine" Width="450" runat="server"
                                CssClass="Controls-en" ValidationGroup="ItemsModulesOptions"></asp:TextBox>
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
                            Font Icon
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbFontIcon" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredFontIcon" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                           
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
                            Item End Date
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasItemEndDate" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredItemEndDate" CssClass="Controls-en" Text="Required" runat="server"
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
                            SpecialOption
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbSpecialOption" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
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
                            Type
                        </td>
                        <td class="Control-en">
                            <table>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="cbHasType" CssClass="Controls-en" runat="server" ValidationGroup="ItemsModulesOptions">
                                        </asp:CheckBox>
                                        <asp:CheckBox ID="cbRequiredType" CssClass="Controls-en" Text="Required" runat="server"
                                            ValidationGroup="ItemsModulesOptions"></asp:CheckBox>
                                    </td>
                                    <td>
                                        Types Count
                                    </td>
                                    <td>
                                        <asp:TextBox MaxLength="9" ID="txtTypesCount" runat="server" CssClass="Controls-en"
                                            ValidationGroup="ItemsModulesOptions"></asp:TextBox>
                                        <asp:RegularExpressionValidator Display="Dynamic" ID="revTypesCount" runat="server"
                                            ControlToValidate="txtTypesCount" ErrorMessage="" Text="<%$ Resources:AdminText,InvalidNumericalData %>"
                                            ValidationGroup="ItemsModulesOptions" ValidationExpression="^-?\d*"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                            </table>
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
