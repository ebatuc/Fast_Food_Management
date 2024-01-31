using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcpOdev.Entity.Abstract;

namespace TcpOdev.Entity
{
    public class Product:CommonProperty
    {
        public double Price { get; set; }
        public int PrepTime { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
 
    }
}
