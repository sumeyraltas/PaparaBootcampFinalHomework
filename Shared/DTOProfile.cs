using AutoMapper;
using PaparaBootcampFinalHomework.Models.Apartments;
using PaparaBootcampFinalHomework.Models.Payments;
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
        }
    }
}
