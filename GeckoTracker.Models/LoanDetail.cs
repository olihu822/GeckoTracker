using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeckoTracker.Data;

namespace GeckoTracker.Models
{
    public class LoanDetail
    {
        public int LoanID { get; set; }

        public Gecko LoanedGecko { get; set; }

        [Display(Name = "GeckoID")]
        public int LoanedGeckoID { get; set; }

        [Display(Name = "Gecko Name")]
        public string LoanedGeckoName { get; set; }

        [Display(Name = "Leasee Name")]
        public string LeaseeName { get; set; }

        [Display(Name = "Loan Start Date")]
        public DateTime LoanStart { get; set; }

        [Display(Name = "Loan Duration")]
        public string LoanDuration { get; set; }
    }
}
