using System;
using System.Collections.Generic;
using System.Data.Entity;
using Books.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Web.DataContexts
{
    public class BooksDb : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public BooksDb() 
            : base("DefaultConnection")
        {

        }
    }
}
