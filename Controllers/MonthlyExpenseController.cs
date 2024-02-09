using Microsoft.AspNetCore.Mvc;
using PaparaBootcampFinalHomework.Models.MonthlyExpense;
using PaparaBootcampFinalHomework.Models.MonthlyExpense.DTOs;
using PaparaBootcampFinalHomework.Models.Payments;

namespace PaparaBootcampFinalHomework.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MonthlyExpenseController(IMonthlyExpenseService monthlyExpenseService) : ControllerBase
    {
        private readonly IMonthlyExpenseService _monthlyExpenseService = monthlyExpenseService;
        //[Authorize(Roles = "Admin")]
        [HttpPost("monthly-bills")]
        public IActionResult AddMonthlyBills(MonthlyExpenseDTO paymentDTO)
        {

            var response = _monthlyExpenseService.AddMonthlyBills(paymentDTO);
            if (response.AnyError)
            {
                return BadRequest(response);
            }
            return Created("", response);

        }
        [HttpGet("building-expenses")]
        public IActionResult GetBuildingExpenses()
        {

            var buildingExpenses = _monthlyExpenseService.GetAllTotalBuildingExpenses();

            return Ok(buildingExpenses);

        }
        [HttpGet("gas-bills")]
        public IActionResult GetAllGasBills()
        {
            var response = _monthlyExpenseService.GetAllGasBills();

            return Ok(response);
        }
        [HttpGet("electricity-bills")]
        public IActionResult GetAllElectricityBill()
        {
            var response = _monthlyExpenseService.GetAllElectricityBill();

            return Ok(response);
        }
        [HttpGet("water-bills")]
        public IActionResult GetAllWaterBill()
        {
            var response = _monthlyExpenseService.GetAllWaterBill();

            return Ok(response);
        }
    }
}
