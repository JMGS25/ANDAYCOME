

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
 *      Definition of the class ClientCEN
 *
 */
public partial class ClientCEN
{
private IClientCAD _IClientCAD;

public ClientCEN()
{
        this._IClientCAD = new ClientCAD ();
}

public ClientCEN(IClientCAD _IClientCAD)
{
        this._IClientCAD = _IClientCAD;
}

public IClientCAD get_IClientCAD ()
{
        return this._IClientCAD;
}

public string New_ (int p_tel, string p_photo, String p_pass, int p_country, string p_email, AndayComeGenNHibernate.Enumerated.AndayCome.LanguageEnum p_language, string p_name, bool p_premium)
{
        ClientEN clientEN = null;
        string oid;

        //Initialized ClientEN
        clientEN = new ClientEN ();
        clientEN.Tel = p_tel;

        clientEN.Photo = p_photo;

        clientEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);


        if (p_country != -1) {
                // El argumento p_country -> Property country es oid = false
                // Lista de oids email
                clientEN.Country = new AndayComeGenNHibernate.EN.AndayCome.CountryEN ();
                clientEN.Country.Id = p_country;
        }

        clientEN.Email = p_email;

        clientEN.Language = p_language;

        clientEN.Name = p_name;

        clientEN.Premium = p_premium;

        //Call to ClientCAD

        oid = _IClientCAD.New_ (clientEN);
        return oid;
}

public void Modify (string p_Client_OID, int p_tel, string p_photo, String p_pass, AndayComeGenNHibernate.Enumerated.AndayCome.LanguageEnum p_language, string p_name, bool p_premium)
{
        ClientEN clientEN = null;

        //Initialized ClientEN
        clientEN = new ClientEN ();
        clientEN.Email = p_Client_OID;
        clientEN.Tel = p_tel;
        clientEN.Photo = p_photo;
        clientEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);
        clientEN.Language = p_language;
        clientEN.Name = p_name;
        clientEN.Premium = p_premium;
        //Call to ClientCAD

        _IClientCAD.Modify (clientEN);
}

public void Destroy (string email
                     )
{
        _IClientCAD.Destroy (email);
}

public ClientEN ReadOID (string email
                         )
{
        ClientEN clientEN = null;

        clientEN = _IClientCAD.ReadOID (email);
        return clientEN;
}

public System.Collections.Generic.IList<ClientEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<ClientEN> list = null;

        list = _IClientCAD.ReadAll (first, size);
        return list;
}
}
}
