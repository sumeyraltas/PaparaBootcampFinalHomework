using Microsoft.EntityFrameworkCore;
using PaparaBootcampFinalHomework.Models.Apartments;
using PaparaBootcampFinalHomework.Models.Payments;
using PaparaBootcampFinalHomework.Models.Users;

namespace PaparaBootcampFinalHomework
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<MonthlyExpense> MonthlyExpenses { get; set; } 


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {  
            modelBuilder.Entity<Payment>()
        .Property(p => p.Amount)
        .HasColumnType("decimal(18,2)"); 
        }
     }
}
