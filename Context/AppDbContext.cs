using Microsoft.EntityFrameworkCore;
using PhoneBook.Models;

namespace PhoneBook.Context;

public class AppDbContext(IConfiguration configuration) : DbContext
{
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Phone> Phones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(configuration["ConnectionString"]);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>()
             .HasMany(c => c.Phones)
             .WithOne(p => p.Contact)
             .HasForeignKey(c => c.ContactId);
    }
}
