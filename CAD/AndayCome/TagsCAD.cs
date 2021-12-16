
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
 * Clase Tags:
 *
 */

namespace AndayComeGenNHibernate.CAD.AndayCome
{
public partial class TagsCAD : BasicCAD, ITagsCAD
{
public TagsCAD() : base ()
{
}

public TagsCAD(ISession sessionAux) : base (sessionAux)
{
}



public TagsEN ReadOIDDefault (string name
                              )
{
        TagsEN tagsEN = null;

        try
        {
                SessionInitializeTransaction ();
                tagsEN = (TagsEN)session.Get (typeof(TagsEN), name);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in TagsCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tagsEN;
}

public System.Collections.Generic.IList<TagsEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<TagsEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(TagsEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<TagsEN>();
                        else
                                result = session.CreateCriteria (typeof(TagsEN)).List<TagsEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in TagsCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (TagsEN tags)
{
        try
        {
                SessionInitializeTransaction ();
                TagsEN tagsEN = (TagsEN)session.Load (typeof(TagsEN), tags.Name);

                session.Update (tagsEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in TagsCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public string New_ (TagsEN tags)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (tags);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in TagsCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tags.Name;
}

public void Modify (TagsEN tags)
{
        try
        {
                SessionInitializeTransaction ();
                TagsEN tagsEN = (TagsEN)session.Load (typeof(TagsEN), tags.Name);
                session.Update (tagsEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in TagsCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (string name
                     )
{
        try
        {
                SessionInitializeTransaction ();
                TagsEN tagsEN = (TagsEN)session.Load (typeof(TagsEN), name);
                session.Delete (tagsEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in TagsCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AddRestaurant (string p_Tags_OID, System.Collections.Generic.IList<int> p_restaurant_OIDs)
{
        AndayComeGenNHibernate.EN.AndayCome.TagsEN tagsEN = null;
        try
        {
                SessionInitializeTransaction ();
                tagsEN = (TagsEN)session.Load (typeof(TagsEN), p_Tags_OID);
                AndayComeGenNHibernate.EN.AndayCome.RestaurantEN restaurantENAux = null;
                if (tagsEN.Restaurant == null) {
                        tagsEN.Restaurant = new System.Collections.Generic.List<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN>();
                }

                foreach (int item in p_restaurant_OIDs) {
                        restaurantENAux = new AndayComeGenNHibernate.EN.AndayCome.RestaurantEN ();
                        restaurantENAux = (AndayComeGenNHibernate.EN.AndayCome.RestaurantEN)session.Load (typeof(AndayComeGenNHibernate.EN.AndayCome.RestaurantEN), item);
                        restaurantENAux.Tags.Add (tagsEN);

                        tagsEN.Restaurant.Add (restaurantENAux);
                }


                session.Update (tagsEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in TagsCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void DeleteRestaurant (string p_Tags_OID, System.Collections.Generic.IList<int> p_restaurant_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                AndayComeGenNHibernate.EN.AndayCome.TagsEN tagsEN = null;
                tagsEN = (TagsEN)session.Load (typeof(TagsEN), p_Tags_OID);

                AndayComeGenNHibernate.EN.AndayCome.RestaurantEN restaurantENAux = null;
                if (tagsEN.Restaurant != null) {
                        foreach (int item in p_restaurant_OIDs) {
                                restaurantENAux = (AndayComeGenNHibernate.EN.AndayCome.RestaurantEN)session.Load (typeof(AndayComeGenNHibernate.EN.AndayCome.RestaurantEN), item);
                                if (tagsEN.Restaurant.Contains (restaurantENAux) == true) {
                                        tagsEN.Restaurant.Remove (restaurantENAux);
                                        restaurantENAux.Tags.Remove (tagsEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_restaurant_OIDs you are trying to unrelationer, doesn't exist in TagsEN");
                        }
                }

                session.Update (tagsEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in TagsCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
//Sin e: ReadOID
//Con e: TagsEN
public TagsEN ReadOID (string name
                       )
{
        TagsEN tagsEN = null;

        try
        {
                SessionInitializeTransaction ();
                tagsEN = (TagsEN)session.Get (typeof(TagsEN), name);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in TagsCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return tagsEN;
}

public System.Collections.Generic.IList<TagsEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<TagsEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(TagsEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<TagsEN>();
                else
                        result = session.CreateCriteria (typeof(TagsEN)).List<TagsEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in TagsCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
