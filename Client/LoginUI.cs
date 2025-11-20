
namespace Client
{
    public partial class LoginUI : Form
    {
        public LoginUI()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                if (keyData == (Keys.Escape))
                {
                    Application.Exit();
                    return true;
                }
                else if (keyData == (Keys.Enter))
                {
                    login_btn.PerformClick();
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        private void login_showPass_CheckedChanged(object sender, EventArgs e)
        {
            if (login_showPass.Checked)
            {
                login_password.UseSystemPasswordChar = false;
            }
            else
            {
                login_password.UseSystemPasswordChar = true;
            }


        }

        private void login_signupBtn_Click(object sender, EventArgs e)
        {
            if (login_signupBtn.Text == "SIGN UP")
            {
                login_registerLbl.Text = "LOG IN HERE";
                login_signupBtn.Text = "SIGN IN";
                login_signinLbl.Text = "REGISTRATION";
                login_btn.Text = "REGISTER";
                //show and enable registration form fields
                login_firstname_BX.Visible = true;
                login_lastname_BX.Visible = true;
                login_firstname_lbl.Visible = true;
                login_lastname_lbl.Visible = true;
                login_firstname_BX.Enabled = true;
                login_lastname_BX.Enabled = true;
            }
            else if (login_signupBtn.Text == "SIGN IN")
            {
                login_firstname_BX.Visible = false;
                login_lastname_BX.Visible = false;
                login_firstname_lbl.Visible = false;
                login_lastname_lbl.Visible = false;
                login_registerLbl.Text = "REGISTER HERE";
                login_signupBtn.Text = "SIGN UP";
                login_signinLbl.Text = "SIGN IN";
                login_btn.Text = "LOGIN";
            }
            else
            {
                return;
            }

        }


        private void login_btn_Click(object sender, EventArgs e)
        {
            if (login_btn.Text == "REGISTER")
            {
                //placeholder for registration functionality
                MessageBox.Show("Registration functionality is not implemented yet.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {

                if (login_username.Text == "" || login_password.Text == "")
                {
                    MessageBox.Show("Please fill all blank fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //placeholder for login authentication
                else if (login_username.Text == "admin" && login_password.Text == "password")
                {
                    this.Hide();
                    ClientUI clientUI = new ClientUI();
                    clientUI.Show();


                }
                //------------
                else
                {
                    MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoginUI_Load(object sender, EventArgs e)
        {

        }
        private void LoginUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
