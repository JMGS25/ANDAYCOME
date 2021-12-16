
using System;
using System.Text;
using AndayComeGenNHibernate.CEN.AndayCome;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using AndayComeGenNHibernate.EN.AndayCome;
using AndayComeGenNHibernate.Exceptions;


/*
 * Clase Payment:
 *
 */

namespace AndayComeGenNHibernate.CAD.AndayCome
{
public partial class PaymentCAD : BasicCAD, IPaymentCAD
{
public PaymentCAD() : base ()
{
}

public PaymentCAD(ISession sessionAux) : base (sessionAux)
{
}



public PaymentEN ReadOIDDefault (int id
                                 )
{
        PaymentEN paymentEN = null;

        try
        {
                SessionInitializeTransaction ();
                paymentEN = (PaymentEN)session.Get (typeof(PaymentEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in PaymentCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return paymentEN;
}

public System.Collections.Generic.IList<PaymentEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PaymentEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PaymentEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<PaymentEN>();
                        else
                                result = session.CreateCriteria (typeof(PaymentEN)).List<PaymentEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in PaymentCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PaymentEN payment)
{
        try
        {
                SessionInitializeTransaction ();
                PaymentEN paymentEN = (PaymentEN)session.Load (typeof(PaymentEN), payment.Id);


                paymentEN.Paypal = payment.Paypal;


                paymentEN.Date_sub = payment.Date_sub;

                session.Update (paymentEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in PaymentCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (PaymentEN payment)
{
        try
        {
                SessionInitializeTransaction ();
                if (payment.Client != null) {
                        // Argumento OID y no colección.
                        payment.Client = (AndayComeGenNHibernate.EN.AndayCome.ClientEN)session.Load (typeof(AndayComeGenNHibernate.EN.AndayCome.ClientEN), payment.Client.Email);

                        payment.Client.Payment
                                = payment;
                }

                session.Save (payment);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in PaymentCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return payment.Id;
}

public void Modify (PaymentEN payment)
{
        try
        {
                SessionInitializeTransaction ();
                PaymentEN paymentEN = (PaymentEN)session.Load (typeof(PaymentEN), payment.Id);

                paymentEN.Paypal = payment.Paypal;


                paymentEN.Date_sub = payment.Date_sub;

                session.Update (paymentEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in PaymentCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                PaymentEN paymentEN = (PaymentEN)session.Load (typeof(PaymentEN), id);
                session.Delete (paymentEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in PaymentCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: ReadOID
//Con e: PaymentEN
public PaymentEN ReadOID (int id
                          )
{
        PaymentEN paymentEN = null;

        try
        {
                SessionInitializeTransaction ();
                paymentEN = (PaymentEN)session.Get (typeof(PaymentEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in PaymentCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return paymentEN;
}

public System.Collections.Generic.IList<PaymentEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<PaymentEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PaymentEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<PaymentEN>();
                else
                        result = session.CreateCriteria (typeof(PaymentEN)).List<PaymentEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is AndayComeGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new AndayComeGenNHibernate.Exceptions.DataLayerException ("Error in PaymentCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
