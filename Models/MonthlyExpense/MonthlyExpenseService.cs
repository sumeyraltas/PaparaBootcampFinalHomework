using AutoMapper;
using Models.Shared.ResponseDto;
using PaparaBootcampFinalHomework.Models.Apartments;
using PaparaBootcampFinalHomework.Models.MonthlyExpense.DTOs;
using PaparaBootcampFinalHomework.Models.Payments;
using PaparaBootcampFinalHomework.Models.UnitOfWorks;

namespace PaparaBootcampFinalHomework.Models.MonthlyExpense
{
    public class MonthlyExpenseService(IMonthlyExpenseRepository monthlyExpenseRepository , IMapper mapper, IUnitOfWork unitOfWork) : IMonthlyExpenseService
    {
        private readonly IMonthlyExpenseRepository _monthlyExpenseRepository = monthlyExpenseRepository;
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        public List<GasBillsDTO> GetAllGasBills()
        {
            using var transaction = _unitOfWork.BeginTransaction();

            var gasBills = _monthlyExpenseRepository.GetAllGasBills();

            _unitOfWork.Commit();
            transaction.Commit();

            return _mapper.Map<List<GasBillsDTO>>(gasBills);
        }
        public List<ElectricityBillsDTO> GetAllElectricityBill()
        {
            using var transaction = _unitOfWork.BeginTransaction();

            var bills = _monthlyExpenseRepository.GetAllElectricityBill();


            _unitOfWork.Commit();
            transaction.Commit();

            return _mapper.Map<List<ElectricityBillsDTO>>(bills);
        }
        public List<WaterBillsDTO> GetAllWaterBill()
        {
            using var transaction = _unitOfWork.BeginTransaction();

            var bills = _monthlyExpenseRepository.GetAllWaterBill();

            _unitOfWork.Commit();
            transaction.Commit();

            return _mapper.Map<List<WaterBillsDTO>>(bills);
        }
        public int GetAllTotalBuildingExpenses()
        {
            var allMonthlyExpenses = _monthlyExpenseRepository.GetAllMonthlyExpenses();
            var totalExpense = 0;
            foreach (var monthlyExpense in allMonthlyExpenses)
            {
                totalExpense = (int)(monthlyExpense.ElectricityBill + monthlyExpense.WaterBill + monthlyExpense.GasBill);

            }

            return totalExpense;
        }
        public ResponseDto<int> AddMonthlyBillsForOneApartment(MonthlyExpenseDTO request)
        {
            using var transaction = _unitOfWork.BeginTransaction();

            var payment = new MonthlyExpense
            {

                Year = request.Year,
                Month = request.Month
            };

            _monthlyExpenseRepository.AddMonthlyBills(payment);
            _unitOfWork.Commit();
            transaction.Commit();

            return ResponseDto<int>.Success(payment.Id);
        }
        public ResponseDto<int> AddMonthlyBills(MonthlyExpenseDTO request)
        {

            using var transaction = _unitOfWork.BeginTransaction();

            var payment = new MonthlyExpense { };
            _monthlyExpenseRepository.AddMonthlyBills(payment);
            _unitOfWork.Commit();
            transaction.Commit();

            return ResponseDto<int>.Success(payment.Id);
        }
    }
}
