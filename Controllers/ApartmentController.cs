using Microsoft.AspNetCore.Mvc;
using PaparaBootcampFinalHomework.Models.Apartments;
using PaparaBootcampFinalHomework.Models.Users;

namespace PaparaBootcampFinalHomework.Controllers
{    //[Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ApartmentController : ControllerBase
    {
        private readonly IApartmentService _apartmentService;

        public ApartmentController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddApartment(ApartmentDTO apartmentDTO)
        {

            return Ok(_apartmentService.AddApartment(apartmentDTO));
        }
        //[Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult UpdatApartment( ApartmentDTO apartmentDTO)
        {
            _apartmentService.UpdateApartment(apartmentDTO);
            return Ok();
        }
        //[Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteApartment(int id)
        {
            _apartmentService.DeleteApartment(id);
            return Ok();
        }
        [HttpGet]
        public IActionResult GetAllApartment()
        {
            return Ok(_apartmentService.GetAllApartment());
        }
        [HttpGet("{id}")]
        public IActionResult GetByIdApartment(int id)
        {
            return Ok(_apartmentService.GetByIdApartment(id));
        }
    }
}
