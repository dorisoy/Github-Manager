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
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace github_management
{
    public partial class Main : Form
    {
        // github client
        GitHubClient client;

        // current user
        User user;

        // list of users repositories
        List<Repository> repositories;

        // used to reference on currently opened repository
        Repository current_repo;

        // used when invoke is required for Form controles
        delegate void SetWelcomeLabelCallback();
        delegate void PopulatePanelCallback();
        delegate void SetUpMenuCallback();

        // this is set on load and indicates if to show log in on Form_Shown
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
            this.Icon = new Icon(@"GitHub-Mark/github_mark_120px_plus_Bzz_icon.ico");
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
                    if (key.GetValue("bash_path") == null || key.GetValue("wroking_directory") == null)
                    {
                        key.SetValue("bash_path", "D:/Instalirani       Programi/Git/bin/bash.exe");

                        key.SetValue("wroking_directory", "C:/wamp64/   www");
                    }
                    

                    client = new GitHubClient(new ProductHeaderValue("personal-gh-management-app"));
                    var basicAuth = new Credentials(key.GetValue("username").ToString(), key.GetValue("password").ToString());
                    client.Credentials = basicAuth;

                    for(int i = 0; i < menu_strip.Items.Count; i++)
                    {
                        if(menu_strip.Items[i].Text == "Log In")
                        {
                            menu_strip.Items.RemoveAt(i);
                            break;
                        }
                    }

                    // add log out item
                    ToolStripItem log_out_item = new ToolStripMenuItem();
                    log_out_item.Text = "Log Out";
                    log_out_item.Click += new EventHandler(LogOut);
                    menu_strip.Items.Add(log_out_item);

                    var task = SetUserAsync();
                    general_progress_bar.Value = 10;
                    general_progress_bar.Visible = true;
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
                general_progress_bar.Value = 20;
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
                PopulatePanel(repositories);
            }
        }

        private void PopulatePanel(List<Repository> repos_list)
        {
            repos_panel.Controls.Clear();

            general_progress_bar.Value = 30;
            repo_count_lb.Text = "Showing " + repos_list.Count + " repos";

            double increase = 70 / repos_list.Count;

            for (int i = 0; i < repos_list.Count; i++)
            {
                // this repo
                Repository this_repo = repos_list[i];

                // create new label instance
                System.Windows.Forms.Label lb = new System.Windows.Forms.Label();
                lb.Text = repos_list[i].FullName;
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

                general_progress_bar.Value += (int)increase;
            }

            general_progress_bar.Value = 100;
            general_progress_bar.Visible = false;

            // in case user reauthenticates
            // panel will hide on log out
            // and this is when it will show again
            window_panel.Show();
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
                    
            //if the cast was successful (i.e. not null)
            if (lbl != null)
            {
                current_repo = repo;

                empty_lb.Hide();

                // set repo name
                repo_name.Text = repo.FullName;

                // set hidden textbox tetx to clone url
                clone_url_tb.Text = repo.CloneUrl;

                // set repo description
                if (repo.Description != null)
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
                // remove log out item
                for (int i = 0; i < menu_strip.Items.Count; i++)
                {
                    if (menu_strip.Items[i].Text == "Log Out")
                    {
                        menu_strip.Items.RemoveAt(i);
                        break;
                    }
                }

                window_panel.Hide();

                // add log in item
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

        private void Repo_name_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(clone_url_tb.Text);
        }

        private void Open_terminal_Click(object sender, EventArgs e)
        {
            if(current_repo != null)
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\GithubManager", true);

                Process process = new Process();

                ProcessStartInfo processStartInfo = new ProcessStartInfo();
                processStartInfo.WindowStyle = ProcessWindowStyle.Normal;
                processStartInfo.FileName = key.GetValue("bash_path").ToString();

                string path_to_project = key.GetValue("working_directory").ToString() + "/" + current_repo.Name;
                if (Directory.Exists(path_to_project))
                {
                    processStartInfo.WorkingDirectory = path_to_project;
                }
                else
                {
                    processStartInfo.WorkingDirectory = key.GetValue("working_directory").ToString();
                }


                Clipboard.SetText(current_repo.CloneUrl);

                process.StartInfo = processStartInfo;
                process.Start();

                key.Close();
            }
        }

        private void Copy_Clone_Url_Click(object sender, EventArgs e)
        {
            if(current_repo != null)
            {
                Clipboard.SetText(current_repo.CloneUrl);

                MessageBox.Show("URL copied to clipboard.");
            }
        }

        private void ChangeBashPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeBashPathDialog.ShowDialog();

            if(changeBashPathDialog.FileName != null && changeBashPathDialog.FileName.Trim() != "")
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\GithubManager", true);

                key.SetValue("bash_path", changeBashPathDialog.FileName);

                key.Close();
            }
        }

        private void ChangeWorkingDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeWorkingDirectoryDialog.ShowDialog();

            if (changeWorkingDirectoryDialog.SelectedPath != null && changeWorkingDirectoryDialog.SelectedPath.Trim() != "")
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\GithubManager", true);

                key.SetValue("working_directory", changeWorkingDirectoryDialog.SelectedPath);

                key.Close();
            }
        }

        private void ShowInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\GithubManager", true);

            MessageBox.Show(
                "Working directory: " + key.GetValue("working_directory").ToString() + "\n" +
                "Bash path: " + key.GetValue("bash_path").ToString(),
                "Variables information"
                );

            key.Close();
        }

        private void Search_tb_TextChanged(object sender, EventArgs e)
        {
            TextBox search_tb = sender as TextBox;
            if(search_tb.Text.Trim() == "")
            {
                PopulatePanel(repositories);
            }
            else
            {
                List<Repository> results = new List<Repository>();
                foreach(Repository repo in repositories)
                {
                    if (repo.FullName.Contains(search_tb.Text.Trim()))
                    {
                        results.Add(repo);
                    }
                }

                PopulatePanel(results);
            }
        }
    }
}
