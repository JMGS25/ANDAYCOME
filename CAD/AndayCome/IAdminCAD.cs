
using System;
using AndayComeGenNHibernate.EN.AndayCome;

namespace AndayComeGenNHibernate.CAD.AndayCome
{
public partial interface IAdminCAD
{
AdminEN ReadOIDDefault (string email
                        );

void ModifyDefault (AdminEN admin);

System.Collections.Generic.IList<AdminEN> ReadAllDefault (int first, int size);



string New_ (AdminEN admin);

void Modify (AdminEN admin);


void Destroy (string email
              );



AdminEN ReadOID (string email
                 );


System.Collections.Generic.IList<AdminEN> ReadAll (int first, int size);
}
}
