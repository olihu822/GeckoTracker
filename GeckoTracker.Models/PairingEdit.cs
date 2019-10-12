using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeckoTracker.Data;

namespace GeckoTracker.Models
{
    public class PairingEdit
    {
        public int PairingID { get; set; }

        [Display(Name = "ID of Male Gecko")]
        public int? MaleGeckoID { get; set; }

        public  string MaleGeckoName { get; set; }

        [Display(Name = "ID of Female Gecko")]
        public int? FemaleGeckoID { get; set; }

        public string FemaleGeckoName { get; set; }

        [Required]
        [Display(Name = "Season (YYYY)")]
        [MinLength(4, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(4, ErrorMessage = "There are too many characters in this field.")]
        public string Season { get; set; }
    }
}
