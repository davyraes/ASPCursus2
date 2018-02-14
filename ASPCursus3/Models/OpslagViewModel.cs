using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ASPCursus3.Models
{
    public class OpslagViewModel
    {
        [Required(ErrorMessage = "Van wedde is een verplicht veld")]
        [Display(Name ="Van wedde:")]
        public decimal? VanWedde { get; set; }
        [Required(ErrorMessage ="Tot wedde is een verplicht veld")]
        [Display(Name = "Tot wedde")]
        public decimal? TotWedde { get; set; }
        [Required(ErrorMessage ="Percentage is een verplicht veld")]
        [Range(0,100,ErrorMessage ="De minimum- en maximumwaarden vorr percentage zijn: {1} en {2}")]
        [Display(Name ="Percentage")]
        public decimal? Percentage { get; set; }
    }
}