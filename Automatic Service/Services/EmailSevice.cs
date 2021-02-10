using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Automatic_Service.Services
{
    public static class EmailSevice
    {
        public static void SendEmail(string MailBody, int idNode)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("pedrosaxes@gmail.com");
                mail.To.Add("omeutoshiba@gmail.com");
                mail.Subject = $"ALERT!! Potencial error on Node {idNode}";
                mail.Body = MailBody;

                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("pedrosaxes", "filamento");
                SmtpServer.EnableSsl = true;
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;

                SmtpServer.Send(mail);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
