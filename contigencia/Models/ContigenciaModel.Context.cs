﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ContingenciaEntities : DbContext
    {
        public ContingenciaEntities()
            : base("name=ContingenciaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Condicion> Condiciones { get; set; }
        public virtual DbSet<Escenario> Escenarios { get; set; }
        public virtual DbSet<Instruccion> Instrucciones { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<PlanContingencia> PlanContingencias { get; set; }
        public virtual DbSet<NivelesDeRiesgo> NivelesDeRiesgo { get; set; }
        public virtual DbSet<Destinatario> Destinatarios { get; set; }
        public virtual DbSet<PlanContingencia_Destinatario> PlanContingencia_Destinatario { get; set; }
    }
}
