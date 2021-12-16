
using System;
// Definición clase BookingEN
namespace AndayComeGenNHibernate.EN.AndayCome
{
public partial class BookingEN
{
/**
 *	Atributo restaurant
 */
private AndayComeGenNHibernate.EN.AndayCome.RestaurantEN restaurant;



/**
 *	Atributo routes
 */
private System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RouteEN> routes;



/**
 *	Atributo client
 */
private AndayComeGenNHibernate.EN.AndayCome.ClientEN client;



/**
 *	Atributo date
 */
private Nullable<DateTime> date;



/**
 *	Atributo hour
 */
private Nullable<DateTime> hour;



/**
 *	Atributo guests
 */
private int guests;



/**
 *	Atributo id
 */
private int id;






public virtual AndayComeGenNHibernate.EN.AndayCome.RestaurantEN Restaurant {
        get { return restaurant; } set { restaurant = value;  }
}



public virtual System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RouteEN> Routes {
        get { return routes; } set { routes = value;  }
}



public virtual AndayComeGenNHibernate.EN.AndayCome.ClientEN Client {
        get { return client; } set { client = value;  }
}



public virtual Nullable<DateTime> Date {
        get { return date; } set { date = value;  }
}



public virtual Nullable<DateTime> Hour {
        get { return hour; } set { hour = value;  }
}



public virtual int Guests {
        get { return guests; } set { guests = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}





public BookingEN()
{
        routes = new System.Collections.Generic.List<AndayComeGenNHibernate.EN.AndayCome.RouteEN>();
}



public BookingEN(int id, AndayComeGenNHibernate.EN.AndayCome.RestaurantEN restaurant, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RouteEN> routes, AndayComeGenNHibernate.EN.AndayCome.ClientEN client, Nullable<DateTime> date, Nullable<DateTime> hour, int guests
                 )
{
        this.init (Id, restaurant, routes, client, date, hour, guests);
}


public BookingEN(BookingEN booking)
{
        this.init (Id, booking.Restaurant, booking.Routes, booking.Client, booking.Date, booking.Hour, booking.Guests);
}

private void init (int id
                   , AndayComeGenNHibernate.EN.AndayCome.RestaurantEN restaurant, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RouteEN> routes, AndayComeGenNHibernate.EN.AndayCome.ClientEN client, Nullable<DateTime> date, Nullable<DateTime> hour, int guests)
{
        this.Id = id;


        this.Restaurant = restaurant;

        this.Routes = routes;

        this.Client = client;

        this.Date = date;

        this.Hour = hour;

        this.Guests = guests;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        BookingEN t = obj as BookingEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
