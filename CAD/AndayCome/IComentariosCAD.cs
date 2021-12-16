
using System;
using AndayComeGenNHibernate.EN.AndayCome;

namespace AndayComeGenNHibernate.CAD.AndayCome
{
public partial interface IComentariosCAD
{
ComentariosEN ReadOIDDefault (int id
                              );

void ModifyDefault (ComentariosEN comentarios);

System.Collections.Generic.IList<ComentariosEN> ReadAllDefault (int first, int size);



int New_ (ComentariosEN comentarios);

void Modify (ComentariosEN comentarios);


void Destroy (int id
              );


ComentariosEN ReadOID (int id
                       );


System.Collections.Generic.IList<ComentariosEN> ReadAll (int first, int size);
}
}
