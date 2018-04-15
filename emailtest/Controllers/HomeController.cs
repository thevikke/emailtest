using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using emailtest.Models;
using System.Net.Mail;
using System.Net;
using MimeKit;

namespace emailtest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            MailMessage mail = new MailMessage
            {
                Subject = "mokkamoi!!",
                From = new MailAddress("vikke94@hotmail.com")
            };
            mail.To.Add("kristian.tuusjarvi@gmail.com");
            mail.Body = "Hello! your mail content goes here...";
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient("smtp-mail.outlook.com", 587)
            {
                EnableSsl = true
            };
            NetworkCredential netCre = new NetworkCredential("vikke94@hotmail.com", "*******");
            smtp.Credentials = netCre;
            try
            {
                smtp.Send(mail);
            }
            catch (Exception)
            {
                // Handle exception here 
            }

            return View();

        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
