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

        public void Send(PlanContingencia plan, Escenario escenario, string url)
        {
            //string usuarioMail = ConfigurationManager.AppSettings["MailUserName"];
            //string passwordMail = ConfigurationManager.AppSettings["MailPassword"];
                        
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();

            foreach (var d in plan.Destinatario)
            {
                foreach (var pers in d.Persona)
                {
                    mail.To.Add(String.Format("{0} <{1}>",pers.razon_social, pers.email));                    
                }
            }


            mail.From = new MailAddress("alerta@fdbrokers.com");
            mail.Subject = string.Format("Alerta de Plan de Contingencia: {0}, Riesgo: {1}", plan.descripcion, escenario.NivelesDeRiesgo.descripcion);
            mail.SubjectEncoding = System.Text.Encoding.UTF8;

            //reemplazo el controlador actual por el nuevo controlador cuando el usuario confirme su mail
            //string urlConfirmacion = string.Format("{0}/{1}",HttpContext.Current.Request.Url.AbsoluteUri.Replace("Register","Bienvenido"),user.UsuarioEncriptado);

            //string urlConfirmacion = ""; // = string.Format("{0}://{1}/{2}/{3}", HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.Host, "Account/Bienvenido", user.UsuarioEncriptado);

            //http://localhost:60227/Account/Bienvenido/

            StringBuilder body = new StringBuilder();

            body.Append("<b><font color='#FF0000'>ALERTA DE PLAN DE CONTINGENCIA </font></b> <br/><hr/> ");
            body.Append(string.Format("<b>Escenario de Riesgo acontecido:</b> {0} <br/>", escenario.nombre));
            body.Append(string.Format("<b>Nivel de Riesgo:</b>  {0} (Prioridad:{1})  <br/>", escenario.NivelesDeRiesgo.descripcion, escenario.NivelesDeRiesgo.prioridad, escenario.NivelesDeRiesgo.color));
            body.Append(string.Format("<b>Plan de Contingencia a aplicar:</b> {0} <br/> <br/>", plan.descripcion));
            body.Append("Para poder cumplimentar con el plan de contingencia por favor dirijase al siguiente link: <br/><br/>");
            body.Append(url);            
            body.Append("<br/><br/>Por favor, NO RESPONDA ESTE MENSAJE. <br/>");
            body.Append("Atentamente. <br/>");
            body.Append("Contingencia APP");
            mail.Body = body.ToString();
            //mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            //mail.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();
            client.Host = "localhost";//ConfigurationManager.AppSettings["MailHost"];
            //primero lo envio local
            if (client.DeliveryMethod == SmtpDeliveryMethod.SpecifiedPickupDirectory)
            {
                client.Send(mail);
            }
            //if (client.DeliveryMethod != SmtpDeliveryMethod.SpecifiedPickupDirectory)
            //{
            client.UseDefaultCredentials = false;
            client.Host = "mail.fdbrokers.com";
            client.Credentials = new System.Net.NetworkCredential("alerta@fdbrokers.com", "Qwerty1234");                
            client.Port = 587;
            client.EnableSsl = false;
            //}
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