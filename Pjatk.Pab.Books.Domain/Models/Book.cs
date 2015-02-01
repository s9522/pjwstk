using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Pjatk.Pab.Books.Domain.Models
{
    public class Book
    {
        [DisplayName("Identyfikator")]
        public int Id { get; set; }
        [StringLength(100, ErrorMessage="Nieprawidłowa ilość znaków"), Required(ErrorMessage = "Pole wymagane")]
        [DisplayName("Tytuł")]
        public string Title { get; set; }
        [DisplayName("Podtytuł")]
        [StringLength(100, ErrorMessage = "Nieprawidłowa ilość znaków")]
        public string Subtitle { get; set; }
        [Required(ErrorMessage = "Pole wymagane"), StringLength(20, ErrorMessage = "Nieprawidłowa ilość znaków")]
        [DisplayName("ISBN")]
        public string Isbn { get; set; }
        [DisplayName("Wydawnictwo")]
        [Required(ErrorMessage = "Pole wymagane"), StringLength(100, ErrorMessage = "Nieprawidłowa ilość znaków")]
        public string Publisher { get; set; }
        [Required(ErrorMessage = "Pole wymagane")]
        [DisplayName("Data wydania")]
        public DateTime PublishDate { get; set; }
        [Required(ErrorMessage = "Pole wymagane"), Range(1, 10000, ErrorMessage="Podaj wartość 1 do 10000")]
        [DisplayName("Ilość stron")]
        public int PagesCount { get; set; }
        [Required(ErrorMessage = "Pole wymagane"), Range(1, 100, ErrorMessage="Podaj wartość od do 100")]
        [DisplayName("Numer edycji")]
        public int EditionNumber { get; set; }
        [DisplayName("Autorzy")]
        public virtual IList<Author> Authors { get; set; }
    }
}
