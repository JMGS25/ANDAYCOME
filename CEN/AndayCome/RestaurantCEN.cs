

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
 *      Definition of the class RestaurantCEN
 *
 */
public partial class RestaurantCEN
{
private IRestaurantCAD _IRestaurantCAD;

public RestaurantCEN()
{
        this._IRestaurantCAD = new RestaurantCAD ();
}

public RestaurantCEN(IRestaurantCAD _IRestaurantCAD)
{
        this._IRestaurantCAD = _IRestaurantCAD;
}

public IRestaurantCAD get_IRestaurantCAD ()
{
        return this._IRestaurantCAD;
}

public int New_ (string p_restaurant_Owner, int p_country, string p_menu, string p_photo, string p_name, string p_street, int p_capacity)
{
        RestaurantEN restaurantEN = null;
        int oid;

        //Initialized RestaurantEN
        restaurantEN = new RestaurantEN ();

        if (p_restaurant_Owner != null) {
                // El argumento p_restaurant_Owner -> Property restaurant_Owner es oid = false
                // Lista de oids id
                restaurantEN.Restaurant_Owner = new AndayComeGenNHibernate.EN.AndayCome.Restaurant_OwnerEN ();
                restaurantEN.Restaurant_Owner.Email = p_restaurant_Owner;
        }


        if (p_country != -1) {
                // El argumento p_country -> Property country es oid = false
                // Lista de oids id
                restaurantEN.Country = new AndayComeGenNHibernate.EN.AndayCome.CountryEN ();
                restaurantEN.Country.Id = p_country;
        }

        restaurantEN.Menu = p_menu;

        restaurantEN.Photo = p_photo;

        restaurantEN.Name = p_name;

        restaurantEN.Street = p_street;

        restaurantEN.Capacity = p_capacity;

        //Call to RestaurantCAD

        oid = _IRestaurantCAD.New_ (restaurantEN);
        return oid;
}

public void Modify (int p_Restaurant_OID, string p_menu, string p_photo, string p_name, string p_street, int p_capacity)
{
        RestaurantEN restaurantEN = null;

        //Initialized RestaurantEN
        restaurantEN = new RestaurantEN ();
        restaurantEN.Id = p_Restaurant_OID;
        restaurantEN.Menu = p_menu;
        restaurantEN.Photo = p_photo;
        restaurantEN.Name = p_name;
        restaurantEN.Street = p_street;
        restaurantEN.Capacity = p_capacity;
        //Call to RestaurantCAD

        _IRestaurantCAD.Modify (restaurantEN);
}

public void Destroy (int id
                     )
{
        _IRestaurantCAD.Destroy (id);
}

public void AddClient (int p_Restaurant_OID, System.Collections.Generic.IList<string> p_client_OIDs)
{
        //Call to RestaurantCAD

        _IRestaurantCAD.AddClient (p_Restaurant_OID, p_client_OIDs);
}
public void RemoveClient (int p_Restaurant_OID, System.Collections.Generic.IList<string> p_client_OIDs)
{
        //Call to RestaurantCAD

        _IRestaurantCAD.RemoveClient (p_Restaurant_OID, p_client_OIDs);
}
public System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN> FilterByTag (string p_oid_tag)
{
        return _IRestaurantCAD.FilterByTag (p_oid_tag);
}
public RestaurantEN ReadOID (int id
                             )
{
        RestaurantEN restaurantEN = null;

        restaurantEN = _IRestaurantCAD.ReadOID (id);
        return restaurantEN;
}

public System.Collections.Generic.IList<RestaurantEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<RestaurantEN> list = null;

        list = _IRestaurantCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN> FilterbyRate (int ? p_rate)
{
        return _IRestaurantCAD.FilterbyRate (p_rate);
}
}
}
