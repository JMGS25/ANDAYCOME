

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
 *      Definition of the class RatesCEN
 *
 */
public partial class RatesCEN
{
private IRatesCAD _IRatesCAD;

public RatesCEN()
{
        this._IRatesCAD = new RatesCAD ();
}

public RatesCEN(IRatesCAD _IRatesCAD)
{
        this._IRatesCAD = _IRatesCAD;
}

public IRatesCAD get_IRatesCAD ()
{
        return this._IRatesCAD;
}

public int New_ (string p_client, int p_rate)
{
        RatesEN ratesEN = null;
        int oid;

        //Initialized RatesEN
        ratesEN = new RatesEN ();

        if (p_client != null) {
                // El argumento p_client -> Property client es oid = false
                // Lista de oids id
                ratesEN.Client = new AndayComeGenNHibernate.EN.AndayCome.ClientEN ();
                ratesEN.Client.Email = p_client;
        }

        ratesEN.Rate = p_rate;

        //Call to RatesCAD

        oid = _IRatesCAD.New_ (ratesEN);
        return oid;
}

public void Modify (int p_Rates_OID, int p_rate)
{
        RatesEN ratesEN = null;

        //Initialized RatesEN
        ratesEN = new RatesEN ();
        ratesEN.Id = p_Rates_OID;
        ratesEN.Rate = p_rate;
        //Call to RatesCAD

        _IRatesCAD.Modify (ratesEN);
}

public void Destroy (int id
                     )
{
        _IRatesCAD.Destroy (id);
}

public void RateRestaurant (int p_Rates_OID, System.Collections.Generic.IList<int> p_restaurants_OIDs)
{
        //Call to RatesCAD

        _IRatesCAD.RateRestaurant (p_Rates_OID, p_restaurants_OIDs);
}
public void UnrateRestaurant (int p_Rates_OID, System.Collections.Generic.IList<int> p_restaurants_OIDs)
{
        //Call to RatesCAD

        _IRatesCAD.UnrateRestaurant (p_Rates_OID, p_restaurants_OIDs);
}
public void RateRoute (int p_Rates_OID, System.Collections.Generic.IList<int> p_route_OIDs)
{
        //Call to RatesCAD

        _IRatesCAD.RateRoute (p_Rates_OID, p_route_OIDs);
}
public void UnrateRoute (int p_Rates_OID, System.Collections.Generic.IList<int> p_route_OIDs)
{
        //Call to RatesCAD

        _IRatesCAD.UnrateRoute (p_Rates_OID, p_route_OIDs);
}
public RatesEN ReadOID (int id
                        )
{
        RatesEN ratesEN = null;

        ratesEN = _IRatesCAD.ReadOID (id);
        return ratesEN;
}

public System.Collections.Generic.IList<RatesEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<RatesEN> list = null;

        list = _IRatesCAD.ReadAll (first, size);
        return list;
}
}
}
