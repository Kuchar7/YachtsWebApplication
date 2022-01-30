using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YachtsWebApplication.Entities;

namespace YachtsWebApplication.ViewModels
{
    public class YachtViewModel
    {
        public YachtViewModel(Yacht yacht)
        {
            this.Id = yacht.Id;
            this.Image = yacht.Image;
            this.Model = yacht.Model;
            this.PricePerDay = yacht.PricePerDay;
            this.CategoryName = yacht.YachtCategory.Name;
            this.MaxSpeed = yacht.MaxSpeed;

        }



        public int Id { get; set; }
        public string Image { get; set; }
        public decimal PricePerDay { get; set; }
        public string Model { get; set; }
        public string CategoryName { get; set; }
        public decimal MaxSpeed { get; set; }
    }
}

