<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PageContacts.ascx.cs" Inherits="WebSite__SharedControls_PageContacts" %>
<script runat="server">
    public ItemsEntity Contacts { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Contacts == null)
        {
            Contacts = ItemsFactory.GetObject(5, SiteSettings.GetCurrentLanguage(), UsersTypes.User, SitesHandler.GetOwnerIDAsGuid());
        
        }
    }
</script>

<!-- Contacts -->
                <div class="headline"><h2><%= (Contacts!=null)?Contacts.Title:"" %></h2></div>
                <ul class="list-unstyled who margin-bottom-30">
                    <li><a href="#"><i class="fa fa-home"></i><%= (Contacts!=null)?Contacts.Address:"" %></a></li>
                    <li><a href="#"><i class="fa fa-envelope"></i><%= (Contacts!=null)?Contacts.Email:""  %></a></li>
                    <li><a href="#"><i class="fa fa-phone"></i><%= (Contacts!=null)?Contacts.Mobile:"" %></a></li>
                    <li><a href="#"><i class="fa fa-globe"></i><%= (Contacts!=null)?Contacts.Url:"" %></a></li>
                </ul>

                