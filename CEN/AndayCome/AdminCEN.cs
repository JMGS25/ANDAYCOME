

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
 *      Definition of the class AdminCEN
 *
 */
public partial class AdminCEN
{
private IAdminCAD _IAdminCAD;

public AdminCEN()
{
        this._IAdminCAD = new AdminCAD ();
}

public AdminCEN(IAdminCAD _IAdminCAD)
{
        this._IAdminCAD = _IAdminCAD;
}

public IAdminCAD get_IAdminCAD ()
{
        return this._IAdminCAD;
}

public string New_ (int p_tel, string p_photo, String p_pass, int p_country, string p_email, AndayComeGenNHibernate.Enumerated.AndayCome.LanguageEnum p_language, string p_name)
{
        AdminEN adminEN = null;
        string oid;

        //Initialized AdminEN
        adminEN = new AdminEN ();
        adminEN.Tel = p_tel;

        adminEN.Photo = p_photo;

        adminEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);


        if (p_country != -1) {
                // El argumento p_country -> Property country es oid = false
                // Lista de oids email
                adminEN.Country = new AndayComeGenNHibernate.EN.AndayCome.CountryEN ();
                adminEN.Country.Id = p_country;
        }

        adminEN.Email = p_email;

        adminEN.Language = p_language;

        adminEN.Name = p_name;

        //Call to AdminCAD

        oid = _IAdminCAD.New_ (adminEN);
        return oid;
}

public void Modify (string p_Admin_OID, int p_tel, string p_photo, String p_pass, AndayComeGenNHibernate.Enumerated.AndayCome.LanguageEnum p_language, string p_name)
{
        AdminEN adminEN = null;

        //Initialized AdminEN
        adminEN = new AdminEN ();
        adminEN.Email = p_Admin_OID;
        adminEN.Tel = p_tel;
        adminEN.Photo = p_photo;
        adminEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);
        adminEN.Language = p_language;
        adminEN.Name = p_name;
        //Call to AdminCAD

        _IAdminCAD.Modify (adminEN);
}

public void Destroy (string email
                     )
{
        _IAdminCAD.Destroy (email);
}

public AdminEN ReadOID (string email
                        )
{
        AdminEN adminEN = null;

        adminEN = _IAdminCAD.ReadOID (email);
        return adminEN;
}

public System.Collections.Generic.IList<AdminEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<AdminEN> list = null;

        list = _IAdminCAD.ReadAll (first, size);
        return list;
}
}
}
