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
    
    public partial class destinatario
    {
        public destinatario()
        {
            this.destinatario_persona = new HashSet<destinatario_persona>();
        }
    
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public Nullable<bool> activo { get; set; }
        public Nullable<int> id_planescontigencia { get; set; }
    
        public virtual planescontingencia planescontingencia { get; set; }
        public virtual ICollection<destinatario_persona> destinatario_persona { get; set; }
    }
}
