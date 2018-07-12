using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace TheDojoLeague.Models
{
    public class Ninjas
    {
        [Key]
        public int NinjaId { get; set; }

        [Required]
        [Display(Name ="Ninja Name")]
        public string NinjaName { get; set; }

        [Required]
        [Range(1, 10)]
        [Display(Name ="Ninjaing Level (1-10)")]
        public int NinjaingLevel { get; set; }

        [Required]
        [Display(Name ="Optional Description")]
        public string OptionalDescription { get; set; }

        public Dojos Dojos { get; set; }
        public int? DojoId { get; set; }
    }
}