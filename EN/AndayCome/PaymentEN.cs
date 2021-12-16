
using System;
// Definición clase PaymentEN
namespace AndayComeGenNHibernate.EN.AndayCome
{
public partial class PaymentEN
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
 *	Atributo paypal
 */
private bool paypal;



/**
 *	Atributo date_sub
 */
private Nullable<DateTime> date_sub;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual AndayComeGenNHibernate.EN.AndayCome.ClientEN Client {
        get { return client; } set { client = value;  }
}



public virtual bool Paypal {
        get { return paypal; } set { paypal = value;  }
}



public virtual Nullable<DateTime> Date_sub {
        get { return date_sub; } set { date_sub = value;  }
}





public PaymentEN()
{
}



public PaymentEN(int id, AndayComeGenNHibernate.EN.AndayCome.ClientEN client, bool paypal, Nullable<DateTime> date_sub
                 )
{
        this.init (Id, client, paypal, date_sub);
}


public PaymentEN(PaymentEN payment)
{
        this.init (Id, payment.Client, payment.Paypal, payment.Date_sub);
}

private void init (int id
                   , AndayComeGenNHibernate.EN.AndayCome.ClientEN client, bool paypal, Nullable<DateTime> date_sub)
{
        this.Id = id;


        this.Client = client;

        this.Paypal = paypal;

        this.Date_sub = date_sub;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PaymentEN t = obj as PaymentEN;
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
