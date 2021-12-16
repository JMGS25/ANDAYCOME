
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
 * Clase Client:
 *
 */

namespace AndayComeGenNHibernate.CAD.AndayCome
{
public partial class ClientCAD : BasicCAD, IClientCAD
{
public ClientCAD() : base ()
{
}

public ClientCAD(ISession sessionAux) : base (sessionAux)
{
}



public ClientEN ReadOIDDefault (string email
                                )
{
        ClientEN clientEN = null;

        try
        {
                SessionInitializeTransaction ();
                clientEN = (ClientEN)session.Get (typeof(ClientEN), email);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in ClientCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return clientEN;
}

public System.Collections.Generic.IList<ClientEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ClientEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ClientEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ClientEN>();
                        else
                                result = session.CreateCriteria (typeof(ClientEN)).List<ClientEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in ClientCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ClientEN client)
{
        try
        {
                SessionInitializeTransaction ();
                ClientEN clientEN = (ClientEN)session.Load (typeof(ClientEN), client.Email);

                clientEN.Premium = client.Premium;










                session.Update (clientEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in ClientCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public string New_ (ClientEN client)
{
        try
        {
                SessionInitializeTransaction ();
                if (client.Country != null) {
                        // Argumento OID y no colección.
                        client.Country = (AndayComeGenNHibernate.EN.AndayCome.CountryEN)session.Load (typeof(AndayComeGenNHibernate.EN.AndayCome.CountryEN), client.Country.Id);

                        client.Country.Users
                        .Add (client);
                }

                session.Save (client);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in ClientCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return client.Email;
}

public void Modify (ClientEN client)
{
        try
        {
                SessionInitializeTransaction ();
                ClientEN clientEN = (ClientEN)session.Load (typeof(ClientEN), client.Email);

                clientEN.Tel = client.Tel;


                clientEN.Photo = client.Photo;


                clientEN.Pass = client.Pass;


                clientEN.Language = client.Language;


                clientEN.Name = client.Name;


                clientEN.Premium = client.Premium;

                session.Update (clientEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in ClientCAD.", ex);
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
                ClientEN clientEN = (ClientEN)session.Load (typeof(ClientEN), email);
                session.Delete (clientEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in ClientCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: ClientEN
public ClientEN ReadOID (string email
                         )
{
        ClientEN clientEN = null;

        try
        {
                SessionInitializeTransaction ();
                clientEN = (ClientEN)session.Get (typeof(ClientEN), email);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in ClientCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return clientEN;
}

public System.Collections.Generic.IList<ClientEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ClientEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ClientEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ClientEN>();
                else
                        result = session.CreateCriteria (typeof(ClientEN)).List<ClientEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in ClientCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
