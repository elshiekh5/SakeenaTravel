<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MLangsDetails.ascx.cs"
    Inherits="UserControls_MLangsDetails" %>
 
    
<%@ Register Src="Details.ascx" TagName="Details" TagPrefix="uc1" %>
<script type="text/javascript">
function GetTabStyle(tab,tabContent,langID)
{
    var DefaultLanguageID = <%= (int)(Languages)SiteSettings.Languages_DefaultLanguageID  %> ;
    if (DefaultLanguageID == langID)
        {
            document.getElementById(tab).className="tabActive";
             document.getElementById(tabContent).style.display = 'block';
        }
        else
        {
            document.getElementById(tab).className="tab";
             document.getElementById(tabContent).style.display = 'none';
        }
}
 //----------------------------------------------
     function SwitchTabs(type) {
         if (type == 'ar') {
             document.getElementById("tabArabic").style.display = 'block';
             document.getElementById("tabEnglish").style.display = 'none';
             document.getElementById("<%= tbArabic.ClientID %>").className = "tabActive";
             document.getElementById("<%= tbEnglish.ClientID %>").className = "tab";
             currentLang = ar;
         }
         else {
             document.getElementById("tabArabic").style.display = 'none';
             document.getElementById("tabEnglish").style.display = 'block';
             document.getElementById("<%= tbArabic.ClientID %>").className = "tab";
             document.getElementById("<%= tbEnglish.ClientID %>").className = "tabActive";
             currentLang = en;
         }
     }
</script>
<table cellspacing="0" cellpadding="0" width="100%" border="0">
<% if (ViewTaps)
   { %>
     <tr>
                    <td class="text" colspan="2">
                        <table cellpadding="1" cellspacing="0" class="tableTab" width="100%">
                            <tr>
                                <td runat="server"  width="60" align="center" id="tbArabic" onclick="SwitchTabs('ar');">
                                    عربي
                                </td>
                                <td width="5">
                                </td>
                                <td runat="server"  width="60" align="center" id="tbEnglish" onclick="SwitchTabs('en');">
                                    English
                                </td>
                                <td >
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                
     <tr>
             <td colspan="2" class="tabfasel">
             </td>
         </tr><% } %>
         <tr>
                    <td class="text" colspan="2">
                        <div id="tabArabic">
                        <% if (ViewTaps)
                            { %>
                            <div class="SubHeader2"><%= Resources.AdminText.LanguageDetails1 %></div>
                            <% } %>
                            <uc1:Details ID="ucArDetails" Lang="Ar" runat="server" />
                        </div>
                        <div id="tabEnglish" >
                        <% if (ViewTaps)
                            { %>
                            <div class="SubHeader2"><%= Resources.AdminText.LanguageDetails2 %></div>
                            <% } %>
                            <uc1:Details  ID="ucEnDetails" Lang="En" runat="server" />
                        </div>
                    </td>
                </tr>            
</table>
<script type="text/javascript">
GetTabStyle('<%= tbArabic.ClientID %>',"tabArabic",1);
GetTabStyle('<%= tbEnglish.ClientID %>',"tabEnglish",2);
</script>
