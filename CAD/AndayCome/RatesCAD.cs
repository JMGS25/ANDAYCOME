
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
 * Clase Rates:
 *
 */

namespace AndayComeGenNHibernate.CAD.AndayCome
{
public partial class RatesCAD : BasicCAD, IRatesCAD
{
public RatesCAD() : base ()
{
}

public RatesCAD(ISession sessionAux) : base (sessionAux)
{
}



public RatesEN ReadOIDDefault (int id
                               )
{
        RatesEN ratesEN = null;

        try
        {
                SessionInitializeTransaction ();
                ratesEN = (RatesEN)session.Get (typeof(RatesEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in RatesCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return ratesEN;
}

public System.Collections.Generic.IList<RatesEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<RatesEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(RatesEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<RatesEN>();
                        else
                                result = session.CreateCriteria (typeof(RatesEN)).List<RatesEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in RatesCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (RatesEN rates)
{
        try
        {
                SessionInitializeTransaction ();
                RatesEN ratesEN = (RatesEN)session.Load (typeof(RatesEN), rates.Id);




                ratesEN.Rate = rates.Rate;

                session.Update (ratesEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in RatesCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (RatesEN rates)
{
        try
        {
                SessionInitializeTransaction ();
                if (rates.Client != null) {
                        // Argumento OID y no colección.
                        rates.Client = (AndayComeGenNHibernate.EN.AndayCome.ClientEN)session.Load (typeof(AndayComeGenNHibernate.EN.AndayCome.ClientEN), rates.Client.Email);

                        rates.Client.Rates
                        .Add (rates);
                }

                session.Save (rates);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in RatesCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return rates.Id;
}

public void Modify (RatesEN rates)
{
        try
        {
                SessionInitializeTransaction ();
                RatesEN ratesEN = (RatesEN)session.Load (typeof(RatesEN), rates.Id);

                ratesEN.Rate = rates.Rate;

                session.Update (ratesEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in RatesCAD.", ex);
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
                RatesEN ratesEN = (RatesEN)session.Load (typeof(RatesEN), id);
                session.Delete (ratesEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in RatesCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void RateRestaurant (int p_Rates_OID, System.Collections.Generic.IList<int> p_restaurants_OIDs)
{
        AndayComeGenNHibernate.EN.AndayCome.RatesEN ratesEN = null;
        try
        {
                SessionInitializeTransaction ();
                ratesEN = (RatesEN)session.Load (typeof(RatesEN), p_Rates_OID);
                AndayComeGenNHibernate.EN.AndayCome.RestaurantEN restaurantsENAux = null;
                if (ratesEN.Restaurants == null) {
                        ratesEN.Restaurants = new System.Collections.Generic.List<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN>();
                }

                foreach (int item in p_restaurants_OIDs) {
                        restaurantsENAux = new AndayComeGenNHibernate.EN.AndayCome.RestaurantEN ();
                        restaurantsENAux = (AndayComeGenNHibernate.EN.AndayCome.RestaurantEN)session.Load (typeof(AndayComeGenNHibernate.EN.AndayCome.RestaurantEN), item);
                        restaurantsENAux.Rates.Add (ratesEN);

                        ratesEN.Restaurants.Add (restaurantsENAux);
                }


                session.Update (ratesEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in RatesCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void UnrateRestaurant (int p_Rates_OID, System.Collections.Generic.IList<int> p_restaurants_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                AndayComeGenNHibernate.EN.AndayCome.RatesEN ratesEN = null;
                ratesEN = (RatesEN)session.Load (typeof(RatesEN), p_Rates_OID);

                AndayComeGenNHibernate.EN.AndayCome.RestaurantEN restaurantsENAux = null;
                if (ratesEN.Restaurants != null) {
                        foreach (int item in p_restaurants_OIDs) {
                                restaurantsENAux = (AndayComeGenNHibernate.EN.AndayCome.RestaurantEN)session.Load (typeof(AndayComeGenNHibernate.EN.AndayCome.RestaurantEN), item);
                                if (ratesEN.Restaurants.Contains (restaurantsENAux) == true) {
                                        ratesEN.Restaurants.Remove (restaurantsENAux);
                                        restaurantsENAux.Rates.Remove (ratesEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_restaurants_OIDs you are trying to unrelationer, doesn't exist in RatesEN");
                        }
                }

                session.Update (ratesEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in RatesCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void RateRoute (int p_Rates_OID, System.Collections.Generic.IList<int> p_route_OIDs)
{
        AndayComeGenNHibernate.EN.AndayCome.RatesEN ratesEN = null;
        try
        {
                SessionInitializeTransaction ();
                ratesEN = (RatesEN)session.Load (typeof(RatesEN), p_Rates_OID);
                AndayComeGenNHibernate.EN.AndayCome.RouteEN routeENAux = null;
                if (ratesEN.Route == null) {
                        ratesEN.Route = new System.Collections.Generic.List<AndayComeGenNHibernate.EN.AndayCome.RouteEN>();
                }

                foreach (int item in p_route_OIDs) {
                        routeENAux = new AndayComeGenNHibernate.EN.AndayCome.RouteEN ();
                        routeENAux = (AndayComeGenNHibernate.EN.AndayCome.RouteEN)session.Load (typeof(AndayComeGenNHibernate.EN.AndayCome.RouteEN), item);
                        routeENAux.Rates.Add (ratesEN);

                        ratesEN.Route.Add (routeENAux);
                }


                session.Update (ratesEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in RatesCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void UnrateRoute (int p_Rates_OID, System.Collections.Generic.IList<int> p_route_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                AndayComeGenNHibernate.EN.AndayCome.RatesEN ratesEN = null;
                ratesEN = (RatesEN)session.Load (typeof(RatesEN), p_Rates_OID);

                AndayComeGenNHibernate.EN.AndayCome.RouteEN routeENAux = null;
                if (ratesEN.Route != null) {
                        foreach (int item in p_route_OIDs) {
                                routeENAux = (AndayComeGenNHibernate.EN.AndayCome.RouteEN)session.Load (typeof(AndayComeGenNHibernate.EN.AndayCome.RouteEN), item);
                                if (ratesEN.Route.Contains (routeENAux) == true) {
                                        ratesEN.Route.Remove (routeENAux);
                                        routeENAux.Rates.Remove (ratesEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_route_OIDs you are trying to unrelationer, doesn't exist in RatesEN");
                        }
                }

                session.Update (ratesEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in RatesCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
//Sin e: ReadOID
//Con e: RatesEN
public RatesEN ReadOID (int id
                        )
{
        RatesEN ratesEN = null;

        try
        {
                SessionInitializeTransaction ();
                ratesEN = (RatesEN)session.Get (typeof(RatesEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in RatesCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return ratesEN;
}

public System.Collections.Generic.IList<RatesEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<RatesEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(RatesEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<RatesEN>();
                else
                        result = session.CreateCriteria (typeof(RatesEN)).List<RatesEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in RatesCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
