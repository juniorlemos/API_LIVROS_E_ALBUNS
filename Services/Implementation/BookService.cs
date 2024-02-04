using Businnes;
using Repository.GenericRepository;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implemetation
{
    public class BookService : IBasicService<Book>
    {
        private readonly IRepository<Book>_repository;

        public BookService(IRepository<Book> repository)
        {
            _repository = repository;
        }
        
        public async Task<IEnumerable<Book>> Get()
        {
            return await _repository.Get();
        }

        public async Task<Book> GetId(long id)
        {
            return await _repository.GetId(id);
        }

        public async Task<Book> Create(Book book)
        {
            var bookEntity = book;
            bookEntity = await _repository.Create(bookEntity);
            return (bookEntity);
        }
        public async Task<Book> Update(Book book)
        {
            var bookEntity = book;
            bookEntity = await _repository.Update(bookEntity);
            return (bookEntity);
        }
        public async Task Delete(long id)
        {
            await _repository.Delete(id);
        }

    }
}
