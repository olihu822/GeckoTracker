using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeckoTracker.Models
{
    public class GeckoDetail
    {
        public int GeckoID { get; set; }

        [Display(Name = "Gecko Name")]
        public string GeckoName { get; set; }

        [Display(Name = "Is Gecko Male?")]
        public bool GeckoSexIsMale { get; set; }

        [Display(Name = "Weight of Gecko")]
        public double GeckoWeight { get; set; }

        [Display(Name = "Hatch Date")]
        public string HatchDate { get; set; }
    }
}
