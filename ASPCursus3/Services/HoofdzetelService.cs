using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASPCursus3.Models;

namespace ASPCursus3.Services
{
    public class HoofdzetelService
    {
        public HoofdZetel read()
        {
            return new HoofdZetel
            {
                Straat = "Keizerslaan",
                HuisNr = "11",
                Postcode = "1000",
                Gemeente = "Brussel"
            };
        }
    }
}