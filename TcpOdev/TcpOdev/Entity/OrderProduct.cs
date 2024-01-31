using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcpOdev.Entity.Abstract;

namespace TcpOdev.Entity
{
    public class OrderProduct
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantiy { get; set; }
        public int SizeId { get; set; }
        public Size Size { get; set; }
    }
}
