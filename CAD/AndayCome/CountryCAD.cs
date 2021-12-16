
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
 * Clase Country:
 *
 */

namespace AndayComeGenNHibernate.CAD.AndayCome
{
public partial class CountryCAD : BasicCAD, ICountryCAD
{
public CountryCAD() : base ()
{
}

public CountryCAD(ISession sessionAux) : base (sessionAux)
{
}



public CountryEN ReadOIDDefault (int id
                                 )
{
        CountryEN countryEN = null;

        try
        {
                SessionInitializeTransaction ();
                countryEN = (CountryEN)session.Get (typeof(CountryEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in CountryCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return countryEN;
}

public System.Collections.Generic.IList<CountryEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<CountryEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(CountryEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<CountryEN>();
                        else
                                result = session.CreateCriteria (typeof(CountryEN)).List<CountryEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in CountryCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (CountryEN country)
{
        try
        {
                SessionInitializeTransaction ();
                CountryEN countryEN = (CountryEN)session.Load (typeof(CountryEN), country.Id);

                countryEN.City = country.City;





                countryEN.Name = country.Name;

                session.Update (countryEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in CountryCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (CountryEN country)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (country);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in CountryCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return country.Id;
}

public void Modify (CountryEN country)
{
        try
        {
                SessionInitializeTransaction ();
                CountryEN countryEN = (CountryEN)session.Load (typeof(CountryEN), country.Id);

                countryEN.City = country.City;


                countryEN.Name = country.Name;

                session.Update (countryEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in CountryCAD.", ex);
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
                CountryEN countryEN = (CountryEN)session.Load (typeof(CountryEN), id);
                session.Delete (countryEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in CountryCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AddRestaurant (int p_Country_OID, System.Collections.Generic.IList<int> p_restaurant_OIDs)
{
        AndayComeGenNHibernate.EN.AndayCome.CountryEN countryEN = null;
        try
        {
                SessionInitializeTransaction ();
                countryEN = (CountryEN)session.Load (typeof(CountryEN), p_Country_OID);
                AndayComeGenNHibernate.EN.AndayCome.RestaurantEN restaurantENAux = null;
                if (countryEN.Restaurant == null) {
                        countryEN.Restaurant = new System.Collections.Generic.List<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN>();
                }

                foreach (int item in p_restaurant_OIDs) {
                        restaurantENAux = new AndayComeGenNHibernate.EN.AndayCome.RestaurantEN ();
                        restaurantENAux = (AndayComeGenNHibernate.EN.AndayCome.RestaurantEN)session.Load (typeof(AndayComeGenNHibernate.EN.AndayCome.RestaurantEN), item);
                        restaurantENAux.Country = countryEN;

                        countryEN.Restaurant.Add (restaurantENAux);
                }


                session.Update (countryEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in CountryCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void DeleteRestaurant (int p_Country_OID, System.Collections.Generic.IList<int> p_restaurant_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                AndayComeGenNHibernate.EN.AndayCome.CountryEN countryEN = null;
                countryEN = (CountryEN)session.Load (typeof(CountryEN), p_Country_OID);

                AndayComeGenNHibernate.EN.AndayCome.RestaurantEN restaurantENAux = null;
                if (countryEN.Restaurant != null) {
                        foreach (int item in p_restaurant_OIDs) {
                                restaurantENAux = (AndayComeGenNHibernate.EN.AndayCome.RestaurantEN)session.Load (typeof(AndayComeGenNHibernate.EN.AndayCome.RestaurantEN), item);
                                if (countryEN.Restaurant.Contains (restaurantENAux) == true) {
                                        countryEN.Restaurant.Remove (restaurantENAux);
                                        restaurantENAux.Country = null;
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_restaurant_OIDs you are trying to unrelationer, doesn't exist in CountryEN");
                        }
                }

                session.Update (countryEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in CountryCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
//Sin e: ReadOID
//Con e: CountryEN
public CountryEN ReadOID (int id
                          )
{
        CountryEN countryEN = null;

        try
        {
                SessionInitializeTransaction ();
                countryEN = (CountryEN)session.Get (typeof(CountryEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in CountryCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return countryEN;
}

public System.Collections.Generic.IList<CountryEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<CountryEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(CountryEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<CountryEN>();
                else
                        result = session.CreateCriteria (typeof(CountryEN)).List<CountryEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in CountryCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
