using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeckoTracker.Data
{
    public class Gecko
    {
        [Key]
        public int GeckoID { get; set; }
        [Required]
        [Display(Name = "Gecko Name")]
        public string GeckoName { get; set; }
        [Required]
        [Display(Name = "Sex of Gecko")]
        public bool GeckoSexIsMale { get; set; }
        [Required]
        [Display(Name = "Weight of Gecko")]
        public double GeckoWeight { get; set; }
        [Required]
        [Display(Name = "Hatch Date")]
        public string HatchDate { get; set; }
        public Guid OwnerID { get; set; }

    }
}
