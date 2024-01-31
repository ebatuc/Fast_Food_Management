using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TcpOdev.Entity;
using TcpOdev.Entity.Interface;

namespace TcpOdev.Controller
{
    public class CampaignProductController : ICrud<CampaignProduct>
    {

        public List<CampaignProduct> GetByCategory(string name)
        {
            throw new NotImplementedException();
        }

        public CampaignProduct GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
