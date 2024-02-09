using Azure;
using Microsoft.AspNetCore.Mvc;
using PaparaBootcampFinalHomework.Models.MonthlyExpense.DTOs;
using PaparaBootcampFinalHomework.Models.Payments;
using PaparaBootcampFinalHomework.Models.Payments.DTOs;

namespace PaparaBootcampFinalHomework.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PaymentController(IPaymentService paymentService) : ControllerBase
    {
        private readonly IPaymentService _paymentService = paymentService;

        //[Authorize(Roles = "Admin")]
        [HttpPost("monthly-bills")]
        public IActionResult AddMonthlyBills(MonthlyExpenseDTO paymentDTO)
        {

            var response = _paymentService.AddMonthlyBills(paymentDTO);
            if (response.AnyError)
            {
                return BadRequest(response);
            }
            return Created("", response);

        }
        //[Authorize(Roles = "Admin")]
        [HttpGet("monthly-bills/{billingMonth}")]
        public IActionResult GetMonthlyPaymentsByMonth(int billingMonth)
        {

            var response = _paymentService.GetMonthlyBillsByMonth(billingMonth);
           
            if (response != null)
                return Ok(response);
            else
                return NotFound("No monthly bills found for the given month.");

        }

        [HttpGet("user-payments")]
        public IActionResult GetUserPayments()
        {
            var userPayments = _paymentService.GetUserPayments();

            if (userPayments != null)
                return Ok(userPayments);
            else
                return NotFound("No payments found for the user.");
        }

        [HttpGet("building-expenses")]
        public IActionResult GetBuildingExpenses()
        {

            var buildingExpenses = _paymentService.GetAllTotalBuildingExpenses();

            return Ok(buildingExpenses);

        }
        [HttpPost("add-monthly-bills-for-all-apartments")]
        public IActionResult AddMonthlyBillsForAllApartments([FromBody] PaymentDTO request)
        {
            var response = _paymentService.AddMonthlyBillsForAllApartments(request);

            return Ok(response);
        }

       
        [HttpGet("gas-bills")]
        public IActionResult GetAllGasBills()
        {
                var response = _paymentService.GetAllGasBills();
          
                return Ok(response);
        }
        [HttpGet("electricity-bills")]
        public IActionResult GetAllElectricityBill()
        {
            var response = _paymentService.GetAllElectricityBill();

            return Ok(response);
        }
        [HttpGet("water-bills")]
        public IActionResult GetAllWaterBill()
        {
            var response = _paymentService.GetAllWaterBill();

            return Ok(response);
        }
    }
}
