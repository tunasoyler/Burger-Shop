using Microsoft.AspNetCore.Identity;
using MVC.Models.Context;
using System.Net.Mail;
using MVC.Models.Context;
using Microsoft.AspNetCore.Mvc;

namespace MVC.MailHelper
{
    public class ResetPassword
    {
        public static void PasswordSendMail(string link)
        {
        
            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            mail.From=new MailAddress("system@mail.com");
            mail.To.Add("sakuraburgerdestek@gmail.com");
            mail.Subject = "Şifre Güncelleme";
            mail.Body = "<h2>Şifrenizi yenilemek için linke tıklayınız.</h2><hr>";
            mail.Body += $"<a href='{link}'> Şifre yenileme bağlantısı";

            mail.IsBodyHtml= true;
            smtp.Host= "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl= true;
            smtp.Credentials = new System.Net.NetworkCredential("sakuraburgerdestek@gmail.com", "Beste1998.");
            smtp.Send(mail);
        }
    }
}
