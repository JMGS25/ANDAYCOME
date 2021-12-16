
using System;
using System.Text;
using AndayComeGenNHibernate.CEN.AndayCome;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using AndayComeGenNHibernate.EN.AndayCome;
using AndayComeGenNHibernate.Exceptions;


/*
 * Clase Route:
 *
 */

namespace AndayComeGenNHibernate.CAD.AndayCome
{
public partial class RouteCAD : BasicCAD, IRouteCAD
{
public RouteCAD() : base ()
{
}

public RouteCAD(ISession sessionAux) : base (sessionAux)
{
}



public RouteEN ReadOIDDefault (int id
                               )
{
        RouteEN routeEN = null;

        try
        {
                SessionInitializeTransaction ();
                routeEN = (RouteEN)session.Get (typeof(RouteEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in RouteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return routeEN;
}

public System.Collections.Generic.IList<RouteEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<RouteEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(RouteEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<RouteEN>();
                        else
                                result = session.CreateCriteria (typeof(RouteEN)).List<RouteEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in RouteCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (RouteEN route)
{
        try
        {
                SessionInitializeTransaction ();
                RouteEN routeEN = (RouteEN)session.Load (typeof(RouteEN), route.Id);








                routeEN.Start_date = route.Start_date;


                routeEN.End_date = route.End_date;


                routeEN.Photo = route.Photo;


                routeEN.Description = route.Description;


                routeEN.Name = route.Name;

                session.Update (routeEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in RouteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (RouteEN route)
{
        try
        {
                SessionInitializeTransaction ();
                if (route.Creator != null) {
                        // Argumento OID y no colección.
                        route.Creator = (AndayComeGenNHibernate.EN.AndayCome.ClientEN)session.Load (typeof(AndayComeGenNHibernate.EN.AndayCome.ClientEN), route.Creator.Email);

                        route.Creator.Created_routes
                        .Add (route);
                }
                if (route.Countries != null) {
                        // Argumento OID y no colección.
                        route.Countries = (AndayComeGenNHibernate.EN.AndayCome.CountryEN)session.Load (typeof(AndayComeGenNHibernate.EN.AndayCome.CountryEN), route.Countries.Id);

                        route.Countries.Route
                        .Add (route);
                }
                if (route.Restaurants != null) {
                        for (int i = 0; i < route.Restaurants.Count; i++) {
                                route.Restaurants [i] = (AndayComeGenNHibernate.EN.AndayCome.RestaurantEN)session.Load (typeof(AndayComeGenNHibernate.EN.AndayCome.RestaurantEN), route.Restaurants [i].Id);
                                route.Restaurants [i].Routes.Add (route);
                        }
                }

                session.Save (route);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in RouteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return route.Id;
}

public void Modify (RouteEN route)
{
        try
        {
                SessionInitializeTransaction ();
                RouteEN routeEN = (RouteEN)session.Load (typeof(RouteEN), route.Id);

                routeEN.Start_date = route.Start_date;


                routeEN.End_date = route.End_date;


                routeEN.Photo = route.Photo;


                routeEN.Description = route.Description;


                routeEN.Name = route.Name;

                session.Update (routeEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in RouteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                RouteEN routeEN = (RouteEN)session.Load (typeof(RouteEN), id);
                session.Delete (routeEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in RouteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AddClient (int p_Route_OID, System.Collections.Generic.IList<string> p_clients_OIDs)
{
        AndayComeGenNHibernate.EN.AndayCome.RouteEN routeEN = null;
        try
        {
                SessionInitializeTransaction ();
                routeEN = (RouteEN)session.Load (typeof(RouteEN), p_Route_OID);
                AndayComeGenNHibernate.EN.AndayCome.ClientEN clientsENAux = null;
                if (routeEN.Clients == null) {
                        routeEN.Clients = new System.Collections.Generic.List<AndayComeGenNHibernate.EN.AndayCome.ClientEN>();
                }

                foreach (string item in p_clients_OIDs) {
                        clientsENAux = new AndayComeGenNHibernate.EN.AndayCome.ClientEN ();
                        clientsENAux = (AndayComeGenNHibernate.EN.AndayCome.ClientEN)session.Load (typeof(AndayComeGenNHibernate.EN.AndayCome.ClientEN), item);
                        clientsENAux.Routes.Add (routeEN);

                        routeEN.Clients.Add (clientsENAux);
                }


                session.Update (routeEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in RouteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void RemoveClient (int p_Route_OID, System.Collections.Generic.IList<string> p_clients_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                AndayComeGenNHibernate.EN.AndayCome.RouteEN routeEN = null;
                routeEN = (RouteEN)session.Load (typeof(RouteEN), p_Route_OID);

                AndayComeGenNHibernate.EN.AndayCome.ClientEN clientsENAux = null;
                if (routeEN.Clients != null) {
                        foreach (string item in p_clients_OIDs) {
                                clientsENAux = (AndayComeGenNHibernate.EN.AndayCome.ClientEN)session.Load (typeof(AndayComeGenNHibernate.EN.AndayCome.ClientEN), item);
                                if (routeEN.Clients.Contains (clientsENAux) == true) {
                                        routeEN.Clients.Remove (clientsENAux);
                                        clientsENAux.Routes.Remove (routeEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_clients_OIDs you are trying to unrelationer, doesn't exist in RouteEN");
                        }
                }

                session.Update (routeEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in RouteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RouteEN> FilterByCity (AndayComeGenNHibernate.Enumerated.AndayCome.CitiesEnum ? p_city)
{
        System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RouteEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM RouteEN self where  FROM RouteEN as r WHERE r.Countries.City = :p_city";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("RouteENfilterByCityHQL");
                query.SetParameter ("p_city", p_city);

                result = query.List<AndayComeGenNHibernate.EN.AndayCome.RouteEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in RouteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RouteEN> FilterByRate (int ? p_rate)
{
        System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RouteEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM RouteEN self where SELECT res FROM RouteEN as res WHERE :p_rate <= ( SELECT AVG(rat.Rate) as avg from RouteEN as res INNER JOIN res.Rates as rat)";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("RouteENfilterByRateHQL");
                query.SetParameter ("p_rate", p_rate);

                result = query.List<AndayComeGenNHibernate.EN.AndayCome.RouteEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in RouteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void AddBooking (int p_Route_OID, System.Collections.Generic.IList<int> p_booking_OIDs)
{
        AndayComeGenNHibernate.EN.AndayCome.RouteEN routeEN = null;
        try
        {
                SessionInitializeTransaction ();
                routeEN = (RouteEN)session.Load (typeof(RouteEN), p_Route_OID);
                AndayComeGenNHibernate.EN.AndayCome.BookingEN bookingENAux = null;
                if (routeEN.Booking == null) {
                        routeEN.Booking = new System.Collections.Generic.List<AndayComeGenNHibernate.EN.AndayCome.BookingEN>();
                }

                foreach (int item in p_booking_OIDs) {
                        bookingENAux = new AndayComeGenNHibernate.EN.AndayCome.BookingEN ();
                        bookingENAux = (AndayComeGenNHibernate.EN.AndayCome.BookingEN)session.Load (typeof(AndayComeGenNHibernate.EN.AndayCome.BookingEN), item);
                        bookingENAux.Routes.Add (routeEN);

                        routeEN.Booking.Add (bookingENAux);
                }


                session.Update (routeEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in RouteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void RemoveBooking (int p_Route_OID, System.Collections.Generic.IList<int> p_booking_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                AndayComeGenNHibernate.EN.AndayCome.RouteEN routeEN = null;
                routeEN = (RouteEN)session.Load (typeof(RouteEN), p_Route_OID);

                AndayComeGenNHibernate.EN.AndayCome.BookingEN bookingENAux = null;
                if (routeEN.Booking != null) {
                        foreach (int item in p_booking_OIDs) {
                                bookingENAux = (AndayComeGenNHibernate.EN.AndayCome.BookingEN)session.Load (typeof(AndayComeGenNHibernate.EN.AndayCome.BookingEN), item);
                                if (routeEN.Booking.Contains (bookingENAux) == true) {
                                        routeEN.Booking.Remove (bookingENAux);
                                        bookingENAux.Routes.Remove (routeEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_booking_OIDs you are trying to unrelationer, doesn't exist in RouteEN");
                        }
                }

                session.Update (routeEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in RouteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
//Sin e: ReadOID
//Con e: RouteEN
public RouteEN ReadOID (int id
                        )
{
        RouteEN routeEN = null;

        try
        {
                SessionInitializeTransaction ();
                routeEN = (RouteEN)session.Get (typeof(RouteEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in RouteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return routeEN;
}

public System.Collections.Generic.IList<RouteEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<RouteEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(RouteEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<RouteEN>();
                else
                        result = session.CreateCriteria (typeof(RouteEN)).List<RouteEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in RouteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RouteEN> FilterByRestaurant (string p_name)
{
        System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RouteEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM RouteEN self where SELECT r FROM RouteEN as r INNER JOIN r.Restaurants as t where t.Name = :p_name";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("RouteENfilterByRestaurantHQL");
                query.SetParameter ("p_name", p_name);

                result = query.List<AndayComeGenNHibernate.EN.AndayCome.RouteEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in RouteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void AddRestaurant (int p_Route_OID, System.Collections.Generic.IList<int> p_restaurants_OIDs)
{
        AndayComeGenNHibernate.EN.AndayCome.RouteEN routeEN = null;
        try
        {
                SessionInitializeTransaction ();
                routeEN = (RouteEN)session.Load (typeof(RouteEN), p_Route_OID);
                AndayComeGenNHibernate.EN.AndayCome.RestaurantEN restaurantsENAux = null;
                if (routeEN.Restaurants == null) {
                        routeEN.Restaurants = new System.Collections.Generic.List<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN>();
                }

                foreach (int item in p_restaurants_OIDs) {
                        restaurantsENAux = new AndayComeGenNHibernate.EN.AndayCome.RestaurantEN ();
                        restaurantsENAux = (AndayComeGenNHibernate.EN.AndayCome.RestaurantEN)session.Load (typeof(AndayComeGenNHibernate.EN.AndayCome.RestaurantEN), item);
                        restaurantsENAux.Routes.Add (routeEN);

                        routeEN.Restaurants.Add (restaurantsENAux);
                }


                session.Update (routeEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in RouteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void DeleteRestaurant (int p_Route_OID, System.Collections.Generic.IList<int> p_restaurants_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                AndayComeGenNHibernate.EN.AndayCome.RouteEN routeEN = null;
                routeEN = (RouteEN)session.Load (typeof(RouteEN), p_Route_OID);

                AndayComeGenNHibernate.EN.AndayCome.RestaurantEN restaurantsENAux = null;
                if (routeEN.Restaurants != null) {
                        foreach (int item in p_restaurants_OIDs) {
                                restaurantsENAux = (AndayComeGenNHibernate.EN.AndayCome.RestaurantEN)session.Load (typeof(AndayComeGenNHibernate.EN.AndayCome.RestaurantEN), item);
                                if (routeEN.Restaurants.Contains (restaurantsENAux) == true) {
                                        routeEN.Restaurants.Remove (restaurantsENAux);
                                        restaurantsENAux.Routes.Remove (routeEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_restaurants_OIDs you are trying to unrelationer, doesn't exist in RouteEN");
                        }
                }

                session.Update (routeEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in RouteCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
