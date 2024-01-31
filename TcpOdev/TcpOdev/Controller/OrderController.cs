using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcpOdev.Entity;
using TcpOdev.Entity.Interface;

namespace TcpOdev.Controller
{
    public class OrderController : ICrud<Order>
    {

        public List<Order> GetByCategory(string name)
        {
            throw new NotImplementedException();
        }

        public Order GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
