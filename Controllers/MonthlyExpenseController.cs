using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaparaBootcampFinalHomework.Models.MonthlyExpense;
using PaparaBootcampFinalHomework.Models.MonthlyExpense.DTOs;

namespace PaparaBootcampFinalHomework.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MonthlyExpenseController(IMonthlyExpenseService monthlyExpenseService) : ControllerBase
    {
        private readonly IMonthlyExpenseService _monthlyExpenseService = monthlyExpenseService;

        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public IActionResult GetBuildingExpenses()
        {

            var buildingExpenses = _monthlyExpenseService.GetAllTotalBuildingExpenses();
  
            return Ok(buildingExpenses);

        }
        [HttpGet("gas-bills")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllGasBills()
        {
            var response = _monthlyExpenseService.GetAllGasBills();
            if (response == null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpGet("electricity-bills")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllElectricityBill()
        {
            var response = _monthlyExpenseService.GetAllElectricityBill();
            if (response == null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpGet("water-bills")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllWaterBill()
        {
            var response = _monthlyExpenseService.GetAllWaterBill();
            if (response == null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
