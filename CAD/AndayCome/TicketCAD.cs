
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
 * Clase Ticket:
 *
 */

namespace AndayComeGenNHibernate.CAD.AndayCome
{
public partial class TicketCAD : BasicCAD, ITicketCAD
{
public TicketCAD() : base ()
{
}

public TicketCAD(ISession sessionAux) : base (sessionAux)
{
}



public TicketEN ReadOIDDefault (int id
                                )
{
        TicketEN ticketEN = null;

        try
        {
                SessionInitializeTransaction ();
                ticketEN = (TicketEN)session.Get (typeof(TicketEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in TicketCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return ticketEN;
}

public System.Collections.Generic.IList<TicketEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<TicketEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(TicketEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<TicketEN>();
                        else
                                result = session.CreateCriteria (typeof(TicketEN)).List<TicketEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in TicketCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (TicketEN ticket)
{
        try
        {
                SessionInitializeTransaction ();
                TicketEN ticketEN = (TicketEN)session.Load (typeof(TicketEN), ticket.Id);



                ticketEN.Date = ticket.Date;


                ticketEN.Total = ticket.Total;

                session.Update (ticketEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in TicketCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (TicketEN ticket)
{
        try
        {
                SessionInitializeTransaction ();
                if (ticket.Client != null) {
                        // Argumento OID y no colección.
                        ticket.Client = (AndayComeGenNHibernate.EN.AndayCome.ClientEN)session.Load (typeof(AndayComeGenNHibernate.EN.AndayCome.ClientEN), ticket.Client.Email);

                        ticket.Client.Tickets
                        .Add (ticket);
                }
                if (ticket.Restaurant != null) {
                        // Argumento OID y no colección.
                        ticket.Restaurant = (AndayComeGenNHibernate.EN.AndayCome.RestaurantEN)session.Load (typeof(AndayComeGenNHibernate.EN.AndayCome.RestaurantEN), ticket.Restaurant.Id);

                        ticket.Restaurant.Tickets
                        .Add (ticket);
                }

                session.Save (ticket);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in TicketCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return ticket.Id;
}

public void Modify (TicketEN ticket)
{
        try
        {
                SessionInitializeTransaction ();
                TicketEN ticketEN = (TicketEN)session.Load (typeof(TicketEN), ticket.Id);

                ticketEN.Date = ticket.Date;


                ticketEN.Total = ticket.Total;

                session.Update (ticketEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in TicketCAD.", ex);
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
                TicketEN ticketEN = (TicketEN)session.Load (typeof(TicketEN), id);
                session.Delete (ticketEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in TicketCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: TicketEN
public TicketEN ReadOID (int id
                         )
{
        TicketEN ticketEN = null;

        try
        {
                SessionInitializeTransaction ();
                ticketEN = (TicketEN)session.Get (typeof(TicketEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in TicketCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return ticketEN;
}

public System.Collections.Generic.IList<TicketEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<TicketEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(TicketEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<TicketEN>();
                else
                        result = session.CreateCriteria (typeof(TicketEN)).List<TicketEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in TicketCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
