using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcpOdev.Entity;
using TcpOdev.Entity.Interface;

namespace TcpOdev.Controller
{
    public class OrderProductController : ICrud<OrderProduct>
    {
       

        public List<OrderProduct> GetByCategory(string name)
        {
            throw new NotImplementedException();
        }

        public OrderProduct GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
