using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Pjatk.Pab.Books.Domain.Models
{
    public class Reader
    {
        [Required(ErrorMessage = "Pole wymagane")]
        [DisplayName("Identyfikator")]
        public int Id { get; set; }
        [DisplayName("Imię")]
        [Required(ErrorMessage = "Pole wymagane"), StringLength(50, ErrorMessage = "Nieprawidłowa ilość znaków")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Pole wymagane"), StringLength(50, ErrorMessage = "Nieprawidłowa ilość znaków")]
        [DisplayName("Nazwisko")]
        public string LastName { get; set; }
    }
}
