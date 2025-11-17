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
        public WalletUI()
        {
            InitializeComponent();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void WalletDel_btn_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to delete this wallet?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                // Code to delete the wallet goes here
                MessageBox.Show("Wallet deleted successfully.", "Deletion Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
        }
    }
}
