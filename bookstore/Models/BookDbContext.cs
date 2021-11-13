using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookstore.Entity;
using Microsoft.EntityFrameworkCore;
namespace bookstore.Repositories
{
    public class BookDbContext:DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options)
           : base(options)
        {

        }
        public virtual DbSet<BookEntity> BookItems { get; set; }
    }
}
