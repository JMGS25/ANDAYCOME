
using System;
// Definición clase GiveawayEN
namespace AndayComeGenNHibernate.EN.AndayCome
{
public partial class GiveawayEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo client
 */
private System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.ClientEN> client;



/**
 *	Atributo precio
 */
private int precio;



/**
 *	Atributo premium
 */
private bool premium;



/**
 *	Atributo premio
 */
private string premio;



/**
 *	Atributo winner
 */
private string winner;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.ClientEN> Client {
        get { return client; } set { client = value;  }
}



public virtual int Precio {
        get { return precio; } set { precio = value;  }
}



public virtual bool Premium {
        get { return premium; } set { premium = value;  }
}



public virtual string Premio {
        get { return premio; } set { premio = value;  }
}



public virtual string Winner {
        get { return winner; } set { winner = value;  }
}





public GiveawayEN()
{
        client = new System.Collections.Generic.List<AndayComeGenNHibernate.EN.AndayCome.ClientEN>();
}



public GiveawayEN(int id, System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.ClientEN> client, int precio, bool premium, string premio, string winner
                  )
{
        this.init (Id, client, precio, premium, premio, winner);
}


public GiveawayEN(GiveawayEN giveaway)
{
        this.init (Id, giveaway.Client, giveaway.Precio, giveaway.Premium, giveaway.Premio, giveaway.Winner);
}

private void init (int id
                   , System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.ClientEN> client, int precio, bool premium, string premio, string winner)
{
        this.Id = id;


        this.Client = client;

        this.Precio = precio;

        this.Premium = premium;

        this.Premio = premio;

        this.Winner = winner;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        GiveawayEN t = obj as GiveawayEN;
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
