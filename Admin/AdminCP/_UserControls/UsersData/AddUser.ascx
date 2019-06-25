<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddUser.ascx.cs" Inherits="UserControls_UsersData_AddUser" %>
<%@ Register Src="../Date.ascx" TagName="Date" TagPrefix="uc1" %>
<%@ Register Src="../HijriDate.ascx" TagName="HijriDate" TagPrefix="uc2" %>
<table class="MainTable" cellspacing="0" cellpadding="0" border="0" width="100%">
    <tr>
        <td align="center" class="result" colspan="1">
            <asp:Label ID="lblResult" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <table runat="server" id="tblControls" class="SubTable" cellspacing="0" cellpadding="0"
                border="0" width="100%">
                <tr id="trUserName" runat="server">
                    <td class="text">
                        <asp:Label ID="lblUserName" Text="<%$ Resources:MemberShip,UserName %>" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="128" ID="txtUserName" runat="server" CssClass="Controls"
                            ValidationGroup="UsersData"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvUserName"
                            runat="server" ErrorMessage="<%$ Resources:User,RequiredField %>" ControlToValidate="txtUserName"
                            ValidationGroup="UsersData" Text="<%$ Resources:User,RequiredField %>"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trPassword" runat="server">
                    <td class="text">
                        <asp:Label ID="lblPassword" Text="<%$ Resources:MemberShip,Password %>" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="128" ID="txtPassword" runat="server" CssClass="Controls"
                            ValidationGroup="UsersData" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvPassword"
                            runat="server" ErrorMessage="<%$ Resources:User,RequiredField %>" ControlToValidate="txtPassword"
                            ValidationGroup="UsersData" Text="<%$ Resources:User,RequiredField %>"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trConfirmPassword" runat="server">
                    <td class="text">
                        <asp:Label ID="lblConfirmPassword" Text="<%$ Resources:MemberShip,ConfirmPassword %>"
                            runat="server" />
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="128" ID="txtConfirmPassword" runat="server" CssClass="Controls"
                            ValidationGroup="UsersData" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvConfirmPassword"
                            runat="server" ErrorMessage="<%$ Resources:User,RequiredField %>" ControlToValidate="txtConfirmPassword"
                            ValidationGroup="UsersData" Text="<%$ Resources:User,RequiredField %>"></asp:RequiredFieldValidator>
                        <asp:CompareValidator CssClass="ourvalidation" ID="CompareValidator1" runat="server"
                            ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ErrorMessage="<%$ Resources:MemberShip,ConfirmPasswordError %>"
                            ValidationGroup="UsersData" Display="Dynamic"></asp:CompareValidator>
                    </td>
                </tr>
                <tr id="trEmail" runat="server">
                    <td class="text">
                        <asp:Label ID="lblEmail" Text="<%$ Resources:MemberShip,Email %>" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="128" ID="txtEmail" runat="server" CssClass="Controls" ValidationGroup="UsersData"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvEmail"
                            runat="server" ErrorMessage="<%$ Resources:User,RequiredField %>" ControlToValidate="txtEmail"
                            ValidationGroup="UsersData" Text="<%$ Resources:User,RequiredField %>"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator CssClass="ourvalidation" ID="RegularExpressionValidator1"
                            runat="server" ControlToValidate="txtEmail" ErrorMessage="<%$ Resources:MemberShip,InvalidEmail %>"
                            ValidationExpression="^([\w\-\.]+)@((\[([0-9]{1,3}\.){3}[0-9]{1,3}\])|(([\w\-]+\.)+)([a-zA-Z]{2,4}))$" ValidationGroup="UsersData"
                            Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <%--                <tr id="trConfirmEmail" runat="server">
                    <td class="text">
                        <asp:Label ID="lblConfirmEmail" Text="<%$ Resources:MemberShip,ConfirmEmail %>" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="128" ID="txtConfirmEmail" runat="server" CssClass="Controls"
                            ValidationGroup="UsersData"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="ourvalidation"  Display="Dynamic" ID="rfvConfirmEmail" runat="server"
                            ErrorMessage="<%$ Resources:User,RequiredField %>" ControlToValidate="txtConfirmEmail"
                            ValidationGroup="UsersData" Text="<%$ Resources:User,RequiredField %>"></asp:RequiredFieldValidator>
                        <asp:CompareValidator CssClass="ourvalidation"  ID="CompareValidator2" runat="server" ControlToCompare="txtEmail"
                            ControlToValidate="txtConfirmEmail" ErrorMessage="<%$ Resources:MemberShip,ConfirmEmailError %>"
                            ValidationGroup="UsersData" Display="Dynamic"></asp:CompareValidator>
                    </td>
                </tr>--%>
                <tr id="trName" runat="server">
                    <td class="text">
                        <asp:Label ID="lblName" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="128" ID="txtName" runat="server" CssClass="Controls" ValidationGroup="UsersData"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvName"
                            runat="server" ErrorMessage="<%$ Resources:User,RequiredField %>" ControlToValidate="txtName"
                            ValidationGroup="UsersData" Text="<%$ Resources:User,RequiredField %>"></asp:RequiredFieldValidator>
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
                <tr id="trBirthDate" runat="server">
                    <td class="text">
                        <asp:Label ID="lblBirthDate" runat="server" />
                    </td>
                    <td class="Control">
                        <uc1:Date ID="ucDateBirthDate" runat="server" ValidationGroup="UsersData" CssClass="Controls" />
                    </td>
                </tr>
                <tr id="trGender" runat="server">
                    <td class="text">
                        <asp:Label ID="lblGender" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:DropDownList ID="ddlGender" runat="server" CssClass="Controls" ValidationGroup="UsersData">
                            <asp:ListItem Selected="True" Value="-1" Text="<%$ Resources:User,Choose %>"></asp:ListItem>
                            <asp:ListItem Value="1" Text="<%$ Resources:UsersData,Gender_1 %>"></asp:ListItem>
                            <asp:ListItem Value="2" Text="<%$ Resources:UsersData,Gender_2 %>"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvGender"
                            runat="server" ErrorMessage="<%$ Resources:User,RequiredField %>" ControlToValidate="ddlGender"
                            InitialValue="-1" ValidationGroup="UsersData" Text="<%$ Resources:User,RequiredField %>"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                
                <tr id="trJobID" runat="server">
                    <td class="text">
                        <asp:Label ID="lblJobID" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="128" ID="txtJobID" runat="server" CssClass="Controls" ValidationGroup="UsersData"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvJobID"
                            runat="server" ErrorMessage="<%$ Resources:User,RequiredField %>" ControlToValidate="txtJobID"
                            ValidationGroup="UsersData" Text="<%$ Resources:User,RequiredField %>"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trJobText" runat="server">
                    <td class="text">
                        <asp:Label ID="lblJobText" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="128" ID="txtJobText" runat="server" CssClass="Controls" ValidationGroup="UsersData"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvJobText"
                            runat="server" ErrorMessage="<%$ Resources:User,RequiredField %>" ControlToValidate="txtJobText"
                            ValidationGroup="UsersData" Text="<%$ Resources:User,RequiredField %>"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trCompany" runat="server">
                    <td class="text">
                        <asp:Label ID="lblCompany" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="128" ID="txtCompany" runat="server" CssClass="Controls" ValidationGroup="UsersData"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvCompany"
                            runat="server" ErrorMessage="<%$ Resources:User,RequiredField %>" ControlToValidate="txtCompany"
                            ValidationGroup="UsersData" Text="<%$ Resources:User,RequiredField %>"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trEmpNo" runat="server">
                    <td class="text">
                        <asp:Label ID="lblEmpNo" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="8" ID="txtEmpNo" runat="server" CssClass="Controls" ValidationGroup="UsersData"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvEmpNo"
                            runat="server" ErrorMessage="<%$ Resources:User,RequiredField %>" ControlToValidate="txtEmpNo"
                            ValidationGroup="UsersData" Text="<%$ Resources:User,RequiredField %>"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator CssClass="ourvalidation" Display="Dynamic" ID="revDaysCount"
                            runat="server" ControlToValidate="txtEmpNo" ErrorMessage="<%$ Resources:UsersData,EmpNoError %>"
                            ValidationGroup="UsersData" ValidationExpression="\d*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
             
                <tr id="trMailBox" runat="server">
                    <td class="text">
                        <asp:Label ID="lblMailBox" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="128" ID="txtMailBox" runat="server" CssClass="Controls" ValidationGroup="UsersData"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvMailBox"
                            runat="server" ErrorMessage="<%$ Resources:User,RequiredField %>" ControlToValidate="txtMailBox"
                            ValidationGroup="UsersData" Text="<%$ Resources:User,RequiredField %>"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trZipCode" runat="server">
                    <td class="text">
                        <asp:Label ID="lblZipCode" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="128" ID="txtZipCode" runat="server" CssClass="Controls" ValidationGroup="UsersData"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvZipCode"
                            runat="server" ErrorMessage="<%$ Resources:User,RequiredField %>" ControlToValidate="txtZipCode"
                            ValidationGroup="UsersData" Text="<%$ Resources:User,RequiredField %>"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trCountryID" runat="server">
                    <td class="text">
                        <asp:Label ID="lblCountryID" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:DropDownList ID="ddlSystemCountries" runat="server" CssClass="Controls" ValidationGroup="UsersData">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvCountryID"
                            runat="server" ErrorMessage="<%$ Resources:User,RequiredField %>" ControlToValidate="ddlSystemCountries"
                            InitialValue="-1" ValidationGroup="UsersData" Text="<%$ Resources:User,RequiredField %>"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trCityID" runat="server" visible="false">
                    <td class="text">
                        <asp:Label ID="lblCityID" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:DropDownList ID="ddlCities" runat="server" CssClass="Controls" ValidationGroup="UsersData">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Visible="false" Display="Dynamic"
                            ID="rfvCityID" runat="server" ErrorMessage="<%$ Resources:User,RequiredField %>"
                            ControlToValidate="ddlCities" InitialValue="-1" ValidationGroup="UsersData" Text="<%$ Resources:User,RequiredField %>"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trUserCityName" runat="server">
                    <td class="text">
                        <asp:Label ID="lblUserCityName" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="32" ID="txtUserCityName" runat="server" CssClass="Controls"
                            ValidationGroup="UsersData"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Visible="false" Display="Dynamic"
                            ID="rfvUserCityName" runat="server" ErrorMessage="<%$ Resources:User,RequiredField %>"
                            ControlToValidate="txtUserCityName" ValidationGroup="UsersData" Text="<%$ Resources:User,RequiredField %>"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trActivitiesID" runat="server">
                    <td class="text">
                        <asp:Label ID="lblActivitiesID" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:DropDownList ID="ddlActivitiesID" runat="server" CssClass="Controls" ValidationGroup="UsersData">
                            <asp:ListItem Selected="True" Value="-1" Text="<%$ Resources:User,Choose %>"></asp:ListItem>
                            <asp:ListItem Value="1" Text="<%$ Resources:UsersData,ActivitiesID_1 %>"></asp:ListItem>
                            <asp:ListItem Value="2" Text="<%$ Resources:UsersData,ActivitiesID_2 %>"></asp:ListItem>
                            <asp:ListItem Value="3" Text="<%$ Resources:UsersData,ActivitiesID_3 %>"></asp:ListItem>
                            <asp:ListItem Value="4" Text="<%$ Resources:UsersData,ActivitiesID_4 %>"></asp:ListItem>
                            <asp:ListItem Value="5" Text="<%$ Resources:UsersData,ActivitiesID_5 %>"></asp:ListItem>
                            <asp:ListItem Value="6" Text="<%$ Resources:UsersData,ActivitiesID_6 %>"></asp:ListItem>
                            <asp:ListItem Value="7" Text="<%$ Resources:UsersData,ActivitiesID_7 %>"></asp:ListItem>
                            <asp:ListItem Value="8" Text="<%$ Resources:UsersData,ActivitiesID_8 %>"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvActivitiesID"
                            runat="server" ErrorMessage="<%$ Resources:User,RequiredField %>" ControlToValidate="ddlActivitiesID"
                            InitialValue="-1" ValidationGroup="UsersData" Text="<%$ Resources:User,RequiredField %>"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trPhotoExtension" runat="server">
                    <td class="text">
                        <asp:Label ID="lblPhotoExtension" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:FileUpload ID="fuPhoto" runat="server" CssClass="Controls" />
                        <asp:RequiredFieldValidator CssClass="ourvalidation" ValidationGroup="UsersData"
                            ID="rfvPhoto" ControlToValidate="fuPhoto" Display="Dynamic" runat="server" ErrorMessage="<%$ Resources:User,RequiredField %>"
                            Text="<%$ Resources:User,RequiredField %>"></asp:RequiredFieldValidator>
                        <asp:Label ID="lblPhotoAvailableExtension" runat="server"></asp:Label>
                        <asp:RegularExpressionValidator CssClass="ourvalidation" ValidationGroup="UsersData"
                            ID="rxpPhoto" Display="Dynamic" runat="server" ControlToValidate="fuPhoto"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr id="trUrl" runat="server">
                    <td class="text">
                        <asp:Label ID="lblUrl" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="128" ID="txtUrl" runat="server" CssClass="Controls" ValidationGroup="UsersData"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvUrl"
                            runat="server" ErrorMessage="<%$ Resources:User,RequiredField %>" ControlToValidate="txtUrl"
                            ValidationGroup="UsersData" Text="<%$ Resources:User,RequiredField %>"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trTel" runat="server">
                    <td class="text">
                        <asp:Label ID="lblTel" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="13" ID="txtTel" runat="server" CssClass="Controls" ValidationGroup="UsersData"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvTel"
                            runat="server" ErrorMessage="<%$ Resources:User,RequiredField %>" ControlToValidate="txtTel"
                            ValidationGroup="UsersData" Text="<%$ Resources:User,RequiredField %>"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trMobile" runat="server">
                    <td class="text">
                        <asp:Label ID="lblMobile" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="13" ID="txtMobile" runat="server" CssClass="Controls" ValidationGroup="UsersData"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvMobile"
                            runat="server" ErrorMessage="<%$ Resources:User,RequiredField %>" ControlToValidate="txtMobile"
                            ValidationGroup="UsersData" Text="<%$ Resources:User,RequiredField %>"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trFax" runat="server">
                    <td class="text">
                        <asp:Label ID="lblFax" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="128" ID="txtFax" runat="server" CssClass="Controls" ValidationGroup="UsersData"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvFax"
                            runat="server" ErrorMessage="<%$ Resources:User,RequiredField %>" ControlToValidate="txtFax"
                            ValidationGroup="UsersData" Text="<%$ Resources:User,RequiredField %>"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trHasSmsService" runat="server">
                    <td class="text">
                        <asp:Label ID="lblHasSmsService" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:CheckBox ID="cbHasSmsService" runat="server" ValidationGroup="UsersData"></asp:CheckBox>
                    </td>
                </tr>
                <tr id="trHasEmailService" runat="server">
                    <td class="text">
                        <asp:Label ID="lblHasEmailService" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:CheckBox ID="cbHasEmailService" runat="server" ValidationGroup="UsersData">
                        </asp:CheckBox>
                    </td>
                </tr>
                <tr id="trAgeRang" runat="server">
                    <td class="text">
                        <asp:Label ID="lblAgeRang" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:DropDownList ID="ddlAgeRang" runat="server" CssClass="Controls" ValidationGroup="UsersData">
                            <asp:ListItem Selected="True" Value="-1" Text="<%$ Resources:User,Choose %>"></asp:ListItem>
                            <asp:ListItem Value="1" Text="<%$ Resources:UsersData,AgeRang_1 %>"></asp:ListItem>
                            <asp:ListItem Value="2" Text="<%$ Resources:UsersData,AgeRang_2 %>"></asp:ListItem>
                            <asp:ListItem Value="3" Text="<%$ Resources:UsersData,AgeRang_3 %>"></asp:ListItem>
                            <asp:ListItem Value="4" Text="<%$ Resources:UsersData,AgeRang_4 %>"></asp:ListItem>
                            <asp:ListItem Value="5" Text="<%$ Resources:UsersData,AgeRang_5 %>"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvAgeRang"
                            runat="server" ErrorMessage="<%$ Resources:User,RequiredField %>" ControlToValidate="ddlAgeRang"
                            InitialValue="-1" ValidationGroup="UsersData" Text="<%$ Resources:User,RequiredField %>"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trSocialStatus" runat="server">
                    <td class="text">
                        <asp:Label ID="lblSocialStatus" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:DropDownList ID="ddlSocialStatus" runat="server" CssClass="Controls" ValidationGroup="UsersData">
                            <asp:ListItem Selected="True" Value="-1" Text="<%$ Resources:User,Choose %>"></asp:ListItem>
                            <asp:ListItem Value="1" Text="<%$ Resources:UsersData,SocialStatus_1 %>"></asp:ListItem>
                            <asp:ListItem Value="2" Text="<%$ Resources:UsersData,SocialStatus_2 %>"></asp:ListItem>
                            <asp:ListItem Value="3" Text="<%$ Resources:UsersData,SocialStatus_3 %>"></asp:ListItem>
                            <asp:ListItem Value="4" Text="<%$ Resources:UsersData,SocialStatus_4 %>"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvSocialStatus"
                            runat="server" ErrorMessage="<%$ Resources:User,RequiredField %>" ControlToValidate="ddlSocialStatus"
                            InitialValue="-1" ValidationGroup="UsersData" Text="<%$ Resources:User,RequiredField %>"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trEducationLevel" runat="server">
                    <td class="text">
                        <asp:Label ID="lblEducationLevel" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:DropDownList ID="ddlEducationLevel" runat="server" CssClass="Controls" ValidationGroup="UsersData">
                            <asp:ListItem Selected="True" Value="-1" Text="<%$ Resources:User,Choose %>"></asp:ListItem>
                            <asp:ListItem Value="1" Text="<%$ Resources:UsersData,EducationLevel_1 %>"></asp:ListItem>
                            <asp:ListItem Value="2" Text="<%$ Resources:UsersData,EducationLevel_2 %>"></asp:ListItem>
                            <asp:ListItem Value="3" Text="<%$ Resources:UsersData,EducationLevel_3 %>"></asp:ListItem>
                            <asp:ListItem Value="4" Text="<%$ Resources:UsersData,EducationLevel_4 %>"></asp:ListItem>
                            <asp:ListItem Value="5" Text="<%$ Resources:UsersData,EducationLevel_5 %>"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvEducationLevel"
                            runat="server" ErrorMessage="<%$ Resources:User,RequiredField %>" ControlToValidate="ddlEducationLevel"
                            InitialValue="-1" ValidationGroup="UsersData" Text="<%$ Resources:User,RequiredField %>"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr id="trDetailsControl" runat="server">
                    <td class="texttop">
                        <asp:Label ID="lblDetails" runat="server" />
                    </td>
                    <td class="Control">
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtDetails" runat="server" TextMode="MultiLine" CssClass="BigControls"
                                        ValidationGroup="UsersData" maxlengthS="2000" onkeyup="return ismaxlength(this,document.forms[0].txtDetailsLengthControler)"
                                        onfocus="return ismaxlength(this,document.forms[0].txtDetailsLengthControler)"></asp:TextBox>
                                    <asp:RequiredFieldValidator CssClass="ourvalidation" Display="Dynamic" ID="rfvDetails"
                                        runat="server" ErrorMessage="<%$ Resources:User,RequiredField %>" ControlToValidate="txtDetails"
                                        ValidationGroup="UsersData" Text="<%$ Resources:User,RequiredField %>"></asp:RequiredFieldValidator>
                                </td>
                                </tr>
                            <tr>
                                <td class="Control">
                                    <input type="text" class="txtCounter" name="txtDetailsLengthControler" id="Text1"
                                        disabled>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="trIsConsultant" runat="server">
                    <td class="text">
                        <asp:Label ID="lblIsConsultant" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:CheckBox ID="cbIsConsultant" runat="server" ValidationGroup="UsersData"></asp:CheckBox>
                    </td>
                </tr>
                <tr id="trMetaKeyWords" runat="server">
                    <td class="text">
                        <asp:Label ID="lblMetaKeyWords" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="128" ID="txtMetaKeyWordsAr" runat="server" CssClass="Controls"></asp:TextBox>
                    </td>
                </tr>
                <tr id="trShortDescription" runat="server">
                    <td class="text">
                        <asp:Label ID="lblShortDescription" runat="server" />
                    </td>
                    <td class="Control">
                        <asp:TextBox MaxLength="128" ID="txtShortDescriptionAr" runat="server" CssClass="Controls"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Result" align="center" colspan="2" style="padding-top: 15px; padding-bottom: 15px">
                        <asp:Button ID="btnSave" runat="server" ValidationGroup="UsersData" OnClick="btnSave_Click"
                            SkinID="btnSave" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
