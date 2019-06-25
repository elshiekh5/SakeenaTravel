<%@ Page  Language="C#" MasterPageFile="~/AdminCP/ClearAdmin.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Modules_Security_Groups_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
        function ShowHideDiv(id) 
        {
            var _div = document.getElementById(id );
            if (_div.style.display == 'none') 
            {
                _div.style.display = 'block';
            }
            else 
            {
                _div.style.display = 'none';
            }
        }
    </script>
    <table width="100%" id="tbl_groups">
       
        <tr>
            <td>
                <asp:DataGrid runat="server" ID="dgPermissionGroups" DataKeyField="ID" 
                    onitemdatabound="dgPermissionGroups_ItemDataBound" 
                    ondeletecommand="dgPermissionGroups_DeleteCommand" SkinID=GridViewSkin>
                    <PagerStyle Visible=false />
                    <Columns>
                        <asp:TemplateColumn HeaderText="<%$ Resources:Zecurity,GroupName %>">
                            <ItemTemplate>
                                <div class="GroupName"><%# Eval("Name")%></div>
                                <ul>
                                    <li class="li_expand">
                                        <div class="Switch" style="cursor:hand;" onclick="ShowHideDiv('dv_<%# Eval("ID")%>');"><%# Resources.Zecurity.Permissions %></div>
                                        <div class="Expandable" align="center" id='dv_<%# Eval("ID")%>' style="display:none">
                                            <asp:DataGrid SkinID=GridViewSkin runat="server" ID="dgPermissions" DataKeyField="ID" Width="80%">
                                                <Columns>
                                                    <asp:BoundColumn DataField="Name" HeaderText="<%$ Resources:Zecurity,Deparments %>"  />
                                                    <asp:BoundColumn DataField="Add" HeaderText="<%$ Resources:Zecurity,Add %>" DataFormatString="<img src='/Content/images/Boolean/{0}.gif' />" >
                                                        <ItemStyle Width="50" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="Edit" HeaderText="<%$ Resources:AdminText,Update %>" DataFormatString="<img src='/Content/images/Boolean/{0}.gif' />" >
                                                        <ItemStyle Width="50" />
                                                    </asp:BoundColumn>
                                                    <asp:BoundColumn DataField="Delete" HeaderText="<%$ Resources:AdminText,Delete %>" DataFormatString="<img src='/Content/images/Boolean/{0}.gif' />" >
                                                        <ItemStyle Width="50" />
                                                    </asp:BoundColumn>
                                                   
                                                </Columns>
                                            </asp:DataGrid>
                                        </div>
                                    </li>
                                    <li class="li_expand">
                                        <div class="Switch" style="cursor:hand;" onclick="ShowHideDiv('dvu_<%# Eval("ID")%>');"><%# Resources.Zecurity.ZecurityUsers%></div>
                                        <div class="Expandable"  id='dvu_<%# Eval("ID")%>' style="display:none">
                                            <ul>
                                                <asp:Repeater runat="server" ID="rptUsers">
                                                    <ItemTemplate>
                                                        <li>
                                                            <%# GetUserNameByID(Eval("ID")) %>
                                                        </li>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </ul>
                                        </div>
                                    </li>
                                </ul>
                            </ItemTemplate>
                            
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="<%$ Resources:AdminText,Update %>">
                            <ItemStyle Width="24" />
                            <ItemTemplate>
                                <a href='<%# "Edit.aspx?id=" + Eval("ID") %>' class='Link'>
									<img src="/Content/AdminDesign/global/images/Edit.gif" style="border-width:0px" alt="<%#Resources.AdminText.Update%>" /></a>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        <asp:TemplateColumn HeaderText="<%$ Resources:AdminText,Delete %>">
                        <ItemStyle Width="25" />
                            <ItemTemplate>
                                <asp:ImageButton ID="lbtnDelete" runat="server" SkinID="ibtnGridDelete" CommandName="Delete" OnClientClick="return confirm('<%$ Resources:AdminText,DeleteActivation %>')"></asp:ImageButton>
                            </ItemTemplate>
                        </asp:TemplateColumn>
                        
                    </Columns>
                </asp:DataGrid>
            </td>
        </tr>
    </table>
</asp:Content>

