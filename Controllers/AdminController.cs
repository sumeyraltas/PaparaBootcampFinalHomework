using Microsoft.AspNetCore.Mvc;
using PaparaBootcampFinalHomework.Models.Tokens;
using PaparaBootcampFinalHomework.Models.Tokens.DTOs;
using PaparaBootcampFinalHomework.Models.Admin.DTOs;
using Microsoft.AspNetCore.Authorization;
namespace PaparaBootcampFinalHomework.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController(IIdentityService identityService, ITokenService tokenService) : ControllerBase
    {
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAdmin(AdminCreateRequestDto request)
        {
            var response = await identityService.CreateAdmin(request);

            if (response.AnyError)
            {
                return BadRequest(response);
            }

            return Created("", response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateToken(TokenCreateRequestDTO request)
        {
            var response = await tokenService.Create(request);

            if (response.AnyError)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignRoleToUser(RoleCreateRequestDto request)
        {
            var response = await identityService.CreateRole(request);

            if (response.AnyError)
            {
                return BadRequest(response);
            }

            return Created("", response);
        }
    }
}
