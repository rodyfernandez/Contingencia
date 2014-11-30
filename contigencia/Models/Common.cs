using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Net.Mail;
using System.Configuration;

namespace contigencia.Models
{
    public class Common
    {

        public void Send(Persona pers, PlanContingencia plan, Escenario escenario)
        {
            string usuarioMail = ConfigurationManager.AppSettings["MailUserName"];
            string passwordMail = ConfigurationManager.AppSettings["MailPassword"];

            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(pers.email);
            mail.From = new MailAddress("PlanDeContingencia@gmail.com", "Plan Contingencia");
            mail.Subject = string.Format("{0}, Alerta de Plan de Contingencia: {1}, Riesgo: {2}", pers.razon_social, plan.descripcion, escenario.NivelesDeRiesgo.descripcion);
            mail.SubjectEncoding = System.Text.Encoding.UTF8;

            //reemplazo el controlador actual por el nuevo controlador cuando el usuario confirme su mail
            //string urlConfirmacion = string.Format("{0}/{1}",HttpContext.Current.Request.Url.AbsoluteUri.Replace("Register","Bienvenido"),user.UsuarioEncriptado);

            string urlConfirmacion = ""; // = string.Format("{0}://{1}/{2}/{3}", HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.Host, "Account/Bienvenido", user.UsuarioEncriptado);

            //http://localhost:60227/Account/Bienvenido/

            StringBuilder body = new StringBuilder();

            body.Append("<b>ACTIVE SU CUENTA.</b> <br/><hr/> ");
            body.Append("Gracias por registrarse en la escuela de futbol <b>Campus Crecer</b>. <br/><br/>");
            body.Append("Para proceder con la activación de su cuenta, ingrese a la siguiente dirección: <br/><br/>");
            body.Append(urlConfirmacion);
            body.Append("<br/><br/>IMPORTANTE: Recuerde y proteja la información de su cuenta de acceso a Campus Crecer:<br/>");
            body.Append("<br/><br/>Por favor, NO RESPONDA ESTE MENSAJE.<br/>");
            body.Append("Atentamente. <br/>");
            body.Append("Campus Crecer.");
            mail.Body = body.ToString();

            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();
            client.Host = ConfigurationManager.AppSettings["MailHost"];
            if (client.DeliveryMethod != SmtpDeliveryMethod.SpecifiedPickupDirectory)
            {
                client.Credentials = new System.Net.NetworkCredential(usuarioMail, passwordMail);
                client.Port = 587;
                client.EnableSsl = true;
            }
            try
            {
                client.Send(mail);
            }
            catch (Exception ex)
            {
                throw;
                //Page.RegisterStartupScript("UserMsg", "<script>alert('Sending Failed...');if(alert){ window.location='SendMail.aspx';}</script>");
            }

        }
    }
}