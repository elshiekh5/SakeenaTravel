<%@ Page language="c#" MasterPageFile="~/AdminCP/ClearAdmin.master" CodeFile="Save.aspx.cs" Inherits="AdminAdvertisments_Save"  %>

 <%@ Register src="../../_UserControls/Advertisments/Save.ascx" tagname="Save" tagprefix="uc1" %>

 <asp:Content id="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

			<uc1:Save ID="Save1" runat="server" PlaceType="MasterWebSite" />
            
</asp:Content>

