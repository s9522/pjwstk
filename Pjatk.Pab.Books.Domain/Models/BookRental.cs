using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Pjatk.Pab.Books.Domain.Models
{
    public class BookRental
    {
        [Required(ErrorMessage = "Pole wymagane")]
        [DisplayName("Identyfikator")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Pole wymagane")]
        [DisplayName("Czytelnik")]
        public Reader Reader { get; set; }
        [Required(ErrorMessage = "Pole wymagane")]
        [DisplayName("Książki")]
        public IList<Book> Books { get; set; }
        [DisplayName("Data wypożyczenia")]
        public DateTime DateFrom { get; set; }
        [DisplayName("Data oddania")]
        public DateTime DateTo { get; set; }
    }
}
