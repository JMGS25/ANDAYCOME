
using System;
using AndayComeGenNHibernate.EN.AndayCome;

namespace AndayComeGenNHibernate.CAD.AndayCome
{
public partial interface IRestaurant_OwnerCAD
{
Restaurant_OwnerEN ReadOIDDefault (string email
                                   );

void ModifyDefault (Restaurant_OwnerEN restaurant_Owner);

System.Collections.Generic.IList<Restaurant_OwnerEN> ReadAllDefault (int first, int size);



string New_ (Restaurant_OwnerEN restaurant_Owner);

void Modify (Restaurant_OwnerEN restaurant_Owner);


void Destroy (string email
              );


Restaurant_OwnerEN ReadOID (string email
                            );


System.Collections.Generic.IList<Restaurant_OwnerEN> ReadAll (int first, int size);
}
}
