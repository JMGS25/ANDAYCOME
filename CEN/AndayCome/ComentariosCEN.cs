

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
 *      Definition of the class ComentariosCEN
 *
 */
public partial class ComentariosCEN
{
private IComentariosCAD _IComentariosCAD;

public ComentariosCEN()
{
        this._IComentariosCAD = new ComentariosCAD ();
}

public ComentariosCEN(IComentariosCAD _IComentariosCAD)
{
        this._IComentariosCAD = _IComentariosCAD;
}

public IComentariosCAD get_IComentariosCAD ()
{
        return this._IComentariosCAD;
}

public int New_ (string p_content, string p_client, Nullable<DateTime> p_date)
{
        ComentariosEN comentariosEN = null;
        int oid;

        //Initialized ComentariosEN
        comentariosEN = new ComentariosEN ();
        comentariosEN.Content = p_content;


        if (p_client != null) {
                // El argumento p_client -> Property client es oid = false
                // Lista de oids id
                comentariosEN.Client = new AndayComeGenNHibernate.EN.AndayCome.ClientEN ();
                comentariosEN.Client.Email = p_client;
        }

        comentariosEN.Date = p_date;

        //Call to ComentariosCAD

        oid = _IComentariosCAD.New_ (comentariosEN);
        return oid;
}

public void Modify (int p_Comentarios_OID, string p_content, Nullable<DateTime> p_date)
{
        ComentariosEN comentariosEN = null;

        //Initialized ComentariosEN
        comentariosEN = new ComentariosEN ();
        comentariosEN.Id = p_Comentarios_OID;
        comentariosEN.Content = p_content;
        comentariosEN.Date = p_date;
        //Call to ComentariosCAD

        _IComentariosCAD.Modify (comentariosEN);
}

public void Destroy (int id
                     )
{
        _IComentariosCAD.Destroy (id);
}

public ComentariosEN ReadOID (int id
                              )
{
        ComentariosEN comentariosEN = null;

        comentariosEN = _IComentariosCAD.ReadOID (id);
        return comentariosEN;
}

public System.Collections.Generic.IList<ComentariosEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ComentariosEN> list = null;

        list = _IComentariosCAD.ReadAll (first, size);
        return list;
}
}
}
