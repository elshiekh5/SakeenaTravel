using System;using DCCMSNameSpace;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Configuration;

public partial class SendMail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        LocalEmailService.EmailService service = new LocalEmailService.EmailService();
        
        service.BeginSendMail(ConfigurationManager.AppSettings["MailFrom"], "ame@digitalchains.com", "xxxxxxxx","أكد الكابتن هادى خشبه مدير الكرة بالنادى الأهلى فى تصريحات تلفزيونية أن محمد فضل مهاجم الفريق سوف يعود من ألمانيا غدا الثلاثاء بعد ان اثبتت الاشعة عدم", new AsyncCallback(OnSendMail), null);
        //////System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();

        //////mail.To.Add("ame@digitalchains.com");
        //////mail.Subject = "تجربة ارسال ميل";
        //////mail.IsBodyHtml = true;
        //////mail.Body = "يارب يوصل";

        //////System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
        

        //////smtp.Send(mail);


        Response.Write(DateFormat.ArabicCalCustom(DateTime.Now, true));

        //System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();

        //mail.To.Add("ame@digitalchains.com");
        //mail.Subject = "dddddddddddddd";

        //mail.From = new System.Net.Mail.MailAddress("test@egypt.digitalchains.com");
        //mail.IsBodyHtml = true;
        //mail.Body = "dddddddddddddd";

        //System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
        //smtp.EnableSsl = true;


        //string portNum = ConfigurationManager.AppSettings["MailSMTPPort"];
        //string userName = ConfigurationManager.AppSettings["MailUserName"];
        //string password = ConfigurationManager.AppSettings["MailPassWord"];
        ////mail.Headers.Add("Disposition-Notification-To", ConfigurationManager.AppSettings["MailFrom"]);
        //mail.Headers.Add("Return-Path", ConfigurationManager.AppSettings["MailFrom"]);

        ////for SMTP Authentication
        //System.Net.NetworkCredential net = new System.Net.NetworkCredential(userName, password);
        //smtp.Credentials = net;

        //mail.Headers.Add("X-CS-EmailID", Guid.NewGuid().ToString());
        //mail.Headers.Add("X-CS-ThreadId", Thread.CurrentThread.ManagedThreadId.ToString());
        //mail.Headers.Add("X-CS-Attempts", "1");
        //mail.Headers.Add("X-CS-AppDomain", AppDomain.CurrentDomain.FriendlyName);
        //mail.BodyEncoding = Encoding.GetEncoding(1256);
        //mail.SubjectEncoding = Encoding.GetEncoding(1256);
        //mail.DeliveryNotificationOptions = DeliveryNotificationOptions.None;

        //mail.IsBodyHtml = true;
        //smtp.Send(mail);
    }
    private void OnSendMail(IAsyncResult ar)
    {

    }
}
