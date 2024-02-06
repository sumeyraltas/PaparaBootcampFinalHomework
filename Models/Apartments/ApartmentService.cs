using AutoMapper;
using Models.Shared.ResponseDto;
using PaparaBootcampFinalHomework.Models.UnitOfWorks;
using PaparaBootcampFinalHomework.Models.Users;

namespace PaparaBootcampFinalHomework.Models.Apartments
{
    public class ApartmentService : IApartmentService
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ResponseDto<int> AddApartment(ApartmentDTO request)
        {
            using var transaction = _unitOfWork.BeginTransaction();

            var apartment = new Apartment { };
            _apartmentRepository.AddApartment(apartment);

            _unitOfWork.Commit();
            transaction.Commit();

            return ResponseDto<int>.Success(apartment.Id);
        }

        public void DeleteApartment(int id)
        {
            using var transaction = _unitOfWork.BeginTransaction();

            _apartmentRepository.DeleteApartment(id);

            _unitOfWork.Commit();
            transaction.Commit();
        }

        public ResponseDto<List<ApartmentDTO>> GetAllApartment()
        {
            using var transaction = _unitOfWork.BeginTransaction();

            var apartmentList = _apartmentRepository.GetAllApartment();
            var apartmentListWithDto = _mapper.Map<List<ApartmentDTO>>(apartmentList);

            _unitOfWork.Commit();
            transaction.Commit();

            return ResponseDto<List<ApartmentDTO>>.Success(apartmentListWithDto);
        }

        public ApartmentDTO GetByIdApartment(int id)
        {
            using var transaction = _unitOfWork.BeginTransaction();

            var apartment = _apartmentRepository.GetAllApartment();

            _unitOfWork.Commit();
            transaction.Commit();

            return _mapper.Map<ApartmentDTO>(apartment);
        }

        public void UpdateApartment(ApartmentDTO request)
        {
            using var transaction = _unitOfWork.BeginTransaction();

            var apartment = _apartmentRepository.GetByIdApartment(request.Id);
            if (apartment == null)
                return; // or handle the case where user is not found



            _apartmentRepository.UpdateApartment(apartment);

            _unitOfWork.Commit();
            transaction.Commit();
        }
    }
}
