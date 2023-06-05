using SDI_App.Models;
using Microsoft.EntityFrameworkCore;

namespace SDI_App.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }


    public DbSet<Phone> Phones { get; set; } = default!;
    public DbSet<Person> Persons { get; set; } = default!;
    public DbSet<Tablet> Tablets { get; set; } = default!;
    public DbSet<AccessedWebsite> AccessedWebsites { get; set; } = default!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // One to many relationship between Person and Phone
        modelBuilder.Entity<Person>()
            .HasMany(p => p.AbsPhones)
            .WithOne(p => p.AbsPerson)
            .HasForeignKey(p => p.PersonId);
        // One to one relationship between Person and Tablet
        modelBuilder.Entity<Person>()
            .HasOne(p => p.AbsTablet)
            .WithOne(t => t.AbsPerson)
            .HasForeignKey<Tablet>(t => t.PersonId)
            .OnDelete(DeleteBehavior.NoAction);
        // Many to many relationship between Phone and Tablet through AccessedWebsite
        modelBuilder.Entity<AccessedWebsite>()
            .HasOne(p => p.AbsPhone)
            .WithMany(p => p.AbsAccessedWebsites)
            .HasForeignKey(p => p.PhoneId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<AccessedWebsite>()
            .HasOne(p => p.AbsTablet)
            .WithMany(p => p.AbsAccessedWebsites)
            .HasForeignKey(p => p.TabletId)
            .OnDelete(DeleteBehavior.Cascade);
    }

}