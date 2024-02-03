using Businnes;
using Repository.Implementation;
using Repository.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implemetation
{
    public class BookService : IService
    {
        private readonly IRepository _repository;

        public BookService(IRepository repository)
        {
            _repository = repository;
        }
        public List<Book> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
