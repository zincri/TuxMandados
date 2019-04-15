using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace TuxMandados.Helpers
{
  public class EmailHelper
    {
        public static async Task EnviarCorreo(string Mensaje,string Correo,bool html,string Titulo)
        {


            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("tuxmandados.18@gmail.com");//Este debe ser nuestro correo Gmail al que le dimos los permisos necesarios es decir el que envia los correos
                mail.To.Add(Correo);//Este es el correo al que llegara el correo
                mail.Subject = Titulo;// El titulo del mensaje
                mail.IsBodyHtml = html;
                mail.Body = Mensaje;//El mensaje que se almaceno en el string

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("tuxmandados.18@gmail.com", "Tu%m4nd4d0s");// aqui debe ir nuestro correo Gmail y nuestra contraseña
                SmtpServer.EnableSsl = true;
                ServicePointManager.ServerCertificateValidationCallback = delegate (object sender, X509Certificate certificate, X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors) {
                    return true;
                };
                SmtpServer.Send(mail);

            }

            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert(
              "Error",
              "Ocurrio un problema enviando el correo de recuperacion",
              "Ok");
            }
        }
    }
}
