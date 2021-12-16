

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using AndayComeGenNHibernate.Exceptions;

using AndayComeGenNHibernate.EN.AndayCome;
using AndayComeGenNHibernate.CAD.AndayCome;


namespace AndayComeGenNHibernate.CEN.AndayCome
{
/*
 *      Definition of the class PaymentCEN
 *
 */
public partial class PaymentCEN
{
private IPaymentCAD _IPaymentCAD;

public PaymentCEN()
{
        this._IPaymentCAD = new PaymentCAD ();
}

public PaymentCEN(IPaymentCAD _IPaymentCAD)
{
        this._IPaymentCAD = _IPaymentCAD;
}

public IPaymentCAD get_IPaymentCAD ()
{
        return this._IPaymentCAD;
}

public int New_ (string p_client, bool p_paypal, Nullable<DateTime> p_date_sub)
{
        PaymentEN paymentEN = null;
        int oid;

        //Initialized PaymentEN
        paymentEN = new PaymentEN ();

        if (p_client != null) {
                // El argumento p_client -> Property client es oid = false
                // Lista de oids id
                paymentEN.Client = new AndayComeGenNHibernate.EN.AndayCome.ClientEN ();
                paymentEN.Client.Email = p_client;
        }

        paymentEN.Paypal = p_paypal;

        paymentEN.Date_sub = p_date_sub;

        //Call to PaymentCAD

        oid = _IPaymentCAD.New_ (paymentEN);
        return oid;
}

public void Modify (int p_Payment_OID, bool p_paypal, Nullable<DateTime> p_date_sub)
{
        PaymentEN paymentEN = null;

        //Initialized PaymentEN
        paymentEN = new PaymentEN ();
        paymentEN.Id = p_Payment_OID;
        paymentEN.Paypal = p_paypal;
        paymentEN.Date_sub = p_date_sub;
        //Call to PaymentCAD

        _IPaymentCAD.Modify (paymentEN);
}

public void Destroy (int id
                     )
{
        _IPaymentCAD.Destroy (id);
}

public PaymentEN ReadOID (int id
                          )
{
        PaymentEN paymentEN = null;

        paymentEN = _IPaymentCAD.ReadOID (id);
        return paymentEN;
}

public System.Collections.Generic.IList<PaymentEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PaymentEN> list = null;

        list = _IPaymentCAD.ReadAll (first, size);
        return list;
}
}
}
