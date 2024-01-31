using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcpOdev.Entity;
using TcpOdev.Entity.Interface;

namespace TcpOdev.Controller
{
    public class CategoryController : ICrud<Category>
    {

  

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        List<Category> ICrud<Category>.GetByCategory(string name)
        {
            throw new NotImplementedException();
        }
    }
}
