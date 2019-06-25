<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PageContacts.ascx.cs" Inherits="Footer_PageContacts" %>
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
<div class="headline"><h2>Contact Us</h2></div>
                <address class="md-margin-bottom-40">
	<%= (Contacts != null) ? Contacts.Address : ""%> <br />
					Phone: <%= (Contacts != null) ? Contacts.Mobile : ""%> <br />
					Url: <a href=":<%= (Contacts!=null)?Contacts.Url:""  %>" class=""><%= (Contacts!=null)?Contacts.Url:""  %></a><br />
					Email: <a href="mailto:<%= (Contacts != null) ? Contacts.Email : ""%>" class=""><%= (Contacts != null) ? Contacts.Email : ""%></a>
                </address>