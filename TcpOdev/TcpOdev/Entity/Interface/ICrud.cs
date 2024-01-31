using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpOdev.Entity.Interface
{
    public interface ICrud<T>
    {
        T GetById(int id);
        List<T> GetByCategory(string name);
    }
}
