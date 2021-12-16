

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
 *      Definition of the class Restaurant_OwnerCEN
 *
 */
public partial class Restaurant_OwnerCEN
{
private IRestaurant_OwnerCAD _IRestaurant_OwnerCAD;

public Restaurant_OwnerCEN()
{
        this._IRestaurant_OwnerCAD = new Restaurant_OwnerCAD ();
}

public Restaurant_OwnerCEN(IRestaurant_OwnerCAD _IRestaurant_OwnerCAD)
{
        this._IRestaurant_OwnerCAD = _IRestaurant_OwnerCAD;
}

public IRestaurant_OwnerCAD get_IRestaurant_OwnerCAD ()
{
        return this._IRestaurant_OwnerCAD;
}

public string New_ (int p_tel, string p_photo, String p_pass, int p_country, string p_email, AndayComeGenNHibernate.Enumerated.AndayCome.LanguageEnum p_language, string p_name)
{
        Restaurant_OwnerEN restaurant_OwnerEN = null;
        string oid;

        //Initialized Restaurant_OwnerEN
        restaurant_OwnerEN = new Restaurant_OwnerEN ();
        restaurant_OwnerEN.Tel = p_tel;

        restaurant_OwnerEN.Photo = p_photo;

        restaurant_OwnerEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);


        if (p_country != -1) {
                // El argumento p_country -> Property country es oid = false
                // Lista de oids email
                restaurant_OwnerEN.Country = new AndayComeGenNHibernate.EN.AndayCome.CountryEN ();
                restaurant_OwnerEN.Country.Id = p_country;
        }

        restaurant_OwnerEN.Email = p_email;

        restaurant_OwnerEN.Language = p_language;

        restaurant_OwnerEN.Name = p_name;

        //Call to Restaurant_OwnerCAD

        oid = _IRestaurant_OwnerCAD.New_ (restaurant_OwnerEN);
        return oid;
}

public void Modify (string p_Restaurant_Owner_OID, int p_tel, string p_photo, String p_pass, AndayComeGenNHibernate.Enumerated.AndayCome.LanguageEnum p_language, string p_name)
{
        Restaurant_OwnerEN restaurant_OwnerEN = null;

        //Initialized Restaurant_OwnerEN
        restaurant_OwnerEN = new Restaurant_OwnerEN ();
        restaurant_OwnerEN.Email = p_Restaurant_Owner_OID;
        restaurant_OwnerEN.Tel = p_tel;
        restaurant_OwnerEN.Photo = p_photo;
        restaurant_OwnerEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);
        restaurant_OwnerEN.Language = p_language;
        restaurant_OwnerEN.Name = p_name;
        //Call to Restaurant_OwnerCAD

        _IRestaurant_OwnerCAD.Modify (restaurant_OwnerEN);
}

public void Destroy (string email
                     )
{
        _IRestaurant_OwnerCAD.Destroy (email);
}

public Restaurant_OwnerEN ReadOID (string email)
{
        Restaurant_OwnerEN restaurant_OwnerEN = null;

        restaurant_OwnerEN = _IRestaurant_OwnerCAD.ReadOID (email);
        return restaurant_OwnerEN;
}

public System.Collections.Generic.IList<Restaurant_OwnerEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<Restaurant_OwnerEN> list = null;

        list = _IRestaurant_OwnerCAD.ReadAll (first, size);
        return list;
}
}
}
