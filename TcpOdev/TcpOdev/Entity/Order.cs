using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcpOdev.Entity.Abstract;

namespace TcpOdev.Entity
{
    public class Order : CommonProperty
    {
        public DateTime CreatedTime { get; set; }
        public double TotalPrice { get; set; }
        public int StuffId { get; set; }
        public Stuff Stuff { get; set; }
    }
}
