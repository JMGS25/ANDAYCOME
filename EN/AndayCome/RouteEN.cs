
using System;
// Definición clase RouteEN
namespace AndayComeGenNHibernate.EN.AndayCome
{
public partial class RouteEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo creator
 */
private AndayComeGenNHibernate.EN.AndayCome.ClientEN creator;



/**
 *	Atributo clients
 */
private System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.ClientEN> clients;



/**
 *	Atributo rates
 */
private System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RatesEN> rates;



/**
 *	Atributo booking
 */
private System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.BookingEN> booking;



/**
 *	Atributo countries
 */
private AndayComeGenNHibernate.EN.AndayCome.CountryEN countries;



/**
 *	Atributo comentarios
 */
private System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.ComentariosEN> comentarios;



/**
 *	Atributo restaurants
 */
private System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN> restaurants;



/**
 *	Atributo start_date
 */
private Nullable<DateTime> start_date;



/**
 *	Atributo end_date
 */
private Nullable<DateTime> end_date;



/**
 *	Atributo photo
 */
private string photo;



/**
 *	Atributo description
 */
private string description;



/**
 *	Atributo name
 */
private string name;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual AndayComeGenNHibernate.EN.AndayCome.ClientEN Creator {
        get { return creator; } set { creator = value;  }
}



public virtual System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.ClientEN> Clients {
        get { return clients; } set { clients = value;  }
}



public virtual System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RatesEN> Rates {
        get { return rates; } set { rates = value;  }
}



public virtual System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.BookingEN> Booking {
        get { return booking; } set { booking = value;  }
}



public virtual AndayComeGenNHibernate.EN.AndayCome.CountryEN Countries {
        get { return countries; } set { countries = value;  }
}



public virtual System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.ComentariosEN> Comentarios {
        get { return comentarios; } set { comentarios = value;  }
}



public virtual System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN> Restaurants {
        get { return restaurants; } set { restaurants = value;  }
}



public virtual Nullable<DateTime> Start_date {
        get { return start_date; } set { start_date = value;  }
}



public virtual Nullable<DateTime> End_date {
        get { return end_date; } set { end_date = value;  }
}



public virtual string Photo {
        get { return photo; } set { photo = value;  }
}



public virtual string Description {
        get { return description; } set { description = value;  }
}



public virtual string Name {
        get { return name; } set { name = value;  }
}





public RouteEN()
{
        clients = new System.Collections.Generic.List<AndayComeGenNHibernate.EN.AndayCome.ClientEN>();
        rates = new System.Collections.Generic.List<AndayComeGenNHibernate.EN.AndayCome.RatesEN>();
        booking = new System.Collections.Generic.List<AndayComeGenNHibernate.EN.AndayCome.BookingEN>();
        comentarios = new System.Collections.Generic.List<AndayComeGenNHibernate.EN.AndayCome.ComentariosEN>();
        restaurants = new System.Collections.Generic.List<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN>();
}



public RouteEN(int id, AndayComeGenNHibernate.EN.AndayCome.ClientEN creator, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.ClientEN> clients, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RatesEN> rates, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.BookingEN> booking, AndayComeGenNHibernate.EN.AndayCome.CountryEN countries, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.ComentariosEN> comentarios, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN> restaurants, Nullable<DateTime> start_date, Nullable<DateTime> end_date, string photo, string description, string name
               )
{
        this.init (Id, creator, clients, rates, booking, countries, comentarios, restaurants, start_date, end_date, photo, description, name);
}


public RouteEN(RouteEN route)
{
        this.init (Id, route.Creator, route.Clients, route.Rates, route.Booking, route.Countries, route.Comentarios, route.Restaurants, route.Start_date, route.End_date, route.Photo, route.Description, route.Name);
}

private void init (int id
                   , AndayComeGenNHibernate.EN.AndayCome.ClientEN creator, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.ClientEN> clients, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RatesEN> rates, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.BookingEN> booking, AndayComeGenNHibernate.EN.AndayCome.CountryEN countries, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.ComentariosEN> comentarios, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN> restaurants, Nullable<DateTime> start_date, Nullable<DateTime> end_date, string photo, string description, string name)
{
        this.Id = id;


        this.Creator = creator;

        this.Clients = clients;

        this.Rates = rates;

        this.Booking = booking;

        this.Countries = countries;

        this.Comentarios = comentarios;

        this.Restaurants = restaurants;

        this.Start_date = start_date;

        this.End_date = end_date;

        this.Photo = photo;

        this.Description = description;

        this.Name = name;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        RouteEN t = obj as RouteEN;
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
