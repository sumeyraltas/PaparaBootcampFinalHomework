using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaparaBootcampFinalHomework.Models.Users;

namespace PaparaBootcampFinalHomework.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController(IResidentService userService) : ControllerBase
    {
        private readonly IResidentService _userService = userService;

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddUser(ResidentDTO userDto)
        {
            var response = _userService.AddUser(userDto);
            if (response.AnyError)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        //[Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, ResidentDTO userDto)
        {
            _userService.UpdateUser(userDto);

            return Ok();
        }
        //[Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userService.DeleteUser(id);
            return Ok();
        }
        [HttpGet]
        public IActionResult GetAllUser()
        {
            var response = _userService.GetAllUser();
            if (response.AnyError)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_userService.GetByIdUser(id));
        }

    }
}
