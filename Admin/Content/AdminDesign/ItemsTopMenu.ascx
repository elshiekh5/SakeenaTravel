<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ItemsTopMenu.ascx.cs"
    Inherits="App_Design_masters_ItemsTopMenu" %>

<table width="100%" cellspacing="0" cellpadding="0" border="0" style="margin-bottom:20px;">
    <tr id="trCategories" runat="server">
        <td class="toplinks">
            <li><a class="toplinks" href="/AdminCP/Items/<%= currentModule.Identifire %>/Cats/Add.aspx"><%= Resources.Modules.Module_CategoriesAdd%></a></li>
        </td>
        <td class="toplinks">
            <li><a class="toplinks" href="/AdminCP/Items/<%= currentModule.Identifire %>/Cats/default.aspx"><%= Resources.Modules.Module_CategoriesDefault%></a></li>
        </td>
    </tr>
    <tr id="trItems" runat="server">
        <td class="toplinks">
            <li><a class="toplinks" href="/AdminCP/Items/<%= currentModule.Identifire %>/Add.aspx"><%= Resources.Modules.Module_ItemsAdd%></a></li>
        </td>
        <td class="toplinks">
            <li><a class="toplinks" href="/AdminCP/Items/<%= currentModule.Identifire %>/default.aspx"><%= Resources.Modules.Module_ItemsDefault%></a></li>
        </td>
    </tr>
    <tr id="trPhotos" runat="server">
        <td class="toplinks">
            <li><a class="toplinks" href="/AdminCP/Items/<%= currentModule.Identifire %>/AddPhoto.aspx"><%= Resources.Modules.Module_ItemsPhotosAdd%></a></li>
        </td>
        <td class="toplinks">
        </td>
    </tr>
    <tr id="trComments" runat="server">
        <td class="toplinks">
            <li><a class="toplinks" href="/AdminCP/Items/<%= currentModule.Identifire %>/Comments/InActive.aspx"><asp:Label ID="lblInactiveComments" runat="server" ></asp:Label></a></li>
        </td>
        <td class="toplinks">
        </td>
    </tr>
</table>
