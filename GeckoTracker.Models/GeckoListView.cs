using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeckoTracker.Models
{
    public class GeckoListView
    {
        public int GeckoID { get; set; }
        [Display (Name = "Gecko Name")]
        public string GeckoName { get; set; }
        [Display (Name = "Is Gecko Male?")]
        public bool GeckoSexIsMale { get; set; }
        [Display(Name = "Gecko Weight (in grams)")]
        public double GeckoWeight { get; set; }
        [Display(Name = "Hatch Date")]
        public string HatchDate { get; set; }
    }
}
