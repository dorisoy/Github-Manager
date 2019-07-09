using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octokit;
using System.Windows.Forms;
using System.Drawing;

namespace github_management
{
    class CommitControl
    {
        private GitHubCommit Commit { get; set; }
        public Panel Wrapper { get; set; }
        public System.Windows.Forms.Label HeaderLabel { get; set; }
        System.Windows.Forms.Label InsertionsCountLabel { get; set; }
        System.Windows.Forms.Label DeletionsCountLabel { get; set; }

        public CommitControl(GitHubCommit commit)
        {
            Commit = commit;
            Wrapper = new Panel();
            Wrapper.AutoSize = true;
            Wrapper.Margin = new Padding(0, 0, 0, 15);

            // create new label instance
            HeaderLabel = new System.Windows.Forms.Label();
            HeaderLabel.AutoSize = true;
            HeaderLabel.Text = commit.Commit.Message.Replace('\n'.ToString(), "");
            HeaderLabel.Font = new Font(new FontFamily(System.Drawing.Text.GenericFontFamilies.Serif), 12, FontStyle.Bold);
            Wrapper.Controls.Add(HeaderLabel);

            // insertions and deletitions labels
            InsertionsCountLabel = new System.Windows.Forms.Label();
            InsertionsCountLabel.AutoSize = true;
            InsertionsCountLabel.ForeColor = Color.DarkGreen;
            InsertionsCountLabel.Text = "+" + commit.Stats.Additions.ToString();
            InsertionsCountLabel.Location = new Point(0, HeaderLabel.Height);
            Wrapper.Controls.Add(InsertionsCountLabel);

            DeletionsCountLabel = new System.Windows.Forms.Label();
            DeletionsCountLabel.AutoSize = true;
            DeletionsCountLabel.ForeColor = Color.DarkRed;
            DeletionsCountLabel.Text = "-" + commit.Stats.Deletions.ToString();
            DeletionsCountLabel.Location = new Point(0, HeaderLabel.Height + InsertionsCountLabel.Height);
            Wrapper.Controls.Add(DeletionsCountLabel);
        }

        public void SetEvents(Main form)
        {
            HeaderLabel.Click += (sender, e) => HeaderLabel_Click(sender, e, Commit);
            HeaderLabel.MouseEnter += (sender, e) => HeaderLabel_MouseEnter(sender, e, form);
            HeaderLabel.MouseLeave += (sender, e) => HeaderLabel_MouseLeave(sender, e, form);
        }

        protected void HeaderLabel_Click(object sender, EventArgs e, GitHubCommit commit)
        {
            CommitInfoForm cif = new CommitInfoForm(commit);
            cif.Show();
        }

        protected void HeaderLabel_MouseEnter(object sender, EventArgs e, Main form)
        {
            form.Cursor = Cursors.Hand;
            HeaderLabel.ForeColor = Color.DarkGreen;
        }

        protected void HeaderLabel_MouseLeave(object sender, EventArgs e, Main form)
        {
            form.Cursor = Cursors.Default;
            HeaderLabel.ForeColor = Color.Black;
        }
    }
}
