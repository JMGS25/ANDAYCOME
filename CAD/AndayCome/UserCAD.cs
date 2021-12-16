
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
 * Clase User:
 *
 */

namespace AndayComeGenNHibernate.CAD.AndayCome
{
public partial class UserCAD : BasicCAD, IUserCAD
{
public UserCAD() : base ()
{
}

public UserCAD(ISession sessionAux) : base (sessionAux)
{
}



public UserEN ReadOIDDefault (string email
                              )
{
        UserEN userEN = null;

        try
        {
                SessionInitializeTransaction ();
                userEN = (UserEN)session.Get (typeof(UserEN), email);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in UserCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return userEN;
}

public System.Collections.Generic.IList<UserEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<UserEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(UserEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<UserEN>();
                        else
                                result = session.CreateCriteria (typeof(UserEN)).List<UserEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in UserCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (UserEN user)
{
        try
        {
                SessionInitializeTransaction ();
                UserEN userEN = (UserEN)session.Load (typeof(UserEN), user.Email);

                userEN.Tel = user.Tel;


                userEN.Photo = user.Photo;


                userEN.Pass = user.Pass;



                userEN.Language = user.Language;


                userEN.Name = user.Name;

                session.Update (userEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in UserCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public string New_ (UserEN user)
{
        try
        {
                SessionInitializeTransaction ();
                if (user.Country != null) {
                        // Argumento OID y no colección.
                        user.Country = (AndayComeGenNHibernate.EN.AndayCome.CountryEN)session.Load (typeof(AndayComeGenNHibernate.EN.AndayCome.CountryEN), user.Country.Id);

                        user.Country.Users
                        .Add (user);
                }

                session.Save (user);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in UserCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return user.Email;
}

public void Modify (UserEN user)
{
        try
        {
                SessionInitializeTransaction ();
                UserEN userEN = (UserEN)session.Load (typeof(UserEN), user.Email);

                userEN.Tel = user.Tel;


                userEN.Photo = user.Photo;


                userEN.Pass = user.Pass;


                userEN.Language = user.Language;


                userEN.Name = user.Name;

                session.Update (userEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in UserCAD.", ex);
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
                UserEN userEN = (UserEN)session.Load (typeof(UserEN), email);
                session.Delete (userEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in UserCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: UserEN
public UserEN ReadOID (string email
                       )
{
        UserEN userEN = null;

        try
        {
                SessionInitializeTransaction ();
                userEN = (UserEN)session.Get (typeof(UserEN), email);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in UserCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return userEN;
}

public System.Collections.Generic.IList<UserEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<UserEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(UserEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<UserEN>();
                else
                        result = session.CreateCriteria (typeof(UserEN)).List<UserEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in UserCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
