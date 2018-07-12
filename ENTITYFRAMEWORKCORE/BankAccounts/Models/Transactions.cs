using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace BankAccounts.Models
{
    public class Transactions
    {
        [Key]
        public int TransactionId { get; set; }
        [Display(Name ="Deposit/Withdrawal Amount")]    
        public double Amount { get; set; }
        public int UserId { get; set; }
        public Users Users { get; set; }
        public DateTime TransactionDate { get; set; }
    }    
}