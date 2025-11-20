using Infrastructure;
using Server.Events;
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
            _server.Context = factory.CreateDbContext(new string[] { "" });

            _server.UserConnected += OnUserConnected;
            _server.UserDisconnected += OnUserDisconnected;
            _server.MessageReceived += OnMessageReceived;

            _ = _server.StartAsync();

            FlipFlags();
        }
        private void OnUserConnected(object? s, UserConnectedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(() =>
                {
                    lbActiveUsers.Items.Add(e.User);
                    lbActiveUsers.TopIndex = lbActiveUsers.Items.Count - 1;
                });
            }
            else
            {
                lbActiveUsers.Items.Add(e.User);
                lbActiveUsers.TopIndex = lbActiveUsers.Items.Count - 1;
            }
        }
        private void OnMessageReceived(object? s, MessageReceivedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(() =>
                {
                    lbLogs.Items.Add(e.Message);
                    lbLogs.TopIndex = lbLogs.Items.Count - 1;
                });
            }
            else
            {
                lbLogs.Items.Add(e.Message);
                lbLogs.TopIndex = lbLogs.Items.Count - 1;
            }
        }
        private void OnUserDisconnected(object? s, UserDisconnectedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(() =>
                {
                    lbActiveUsers.Items.Remove(e.User);
                });
            }
            else
            {
                lbActiveUsers.Items.Remove(e.User);
            }
        }
        private void FlipFlags()
        {
            btnStop.Enabled = !btnStop.Enabled;
            btnStart.Enabled = !btnStart.Enabled;
            btnDisconnect.Enabled = !btnDisconnect.Enabled;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {

        }
    }
}
