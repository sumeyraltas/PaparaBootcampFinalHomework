using Azure;
using Microsoft.AspNetCore.Authorization;
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



        [Authorize(Roles = "ADMIN")]
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

        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public IActionResult GetUserPayments()
        {
            var userPayments = _paymentService.GetUserPayments();

            if (userPayments != null)
                return Ok(userPayments);
            else
                return NotFound("No payments found for the user.");
        }

        [HttpPost("add-monthly-bills-for-all-apartments")]

        [Authorize(Roles = "Admin")]
        public IActionResult AddMonthlyBillsForAllApartments([FromBody] PaymentDTO request)
        {
            var response = _paymentService.AddMonthlyBillsForAllApartments(request);

            return Ok(response);
        }
        [HttpGet("my-payments")]
        [Authorize(Roles = "Admin, Resident")]
        public IActionResult GetMyPayments(int id)
        {
            var response = _paymentService.GetResidentPayments(id);

            if (response != null)
                return Ok(response);
            else
                return NotFound("No payments found for the resident.");
        }
        [HttpPost("make-payment")]
        [Authorize(Roles = "Admin, Resident")]
        public IActionResult MakePayment([FromBody] ResistentPaymentsDTO request)
        {
            var response = _paymentService.MakePayment(request);

            if (response.AnyError)
                return BadRequest(response);

            return Ok(response);
        }


    }
}
