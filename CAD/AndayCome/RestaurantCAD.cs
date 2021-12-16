
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
 * Clase Restaurant:
 *
 */

namespace AndayComeGenNHibernate.CAD.AndayCome
{
public partial class RestaurantCAD : BasicCAD, IRestaurantCAD
{
public RestaurantCAD() : base ()
{
}

public RestaurantCAD(ISession sessionAux) : base (sessionAux)
{
}



public RestaurantEN ReadOIDDefault (int id
                                    )
{
        RestaurantEN restaurantEN = null;

        try
        {
                SessionInitializeTransaction ();
                restaurantEN = (RestaurantEN)session.Get (typeof(RestaurantEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in RestaurantCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return restaurantEN;
}

public System.Collections.Generic.IList<RestaurantEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<RestaurantEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(RestaurantEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<RestaurantEN>();
                        else
                                result = session.CreateCriteria (typeof(RestaurantEN)).List<RestaurantEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in RestaurantCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (RestaurantEN restaurant)
{
        try
        {
                SessionInitializeTransaction ();
                RestaurantEN restaurantEN = (RestaurantEN)session.Load (typeof(RestaurantEN), restaurant.Id);








                restaurantEN.Menu = restaurant.Menu;


                restaurantEN.Photo = restaurant.Photo;


                restaurantEN.Name = restaurant.Name;


                restaurantEN.Street = restaurant.Street;



                restaurantEN.Capacity = restaurant.Capacity;

                session.Update (restaurantEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in RestaurantCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (RestaurantEN restaurant)
{
        try
        {
                SessionInitializeTransaction ();
                if (restaurant.Restaurant_Owner != null) {
                        // Argumento OID y no colección.
                        restaurant.Restaurant_Owner = (AndayComeGenNHibernate.EN.AndayCome.Restaurant_OwnerEN)session.Load (typeof(AndayComeGenNHibernate.EN.AndayCome.Restaurant_OwnerEN), restaurant.Restaurant_Owner.Email);

                        restaurant.Restaurant_Owner.Restaurants
                        .Add (restaurant);
                }
                if (restaurant.Country != null) {
                        // Argumento OID y no colección.
                        restaurant.Country = (AndayComeGenNHibernate.EN.AndayCome.CountryEN)session.Load (typeof(AndayComeGenNHibernate.EN.AndayCome.CountryEN), restaurant.Country.Id);

                        restaurant.Country.Restaurant
                        .Add (restaurant);
                }

                session.Save (restaurant);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in RestaurantCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return restaurant.Id;
}

public void Modify (RestaurantEN restaurant)
{
        try
        {
                SessionInitializeTransaction ();
                RestaurantEN restaurantEN = (RestaurantEN)session.Load (typeof(RestaurantEN), restaurant.Id);

                restaurantEN.Menu = restaurant.Menu;


                restaurantEN.Photo = restaurant.Photo;


                restaurantEN.Name = restaurant.Name;


                restaurantEN.Street = restaurant.Street;


                restaurantEN.Capacity = restaurant.Capacity;

                session.Update (restaurantEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in RestaurantCAD.", ex);
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
                RestaurantEN restaurantEN = (RestaurantEN)session.Load (typeof(RestaurantEN), id);
                session.Delete (restaurantEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in RestaurantCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AddClient (int p_Restaurant_OID, System.Collections.Generic.IList<string> p_client_OIDs)
{
        AndayComeGenNHibernate.EN.AndayCome.RestaurantEN restaurantEN = null;
        try
        {
                SessionInitializeTransaction ();
                restaurantEN = (RestaurantEN)session.Load (typeof(RestaurantEN), p_Restaurant_OID);
                AndayComeGenNHibernate.EN.AndayCome.ClientEN clientENAux = null;
                if (restaurantEN.Client == null) {
                        restaurantEN.Client = new System.Collections.Generic.List<AndayComeGenNHibernate.EN.AndayCome.ClientEN>();
                }

                foreach (string item in p_client_OIDs) {
                        clientENAux = new AndayComeGenNHibernate.EN.AndayCome.ClientEN ();
                        clientENAux = (AndayComeGenNHibernate.EN.AndayCome.ClientEN)session.Load (typeof(AndayComeGenNHibernate.EN.AndayCome.ClientEN), item);
                        clientENAux.Restaurants.Add (restaurantEN);

                        restaurantEN.Client.Add (clientENAux);
                }


                session.Update (restaurantEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in RestaurantCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void RemoveClient (int p_Restaurant_OID, System.Collections.Generic.IList<string> p_client_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                AndayComeGenNHibernate.EN.AndayCome.RestaurantEN restaurantEN = null;
                restaurantEN = (RestaurantEN)session.Load (typeof(RestaurantEN), p_Restaurant_OID);

                AndayComeGenNHibernate.EN.AndayCome.ClientEN clientENAux = null;
                if (restaurantEN.Client != null) {
                        foreach (string item in p_client_OIDs) {
                                clientENAux = (AndayComeGenNHibernate.EN.AndayCome.ClientEN)session.Load (typeof(AndayComeGenNHibernate.EN.AndayCome.ClientEN), item);
                                if (restaurantEN.Client.Contains (clientENAux) == true) {
                                        restaurantEN.Client.Remove (clientENAux);
                                        clientENAux.Restaurants.Remove (restaurantEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_client_OIDs you are trying to unrelationer, doesn't exist in RestaurantEN");
                        }
                }

                session.Update (restaurantEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in RestaurantCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN> FilterByTag (string p_oid_tag)
{
        System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM RestaurantEN self where SELECT r FROM RestaurantEN as r INNER JOIN r.Tags as t where t.Name = :p_oid_tag";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("RestaurantENfilterByTagHQL");
                query.SetParameter ("p_oid_tag", p_oid_tag);

                result = query.List<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in RestaurantCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
//Sin e: ReadOID
//Con e: RestaurantEN
public RestaurantEN ReadOID (int id
                             )
{
        RestaurantEN restaurantEN = null;

        try
        {
                SessionInitializeTransaction ();
                restaurantEN = (RestaurantEN)session.Get (typeof(RestaurantEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in RestaurantCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return restaurantEN;
}

public System.Collections.Generic.IList<RestaurantEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<RestaurantEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(RestaurantEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<RestaurantEN>();
                else
                        result = session.CreateCriteria (typeof(RestaurantEN)).List<RestaurantEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in RestaurantCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN> FilterbyRate (int ? p_rate)
{
        System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM RestaurantEN self where SELECT res FROM RestaurantEN as res WHERE :p_rate <= ( SELECT AVG(rat.Rate) as avg from RestaurantEN as res INNER JOIN res.Rates as rat)";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("RestaurantENfilterbyRateHQL");
                query.SetParameter ("p_rate", p_rate);

                result = query.List<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in RestaurantCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
