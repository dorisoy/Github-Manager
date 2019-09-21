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
using System.Net;

namespace github_management
{
    public partial class Main : Form
    {
        // github client
        GitHubClient client;

        // current user
        User user;

        // list of users repositories
        public List<Repository> repositories;

        // used to reference on currently opened repository
        public Repository current_repo;

        // this is set on load and indicates if to show log in on Form_Shown
        public bool show_login_on_show = false;

        // indicates if repo is loading currently
        public bool repo_loading = false;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            if (show_login_on_show)
            {
                ShowLogInForm(null, null);
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon(@"GitHub-Mark/github_mark_120px_plus_Bzz_icon.ico");

            open_terminal.Image = Image.FromFile(@"Images/terminal.png");
            open_terminal.ImageAlign = ContentAlignment.MiddleLeft;
            open_terminal.TextAlign = ContentAlignment.MiddleRight;

            copy_clone_url.Image = Image.FromFile(@"Images/copy.png");
            copy_clone_url.ImageAlign = ContentAlignment.MiddleLeft;
            copy_clone_url.TextAlign = ContentAlignment.MiddleRight;

            LoadClient();
        }

        // load client based on username and password from registry
        // if nothing is set in registry, log in
        public async void LoadClient()
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
                        key.SetValue("bash_path", "D:/Instalirani Programi/Git/bin/bash.exe");

                        key.SetValue("wroking_directory", "C:/wamp64/www");
                    }


                    empty_lb.Hide();

                    client = new GitHubClient(new ProductHeaderValue("personal-gh-management-app"));
                    //Credentials basicAuth = new Credentials(key.GetValue("username").ToString(), key.GetValue("password").ToString());
                    Credentials basicAuth = new Credentials("d6253481d3615b49d6a31badc75f802c7b322c09", AuthenticationType.Oauth);
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

                    // set user
                    user = await GetUserAsync();

                    general_progress_bar.Value = 10;
                    general_progress_bar.Visible = true;

