using System.ComponentModel.DataAnnotations;

namespace LostInTheWoods.Models
{
    public class Trail
    {
        [Key]
        public int id { get; set; }                
        
        [Required]
        public string TrailName { get; set; }

        [Required]        
        [MinLength(10)]
        public string Description { get; set; }

        [Required]
        public double TrailLength { get; set; }

        [Required]
        public int ElevationChange { get; set; }  

        [Required]
        public double Longitude { get; set; }

        [Required]
        public double Latitude { get; set; }
                              
        
        
    }
}
