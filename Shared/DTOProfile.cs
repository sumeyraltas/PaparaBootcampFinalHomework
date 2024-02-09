using AutoMapper;
using PaparaBootcampFinalHomework.Models.Admin;
using PaparaBootcampFinalHomework.Models.Apartments;
using PaparaBootcampFinalHomework.Models.MonthlyExpense;
using PaparaBootcampFinalHomework.Models.MonthlyExpense.DTOs;
using PaparaBootcampFinalHomework.Models.Payments;
using PaparaBootcampFinalHomework.Models.Payments.DTOs;
using PaparaBootcampFinalHomework.Models.Residents.DTOs;
using PaparaBootcampFinalHomework.Models.Tokens;
using PaparaBootcampFinalHomework.Models.Users;

namespace PaparaBootcampFinalHomework.Shared
{
    public class DTOProfile : Profile
    {
        public DTOProfile()
        {
            CreateMap<Resident, ResidentDTO>();
            CreateMap<Apartment, ApartmentDTO>();
            CreateMap<Payment, PaymentDTO>();
            CreateMap<MonthlyExpense, GasBillsDTO>();
            CreateMap<MonthlyExpense, ElectricityBillsDTO>();
            CreateMap<MonthlyExpense, WaterBillsDTO>();
            // CreateMap<AppAdmin, AdminCreateRequestDto>();

        }
    }
}
