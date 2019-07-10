using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Octokit;

namespace github_management
{
    public partial class CommitInfoForm : Form
    {
        private GitHubCommit Commit { get; set; }

        public CommitInfoForm(GitHubCommit commit)
        {
            Commit = commit;
            InitializeComponent();
        }

        private void CommitInfoForm_Load(object sender, EventArgs e)
        {
            this.Icon = new Icon(@"GitHub-Mark/github_mark_120px_plus_Bzz_icon.ico");

            if (Commit.Commit.Message.IndexOf('\n') > -1)
            {
                Text = Commit.Commit.Message.Substring(0, Commit.Commit.Message.IndexOf('\n'));
                commit_desc.Text = Commit.Commit.Message.Substring(Commit.Commit.Message.IndexOf('\n') + 2);
            }
            else
            {
                Text = Commit.Commit.Message;
                commit_desc.Hide();
            }

            IReadOnlyList<GitHubCommitFile> files = Commit.Files;

            for(int i = 0; i < files.Count; i++)
            {
                GitHubCommitFile file = files[i];

                Panel wrapper = new Panel();
                wrapper.AutoSize = true;

                System.Windows.Forms.Label file_name = new System.Windows.Forms.Label();
                file_name.AutoSize = true;
                file_name.Font = new Font(new FontFamily(System.Drawing.Text.GenericFontFamilies.Serif), 12, FontStyle.Bold);
                file_name.Text = file.Filename;
                file_name.Click += (event_sender, event_args) => FileName_Click(event_sender, event_args, file);
                file_name.MouseEnter += (event_sender, event_args) =>
                {
                    Cursor = Cursors.Hand;
                    file_name.ForeColor = Color.DarkGreen;
                };
                file_name.MouseLeave += (event_sender, event_args) =>
                {
                    Cursor = Cursors.Default;
                    file_name.ForeColor = Color.Black;
                };
                wrapper.Controls.Add(file_name);

                System.Windows.Forms.Label status_lb = new System.Windows.Forms.Label();
                status_lb.AutoSize = true;
                status_lb.Text = file.Status;
                if (file.Status == "modified")
                {
                    status_lb.ForeColor = Color.DarkOrange;
                }
                else if(file.Status == "added")
                {
                    status_lb.ForeColor = Color.DarkGreen;
                }
                else if (file.Status == "removed")
                {
                    status_lb.ForeColor = Color.DarkRed;
                }

                status_lb.Location = new Point(0, wrapper.Controls.Count * status_lb.Height);
                wrapper.Controls.Add(status_lb);

                wrapper.Margin = new Padding(0, 0, 0, 20);

                files_panel.Controls.Add(wrapper);
            }
        }

        private void FileName_Click(object event_sender, EventArgs event_args, GitHubCommitFile file)
        {
            save_file_dialog.ShowDialog();
            string save_to = null;

            if (save_file_dialog.SelectedPath != null && save_file_dialog.SelectedPath.Trim() != "")
            {
                save_to = save_file_dialog.SelectedPath;
                using (WebClient wc = new WebClient())
                {
                    wc.Headers.Add("user-agent", "personal-gh-management-app");
                    wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                    wc.DownloadFileCompleted += wc_DownloadFileCompleted;
                    wc.DownloadFileAsync(
                        new Uri(file.RawUrl),
                        save_to + "/" + file.Filename.Substring(file.Filename.LastIndexOf('/'))
                    );
                }
            }
        }

        private void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            file_downloaded_progress.Value = 0;
            MessageBox.Show("File downloaded");
        }

        private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            file_downloaded_progress.Value = e.ProgressPercentage;
        }
    }
}
