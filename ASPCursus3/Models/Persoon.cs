﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using ASPCursus3.Attributes;

namespace ASPCursus3.Models
{
    [WeddeScore]
    public class Persoon
    {
        public int ID { get; set; }
        [StringLength(255,ErrorMessage ="Max {1} tekens voor {0}")]
        public string Voornaam { get; set; }
        public string Familienaam { get; set; }
        [OnevenTussenTweeGrenzen(1,5,ErrorMessage ="Enkel oneven scores tussen {1} en {2} !")]
        public int Score { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0.00}")]
        public decimal Wedde { get; set; }
        [Display(Name ="Wachtwoord")]
        [DataType(DataType.Password)]
        [StringLength(20,MinimumLength =8,ErrorMessage ="Het wachtwoord bevat min.{2},max {1} tekens")]
        public string Paswoord { get; set; }
        [Compare("Paswoord",ErrorMessage ="{0} verschilt van {1}")]
        [DataType(DataType.Password)]
        public string HerhaalPaswoord { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}",ApplyFormatInEditMode =true)]
        [DataType(DataType.Date)]
        [System.Web.Mvc.Remote("ValidateDOB","Persoon")]
        public DateTime Geboren { get; set; }
        public bool Gehuwd { get; set; }
        [DataType(DataType.MultilineText)]
        public string Opmerkingen { get; set; }
        public Geslacht Geslacht { get; set; }
        public Adres Adres { get; set; }
    }
}