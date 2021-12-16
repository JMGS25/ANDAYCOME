
using System;
// Definición clase RestaurantEN
namespace AndayComeGenNHibernate.EN.AndayCome
{
public partial class RestaurantEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo restaurant_Owner
 */
private AndayComeGenNHibernate.EN.AndayCome.Restaurant_OwnerEN restaurant_Owner;



/**
 *	Atributo tickets
 */
private System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.TicketEN> tickets;



/**
 *	Atributo rates
 */
private System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RatesEN> rates;



/**
 *	Atributo booking
 */
private System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.BookingEN> booking;



/**
 *	Atributo routes
 */
private System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RouteEN> routes;



/**
 *	Atributo country
 */
private AndayComeGenNHibernate.EN.AndayCome.CountryEN country;



/**
 *	Atributo client
 */
private System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.ClientEN> client;



/**
 *	Atributo menu
 */
private string menu;



/**
 *	Atributo photo
 */
private string photo;



/**
 *	Atributo name
 */
private string name;



/**
 *	Atributo street
 */
private string street;



/**
 *	Atributo tags
 */
private System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.TagsEN> tags;



/**
 *	Atributo capacity
 */
private int capacity;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual AndayComeGenNHibernate.EN.AndayCome.Restaurant_OwnerEN Restaurant_Owner {
        get { return restaurant_Owner; } set { restaurant_Owner = value;  }
}



public virtual System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.TicketEN> Tickets {
        get { return tickets; } set { tickets = value;  }
}



public virtual System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RatesEN> Rates {
        get { return rates; } set { rates = value;  }
}



public virtual System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.BookingEN> Booking {
        get { return booking; } set { booking = value;  }
}



public virtual System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RouteEN> Routes {
        get { return routes; } set { routes = value;  }
}



public virtual AndayComeGenNHibernate.EN.AndayCome.CountryEN Country {
        get { return country; } set { country = value;  }
}



public virtual System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.ClientEN> Client {
        get { return client; } set { client = value;  }
}



public virtual string Menu {
        get { return menu; } set { menu = value;  }
}



public virtual string Photo {
        get { return photo; } set { photo = value;  }
}



public virtual string Name {
        get { return name; } set { name = value;  }
}



public virtual string Street {
        get { return street; } set { street = value;  }
}



public virtual System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.TagsEN> Tags {
        get { return tags; } set { tags = value;  }
}



public virtual int Capacity {
        get { return capacity; } set { capacity = value;  }
}





public RestaurantEN()
{
        tickets = new System.Collections.Generic.List<AndayComeGenNHibernate.EN.AndayCome.TicketEN>();
        rates = new System.Collections.Generic.List<AndayComeGenNHibernate.EN.AndayCome.RatesEN>();
        booking = new System.Collections.Generic.List<AndayComeGenNHibernate.EN.AndayCome.BookingEN>();
        routes = new System.Collections.Generic.List<AndayComeGenNHibernate.EN.AndayCome.RouteEN>();
        client = new System.Collections.Generic.List<AndayComeGenNHibernate.EN.AndayCome.ClientEN>();
        tags = new System.Collections.Generic.List<AndayComeGenNHibernate.EN.AndayCome.TagsEN>();
}



public RestaurantEN(int id, AndayComeGenNHibernate.EN.AndayCome.Restaurant_OwnerEN restaurant_Owner, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.TicketEN> tickets, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RatesEN> rates, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.BookingEN> booking, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RouteEN> routes, AndayComeGenNHibernate.EN.AndayCome.CountryEN country, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.ClientEN> client, string menu, string photo, string name, string street, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.TagsEN> tags, int capacity
                    )
{
        this.init (Id, restaurant_Owner, tickets, rates, booking, routes, country, client, menu, photo, name, street, tags, capacity);
}


public RestaurantEN(RestaurantEN restaurant)
{
        this.init (Id, restaurant.Restaurant_Owner, restaurant.Tickets, restaurant.Rates, restaurant.Booking, restaurant.Routes, restaurant.Country, restaurant.Client, restaurant.Menu, restaurant.Photo, restaurant.Name, restaurant.Street, restaurant.Tags, restaurant.Capacity);
}

private void init (int id
                   , AndayComeGenNHibernate.EN.AndayCome.Restaurant_OwnerEN restaurant_Owner, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.TicketEN> tickets, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RatesEN> rates, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.BookingEN> booking, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RouteEN> routes, AndayComeGenNHibernate.EN.AndayCome.CountryEN country, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.ClientEN> client, string menu, string photo, string name, string street, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.TagsEN> tags, int capacity)
{
        this.Id = id;


        this.Restaurant_Owner = restaurant_Owner;

        this.Tickets = tickets;

        this.Rates = rates;

        this.Booking = booking;

        this.Routes = routes;

        this.Country = country;

        this.Client = client;

        this.Menu = menu;

        this.Photo = photo;

        this.Name = name;

        this.Street = street;

        this.Tags = tags;

        this.Capacity = capacity;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        RestaurantEN t = obj as RestaurantEN;
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
