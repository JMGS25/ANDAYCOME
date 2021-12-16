
using System;
using AndayComeGenNHibernate.EN.AndayCome;

namespace AndayComeGenNHibernate.CAD.AndayCome
{
public partial interface IRouteCAD
{
RouteEN ReadOIDDefault (int id
                        );

void ModifyDefault (RouteEN route);

System.Collections.Generic.IList<RouteEN> ReadAllDefault (int first, int size);



int New_ (RouteEN route);

void Modify (RouteEN route);


void Destroy (int id
              );





void AddClient (int p_Route_OID, System.Collections.Generic.IList<string> p_clients_OIDs);

void RemoveClient (int p_Route_OID, System.Collections.Generic.IList<string> p_clients_OIDs);

System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RouteEN> FilterByCity (AndayComeGenNHibernate.Enumerated.AndayCome.CitiesEnum ? p_city);


System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RouteEN> FilterByRate (int ? p_rate);


void AddBooking (int p_Route_OID, System.Collections.Generic.IList<int> p_booking_OIDs);

void RemoveBooking (int p_Route_OID, System.Collections.Generic.IList<int> p_booking_OIDs);

RouteEN ReadOID (int id
                 );


System.Collections.Generic.IList<RouteEN> ReadAll (int first, int size);


System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.RouteEN> FilterByRestaurant (string p_name);


void AddRestaurant (int p_Route_OID, System.Collections.Generic.IList<int> p_restaurants_OIDs);

void DeleteRestaurant (int p_Route_OID, System.Collections.Generic.IList<int> p_restaurants_OIDs);
}
}
