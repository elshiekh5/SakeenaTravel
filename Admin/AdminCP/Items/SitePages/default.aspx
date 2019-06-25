<%@ Page language="c#" ValidateRequest="false" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="default.aspx.cs" Inherits="AdminSitePages_GetAll"  %><%@ Register Assembly="MoversFW" Namespace="MoversFW" TagPrefix="cc1" %>

 <%@ Register src="../../../AdminCP/_UserControls/Items/GetAll.ascx" tagname="GetAll" tagprefix="uc1" %>

 <asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <uc1:GetAll ID="GetAll1" runat="server" ModuleTypeID="1" />

</asp:Content>

