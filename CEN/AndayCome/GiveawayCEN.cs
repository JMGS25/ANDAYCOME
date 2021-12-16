

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using AndayComeGenNHibernate.Exceptions;

using AndayComeGenNHibernate.EN.AndayCome;
using AndayComeGenNHibernate.CAD.AndayCome;


namespace AndayComeGenNHibernate.CEN.AndayCome
{
/*
 *      Definition of the class GiveawayCEN
 *
 */
public partial class GiveawayCEN
{
private IGiveawayCAD _IGiveawayCAD;

public GiveawayCEN()
{
        this._IGiveawayCAD = new GiveawayCAD ();
}

public GiveawayCEN(IGiveawayCAD _IGiveawayCAD)
{
        this._IGiveawayCAD = _IGiveawayCAD;
}

public IGiveawayCAD get_IGiveawayCAD ()
{
        return this._IGiveawayCAD;
}

public int New_ (int p_precio, bool p_premium, string p_premio)
{
        GiveawayEN giveawayEN = null;
        int oid;

        //Initialized GiveawayEN
        giveawayEN = new GiveawayEN ();
        giveawayEN.Precio = p_precio;

        giveawayEN.Premium = p_premium;

        giveawayEN.Premio = p_premio;

        //Call to GiveawayCAD

        oid = _IGiveawayCAD.New_ (giveawayEN);
        return oid;
}

public void Modify (int p_Giveaway_OID, int p_precio, bool p_premium, string p_premio)
{
        GiveawayEN giveawayEN = null;

        //Initialized GiveawayEN
        giveawayEN = new GiveawayEN ();
        giveawayEN.Id = p_Giveaway_OID;
        giveawayEN.Precio = p_precio;
        giveawayEN.Premium = p_premium;
        giveawayEN.Premio = p_premio;
        //Call to GiveawayCAD

        _IGiveawayCAD.Modify (giveawayEN);
}

public void Destroy (int id
                     )
{
        _IGiveawayCAD.Destroy (id);
}

public void AddClient (int p_Giveaway_OID, System.Collections.Generic.IList<string> p_client_OIDs)
{
        //Call to GiveawayCAD

        _IGiveawayCAD.AddClient (p_Giveaway_OID, p_client_OIDs);
}
public void RemoveClient (int p_Giveaway_OID, System.Collections.Generic.IList<string> p_client_OIDs)
{
        //Call to GiveawayCAD

        _IGiveawayCAD.RemoveClient (p_Giveaway_OID, p_client_OIDs);
}
public GiveawayEN ReadOID (int id
                           )
{
        GiveawayEN giveawayEN = null;

        giveawayEN = _IGiveawayCAD.ReadOID (id);
        return giveawayEN;
}

public System.Collections.Generic.IList<GiveawayEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<GiveawayEN> list = null;

        list = _IGiveawayCAD.ReadAll (first, size);
        return list;
}
}
}
