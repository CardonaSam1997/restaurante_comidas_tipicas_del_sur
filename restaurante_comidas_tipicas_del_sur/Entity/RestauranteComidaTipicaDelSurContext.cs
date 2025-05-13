using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace restaurante_comidas_tipicas_del_sur.Entity;

public partial class RestauranteComidaTipicaDelSurContext : DbContext
{
    public RestauranteComidaTipicaDelSurContext()
    {
    }

    public RestauranteComidaTipicaDelSurContext(DbContextOptions<RestauranteComidaTipicaDelSurContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DetallexFactura> DetallexFacturas { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<Mesa> Mesas { get; set; }

    public virtual DbSet<Mesero> Meseros { get; set; }

    public virtual DbSet<Supervisor> Supervisors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=restaurante_comida_tipica_del_sur;Trusted_Connection=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Identificacion).HasName("PK__Cliente__D6F931E430D1C736");

            entity.ToTable("Cliente");

            entity.Property(e => e.Identificacion).ValueGeneratedNever();
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DetallexFactura>(entity =>
        {
            entity.HasKey(e => e.IdDetallesxFactura).HasName("PK__Detallex__7E9129904D337D59");

            entity.ToTable("DetallexFactura");

            entity.Property(e => e.IdDetallesxFactura).ValueGeneratedNever();
            entity.Property(e => e.Plato)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Valor).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdSupervisorNavigation).WithMany(p => p.DetallexFacturas)
                .HasForeignKey(d => d.IdSupervisor)
                .HasConstraintName("FK__DetallexF__IdSup__44FF419A");

            entity.HasOne(d => d.NroFacturaNavigation).WithMany(p => p.DetallexFacturas)
                .HasForeignKey(d => d.NroFactura)
                .HasConstraintName("FK__DetallexF__NroFa__440B1D61");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.NroFactura).HasName("PK__Factura__54177A84EAAEAB12");

            entity.ToTable("Factura");

            entity.Property(e => e.NroFactura).ValueGeneratedNever();
            entity.Property(e => e.Fecha).HasColumnType("datetime");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Factura__IdClien__3F466844");

            entity.HasOne(d => d.IdMeseroNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdMesero)
                .HasConstraintName("FK__Factura__IdMeser__412EB0B6");

            entity.HasOne(d => d.NroMesaNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.NroMesa)
                .HasConstraintName("FK__Factura__NroMesa__403A8C7D");
        });

        modelBuilder.Entity<Mesa>(entity =>
        {
            entity.HasKey(e => e.NroMesa).HasName("PK__Mesa__3F2EFFCF2C36C081");

            entity.ToTable("Mesa");

            entity.Property(e => e.NroMesa).ValueGeneratedNever();
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Mesero>(entity =>
        {
            entity.HasKey(e => e.IdMesero).HasName("PK__Mesero__5C84C56339D900AB");

            entity.ToTable("Mesero");

            entity.Property(e => e.IdMesero).ValueGeneratedNever();
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Supervisor>(entity =>
        {
            entity.HasKey(e => e.IdSupervisor).HasName("PK__Supervis__F80D528233076693");

            entity.ToTable("Supervisor");

            entity.Property(e => e.IdSupervisor).ValueGeneratedNever();
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
