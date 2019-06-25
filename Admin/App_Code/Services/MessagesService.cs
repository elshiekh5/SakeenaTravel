using AppService;
using ServicesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;




    /// <summary>
    /// Summary description for Messages
    /// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class MessagesService : System.Web.Services.WebService
{

    public MessagesService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [System.Web.Services.WebMethod]
    public JsonTextResult ContactUs(ContactUsModel message)
    {
        string resultMessage = null;
        bool SendingResult = MessagesController.ContactUS(message, out resultMessage);
        return new JsonTextResult(resultMessage);
    }
}


