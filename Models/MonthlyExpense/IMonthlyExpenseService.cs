using Models.Shared.ResponseDto;
using PaparaBootcampFinalHomework.Models.MonthlyExpense.DTOs;

namespace PaparaBootcampFinalHomework.Models.MonthlyExpense
{
    public interface IMonthlyExpenseService
    {
        ResponseDto<int> AddMonthlyBills(MonthlyExpenseDTO request);
        List<GasBillsDTO> GetAllGasBills();
        List<ElectricityBillsDTO> GetAllElectricityBill();
        ResponseDto<int> AddMonthlyBillsForOneApartment(MonthlyExpenseDTO request);
        List<WaterBillsDTO> GetAllWaterBill();

        int GetAllTotalBuildingExpenses();
    }
}
