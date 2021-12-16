
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



/*PROTECTED REGION ID(usingAndayComeGenNHibernate.CP.AndayCome_Booking_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace AndayComeGenNHibernate.CP.AndayCome
{
public partial class BookingCP : BasicCP
{
public AndayComeGenNHibernate.EN.AndayCome.BookingEN New_ (int p_restaurant, string p_client, Nullable<DateTime> p_date, Nullable<DateTime> p_hour, int p_guests)
{
        /*PROTECTED REGION ID(AndayComeGenNHibernate.CP.AndayCome_Booking_new_) ENABLED START*/

        IBookingCAD bookingCAD = null;
        BookingCEN bookingCEN = null;
        RestaurantCAD restaurantCAD = null;
        RestaurantCEN restaurantCEN = null;

        AndayComeGenNHibernate.EN.AndayCome.BookingEN result = null;


        try
        {
                SessionInitializeTransaction ();
                bookingCAD = new BookingCAD (session);
                bookingCEN = new BookingCEN (bookingCAD);
                //variables para el restaurante
                restaurantCAD = new RestaurantCAD (session);
                restaurantCEN = new RestaurantCEN (restaurantCAD);
                //recuperamos rest desde la id
                RestaurantEN restaurantEN = restaurantCEN.ReadOID (p_restaurant);
                //variable que maneja si se crea el booking
                int capacidad_actual = -1;
                capacidad_actual = restaurantCEN.Check (p_restaurant, p_guests);


                //Console.WriteLine("\n ###  Se inicia el proceso de crear reserva ###");
                //si se hay capacidad crea la reserva
                if (capacidad_actual != -1) {
                        int oid;
                        //Initialized BookingEN
                        BookingEN bookingEN;
                        bookingEN = new BookingEN ();

                        if (p_restaurant != -1) {
                                bookingEN.Restaurant = new AndayComeGenNHibernate.EN.AndayCome.RestaurantEN ();
                                bookingEN.Restaurant.Id = p_restaurant;
                        }


                        if (p_client != "") {
                                bookingEN.Client = new AndayComeGenNHibernate.EN.AndayCome.ClientEN ();
                                Console.WriteLine (p_client);
                                bookingEN.Client.Email = p_client;
                                Console.WriteLine ("SADASFAVASDVSAVASVASVASVS: " + bookingEN.Client.Email);
                        }

                        bookingEN.Date = p_date;

                        bookingEN.Hour = p_hour;

                        bookingEN.Guests = p_guests;

                        restaurantEN.Capacity = capacidad_actual;
                        restaurantCAD.ModifyDefault (restaurantEN);

                        //Call to BookingCAD

                        oid = bookingCAD.New_ (bookingEN);
                        result = bookingCAD.ReadOIDDefault (oid);
                }
                else{
                        //preguntar profe que hay q hacer para throwear excepcion si no se crea
                        Exception ex = new Exception ("NO hay suficiente capacidad");
                        throw ex;
                }


                SessionCommit ();
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
        return result;


        /*PROTECTED REGION END*/
}
}
}
