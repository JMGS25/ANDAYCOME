
using System;
using AndayComeGenNHibernate.EN.AndayCome;

namespace AndayComeGenNHibernate.CAD.AndayCome
{
public partial interface IWallCAD
{
WallEN ReadOIDDefault (int id
                       );

void ModifyDefault (WallEN wall);

System.Collections.Generic.IList<WallEN> ReadAllDefault (int first, int size);



int New_ (WallEN wall);

void Modify (WallEN wall);


void Destroy (int id
              );


WallEN ReadOID (int id
                );


System.Collections.Generic.IList<WallEN> ReadAll (int first, int size);
}
}
