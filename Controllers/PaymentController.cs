using Microsoft.AspNetCore.Mvc;
using PaparaBootcampFinalHomework.Models.Payments;

namespace PaparaBootcampFinalHomework.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        //[Authorize(Roles = "Admin")]
        [HttpPost("monthly-bills")]
        public IActionResult AddMonthlyBills(PaymentDTO paymentDTO)
        {
            try
            {
                _paymentService.AddMonthlyBills(paymentDTO);
                return Ok("Monthly bills added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        //[Authorize(Roles = "Admin")]
        [HttpGet("monthly-bills/{billingMonth}")]
        public IActionResult GetMonthlyBillsByMonth(DateTime billingMonth)
        {
            try
            {
                var monthlyBills = _paymentService.GetMonthlyBillsByMonth(billingMonth);
                if (monthlyBills != null)
                    return Ok(monthlyBills);
                else
                    return NotFound("No monthly bills found for the given month.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        [HttpGet("user-payments/{userId}")]
        public IActionResult GetUserPayments(int userId)
        {
            try
            {
                var userPayments = _paymentService.GetUserPayments(userId);
                if (userPayments != null)
                    return Ok(userPayments);
                else
                    return NotFound("No payments found for the user.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("building-expenses")]
        public IActionResult GetBuildingExpenses()
        {
            try
            {
                var buildingExpenses = _paymentService.GetBuildingExpenses();
                return Ok(buildingExpenses);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [HttpPost("add-monthly-bills-for-all-apartments")]
        public IActionResult AddMonthlyBillsForAllApartments([FromBody] PaymentDTO request)
        {
            var result = _paymentService.AddMonthlyBillsForAllApartments(request);
            return Ok(result);
        }

        [HttpPost("add-monthly-bills-for-one-apartment")]
        public IActionResult AddMonthlyBillsForOneApartment([FromBody] PaymentDTO request)
        {
            var result = _paymentService.AddMonthlyBillsForOneApartment(request);
            return Ok(result);
        }

    }
}
