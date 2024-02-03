using Businnes;
using Repository.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class BookRepository : IRepository
    {
        private readonly ApplicationDbContext _context;
        public BookRepository( ApplicationDbContext context)
        {
            _context =context;
        }

        public List<Book> GetAll()
        {
             return _context.Books.ToList();
        }
    }
}
