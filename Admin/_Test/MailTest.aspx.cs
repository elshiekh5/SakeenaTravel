using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Threading;
using System.IO;
using System.Net;
using DCCMSNameSpace;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ActualSend3();
    }
    public void ActualSend(MailMessage mail)
    {


        //int portNum = Convert.ToInt32(txtport.Text);
        string userName = txtUser.Text;
        string password = txtpass.Text;
        SmtpClient Smtp = new SmtpClient(txtSmtp.Text);
        Smtp.Host = txtSmtp.Text;


        //mail.Headers.Add("Disposition-Notification-To", SiteSettings.MailList_MailFrom);
        mail.Headers.Add("Return-Path", txtFrom.Text);

        //for SMTP Authentication
        System.Net.NetworkCredential net = new System.Net.NetworkCredential(userName, password);
        Smtp.Credentials = net;
        Smtp.UseDefaultCredentials = false;
        //Smtp.Host = SiteSettings.MailList_MailSMTP.Text;
        mail.Headers.Add("X-CS-EmailID", Guid.NewGuid().ToString());
        mail.Headers.Add("X-CS-ThreadId", Thread.CurrentThread.ManagedThreadId.ToString());
        mail.Headers.Add("X-CS-Attempts", "1");
        mail.Headers.Add("X-CS-AppDomain", AppDomain.CurrentDomain.FriendlyName);

        // Set the body encoding
        //mail.BodyEncoding = Encoding.GetEncoding(SiteSettings.EmailEncoding);
        //mail.IsBodyHtml = true;
        // Replace any LF characters with CR LF
        mail.Body = mail.Body.Replace("\n", "\r\n");

        mail.BodyEncoding = Encoding.GetEncoding(1256);
        mail.SubjectEncoding = Encoding.GetEncoding(1256);
        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.None;

        mail.IsBodyHtml = true;
        // Replace any LF characters with CR LF
        // Send it
        Smtp.Send(mail);
        mail.Dispose();

    }

    public void ActualSend2(MailMessage mail)
    {


        string to = "elshiekh5@gmail.com";

        //It seems, your mail server demands to use the same email-id in SENDER as with which you're authenticating. 
        //string from = "sender@domain.com";
        string from = "mail@shamifactory.com";

        string subject = "Hello World!";
        string body = "Hello Body!";
        MailMessage message = new MailMessage(from, to, subject, body);
        SmtpClient client = new SmtpClient("74.53.184.13");
        client.Port = 25;
        client.UseDefaultCredentials = false;
        client.Credentials = new NetworkCredential("mail@shamifactory.com", "test123321");
        client.Send(message);
        Response.Write("Sent Done");

    }

    public void ActualSend3()
    {


        string to = txtTo.Text;
        string userName = txtUser.Text;
        string password = txtpass.Text;
        //It seems, your mail server demands to use the same email-id in SENDER as with which you're authenticating. 
        //string from = "sender@domain.com";
        string from = txtFrom.Text;

        string subject = txtSubject.Text;
        string body = txtBody.Text;
        MailMessage message = new MailMessage(from, to, subject, body);
        SmtpClient client = new SmtpClient(txtSmtp.Text);
        //for SMTP Authentication
        System.Net.NetworkCredential net = new System.Net.NetworkCredential(userName, password);
        client.Credentials = net;
        client.UseDefaultCredentials = false;
        client.Credentials = new NetworkCredential(txtUser.Text, txtpass.Text);
        client.Send(message);



    }
}
