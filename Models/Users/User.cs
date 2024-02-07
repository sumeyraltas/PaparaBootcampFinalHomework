using PaparaBootcampFinalHomework.Models.Apartments;
using PaparaBootcampFinalHomework.Models.Payments;
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

        public ICollection<Payment> Payments { get; set; }
       // [ForeignKey("PaymentId")]
       // public Payment? Payment { get; set; }
    
       // [ForeignKey("ApartmentId")]
        public Apartment Apartment { get; set; }
      
        public int ApartmentId { get; set; }
       

     } 
}
