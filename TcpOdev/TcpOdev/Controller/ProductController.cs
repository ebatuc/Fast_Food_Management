using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcpOdev.Entity;
using TcpOdev.Entity.Data;
using TcpOdev.Entity.Interface;

namespace TcpOdev.Controller
{
    public class ProductController : ICrud<Product>
    {
        DataContext db = new DataContext();
        public List<Product> GetByCategory(string name)
        {
           
            return db.Product.Where(x => x.Category.Name == name).ToList();
            
        }

        public Product GetById(int id)
        {
            return db.Product.Where(x=>x.Id == id).FirstOrDefault();
        }
    }
}
