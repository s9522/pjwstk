using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pjatk.Pab.Books.Domain.Models
{
    public class Author
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
        [DisplayName("Data urodzenia")]
        public DateTime DateOfBirth { get; set; }
        [DisplayName("Książki")]
        public virtual IList<Book> Books { get; set; }

    }
}
