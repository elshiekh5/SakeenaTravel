<%@ Page Language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="Save.aspx.cs"
    Inherits="AdminUsersDataGlobalOptions_Create" %>

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
                                ValidationGroup="UsersDataGlobalOptions"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvIdentifire" ControlToValidate="txtIdentifire"
                                ValidationGroup="UsersDataGlobalOptions" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            ModuleTypeID
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="11" ID="txtModuleTypeID" runat="server" CssClass="Controls-en"
                                ValidationGroup="UsersDataGlobalOptions"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvModuleTypeID" ControlToValidate="txtModuleTypeID"
                                ValidationGroup="UsersDataGlobalOptions" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="RegularExpressionValidator1"
                                runat="server" ControlToValidate="txtModuleTypeID" ErrorMessage="" Text="<%$ Resources:AdminText,InvalidNumericalData %>"
                                ValidationGroup="UsersDataGlobalOptions" ValidationExpression="\d*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            User Type
                        </td>
                        <td class="Control-en">
                            <asp:DropDownList ID="ddlUserType" runat="server" CssClass="Controls-en" ValidationGroup="UsersDataGlobalOptions">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Sub Site Type
                        </td>
                        <td class="Control-en">
                            <asp:DropDownList ID="ddlSubSiteType" runat="server" CssClass="Controls-en" ValidationGroup="UsersDataGlobalOptions">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Has UserId
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasUserId" CssClass="Controls-en" runat="server" ValidationGroup="UsersDataGlobalOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            UserRole
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="64" ID="txtUserRole" runat="server" CssClass="Controls-en"
                                ValidationGroup="UsersDataGlobalOptions"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            HasAddUserInAdmin
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasAddUserInAdmin" CssClass="Controls-en" runat="server" ValidationGroup="UsersDataGlobalOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            HasOwenFolder
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasOwenFolder_User" Text="User" CssClass="Controls-en" runat="server"
                                ValidationGroup="UsersDataGlobalOptions"></asp:CheckBox>
                            <asp:CheckBox ID="cbHasOwenFolder_Admin" Text="Admin" CssClass="Controls-en" runat="server"
                                ValidationGroup="UsersDataGlobalOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="Text-en">
                           Module Special Path
                        </td>
                        <td class="Control-en">
                            <asp:TextBox  ID="txtModuleSpecialPath" runat="server" CssClass="Controls"
                                ValidationGroup="UsersDataGlobalOptions"></asp:TextBox>

                        </td>
                    </tr>


                    <tr>
                        <td class="Text-en">
                            Module Title
                        </td>
                        <td class="Control-en">
                            Arabic
                            <asp:TextBox MaxLength="64" ID="txtModuleTitleArabic" runat="server" CssClass="Controls-en"
                                ValidationGroup="UsersDataGlobalOptions"></asp:TextBox>
                            English
                            <asp:TextBox MaxLength="64" ID="txtModuleTitleEnglish" runat="server" CssClass="Controls-en"
                                ValidationGroup="UsersDataGlobalOptions"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Module Admin Special Title
                        </td>
                        <td class="Control-en">
                            Arabic
                            <asp:TextBox MaxLength="64" ID="txtModuleAdminSpecialTitleArabic" runat="server"
                                CssClass="Controls-en" ValidationGroup="UsersDataGlobalOptions"></asp:TextBox>
                            English
                            <asp:TextBox MaxLength="64" ID="txtModuleAdminSpecialTitleEnglish" runat="server"
                                CssClass="Controls-en" ValidationGroup="UsersDataGlobalOptions"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Add In Admin Menu Autmaticly
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbAddInAdminMenuAutmaticly" CssClass="Controls-en" runat="server"
                                ValidationGroup="UsersDataGlobalOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Desplay Categories InAdmin Menu
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbDisplayCategoriesInAdminMenue" CssClass="Controls-en" runat="server"
                                ValidationGroup="UsersDataGlobalOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            ResourceFile
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="32" ID="txtResourceFile" runat="server" CssClass="Controls-en"
                                ValidationGroup="UsersDataGlobalOptions"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            DefaultResourceFile
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="32" ID="txtDefaultResourceFile" runat="server" CssClass="Controls-en"
                                ValidationGroup="UsersDataGlobalOptions"></asp:TextBox>
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
                            AutomaticApproved
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbAutomaticApproved" CssClass="Controls-en" runat="server" ValidationGroup="UsersDataGlobalOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Module RelatedPageID
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="9" ID="txtModuleRelatedPageID" runat="server" CssClass="Controls-en"
                                ValidationGroup="UsersDataGlobalOptions"></asp:TextBox>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="revModuleRelatedPageID" runat="server"
                                ControlToValidate="txtModuleRelatedPageID" ErrorMessage="" Text="<%$ Resources:AdminText,InvalidNumericalData %>"
                                ValidationGroup="UsersDataGlobalOptions" ValidationExpression="^-?\d*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            HasOwnerID
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasOwnerID" CssClass="Controls-en" runat="server" ValidationGroup="UsersDataGlobalOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            HasProfilePage
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasProfilePage" CssClass="Controls-en" runat="server" ValidationGroup="UsersDataGlobalOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Enable Export Data
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasExportData" CssClass="Controls-en" runat="server" ValidationGroup="UsersDataGlobalOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            ListID
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="64" ID="txtListID" runat="server" CssClass="SmallControls"
                                ValidationGroup="UsersDataGlobalOptions"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            ⁄œœ ⁄‰«’— ’›Õ… «·„ÊœÌÊ·
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="64" ID="txtPageItemCount_UserDefault" runat="server" CssClass="SmallControls"
                                ValidationGroup="UsersDataGlobalOptions"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            ⁄œœ ⁄‰«’— ’›Õ… «·√œ„‰
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="64" ID="txtPageItemCount_AdminDefault" runat="server" CssClass="SmallControls"
                                ValidationGroup="UsersDataGlobalOptions"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Show in Site Departments
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbShowInSiteDepartments" CssClass="Controls-en" runat="server"
                                ValidationGroup="UsersDataGlobalOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            «·”„«Õ »«·»ÕÀ œ«Œ· «·„ÊœÌÊ·
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasSearch" CssClass="Controls-en" runat="server" ValidationGroup="UsersDataGlobalOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            ≈„ﬂ«‰Ì… «· ÕÊÌ· ·≈” ‘«—Ì
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasIsConsultant" CssClass="Controls-en" runat="server" ValidationGroup="UsersDataGlobalOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Has Profile
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasProfile" CssClass="Controls-en" runat="server" ValidationGroup="UsersDataGlobalOptions">
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
                            Module Meta KeyWords
                        </td>
                        <td class="Control-en">
                            <asp:TextBox ID="txtModuleMetaKeyWords" TextMode="MultiLine" Width="450" runat="server"
                                CssClass="Controls-en" ValidationGroup="UsersDataGlobalOptions"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Module Meta Description
                        </td>
                        <td class="Control-en">
                            <asp:TextBox ID="txtModuleMetaDescription" TextMode="MultiLine" Width="450" runat="server"
                                CssClass="Controls-en" ValidationGroup="UsersDataGlobalOptions"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Has Meta KeyWords
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasMetaKeyWords" CssClass="Controls-en" runat="server" ValidationGroup="UsersDataGlobalOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Has Meta Description
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasMetaDescription" CssClass="Controls-en" runat="server" ValidationGroup="UsersDataGlobalOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            User Can Send Meta
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbUserCanSendMeta" CssClass="Controls-en" runat="server" ValidationGroup="UsersDataGlobalOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="items_vontents_footer">
            </div>
        </div>
        <div class="menuheader expandable">
            ≈⁄œ«œ«  «·„Ê«ﬁ⁄ «·›—⁄Ì…
        </div>
        <div class="categoryitems">
            <div class="items_contents_body">
                <table class='elssubcontainer' cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="Text-en">
                           HasSiteTitle
                        </td>
                        <td class="Control-en">
                             <asp:CheckBox ID="cbHasSiteTitle" CssClass="Controls-en" runat="server" ValidationGroup="UsersDataGlobalOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            HasSkinID
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasSkinID" CssClass="Controls-en" runat="server" ValidationGroup="UsersDataGlobalOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                           HasVisitorsCount
                        </td>
                        <td class="Control-en">
                           <asp:CheckBox ID="cbHasVisitorsCount" CssClass="Controls-en" runat="server" ValidationGroup="UsersDataGlobalOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            HasSiteModules
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasSiteModules" CssClass="Controls-en" runat="server" ValidationGroup="UsersDataGlobalOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            HasSiteStaticPages
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasSiteStaticPages" CssClass="Controls-en" runat="server" ValidationGroup="UsersDataGlobalOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="items_vontents_footer">
            </div>
        </div>
        <div class="menuheader expandable">
            «· ’‰Ì›« 
        </div>
        <div class="categoryitems">
            <div class="items_contents_body">
                <table class='elssubcontainer' cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="Text-en">
                            Category Level
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="9" ID="txtCategoryLevel" runat="server" CssClass="Controls-en"
                                ValidationGroup="UsersDataGlobalOptions"></asp:TextBox>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="revCategoryLevel" runat="server"
                                ControlToValidate="txtCategoryLevel" ErrorMessage="" Text="<%$ Resources:AdminText,InvalidNumericalData %>"
                                ValidationGroup="UsersDataGlobalOptions" ValidationExpression="^-?\d*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            CanUserAssignHimSelfToCategory
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbCanUserAssignHimSelfToCategory" CssClass="Controls-en" runat="server"
                                ValidationGroup="UsersDataGlobalOptions"></asp:CheckBox>
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
                            Name
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasName" CssClass="Controls-en" runat="server" ValidationGroup="UsersDataGlobalOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredName" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="UsersDataGlobalOptions"></asp:CheckBox>
                            <asp:CheckBox ID="cbNameSeprated" Text="Seprated" CssClass="Controls-en" runat="server"
                                ValidationGroup="UsersDataGlobalOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Country
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasCountryID" CssClass="Controls-en" runat="server" ValidationGroup="UsersDataGlobalOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredCountryID" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="UsersDataGlobalOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            NationalityID
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasNationalityID" CssClass="Controls-en" runat="server" ValidationGroup="UsersDataGlobalOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredNationalityID" CssClass="Controls-en" Text="Required"
                                runat="server" ValidationGroup="UsersDataGlobalOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            CityID
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasCityID" CssClass="Controls-en" runat="server" ValidationGroup="UsersDataGlobalOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredCityID" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="UsersDataGlobalOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            City Name Text
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasUserCityName" CssClass="Controls-en" runat="server" ValidationGroup="UsersDataGlobalOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredUserCityName" CssClass="Controls-en" Text="Required"
                                runat="server" ValidationGroup="UsersDataGlobalOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Birth Date
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasBirthDate" CssClass="Controls-en" runat="server" ValidationGroup="UsersDataGlobalOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredBirthDate" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="UsersDataGlobalOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Gender
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasGender" CssClass="Controls-en" runat="server" ValidationGroup="UsersDataGlobalOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredGender" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="UsersDataGlobalOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Tel
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasTel" CssClass="Controls-en" runat="server" ValidationGroup="UsersDataGlobalOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredTel" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="UsersDataGlobalOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Mobile
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasMobile" CssClass="Controls-en" runat="server" ValidationGroup="UsersDataGlobalOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredMobile" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="UsersDataGlobalOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Fax
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasFax" CssClass="Controls-en" runat="server" ValidationGroup="UsersDataGlobalOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredFax" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="UsersDataGlobalOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Mail Box
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasMailBox" CssClass="Controls-en" runat="server" ValidationGroup="UsersDataGlobalOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredMailBox" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="UsersDataGlobalOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Zip Code
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasZipCode" CssClass="Controls-en" runat="server" ValidationGroup="UsersDataGlobalOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredZipCode" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="UsersDataGlobalOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Url
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasUrl" CssClass="Controls-en" runat="server" ValidationGroup="UsersDataGlobalOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredUrl" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="UsersDataGlobalOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Age Rang
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasAgeRang" CssClass="Controls-en" runat="server" ValidationGroup="UsersDataGlobalOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredAgeRang" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="UsersDataGlobalOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Education Level
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasEducationLevel" CssClass="Controls-en" runat="server" ValidationGroup="UsersDataGlobalOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredEducationLevel" CssClass="Controls-en" Text="Required"
                                runat="server" ValidationGroup="UsersDataGlobalOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Social Status
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasSocialStatus" CssClass="Controls-en" runat="server" ValidationGroup="UsersDataGlobalOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredSocialStatus" CssClass="Controls-en" Text="Required"
                                runat="server" ValidationGroup="UsersDataGlobalOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Notes1
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasNotes1" CssClass="Controls-en" runat="server" ValidationGroup="UsersDataGlobalOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredNotes1" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="UsersDataGlobalOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Notes2
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasNotes2" CssClass="Controls-en" runat="server" ValidationGroup="UsersDataGlobalOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredNotes2" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="UsersDataGlobalOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Photo
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasPhotoExtension" CssClass="Controls-en" runat="server" ValidationGroup="UsersDataGlobalOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredPhotoExtension" CssClass="Controls-en" Text="Required"
                                runat="server" ValidationGroup="UsersDataGlobalOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Available Extension
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="128" ID="txtPhotoAvailableExtension" runat="server" CssClass="Controls-en"
                                ValidationGroup="UsersDataGlobalOptions"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Photo Max Size
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="9" ID="txtPhotoMaxSize" runat="server" CssClass="Controls-en"
                                ValidationGroup="UsersDataGlobalOptions"></asp:TextBox>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="revPhotoMaxSize" runat="server"
                                ControlToValidate="txtPhotoMaxSize" ErrorMessage="" Text="<%$ Resources:AdminText,InvalidNumericalData %>"
                                ValidationGroup="UsersDataGlobalOptions" ValidationExpression="^-?\d*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            ExtraDataCount
                        </td>
                        <td class="Control-en">
                            <asp:DropDownList ID="ddlExtraDataCount" runat="server" ValidationGroup="UsersDataGlobalOptions">
                                <asp:ListItem Text="≈Œ —" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                <asp:ListItem Text="6" Value="6"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:CheckBox ID="cbRequiredExtraData1" CssClass="Controls-en" Text="Extra1 Required"
                                runat="server" ValidationGroup="UsersDataGlobalOptions"></asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredExtraData2" CssClass="Controls-en" Text="Extra2 Required"
                                runat="server" ValidationGroup="UsersDataGlobalOptions"></asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredExtraData3" CssClass="Controls-en" Text="Extra3 Required"
                                runat="server" ValidationGroup="UsersDataGlobalOptions"></asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredExtraData4" CssClass="Controls-en" Text="Extra4 Required"
                                runat="server" ValidationGroup="UsersDataGlobalOptions"></asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredExtraData5" CssClass="Controls-en" Text="Extra5 Required"
                                runat="server" ValidationGroup="UsersDataGlobalOptions"></asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredExtraData6" CssClass="Controls-en" Text="Extra6 Required"
                                runat="server" ValidationGroup="UsersDataGlobalOptions"></asp:CheckBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="items_vontents_footer">
            </div>
        </div>
        <div class="menuheader expandable">
            «·»Ì«‰«  «·ÊŸÌ›Ì…
        </div>
        <div class="categoryitems">
            <div class="items_contents_body">
                <table class='elssubcontainer' cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="Text-en">
                            Company
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasCompany" CssClass="Controls-en" runat="server" ValidationGroup="UsersDataGlobalOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredCompany" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="UsersDataGlobalOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Activities ID
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasActivitiesID" CssClass="Controls-en" runat="server" ValidationGroup="UsersDataGlobalOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredActivitiesID" CssClass="Controls-en" Text="Required"
                                runat="server" ValidationGroup="UsersDataGlobalOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Job ID
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasJobID" CssClass="Controls-en" runat="server" ValidationGroup="UsersDataGlobalOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredJobID" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="UsersDataGlobalOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Job Text
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasJobText" CssClass="Controls-en" runat="server" ValidationGroup="UsersDataGlobalOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredJobText" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="UsersDataGlobalOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Emp No
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasEmpNo" CssClass="Controls-en" runat="server" ValidationGroup="UsersDataGlobalOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredEmpNo" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="UsersDataGlobalOptions"></asp:CheckBox>
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
                            Has Email Service
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasHasEmailService" CssClass="Controls-en" runat="server" ValidationGroup="UsersDataGlobalOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Automatic Registration
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbMailListAutomaticRegistration" CssClass="Controls-en" runat="server"
                                ValidationGroup="UsersDataGlobalOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Sending Mail Activation
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbMailListSendingMailActivation" CssClass="Controls-en" runat="server"
                                ValidationGroup="UsersDataGlobalOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Automatic Activation
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbMailListAutomaticActivation" CssClass="Controls-en" runat="server"
                                ValidationGroup="UsersDataGlobalOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Sending Acount Data InActivation Mail
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbSendingAcountDataInActivationMail" CssClass="Controls-en" runat="server"
                                ValidationGroup="UsersDataGlobalOptions"></asp:CheckBox>
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
                            Has Sms Service
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasHasSmsService" CssClass="Controls-en" runat="server" ValidationGroup="UsersDataGlobalOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Automatic Registration
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbSmsAutomaticRegistration" CssClass="Controls-en" runat="server"
                                ValidationGroup="UsersDataGlobalOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Sending Sms Activation
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbSmsSendingSmsActivation" CssClass="Controls-en" runat="server"
                                ValidationGroup="UsersDataGlobalOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Automatic Activation
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbSmsAutomaticActivation" CssClass="Controls-en" runat="server"
                                ValidationGroup="UsersDataGlobalOptions"></asp:CheckBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="items_vontents_footer">
            </div>
        </div>
        <div style="">
            <asp:Button ID="btnSave" runat="server" ValidationGroup="UsersDataGlobalOptions"
                OnClick="btnSave_Click" SkinID="btnSave" /></div>
</asp:Content>
