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
        [HttpGet("monthly-bills/{billingMonth}")]
        public IActionResult GetMonthlyPaymentsByMonth(int billingMonth)
        {

            var response = _paymentService.GetMonthlyBillsByMonth(billingMonth);
           
            if (response != null)
                return Ok(response);
            else
                return NotFound("No monthly bills found for the given month.");

        }
        [HttpPost("add-payment")]
        public IActionResult AddPayment([FromBody] PaymentDTO request)
        {
            var response = _paymentService.AddPayment(request);
            if (response.AnyError)
            {
                return BadRequest(response);
            }
            return Ok(response);
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

        [HttpPost("add-monthly-bills-for-all-apartments")]
        public IActionResult AddMonthlyBillsForAllApartments([FromBody] PaymentDTO request)
        {
            var response = _paymentService.AddMonthlyBillsForAllApartments(request);

            return Ok(response);
        }

       
     
    }
}
