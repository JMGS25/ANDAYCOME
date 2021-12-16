
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
 * Clase Restaurant_Owner:
 *
 */

namespace AndayComeGenNHibernate.CAD.AndayCome
{
public partial class Restaurant_OwnerCAD : BasicCAD, IRestaurant_OwnerCAD
{
public Restaurant_OwnerCAD() : base ()
{
}

public Restaurant_OwnerCAD(ISession sessionAux) : base (sessionAux)
{
}



public Restaurant_OwnerEN ReadOIDDefault (string email
                                          )
{
        Restaurant_OwnerEN restaurant_OwnerEN = null;

        try
        {
                SessionInitializeTransaction ();
                restaurant_OwnerEN = (Restaurant_OwnerEN)session.Get (typeof(Restaurant_OwnerEN), email);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in Restaurant_OwnerCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return restaurant_OwnerEN;
}

public System.Collections.Generic.IList<Restaurant_OwnerEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<Restaurant_OwnerEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(Restaurant_OwnerEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<Restaurant_OwnerEN>();
                        else
                                result = session.CreateCriteria (typeof(Restaurant_OwnerEN)).List<Restaurant_OwnerEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in Restaurant_OwnerCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (Restaurant_OwnerEN restaurant_Owner)
{
        try
        {
                SessionInitializeTransaction ();
                Restaurant_OwnerEN restaurant_OwnerEN = (Restaurant_OwnerEN)session.Load (typeof(Restaurant_OwnerEN), restaurant_Owner.Email);

                session.Update (restaurant_OwnerEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in Restaurant_OwnerCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public string New_ (Restaurant_OwnerEN restaurant_Owner)
{
        try
        {
                SessionInitializeTransaction ();
                if (restaurant_Owner.Country != null) {
                        // Argumento OID y no colección.
                        restaurant_Owner.Country = (AndayComeGenNHibernate.EN.AndayCome.CountryEN)session.Load (typeof(AndayComeGenNHibernate.EN.AndayCome.CountryEN), restaurant_Owner.Country.Id);

                        restaurant_Owner.Country.Users
                        .Add (restaurant_Owner);
                }

                session.Save (restaurant_Owner);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in Restaurant_OwnerCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return restaurant_Owner.Email;
}

public void Modify (Restaurant_OwnerEN restaurant_Owner)
{
        try
        {
                SessionInitializeTransaction ();
                Restaurant_OwnerEN restaurant_OwnerEN = (Restaurant_OwnerEN)session.Load (typeof(Restaurant_OwnerEN), restaurant_Owner.Email);

                restaurant_OwnerEN.Tel = restaurant_Owner.Tel;


                restaurant_OwnerEN.Photo = restaurant_Owner.Photo;


                restaurant_OwnerEN.Pass = restaurant_Owner.Pass;


                restaurant_OwnerEN.Language = restaurant_Owner.Language;


                restaurant_OwnerEN.Name = restaurant_Owner.Name;

                session.Update (restaurant_OwnerEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in Restaurant_OwnerCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (string email
                     )
{
        try
        {
                SessionInitializeTransaction ();
                Restaurant_OwnerEN restaurant_OwnerEN = (Restaurant_OwnerEN)session.Load (typeof(Restaurant_OwnerEN), email);
                session.Delete (restaurant_OwnerEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in Restaurant_OwnerCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: Restaurant_OwnerEN
public Restaurant_OwnerEN ReadOID (string email
                                   )
{
        Restaurant_OwnerEN restaurant_OwnerEN = null;

        try
        {
                SessionInitializeTransaction ();
                restaurant_OwnerEN = (Restaurant_OwnerEN)session.Get (typeof(Restaurant_OwnerEN), email);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in Restaurant_OwnerCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return restaurant_OwnerEN;
}

public System.Collections.Generic.IList<Restaurant_OwnerEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<Restaurant_OwnerEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(Restaurant_OwnerEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<Restaurant_OwnerEN>();
                else
                        result = session.CreateCriteria (typeof(Restaurant_OwnerEN)).List<Restaurant_OwnerEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in Restaurant_OwnerCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
