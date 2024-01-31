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
using TcpOdev.Entity;
using TcpOdev.Controller;
using System.Diagnostics;
using System.Data.Entity.Infrastructure;
using TcpOdev;
using SimpleTCP;

namespace TcpOdev
{
    public partial class AdminForm : Form
    {

        SimpleTcpClient client;
        SimpleTcpServer server;
        Dictionary<string, List<string>> addresses = new Dictionary<string, List<string>>()
        {
            //{"stuff", ["192.168.56.1", "4000"]},
            //{"kitchen", ["192.168.1.37", "4001"]},
            //{"customer", ["192.168.1.39", "4002"]}
        };

        TcpOdev.Entity.Size size = new TcpOdev.Entity.Size();
        double totalPrice = 0;
        int x = 100;
        int y = 100;
        ProductController pc = new ProductController();
        Functions functions = new Functions();  
        DataContext db = new DataContext();
        public List<Product> products = new List<Product>();
        public Product cartProduct;
        Stuff _stuff;
        public AdminForm(Stuff stuff)
        {
         _stuff = stuff;
            InitializeComponent();
        }
        public void SetWelcomeLabel(string userName)
        {
            WelcomeLbl.Text = $"Kasiyer, {userName}";
        }
        public void CreateGroupBox(Panel panel, string title, double price,int id)
        {

           
            if (x<1200)
            {
                // GroupBox oluşturulur
                GroupBox groupBox = new GroupBox();
                groupBox.Text = "";
                groupBox.Size = new System.Drawing.Size(200, 100);
                groupBox.Location = new Point(x, y);

                // Label oluşturulur
                Label label = new Label();
                label.Text = $"{title} / {price} TL";
                label.Location = new Point(10, 20);
                label.AutoSize = true;

                // Arama yapma butonu
                Button searchButton = new Button();
                searchButton.Text = "🔍";
                searchButton.Location = new Point(10, 50);

                // Ekleme butonu
                Button addButton = new Button();
                addButton.Name = "addButton_" + id;
                addButton.Text = "+";
                addButton.Location = new Point(120, 50);
                addButton.Click += AddButton_Click;

                // Oluşturulan kontroller GroupBox içine eklenir
                groupBox.Controls.Add(label);
                groupBox.Controls.Add(searchButton);
                groupBox.Controls.Add(addButton);


                panel.Controls.Add(groupBox);
                x += 220;
            }
            else
            {
                y += 150;
                x = 100;
                // GroupBox oluşturulur
                GroupBox groupBox = new GroupBox();
                groupBox.Text = "";
                groupBox.Size = new System.Drawing.Size(200, 100);
                groupBox.Location = new Point(x, y);

                // Label oluşturulur
                Label label = new Label();
                label.Text = $"{title} / {price} TL";
                label.Location = new Point(10, 20);
                label.AutoSize = true;

                // Arama yapma butonu
                Button searchButton = new Button();
                searchButton.Text = "🔍";
                searchButton.Location = new Point(10, 50);

                // Ekleme butonu
                Button addButton = new Button();
                addButton.Text = "+";
                addButton.Location = new Point(120, 50);
                addButton.Click += AddButton_Click;

                // Oluşturulan kontroller GroupBox içine eklenir
                groupBox.Controls.Add(label);
                groupBox.Controls.Add(searchButton);
                groupBox.Controls.Add(addButton);


                panel.Controls.Add(groupBox);
                x += 220;
            }
            
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);
            string btnName = btn.Name;
            string[] btnId = btnName.Split('_');

            cartProduct = pc.GetById(Convert.ToInt32(btnId[1]));
            if (cartProduct.CategoryId==1)
            {
                cartProduct.Price += size.ChangePrice;
            }
            products.Add(cartProduct);
            denemeDgv.DataSource = null;
            denemeDgv.DataSource = products;
            denemeDgv.Columns["Name"].DisplayIndex = 0;
           
            denemeDgv.Columns["Id"].Visible = false;
            denemeDgv.Columns["CategoryId"].Visible = false;
            denemeDgv.Columns["Category"].Visible=false;
            denemeDgv.Columns["IsStatus"].Visible = false;
            denemeDgv.Columns["IsDelete"].Visible = false;
     
                totalPrice+= cartProduct.Price;
            
       
            totalPriceLbl.Text = totalPrice.ToString() + "₺";
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            
           
            sizePnl.Visible = false;
            client = new SimpleTcpClient();
            server = new SimpleTcpServer();

            client.StringEncoder = Encoding.UTF8;

            server.Delimiter = 0x13;//enter
            server.StringEncoder = Encoding.UTF8;//t�rk�e karakter okuma
            server.DataReceived += Server_DataReceived;

