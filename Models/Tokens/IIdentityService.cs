using Microsoft.AspNetCore.Identity;
using Models.Shared.ResponseDto;
using PaparaBootcampFinalHomework.Models.Admin.DTOs;
using PaparaBootcampFinalHomework.Models.Tokens.DTOs;

namespace PaparaBootcampFinalHomework.Models.Tokens
{
    public interface IIdentityService
    {
          Task<ResponseDto<Guid?>> CreateAdmin(AdminCreateRequestDto request);
          Task EnsureAdminUserExists() ;
          Task<ResponseDto<string>> CreateRole(RoleCreateRequestDto request);
     
    }
}
