
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using AndayComeGenNHibernate.Exceptions;
using AndayComeGenNHibernate.EN.AndayCome;
using AndayComeGenNHibernate.CAD.AndayCome;
using AndayComeGenNHibernate.CEN.AndayCome;



namespace AndayComeGenNHibernate.CP.AndayCome
{
public partial class GiveawayCP : BasicCP
{
public GiveawayCP() : base ()
{
}

public GiveawayCP(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
