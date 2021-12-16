
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using AndayComeGenNHibernate.Exceptions;
using AndayComeGenNHibernate.EN.AndayCome;
using AndayComeGenNHibernate.CAD.AndayCome;


/*PROTECTED REGION ID(usingAndayComeGenNHibernate.CEN.AndayCome_Restaurant_sendMail) ENABLED START*/
//  references to other libraries
using System.Net.Mail;
using System.Net;
/*PROTECTED REGION END*/

namespace AndayComeGenNHibernate.CEN.AndayCome
{
public partial class RestaurantCEN
{
public void SendMail (int p_oid, string p_subject, string p_body)
{
        /*PROTECTED REGION ID(AndayComeGenNHibernate.CEN.AndayCome_Restaurant_sendMail) ENABLED START*/

        // Write here your custom code...


        MailMessage mail = new MailMessage ();

        RestaurantCEN restaurantCEN = new RestaurantCEN ();
        RestaurantEN restaurantEN = restaurantCEN.ReadOID (p_oid);

        try
        {
                //recupero los clientes
                IList<ClientEN> clientes = restaurantEN.Client;
                //recupero el correo del restaurant owner
                String email_owner = restaurantEN.Restaurant_Owner.Email;

                //para probarlo usamos un email estatico
                mail.From = new MailAddress ("andaycomeUA@gmail.com");
                Console.WriteLine ("A");
                Console.WriteLine ("L TAMANYO ES ESTE: " + clientes.Count);
                Console.WriteLine ("B");
                //recorro los clientes
                foreach (ClientEN cli in clientes) {
                        Console.WriteLine ("A");
                        mail.To.Add (new MailAddress (cli.Email));
                        mail.Subject = p_subject;
                        mail.Body = p_body;
                        mail.IsBodyHtml = false;
                        SmtpClient client = new SmtpClient (cli.Email);
                        client.Port = 587;
                        client.Credentials = new NetworkCredential ("andaycomeUA@gmail.com", "12345uaNube");
                        client.EnableSsl = true;
                        client.Send (mail);
                }
        }

        catch (Exception e)
        {
                Console.WriteLine ("Email no enviado: " + e.StackTrace);
        }


        /*PROTECTED REGION END*/
}
}
}
