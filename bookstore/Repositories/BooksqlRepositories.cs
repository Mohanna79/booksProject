using bookstore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;



namespace bookstore.Repositories
{
    public class BooksqlRepositories : IBookRepository
    {
        private BookDbContext _context;

        public BooksqlRepositories(BookDbContext context)
        {
            _context = context;
        }
        public async  Task<BookEntity> Add(BookEntity item)
        {
            await _context.BookItems.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<int> CountBook()
        {
            return await _context.BookItems.CountAsync();
        }

        public async Task<BookEntity> Find(int id)
        {
            return await _context.BookItems.Include(c => c.Id).SingleOrDefaultAsync(c => c.Id == id);
        }
        public IEnumerable<BookEntity> GetAll()
        {
            return _context.BookItems.ToList();
        }
        public async Task<bool> IsExists(int id)
        {
            return await _context.BookItems.AnyAsync(c => c.Id == id);
        }

        public  async Task<BookEntity> Remove(int id)
        {
            var customer = await _context.BookItems.SingleAsync(c => c.Id == id);
            _context.BookItems.Remove(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<BookEntity> Update(BookEntity item)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}
