

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
 *      Definition of the class WallCEN
 *
 */
public partial class WallCEN
{
private IWallCAD _IWallCAD;

public WallCEN()
{
        this._IWallCAD = new WallCAD ();
}

public WallCEN(IWallCAD _IWallCAD)
{
        this._IWallCAD = _IWallCAD;
}

public IWallCAD get_IWallCAD ()
{
        return this._IWallCAD;
}

public int New_ ()
{
        WallEN wallEN = null;
        int oid;

        //Initialized WallEN
        wallEN = new WallEN ();
        //Call to WallCAD

        oid = _IWallCAD.New_ (wallEN);
        return oid;
}

public void Modify (int p_Wall_OID)
{
        WallEN wallEN = null;

        //Initialized WallEN
        wallEN = new WallEN ();
        wallEN.Id = p_Wall_OID;
        //Call to WallCAD

        _IWallCAD.Modify (wallEN);
}

public void Destroy (int id
                     )
{
        _IWallCAD.Destroy (id);
}

public WallEN ReadOID (int id
                       )
{
        WallEN wallEN = null;

        wallEN = _IWallCAD.ReadOID (id);
        return wallEN;
}

public System.Collections.Generic.IList<WallEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<WallEN> list = null;

        list = _IWallCAD.ReadAll (first, size);
        return list;
}
}
}
