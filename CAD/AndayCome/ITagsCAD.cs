
using System;
using AndayComeGenNHibernate.EN.AndayCome;

namespace AndayComeGenNHibernate.CAD.AndayCome
{
public partial interface ITagsCAD
{
TagsEN ReadOIDDefault (string name
                       );

void ModifyDefault (TagsEN tags);

System.Collections.Generic.IList<TagsEN> ReadAllDefault (int first, int size);



string New_ (TagsEN tags);

void Modify (TagsEN tags);


void Destroy (string name
              );


void AddRestaurant (string p_Tags_OID, System.Collections.Generic.IList<int> p_restaurant_OIDs);

void DeleteRestaurant (string p_Tags_OID, System.Collections.Generic.IList<int> p_restaurant_OIDs);

TagsEN ReadOID (string name
                );


System.Collections.Generic.IList<TagsEN> ReadAll (int first, int size);
}
}
