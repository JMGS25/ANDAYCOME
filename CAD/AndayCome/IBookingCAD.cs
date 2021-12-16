
using System;
using AndayComeGenNHibernate.EN.AndayCome;

namespace AndayComeGenNHibernate.CAD.AndayCome
{
public partial interface IBookingCAD
{
BookingEN ReadOIDDefault (int id
                          );

void ModifyDefault (BookingEN booking);

System.Collections.Generic.IList<BookingEN> ReadAllDefault (int first, int size);



int New_ (BookingEN booking);

void Modify (BookingEN booking);


void Destroy (int id
              );


BookingEN ReadOID (int id
                   );


System.Collections.Generic.IList<BookingEN> ReadAll (int first, int size);


System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.BookingEN> FilterByClient (string p_oid_client);


System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.BookingEN> FilterByRestaurant (string p_name);
}
}
