
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
 * Clase Comentarios:
 *
 */

namespace AndayComeGenNHibernate.CAD.AndayCome
{
public partial class ComentariosCAD : BasicCAD, IComentariosCAD
{
public ComentariosCAD() : base ()
{
}

public ComentariosCAD(ISession sessionAux) : base (sessionAux)
{
}



public ComentariosEN ReadOIDDefault (int id
                                     )
{
        ComentariosEN comentariosEN = null;

        try
        {
                SessionInitializeTransaction ();
                comentariosEN = (ComentariosEN)session.Get (typeof(ComentariosEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in ComentariosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return comentariosEN;
}

public System.Collections.Generic.IList<ComentariosEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ComentariosEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ComentariosEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ComentariosEN>();
                        else
                                result = session.CreateCriteria (typeof(ComentariosEN)).List<ComentariosEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in ComentariosCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ComentariosEN comentarios)
{
        try
        {
                SessionInitializeTransaction ();
                ComentariosEN comentariosEN = (ComentariosEN)session.Load (typeof(ComentariosEN), comentarios.Id);

                comentariosEN.Content = comentarios.Content;





                comentariosEN.Date = comentarios.Date;

                session.Update (comentariosEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in ComentariosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ComentariosEN comentarios)
{
        try
        {
                SessionInitializeTransaction ();
                if (comentarios.Client != null) {
                        // Argumento OID y no colección.
                        comentarios.Client = (AndayComeGenNHibernate.EN.AndayCome.ClientEN)session.Load (typeof(AndayComeGenNHibernate.EN.AndayCome.ClientEN), comentarios.Client.Email);

                        comentarios.Client.Comentarios
                        .Add (comentarios);
                }

                session.Save (comentarios);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in ComentariosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return comentarios.Id;
}

public void Modify (ComentariosEN comentarios)
{
        try
        {
                SessionInitializeTransaction ();
                ComentariosEN comentariosEN = (ComentariosEN)session.Load (typeof(ComentariosEN), comentarios.Id);

                comentariosEN.Content = comentarios.Content;


                comentariosEN.Date = comentarios.Date;

                session.Update (comentariosEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in ComentariosCAD.", ex);
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
                ComentariosEN comentariosEN = (ComentariosEN)session.Load (typeof(ComentariosEN), id);
                session.Delete (comentariosEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in ComentariosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: ComentariosEN
public ComentariosEN ReadOID (int id
                              )
{
        ComentariosEN comentariosEN = null;

        try
        {
                SessionInitializeTransaction ();
                comentariosEN = (ComentariosEN)session.Get (typeof(ComentariosEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in ComentariosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return comentariosEN;
}

public System.Collections.Generic.IList<ComentariosEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ComentariosEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(ComentariosEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<ComentariosEN>();
                else
                        result = session.CreateCriteria (typeof(ComentariosEN)).List<ComentariosEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in ComentariosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
