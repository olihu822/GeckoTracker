using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeckoTracker.Data;

namespace GT.Data
{
    public class Loan
    {
        [Key]
        [Required]
        public int LoanID { get; set; }

        public virtual Gecko LoanedGecko { get; set; }

        [Required]
        [ForeignKey("LoanedGecko")]
        [Display(Name = "Gecko On Loan")]
        public int LoanedGeckoID { get; set; }

        public string LoanedGeckoName { get; set; }

        public Guid OwnerID { get; set; }

        [Required]
        public string LeaseeName { get; set; }

        [Required]
        public DateTime LoanStart { get; set; }
        
        public string LoanDuration { get; set; }
    }
}
