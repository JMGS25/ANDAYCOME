
using System;
using AndayComeGenNHibernate.EN.AndayCome;

namespace AndayComeGenNHibernate.CAD.AndayCome
{
public partial interface IRatesCAD
{
RatesEN ReadOIDDefault (int id
                        );

void ModifyDefault (RatesEN rates);

System.Collections.Generic.IList<RatesEN> ReadAllDefault (int first, int size);



int New_ (RatesEN rates);

void Modify (RatesEN rates);


void Destroy (int id
              );


void RateRestaurant (int p_Rates_OID, System.Collections.Generic.IList<int> p_restaurants_OIDs);

void UnrateRestaurant (int p_Rates_OID, System.Collections.Generic.IList<int> p_restaurants_OIDs);

void RateRoute (int p_Rates_OID, System.Collections.Generic.IList<int> p_route_OIDs);

void UnrateRoute (int p_Rates_OID, System.Collections.Generic.IList<int> p_route_OIDs);

RatesEN ReadOID (int id
                 );


System.Collections.Generic.IList<RatesEN> ReadAll (int first, int size);
}
}
