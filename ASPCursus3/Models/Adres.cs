using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPCursus3.Models
{
    public class Adres
    {
        public string Straat { get; set; }
        public string Nummer { get; set; }
        public string Postcode { get; set; }
        public string Gemeente { get; set; }
        public override string ToString()
        {
            return $"{Straat} {Nummer} {Postcode} {Gemeente}";
        }
    }
    
}