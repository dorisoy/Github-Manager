using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

            commit_message.Text = Commit.Commit.Message;

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
                wrapper.Controls.Add(file_name);

                System.Windows.Forms.Label status_lb = new System.Windows.Forms.Label();
                status_lb.AutoSize = true;
                status_lb.Text = file.Status;
                status_lb.Location = new Point(0, wrapper.Controls.Count * status_lb.Height);
                wrapper.Controls.Add(status_lb);

                wrapper.Margin = new Padding(0, 0, 0, 20);

                files_panel.Controls.Add(wrapper);
            }
        }
    }
}
