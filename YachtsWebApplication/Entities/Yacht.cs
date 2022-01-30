using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YachtsWebApplication.Entities
{
    [Table("Yachts")]
    public class Yacht
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProductionYear { get; set; }
        public string ProductionCountry { get; set; }
        public string Model { get; set; }
        public int CabinsNumber { get; set; }
        public int MaxCrewNumber { get; set; }
        public decimal PricePerDay { get; set; }
        public decimal MaxSpeed { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }


        [ForeignKey("YachtCategoryId")]
        public virtual YachtCategory YachtCategory { get; set; }
        public int YachtCategoryId { get; set; }
    }
}
