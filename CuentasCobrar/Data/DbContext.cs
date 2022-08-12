using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CuentasCobrar.Models;

    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext (DbContextOptions<DbContext> options)
            : base(options)
        {
        }

    public virtual DbSet<Asientos_Contables> Asientos_Contables { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Tipos_documentos> Tipos_documentos { get; set; }
        public virtual DbSet<Transacciones> Transacciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asientos_Contables>()
                .Property(e => e.Identificador_Asiento)
                .IsUnicode(false);

            modelBuilder.Entity<Asientos_Contables>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Asientos_Contables>()
                .Property(e => e.Identificador_Cliente)
                .IsUnicode(false);

            modelBuilder.Entity<Asientos_Contables>()
                .Property(e => e.Tipo_de_Movimiento)
                .IsUnicode(false);

            modelBuilder.Entity<Asientos_Contables>()
                .Property(e => e.Monto_Asiento)
                .HasPrecision(30, 0);

            modelBuilder.Entity<Asientos_Contables>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<Asientos_Contables>()
                .Property(e => e.Id_registro)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Identificador)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Cedula)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Limite_credito)
                .HasPrecision(30, 0);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<Estado>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Tipos_documentos>()
                .Property(e => e.Identificador)
                .IsUnicode(false);

            modelBuilder.Entity<Tipos_documentos>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Tipos_documentos>()
                .Property(e => e.Cuenta_contable)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Tipos_documentos>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<Transacciones>()
                .Property(e => e.Identificador_Transacción)
                .IsUnicode(false);

            modelBuilder.Entity<Transacciones>()
                .Property(e => e.Tipo_de_Movimiento)
                .IsUnicode(false);

            modelBuilder.Entity<Transacciones>()
                .Property(e => e.Tipo_Documento)
                .IsUnicode(false);

            modelBuilder.Entity<Transacciones>()
                .Property(e => e.Número_de_Documento)
                .HasPrecision(10, 0);

            modelBuilder.Entity<Transacciones>()
                .Property(e => e.Identificador_Cliente)
                .IsUnicode(false);

            modelBuilder.Entity<Transacciones>()
                .Property(e => e.Monto)
                .HasPrecision(30, 0);

            modelBuilder.Entity<Transacciones>()
                .Property(e => e.Estado)
                .IsUnicode(false);
        }
}