            StartServer();

        }
        private void Starter_Btn_Click(object sender, EventArgs e)
        {
            sizePnl.Visible = false;
            y = 100;
            x = 100;
            ProductListPnl.Controls.Clear();
            var list = pc.GetByCategory("Starter");
            foreach (var item in list)
            {
                CreateGroupBox(ProductListPnl, item.Name, item.Price,item.Id);
            }
        }

        private void Beverage_Btn_Click(object sender, EventArgs e)
        {
            sizePnl.Visible = false;
            y = 100;
            x = 100;
            ProductListPnl.Controls.Clear();
            var list = pc.GetByCategory("Beverage");
            foreach (var item in list)
            {
                CreateGroupBox(ProductListPnl, item.Name, item.Price, item.Id);
            }
        }

        private bool ConnectToClient()
        {
            try
            {
                client.Connect("192.168.187.169", Convert.ToInt32("4001")); // mutfak ip
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }

        }

        private void StartServer()
        {
            System.Net.IPAddress ip = System.Net.IPAddress.Parse("192.168.187.232"); // �al��an ipsi
            int pcport = Convert.ToInt32("4000");
            server.Start(ip, pcport);
        }

        private void Server_DataReceived(object sender, SimpleTCP.Message e)
        {
            MessageBox.Show(e.MessageString);
        }


        private void Pizza_Btn_Click(object sender, EventArgs e)
        {
          
            y = 100;
            x = 100;
            ProductListPnl.Controls.Clear();
            int xs = 20;
            int xy = 10;
            var sizeList = db.Size.ToList();
            sizePnl.Visible = true;

            foreach (var item in sizeList)
            {
                Button sizeButton = new Button();
                sizeButton.Text = item.Name;
                sizeButton.Location = new Point(xs, xy);
                xs += 80;
                sizeButton.Click += SizeButton_Click;
               
           
               sizePnl.Controls.Add(sizeButton);
            }
            //var list = pc.GetByCategory("Pizza");
            //foreach (var item in list)
            //{
            //    CreateGroupBox(ProductListPnl, item.Name, item.Price);
            //}
        }

        private void SizeButton_Click(object sender, EventArgs e)
        {
            y = 100;
            x = 100;
            var sizeButton =(Button)sender;
            size = db.Size.Where(x=>x.Name == sizeButton.Text).First();
            ProductListPnl.Controls.Clear();

            var list = pc.GetByCategory("Pizza");
            foreach (var item in list)
            {
                CreateGroupBox(ProductListPnl, item.Name, item.Price, item.Id, size.ChangePrice);
            }
        }
        private void Campeign_Btn_Click(object sender, EventArgs e)
        {
            sizePnl.Visible = false;
            y = 100;
            x = 100;
            ProductListPnl.Controls.Clear();
            var list = db.Campaign.ToList();

            foreach (var item in list)
            {
                CreateGroupBox(ProductListPnl, item.Name, item.Price, item.Id);
            }
        }

        private void Sauce_Btn_Click(object sender, EventArgs e)
        {
            sizePnl.Visible = false;
            y = 100;
            x = 100;
            ProductListPnl.Controls.Clear();
            var list = pc.GetByCategory("Sauce");
            foreach (var item in list)
            {
                CreateGroupBox(ProductListPnl, item.Name, item.Price, item.Id, size.ChangePrice);
            }
        }

        private void Dessert_Btn_Click(object sender, EventArgs e)
        {
            sizePnl.Visible = false;
            y = 100;
            x = 100;
            ProductListPnl.Controls.Clear();
            var list = pc.GetByCategory("Dessert");
            foreach (var item in list)
            {
                CreateGroupBox(ProductListPnl, item.Name, item.Price, item.Id);
            }
        }

        private void denemeDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        public void CreateGroupBox(Panel panel, string title, double price, int id,double changedPrice)
        {


            if (x < 1200)
            {
                // GroupBox oluşturulur
                GroupBox groupBox = new GroupBox();
                groupBox.Text = "";
                groupBox.Size = new System.Drawing.Size(200, 100);
                groupBox.Location = new Point(x, y);

                // Label oluşturulur
                Label label = new Label();
                label.Text = $"{title} / {price + changedPrice} TL";
                label.Location = new Point(10, 20);
                label.AutoSize = true;

                // Arama yapma butonu
                Button searchButton = new Button();
                searchButton.Text = "🔍";
                searchButton.Location = new Point(10, 50);

                // Ekleme butonu
                Button addButton = new Button();
                addButton.Name = "addButton_" + id;
                addButton.Text = "+";
                addButton.Location = new Point(120, 50);
                addButton.Click += AddButton_Click;

                // Oluşturulan kontroller GroupBox içine eklenir
                groupBox.Controls.Add(label);
                groupBox.Controls.Add(searchButton);
                groupBox.Controls.Add(addButton);


                panel.Controls.Add(groupBox);
                x += 220;
            }
            else
            {
                y += 150;
                x = 100;
                // GroupBox oluşturulur
                GroupBox groupBox = new GroupBox();
                groupBox.Text = "";
                groupBox.Size = new System.Drawing.Size(200, 100);
                groupBox.Location = new Point(x, y);

                // Label oluşturulur
                Label label = new Label();
                label.Text = $"{title} / {price} TL";
                label.Location = new Point(10, 20);
                label.AutoSize = true;

                // Arama yapma butonu
                Button searchButton = new Button();
                searchButton.Text = "🔍";
                searchButton.Location = new Point(10, 50);

                // Ekleme butonu
                Button addButton = new Button();
                addButton.Text = "+";
                addButton.Location = new Point(120, 50);
                addButton.Click += AddButton_Click;

                // Oluşturulan kontroller GroupBox içine eklenir
                groupBox.Controls.Add(label);
                groupBox.Controls.Add(searchButton);
                groupBox.Controls.Add(addButton);


                panel.Controls.Add(groupBox);
                x += 220;
            }

        }

