namespace PaparaBootcampFinalHomework.Models.Admin.DTOs
{
    public class AdminCreateRequestDto
    {
        public required string UserName { get; set; } = default!;
        public required string Password { get; set; } = default!;

    }
}