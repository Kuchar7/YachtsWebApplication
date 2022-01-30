using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using YachtsWebApplication.ViewModels;

namespace YachtsWebApplication.Entities
{
    [Table("Bookings")]
    public class Booking
    {
        public Booking()
        {

        }
        public Booking(BookingViewModel bookingVm)
        {
            this.FirstName = bookingVm.FirstName;
            this.LastName = bookingVm.LastName;
            this.PhoneNumber = bookingVm.PhoneNumber;
            this.Price = bookingVm.PricePerDay * (int)(bookingVm.End - bookingVm.Start).TotalDays;
            this.Start = bookingVm.Start;
            this.End = bookingVm.End;
            this.YachtId = bookingVm.YachtId;
            this.EmailAddress = bookingVm.EmailAddress;
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Price { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        [ForeignKey("YachtId")]
        public virtual Yacht Yacht { get; set; }
        public int YachtId { get; set; }
    }
}
