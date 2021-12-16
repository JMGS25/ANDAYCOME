
using System;
// Definición clase TicketEN
namespace AndayComeGenNHibernate.EN.AndayCome
{
public partial class TicketEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo client
 */
private AndayComeGenNHibernate.EN.AndayCome.ClientEN client;



/**
 *	Atributo restaurant
 */
private AndayComeGenNHibernate.EN.AndayCome.RestaurantEN restaurant;



/**
 *	Atributo date
 */
private Nullable<DateTime> date;



/**
 *	Atributo total
 */
private float total;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual AndayComeGenNHibernate.EN.AndayCome.ClientEN Client {
        get { return client; } set { client = value;  }
}



public virtual AndayComeGenNHibernate.EN.AndayCome.RestaurantEN Restaurant {
        get { return restaurant; } set { restaurant = value;  }
}



public virtual Nullable<DateTime> Date {
        get { return date; } set { date = value;  }
}



public virtual float Total {
        get { return total; } set { total = value;  }
}





public TicketEN()
{
}



public TicketEN(int id, AndayComeGenNHibernate.EN.AndayCome.ClientEN client, AndayComeGenNHibernate.EN.AndayCome.RestaurantEN restaurant, Nullable<DateTime> date, float total
                )
{
        this.init (Id, client, restaurant, date, total);
}


public TicketEN(TicketEN ticket)
{
        this.init (Id, ticket.Client, ticket.Restaurant, ticket.Date, ticket.Total);
}

private void init (int id
                   , AndayComeGenNHibernate.EN.AndayCome.ClientEN client, AndayComeGenNHibernate.EN.AndayCome.RestaurantEN restaurant, Nullable<DateTime> date, float total)
{
        this.Id = id;


        this.Client = client;

        this.Restaurant = restaurant;

        this.Date = date;

        this.Total = total;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        TicketEN t = obj as TicketEN;
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
