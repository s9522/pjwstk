using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace Pjatk.Pab.Books.DAL
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DomainContext>
    {
        protected override void Seed(DomainContext context)
        {
            
        }
    }
}
