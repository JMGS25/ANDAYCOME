
using System;
// Definición clase RatesEN
namespace AndayComeGenNHibernate.EN.AndayCome
{
public partial class RatesEN
{
/**
 *	Atributo route
 */
private System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RouteEN> route;



/**
 *	Atributo restaurants
 */
private System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN> restaurants;



/**
 *	Atributo client
 */
private AndayComeGenNHibernate.EN.AndayCome.ClientEN client;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo rate
 */
private int rate;






public virtual System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RouteEN> Route {
        get { return route; } set { route = value;  }
}



public virtual System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN> Restaurants {
        get { return restaurants; } set { restaurants = value;  }
}



public virtual AndayComeGenNHibernate.EN.AndayCome.ClientEN Client {
        get { return client; } set { client = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual int Rate {
        get { return rate; } set { rate = value;  }
}





public RatesEN()
{
        route = new System.Collections.Generic.List<AndayComeGenNHibernate.EN.AndayCome.RouteEN>();
        restaurants = new System.Collections.Generic.List<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN>();
}



public RatesEN(int id, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RouteEN> route, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN> restaurants, AndayComeGenNHibernate.EN.AndayCome.ClientEN client, int rate
               )
{
        this.init (Id, route, restaurants, client, rate);
}


public RatesEN(RatesEN rates)
{
        this.init (Id, rates.Route, rates.Restaurants, rates.Client, rates.Rate);
}

private void init (int id
                   , System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RouteEN> route, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN> restaurants, AndayComeGenNHibernate.EN.AndayCome.ClientEN client, int rate)
{
        this.Id = id;


        this.Route = route;

        this.Restaurants = restaurants;

        this.Client = client;

        this.Rate = rate;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        RatesEN t = obj as RatesEN;
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
