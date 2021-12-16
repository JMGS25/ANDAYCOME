

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
 *      Definition of the class BookingCEN
 *
 */
public partial class BookingCEN
{
private IBookingCAD _IBookingCAD;

public BookingCEN()
{
        this._IBookingCAD = new BookingCAD ();
}

public BookingCEN(IBookingCAD _IBookingCAD)
{
        this._IBookingCAD = _IBookingCAD;
}

public IBookingCAD get_IBookingCAD ()
{
        return this._IBookingCAD;
}

public void Modify (int p_Booking_OID, Nullable<DateTime> p_date, Nullable<DateTime> p_hour, int p_guests)
{
        BookingEN bookingEN = null;

        //Initialized BookingEN
        bookingEN = new BookingEN ();
        bookingEN.Id = p_Booking_OID;
        bookingEN.Date = p_date;
        bookingEN.Hour = p_hour;
        bookingEN.Guests = p_guests;
        //Call to BookingCAD

        _IBookingCAD.Modify (bookingEN);
}

public void Destroy (int id
                     )
{
        _IBookingCAD.Destroy (id);
}

public BookingEN ReadOID (int id
                          )
{
        BookingEN bookingEN = null;

        bookingEN = _IBookingCAD.ReadOID (id);
        return bookingEN;
}

public System.Collections.Generic.IList<BookingEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<BookingEN> list = null;

        list = _IBookingCAD.ReadAll (first, size);
        return list;
}
public System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.BookingEN> FilterByClient (string p_oid_client)
{
        return _IBookingCAD.FilterByClient (p_oid_client);
}
public System.Collections.Generic.IList<AndayComeGenNHibernate.EN.AndayCome.BookingEN> FilterByRestaurant (string p_name)
{
        return _IBookingCAD.FilterByRestaurant (p_name);
}
}
}
