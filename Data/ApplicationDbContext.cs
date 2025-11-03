using Microsoft.EntityFrameworkCore;
using BookApi.Models;

namespace BookApi.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable("books");

            entity.HasKey(e => e.Id);
            
            entity.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();
            
            entity.Property(e => e.Title)
                .HasColumnName("title")
                .IsRequired()
                .HasMaxLength(500);
            
            entity.Property(e => e.Author)
                .HasColumnName("author")
                .IsRequired()
                .HasMaxLength(300);
            
            entity.Property(e => e.Isbn)
                .HasColumnName("isbn")
                .HasMaxLength(20);
            
            entity.Property(e => e.PublishedDate)
                .HasColumnName("published_date")
                .IsRequired()
                .HasConversion(
                    v => v.Kind == DateTimeKind.Unspecified 
                        ? DateTime.SpecifyKind(v, DateTimeKind.Utc) 
                        : v.ToUniversalTime(),
                    v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
            
            entity.Property(e => e.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired()
                .HasConversion(
                    v => v.Kind == DateTimeKind.Unspecified 
                        ? DateTime.SpecifyKind(v, DateTimeKind.Utc) 
                        : v.ToUniversalTime(),
                    v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
        });
    }
}

