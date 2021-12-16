

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using AndayComeGenNHibernate.Exceptions;

using AndayComeGenNHibernate.EN.AndayCome;
using AndayComeGenNHibernate.CAD.AndayCome;


namespace AndayComeGenNHibernate.CEN.AndayCome
{
/*
 *      Definition of the class TicketCEN
 *
 */
public partial class TicketCEN
{
private ITicketCAD _ITicketCAD;

public TicketCEN()
{
        this._ITicketCAD = new TicketCAD ();
}

public TicketCEN(ITicketCAD _ITicketCAD)
{
        this._ITicketCAD = _ITicketCAD;
}

public ITicketCAD get_ITicketCAD ()
{
        return this._ITicketCAD;
}

public int New_ (string p_client, int p_restaurant, Nullable<DateTime> p_date, float p_total)
{
        TicketEN ticketEN = null;
        int oid;

        //Initialized TicketEN
        ticketEN = new TicketEN ();

        if (p_client != null) {
                // El argumento p_client -> Property client es oid = false
                // Lista de oids id
                ticketEN.Client = new AndayComeGenNHibernate.EN.AndayCome.ClientEN ();
                ticketEN.Client.Email = p_client;
        }


        if (p_restaurant != -1) {
                // El argumento p_restaurant -> Property restaurant es oid = false
                // Lista de oids id
                ticketEN.Restaurant = new AndayComeGenNHibernate.EN.AndayCome.RestaurantEN ();
                ticketEN.Restaurant.Id = p_restaurant;
        }

        ticketEN.Date = p_date;

        ticketEN.Total = p_total;

        //Call to TicketCAD

        oid = _ITicketCAD.New_ (ticketEN);
        return oid;
}

public void Modify (int p_Ticket_OID, Nullable<DateTime> p_date, float p_total)
{
        TicketEN ticketEN = null;

        //Initialized TicketEN
        ticketEN = new TicketEN ();
        ticketEN.Id = p_Ticket_OID;
        ticketEN.Date = p_date;
        ticketEN.Total = p_total;
        //Call to TicketCAD

        _ITicketCAD.Modify (ticketEN);
}

public void Destroy (int id
                     )
{
        _ITicketCAD.Destroy (id);
}

public TicketEN ReadOID (int id
                         )
{
        TicketEN ticketEN = null;

        ticketEN = _ITicketCAD.ReadOID (id);
        return ticketEN;
}

public System.Collections.Generic.IList<TicketEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<TicketEN> list = null;

        list = _ITicketCAD.ReadAll (first, size);
        return list;
}
}
}
