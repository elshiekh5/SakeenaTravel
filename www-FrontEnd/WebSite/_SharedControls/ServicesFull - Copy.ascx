<%@ Control Language="C#" AutoEventWireup="true" Inherits="DCCMSNameSpace.ReadyUserControls.Items_GetAll" %>
<script runat="server">
    int index = 0;
    int rowsCountOpened = 0;
    int rowsCountClosed = 0;
    public override void Prepare()
    {
        RequiredModule = SiteModulesMap.Services;
    }
</script>
<%@ Register Src="Intro.ascx" TagName="Intro" TagPrefix="uc1" %>
<div class="row-fluid">
    <p>
        <uc1:Intro ID="Intro1" runat="server" RequiredPageType="ServicesIntro" />
    </p>
    <br />

     <asp:Repeater ID="rList" runat="server">
            <ItemTemplate>
      <% if(index%3 == 0)
         {
               ++rowsCountOpened; 
       %>
      <div class="row-fluid servive-block">
      <% } %>
          <div class="span4">
               <h4><%# DataBinder.Eval(Container, "DataItem.Title") %></h4>
               <p>
                  <img src="<%# Eval("PhotoPathOriginal") %>" />
               </p>
               <p class="justify"><%# DataBinder.Eval(Container, "DataItem.ShortDescription") %></p>
          </div>
       
           <% if(index%3 == 2)
                { 
                     ++rowsCountClosed;
                  
                %>
               </div>
                <% }
                    ++index;
                %>

                 
            </ItemTemplate>
        </asp:Repeater>
       <% if (rowsCountOpened > rowsCountClosed){ %>
           </div>
           <% } %>
    <!--/row-fluid-->
</div>
