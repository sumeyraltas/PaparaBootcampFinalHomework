using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PaparaBootcampFinalHomework.Models.Apartments;
using PaparaBootcampFinalHomework.Models.Payments;
using PaparaBootcampFinalHomework.Models.Tokens;
using PaparaBootcampFinalHomework.Models.Users;

namespace PaparaBootcampFinalHomework.Shared
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<AppAdmin, AppRole, Guid>(options)
    {
        // : IdentityDbContext<AppUser, AppRole, Guid>(options)
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<User> Userss { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<MonthlyExpense> MonthlyExpenses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          base.OnModelCreating(modelBuilder);
        
        //    modelBuilder.Entity<IdentityUserLogin<Guid>>().HasNoKey();

            modelBuilder.Entity<Payment>()
        .Property(p => p.Amount)
        .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<MonthlyExpense>().
                Property(p => p.ElectricityBill)
        .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<MonthlyExpense>().
                Property(p => p.WaterBill)
        .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<MonthlyExpense>().
                Property(p => p.GasBill)
        .HasColumnType("decimal(18,2)");
            //one to one
            modelBuilder.Entity<Apartment>()
               .HasOne(a => a.User)
               .WithOne(u => u.Apartment)
               .HasForeignKey<User>(u => u.ApartmentId);
            //one to many bir user çok ödeme
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.User)
            .WithMany(u => u.Payments)
            .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<MonthlyExpense>()
               .HasKey(me => new { me.Year, me.Month });

            modelBuilder.Entity<MonthlyExpense>()
                .HasMany(me => me.Payments)
                .WithOne(p => p.MonthlyExpense)
                .HasForeignKey(p => new { p.Year, p.Month });
        }

    }

}

