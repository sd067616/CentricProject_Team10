using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;

namespace CentricProject_Team10.Controllers
{
    public class emailController : Controller
    {
        // GET: email
        public ActionResult Index()
        {
            
            SmtpClient myClient = new SmtpClient();
            // the following line has to contain the email address and password of someone
            // authorized to use the email server (you will need a valid Ohio account/password
            // for this to work)
            myClient.Credentials = new NetworkCredential("ag705715@ohio.edu", "Wigwamguy7");
            MailMessage myMessage = new MailMessage();
            // the syntax here is email address, username (that will appear in the email)
            MailAddress from = new MailAddress("ag705715@ohio.edu", "Andrew Golik");
            myMessage.From = from;
            myMessage.To.Add("ag705715@ohio.edu"); // this should be replaced with model data
                                                    // as shown at the end of this document
            myMessage.Subject = "MVC Email test";
            // the body of the email is hard coded here but could be dynamically created using data
            // from the model- see the note at the end of this document
            myMessage.Body = "This is the body of the mail message. This can be essentially anylength, and could come ";
myMessage.Body += "from the database, a variable, the return of another method...";
            try
            {
                myClient.Send(myMessage);
                TempData["mailError"] = "";
            }
            catch (Exception ex)
            {
                // this captures an Exception and allows you to display the message in the View
                TempData["mailError"] = ex.Message;
            }
            return View();
        }
    }
}