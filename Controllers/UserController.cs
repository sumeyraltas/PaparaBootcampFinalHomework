using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaparaBootcampFinalHomework.Models.Users;

namespace PaparaBootcampFinalHomework.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddUser(UserDTO userDto)
        {
         
            return Ok(_userService.AddUser(userDto));
        }
        //[Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, UserDTO userDto)
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
            return Ok(_userService.GetAllUser());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_userService.GetByIdUser(id));
        }

    }
}
