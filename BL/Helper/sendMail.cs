using System.Net.Mail;
using System.Net;
using EmailSender.Model;
using EmailSender.DAL.Entities;

namespace EmailSender.BL.Helper
{
    public class sendMail
    {
        public static string senderMail(Messages messages,List<string>mails)
        {
            
            var client = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("97d904461353f9", "b5996d1afbd27d"),
                EnableSsl = true
            };
            foreach(var maile in mails)
            client.Send("from@example.com", maile, messages.Subject, messages.Message);
            Console.WriteLine("Sent");
            return "sucss";

        }
    }
}


