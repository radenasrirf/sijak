//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SIP.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Kota
    {
        public Kota()
        {
            this.Samsat = new HashSet<Samsat>();
        }
    
        public int ID { get; set; }
        public int ProvinsiID { get; set; }
        public string Nama { get; set; }
    
        public virtual Provinsi Provinsi { get; set; }
        public virtual ICollection<Samsat> Samsat { get; set; }
    }
}
