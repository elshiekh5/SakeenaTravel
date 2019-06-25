<%@ Page Language="C#" MasterPageFile="~/AdminCP/ClearAdmin.master"  AutoEventWireup="true" CodeFile="Add.aspx.cs" Inherits="Admin_Users_CreateUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" border="0">
	    
		        
	    <tr>
			<td align="center"  class="SubHeader"><asp:Label ID="Label1" Text="<%$ Resources:Zecurity,ZecurityUserData %>" runat="server" /></td>
		</tr>
		<tr>
			<td >
				<asp:CreateUserWizard ID="CreateUserWizard1" runat="server" OnCreatedUser="CreateUserWizard1_CreatedUser" 
						ContinueDestinationPageUrl="Default.aspx" 
						FinishDestinationPageUrl="Default.aspx" 
						LoginCreatedUser="False" 
						RequireEmail="True"
						AnswerLabelText="<%$ Resources:Zecurity,AnswerLabelText %>"
						AnswerRequiredErrorMessage="<%$ Resources:Zecurity,AnswerRequiredErrorMessage %>"
						CancelButtonText="<%$ Resources:Zecurity,CancelButtonText %>"
						CompleteSuccessText="<%$ Resources:Zecurity,CompleteSuccessText %>"
						ConfirmPasswordCompareErrorMessage="<%$ Resources:Zecurity,ConfirmPasswordCompareErrorMessage %>"
						ConfirmPasswordLabelText="<%$ Resources:Zecurity,ConfirmPasswordLabelText %>"
						ConfirmPasswordRequiredErrorMessage="<%$ Resources:Zecurity,ConfirmPasswordRequiredErrorMessage %>"
						ContinueButtonText="<%$ Resources:Zecurity,ContinueButtonText %>"
						CreateUserButtonText="<%$ Resources:Zecurity,CreateUserButtonText %>"
						DuplicateEmailErrorMessage="<%$ Resources:Zecurity,DuplicateEmailErrorMessage %>"
						DuplicateUserNameErrorMessage="<%$ Resources:Zecurity,DuplicateUserNameErrorMessage %>"
						EmailLabelText="<%$ Resources:Zecurity,EmailLabelText %>"
						EmailRegularExpressionErrorMessage="<%$ Resources:Zecurity,EmailRegularExpressionErrorMessage %>"
						EmailRequiredErrorMessage="<%$ Resources:Zecurity,EmailRequiredErrorMessage %>"
						FinishCompleteButtonText="<%$ Resources:Zecurity,FinishCompleteButtonText %>"
						FinishPreviousButtonText="<%$ Resources:Zecurity,FinishPreviousButtonText %>"
						InvalidAnswerErrorMessage="<%$ Resources:Zecurity,InvalidAnswerErrorMessage %>"
						InvalidEmailErrorMessage="<%$ Resources:Zecurity,InvalidEmailErrorMessage %>"
						InvalidPasswordErrorMessage="<%$ Resources:Zecurity,InvalidPasswordErrorMessage %>"
						InvalidQuestionErrorMessage="<%$ Resources:Zecurity,InvalidQuestionErrorMessage %>"
						PasswordLabelText="<%$ Resources:Zecurity,PasswordLabelText %>"
						PasswordRegularExpressionErrorMessage="<%$ Resources:Zecurity,PasswordRegularExpressionErrorMessage %>"
						PasswordRequiredErrorMessage="<%$ Resources:Zecurity,PasswordRequiredErrorMessage %>"
						QuestionLabelText="<%$ Resources:Zecurity,QuestionLabelText %>"
						QuestionRequiredErrorMessage="<%$ Resources:Zecurity,QuestionRequiredErrorMessage %>"
						StartNextButtonText="<%$ Resources:Zecurity,StartNextButtonText %>"
						StepNextButtonText="<%$ Resources:Zecurity,StepNextButtonText %>"
						StepPreviousButtonText="<%$ Resources:Zecurity,StepPreviousButtonText %>"
						UnknownErrorMessage="<%$ Resources:Zecurity,UnknownErrorMessage %>"
						UserNameLabelText="<%$ Resources:Zecurity,UserNameLabelText %>"
						UserNameRequiredErrorMessage="<%$ Resources:Zecurity,UserNameRequiredErrorMessage %>"
						Question="<%$ Resources:Zecurity,Question %>"
						 CancelButtonStyle-CssClass="Button"
						 ContinueButtonStyle-CssClass="Button"

						 CreateUserButtonStyle-CssClass="Button"
						 FinishCompleteButtonStyle-CssClass="Button"
						 FinishPreviousButtonStyle-CssClass="Button"
						>
					<WizardSteps>
						<asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server" Title=""></asp:CreateUserWizardStep>
						<asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server" Title=""></asp:CompleteWizardStep>
					</WizardSteps></asp:CreateUserWizard>
			</td>
		</tr>
		<tr>
			<td align=center class="SubHeader"><asp:Label ID="Label2" Text="<%$ Resources:Zecurity,Permissions %>" runat="server" /></td>
		</tr>
		<tr>
		<td class="Control"><asp:CheckBoxList ID="cblGroups" runat="server">
            </asp:CheckBoxList></td></tr>
            
		</table>
</asp:Content>