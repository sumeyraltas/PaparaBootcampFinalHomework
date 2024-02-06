
using PaparaBootcampFinalHomework.Models.Admin;
using PaparaBootcampFinalHomework.Models.Apartments;
using PaparaBootcampFinalHomework.Models.Payments;
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
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
        }
    }
}
