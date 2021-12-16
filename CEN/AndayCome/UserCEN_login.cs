
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using AndayComeGenNHibernate.Exceptions;
using AndayComeGenNHibernate.EN.AndayCome;
using AndayComeGenNHibernate.CAD.AndayCome;


/*PROTECTED REGION ID(usingAndayComeGenNHibernate.CEN.AndayCome_User_login) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace AndayComeGenNHibernate.CEN.AndayCome
{
public partial class UserCEN
{
public string Login (string p_email, string p_pass)
{
        /*PROTECTED REGION ID(AndayComeGenNHibernate.CEN.AndayCome_User_login) ENABLED START*/
        string result = null;

        IList<UserEN> listaEN = DameUsuarioPorEmail (p_email);

        if (listaEN.Count > 0) {
                UserEN userEN = listaEN [0];
                if (userEN.Pass.Equals (Utils.Util.GetEncondeMD5 (p_pass))) {
                        result = this.GetToken (userEN.Name);
                }
        }
        return result;
        /*PROTECTED REGION END*/
}
}
}
