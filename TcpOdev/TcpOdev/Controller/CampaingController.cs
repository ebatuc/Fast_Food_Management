using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcpOdev.Entity;
using TcpOdev.Entity.Interface;

namespace TcpOdev.Controller
{
    public class CampaingController : ICrud<Campaign>
    {
        public List<Campaign> GetByCategory(string name)
        {
            throw new NotImplementedException();
        }

        public Campaign GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
