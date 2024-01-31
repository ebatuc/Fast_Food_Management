using System.Text;
using System.Timers;
using SimpleTCP;


namespace Stuff
{
    public class TimerArgs : EventArgs
    {
        public int rt { get; set; }
        public Label lb { get; set; }
        public GroupBox gb { get; set; }
    }
    public partial class Form1 : Form
    {
        int x, y = 100;
        int lx = 10;
        int ly = 30;

        List<string> comingOrderList = new List<string>();
        SimpleTcpClient client;
        SimpleTcpServer server;
        Dictionary<string, List<string>> addresses = new()
        {
            {"kitchen", ["192.168.187.169", "4001"]},
            {"stuff", ["192.168.187.232", "4000"]},
            {"customer", ["192.168.1.39", "4002"]}
        };


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new SimpleTcpClient();
            server = new SimpleTcpServer();

            client.StringEncoder = Encoding.UTF8;

            server.Delimiter = 0x13;//enter
            server.StringEncoder = Encoding.UTF8;//türkçe karakter okuma
            server.DataReceived += Server_DataReceived;
            StartServer();
        }

        private bool ConnectToClient()
        {
            try
            {
                client.Connect(addresses["stuff"][0], Convert.ToInt32(addresses["stuff"][1]));
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot Connect To Kitchen, Try Again");
                return false;
            }
        }

        private void StartServer()
        {
            System.Net.IPAddress ip = System.Net.IPAddress.Parse(addresses["kitchen"][0]); // çalýþan ipsi
            int pcport = Convert.ToInt32(addresses["kitchen"][1]);
            server.Start(ip, pcport);
        }

        private void Server_DataReceived(object? sender, SimpleTCP.Message e)
        {
            if (!String.IsNullOrEmpty(e.MessageString))
            {
                comingOrderList = e.MessageString.Split("_").SkipLast(1).ToList();
            }
        }

        //private void SaveBtn_Click(object sender, EventArgs e)
        //{
        //    var status = ConnectToClient();
        //    if (status)
        //        client.WriteLineAndGetReply("aaaa", TimeSpan.FromSeconds(3));
        //}

        private void FillGroupBox()
        {

            GroupBox groupBox = new GroupBox();
            groupBox.Size = new Size(300, 300);
            groupBox.Location = new Point(x, y);
            int remainingTime = 0;
            for (int i = 0; i < comingOrderList.Count(); i++)
            {
                Label productName = new Label();
                productName.Size = new Size(150, 30);

                productName.Location = new Point(lx, ly);
                if (i % 2 == 0)
                {
                    ly += 35;
                    productName.Name = Guid.NewGuid().ToString();
                    productName.Text = comingOrderList[i];
                    groupBox.BackColor = Color.Red;
                    groupBox.Controls.Add(productName);
                }
                else
                {
                    remainingTime += Convert.ToInt32(comingOrderList[i]);
                }
            }
            Label timeLbl = new Label();
            timeLbl.Name = Guid.NewGuid().ToString();
            //timeLbl.Text = "Remainin Time: " +  remainingTime.ToString();
            timeLbl.Location = new Point(40, 270);
            timeLbl.Size = new Size(200, 40);
            groupBox.Controls.Add(timeLbl);
            //productName.Text = comingOrderList[0];
            panel1.Controls.Add(groupBox);
            x += 320;

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1300;
            timer.Enabled = false;

            timer.Tick += (sender, e) => Timer_Tick(this, new TimerArgs() { rt = remainingTime--, lb = timeLbl, gb = groupBox });

            timer.Start();
        }
        private void Timer_Tick(object? sender, EventArgs e)
        {
            int rt = ((TimerArgs)e).rt;
            if (rt >= 0)
            {
                ((TimerArgs)e).lb.Text = TimeSpan.FromSeconds(rt).ToString(@"mm\:ss");
            }
            else if (rt <= 0)
            {
                ((TimerArgs)e).gb.BackColor = Color.Green;
                //((System.Windows.Forms.Timer)sender).Stop();
            }
        }


        private void refreshBtn_Click(object sender, EventArgs e)
        {
            if (comingOrderList.Count() > 0)
            {
                FillGroupBox();
                comingOrderList.Clear();
                lx = 10;
                ly = 30;
            }
        }
    }
}