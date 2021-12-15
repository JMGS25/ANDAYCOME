using AndayComeGenNHibernate.EN.AndayCome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAndayCome.Models;

namespace WebAndayCome.Assembler
{
    public class BookingAssembler
    {
        public BookingViewModel ConvertENToModelUI(BookingEN en)
        {
            BookingViewModel booking = new BookingViewModel();
            booking.Id = en.Id;
            booking.Guest = en.Guests;
            booking.Date = en.Date;
            booking.Hour = en.Hour;
            booking.IdCliente = en.Client.Email;
            booking.Restaurante = en.Restaurant.Name;

            return booking;
        }

        public IList<BookingViewModel> ConvertListENToModel(IList<BookingEN> ens)
        {
            IList<BookingViewModel> bookings = new List<BookingViewModel>();
            foreach (BookingEN en in ens)
            {
                bookings.Add(ConvertENToModelUI(en));
            }

            return bookings;
        }
    }
}
