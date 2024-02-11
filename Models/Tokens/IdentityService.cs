using Microsoft.AspNetCore.Identity;
using Models.Shared.ResponseDto;
using PaparaBootcampFinalHomework.Models.Admin.DTOs;
using PaparaBootcampFinalHomework.Models.Tokens.DTOs;

namespace PaparaBootcampFinalHomework.Models.Tokens
{
    public class IdentityService(
      UserManager<AppAdmin> userManager,
      RoleManager<AppRole> roleManager,
      SignInManager<AppAdmin> signInManager
     ) : IIdentityService
    {
        public UserManager<AppAdmin> UserManager { get; set; } = userManager;
        public RoleManager<AppRole> RoleManager { get; set; } = roleManager;
        public SignInManager<AppAdmin> SignInManager { get; set; } = signInManager;


        public async Task<ResponseDto<Guid?>> CreateAdmin(AdminCreateRequestDto request)
        {
            var appUser = new AppAdmin
            {
                UserName = request.UserName,
                PasswordHash = request.Password
            };

            //   roleManager.AddClaimAsync("ADMIN");
            var result = await userManager.CreateAsync(appUser, request.Password);

            if (!result.Succeeded)
            {
                var errorList = result.Errors.Select(x => x.Description).ToList();

                return ResponseDto<Guid?>.Fail(errorList);
            }

            return ResponseDto<Guid?>.Success(appUser.Id);

        }
        public async Task EnsureAdminUserExists()
        {
            if (!await roleManager.RoleExistsAsync("ADMIN"))
            {
                var adminRole = new AppRole { Name = "ADMIN" };
                await roleManager.CreateAsync(adminRole);
            }

            var adminUser = await userManager.FindByNameAsync("admin");
            if (adminUser == null)
            {
                adminUser = new AppAdmin { UserName = "admin" };
                await userManager.CreateAsync(adminUser, "Admin123."); 
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }

        public async Task<ResponseDto<string>> CreateRole(RoleCreateRequestDto request)
        {
            var appRole = new AppRole
            {
                Name = request.RoleName,
            };

            var hasRole = await roleManager.RoleExistsAsync(appRole.Name);

            IdentityResult? roleCreateResult = null;
            if (!hasRole)
            {
                roleCreateResult = await roleManager.CreateAsync(appRole);
            }

            if (roleCreateResult is not null && !roleCreateResult.Succeeded)
            {
                var errorList = roleCreateResult.Errors.Select(x => x.Description).ToList();

                return ResponseDto<string>.Fail(errorList);
            }

            var hasUser = await userManager.FindByIdAsync(request.UserId);

            if (hasUser is null)
            {
                return ResponseDto<string>.Fail("kullanıcı bulunamadı.");
            }

            var roleAssignResult = await userManager.AddToRoleAsync(hasUser, appRole.Name);

            if (!roleAssignResult.Succeeded)
            {
                var errorList = roleAssignResult.Errors.Select(x => x.Description).ToList();

                return ResponseDto<string>.Fail(errorList);
            }

            return ResponseDto<string>.Success(string.Empty);
        }

    }
}