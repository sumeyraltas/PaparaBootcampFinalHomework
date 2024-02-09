using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaparaBootcampFinalHomework.Models.Residents.DTOs;
using PaparaBootcampFinalHomework.Models.Users;

namespace PaparaBootcampFinalHomework.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ResidentController(IResidentService residentService) : ControllerBase
    {
        private readonly IResidentService _residentService = residentService;

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddResident(ResidentDTO userDto)
        {
            var response = _residentService.AddUser(userDto);
            if (response.AnyError)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        //[Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult UpdateResident( ResidentDTO userDto)
        {
            _residentService.UpdateUser(userDto);

            return Ok();
        }
        //[Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteResident(int id)
        {
            _residentService.DeleteUser(id);
            return Ok();
        }
        [HttpGet]
        public IActionResult GetAllResident()
        {
            var response = _residentService.GetAllUser();
            if (response.AnyError)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpGet("{id}")]
        public IActionResult GetByIdResident(int id)
        {
            return Ok(_residentService.GetByIdUser(id));
        }

    }
}
