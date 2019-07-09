using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Octokit;

namespace github_management
{
    class RepositoryControl
    {
        private Repository Repo { get; set; }
        public Panel Wrapper { get; set; }
        public System.Windows.Forms.Label Label { get; set; }

        public RepositoryControl(Repository repo)
        {
            Repo = repo;
            Wrapper = new Panel();

            // create new label instance
            Label = new System.Windows.Forms.Label();
            Label.Text = repo.FullName;
            Label.AutoSize = true;

            Wrapper.Controls.Add(Label);

            Wrapper.Height = Label.Height;
        }

        public void SetEvents(Main form)
        {
            // create event
            // let it lead to lambda function that has only sender and e
            // that lambda function will call our callback function
            // this way we can pass extra arguments to event function
            Label.Click += (sender, e) => Repo_Label_Click(sender, e, Repo, form);

            Label.MouseEnter += (sender, e) => Repo_Label_Mouse_Enter(sender, e, form);
            Label.MouseLeave += (sender, e) => Repo_Label_Mouse_Leave(sender, e, form);
        }

        // on mouse enter, color the label
        protected void Repo_Label_Mouse_Enter(object sender, EventArgs e, Main form)
        {
            System.Windows.Forms.Label lb = sender as System.Windows.Forms.Label;
            form.Cursor = Cursors.Hand;
            lb.ForeColor = Color.DarkGreen;
        }

        // on mouse leave, make label dark again
        protected void Repo_Label_Mouse_Leave(object sender, EventArgs e, Main form)
        {
            System.Windows.Forms.Label lb = sender as System.Windows.Forms.Label;
            form.Cursor = Cursors.Default;
            lb.ForeColor = Color.Black;
        }

        // on label click, load the repo into view
        protected async void Repo_Label_Click(object sender, EventArgs e, Repository repo, Main form)
        {
            if (!form.repo_loading)
            {
                //attempt to cast the sender as a label
                System.Windows.Forms.Label lbl = sender as System.Windows.Forms.Label;

                //if the cast was successful (i.e. not null)
                if (lbl != null)
                {
                    form.repo_loading = true;
                    form.current_repo = repo;

                    form.empty_lb.Hide();

                    form.loading_panel.Visible = true;
                    form.loading_panel.BringToFront();

                    // set repo name
                    form.repo_name.Text = repo.FullName;

                    // set hidden textbox tetx to clone url
                    form.clone_url_tb.Text = repo.CloneUrl;

                    // set repo description
                    if (repo.Description != null)
                    {
                        form.repo_desc.Text = repo.Description;
                    }
                    else
                    {
                        form.repo_desc.Text = "No description";
                    }

                    // set commits
                    form.PopulateCommitsPanel(await form.getAllCommits());

                    form.loading_panel.Visible = false;
                    form.loading_panel.SendToBack();

                    form.main_view.Visible = true;

                    form.repo_loading = false;
                }
            }
        }


    }
}
