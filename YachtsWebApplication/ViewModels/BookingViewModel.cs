using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using YachtsWebApplication.Entities;
using YachtsWebApplication.ViewModels.CustomValidations;

namespace YachtsWebApplication.ViewModels
{

    public class BookingViewModel
    {
        public BookingViewModel()
        {

        }
        public BookingViewModel(Yacht yacht)
        {
            this.Image = yacht.Image;
            this.ProductionCountry = yacht.ProductionCountry;
            this.ProductionYear = yacht.ProductionYear;
            this.Description = yacht.Description;
            this.CabinsNumber = yacht.CabinsNumber;
            this.MaxCrewNumber = yacht.MaxCrewNumber;
            this.PricePerDay = yacht.PricePerDay;
            this.MaxSpeed = yacht.MaxSpeed;
            this.Model = yacht.Model;
            this.CategoryName = yacht.YachtCategory.Name;
            this.YachtId = yacht.Id;
        }


        public int ProductionYear { get; set; }
        public string ProductionCountry { get; set; }
        public string Model { get; set; }
        public int CabinsNumber { get; set; }
        public int MaxCrewNumber { get; set; }
        public decimal PricePerDay { get; set; }
        public decimal MaxSpeed { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string CategoryName { get; set; }
        public int YachtId { get; set; }
        [Required(ErrorMessage = "Nie wprowadzono imienia.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Nie wprowadzono nazwiska.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Nie wprowadzono adresu email.")]
        [EmailAddress(ErrorMessage ="Nieprawidłowy format adresu email.")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Nie wprowadzono numeru telefonu.")]
        [RegularExpression("^\\d{9}$", ErrorMessage = "Niepoprawny format numeru telefonu.")]

        public string PhoneNumber { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Required(ErrorMessage = "Nie wprowadzono daty początku wypożyczenia.")]
        [Display(Name = "Start")]
        [MinimumStartYachtCharterDate(ErrorMessage = "Data początku wypożyczenia nie może być wcześniejsza niż dwa dni od bierzącej daty.")]
        public DateTime Start { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Required(ErrorMessage = "Nie wprowadzono daty końca wypożyczenia.")]
        [Display(Name = "Koniec")]
        public DateTime End { get; set; }
    }
}