        private void denemeDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < denemeDgv.Rows.Count)
            {
                Product selectedProduct = (Product)denemeDgv.Rows[e.RowIndex].DataBoundItem;
                products.Remove(selectedProduct);
                denemeDgv.DataSource = null; 
                denemeDgv.DataSource = products;
                denemeDgv.Columns["Name"].DisplayIndex = 0;
                denemeDgv.Columns["PrepTime"].Visible = false;
                denemeDgv.Columns["Id"].Visible = false;
                denemeDgv.Columns["CategoryId"].Visible = false;
                denemeDgv.Columns["Category"].Visible = false;
                denemeDgv.Columns["IsStatus"].Visible = false;
                denemeDgv.Columns["IsDelete"].Visible = false;
               
                    totalPrice -= selectedProduct.Price;
                

                totalPriceLbl.Text = totalPrice.ToString() + "₺";
            }
        }

     
        private void DenemeBtn_Click(object sender, EventArgs e)
        {

            bool status = ConnectToClient();
            if (status)
                client.WriteLineAndGetReply("aaaaa", TimeSpan.FromSeconds(3));
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
        

            LoginForm loginForm = new LoginForm();

            if (products.Count > 0)
            {
                Order newOrder = new Order
                {
                    Name = "Sipariş",
                    CreatedTime = DateTime.Now,
                    TotalPrice = totalPrice,
                    StuffId = _stuff.Id,
                    IsStatus = true,
                    
                };

                db.Order.Add(newOrder);

                try
                {
                    db.SaveChanges(); // Save changes to get the newOrder Id
                }
                catch (DbUpdateException ex)
                {
                    // Handle exception
                    MessageBox.Show($"Error updating the database: {ex.Message}");
                    return;
                }

                List<OrderProduct> orderProducts = new List<OrderProduct>();
                string orderString = "";
                foreach (var product in products)
                {
                    orderString += product.Name+"_"+product.PrepTime+"_";
                    OrderProduct orderProduct = new OrderProduct();
                    if (product.CategoryId ==1)
                    {
                        orderProduct.OrderId = newOrder.Id;
                        orderProduct.ProductId = product.Id;
                        orderProduct.Quantiy = 1;
                        orderProduct.SizeId = size.Id;
                      
                    }
                    else if(product.CategoryId == 2 || product.CategoryId == 3 || product.CategoryId == 4 || product.CategoryId == 5 || product.CategoryId == 6)
                    {
                        orderProduct.OrderId = newOrder.Id;
                        orderProduct.ProductId = product.Id;
                        orderProduct.Quantiy = 1;
                        orderProduct.SizeId =4;
                    }
                    else
                    {
                        MessageBox.Show("sıkıntı var");
                    }


                    // Add the orderProduct to the list
                    orderProducts.Add(orderProduct);
                }

                // Add the list of orderProducts to the OrderProduct DbSet
                db.OrderProduct.AddRange(orderProducts);

                try
                {
                    db.SaveChanges(); // Save changes to add orderProducts
                }
                catch (DbUpdateException ex)
                {
                    // Handle exception
                    MessageBox.Show($"Error updating the database: {ex.Message}");
                    return;
                }
                

                bool status = ConnectToClient();
                if (status)
                    client.WriteLineAndGetReply(orderString, TimeSpan.FromSeconds(3));

                // Clear the products list
                products.Clear();

                // Refresh DataGridView
                denemeDgv.DataSource = null;
                denemeDgv.Refresh();

                // Reset total price
                totalPrice = 0;
                totalPriceLbl.Text = "₺0";

                MessageBox.Show("Siparişiniz başarıyla alındı!");
             

            }
            else
            {
                MessageBox.Show("Sipariş içeriği boş!");
            }
        }


    }
}




