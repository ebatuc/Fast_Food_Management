using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpOdev.Entity.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DbConnection") { }
        public DbSet <Campaign> Campaign { get; set; }
        public DbSet <Category> Category { get; set; }
        public DbSet <Order> Order { get; set; }
        public DbSet <OrderProduct> OrderProduct { get; set; }
        public DbSet <Product> Product { get; set; }
        public DbSet <Size> Size { get; set; }
        public DbSet <Stuff> Stuff { get; set; }

        public DbSet <CampaignProduct> CampaignProduct { get; set; }    






    }
}
