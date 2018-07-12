using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace BankAccounts.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name ="Last Name")]
        public string LastName { get; set; }

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

        [Required]        
        [Compare("Password", ErrorMessage = "Password and confirmation must match.")]
        [Display(Name ="Confirm Password")]
        [DataType(DataType.Password)]
        public string Confirm { get; set; }

        public int Balance {get; set;}

        public List<Transactions> Transactions { get; set; }
 
        public Users()
        {
            Balance = 0;
            Transactions = new List<Transactions>();
        }

    }
}