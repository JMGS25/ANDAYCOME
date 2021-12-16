
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


/*PROTECTED REGION ID(usingAndayComeGenNHibernate.CEN.AndayCome_Admin_obtenerContacto) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace AndayComeGenNHibernate.CEN.AndayCome
{
public partial class AdminCEN
{
public string ObtenerContacto (string p_oid)
{
        /*PROTECTED REGION ID(AndayComeGenNHibernate.CEN.AndayCome_Admin_obtenerContacto) ENABLED START*/

        AdminEN en = _IAdminCAD.ReadOIDDefault (p_oid);

        return en.Email + "#" + en.Tel + "#" + en.Name;

        /*PROTECTED REGION END*/
}
}
}
