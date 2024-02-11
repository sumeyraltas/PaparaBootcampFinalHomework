using AutoMapper;
using Models.Shared.ResponseDto;
using PaparaBootcampFinalHomework.Models.Apartments.DTOs;
using PaparaBootcampFinalHomework.Models.UnitOfWorks;
using PaparaBootcampFinalHomework.Models.Users;

namespace PaparaBootcampFinalHomework.Models.Apartments
{
    public class ApartmentService(IApartmentRepository apartmentRepository, IMapper mapper, IResidentRepository userRepository, IUnitOfWork unitOfWork) : IApartmentService
    {
        private readonly IApartmentRepository _apartmentRepository = apartmentRepository;
        private readonly IResidentRepository _userRepository = userRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _unitOfWork = unitOfWork; 

        public ResponseDto<int> AddApartment(ApartmentDTO request)
        {
            using var transaction = _unitOfWork.BeginTransaction();

            var apartment = new Apartment {
                ResidentId = request.ResidentId,
                OwnerTenant = request.OwnerTenant,
                IsOccupied = request.IsOccupied,
                Floor = request.Floor,
                //ApartmentNumber = request.ApartmentNumber,
                BlockInfo = request.BlockInfo,
                Type = request.Type
            }; if (_unitOfWork == null)
            {
                return ResponseDto<int>.Fail("UnitOfWork is not initialized.");
            }

            if (_apartmentRepository == null)
            {
                return ResponseDto<int>.Fail("ApartmentRepository is not initialized.");
            }
      
                var resident = _userRepository.GetByIdUser(request.ResidentId);
                if (resident == null)
                {
                    return ResponseDto<int>.Fail("Invalid ResidentId provided.");
                }

                apartment.Resident = resident;
           
            _apartmentRepository.AddApartment(apartment);

            _unitOfWork.Commit();
            transaction.Commit();

            return ResponseDto<int>.Success((int)apartment.Id);
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
            if (_unitOfWork == null)
            {
                return ResponseDto<List<ApartmentDTO>>.Fail("UnitOfWork is not initialized.");
            }

            if (_apartmentRepository == null)
            {
                return ResponseDto<List<ApartmentDTO>>.Fail("ApartmentRepository is not initialized.");
            }
            var apartmentList = _apartmentRepository.GetAllApartment();
            var apartmentListWithDto = _mapper.Map<List<ApartmentDTO>>(apartmentList);

            _unitOfWork.Commit();
            transaction.Commit();

            return ResponseDto<List<ApartmentDTO>>.Success(apartmentListWithDto);
        }

        public ApartmentDTO GetByIdApartment(int id)
        {
            using var transaction = _unitOfWork.BeginTransaction();

            var apartment = _apartmentRepository.GetByIdApartment(id);

            _unitOfWork.Commit();
            transaction.Commit();

            return _mapper.Map<ApartmentDTO>(apartment);
        }

        public ResponseDto<int> UpdateApartment(ApartmentDTO request)
        {
            using var transaction = _unitOfWork.BeginTransaction();

            var apartment = _apartmentRepository.GetByIdApartment(request.ApartmentNumber);
            if (apartment == null)
                return ResponseDto<int>.Fail("Apartment number is not valid.");

            apartment.ApartmentNumber = request.ApartmentNumber;
            apartment.ResidentId = request.ResidentId;

            _apartmentRepository.UpdateApartment(apartment);

            _unitOfWork.Commit();
            transaction.Commit();

            return ResponseDto<int>.Success((int)apartment.Id);
        }
        public ResponseDto<ApartmentDTO> GetApartmentByResidentId(int userId)
        {
            using var transaction = _unitOfWork.BeginTransaction();

            var apartment = _apartmentRepository.GetApartmentByResidentId(userId);
            var apartmentDto = _mapper.Map<ApartmentDTO>(apartment);

            _unitOfWork.Commit();
            transaction.Commit();

            return ResponseDto<ApartmentDTO>.Success(apartmentDto);
        }
        public ResponseDto<string> AssignResident(int apartmentId, int residentId)
        {
            var apartment = _apartmentRepository.GetByIdApartment(apartmentId);
            if (apartment == null)
            {
                return ResponseDto<string>.Fail("");
            }
            apartment.ResidentId = residentId;
            _apartmentRepository.UpdateApartment(apartment);

            return ResponseDto<string>.Success("");
        }
    }
}
