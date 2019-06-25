<%@ Page  Language="C#" MasterPageFile="~/AdminCP/ClearAdmin.master" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Admin_Modules_Security_Roles_Add"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<img src="/Content/images/ajax-loader.gif" style="display:none;" />        
    <table width="100%" border="0">

        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="lblResult" runat="server"></asp:Label></td>
        </tr>
         <tr>
            <td class="text"><asp:Label ID="Label1" Text="<%$ Resources:Zecurity,GroupName %>" runat="server" /></td>
            <td class="Control">
                <asp:TextBox ID="txtRoleName" CssClass="Controls" runat="server" ></asp:TextBox>
                <asp:RequiredFieldValidator Display="Dynamic"  ID="RequiredFieldValidator1"  runat="server" ErrorMessage="*" ControlToValidate="txtRoleName" ValidationGroup="vgSecrity"></asp:RequiredFieldValidator>
            </td>
         </tr>
    </table>
    
    <asp:ScriptManager ID="ScriptManager1" runat="server" ></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline">
    <ContentTemplate>
    
    <table width=95% border="0">
         <tr>
            <td class="text"><asp:Label ID="Label2" Text="<%$ Resources:Zecurity,Permissions %>" runat="server" /></td>
            <td class="Control">
                <asp:CheckBox ID="cbAdd" runat="server" Text="<%$ Resources:Zecurity,Add %>" /><br />
                <asp:CheckBox ID="cbEdit" runat="server" Text="<%$ Resources:Zecurity,Update %>" /><br />
                <asp:CheckBox ID="cbDelete" runat="server" Text="<%$ Resources:Zecurity,Delete %>" />
         </tr>
         <tr>
            <td class="text"><asp:Label ID="Label3" Text="<%$ Resources:Zecurity,Deparment %>" runat="server" /></td>
            <td class="Control">
                <asp:DropDownList runat="server" ID="ddlModules">
                </asp:DropDownList>
                <%--<asp:TextBox ID="txtFolder" runat="server" Width="320px"></asp:TextBox>--%>
                <asp:RequiredFieldValidator Display="Dynamic"  ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ValidationGroup="vgAddPermission" ControlToValidate="ddlModules" InitialValue="-1"></asp:RequiredFieldValidator>
                
                <asp:Button ID="btnAdd" runat="server" Text="<%$ Resources:Zecurity,AddDeparment %>" CssClass="BigButton"
                    onclick="btnAdd_Click" ValidationGroup="vgAddPermission" /><br />
               
                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ErrorMessage="*" ControlToValidate="ddlModules" 
                    ValidationExpression="(/[\w- ./?%&amp;=]*)?/" 
                    ValidationGroup="vgAddPermission"></asp:RegularExpressionValidator>--%>
            </td>
         </tr>
         <tr>
             <td class="text" colspan="2">
                 <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
                     AssociatedUpdatePanelID="UpdatePanel1">
                     <ProgressTemplate>
                         <table width="100%">
                             <tr>
                                 <td align="center">
                                     <img src="/Content/images/ajax-loader.gif" /></td>
                             </tr>
                         </table>
                     </ProgressTemplate>
                 </asp:UpdateProgress>
             </td>
         </tr>
         <tr>
            <td colspan="2" >
                <asp:DataGrid  SkinID="GridViewSkin" runat="server"  ID="dgPermissions" DataKeyField="ID" ondeletecommand="dgPermissions_DeleteCommand" >
                    <Columns>
                        <asp:TemplateColumn HeaderText="<%$ Resources:Zecurity,Deparments %>">
                            <ItemTemplate>
                                <%# Eval("Name") %>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:BoundColumn Visible="false" DataField="Path" HeaderText="<%$ Resources:Zecurity,Path %>" DataFormatString="<div dir=ltr align=left>~{0}</div>" />
                        <asp:BoundColumn DataField="Add" HeaderText="<%$ Resources:Zecurity,Add %>" DataFormatString="<img src='/Content/images/Boolean/{0}.gif' />" >
                            <ItemStyle Width="50" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Edit" HeaderText="<%$ Resources:AdminText,Update %>" DataFormatString="<img src='/Content/images/Boolean/{0}.gif' />" >
                            <ItemStyle Width="50" />
                        </asp:BoundColumn>
                        <asp:BoundColumn DataField="Delete" HeaderText="<%$ Resources:AdminText,Delete %>" DataFormatString="<img src='/Content/images/Boolean/{0}.gif' />" >
                            <ItemStyle Width="50" />
                        </asp:BoundColumn>
                        
                        <asp:TemplateColumn>
                            <ItemTemplate>
                                <asp:ImageButton ID="lbtnDelete" runat="server" SkinID="ibtnGridDelete" CommandName="Delete" ></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                    </Columns>
                </asp:DataGrid>
            </td>
         </tr>
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
    <table width="95%" border="0">
        <tr>
            <td align=center>
                <asp:Button  ID="Button1" runat="server" 
                    onclick="Button1_Click" ValidationGroup="vgSecrity"  SkinID="btnSave" /></td>
        </tr>
    </table>
</asp:Content>

