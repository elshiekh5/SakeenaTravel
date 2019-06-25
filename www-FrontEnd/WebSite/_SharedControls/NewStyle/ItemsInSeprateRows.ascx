<%@ Control Language="C#" AutoEventWireup="true" %>
  <% 
    int index = 0;
    int rowsCountOpened = 0;
    int rowsCountClosed = 0;
    List<AppService.FrontItemsModel> ItemsList = AppService.FrontItemsController.GetModuleData((int)SiteModulesMap.Solutions, "Solutions");
    foreach (AppService.FrontItemsModel item in ItemsList)
	{
         //////////////////////////////////////////////// 
		 if(index%4 == 0)
         {
               ++rowsCountOpened; 
 %>
            <div class="row owl-work-v1 margin-bottom-20">
<%
        } 
%>
         <%//////////////////////////////////////////////// %>
         <div class="col-md-3 item">
            <a href="<%= item.BuildLink %>">
                <em class="overflow-hidden">
                    <img class="img-responsive" src="<%= item.PhotoPathOriginal %>" alt="">
                </em>
                <span>
                    <strong><%= item.Title %></strong>
                    <i><%= item.ShortDescription %></i>
                </span>
            </a>
        </div>
        <%//////////////////////////////////////////////// %>
       <% if (index % 4 == 3)
          { 
               ++rowsCountClosed;
       %>
            </div>
       <% }
          ++index;
       %>
<%  }
%>
    
 <% if (rowsCountOpened > rowsCountClosed)
    { %>
           </div>
<%  } %>
    