                    // if user is authed successfully
                    if(user != null)
                    {
                        // welcome user
                        general_progress_bar.Value = 20;
                        welcome_lb.Text = "Welcome, " + user.Name.Substring(0, user.Name.IndexOf(' '));

                        // set users repos
                        repositories = await GetUserReposAsync();
                        PopulateReposPanel(repositories);

                        empty_lb.Text = "Select repository from the list";
                        empty_lb.Location = new Point((this.Width - main_view.Width / 2) - empty_lb.Width / 2, (main_view.Height / 2) - empty_lb.Height / 2);
                        empty_lb.Show();
                    }
                    else
                    {
                        // log out
                        LogOut(null, null);
                        MessageBox.Show("Authentication failed. Please try to log in again.");
                    }
                    
                }
            }

            key.Close();
        }

        // function to populate panel, receives a list of repos to populate panel with
        private void PopulateReposPanel(List<Repository> repos_list)
        {
            repos_panel.Controls.Clear();

            general_progress_bar.Value = 30;
            repo_count_lb.Text = "Showing " + repos_list.Count + " repos";

            double increase = 70 / repos_list.Count;

            for (int i = 0; i < repos_list.Count; i++)
            {
                // this repo
                Repository this_repo = repos_list[i];

                RepositoryControl control = new RepositoryControl(this_repo);
                control.SetEvents(this);

                //// create event
                //// let it lead to lambda function that has only sender and e
                //// that lambda function will call our callback function
                //// this way we can pass extra arguments to event function
                //control.Label.Click += (sender, e) => Repo_Label_Click(sender, e, this_repo);

                //control.Label.MouseEnter += new EventHandler(Repo_Label_Mouse_Enter);
                //control.Label.MouseLeave += new EventHandler(Repo_Label_Mouse_Leave);

                // add to panel
                repos_panel.Controls.Add(control.Wrapper);

                general_progress_bar.Value += (int)increase;
            }

            general_progress_bar.Value = 100;
            general_progress_bar.Visible = false;

            // in case user reauthenticates
            // panel will hide on log out
            // and this is when it will show again
            window_panel.Show();
        }

        // populates commits panel
        public void PopulateCommitsPanel(List<GitHubCommit> commits)
        {
            commits_panel.Controls.Clear();
            foreach (GitHubCommit commit in commits)
            {
                // commit name
                CommitControl control = new CommitControl(commit);
                control.SetEvents(this);

                commits_panel.Controls.Add(control.Wrapper);
            }
        }


        #region ASYNC_METHODS

        // set global user that is authed
        private async Task<User> GetUserAsync()
        {
            return await client.User.Current();
        }

        // set all users repos list and populate panel safely
        private async Task<List<Repository>> GetUserReposAsync()
        {
            var repos = await client.Repository.GetAllForCurrent();
            return repos.ToList();
        }

        // get all commits
        public async Task<List<GitHubCommit>> getAllCommits()
        {
            var commits = await client.Repository.Commit.GetAll(current_repo.Id);

            List<GitHubCommit> commitList = new List<GitHubCommit>();

            foreach (GitHubCommit commit in commits)
            {
                var commitDetails = await client.Repository.Commit.Get(current_repo.Id, commit.Sha);
                commitList.Add(commitDetails);
            }

            return commitList;
        }

        #endregion

        #region LOG_IN_LOG_OUT

        // log in, open form
        private void ShowLogInForm(object sender, EventArgs e)
        {
            LogIn form = new LogIn(this);
            this.Hide();
            form.Show();
        }

        // log out, remove everything from registry and remove log out button
        private void LogOut(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\GithubManager", true);

            key.DeleteValue("username");
            key.DeleteValue("password");
            user = null;
            client = null;
            repositories.Clear();
            current_repo = null;

            empty_lb.Show();
            empty_lb.Text = "You are not logged in";
            empty_lb.Location = new Point(this.Width / 2 - empty_lb.Width/2, this.Height / 2 - empty_lb.Height / 2);

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
            log_in_item.Click += new EventHandler(ShowLogInForm);
            menu_strip.Items.Add(log_in_item);

            key.Close();
        }

        #endregion

        #region MAIN_VIEW_EVENTS

        // get link from hidden tb and open in default browser
        private void Repo_name_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(clone_url_tb.Text);
        }

        // open terminal in workin directory/repo name or just in working directory
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

        // copy clone url from hidden tb
        private void Copy_Clone_Url_Click(object sender, EventArgs e)
        {
            if(current_repo != null)
            {
                Clipboard.SetText(current_repo.CloneUrl);

                MessageBox.Show("URL copied to clipboard.");
            }
        }

        #endregion

        #region MENU_EVENTS

        // change bash.exe path
        private void ChangeBashPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeBashPathDialog.ShowDialog();

            if(changeBashPathDialog.FileName != null && changeBashPathDialog.FileName.Trim() != "" && changeBashPathDialog.FileName != "openFileDialog1")
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\GithubManager", true);

                key.SetValue("bash_path", changeBashPathDialog.FileName);

                key.Close();
            }
        }

        // change w dir path
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

        // show info about vars
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

        #endregion

        // search on input
        private void Search_tb_TextChanged(object sender, EventArgs e)
        {
            TextBox search_tb = sender as TextBox;
            if(search_tb.Text.Trim() == "")
            {
                PopulateReposPanel(repositories);
            }
            else
            {
                List<Repository> results = new List<Repository>();
                foreach(Repository repo in repositories)
                {
                    if (repo.FullName.Trim().ToLower().Contains(search_tb.Text.Trim().ToLower()))
                    {
                        results.Add(repo);
                    }
                }

                if(results.Count > 0)
                {
                    PopulateReposPanel(results);
                }
                else
                {
                    repos_panel.Controls.Clear();
                    System.Windows.Forms.Label lb = new System.Windows.Forms.Label();
                    lb.Text = "No results";
                    repos_panel.Controls.Add(lb);
                }
            }
        }
    }
}
