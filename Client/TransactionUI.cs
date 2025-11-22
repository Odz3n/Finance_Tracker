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
    public partial class TransactionUI : UserControl
    {
        Client _client;
        ClientUserInfo _userInfo;
        CancellationTokenSource _cts;
        BindingSource _transactionsBinding = new BindingSource();
        public TransactionUI(Client client, ClientUserInfo userInfo)
        {
            InitializeComponent();
            _cts = new CancellationTokenSource();
            _client = client;
            _userInfo = userInfo;

            _client.TransactionsReceived += OnTransactionsReceived;
            _client.WalletsReceived += OnWalletsReceived;
            _client.CurrenciesReceived += OnCurrenciesReceived;
            _client.CategoriesReceived += OnCategoriesReceived;
            _client.TransactionTypesReceived += OnTransactinTypesReceived;

            TransactionList.DataSource = _transactionsBinding;
            TransactionList.AutoGenerateColumns = true;

            _ = _client.SendRequestAsync(new GetTransactionsRequest { UserId = _userInfo.Id }, _cts.Token);
            _ = _client.SendRequestAsync(new GetWalletsRequest { UserId = _userInfo.Id }, _cts.Token);
            _ = _client.SendRequestAsync(new GetCurrenciesRequest(), _cts.Token);
            _ = _client.SendRequestAsync(new GetCategoriesRequest(), _cts.Token);
            _ = _client.SendRequestAsync(new GetTransactionTypesRequest(), _cts.Token);
        }
        private void OnTransactionsReceived(object? s, TransactionsReceivedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(() =>
                {
                    UpdateTransactionsGrid(e.Transactions);
                    BindTransactions(e.Transactions);
                });
            }
            else
            {
                UpdateTransactionsGrid(e.Transactions);
                BindTransactions(e.Transactions);
            }
        }
        private void OnWalletsReceived(object? s, WalletsReceivedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(() =>
                {
                    BindWallets(e.Wallets);
                });
            }
            else
                BindWallets(e.Wallets);
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
                BindCurrencies(e.Currencies);
        }
        private void OnCategoriesReceived(object? s, CategoriesReceivedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(() =>
                {
                    BindCategories(e.Categories);
                });
            }
            else
                BindCategories(e.Categories);
        }
        private void OnTransactinTypesReceived(object? s, TransactionTypesReceivedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(() =>
                {
                    BindTransactionTypes(e.TransactionTypes);
                });
            }
            else
                BindTransactionTypes(e.TransactionTypes);
        }
        private void BindWallets(List<WalletDTO> wallets)
        {
            TransactionAddWallet_BX.DataSource = wallets;
            TransactionFilterWallet_BX.DataSource = wallets;
        }
        private void BindCurrencies(List<CurrencyDTO> currencies)
        {
            TransactionAddCurrency_Bx.DataSource = currencies;
        }
        private void BindCategories(List<CategoryDTO> categories)
        {
            TransactionAddCategory_BX.DataSource = categories;
            TransactionFilterCategory_BX.DataSource = categories;
        }
        private void BindTransactionTypes(List<TransactionTypeDTO> transactionTypes)
        {
            TransactionFilterType_BX.DataSource = transactionTypes;
        }
        private void BindTransactions(List<TransactionDTO> transactions)
        {
            TransactionDel_BX.DataSource = transactions;
        }
        private void UpdateTransactionsGrid(List<TransactionDTO> transactions)
        {
            var list = new BindingList<TransactionDTO>(transactions);
            _transactionsBinding.DataSource = list;

            _transactionsBinding.ResetBindings(false);
        }

        private async void TransactionAdd_btn_Click(object sender, EventArgs e)
        {
            try
            {
                var wallet = TransactionAddWallet_BX.SelectedItem as WalletDTO;
                if (wallet == null)
                {
                    MessageBox.Show("Wallet must be provided!", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var currency = TransactionAddCurrency_Bx.SelectedItem as CurrencyDTO;
                if (currency == null)
                {
                    MessageBox.Show("Currency must be provided!", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var category = TransactionAddCategory_BX.SelectedItem as CategoryDTO;
                if (category == null)
                {
                    MessageBox.Show("Category must be provided!", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var result = decimal.TryParse(TransactionAddAmount_BX.Text, out var amount);
                if (!result)
                {
                    MessageBox.Show("Correct amount format must be provided!", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (amount < 0)
                {
                    MessageBox.Show("Amount can't be negative!", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var request = new AddTransactionRequest
                {
                    WalletId = wallet.Id,
                    CurrencyId = currency.Id,
                    CategoryId = category.Id,
                    Amount = amount,
                    DateTime = TransactionAddDateTime.Value,
                    Note = TransactionAddDetails_BX.Text
                };
                await _client.SendRequestAsync(request, _cts.Token);

                await _client.SendRequestAsync(new GetTransactionsRequest { UserId = _userInfo.Id }, _cts.Token);
                await _client.SendRequestAsync(new GetWalletsRequest { UserId = _userInfo.Id }, _cts.Token);
                await _client.SendRequestAsync(new GetCurrenciesRequest(), _cts.Token);
                await _client.SendRequestAsync(new GetCategoriesRequest(), _cts.Token);
                await _client.SendRequestAsync(new GetTransactionTypesRequest(), _cts.Token);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"TransactionAdd_btn_Click: {ex.Message}");
            }
        }

        private async void TransactionDel_btn_Click(object sender, EventArgs e)
        {
            try
            {
                var transaction = TransactionDel_BX.SelectedItem as TransactionDTO;
                if (transaction == null)
                {
                    MessageBox.Show("Transaction must be provided!", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                await _client.SendRequestAsync(new DeleteTransactionRequest { TransactionId = transaction.Id }, _cts.Token);

                await _client.SendRequestAsync(new GetTransactionsRequest { UserId = _userInfo.Id }, _cts.Token);
                await _client.SendRequestAsync(new GetWalletsRequest { UserId = _userInfo.Id }, _cts.Token);
                await _client.SendRequestAsync(new GetCurrenciesRequest(), _cts.Token);
                await _client.SendRequestAsync(new GetCategoriesRequest(), _cts.Token);
                await _client.SendRequestAsync(new GetTransactionTypesRequest(), _cts.Token);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"TransactionDel_btn_Click: {ex.Message}");
            }
        }

        private async void TransactionFilter_btn_Click(object sender, EventArgs e)
        {
            await _client.SendRequestAsync(new GetTransactionsRequest { UserId = _userInfo.Id }, _cts.Token);
            await _client.SendRequestAsync(new GetWalletsRequest { UserId = _userInfo.Id }, _cts.Token);
            await _client.SendRequestAsync(new GetCurrenciesRequest(), _cts.Token);
            await _client.SendRequestAsync(new GetCategoriesRequest(), _cts.Token);
            await _client.SendRequestAsync(new GetTransactionTypesRequest(), _cts.Token);
        }
    }
}
