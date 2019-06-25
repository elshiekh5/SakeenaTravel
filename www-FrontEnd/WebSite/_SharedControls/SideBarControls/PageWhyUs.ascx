<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PageWhyUs.ascx.cs" Inherits="WebSite__SharedControls_PageContacts" %>
 <!-- Why we are? -->
                <div class="headline"><h2><%= (WhyUs!=null)?WhyUs.Title:"" %></h2></div>
                <p><%= (WhyUs!=null)?WhyUs.ShortDescription:"" %></p>
                <ul class="list-unstyled">
                    <%--<%= (WhyUs!=null)?WhyUs.Description:"" %>--%>
                    <li><i class="fa fa-check color-green"></i> Odio dignissimos ducimus</li>
                    <li><i class="fa fa-check color-green"></i> Blanditiis praesentium volup</li>
                    <li><i class="fa fa-check color-green"></i> Eos et accusamus</li>
                </ul>