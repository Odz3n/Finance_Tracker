
using Shared.Requests;
using Shared.Responses;

namespace Client
{
    public partial class LoginUI : Form
    {
        Client _client;
        CancellationTokenSource _cts;
        public LoginUI()
        {
            InitializeComponent();
            _client = new Client("127.0.0.1", 3333);
            _cts = new CancellationTokenSource();
            _client.MessageReceived += OnMessageReceived;
            _client.UserVerified += OnUserVerified;
            _ = _client.ConnectAsync();
        }
        private void OnMessageReceived(object? s, MessageReceivedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(() =>
                {
                    if (e.IsSuccess == true)
                        MessageBox.Show(e.Message, "Server notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show(e.Message, "Server notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                });
            }
            else
            {
                if (e.IsSuccess == true)
                    MessageBox.Show(e.Message, "Server notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show(e.Message, "Server notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void OnUserVerified(object? s, UserVerifiedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(() =>
                {
                    if (e.IsVerified == true)
                    {
                        this.Hide();
                        ClientUI clientUI = new ClientUI(_client, e.UserLogin);
                        clientUI.Show();
                    }
                    else return;
                });
            }
            else
            {
                if (e.IsVerified == true)
                {
                    this.Hide();
                    ClientUI clientUI = new ClientUI(_client, e.UserLogin);
                    clientUI.Show();
                }
                else return;
            }
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


        private async void login_btn_Click(object sender, EventArgs e)
        {
            if (login_btn.Text == "REGISTER")
            {
                if (string.IsNullOrEmpty(login_username.Text) 
                    || string.IsNullOrEmpty(login_password.Text)
                    || string.IsNullOrEmpty(login_firstname_BX.Text)
                    || string.IsNullOrEmpty(login_lastname_BX.Text))
                {
                    MessageBox.Show("All fields are required.", "Warning!",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var request = new RegistrationRequest
                {
                    FirstName = login_firstname_BX.Text,
                    LastName = login_lastname_BX.Text,
                    Login = login_username.Text,
                    Password = login_password.Text
                };
                await _client.SendRequestAsync(request, _cts.Token);
                login_signupBtn_Click(sender, e);
            }
            if (login_btn.Text == "LOGIN")
            {
                if (string.IsNullOrEmpty(login_username.Text) || string.IsNullOrEmpty(login_password.Text))
                {
                    MessageBox.Show("Login and password must be specified.", "Warning!",
                                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var authRequest = new AuthorizationRequest
                {
                    Login = login_username.Text,
                    Password = login_password.Text
                };

                await _client.SendRequestAsync(authRequest, _cts.Token);
            }
        }

        private async void LoginUI_Load(object sender, EventArgs e)
        {

        }
        private void LoginUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            _client.Dispose();
            Application.Exit();
        }
    }
}
