//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCBierenApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bieren
    {
        public int BierNr { get; set; }
        public string Naam { get; set; }
        public int BrouwerNr { get; set; }
        public int SoortNr { get; set; }
        public Nullable<float> Alcohol { get; set; }
    
        public virtual Brouwer Brouwer { get; set; }
        public virtual Soort Soort { get; set; }
    }
}
