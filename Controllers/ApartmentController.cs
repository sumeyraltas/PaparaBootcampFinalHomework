using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaparaBootcampFinalHomework.Models.Apartments;
using PaparaBootcampFinalHomework.Models.Apartments.DTOs;
namespace PaparaBootcampFinalHomework.Controllers
{    //[Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ApartmentController(IApartmentService apartmentService) : ControllerBase
    {
        private readonly IApartmentService _apartmentService = apartmentService;

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddApartment(ApartmentDTO apartmentDTO)
        {
            return Ok(_apartmentService.AddApartment(apartmentDTO));
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult UpdateApartment(ApartmentDTO apartmentDTO)
        {
            _apartmentService.UpdateApartment(apartmentDTO);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteApartment(int id)
        {
            _apartmentService.DeleteApartment(id);
            return Ok();
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllApartment()
        {
            return Ok(_apartmentService.GetAllApartment());
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetByIdApartment(int id)
        {
            return Ok(_apartmentService.GetByIdApartment(id));
        }
        [HttpGet("\"get-apartment-resident-ıd\"{id}")]
        //[Authorize(Roles = "Admin")]
        public IActionResult GetApartmentByResidentId(int id)
        {
            return Ok(_apartmentService.GetApartmentByResidentId(id));
        }
        [HttpPost("assign-resident")]
        public IActionResult AssignResidentToApartment(AssignResidentRequestDTO assignResidentRequestDTO)
        {
            var response = _apartmentService.AssignResident(assignResidentRequestDTO.ApartmentId, assignResidentRequestDTO.ResidentId);
            if (response.AnyError)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
