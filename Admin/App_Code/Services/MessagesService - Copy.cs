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
public class MessagesServicexxxx : System.Web.Services.WebService
{

    public MessagesServicexxxx()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
        public JsonTextResult ContactUS(ContactUsModel model)
    {
        string resultMessage = null;
        bool SendingResult = MessagesController.ContactUS(model, out resultMessage);
        JsonTextResult data = new JsonTextResult();
        data.Message = "HelloWorld";
        return data;
        //JavaScriptSerializer js = new JavaScriptSerializer();
        //Context.Response.Clear();
        //Context.Response.ContentType = "application/json";
       
        //Context.Response.Write(js.Serialize(data));
    }
    [System.Web.Services.WebMethod]
    public City GetCity(City city)
    {
        return city;
    }
 [System.Web.Services.WebMethod]
    public City ContactUs2(ContactUsModel city)
    {
        City newcity = new City();
        newcity.Name = "name";
        newcity.Population = 2014;
        return newcity;
    }
    [System.Web.Services.WebMethod]
    public static string GetText(City city)
    {
        return "done";
    }   
}


