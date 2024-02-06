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
            CreateMap<User, UserDTO>();
            CreateMap<Apartment, ApartmentDTO>();
            CreateMap<Payment, PaymentDTO>();   
        }
    }
}
