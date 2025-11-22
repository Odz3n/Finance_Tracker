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
    public partial class CategoryUI : UserControl
    {
        Client _client;
        ClientUserInfo _userInfo;
        CancellationTokenSource _cts;
        BindingSource _categoriesBinding = new BindingSource();

        public CategoryUI(Client client, ClientUserInfo userInfo)
        {
            InitializeComponent();
            _client = client;
            _userInfo = userInfo;
            _cts = new CancellationTokenSource();

            _client.CategoriesReceived += OnCategoriesReceived;
            _client.TransactionTypesReceived += OnTransactionTypesReceived;

            CategoryDataList.DataSource = _categoriesBinding;
            CategoryDataList.AutoGenerateColumns = true;

            var getCategoriesRequest = new GetCategoriesRequest();
            var getTransactionTypesRequest = new GetTransactionTypesRequest();
            _ = _client.SendRequestAsync(getCategoriesRequest, _cts.Token);
            _ = _client.SendRequestAsync(getTransactionTypesRequest, _cts.Token);
        }

        private async void CategoryAdd_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CategoryNameBX.Text))
            {
                MessageBox.Show("Category name must be provided!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var transaction = (CategoryTypeBX.SelectedItem as TransactionTypeDTO);
            if (transaction == null)
            {
                MessageBox.Show("Category type must be provided!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var transactionId = transaction.Id;
            var request = new AddCategoryRequest { Name = CategoryNameBX.Text, TransactionTypeId = transactionId };
            await _client.SendRequestAsync(request, _cts.Token);
        }

        private async void CategoryDel_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CategoryNameBX.Text))
            {
                MessageBox.Show("Category name must be provided!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var transaction = (CategoryTypeBX.SelectedItem as TransactionTypeDTO);
            if (transaction == null)
            {
                MessageBox.Show("Category type must be provided!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var res = MessageBox.Show("Are you sure you want to delete this category?", "Confirm Deletion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                var transactionId = transaction.Id;
                var request = new DeleteCategoryRequest { Name = CategoryNameBX.Text, TransactionTypeId = transactionId };
                await _client.SendRequestAsync(request, _cts.Token);
            }
            else
                return;
        }

        private async void CategoryUpdate_btn_Click(object sender, EventArgs e)
        {
            var request = new GetCategoriesRequest();
            await _client.SendRequestAsync(request, _cts.Token);
        }
        private void OnCategoriesReceived(object? s, CategoriesReceivedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(() =>
                {
                    UpdateCategoriesGrid(e.Categories);
                });
            }
            else
                UpdateCategoriesGrid(e.Categories);
        }
        private void OnTransactionTypesReceived(object? s, TransactionTypesReceivedEventArgs e)
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
        private void BindTransactionTypes(List<TransactionTypeDTO> transactionTypes)
        {
            CategoryTypeBX.DataSource = transactionTypes;
        }
        private void UpdateCategoriesGrid(List<CategoryDTO> categories)
        {
            var list = new BindingList<CategoryDTO>(categories);
            _categoriesBinding.DataSource = list;

            _categoriesBinding.ResetBindings(false);
        }
    }
}
