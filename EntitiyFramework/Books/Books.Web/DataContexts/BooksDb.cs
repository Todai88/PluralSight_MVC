using System;
using System.Collections.Generic;
using System.Data.Entity;
using Books.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Books.Web.DataContexts
{
    public class BooksDb : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public BooksDb() 
            : base("DefaultConnection")
        {
            Database.Log = sql => Debug.Write(sql);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("library");
            base.OnModelCreating(modelBuilder);
        }
    }
}
