using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeckoTracker.Models
{
    public class LoanListView
    {
        public int LoanID { get; set; }

        [Display(Name = "GeckoID")]
        public int LoanedGeckoID { get; set; }

        [Display(Name = "Gecko Name")]
        public string LoanedGeckoName { get; set; }

        [Display(Name = "Name of Leasee")]
        public string LeaseeName { get; set; }

        [Display(Name = "Loan Start Date")]
        public DateTime LoanStart { get; set; }

        [Display(Name = "Loan Duration")]
        public string LoanDuration { get; set; }
    }
}
