

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using AndayComeGenNHibernate.Exceptions;

using AndayComeGenNHibernate.EN.AndayCome;
using AndayComeGenNHibernate.CAD.AndayCome;


namespace AndayComeGenNHibernate.CEN.AndayCome
{
/*
 *      Definition of the class TagsCEN
 *
 */
public partial class TagsCEN
{
private ITagsCAD _ITagsCAD;

public TagsCEN()
{
        this._ITagsCAD = new TagsCAD ();
}

public TagsCEN(ITagsCAD _ITagsCAD)
{
        this._ITagsCAD = _ITagsCAD;
}

public ITagsCAD get_ITagsCAD ()
{
        return this._ITagsCAD;
}

public string New_ (string p_name)
{
        TagsEN tagsEN = null;
        string oid;

        //Initialized TagsEN
        tagsEN = new TagsEN ();
        tagsEN.Name = p_name;

        //Call to TagsCAD

        oid = _ITagsCAD.New_ (tagsEN);
        return oid;
}

public void Modify (string p_Tags_OID)
{
        TagsEN tagsEN = null;

        //Initialized TagsEN
        tagsEN = new TagsEN ();
        tagsEN.Name = p_Tags_OID;
        //Call to TagsCAD

        _ITagsCAD.Modify (tagsEN);
}

public void Destroy (string name
                     )
{
        _ITagsCAD.Destroy (name);
}

public void AddRestaurant (string p_Tags_OID, System.Collections.Generic.IList<int> p_restaurant_OIDs)
{
        //Call to TagsCAD

        _ITagsCAD.AddRestaurant (p_Tags_OID, p_restaurant_OIDs);
}
public void DeleteRestaurant (string p_Tags_OID, System.Collections.Generic.IList<int> p_restaurant_OIDs)
{
        //Call to TagsCAD

        _ITagsCAD.DeleteRestaurant (p_Tags_OID, p_restaurant_OIDs);
}
public TagsEN ReadOID (string name
                       )
{
        TagsEN tagsEN = null;

        tagsEN = _ITagsCAD.ReadOID (name);
        return tagsEN;
}

public System.Collections.Generic.IList<TagsEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<TagsEN> list = null;

        list = _ITagsCAD.ReadAll (first, size);
        return list;
}
}
}
