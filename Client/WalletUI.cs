using Client.Events;
using Shared.DTOs;
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
    public partial class WalletUI : UserControl
    {
        Client _client;
        ClientUserInfo _userInfo;
        CancellationTokenSource _cts;

        BindingSource _walletsBinding = new BindingSource();

        public WalletUI(Client client, ClientUserInfo userInfo)
        {
            InitializeComponent();

            _client = client;
            _userInfo = userInfo;
            _cts = new CancellationTokenSource();

            _client.WalletsReceived += OnWalletsReceived;
            _client.CurrenciesReceived += OnCurrenciesReceived;

            WalletDataList.DataSource = _walletsBinding;
            WalletDataList.AutoGenerateColumns = true;

            var walletsRequest = new GetWalletsRequest
            {
                UserId = _userInfo.Id
            };
            var currenciesRequest = new GetCurrenciesRequest();

            _ = _client.SendRequestAsync(walletsRequest, _cts.Token);
            _ = _client.SendRequestAsync(currenciesRequest, _cts.Token);
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private async void WalletDel_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(WalletNameBX.Text))
            {
                MessageBox.Show("Wallet name must be provided!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var res = MessageBox.Show("Are you sure you want to delete this wallet?", "Confirm Deletion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                if (string.IsNullOrEmpty(WalletNameBX.Text))
                    return;

                var request = new DeleteWalletRequest { UserId = _userInfo.Id, WalletName = WalletNameBX.Text };
                await _client.SendRequestAsync(request, _cts.Token);
                await _client.SendRequestAsync(new GetWalletsRequest { UserId = _userInfo.Id }, _cts.Token);
            }
        }

        private async void WalletAdd_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(WalletNameBX.Text))
                {
                    MessageBox.Show("Wallet name must be provided!", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var currencyDto = WalletCurrencyBX.SelectedItem as CurrencyDTO;
                if (currencyDto == null)
                {
                    MessageBox.Show("Please select a currency.");
                    return;
                }

                var request = new AddWalletRequest
                {
                    UserId = _userInfo.Id,
                    Name = WalletNameBX.Text,
                    CurrencyId = currencyDto.Id,
                    Balance = 0m
                };
                await _client.SendRequestAsync(request, _cts.Token);
                await _client.SendRequestAsync(new GetWalletsRequest { UserId = _userInfo.Id }, _cts.Token);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"WalletAdd_btn_Click: {ex.Message}");
            }
        }
        private void OnWalletsReceived(object? s, WalletsReceivedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(() =>
                {
                    UpdateWalletGrid(e.Wallets);
                });
            }
            else
            {
                UpdateWalletGrid(e.Wallets);
            }
        }
        private void OnCurrenciesReceived(object? s, CurrenciesReceivedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(() =>
                {
                    BindCurrencies(e.Currencies);
                });
            }
            else
            {
                BindCurrencies(e.Currencies);
            }
        }
        private void BindCurrencies(List<CurrencyDTO> currencies)
        {
            WalletCurrencyBX.DataSource = currencies;
        }
        private void UpdateWalletGrid(List<WalletDTO> wallets)
        {
            var list = new BindingList<WalletDTO>(wallets);
            _walletsBinding.DataSource = list;

            _walletsBinding.ResetBindings(false);
        }

        private async void WalletUpdate_btn_Click(object sender, EventArgs e)
        {
            var request = new GetWalletsRequest { UserId = _userInfo.Id };
            await _client.SendRequestAsync(request, _cts.Token);
        }
    }
}
