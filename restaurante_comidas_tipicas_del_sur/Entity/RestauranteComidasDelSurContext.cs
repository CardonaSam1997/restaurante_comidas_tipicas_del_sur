using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace restaurante_comidas_tipicas_del_sur.Entity;

public partial class RestauranteComidasDelSurContext : DbContext
{
    public RestauranteComidasDelSurContext()
    {
    }

    public RestauranteComidasDelSurContext(DbContextOptions<RestauranteComidasDelSurContext> options)
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
        => optionsBuilder.UseSqlServer("workstation id=restaurante_comidas_del_sur.mssql.somee.com;packet size=4096;user id=sam0297_SQLLogin_1;pwd=8ikuxytgqg;data source=restaurante_comidas_del_sur.mssql.somee.com;persist security info=False;initial catalog=restaurante_comidas_del_sur;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Identificacion).HasName("PK__Cliente__D6F931E4FAF2A8AD");

            entity.ToTable("Cliente");

            entity.Property(e => e.Identificacion).ValueGeneratedNever();
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(150)
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
            entity.HasKey(e => e.IdDetallexFactura).HasName("PK__Detallex__F084433CEE66EE3E");

            entity.ToTable("DetallexFactura");

            entity.Property(e => e.Plato)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Valor).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdSupervisorNavigation).WithMany(p => p.DetallexFacturas)
                .HasForeignKey(d => d.IdSupervisor)
                .HasConstraintName("FK__DetallexF__IdSup__76969D2E");

            entity.HasOne(d => d.NroFacturaNavigation).WithMany(p => p.DetallexFacturas)
                .HasForeignKey(d => d.NroFactura)
                .HasConstraintName("FK__DetallexF__NroFa__75A278F5");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.NroFactura).HasName("PK__Factura__54177A848F5E09B6");

            entity.ToTable("Factura");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__Factura__IdClien__70DDC3D8");

            entity.HasOne(d => d.IdMeseroNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdMesero)
                .HasConstraintName("FK__Factura__IdMeser__72C60C4A");

            entity.HasOne(d => d.NroMesaNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.NroMesa)
                .HasConstraintName("FK__Factura__NroMesa__71D1E811");
        });

        modelBuilder.Entity<Mesa>(entity =>
        {
            entity.HasKey(e => e.NroMesa).HasName("PK__Mesa__3F2EFFCF68622E6A");

            entity.ToTable("Mesa");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Mesero>(entity =>
        {
            entity.HasKey(e => e.IdMesero).HasName("PK__Mesero__5C84C563D4A69C61");

            entity.ToTable("Mesero");

            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Supervisor>(entity =>
        {
            entity.HasKey(e => e.IdSupervisor).HasName("PK__Supervis__F80D5282BF37CBCB");

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
