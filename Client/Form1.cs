
namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
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
            if(login_signupBtn.Text == "SIGN UP")
            {
                login_registerLbl.Text = "LOG IN HERE";
                login_signupBtn.Text = "SIGN IN";
                login_signinLbl.Text = "REGISTRATION";
                login_btn.Text = "REGISTER";
            }
            else if (login_signupBtn.Text == "SIGN IN")
            {
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

            if (login_username.Text == "" || login_password.Text == "")
            {
                MessageBox.Show("Please fill all blank fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //placeholder for login authentication
            else if (login_username.Text == "admin" && login_password.Text == "password")
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.Hide();

            }
            //------------
            else
            {
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
