using System;
using System.Globalization;
using System.ComponentModel.DataAnnotations;


namespace RESTauranter.Models
{
    public class RegisterViewModels
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string ReviewerName { get; set; }

        [Required]

        public string RestaurantName { get; set; }

        [Required]
        public string Review { get; set; }

        [Required]
        public DateTime DateOfVisit { get; set; }

        [Required]
        public int Stars { get; set; }
    }
}
