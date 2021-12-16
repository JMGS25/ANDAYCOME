

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
 *      Definition of the class RouteCEN
 *
 */
public partial class RouteCEN
{
private IRouteCAD _IRouteCAD;

public RouteCEN()
{
        this._IRouteCAD = new RouteCAD ();
}

public RouteCEN(IRouteCAD _IRouteCAD)
{
        this._IRouteCAD = _IRouteCAD;
}

public IRouteCAD get_IRouteCAD ()
{
        return this._IRouteCAD;
}

public int New_ (string p_creator, int p_countries, System.Collections.Generic.IList<int> p_restaurants, Nullable<DateTime> p_start_date, Nullable<DateTime> p_end_date, string p_photo, string p_description, string p_name)
{
        RouteEN routeEN = null;
        int oid;

        //Initialized RouteEN
        routeEN = new RouteEN ();

        if (p_creator != null) {
                // El argumento p_creator -> Property creator es oid = false
                // Lista de oids id
                routeEN.Creator = new AndayComeGenNHibernate.EN.AndayCome.ClientEN ();
                routeEN.Creator.Email = p_creator;
        }


        if (p_countries != -1) {
                // El argumento p_countries -> Property countries es oid = false
                // Lista de oids id
                routeEN.Countries = new AndayComeGenNHibernate.EN.AndayCome.CountryEN ();
                routeEN.Countries.Id = p_countries;
        }


        routeEN.Restaurants = new System.Collections.Generic.List<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN>();
        if (p_restaurants != null) {
                foreach (int item in p_restaurants) {
                        AndayComeGenNHibernate.EN.AndayCome.RestaurantEN en = new AndayComeGenNHibernate.EN.AndayCome.RestaurantEN ();
                        en.Id = item;
                        routeEN.Restaurants.Add (en);
                }
        }

        else{
                routeEN.Restaurants = new System.Collections.Generic.List<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN>();
        }

        routeEN.Start_date = p_start_date;

        routeEN.End_date = p_end_date;

        routeEN.Photo = p_photo;

        routeEN.Description = p_description;

        routeEN.Name = p_name;

        //Call to RouteCAD

        oid = _IRouteCAD.New_ (routeEN);
        return oid;
}

public void Modify (int p_Route_OID, Nullable<DateTime> p_start_date, Nullable<DateTime> p_end_date, string p_photo, string p_description, string p_name)
{
        RouteEN routeEN = null;

        //Initialized RouteEN
        routeEN = new RouteEN ();
        routeEN.Id = p_Route_OID;
        routeEN.Start_date = p_start_date;
        routeEN.End_date = p_end_date;
        routeEN.Photo = p_photo;
        routeEN.Description = p_description;
        routeEN.Name = p_name;
        //Call to RouteCAD

        _IRouteCAD.Modify (routeEN);
}

public void Destroy (int id
                     )
{
        _IRouteCAD.Destroy (id);
}

public void AddClient (int p_Route_OID, System.Collections.Generic.IList<string> p_clients_OIDs)
{
        //Call to RouteCAD

        _IRouteCAD.AddClient (p_Route_OID, p_clients_OIDs);
}
public void RemoveClient (int p_Route_OID, System.Collections.Generic.IList<string> p_clients_OIDs)
{
        //Call to RouteCAD

        _IRouteCAD.RemoveClient (p_Route_OID, p_clients_OIDs);
}
public System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RouteEN> FilterByCity (AndayComeGenNHibernate.Enumerated.AndayCome.CitiesEnum ? p_city)
{
        return _IRouteCAD.FilterByCity (p_city);
}
public System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RouteEN> FilterByRate (int ? p_rate)
{
        return _IRouteCAD.FilterByRate (p_rate);
}
public void AddBooking (int p_Route_OID, System.Collections.Generic.IList<int> p_booking_OIDs)
{
        //Call to RouteCAD

        _IRouteCAD.AddBooking (p_Route_OID, p_booking_OIDs);
}
public void RemoveBooking (int p_Route_OID, System.Collections.Generic.IList<int> p_booking_OIDs)
{
        //Call to RouteCAD

        _IRouteCAD.RemoveBooking (p_Route_OID, p_booking_OIDs);
}
public RouteEN ReadOID (int id
                        )
{
        RouteEN routeEN = null;

        routeEN = _IRouteCAD.ReadOID (id);
        return routeEN;
}

public System.Collections.Generic.IList<RouteEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<RouteEN> list = null;

        list = _IRouteCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RouteEN> FilterByRestaurant (string p_name)
{
        return _IRouteCAD.FilterByRestaurant (p_name);
}
public void AddRestaurant (int p_Route_OID, System.Collections.Generic.IList<int> p_restaurants_OIDs)
{
        //Call to RouteCAD

        _IRouteCAD.AddRestaurant (p_Route_OID, p_restaurants_OIDs);
}
public void DeleteRestaurant (int p_Route_OID, System.Collections.Generic.IList<int> p_restaurants_OIDs)
{
        //Call to RouteCAD

        _IRouteCAD.DeleteRestaurant (p_Route_OID, p_restaurants_OIDs);
}
}
}
