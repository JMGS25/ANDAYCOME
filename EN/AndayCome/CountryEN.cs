
using System;
// Definición clase CountryEN
namespace AndayComeGenNHibernate.EN.AndayCome
{
public partial class CountryEN
{
/**
 *	Atributo city
 */
private AndayComeGenNHibernate.Enumerated.AndayCome.CitiesEnum city;



/**
 *	Atributo users
 */
private System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.UserEN> users;



/**
 *	Atributo route
 */
private System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RouteEN> route;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo restaurant
 */
private System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN> restaurant;



/**
 *	Atributo name
 */
private string name;






public virtual AndayComeGenNHibernate.Enumerated.AndayCome.CitiesEnum City {
        get { return city; } set { city = value;  }
}



public virtual System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.UserEN> Users {
        get { return users; } set { users = value;  }
}



public virtual System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RouteEN> Route {
        get { return route; } set { route = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN> Restaurant {
        get { return restaurant; } set { restaurant = value;  }
}



public virtual string Name {
        get { return name; } set { name = value;  }
}





public CountryEN()
{
        users = new System.Collections.Generic.List<AndayComeGenNHibernate.EN.AndayCome.UserEN>();
        route = new System.Collections.Generic.List<AndayComeGenNHibernate.EN.AndayCome.RouteEN>();
        restaurant = new System.Collections.Generic.List<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN>();
}



public CountryEN(int id, AndayComeGenNHibernate.Enumerated.AndayCome.CitiesEnum city, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.UserEN> users, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RouteEN> route, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN> restaurant, string name
                 )
{
        this.init (Id, city, users, route, restaurant, name);
}


public CountryEN(CountryEN country)
{
        this.init (Id, country.City, country.Users, country.Route, country.Restaurant, country.Name);
}

private void init (int id
                   , AndayComeGenNHibernate.Enumerated.AndayCome.CitiesEnum city, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.UserEN> users, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RouteEN> route, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN> restaurant, string name)
{
        this.Id = id;


        this.City = city;

        this.Users = users;

        this.Route = route;

        this.Restaurant = restaurant;

        this.Name = name;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CountryEN t = obj as CountryEN;
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
