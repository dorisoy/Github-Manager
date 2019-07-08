using Microsoft.Win32;
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

namespace github_management
{
    public partial class Main : Form
    {
        GitHubClient client;
        User user;
        List<Repository> repositories;
        delegate void SetWelcomeLabelCallback();
        delegate void PopulatePanelCallback();
        delegate void SetUpMenuCallback();

        bool show_login_on_show = false;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            if (show_login_on_show)
            {
                LogIn(null, null);
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            LoadClient();
        }

        public void LoadClient()
        {
            //Registry.CurrentUser.DeleteSubKey(@"SOFTWARE\GithubManager");
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\GithubManager", true);

            bool set_up = key != null;

            if (!set_up)
            {
                show_login_on_show = true;
            }
            else
            {
                if(key.GetValue("username") == null || key.GetValue("password") == null)
                {
                    show_login_on_show = true;
                }
                else
                {
                    client = new GitHubClient(new ProductHeaderValue("personal-gh-management-app"));
                    var basicAuth = new Credentials(key.GetValue("username").ToString(), key.GetValue("password").ToString());
                    client.Credentials = basicAuth;

                    menu_strip.Items.Clear();

                    ToolStripItem log_out_item = new ToolStripMenuItem();
                    log_out_item.Text = "Log Out";
                    log_out_item.Click += new EventHandler(LogOut);
                    menu_strip.Items.Add(log_out_item);

                    var task = SetUserAsync();
                    task.ContinueWith(Authenticated);
                }
            }

            key.Close();
        }


        private void Authenticated(Task obj)
        {
            if(user != null)
            {
                WriteWelcomeLabelSafe();
                SetUserReposAsync();
            }
            else
            {
                LogOut(null, null);
                MessageBox.Show("Authentication failed. Please try to log in again.");
            }
        }

        private void WriteWelcomeLabelSafe()
        {
            if (welcome_lb.InvokeRequired)
            {
                var d = new SetWelcomeLabelCallback(WriteWelcomeLabelSafe);
                Invoke(d);
            }
            else
            {
                welcome_lb.Text = "Welcome, " + user.Name.Substring(0, user.Name.IndexOf(' '));
            }
        }

        private async Task SetUserAsync()
        {
            user = await client.User.Current();
        }

        private async Task SetUserReposAsync()
        {
            var repos = await client.Repository.GetAllForCurrent();
            repositories = repos.ToList();
            PopulatePanelSafe();
        }

        private void PopulatePanelSafe()
        {
            if (repos_panel.InvokeRequired)
            {
                var d = new PopulatePanelCallback(PopulatePanelSafe);
                Invoke(d);
            }
            else
            {
                repo_count_lb.Text = "Showing " + repositories.Count + " repos";
                for (int i = 0; i < repositories.Count; i++)
                {
                    // this repo
                    Repository this_repo = repositories[i];

                    // create new label instance
                    System.Windows.Forms.Label lb = new System.Windows.Forms.Label();
                    lb.Text = repositories[i].FullName;
                    lb.Width = repos_panel.Width;

                    // create event
                    // let it lead to lambda function that has only sender and e
                    // that lambda function will call our callback function
                    // this way we can pass extra arguments to event function
                    lb.Click += (sender, e) => Repo_Label_Click(sender, e, this_repo);

                    lb.MouseEnter += new EventHandler(Repo_Label_Mouse_Enter);
                    lb.MouseLeave += new EventHandler(Repo_Label_Mouse_Leave);

                    // add to panel
                    repos_panel.Controls.Add(lb);
                }

                // in case user reauthenticates
                // panel will hide on log out
                // and this is when it will show again
                window_panel.Show();
            }
        }

        protected void Repo_Label_Mouse_Enter(object sender, EventArgs e)
        {
            System.Windows.Forms.Label lb = sender as System.Windows.Forms.Label;
            this.Cursor = Cursors.Hand;

            lb.ForeColor = Color.DarkGreen;
        }

        protected void Repo_Label_Mouse_Leave(object sender, EventArgs e)
        {
            System.Windows.Forms.Label lb = sender as System.Windows.Forms.Label;
            this.Cursor = Cursors.Default;

            lb.ForeColor = Color.Black;
        }

        protected void Repo_Label_Click(object sender, EventArgs e, Repository repo)
        {
            //attempt to cast the sender as a label
            System.Windows.Forms.Label lbl = sender as System.Windows.Forms.Label;

            //if the cast was successful (i.e. not null), navigate to the site
            if (lbl != null)
            {
                empty_lb.Hide();

                repo_name.Text = repo.FullName;
                if(repo.Description != null)
                {
                    repo_desc.Text = repo.Description;
                }
                else
                {
                    repo_desc.Text = "No description";
                }
            }
                
        }

        private void LogOut(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\GithubManager", true);

            key.DeleteValue("username");
            key.DeleteValue("password");
            user = null;
            client = null;

            SetUpMenu();

            key.Close();
        }

        private void SetUpMenu()
        {
            if (window_panel.InvokeRequired)
            {
                var d = new SetUpMenuCallback(SetUpMenu);
                Invoke(d);
            }
            else
            {
                menu_strip.Items.Clear();

                window_panel.Hide();

                ToolStripItem log_in_item = new ToolStripMenuItem();
                log_in_item.Text = "Log In";
                log_in_item.Click += new EventHandler(LogIn);
                menu_strip.Items.Add(log_in_item);
            }
        }

        private void LogIn(object sender, EventArgs e)
        {
            LogIn form = new LogIn(this);
            this.Hide();
            form.Show();
        }
    }
}
