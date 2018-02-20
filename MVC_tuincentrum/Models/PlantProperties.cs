using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_tuincentrum.Models
{
    public class PlantProperties
    {
        [Display(ResourceType = typeof(Resources.Teksten),Name ="LabelPrijs")]
        [Range(0,1000,ErrorMessageResourceType =typeof(Resources.Teksten),ErrorMessageResourceName ="RangePrijs")]
        public decimal VerkoopPrijs { get; set; }
    }
}