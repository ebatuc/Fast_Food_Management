using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpOdev.Entity.Abstract
{
    public class CommonProperty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsStatus { get; set; }
        public bool IsDelete { get; set; }
    }
}
