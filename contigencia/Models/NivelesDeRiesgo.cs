//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace contigencia.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class NivelesDeRiesgo
    {
        public NivelesDeRiesgo()
        {
            this.Escenario = new HashSet<Escenario>();
        }
    
        public int id { get; set; }
        public string descripcion { get; set; }
        public string color { get; set; }
        public Nullable<int> prioridad { get; set; }
    
        public virtual ICollection<Escenario> Escenario { get; set; }
    }
}
