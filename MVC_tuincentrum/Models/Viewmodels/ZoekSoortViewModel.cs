using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_tuincentrum.Models.Viewmodels
{
    public class ZoekSoortViewModel
    {
        [Display(Name ="Begin soortnaam")]
        [Required(ErrorMessage = "Verplicht")]
        public string BeginNaam { get; set; }
        public List<Soort> Soorten { get; set; }
    }
}