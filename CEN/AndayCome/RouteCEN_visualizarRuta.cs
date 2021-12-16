
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


/*PROTECTED REGION ID(usingAndayComeGenNHibernate.CEN.AndayCome_Route_visualizarRuta) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace AndayComeGenNHibernate.CEN.AndayCome
{
public partial class RouteCEN
{
public string VisualizarRuta (int p_oid)
{
        /*PROTECTED REGION ID(AndayComeGenNHibernate.CEN.AndayCome_Route_visualizarRuta) ENABLED START*/

        RouteEN routeEN = _IRouteCAD.ReadOIDDefault (p_oid);

        return routeEN.Id + "#" + routeEN.Name + "#" + routeEN.Description;

        /*PROTECTED REGION END*/
}
}
}
