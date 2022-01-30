using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using YachtsWebApplication.Entities;

namespace YachtsWebApplication.ViewModels
{
    public class ConfirmationViewModel
    {
        public ConfirmationViewModel()
        {

        }
        public ConfirmationViewModel(Booking booking)
        {
            this.EmailAddress = booking.EmailAddress;
            this.Price = booking.Price;
            this.Advance = Math.Round(((booking.Price / 100) * 30), 2);
            this.Start = booking.Start.ToString("dd.MM.yyyy");
            this.End = booking.End.ToString("dd.MM.yyyy");
            this.BookingId = booking.Id;
        }
        public int BookingId { get; set; }
        public string EmailAddress { get; set; }
        public decimal Price { get; set; }
        public decimal Advance { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
    }
}

