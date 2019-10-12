using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeckoTracker.Data;

namespace GeckoTracker.Data
{
    public class Pairing
    {
        [Key]
        [Required]
        public int PairingID { get; set; }

        public virtual Gecko MaleGecko { get; set; }

        [ForeignKey("MaleGecko")]
        [Display(Name = "Male Gecko")]
        public int? MaleGeckoID { get; set; }

        public string MaleGeckoName {get; set;}
       
        public virtual Gecko FemaleGecko { get; set; }

        [ForeignKey("FemaleGecko")]
        [Display(Name = "Female Gecko")]
        public int? FemaleGeckoID { get; set; }

        public string FemaleGeckoName { get; set; }

        [Required]
        public string Season { get; set; }

        public Guid OwnerID { get; set; }
    }
}
