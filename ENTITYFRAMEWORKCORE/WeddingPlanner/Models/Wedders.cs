using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace WeddingPlanner.Models
{
    public class Wedders
    {
        [Key]
        public int WeddersId { get; set; }
        [Required]
        [Display(Name ="Wedder One")]            
        public string WedderOne { get; set; }
        [Required] 
        [Display(Name ="Wedder Two")]                           
        public string WedderTwo { get; set; }
        [Required] 
        [FutureDate] 
        [Display(Name ="Date")]                          
        public DateTime Date { get; set; }   
        [Required]   
        [Display(Name ="Wedding Address")]                              
        public string WeddingAddress { get; set; }  
        public int UserId { get; set; }
        public Users Users { get; set; }
        public List<Visitors> Visitors { get; set; } 
        public Wedders()
        {
            Visitors = new List<Visitors>();            
        }

        public class FutureDate : ValidationAttribute {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
                DateTime date = (DateTime)value;
                return date < DateTime.Now ? new ValidationResult("Date must be in the future.") : ValidationResult.Success;
            }
        }               
                              
    }
}