using PaparaBootcampFinalHomework.Models.Apartments;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaparaBootcampFinalHomework.Models.Users
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentityNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Apartment Apartment { get; set; }
        [ForeignKey("ApartmentId")]
        public int ApartmentId { get; set; }
       

     } 
}
