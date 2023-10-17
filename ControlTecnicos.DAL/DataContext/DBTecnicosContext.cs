using Microsoft.EntityFrameworkCore;
using ControlTecnicos.Models;

namespace ControlTecnicos.DAL.DataContext;

public partial class DBTecnicosContext : DbContext
{
    public DBTecnicosContext()
    {
    }

    public DBTecnicosContext(DbContextOptions<DBTecnicosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Elemento> Elementos { get; set; }

    public virtual DbSet<ElementosTecnico> ElementosTecnicos { get; set; }

    public virtual DbSet<Sucursal> Sucursales { get; set; }

    public virtual DbSet<Tecnico> Tecnicos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(local); DataBase=DBTECNICOS;Integrated Security=true; Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Elemento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Elemento__3214EC07F6CCEE7E");

            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ElementosTecnico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Elemento__3214EC07C72D95E8");

            entity.ToTable("ElementosTecnico");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

            entity.HasOne(d => d.Elemento).WithMany(p => p.ElementosTecnicos)
                .HasForeignKey(d => d.ElementoId)
                .HasConstraintName("FK__Elementos__Eleme__4CA06362");

            entity.HasOne(d => d.Tecnico).WithMany(p => p.ElementosTecnicos)
                .HasForeignKey(d => d.TecnicoId)
                .HasConstraintName("FK__Elementos__Tecni__4BAC3F29");
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sucursal__3214EC0718BFA179");

            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tecnico>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tecnicos__3214EC07175C4452");

            entity.Property(e => e.Codigo)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.SueldoBase).HasColumnType("decimal(12, 2)");

            entity.HasOne(d => d.Sucursal).WithMany(p => p.Tecnicos)
                .HasForeignKey(d => d.SucursalId)
                .HasConstraintName("FK__Tecnicos__Sucurs__47DBAE45");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
