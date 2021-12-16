
using System;
// Definición clase UserEN
namespace AndayComeGenNHibernate.EN.AndayCome
{
public partial class UserEN
{
/**
 *	Atributo tel
 */
private int tel;



/**
 *	Atributo photo
 */
private string photo;



/**
 *	Atributo pass
 */
private String pass;



/**
 *	Atributo country
 */
private AndayComeGenNHibernate.EN.AndayCome.CountryEN country;



/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo language
 */
private AndayComeGenNHibernate.Enumerated.AndayCome.LanguageEnum language;



/**
 *	Atributo name
 */
private string name;






public virtual int Tel {
        get { return tel; } set { tel = value;  }
}



public virtual string Photo {
        get { return photo; } set { photo = value;  }
}



public virtual String Pass {
        get { return pass; } set { pass = value;  }
}



public virtual AndayComeGenNHibernate.EN.AndayCome.CountryEN Country {
        get { return country; } set { country = value;  }
}



public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual AndayComeGenNHibernate.Enumerated.AndayCome.LanguageEnum Language {
        get { return language; } set { language = value;  }
}



public virtual string Name {
        get { return name; } set { name = value;  }
}





public UserEN()
{
}



public UserEN(string email, int tel, string photo, String pass, AndayComeGenNHibernate.EN.AndayCome.CountryEN country, AndayComeGenNHibernate.Enumerated.AndayCome.LanguageEnum language, string name
              )
{
        this.init (Email, tel, photo, pass, country, language, name);
}


public UserEN(UserEN user)
{
        this.init (Email, user.Tel, user.Photo, user.Pass, user.Country, user.Language, user.Name);
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
        UserEN t = obj as UserEN;
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
