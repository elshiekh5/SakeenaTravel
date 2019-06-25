<%@ Control Language="C#" AutoEventWireup="true" %>
<script runat="server">
    public ItemsModulesOptions currentModule { get; set; }
    public ItemsEntity itemsObject { get; set; }
</script>
<div class="blog margin-bottom-30">
	<% if (currentModule.HasTitle){ %>
          <h3><%= itemsObject.Title %></h3>
    <% } %>
    <ul class="unstyled inline blog-info">
        <% if (currentModule.HasItemDate) { %>
                	<li><i class="icon-calendar"></i> <%= itemsObject.ItemDate.ToLongDateString() %></li>
        <% } %>
         <% if (currentModule.HasAuthorName && !string.IsNullOrEmpty(itemsObject.AuthorName))
            { %>
                	<li><i class="icon-pencil"></i> <%= itemsObject.AuthorName %></li>
        <% } %>
                	<li><i class="icon-"></i> <a href="#">24 <%= Resources.Comments.UserCommentsCount%></a></li>
                </ul>
<%--            	<ul class="unstyled inline blog-tags">
                    <li>
                        <i class="icon-tags"></i> 
                        <a href="#">Technology</a> 
                        <a href="#">Education</a>
                        <a href="#">Internet</a>
                        <a href="#">Media</a>
                    </li>
    
                </ul>--%>
     <% if (currentModule.HasPhoto2Extension && !string.IsNullOrEmpty(itemsObject.Photo2Extension))
            { %>
                	<div class="blog-img"><img src="<%=itemsObject.Photo2Path %>" alt="" /></div>
        <% } %>

        <% if (currentModule.HasDetails && !string.IsNullOrEmpty(itemsObject.Description))
            { %>
                	<%=itemsObject.Description %>
        <% } %>
</div>