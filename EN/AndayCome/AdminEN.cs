
using System;
// Definición clase AdminEN
namespace AndayComeGenNHibernate.EN.AndayCome
{
public partial class AdminEN                                                                        : AndayComeGenNHibernate.EN.AndayCome.UserEN


{
public AdminEN() : base ()
{
}



public AdminEN(string email,
               int tel, string photo, String pass, AndayComeGenNHibernate.EN.AndayCome.CountryEN country, AndayComeGenNHibernate.Enumerated.AndayCome.LanguageEnum language, string name
               )
{
        this.init (Email, tel, photo, pass, country, language, name);
}


public AdminEN(AdminEN admin)
{
        this.init (Email, admin.Tel, admin.Photo, admin.Pass, admin.Country, admin.Language, admin.Name);
}

private void init (string email
                   , int tel, string photo, String pass, AndayComeGenNHibernate.EN.AndayCome.CountryEN country, AndayComeGenNHibernate.Enumerated.AndayCome.LanguageEnum language, string name)
{
        this.Email = email;


        this.Tel = tel;

        this.Photo = photo;

        this.Pass = pass;

        this.Country = country;

        this.Language = language;

        this.Name = name;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AdminEN t = obj as AdminEN;
        if (t == null)
                return false;
        if (Email.Equals (t.Email))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Email.GetHashCode ();
        return hash;
}
}
}
