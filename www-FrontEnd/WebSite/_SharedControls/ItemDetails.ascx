<%@ Control Language="C#" AutoEventWireup="true" %>
<script runat="server">
    public ItemsModulesOptions currentModule { get; set; }
    public ItemsEntity itemsObject { get; set; }
</script>
<div class="blog margin-bottom-40">
	<% if (currentModule.HasTitle)
    { %>
          <h2><%= itemsObject.Title%></h2>
    <% } %>
        <div class="blog-post-tags">
        <ul class="list-unstyled list-inline blog-info">
        <% if (currentModule.HasItemDate)
           { %>
                	<li><i class="fa fa-calendar"></i> <%= itemsObject.ItemDate.ToLongDateString()%></li>
        <% } %>
         <% if (currentModule.HasAuthorName && !string.IsNullOrEmpty(itemsObject.AuthorName))
            { %>
                	<li><i class="icon-pencil"></i> <%= itemsObject.AuthorName%></li>
        <% } %>
                	<li><i class="fa fa-comments"></i> <a href="#">24 <%= Resources.Comments.UserCommentsCount%></a></li>
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
    </div>
     <% if (currentModule.HasPhoto2Extension && !string.IsNullOrEmpty(itemsObject.Photo2Extension))
        { %>
                	<div class="blog-img"><img class="img-responsive" src="<%=itemsObject.Photo2Path%>" alt="" /></div>
        <% } %>

        <% if (currentModule.HasDetails && !string.IsNullOrEmpty(itemsObject.Description))
           { %>
                <p>
                	<%=itemsObject.Description%>
                </p>
        <% } %>
</div>