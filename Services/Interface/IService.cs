using Businnes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
     public interface IService
    {
        List<Book> GetAll();
    }
}
