<%@ Page Language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="default.aspx.cs"
    Inherits="AdminVoteQuestions_GetAll" %>

<%@ Register src="../../_UserControls/Voting/VoteQuestions/Default.ascx" tagname="Default" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <uc1:Default ID="Default1" runat="server" />
    
</asp:Content>
