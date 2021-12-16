
using System;
using System.Text;
using AndayComeGenNHibernate.CEN.AndayCome;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using AndayComeGenNHibernate.EN.AndayCome;
using AndayComeGenNHibernate.Exceptions;


/*
 * Clase Booking:
 *
 */

namespace AndayComeGenNHibernate.CAD.AndayCome
{
public partial class BookingCAD : BasicCAD, IBookingCAD
{
public BookingCAD() : base ()
{
}

public BookingCAD(ISession sessionAux) : base (sessionAux)
{
}



public BookingEN ReadOIDDefault (int id
                                 )
{
        BookingEN bookingEN = null;

        try
        {
                SessionInitializeTransaction ();
                bookingEN = (BookingEN)session.Get (typeof(BookingEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in BookingCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return bookingEN;
}

public System.Collections.Generic.IList<BookingEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<BookingEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(BookingEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<BookingEN>();
                        else
                                result = session.CreateCriteria (typeof(BookingEN)).List<BookingEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in BookingCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (BookingEN booking)
{
        try
        {
                SessionInitializeTransaction ();
                BookingEN bookingEN = (BookingEN)session.Load (typeof(BookingEN), booking.Id);




                bookingEN.Date = booking.Date;


                bookingEN.Hour = booking.Hour;


                bookingEN.Guests = booking.Guests;

                session.Update (bookingEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in BookingCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (BookingEN booking)
{
        try
        {
                SessionInitializeTransaction ();
                if (booking.Restaurant != null) {
                        // Argumento OID y no colección.
                        booking.Restaurant = (AndayComeGenNHibernate.EN.AndayCome.RestaurantEN)session.Load (typeof(AndayComeGenNHibernate.EN.AndayCome.RestaurantEN), booking.Restaurant.Id);

                        booking.Restaurant.Booking
                        .Add (booking);
                }
                if (booking.Client != null) {
                        // Argumento OID y no colección.
                        booking.Client = (AndayComeGenNHibernate.EN.AndayCome.ClientEN)session.Load (typeof(AndayComeGenNHibernate.EN.AndayCome.ClientEN), booking.Client.Email);

                        booking.Client.Booking
                        .Add (booking);
                }

                session.Save (booking);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in BookingCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return booking.Id;
}

public void Modify (BookingEN booking)
{
        try
        {
                SessionInitializeTransaction ();
                BookingEN bookingEN = (BookingEN)session.Load (typeof(BookingEN), booking.Id);

                bookingEN.Date = booking.Date;


                bookingEN.Hour = booking.Hour;


                bookingEN.Guests = booking.Guests;

                session.Update (bookingEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in BookingCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                BookingEN bookingEN = (BookingEN)session.Load (typeof(BookingEN), id);
                session.Delete (bookingEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in BookingCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: BookingEN
public BookingEN ReadOID (int id
                          )
{
        BookingEN bookingEN = null;

        try
        {
                SessionInitializeTransaction ();
                bookingEN = (BookingEN)session.Get (typeof(BookingEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in BookingCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return bookingEN;
}

public System.Collections.Generic.IList<BookingEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<BookingEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(BookingEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<BookingEN>();
                else
                        result = session.CreateCriteria (typeof(BookingEN)).List<BookingEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in BookingCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.BookingEN> FilterByClient (string p_oid_client)
{
        System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.BookingEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM BookingEN self where SELECT b FROM BookingEN as b INNER JOIN b.Client as c where c.Email = :p_oid_client";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("BookingENfilterByClientHQL");
                query.SetParameter ("p_oid_client", p_oid_client);

                result = query.List<AndayComeGenNHibernate.EN.AndayCome.BookingEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in BookingCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.BookingEN> FilterByRestaurant (string p_name)
{
        System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.BookingEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM BookingEN self where SELECT b FROM BookingEN as b INNER JOIN b.Restaurant as r where r.Name = :p_name";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("BookingENfilterByRestaurantHQL");
                query.SetParameter ("p_name", p_name);

                result = query.List<AndayComeGenNHibernate.EN.AndayCome.BookingEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in BookingCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
