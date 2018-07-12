using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace TheDojoLeague.Models
{
    public class Dojos
    {
        [Key]
        public int DojoId { get; set; }

        [Required]
        [Display(Name ="Dojo Name")]
        public string DojoName { get; set; }

        [Required]
        [Display(Name ="Dojo Location")]
        public string DojoLocation { get; set; }

        [Required]
        [Display(Name ="Additional Dojo Information")]
        public string AdditionalDojoInformation { get; set; }

        public List<Ninjas> Ninjas { get; set; } 
        
        public Dojos()
        {
            Ninjas = new List<Ninjas>();            
        }

    }
}