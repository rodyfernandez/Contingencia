﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class contingenciaEntities : DbContext
    {
        public contingenciaEntities()
            : base("name=contingenciaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<condicione> condiciones { get; set; }
        public virtual DbSet<destinatario> destinatarios { get; set; }
        public virtual DbSet<escenario> escenarios { get; set; }
        public virtual DbSet<instruccione> instrucciones { get; set; }
        public virtual DbSet<persona> personas { get; set; }
        public virtual DbSet<planescontingencia> planescontingencias { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<escenario_condicion> escenario_condicion { get; set; }
        public virtual DbSet<destinatario_persona> destinatario_persona { get; set; }
        public virtual DbSet<plan_escenario> plan_escenario { get; set; }
        public virtual DbSet<plan_instruccion> plan_instruccion { get; set; }
    }
}
