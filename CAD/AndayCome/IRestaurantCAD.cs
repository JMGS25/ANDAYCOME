
using System;
using AndayComeGenNHibernate.EN.AndayCome;

namespace AndayComeGenNHibernate.CAD.AndayCome
{
public partial interface IRestaurantCAD
{
RestaurantEN ReadOIDDefault (int id
                             );

void ModifyDefault (RestaurantEN restaurant);

System.Collections.Generic.IList<RestaurantEN> ReadAllDefault (int first, int size);



int New_ (RestaurantEN restaurant);

void Modify (RestaurantEN restaurant);


void Destroy (int id
              );



void AddClient (int p_Restaurant_OID, System.Collections.Generic.IList<string> p_client_OIDs);

void RemoveClient (int p_Restaurant_OID, System.Collections.Generic.IList<string> p_client_OIDs);

System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN> FilterByTag (string p_oid_tag);


RestaurantEN ReadOID (int id
                      );


System.Collections.Generic.IList<RestaurantEN> ReadAll (int first, int size);



System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RestaurantEN> FilterbyRate (int ? p_rate);
}
}
