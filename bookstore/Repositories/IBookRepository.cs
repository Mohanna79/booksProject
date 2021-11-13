using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookstore.Entity;

namespace bookstore.Repositories
{
  public  interface IBookRepository
    {
     //  BookEntity GetSingle(int id);
      Task <BookEntity> Add(BookEntity item);
        Task <BookEntity>Remove(int id);
        Task<BookEntity> Update(BookEntity item);
        IEnumerable<BookEntity> GetAll();
        Task<int> CountBook();
        Task<bool> IsExists(int id);
        Task<BookEntity> Find(int id);

    }
}
