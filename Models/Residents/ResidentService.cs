﻿using AutoMapper;
using Models.Shared.ResponseDto;
using PaparaBootcampFinalHomework.Models.Residents.DTOs;
using PaparaBootcampFinalHomework.Models.UnitOfWorks;

namespace PaparaBootcampFinalHomework.Models.Users
{

    public class ResidentService(IResidentRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork) : IResidentService
        {
            private readonly IResidentRepository _userRepository = userRepository;
            private readonly IMapper _mapper = mapper;
            private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public ResponseDto<List<ResidentDTO>> GetAllUser()
            {
                using var transaction = _unitOfWork.BeginTransaction();

                var userList = _userRepository.GetAllUser();
                var userListWithDto = _mapper.Map<List<ResidentDTO>>(userList);

                _unitOfWork.Commit();
                transaction.Commit();

                return ResponseDto<List<ResidentDTO>>.Success(userListWithDto);
            }

            public ResidentDTO GetByIdUser(int id)
            {
                using var transaction = _unitOfWork.BeginTransaction();

                var user = _userRepository.GetByIdUser(id);

                _unitOfWork.Commit();
                transaction.Commit();

                return _mapper.Map<ResidentDTO>(user);
            }

            public void DeleteUser(int id)
            {
                using var transaction = _unitOfWork.BeginTransaction();

                _userRepository.DeleteUser(id);

                _unitOfWork.Commit();
                transaction.Commit();
            }

            public ResponseDto<string> AddUser(ResidentDTO request)
            {
                using var transaction = _unitOfWork.BeginTransaction();

                var user = new Resident { Name = request.Name, Surname = request.Surname, Email = request.Email, PhoneNumber = request.PhoneNumber   };
                _userRepository.AddUser(user);

                _unitOfWork.Commit();
                transaction.Commit();

                return ResponseDto<string>.Success(user.Name);
            }

            public void UpdateUser(ResidentDTO request)
            {
                using var transaction = _unitOfWork.BeginTransaction();

                var user = _userRepository.GetByIdUser(request.Id);
                if (user == null)
                    return; // or handle the case where user is not found

                user.Name = request.Name;
                user.Email = request.Email;
                user.PhoneNumber = request.PhoneNumber;

                _userRepository.UpdateUser(user);

                _unitOfWork.Commit();
                transaction.Commit();
            }
        }
    

}
