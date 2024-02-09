namespace PaparaBootcampFinalHomework.Models.Admin
{
    public class AdminCreateRequestDto
    {
        public required string UserName { get; set; } = default!;
        public required string Password { get; set; } = default!;

    }
}