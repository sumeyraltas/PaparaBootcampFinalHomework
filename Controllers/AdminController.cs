using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.WSIdentity;
using PaparaBootcampFinalHomework.Models.Tokens;
using TokenService = PaparaBootcampFinalHomework.Models.Tokens.TokenService;
using Microsoft.AspNetCore.Http;
using PaparaBootcampFinalHomework.Models.Admin;
namespace PaparaBootcampFinalHomework.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController(IdentityService identityService, TokenService tokenService) : ControllerBase
    {
        [HttpPost]
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
