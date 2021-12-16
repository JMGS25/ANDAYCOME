
using System;
using AndayComeGenNHibernate.EN.AndayCome;

namespace AndayComeGenNHibernate.CAD.AndayCome
{
public partial interface IGiveawayCAD
{
GiveawayEN ReadOIDDefault (int id
                           );

void ModifyDefault (GiveawayEN giveaway);

System.Collections.Generic.IList<GiveawayEN> ReadAllDefault (int first, int size);



int New_ (GiveawayEN giveaway);

void Modify (GiveawayEN giveaway);


void Destroy (int id
              );



void AddClient (int p_Giveaway_OID, System.Collections.Generic.IList<string> p_client_OIDs);

void RemoveClient (int p_Giveaway_OID, System.Collections.Generic.IList<string> p_client_OIDs);

GiveawayEN ReadOID (int id
                    );


System.Collections.Generic.IList<GiveawayEN> ReadAll (int first, int size);
}
}
