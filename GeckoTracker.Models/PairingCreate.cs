using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeckoTracker.Data;

namespace GeckoTracker.Models
{
    public class PairingCreate
    {
        public int? MaleGeckoID { get; set; }

        [Display(Name = "Name of Male Gecko")]
        public string MaleGeckoName { get; set; }

        public int? FemaleGeckoID { get; set; }

        [Display(Name = "Name of Female Gecko")]
        public string FemaleGeckoName { get; set; }

        [Required]
        [Display(Name = "Season (YYYY)")]
        [MinLength(4, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(4, ErrorMessage = "There are too many characters in this field.")]
        public string Season { get; set; }
    }
}
