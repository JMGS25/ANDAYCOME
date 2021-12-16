

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
 *      Definition of the class CountryCEN
 *
 */
public partial class CountryCEN
{
private ICountryCAD _ICountryCAD;

public CountryCEN()
{
        this._ICountryCAD = new CountryCAD ();
}

public CountryCEN(ICountryCAD _ICountryCAD)
{
        this._ICountryCAD = _ICountryCAD;
}

public ICountryCAD get_ICountryCAD ()
{
        return this._ICountryCAD;
}

public int New_ (AndayComeGenNHibernate.Enumerated.AndayCome.CitiesEnum p_city, string p_name)
{
        CountryEN countryEN = null;
        int oid;

        //Initialized CountryEN
        countryEN = new CountryEN ();
        countryEN.City = p_city;

        countryEN.Name = p_name;

        //Call to CountryCAD

        oid = _ICountryCAD.New_ (countryEN);
        return oid;
}

public void Modify (int p_Country_OID, AndayComeGenNHibernate.Enumerated.AndayCome.CitiesEnum p_city, string p_name)
{
        CountryEN countryEN = null;

        //Initialized CountryEN
        countryEN = new CountryEN ();
        countryEN.Id = p_Country_OID;
        countryEN.City = p_city;
        countryEN.Name = p_name;
        //Call to CountryCAD

        _ICountryCAD.Modify (countryEN);
}

public void Destroy (int id
                     )
{
        _ICountryCAD.Destroy (id);
}

public void AddRestaurant (int p_Country_OID, System.Collections.Generic.IList<int> p_restaurant_OIDs)
{
        //Call to CountryCAD

        _ICountryCAD.AddRestaurant (p_Country_OID, p_restaurant_OIDs);
}
public void DeleteRestaurant (int p_Country_OID, System.Collections.Generic.IList<int> p_restaurant_OIDs)
{
        //Call to CountryCAD

        _ICountryCAD.DeleteRestaurant (p_Country_OID, p_restaurant_OIDs);
}
public CountryEN ReadOID (int id
                          )
{
        CountryEN countryEN = null;

        countryEN = _ICountryCAD.ReadOID (id);
        return countryEN;
}

public System.Collections.Generic.IList<CountryEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CountryEN> list = null;

        list = _ICountryCAD.ReadAll (first, size);
        return list;
}
}
}
