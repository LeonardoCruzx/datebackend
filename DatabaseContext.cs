using Date.Models;
using Microsoft.EntityFrameworkCore;

public class DatabaseContext : DbContext
{
    public DbSet<MyDate> MyDates { get; set; }

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MyDate>().ToTable("MyDates");

        modelBuilder.Entity<MyDate>().HasKey(x => x.Id);
        modelBuilder.Entity<MyDate>().Property(x => x.Id).ValueGeneratedOnAdd();
    }
}