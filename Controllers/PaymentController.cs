using Azure;
using Microsoft.AspNetCore.Mvc;
using PaparaBootcampFinalHomework.Models.Payments;

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
        public IActionResult AddMonthlyBills(PaymentDTO paymentDTO)
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
        public IActionResult GetMonthlyBillsByMonth(DateTime billingMonth)
        {

            var response = _paymentService.GetMonthlyBillsByMonth(billingMonth);
            if (response.AnyError)
            {
                return BadRequest(response);
            }
            if (response != null)
                return Ok(response);
            else
                return NotFound("No monthly bills found for the given month.");

        }


        [HttpGet("user-payments/{userId}")]
        public IActionResult GetUserPayments(int userId)
        {

            var userPayments = _paymentService.GetUserPayments(userId);


            if (userPayments != null)
                return Ok(userPayments);
            else
                return NotFound("No payments found for the user.");

        }

        [HttpGet("building-expenses")]
        public IActionResult GetBuildingExpenses()
        {

            var buildingExpenses = _paymentService.GetBuildingExpenses();

            return Ok(buildingExpenses);

        }
        [HttpPost("add-monthly-bills-for-all-apartments")]
        public IActionResult AddMonthlyBillsForAllApartments([FromBody] PaymentDTO request)
        {
            var response = _paymentService.AddMonthlyBillsForAllApartments(request);

            return Ok(response);
        }

        [HttpPost("add-monthly-bills-for-one-apartment")]
        public IActionResult AddMonthlyBillsForOneApartment([FromBody] PaymentDTO request)
        {
            var response = _paymentService.AddMonthlyBillsForOneApartment(request);

            if (response.AnyError)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}
