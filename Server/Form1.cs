using Infrastructure;
using System.Net;

namespace Server
{
    public partial class Form_Login : Form
    {
        Server _server;
        public Form_Login()
        {
            InitializeComponent();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbIp.Text) || string.IsNullOrEmpty(tbPort.Text))
            {
                MessageBox.Show("IP and PORT must be specified!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _server = new Server(IPAddress.Parse(tbIp.Text), int.Parse(tbPort.Text));

            var factory = new FinanceTrackerDbContextFactory();
            _server.Context = factory.CreateDbContext(new string[]{ "" });
            _ = _server.StartAsync();
        }
    }
}
