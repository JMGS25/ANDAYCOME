
using System;
using AndayComeGenNHibernate.EN.AndayCome;

namespace AndayComeGenNHibernate.CAD.AndayCome
{
public partial interface IUserCAD
{
UserEN ReadOIDDefault (string email
                       );

void ModifyDefault (UserEN user);

System.Collections.Generic.IList<UserEN> ReadAllDefault (int first, int size);



string New_ (UserEN user);

void Modify (UserEN user);


void Destroy (string email
              );



UserEN ReadOID (string email
                );


System.Collections.Generic.IList<UserEN> ReadAll (int first, int size);
}
}
