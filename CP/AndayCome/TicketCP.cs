
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
public partial class TicketCP : BasicCP
{
public TicketCP() : base ()
{
}

public TicketCP(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
