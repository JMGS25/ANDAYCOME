
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
 * Clase Wall:
 *
 */

namespace AndayComeGenNHibernate.CAD.AndayCome
{
public partial class WallCAD : BasicCAD, IWallCAD
{
public WallCAD() : base ()
{
}

public WallCAD(ISession sessionAux) : base (sessionAux)
{
}



public WallEN ReadOIDDefault (int id
                              )
{
        WallEN wallEN = null;

        try
        {
                SessionInitializeTransaction ();
                wallEN = (WallEN)session.Get (typeof(WallEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in WallCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return wallEN;
}

public System.Collections.Generic.IList<WallEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<WallEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(WallEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<WallEN>();
                        else
                                result = session.CreateCriteria (typeof(WallEN)).List<WallEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in WallCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (WallEN wall)
{
        try
        {
                SessionInitializeTransaction ();
                WallEN wallEN = (WallEN)session.Load (typeof(WallEN), wall.Id);

                session.Update (wallEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in WallCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (WallEN wall)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (wall);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in WallCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return wall.Id;
}

public void Modify (WallEN wall)
{
        try
        {
                SessionInitializeTransaction ();
                WallEN wallEN = (WallEN)session.Load (typeof(WallEN), wall.Id);
                session.Update (wallEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in WallCAD.", ex);
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
                WallEN wallEN = (WallEN)session.Load (typeof(WallEN), id);
                session.Delete (wallEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in WallCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: WallEN
public WallEN ReadOID (int id
                       )
{
        WallEN wallEN = null;

        try
        {
                SessionInitializeTransaction ();
                wallEN = (WallEN)session.Get (typeof(WallEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in WallCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return wallEN;
}

public System.Collections.Generic.IList<WallEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<WallEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(WallEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<WallEN>();
                else
                        result = session.CreateCriteria (typeof(WallEN)).List<WallEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in WallCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
