
using System;
using AndayComeGenNHibernate.EN.AndayCome;

namespace AndayComeGenNHibernate.CAD.AndayCome
{
public partial interface ITicketCAD
{
TicketEN ReadOIDDefault (int id
                         );

void ModifyDefault (TicketEN ticket);

System.Collections.Generic.IList<TicketEN> ReadAllDefault (int first, int size);



int New_ (TicketEN ticket);

void Modify (TicketEN ticket);


void Destroy (int id
              );


TicketEN ReadOID (int id
                  );


System.Collections.Generic.IList<TicketEN> ReadAll (int first, int size);
}
}
