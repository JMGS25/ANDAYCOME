
using System;
// Definición clase WallEN
namespace AndayComeGenNHibernate.EN.AndayCome
{
public partial class WallEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo comentarios
 */
private System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.ComentariosEN> comentarios;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.ComentariosEN> Comentarios {
        get { return comentarios; } set { comentarios = value;  }
}





public WallEN()
{
        comentarios = new System.Collections.Generic.List<AndayComeGenNHibernate.EN.AndayCome.ComentariosEN>();
}



public WallEN(int id, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.ComentariosEN> comentarios
              )
{
        this.init (Id, comentarios);
}


public WallEN(WallEN wall)
{
        this.init (Id, wall.Comentarios);
}

private void init (int id
                   , System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.ComentariosEN> comentarios)
{
        this.Id = id;


        this.Comentarios = comentarios;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        WallEN t = obj as WallEN;
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
