using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TcpOdev.Entity;
using TcpOdev.Entity.Data;

namespace TcpOdev
{
     
    public partial class LoginForm : Form
    {
      public Stuff stuff = new Stuff();
        DataContext db = new DataContext();
        

        public LoginForm()
        {
            InitializeComponent();
            dateTimeLbl.Text = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

        }
    

        private void LoginBtn_Click(object sender, EventArgs e)
        {
          stuff = db.Stuff.Where(x=>x.Name == userNameTxt.Text).FirstOrDefault();
            if (stuff != null)
            {
                AdminForm adminForm = new AdminForm(stuff);
                adminForm.SetWelcomeLabel(userNameTxt.Text);
                adminForm.ShowDialog();
             this.Visible = false;
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yaptınız!!!");
            }

         
        }
    }
}
