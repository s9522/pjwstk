using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Pjatk.Pab.Books.Domain.Models
{
    public class Book
    {
        [Required]
        public int Id { get; set; }
        [StringLength(100), Required] 
        public string Title { get; set; }
        [StringLength(100)]
        public string Subtitle { get; set; }
        [Required, StringLength(20)]
        public string Isbn { get; set; }
        [Required, StringLength(100)]
        public string Publisher { get; set; }
        [Required]
        public DateTime PublishDate { get; set; }
        [Required, Range(1, 10000)]
        public int PagesCount { get; set; }
        public IList<Author> Authors { get; set; }
    }
}
