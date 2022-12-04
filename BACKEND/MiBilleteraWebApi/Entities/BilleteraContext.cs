using System;
using System.Collections.Generic;
using Entities;
using MEntities;
using Microsoft.EntityFrameworkCore;


namespace Entities
{
    public partial class BilleteraContext : DbContext
    {
        public BilleteraContext()
        {
        }

        public BilleteraContext(DbContextOptions<BilleteraContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Cuenta> Cuentas { get; set; } = null!;
        public virtual DbSet<Localidad> Localidades { get; set; } = null!;
        public virtual DbSet<Moneda> Monedas { get; set; } = null!;
        public virtual DbSet<Operacion> OperacionesDepositoOExtraccions { get; set; } = null!;
        public virtual DbSet<Provincia> Provincias { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-H342I2C\\SQLEXPRESS; Database=master; User=sa; Password=Ese36429770; TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("Clientes_Id_Cliente_PK");

                entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Contrasenia)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cuil)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaAlta)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Alta")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaBaja)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Baja");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("Fecha_Nacimiento");

                entity.Property(e => e.IdLocalidad).HasColumnName("Id_Localidad");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdLocalidadNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdLocalidad)
                    .HasConstraintName("Clientes_Id_Localidad_FK");
            });

            modelBuilder.Entity<Cuenta>(entity =>
            {
                entity.HasKey(e => e.IdCuenta)
                    .HasName("Cuentas_Id_Cuenta_PK");

                entity.HasIndex(e => e.Cvu, "Cuentas_Cvu_UK")
                    .IsUnique();

                entity.Property(e => e.IdCuenta).HasColumnName("Id_Cuenta");

                entity.Property(e => e.EstaHabilitada).HasColumnName("Esta_Habilitada");

                entity.Property(e => e.FechaAlta)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Alta")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaBaja)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Baja");

                entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");

                entity.Property(e => e.IdMoneda).HasColumnName("Id_Moneda");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Cuenta)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("Cuentas_Id_Cliente_FK");

                entity.HasOne(d => d.IdMonedaNavigation)
                    .WithMany(p => p.Cuenta)
                    .HasForeignKey(d => d.IdMoneda)
                    .HasConstraintName("Cuentas_Id_Moneda_FK");
            });

            modelBuilder.Entity<Localidad>(entity =>
            {
                entity.HasKey(e => e.IdLocalidad)
                    .HasName("Localidades_Id_Localidad_PK");

                entity.Property(e => e.IdLocalidad).HasColumnName("Id_Localidad");

                entity.Property(e => e.FechaAlta)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Alta")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaBaja)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Baja");

                entity.Property(e => e.IdProvincia).HasColumnName("Id_Provincia");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProvinciaNavigation)
                    .WithMany(p => p.Localidades)
                    .HasForeignKey(d => d.IdProvincia)
                    .HasConstraintName("Localidades_Id_Provincia_FK");
            });

            modelBuilder.Entity<Moneda>(entity =>
            {
                entity.HasKey(e => e.IdMoneda)
                    .HasName("Monedas_Id_Moneda_PK");

                entity.Property(e => e.IdMoneda).HasColumnName("Id_Moneda");

                entity.Property(e => e.FechaAlta)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Alta")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaBaja)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Baja");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Operacion>(entity =>
            {
                entity.HasKey(e => e.IdOperacion)
                    .HasName("Operaciones_Id_Operacion_PK");

                entity.ToTable("Operaciones_deposito_o_extraccion");

                entity.Property(e => e.IdOperacion).HasColumnName("Id_Operacion");

                entity.Property(e => e.EsDeposito).HasColumnName("Es_Deposito");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaBaja)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Baja");

                entity.Property(e => e.IdCuenta).HasColumnName("Id_Cuenta");

                entity.HasOne(d => d.IdCuentaNavigation)
                    .WithMany(p => p.Operacion)
                    .HasForeignKey(d => d.IdCuenta)
                    .HasConstraintName("Operaciones_Id_Cuenta_FK");
            });

            modelBuilder.Entity<Provincia>(entity =>
            {
                entity.HasKey(e => e.IdProvincia)
                    .HasName("Provincias_Id_Provincia_PK");

                entity.Property(e => e.IdProvincia).HasColumnName("Id_Provincia");

                entity.Property(e => e.FechaAlta)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Alta")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaBaja)
                    .HasColumnType("datetime")
                    .HasColumnName("Fecha_Baja");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
