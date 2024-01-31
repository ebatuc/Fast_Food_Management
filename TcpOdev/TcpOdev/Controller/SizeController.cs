using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcpOdev.Entity;
using TcpOdev.Entity.Interface;

namespace TcpOdev.Controller
{
    public class SizeController : ICrud<Size>
    {

        public List<Size> GetByCategory(string name)
        {
            throw new NotImplementedException();
        }

        public Size GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
