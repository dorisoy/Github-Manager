using System;
using Octokit;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Security.Cryptography;

namespace github_management
{
    public partial class LogIn : Form
    {
        // save the Main form instance so we can set the client variable and show again
        Main invoker;

        // used to indicate if the user authenticated in this form instance
        // if authentication occurs this is set to true
        // so when closing this form, if there was no authentication, the main form will close too
        // if that was not to happen, main form would have stayed open, but not visible and take the process
        bool authed = false;
        public LogIn(Main invoker)
        {
            InitializeComponent();
            this.invoker = invoker;
        }

        private void Log_in_Click(object sender, EventArgs e)
        {
            string username = username_tb.Text;
            string password = password_tb.Text;

            if (ValidateLogIn(username, password))
            {
                GitHubClient client = Authenticate(username, password);
                if (client != null)
                {
                    // user is authenticated
                    authed = true;

                    // close this
                    this.Close();

                    // show main form
                    invoker.Show();
                    invoker.LoadClient();
                }
                else
                {
                    // user is not authenticated
                    login_err.Text = "Failed to authenticate";
                }
            }
        }

        private bool ValidateLogIn(string username, string password)
        {
            bool valid = true;
            username_err.Text = "";
            password_err.Text = "";
            login_err.Text = "";

            if (username.Trim().Length == 0)
            {
                username_err.Text = "Username is empty";
                valid = false;
            }
            if (password.Trim().Length == 0)
            {
                password_err.Text = "Password is empty";
                valid = false;
            }

            return valid;
        }

        private GitHubClient Authenticate(string username, string password)
        {
            var client = new GitHubClient(new ProductHeaderValue("personal-gh-management-app"));
            var basicAuth = new Credentials(username, password);
            client.Credentials = basicAuth;

            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\GithubManager", true);
            key.SetValue("username", username);
            key.SetValue("password", password);
            key.Close();

            return client;
        }

        private void LogIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!authed)
            {
                invoker.Close();
            }
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon(@"GitHub-Mark/github_mark_120px_plus_Bzz_icon.ico");
        }
    }
}
