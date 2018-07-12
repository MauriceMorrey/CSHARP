using System;
using System.Globalization;
using System.ComponentModel.DataAnnotations;


namespace RESTauranter.Models
{
    public class Reviews
    {
        [Key]
        public int id { get; set; }
        public string ReviewerName { get; set; }

        public string RestaurantName { get; set; }
        public string Review { get; set; }
        public DateTime DateOfVisit { get; set; }
        public int Stars { get; set; }
    }
}
