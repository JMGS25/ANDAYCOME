
using System;
// Definición clase ClientEN
namespace AndayComeGenNHibernate.EN.AndayCome
{
public partial class ClientEN                                                                       : AndayComeGenNHibernate.EN.AndayCome.UserEN


{
/**
 *	Atributo premium
 */
private bool premium;



/**
 *	Atributo created_routes
 */
private System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RouteEN> created_routes;



/**
 *	Atributo routes
 */
private System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RouteEN> routes;



/**
 *	Atributo tickets
 */
private System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.TicketEN> tickets;



/**
 *	Atributo payment
 */
private AndayComeGenNHibernate.EN.AndayCome.PaymentEN payment;



/**
 *	Atributo rates
 */
private System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RatesEN> rates;



/**
 *	Atributo giveaway
 */
private System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.GiveawayEN> giveaway;



/**
 *	Atributo comentarios
 */
private System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.ComentariosEN> comentarios;



/**
 *	Atributo restaurants
 */
private System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN> restaurants;



/**
 *	Atributo booking
 */
private System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.BookingEN> booking;






public virtual bool Premium {
        get { return premium; } set { premium = value;  }
}



public virtual System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RouteEN> Created_routes {
        get { return created_routes; } set { created_routes = value;  }
}



public virtual System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RouteEN> Routes {
        get { return routes; } set { routes = value;  }
}



public virtual System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.TicketEN> Tickets {
        get { return tickets; } set { tickets = value;  }
}



public virtual AndayComeGenNHibernate.EN.AndayCome.PaymentEN Payment {
        get { return payment; } set { payment = value;  }
}



public virtual System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RatesEN> Rates {
        get { return rates; } set { rates = value;  }
}



public virtual System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.GiveawayEN> Giveaway {
        get { return giveaway; } set { giveaway = value;  }
}



public virtual System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.ComentariosEN> Comentarios {
        get { return comentarios; } set { comentarios = value;  }
}



public virtual System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN> Restaurants {
        get { return restaurants; } set { restaurants = value;  }
}



public virtual System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.BookingEN> Booking {
        get { return booking; } set { booking = value;  }
}





public ClientEN() : base ()
{
        created_routes = new System.Collections.Generic.List<AndayComeGenNHibernate.EN.AndayCome.RouteEN>();
        routes = new System.Collections.Generic.List<AndayComeGenNHibernate.EN.AndayCome.RouteEN>();
        tickets = new System.Collections.Generic.List<AndayComeGenNHibernate.EN.AndayCome.TicketEN>();
        rates = new System.Collections.Generic.List<AndayComeGenNHibernate.EN.AndayCome.RatesEN>();
        giveaway = new System.Collections.Generic.List<AndayComeGenNHibernate.EN.AndayCome.GiveawayEN>();
        comentarios = new System.Collections.Generic.List<AndayComeGenNHibernate.EN.AndayCome.ComentariosEN>();
        restaurants = new System.Collections.Generic.List<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN>();
        booking = new System.Collections.Generic.List<AndayComeGenNHibernate.EN.AndayCome.BookingEN>();
}



public ClientEN(string email, bool premium, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RouteEN> created_routes, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RouteEN> routes, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.TicketEN> tickets, AndayComeGenNHibernate.EN.AndayCome.PaymentEN payment, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RatesEN> rates, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.GiveawayEN> giveaway, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.ComentariosEN> comentarios, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN> restaurants, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.BookingEN> booking
                , int tel, string photo, String pass, AndayComeGenNHibernate.EN.AndayCome.CountryEN country, AndayComeGenNHibernate.Enumerated.AndayCome.LanguageEnum language, string name
                )
{
        this.init (Email, premium, created_routes, routes, tickets, payment, rates, giveaway, comentarios, restaurants, booking, tel, photo, pass, country, language, name);
}


public ClientEN(ClientEN client)
{
        this.init (Email, client.Premium, client.Created_routes, client.Routes, client.Tickets, client.Payment, client.Rates, client.Giveaway, client.Comentarios, client.Restaurants, client.Booking, client.Tel, client.Photo, client.Pass, client.Country, client.Language, client.Name);
}

private void init (string email
                   , bool premium, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RouteEN> created_routes, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RouteEN> routes, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.TicketEN> tickets, AndayComeGenNHibernate.EN.AndayCome.PaymentEN payment, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RatesEN> rates, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.GiveawayEN> giveaway, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.ComentariosEN> comentarios, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN> restaurants, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.BookingEN> booking, int tel, string photo, String pass, AndayComeGenNHibernate.EN.AndayCome.CountryEN country, AndayComeGenNHibernate.Enumerated.AndayCome.LanguageEnum language, string name)
{
        this.Email = email;


        this.Premium = premium;

        this.Created_routes = created_routes;

        this.Routes = routes;

        this.Tickets = tickets;

        this.Payment = payment;

        this.Rates = rates;

        this.Giveaway = giveaway;

        this.Comentarios = comentarios;

        this.Restaurants = restaurants;

        this.Booking = booking;

        this.Tel = tel;

        this.Photo = photo;

        this.Pass = pass;

        this.Country = country;

        this.Language = language;

        this.Name = name;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ClientEN t = obj as ClientEN;
        if (t == null)
                return false;
        if (Email.Equals (t.Email))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Email.GetHashCode ();
        return hash;
}
}
}
