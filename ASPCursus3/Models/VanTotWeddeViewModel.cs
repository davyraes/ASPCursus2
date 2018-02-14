using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPCursus3.Models
{
    public class VanTotWeddeViewModel:IValidatableObject
    {
        [Display(Name = "Van Wedde")]
        [Required(ErrorMessage = "Van wedde is verplicht")]
        public decimal? VanWedde { get; set; }
        [Display(Name = "Tot Wedde")]
        [Required(ErrorMessage ="Tot wedde is verplicht")]
        public decimal? TotWedde { get; set; }
        public List<Persoon> Personen { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();
            if(VanWedde>TotWedde)
            {
                validationResults.Add(new ValidationResult("TotWedde is kleiner dan VanWedde"));
            }
            return validationResults;
        }
    }
}