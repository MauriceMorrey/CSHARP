using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace WeddingPlanner.Models
{
    public class Visitors
    {
        [Key]
        public int VisitorsId { get; set; }
        public int UserId { get; set; }
        public Users Users { get; set; }
        public int WeddersId { get; set; }
        public Wedders Wedders { get; set; }
                
       
    }    
}