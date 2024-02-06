using Microsoft.AspNetCore.Identity;

namespace PaparaBootcampFinalHomework.Models.Tokens
{
    public class AppUser : IdentityUser<Guid>
    {
        public string Password { get; internal set; }
    }
}