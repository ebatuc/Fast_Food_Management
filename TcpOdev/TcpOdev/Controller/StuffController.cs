using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcpOdev.Entity;
using TcpOdev.Entity.Interface;

namespace TcpOdev.Controller
{
    public class StuffController : ICrud<Stuff>
    {
        public List<Stuff> GetByCategory(string name)
        {
            throw new NotImplementedException();
        }

        public Stuff GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
