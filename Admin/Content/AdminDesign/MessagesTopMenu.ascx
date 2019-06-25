<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MessagesTopMenu.ascx.cs"
    Inherits="App_Design_masters_ItemsTopMenu" %>

<table width="100%" cellspacing="0" cellpadding="0" border="0" style="margin-bottom:20px;">
    <tr id="trCategories" runat="server">
        <td class="toplinks">
            <li><a class="toplinks" href="/AdminCP/Messages/<%= CurrentMessagesModule.Identifire %>/Cats/Add.aspx"><%= Resources.Modules.Module_CategoriesAdd%></a></li>
        </td>
        <td class="toplinks">
            <li><a class="toplinks" href="/AdminCP/Messages/<%= CurrentMessagesModule.Identifire %>/Cats/default.aspx"><%= Resources.Modules.Module_CategoriesDefault%></a></li>
        </td>
    </tr>
    <tr id="trMessages" runat="server">
        <td class="toplinks">
            <li><a class="toplinks" href="/AdminCP/Messages/<%= CurrentMessagesModule.Identifire %>/New.aspx"><%= DynamicResource.GetMessageModuleText(CurrentMessagesModule, "Module_NewMessage")%></a></li>
        </td>
        <td class="toplinks">
            <li><a class="toplinks" href="/AdminCP/Messages/<%= CurrentMessagesModule.Identifire %>/default.aspx"><%= DynamicResource.GetMessageModuleText(CurrentMessagesModule, "Module_AllMessage") %></a></li>
        </td>
    </tr>
    <tr id="trExport" runat="server">
        <td class="toplinks">
            <li><a class="toplinks" href="/AdminCP/Messages/<%= CurrentMessagesModule.Identifire %>/Export.aspx"><%= DynamicResource.GetMessageModuleText(CurrentMessagesModule, "Module_ExportData") %></a></li>
        </td>
        <td class="toplinks">
        </td>
    </tr>
    <tr id="trComments" runat="server">
        <td class="toplinks">
            <li><a class="toplinks" href="/AdminCP/Messages/<%= CurrentMessagesModule.Identifire %>/Comments/InActive.aspx"><asp:Label ID="lblInactiveComments" runat="server" ></asp:Label></a></li>
        </td>
        <td class="toplinks">
        </td>
    </tr>
</table>
