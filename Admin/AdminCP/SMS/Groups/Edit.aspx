<%@ Page Language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="Edit.aspx.cs"
    Inherits="AdminSMSGroups_Update" %>

<%@ Register src="../../_UserControls/SMS/Groups/Edit.ascx" tagname="Edit" tagprefix="uc1" %>

<asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:Edit ID="Edit1" runat="server" />
</asp:Content>
