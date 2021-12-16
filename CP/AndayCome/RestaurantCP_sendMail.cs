
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using System.Collections.Generic;
using AndayComeGenNHibernate.EN.AndayCome;
using AndayComeGenNHibernate.CAD.AndayCome;
using AndayComeGenNHibernate.CEN.AndayCome;



/*PROTECTED REGION ID(usingAndayComeGenNHibernate.CP.AndayCome_Restaurant_sendMail) ENABLED START*/
//  references to other libraries
using System.Net.Mail;
using System.Net;
/*PROTECTED REGION END*/

namespace AndayComeGenNHibernate.CP.AndayCome
{
public partial class RestaurantCP : BasicCP
{
public string SendMail (int p_oid, string p_subject, string p_body)
{
        /*PROTECTED REGION ID(AndayComeGenNHibernate.CP.AndayCome_Restaurant_sendMail) ENABLED START*/
        RestaurantCEN restaurantCEN = null;
        RestaurantCAD restaurantCAD = null;


        MailMessage mail = new MailMessage ();
        string dev = null;


        try
        {
                SessionInitializeTransaction ();

                restaurantCAD = new RestaurantCAD (session);
                restaurantCEN = new RestaurantCEN (restaurantCAD);



                // Write here your custom transaction ...


                //recuperar  el restaurante
                RestaurantEN restaurantEN = restaurantCEN.ReadOID (p_oid);
                //recupero los clientes
                IList<ClientEN> clientes = restaurantEN.Client;
                //recupero el correo del restaurant owner
                String email_owner = restaurantEN.Restaurant_Owner.Email;

                var gmailClient = new SmtpClient
                {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential ("andaycomeua@gmail.com", "12345uaNube")
                };

                //recorro los clientes
                foreach (ClientEN cli in clientes) {
                }

                if (clientes == null || clientes.Count == 0)
                        throw new ArgumentException ("No hay clientes");


                foreach (ClientEN cli in clientes) {
                        using (var msg = new MailMessage ("andaycomeua@gmail.com", cli.Email, p_subject, p_body))
                        {
                                msg.IsBodyHtml = true;
                                try
                                {
                                        gmailClient.Send (msg);
                                        dev = "Email enviado con exito";
                                }
                                catch (Exception)
                                {
                                        // TODO: Handle the exception
                                        dev = "Error. Email no enviado";
                                }
                        }
                }

                SessionCommit ();
                return dev;
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }


        /*PROTECTED REGION END*/
}
}
}
