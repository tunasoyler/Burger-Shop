using System.Net.Mail;

namespace MVC.MailHelper
{
    public class ResetPassword
    {
        public static void PasswordSendMail(string link)
        {
        
            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            mail.From=new MailAddress("sakuraburgerdestek@gmail.com");
            mail.To.Add("besteyasak@gmail.com");
            mail.Subject = "Şifre Güncelleme";
            mail.Body = "<h2>Şifrenizi yenilemek için linke tıklayınız.</h2><hr>";
            mail.Body += $"<a href='{link}'> Şifre yenileme bağlantısı";

            mail.IsBodyHtml= true;
            smtp.Host= "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl= true;
            smtp.Credentials = new System.Net.NetworkCredential("sakuraburgerdestek@gmail.com", "elndjbddszgtqshu");
            smtp.Send(mail);
        }
    }
}
