using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeckoTracker.Models
{
    public class PairingListView
    {
        public int PairingID { get; set; }

        [Display(Name = "Male Gecko ID")]
        public int? MaleGeckoID { get; set; }

        [Display(Name = "Male Gecko Name")]
        public string MaleGeckoName { get; set; }

        [Display(Name = "Female Gecko ID")]
        public int? FemaleGeckoID { get; set; }

        [Display(Name = "Female Gecko Name")]
        public string FemaleGeckoName { get; set; }

        public string Season { get; set; }
    }
}
