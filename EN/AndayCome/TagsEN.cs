
using System;
// Definición clase TagsEN
namespace AndayComeGenNHibernate.EN.AndayCome
{
public partial class TagsEN
{
/**
 *	Atributo name
 */
private string name;



/**
 *	Atributo restaurant
 */
private System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN> restaurant;






public virtual string Name {
        get { return name; } set { name = value;  }
}



public virtual System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN> Restaurant {
        get { return restaurant; } set { restaurant = value;  }
}





public TagsEN()
{
        restaurant = new System.Collections.Generic.List<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN>();
}



public TagsEN(string name, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN> restaurant
              )
{
        this.init (Name, restaurant);
}


public TagsEN(TagsEN tags)
{
        this.init (Name, tags.Restaurant);
}

private void init (string name
                   , System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN> restaurant)
{
        this.Name = name;


        this.Restaurant = restaurant;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        TagsEN t = obj as TagsEN;
        if (t == null)
                return false;
        if (Name.Equals (t.Name))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Name.GetHashCode ();
        return hash;
}
}
}
