using Microsoft.EntityFrameworkCore;

namespace ConstellationGarage.Models;

public partial class GarageautomobileContext : DbContext
{
    public GarageautomobileContext()
    {
    }

    public GarageautomobileContext(DbContextOptions<GarageautomobileContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(Config.GetSection("ConnectionStrings")["sqlserver"]);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__brands__357D4CF8C2528B45");

            entity.ToTable("brands");

            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.Icon).HasColumnName("icon");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cars__3213E83F01802EF8");

            entity.ToTable("cars");

            entity.HasIndex(e => e.CodeBrand, "IX_cars_code_brand");

            entity.HasIndex(e => e.CodeCategorie, "IX_cars_code_categorie");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CodeBrand)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("code_brand");
            entity.Property(e => e.CodeCategorie)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("code_categorie");
            entity.Property(e => e.Color)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("color");
            entity.Property(e => e.Essence)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("essence");
            entity.Property(e => e.New).HasColumnName("new");

            entity.HasOne(d => d.CodeBrandNavigation).WithMany(p => p.Cars)
                .HasForeignKey(d => d.CodeBrand)
                .HasConstraintName("FK__cars__code_brand__3D5E1FD2");

            entity.HasOne(d => d.CodeCategorieNavigation).WithMany(p => p.Cars)
                .HasForeignKey(d => d.CodeCategorie)
                .HasConstraintName("FK__cars__code_categ__3E52440B");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__categori__357D4CF89E4D866F");

            entity.ToTable("categories");

            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
