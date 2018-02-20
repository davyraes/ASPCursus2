using ASPCursus3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPCursus3.Attributes
{
    public class WeddeScoreAttribute:ValidationAttribute
    {
        public WeddeScoreAttribute() { ErrorMessage = "Personen met een score onder de 3 kunnen geen wedde boven 3000 hebben"; }
        public override bool IsValid(object value)
        {
            Persoon p = value as Persoon;
            return !((p.Score < 3) && (p.Wedde > 3000));
        }
    }
    
}