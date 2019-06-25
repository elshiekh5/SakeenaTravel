<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PathLinksControl.ascx.cs" Inherits="PathLinksControl" %>
    <!--=== Breadcrumbs ===-->
    <div class="breadcrumbs">
    	<div class="container">
            <h1 class="pull-left"><%= AppService.NavigationManager.Instance.TopHeader %></h1>
            <ul class="pull-right breadcrumb">
                <%=  BuildLinks()  %>
            </ul>
        </div><!--/container-->
    </div><!--/breadcrumbs-->

