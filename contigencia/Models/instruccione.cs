//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace contigencia.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class instruccione
    {
        public instruccione()
        {
            this.plan_instruccion = new HashSet<plan_instruccion>();
        }
    
        public int id { get; set; }
        public string descripcion { get; set; }
        public Nullable<bool> activo { get; set; }
    
        public virtual ICollection<plan_instruccion> plan_instruccion { get; set; }
    }
}
