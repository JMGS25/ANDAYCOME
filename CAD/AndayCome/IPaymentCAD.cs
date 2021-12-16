
using System;
using AndayComeGenNHibernate.EN.AndayCome;

namespace AndayComeGenNHibernate.CAD.AndayCome
{
public partial interface IPaymentCAD
{
PaymentEN ReadOIDDefault (int id
                          );

void ModifyDefault (PaymentEN payment);

System.Collections.Generic.IList<PaymentEN> ReadAllDefault (int first, int size);



int New_ (PaymentEN payment);

void Modify (PaymentEN payment);


void Destroy (int id
              );




PaymentEN ReadOID (int id
                   );


System.Collections.Generic.IList<PaymentEN> ReadAll (int first, int size);
}
}
