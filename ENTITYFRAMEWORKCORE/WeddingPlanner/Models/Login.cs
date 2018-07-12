using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace WeddingPlanner.Models
{
    public class Login
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name ="Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
 
        [Required]
        [Display(Name ="Password")]
        [DataType(DataType.Password)]
        [MinLength(8)]        
        public string Password { get; set; }

    }
}