using Shared.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ClientUI : Form
    {
        Client _client;
        ClientUserInfo _userInfo;
        CancellationTokenSource _cts;
        public ClientUI(Client client, ClientUserInfo? userInfo)
        {
            InitializeComponent();
            _client = client;
            _userInfo = userInfo;
            _cts = new CancellationTokenSource();

            lblUserLogin.Text = _userInfo?.Login;
        }

        private void ClientUI_Load(object sender, EventArgs e)
        {

        }

        private void ClientPanel_pnl_Paint(object sender, PaintEventArgs e)
        {
            DashboardUI dashboard = new DashboardUI();
            ClientPanel_pnl.Controls.Add(dashboard);
            dashboard.Show();
            dashboard.Dock = DockStyle.Fill;

        }

        private async void ClientLogout_btn_Click(object sender, EventArgs e)
        {
            //hide client uiform show log in form
            var request = new DisconnectRequest();
            await _client.SendRequestAsync(request, _cts.Token);

            this.Hide();
            LoginUI login = new LoginUI();
            login.Show();
        }

        private async void ClientWallet_btn_Click(object sender, EventArgs e)
        {
            //clear panel
            ClientPanel_pnl.Controls.Clear();
            WalletUI wallet = new WalletUI(_client, _userInfo);
            ClientPanel_pnl.Controls.Add(wallet);
            wallet.Show();
            wallet.Dock = DockStyle.Fill;

        }

        private void ClientUserPanel_pnl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ClientDashboard_btn_Click(object sender, EventArgs e)
        {
            //clear panel
            ClientPanel_pnl.Controls.Clear();
            DashboardUI dashboard = new DashboardUI();
            ClientPanel_pnl.Controls.Add(dashboard);
            dashboard.Show();
            dashboard.Dock = DockStyle.Fill;

        }

        private void ClientCategory_btn_Click(object sender, EventArgs e)
        {
            //clear panel
            ClientPanel_pnl.Controls.Clear();
            CategoryUI category = new CategoryUI(_client, _userInfo);
            ClientPanel_pnl.Controls.Add(category);
            category.Show();
            category.Dock = DockStyle.Fill;

        }

        private void ClientTransaction_btn_Click(object sender, EventArgs e)
        {
            //clear panel
            ClientPanel_pnl.Controls.Clear();
            TransactionUI transaction = new TransactionUI(_client, _userInfo);
            ClientPanel_pnl.Controls.Add(transaction);
            transaction.Show();
            transaction.Dock = DockStyle.Fill;

        }

        private void ClientUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
