using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PaparaBootcampFinalHomework.Models.Apartments;
using PaparaBootcampFinalHomework.Models.MonthlyExpense;
using PaparaBootcampFinalHomework.Models.Payments;
using PaparaBootcampFinalHomework.Models.Tokens;
using PaparaBootcampFinalHomework.Models.Users;

namespace PaparaBootcampFinalHomework.Shared
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<AppAdmin, AppRole, Guid>(options)
    {
        
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Resident> Residents { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<MonthlyExpense> MonthlyExpenses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<MonthlyExpense>()
                .Property(p => p.ElectricityBill)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<MonthlyExpense>()
                .Property(p => p.WaterBill)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<MonthlyExpense>()
                .Property(p => p.GasBill)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Resident>()
                .HasOne(r => r.Apartment)
                .WithOne(a => a.Resident)
                .HasForeignKey<Apartment>(a => a.ResidentId);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Resident)
                .WithMany(r => r.Payments)
                .HasForeignKey(p => p.ResidentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MonthlyExpense>()
                .HasKey(me => new { me.Year, me.Month });

            modelBuilder.Entity<MonthlyExpense>()
                .HasMany(me => me.Payments)
                .WithOne(p => p.MonthlyExpense)
                .HasForeignKey(p => new { p.Year, p.Month })
                .OnDelete(DeleteBehavior.Restrict); 
        }


    }

}

