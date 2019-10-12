using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeckoTracker.Data;

namespace GeckoTracker.Models
{
    public class LoanCreate
    {
        [Display(Name = "GeckoID")]
        public int LoanedGeckoID { get; set; }

        [Display(Name = "Gecko Name")]
        public string LoanedGeckoName { get; set; }

        [Required]
        [Display(Name = "Name of Leasee")]
        public string LeaseeName { get; set; }

        [Required]
        [Display(Name = "Loan Start Date")]
        public DateTime LoanStart { get; set; }

        [Display(Name = "Loan Duration")]
        public string LoanDuration { get; set; }


    }
}
