
using System;
using AndayComeGenNHibernate.EN.AndayCome;

namespace AndayComeGenNHibernate.CAD.AndayCome
{
public partial interface IClientCAD
{
ClientEN ReadOIDDefault (string email
                         );

void ModifyDefault (ClientEN client);

System.Collections.Generic.IList<ClientEN> ReadAllDefault (int first, int size);



string New_ (ClientEN client);

void Modify (ClientEN client);


void Destroy (string email
              );


ClientEN ReadOID (string email
                  );


System.Collections.Generic.IList<ClientEN> ReadAll (int first, int size);
}
}
