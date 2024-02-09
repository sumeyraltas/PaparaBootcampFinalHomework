
using PaparaBootcampFinalHomework.Models.Admin;
using PaparaBootcampFinalHomework.Models.Apartments;
using PaparaBootcampFinalHomework.Models.MonthlyExpense;
using PaparaBootcampFinalHomework.Models.Payments;
using PaparaBootcampFinalHomework.Models.Tokens;
using PaparaBootcampFinalHomework.Models.UnitOfWorks;
using PaparaBootcampFinalHomework.Models.Users;

namespace Models.Shared
{
    public static class DIContainer
    {
        public static void DIContainers(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IApartmentRepository, ApartmentRepository>();
            services.AddScoped<IResidentRepository, ResidentRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IApartmentService, ApartmentService>();
            services.AddScoped<IResidentService, ResidentService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IMonthlyExpenseRepository, MonthlyExpenseRepository>();
            services.AddScoped<IMonthlyExpenseService, MonthlyExpenseService>();
        }
    }
}
