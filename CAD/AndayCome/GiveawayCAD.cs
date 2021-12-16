
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
 * Clase Giveaway:
 *
 */

namespace AndayComeGenNHibernate.CAD.AndayCome
{
public partial class GiveawayCAD : BasicCAD, IGiveawayCAD
{
public GiveawayCAD() : base ()
{
}

public GiveawayCAD(ISession sessionAux) : base (sessionAux)
{
}



public GiveawayEN ReadOIDDefault (int id
                                  )
{
        GiveawayEN giveawayEN = null;

        try
        {
                SessionInitializeTransaction ();
                giveawayEN = (GiveawayEN)session.Get (typeof(GiveawayEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in GiveawayCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return giveawayEN;
}

public System.Collections.Generic.IList<GiveawayEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<GiveawayEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(GiveawayEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<GiveawayEN>();
                        else
                                result = session.CreateCriteria (typeof(GiveawayEN)).List<GiveawayEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in GiveawayCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (GiveawayEN giveaway)
{
        try
        {
                SessionInitializeTransaction ();
                GiveawayEN giveawayEN = (GiveawayEN)session.Load (typeof(GiveawayEN), giveaway.Id);


                giveawayEN.Precio = giveaway.Precio;


                giveawayEN.Premium = giveaway.Premium;


                giveawayEN.Premio = giveaway.Premio;


                giveawayEN.Winner = giveaway.Winner;

                session.Update (giveawayEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in GiveawayCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (GiveawayEN giveaway)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (giveaway);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in GiveawayCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return giveaway.Id;
}

public void Modify (GiveawayEN giveaway)
{
        try
        {
                SessionInitializeTransaction ();
                GiveawayEN giveawayEN = (GiveawayEN)session.Load (typeof(GiveawayEN), giveaway.Id);

                giveawayEN.Precio = giveaway.Precio;


                giveawayEN.Premium = giveaway.Premium;


                giveawayEN.Premio = giveaway.Premio;

                session.Update (giveawayEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in GiveawayCAD.", ex);
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
                GiveawayEN giveawayEN = (GiveawayEN)session.Load (typeof(GiveawayEN), id);
                session.Delete (giveawayEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in GiveawayCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AddClient (int p_Giveaway_OID, System.Collections.Generic.IList<string> p_client_OIDs)
{
        AndayComeGenNHibernate.EN.AndayCome.GiveawayEN giveawayEN = null;
        try
        {
                SessionInitializeTransaction ();
                giveawayEN = (GiveawayEN)session.Load (typeof(GiveawayEN), p_Giveaway_OID);
                AndayComeGenNHibernate.EN.AndayCome.ClientEN clientENAux = null;
                if (giveawayEN.Client == null) {
                        giveawayEN.Client = new System.Collections.Generic.List<AndayComeGenNHibernate.EN.AndayCome.ClientEN>();
                }

                foreach (string item in p_client_OIDs) {
                        clientENAux = new AndayComeGenNHibernate.EN.AndayCome.ClientEN ();
                        clientENAux = (AndayComeGenNHibernate.EN.AndayCome.ClientEN)session.Load (typeof(AndayComeGenNHibernate.EN.AndayCome.ClientEN), item);
                        clientENAux.Giveaway.Add (giveawayEN);

                        giveawayEN.Client.Add (clientENAux);
                }


                session.Update (giveawayEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in GiveawayCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void RemoveClient (int p_Giveaway_OID, System.Collections.Generic.IList<string> p_client_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                AndayComeGenNHibernate.EN.AndayCome.GiveawayEN giveawayEN = null;
                giveawayEN = (GiveawayEN)session.Load (typeof(GiveawayEN), p_Giveaway_OID);

                AndayComeGenNHibernate.EN.AndayCome.ClientEN clientENAux = null;
                if (giveawayEN.Client != null) {
                        foreach (string item in p_client_OIDs) {
                                clientENAux = (AndayComeGenNHibernate.EN.AndayCome.ClientEN)session.Load (typeof(AndayComeGenNHibernate.EN.AndayCome.ClientEN), item);
                                if (giveawayEN.Client.Contains (clientENAux) == true) {
                                        giveawayEN.Client.Remove (clientENAux);
                                        clientENAux.Giveaway.Remove (giveawayEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_client_OIDs you are trying to unrelationer, doesn't exist in GiveawayEN");
                        }
                }

                session.Update (giveawayEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in GiveawayCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
//Sin e: ReadOID
//Con e: GiveawayEN
public GiveawayEN ReadOID (int id
                           )
{
        GiveawayEN giveawayEN = null;

        try
        {
                SessionInitializeTransaction ();
                giveawayEN = (GiveawayEN)session.Get (typeof(GiveawayEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in GiveawayCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return giveawayEN;
}

public System.Collections.Generic.IList<GiveawayEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<GiveawayEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(GiveawayEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<GiveawayEN>();
                else
                        result = session.CreateCriteria (typeof(GiveawayEN)).List<GiveawayEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in GiveawayCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
