using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeckoTracker.Models
{
    public class GeckoCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        [Display(Name = "Gecko Name")]
        public string GeckoName { get; set; }

        [Required]
        [Display(Name = "Sex of Gecko: please check box if gecko is male.")]
        public bool GeckoSexIsMale { get; set; }

        [Required]
        [Range(2, 10000)]
        [Display(Name = "Weight of Gecko in grams (g)")]
        public double GeckoWeight { get; set; }

        [Required]
        [Display(Name = "Hatch Date: (dd/mm/yyyy)")]
        public string HatchDate { get; set; }
    }
}
