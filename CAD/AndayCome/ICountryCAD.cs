
using System;
using AndayComeGenNHibernate.EN.AndayCome;

namespace AndayComeGenNHibernate.CAD.AndayCome
{
public partial interface ICountryCAD
{
CountryEN ReadOIDDefault (int id
                          );

void ModifyDefault (CountryEN country);

System.Collections.Generic.IList<CountryEN> ReadAllDefault (int first, int size);



int New_ (CountryEN country);

void Modify (CountryEN country);


void Destroy (int id
              );


void AddRestaurant (int p_Country_OID, System.Collections.Generic.IList<int> p_restaurant_OIDs);

void DeleteRestaurant (int p_Country_OID, System.Collections.Generic.IList<int> p_restaurant_OIDs);

CountryEN ReadOID (int id
                   );


System.Collections.Generic.IList<CountryEN> ReadAll (int first, int size);
}
}
