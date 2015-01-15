using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pjatk.Pab.Books.Domain.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Isbn { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishDate { get; set; }
        public int PagesCount { get; set; }
        public IList<Author> Authors { get; set; }
    }
}
