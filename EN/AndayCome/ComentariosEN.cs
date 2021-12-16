
using System;
// Definición clase ComentariosEN
namespace AndayComeGenNHibernate.EN.AndayCome
{
public partial class ComentariosEN
{
/**
 *	Atributo content
 */
private string content;



/**
 *	Atributo client
 */
private AndayComeGenNHibernate.EN.AndayCome.ClientEN client;



/**
 *	Atributo route
 */
private AndayComeGenNHibernate.EN.AndayCome.RouteEN route;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo wall
 */
private AndayComeGenNHibernate.EN.AndayCome.WallEN wall;



/**
 *	Atributo date
 */
private Nullable<DateTime> date;






public virtual string Content {
        get { return content; } set { content = value;  }
}



public virtual AndayComeGenNHibernate.EN.AndayCome.ClientEN Client {
        get { return client; } set { client = value;  }
}



public virtual AndayComeGenNHibernate.EN.AndayCome.RouteEN Route {
        get { return route; } set { route = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual AndayComeGenNHibernate.EN.AndayCome.WallEN Wall {
        get { return wall; } set { wall = value;  }
}



public virtual Nullable<DateTime> Date {
        get { return date; } set { date = value;  }
}





public ComentariosEN()
{
}



public ComentariosEN(int id, string content, AndayComeGenNHibernate.EN.AndayCome.ClientEN client, AndayComeGenNHibernate.EN.AndayCome.RouteEN route, AndayComeGenNHibernate.EN.AndayCome.WallEN wall, Nullable<DateTime> date
                     )
{
        this.init (Id, content, client, route, wall, date);
}


public ComentariosEN(ComentariosEN comentarios)
{
        this.init (Id, comentarios.Content, comentarios.Client, comentarios.Route, comentarios.Wall, comentarios.Date);
}

private void init (int id
                   , string content, AndayComeGenNHibernate.EN.AndayCome.ClientEN client, AndayComeGenNHibernate.EN.AndayCome.RouteEN route, AndayComeGenNHibernate.EN.AndayCome.WallEN wall, Nullable<DateTime> date)
{
        this.Id = id;


        this.Content = content;

        this.Client = client;

        this.Route = route;

        this.Wall = wall;

        this.Date = date;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ComentariosEN t = obj as ComentariosEN;
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
