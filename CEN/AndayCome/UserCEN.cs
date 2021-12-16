

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
 *      Definition of the class UserCEN
 *
 */
public partial class UserCEN
{
private IUserCAD _IUserCAD;

public UserCEN()
{
        this._IUserCAD = new UserCAD ();
}

public UserCEN(IUserCAD _IUserCAD)
{
        this._IUserCAD = _IUserCAD;
}

public IUserCAD get_IUserCAD ()
{
        return this._IUserCAD;
}

public string New_ (int p_tel, string p_photo, String p_pass, int p_country, string p_email, AndayComeGenNHibernate.Enumerated.AndayCome.LanguageEnum p_language, string p_name)
{
        UserEN userEN = null;
        string oid;

        //Initialized UserEN
        userEN = new UserEN ();
        userEN.Tel = p_tel;

        userEN.Photo = p_photo;

        userEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);


        if (p_country != -1) {
                // El argumento p_country -> Property country es oid = false
                // Lista de oids email
                userEN.Country = new AndayComeGenNHibernate.EN.AndayCome.CountryEN ();
                userEN.Country.Id = p_country;
        }

        userEN.Email = p_email;

        userEN.Language = p_language;

        userEN.Name = p_name;

        //Call to UserCAD

        oid = _IUserCAD.New_ (userEN);
        return oid;
}

public void Modify (string p_User_OID, int p_tel, string p_photo, String p_pass, AndayComeGenNHibernate.Enumerated.AndayCome.LanguageEnum p_language, string p_name)
{
        UserEN userEN = null;

        //Initialized UserEN
        userEN = new UserEN ();
        userEN.Email = p_User_OID;
        userEN.Tel = p_tel;
        userEN.Photo = p_photo;
        userEN.Pass = Utils.Util.GetEncondeMD5 (p_pass);
        userEN.Language = p_language;
        userEN.Name = p_name;
        //Call to UserCAD

        _IUserCAD.Modify (userEN);
}

public void Destroy (string email
                     )
{
        _IUserCAD.Destroy (email);
}

public string Login (string p_User_OID, string p_pass)
{
        string result = null;
        UserEN en = _IUserCAD.ReadOIDDefault (p_User_OID);

        if (en != null && en.Pass.Equals (Utils.Util.GetEncondeMD5 (p_pass)))
                result = this.GetToken (en.Email);

        return result;
}

public UserEN ReadOID (string email
                       )
{
        UserEN userEN = null;

        userEN = _IUserCAD.ReadOID (email);
        return userEN;
}

public System.Collections.Generic.IList<UserEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<UserEN> list = null;

        list = _IUserCAD.ReadAll (first, size);
        return list;
}



private string Encode (string email)
{
        var payload = new Dictionary<string, object>(){
                { "email", email }
        };
        string token = Jose.JWT.Encode (payload, Utils.Util.getKey (), Jose.JwsAlgorithm.HS256);

        return token;
}

public string GetToken (string email)
{
        UserEN en = _IUserCAD.ReadOIDDefault (email);
        string token = Encode (en.Email);

        return token;
}
public string CheckToken (string token)
{
        string result = null;

        try
        {
                string decodedToken = Utils.Util.Decode (token);



                string id = (string)ObtenerEMAIL (decodedToken);

                UserEN en = _IUserCAD.ReadOIDDefault (id);

                if (en != null && ((string)en.Email).Equals (ObtenerEMAIL (decodedToken))
                    ) {
                        result = id;
                }
                else throw new ModelException ("El token es incorrecto");
        } catch (Exception e)
        {
                throw new ModelException ("El token es incorrecto");
        }

        return result;
}


public string ObtenerEMAIL (string decodedToken)
{
        try
        {
                Dictionary<string, object> results = JsonConvert.DeserializeObject<Dictionary<string, object> >(decodedToken);
                string email = (string)results ["email"];
                return email;
        }
        catch
        {
                throw new Exception ("El token enviado no es correcto");
        }
}
}
}
