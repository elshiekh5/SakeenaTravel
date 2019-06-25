<%@ Page Language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="Save.aspx.cs"
    Inherits="AdminMessagesModuleOptions_Create" %>

<%@ Register src="../UC_ModulesGuide.ascx" tagname="UC_ModulesGuide" tagprefix="uc1" %>

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
                            <uc1:UC_ModulesGuide ID="UC_ModulesGuide1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Identifire
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="64" ID="txtIdentifire" runat="server" CssClass="Controls-en"
                                ValidationGroup="MessagesModuleOptions"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvIdentifire" ControlToValidate="txtIdentifire"
                                ValidationGroup="MessagesModuleOptions" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            ModuleTypeID
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="11" ID="txtModuleTypeID" runat="server" CssClass="Controls-en"
                                ValidationGroup="MessagesModuleOptions"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvModuleTypeID" ControlToValidate="txtModuleTypeID"
                                ValidationGroup="MessagesModuleOptions" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="RegularExpressionValidator1"
                                runat="server" ControlToValidate="txtModuleTypeID" ErrorMessage="" Text="<%$ Resources:AdminText,InvalidNumericalData %>"
                                ValidationGroup="MessagesModuleOptions" ValidationExpression="\d*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            ModuleType
                        </td>
                        <td class="Control-en">
                            <asp:DropDownList ID="ddlModuleType" runat="server" CssClass="Controls-en" ValidationGroup="MessagesModuleOptions">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Resource File
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="32" ID="txtResourceFile" runat="server" CssClass="Controls-en"
                                ValidationGroup="MessagesModuleOptions"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Default Resource File
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="32" ID="txtDefaultResourceFile" runat="server" CssClass="Controls-en"
                                ValidationGroup="MessagesModuleOptions"></asp:TextBox>
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
                                ValidationGroup="MessagesModuleOptions"></asp:TextBox>
                            English
                            <asp:TextBox MaxLength="64" ID="txtModuleTitleEnglish" runat="server" CssClass="Controls-en"
                                ValidationGroup="MessagesModuleOptions"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Module Admin Special Title
                        </td>
                        <td class="Control-en">
                            Arabic
                            <asp:TextBox MaxLength="64" ID="txtModuleAdminSpecialTitleArabic" runat="server"
                                CssClass="Controls-en" ValidationGroup="MessagesModuleOptions"></asp:TextBox>
                            English
                            <asp:TextBox MaxLength="64" ID="txtModuleAdminSpecialTitleEnglish" runat="server"
                                CssClass="Controls-en" ValidationGroup="MessagesModuleOptions"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Add In Admin Menu Autmaticly
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbAddInAdminMenuAutmaticly" CssClass="Controls-en" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Desplay Categories InAdmin Menu
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbDisplayCategoriesInAdminMenue" CssClass="Controls-en" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Module RelatedPageID
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="9" ID="txtModuleRelatedPageID" runat="server" CssClass="Controls-en"
                                ValidationGroup="MessagesModuleOptions"></asp:TextBox>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="revModuleRelatedPageID" runat="server"
                                ControlToValidate="txtModuleRelatedPageID" ErrorMessage="" Text="<%$ Resources:AdminText,InvalidNumericalData %>"
                                ValidationGroup="MessagesModuleOptions" ValidationExpression="^-?\d*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Has Owen Folder
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasOwenFolder_User" Text="User" CssClass="Controls-en" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                            <asp:CheckBox ID="cbHasOwenFolder_Admin" Text="Admin" CssClass="Controls-en" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>

                    <tr>
                        <td class="Text-en">
                           Module Special Path
                        </td>
                        <td class="Control-en">
                            <asp:TextBox  ID="txtModuleSpecialPath" runat="server" CssClass="Controls"
                                ValidationGroup="MessagesModuleOptions"></asp:TextBox>

                        </td>
                    </tr>

                    <tr>
                        <td class="Text-en">
                            Users only can send
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbSendingOnlyByUsers" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Enable Export Data
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasExportData" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            ListID
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="64" ID="txtListID" runat="server" CssClass="SmallControls"
                                ValidationGroup="MessagesModuleOptions"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            List Has Date
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbListHasDate" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Admin Note
                        </td>
                        <td class="Control-en">
                            <asp:TextBox ID="txtAdminNote" runat="server" CssClass="Controls-en" ValidationGroup="MessagesModuleOptions"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            HasOwnerID
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasOwnerID" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            ⁄œœ ⁄‰«’— ’›Õ… «·„ÊœÌÊ·
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="64" ID="txtPageItemCount_UserDefault" runat="server" CssClass="SmallControls"
                                ValidationGroup="MessagesModuleOptions"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            ⁄œœ ⁄‰«’— ’›Õ… «·√œ„‰
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="64" ID="txtPageItemCount_AdminDefault" runat="server" CssClass="SmallControls"
                                ValidationGroup="MessagesModuleOptions"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Show in Site Departments
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbShowInSiteDepartments" CssClass="Controls-en" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                             — Ì» «·⁄‰«’—
                        </td>
                        <td class="Control-en">
                            <asp:TextBox ID="txtTableRowsPriorities" runat="server" CssClass="SmallControls"
                                ValidationGroup="MessagesModuleOptions"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                           «·”„«Õ »«·»ÕÀ œ«Œ· «·„ÊœÌÊ·
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasSearch" CssClass="Controls-en" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
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
                                ValidationGroup="MessagesModuleOptions"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Module Meta Description
                        </td>
                        <td class="Control-en">
                            <asp:TextBox ID="txtModuleMetaDescription" TextMode="MultiLine" Width="450" runat="server" CssClass="Controls-en"
                                ValidationGroup="MessagesModuleOptions"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Has Meta KeyWords
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasMetaKeyWords" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Has Meta Description
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasMetaDescription" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            User Can Send Meta
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbUserCanSendMeta" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
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
                            Category Level
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="9" ID="txtCategoryLevel" runat="server" CssClass="Controls-en"
                                ValidationGroup="MessagesModuleOptions"></asp:TextBox>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="revCategoryLevel" runat="server"
                                ControlToValidate="txtCategoryLevel" ErrorMessage="" Text="<%$ Resources:AdminText,InvalidNumericalData %>"
                                ValidationGroup="MessagesModuleOptions" ValidationExpression="^-?\d*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Name
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasName" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredName" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                            <asp:CheckBox ID="cbNameSeprated" Text="Seprated" CssClass="Controls-en" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            EMail
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasEMail" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredEMail" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            CountryID
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasCountryID" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredCountryID" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            NationalityID
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasNationalityID" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredNationalityID" CssClass="Controls-en" Text="Required"
                                runat="server" ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            CityID
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasCityID" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredCityID" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            City Name Text
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasUserCityName" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredUserCityName" CssClass="Controls-en" Text="Required"
                                runat="server" ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Tel
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasTel" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredTel" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Mobile
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasMobile" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredMobile" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Fax
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasFax" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredFax" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            MailBox
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasMailBox" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredMailBox" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            ZipCode
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasZipCode" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredZipCode" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Url
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasUrl" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredUrl" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Address
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasAddress" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredAddress" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Birth Date
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasBirthDate" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredBirthDate" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Gender
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasGender" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredGender" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Age Rang
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasAgeRang" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredAgeRang" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Education Level
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasEducationLevel" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredEducationLevel" CssClass="Controls-en" Text="Required"
                                runat="server" ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Social Status
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasSocialStatus" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredSocialStatus" CssClass="Controls-en" Text="Required"
                                runat="server" ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
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
                                        <asp:CheckBox ID="cbHasType" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                                        </asp:CheckBox>
                                        <asp:CheckBox ID="cbRequiredType" CssClass="Controls-en" Text="Required" runat="server"
                                            ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                                    </td>
                                    <td>
                                        Types Count
                                    </td>
                                    <td>
                                        <asp:TextBox MaxLength="9" ID="txtTypesCount" runat="server" CssClass="Controls-en"
                                            ValidationGroup="MessagesModuleOptions"></asp:TextBox>
                                        <asp:RegularExpressionValidator Display="Dynamic" ID="revTypesCount" runat="server"
                                            ControlToValidate="txtTypesCount" ErrorMessage="" Text="<%$ Resources:AdminText,InvalidNumericalData %>"
                                            ValidationGroup="MessagesModuleOptions" ValidationExpression="^-?\d*"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Title
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasTitle" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredTitle" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Details
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasDetails" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredDetails" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                            <asp:CheckBox ID="cbDetailsInHtmlEditor" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions"
                                Text="HtmlEditor"></asp:CheckBox>
                            <asp:CheckBox ID="cbDetailsAllowHtmlEditorForUser" CssClass="Controls-en" Text="Html Editor For User"
                                runat="server" ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            HasGoogleLatitude
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasGoogleLatitude" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredGoogleLatitude" CssClass="Controls-en" Text="Required"
                                runat="server" ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            HasGoogleLongitude
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasGoogleLongitude" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredGoogleLongitude" CssClass="Controls-en" Text="Required"
                                runat="server" ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            HasPrice
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasPrice" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredPrice" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            HasOnlyForRegisered
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasOnlyForRegisered" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="items_vontents_footer">
            </div>
        </div>
        <div class="menuheader expandable">
            ⁄‰«’— „ ﬁœ„…
        </div>
        <div class="categoryitems">
            <div class="items_contents_body">
                <table class='elssubcontainer' cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="Text-en">
                            UserId
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasUserId" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            To Item
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasToItemID" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredToItemID" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Enable Send Mail To Item
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbEnableSendMailToItem" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            To Item Module Type
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="9" ID="txtToItemModuleType" runat="server" CssClass="Controls-en"
                                ValidationGroup="MessagesModuleOptions"></asp:TextBox>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="revToItemModuleType" runat="server"
                                ControlToValidate="txtToItemModuleType" ErrorMessage="" Text="<%$ Resources:AdminText,InvalidNumericalData %>"
                                ValidationGroup="MessagesModuleOptions" ValidationExpression="^-?\d*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="items_vontents_footer">
            </div>
        </div>
        <div class="menuheader expandable">
            »Ì«‰«  ÊŸÌ›Ì…
        </div>
        <div class="categoryitems">
            <div class="items_contents_body">
                <table class='elssubcontainer' cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="Text-en">
                            HasCompany
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasCompany" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredCompany" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            HasActivitiesID
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasActivitiesID" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredActivitiesID" CssClass="Controls-en" Text="Required"
                                runat="server" ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            HasJobID
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasJobID" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredJobID" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            HasJobText
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasJobText" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredJobText" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Emp No
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasEmpNo" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredEmpNo" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Job Tel
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasJobTel" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredJobTel" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="items_vontents_footer">
            </div>
        </div>
        <div class="menuheader expandable">
            »Ì«‰«  «·„·›«  Ê«·„—›ﬁ« 
        </div>
        <div class="categoryitems">
            <div class="items_contents_body">
                <table class='elssubcontainer' cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="Text-en">
                            HasPhotoExtension
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasPhotoExtension" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredPhotoExtension" CssClass="Controls-en" Text="Required"
                                runat="server" ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                            <asp:CheckBox ID="cbHasPublishPhoto" CssClass="Controls-en" Text="HasPublish" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            PhotoAvailableExtension
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="128" ID="txtPhotoAvailableExtension" runat="server" CssClass="Controls-en"
                                ValidationGroup="MessagesModuleOptions"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            PhotoMaxSize
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="9" ID="txtPhotoMaxSize" runat="server" CssClass="Controls-en"
                                ValidationGroup="MessagesModuleOptions"></asp:TextBox>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="revPhotoMaxSize" runat="server"
                                ControlToValidate="txtPhotoMaxSize" ErrorMessage="" Text="<%$ Resources:AdminText,InvalidNumericalData %>"
                                ValidationGroup="MessagesModuleOptions" ValidationExpression="^-?\d*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            HasFileExtension
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasFileExtension" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredFile" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            FileAvailableExtension
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="128" ID="txtFileAvailableExtension" runat="server" CssClass="Controls-en"
                                ValidationGroup="MessagesModuleOptions"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            FileMaxSize
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="9" ID="txtFileMaxSize" runat="server" CssClass="Controls-en"
                                ValidationGroup="MessagesModuleOptions"></asp:TextBox>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="revFileMaxSize" runat="server"
                                ControlToValidate="txtFileMaxSize" ErrorMessage="" Text="<%$ Resources:AdminText,InvalidNumericalData %>"
                                ValidationGroup="MessagesModuleOptions" ValidationExpression="^-?\d*"></asp:RegularExpressionValidator>
                            <asp:CheckBox ID="cbHasPublishFile" CssClass="Controls-en" Text="HasPublish" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Height
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasHeight" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredHeight" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Width
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasWidth" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredWidth" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Youtube Code
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasYoutubeCode" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredYoutubeCode" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                            <asp:CheckBox ID="cbHasPublishYoutbe" CssClass="Controls-en" Text="HasPublish" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Video
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasVideoExtension" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredVideo" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                            <asp:CheckBox ID="cbHasPublishVideo" CssClass="Controls-en" Text="HasPublish" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Video Available Extension
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="128" ID="txtVideoAvailableExtension" runat="server" CssClass="Controls-en"
                                ValidationGroup="MessagesModuleOptions"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Video Max Size
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="9" ID="txtVideoMaxSize" runat="server" CssClass="Controls-en"
                                ValidationGroup="MessagesModuleOptions"></asp:TextBox>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="revVideoMaxSize" runat="server"
                                ControlToValidate="txtVideoMaxSize" ErrorMessage="" Text="<%$ Resources:AdminText,InvalidNumericalData %>"
                                ValidationGroup="MessagesModuleOptions" ValidationExpression="^-?\d*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Audio
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasAudioExtension" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredAudio" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                            <asp:CheckBox ID="cbHasPublishAudio" CssClass="Controls-en" Text="HasPublish" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Audio Available Extension
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="128" ID="txtAudioAvailableExtension" runat="server" CssClass="Controls-en"
                                ValidationGroup="MessagesModuleOptions"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Audio MaxSize
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="9" ID="txtAudioMaxSize" runat="server" CssClass="Controls-en"
                                ValidationGroup="MessagesModuleOptions"></asp:TextBox>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="revAudioMaxSize" runat="server"
                                ControlToValidate="txtAudioMaxSize" ErrorMessage="" Text="<%$ Resources:AdminText,InvalidNumericalData %>"
                                ValidationGroup="MessagesModuleOptions" ValidationExpression="^-?\d*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Photo2
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasPhoto2Extension" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredPhoto2" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                            <asp:CheckBox ID="cbHasPublishPhoto2" CssClass="Controls-en" Text="HasPublish" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Photo2 Available Extension
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="128" ID="txtPhoto2AvailableExtension" runat="server" CssClass="Controls-en"
                                ValidationGroup="MessagesModuleOptions"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Photo2 Max Size
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="9" ID="txtPhoto2MaxSize" runat="server" CssClass="Controls-en"
                                ValidationGroup="MessagesModuleOptions"></asp:TextBox>
                            <asp:RegularExpressionValidator Display="Dynamic" ID="revPhoto2MaxSize" runat="server"
                                ControlToValidate="txtPhoto2MaxSize" ErrorMessage="" Text="<%$ Resources:AdminText,InvalidNumericalData %>"
                                ValidationGroup="MessagesModuleOptions" ValidationExpression="^-?\d*"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="items_vontents_footer">
            </div>
        </div>
        <div class="menuheader expandable">
            »Ì«‰«  «·≈‘—«›
        </div>
        <div class="categoryitems">
            <div class="items_contents_body">
                <table class='elssubcontainer' cellspacing="0" cellpadding="0" border="0">
                    <tr>
                        <td class="Text-en">
                            Short Description
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasShortDescription" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredShortDescription" CssClass="Controls-en" Text="Required"
                                runat="server" ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                            <asp:CheckBox ID="cbHasShortDescriptionInDetailsPage" CssClass="Controls-en" Text="ShortDescriptionInDetailsPage"
                                runat="server" ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                            <asp:CheckBox ID="cbShortDescriptionAllowToUser" CssClass="Controls-en" Text="Allow To User"
                                runat="server" ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Reply
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasReply" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredReply" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                            <asp:CheckBox ID="cbReplyInHtmlEditor" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions"
                                Text="ReplyInHtmlEditor"></asp:CheckBox>
                        </td>
                    </tr>
                     <tr>
                        <td class="Text-en">
                            Has Attachments In Reply
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasAttachmentsInReplay" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                           
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Item Date
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasItemDate" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredItemDate" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Date_Added
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasDate_Added" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Is Main
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasIsMain" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Priority
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasPriority" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            IsAvailable
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasIsAvailable" Checked="true" CssClass="Controls-en" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Redirect To Member
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasRedirectToMember" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Member Role (send to ddl)
                        </td>
                        <td class="Control-en">
                            <asp:TextBox MaxLength="64" ID="txtMemberRole" runat="server" CssClass="Controls-en"
                                ValidationGroup="MessagesModuleOptions"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            HasNotes1
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasNotes1" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredNotes1" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            HasNotes2
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasNotes2" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                            <asp:CheckBox ID="cbRequiredNotes2" CssClass="Controls-en" Text="Required" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
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
                            <asp:CheckBox ID="cbHasVisitiesCount" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Print
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasPrint" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Tel A Friend
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasTelFriend" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Save As Document
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasSaveAsDocument" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Comments
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasComments" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Share
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasShare" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            RSS
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasRSS" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Rating
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasRating" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
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
                            HasHasEmailService
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbHasHasEmailService" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            MailListAutomaticRegistration
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbMailListAutomaticRegistration" CssClass="Controls-en" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            MailListSendingMailActivation
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbMailListSendingMailActivation" CssClass="Controls-en" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            MailListAutomaticActivation
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbMailListAutomaticActivation" CssClass="Controls-en" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
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
                            <asp:CheckBox ID="cbHasHasSmsService" CssClass="Controls-en" runat="server" ValidationGroup="MessagesModuleOptions">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Automatic Registration
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbSmsAutomaticRegistration" CssClass="Controls-en" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Sending Sms Activation
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbSmsSendingSmsActivation" CssClass="Controls-en" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="Text-en">
                            Automatic Activation
                        </td>
                        <td class="Control-en">
                            <asp:CheckBox ID="cbSmsAutomaticActivation" CssClass="Controls-en" runat="server"
                                ValidationGroup="MessagesModuleOptions"></asp:CheckBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="items_vontents_footer">
            </div>
        </div>
    </div>
    <div style="">
        <asp:Button ID="btnSave" runat="server" ValidationGroup="MessagesModuleOptions" OnClick="btnSave_Click"
            SkinID="btnSave" /></div>
</asp:Content>
