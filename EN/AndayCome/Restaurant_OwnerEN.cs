
using System;
// Definición clase Restaurant_OwnerEN
namespace AndayComeGenNHibernate.EN.AndayCome
{
public partial class Restaurant_OwnerEN                                                                     : AndayComeGenNHibernate.EN.AndayCome.UserEN


{
/**
 *	Atributo restaurants
 */
private System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN> restaurants;






public virtual System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN> Restaurants {
        get { return restaurants; } set { restaurants = value;  }
}





public Restaurant_OwnerEN() : base ()
{
        restaurants = new System.Collections.Generic.List<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN>();
}



public Restaurant_OwnerEN(string email, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN> restaurants
                          , int tel, string photo, String pass, AndayComeGenNHibernate.EN.AndayCome.CountryEN country, AndayComeGenNHibernate.Enumerated.AndayCome.LanguageEnum language, string name
                          )
{
        this.init (Email, restaurants, tel, photo, pass, country, language, name);
}


public Restaurant_OwnerEN(Restaurant_OwnerEN restaurant_Owner)
{
        this.init (Email, restaurant_Owner.Restaurants, restaurant_Owner.Tel, restaurant_Owner.Photo, restaurant_Owner.Pass, restaurant_Owner.Country, restaurant_Owner.Language, restaurant_Owner.Name);
}

private void init (string email
                   , System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN> restaurants, int tel, string photo, String pass, AndayComeGenNHibernate.EN.AndayCome.CountryEN country, AndayComeGenNHibernate.Enumerated.AndayCome.LanguageEnum language, string name)
{
        this.Email = email;


        this.Restaurants = restaurants;

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
        Restaurant_OwnerEN t = obj as Restaurant_OwnerEN;
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
