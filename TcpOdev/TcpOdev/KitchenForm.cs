using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TcpOdev.Entity.Data;

namespace TcpOdev
{
    public partial class KitchenForm : Form
    {
        DataContext db = new DataContext(); 

        public KitchenForm()
        {
            InitializeComponent();
        }
        public void CartItemsToKitchen()
        {
            db.OrderProduct.ToList();
        }

    }
}
