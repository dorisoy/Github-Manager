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
using System.Threading;
using System.IO;

namespace github_management
{
    public partial class CommitInfoForm : Form
    {
        private GitHubCommit Commit { get; set; }

        private IReadOnlyList<GitHubCommitFile> Files { get; set; }

        public CommitInfoForm(GitHubCommit commit)
        {
            Commit = commit;
            InitializeComponent();
        }

        private void CommitInfoForm_Load(object sender, EventArgs e)
        {
            // set icon
            this.Icon = new Icon(@"GitHub-Mark/github_mark_120px_plus_Bzz_icon.ico");

            // happens when commit message has description also and everything gets merged into one string
            // text is all up to \n\n
            // desc is from there
            // separate those two
            if (Commit.Commit.Message.IndexOf('\n') > -1)
            {
                Text = Commit.Commit.Message.Substring(0, Commit.Commit.Message.IndexOf('\n'));
                commit_desc.Text = Commit.Commit.Message.Substring(Commit.Commit.Message.IndexOf('\n') + 2);
            }
            else
            {
                // if there is no commit desc, just commit message
                Text = Commit.Commit.Message;

                // hide desc box as not needed
                commit_desc.Hide();
            }

            commit_sha.Text = Commit.Sha;

            // set files to files from this commit
            Files = Commit.Files;

            // write file count label out
            files_count.Text = "Showing " + Files.Count + " files";

            // go through files
            for(int i = 0; i < Files.Count; i++)
            {
                // get current file
                GitHubCommitFile file = Files[i];

                // create wrapper
                Panel wrapper = new Panel();
                wrapper.AutoSize = true;

                // create label to show file name and add events to it
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
                // add label to wrapper
                wrapper.Controls.Add(file_name);

                // create label about file status
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
                // add label to wrapper
                wrapper.Controls.Add(status_lb);

                // set wrapper's bottom margin to 20
                wrapper.Margin = new Padding(0, 0, 0, 20);

                // add wraper to files panel
                files_panel.Controls.Add(wrapper);
            }
        }

        private void FileName_Click(object event_sender, EventArgs event_args, GitHubCommitFile file)
        {
            // open folder open dialog
            save_file_dialog.ShowDialog();
            string save_to = null;

            if (save_file_dialog.SelectedPath != null && save_file_dialog.SelectedPath.Trim() != "")
            {
                // if folder picked, download to that folder
                save_to = save_file_dialog.SelectedPath;
                DownloadFile(file, save_to + "/");
            }
        }

        private void DownloadFile(GitHubCommitFile file, string save_to)
        {
            // create all folders in this file names path
            string[] folders = file.Filename.Split('/');
            string root = save_to;
            for (int i = 0; i < folders.Length - 1; i++)
            {
                if (!Directory.Exists(root + folders[i]))
                {
                    Directory.CreateDirectory(root + folders[i]);
                }
                root += "/" + folders[i] + "/";
            }

            // download
            using (WebClient wc = new WebClient())
            {
                wc.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2");
                wc.Headers.Add("keep-alive", "timeout=5");
                wc.Headers.Add(HttpRequestHeader.Authorization, "token="); // oAuth token goes here
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileCompleted += wc_DownloadFileCompleted;

                string path = save_to + file.Filename;

                wc.DownloadFileAsync(new Uri(file.RawUrl), path);
            }
        }

        private void DownloadAll(string alt_folder = "")
        {
            // remove temp folder for this commit if any
            RemoveTemp();

            // create new folder
            string dir_path;
            if (alt_folder.Trim() == "")
            {
                dir_path = Path.GetTempPath() + Commit.Sha;
            }
            else
            {
                dir_path = alt_folder + "/Commit-" + Commit.Sha;
            }
            Directory.CreateDirectory(dir_path);

            // for each file in files
            for (int i = 0; i < Files.Count; i++)
            {
                // get file
                GitHubCommitFile file = Files[i];

                // construct path to this commit
                string path = dir_path + "/";

                // download to commit folder
                DownloadFile(file, path);
            }

            MessageBox.Show("All files should be downloaded or are in queue to be downloaded");
        }

        private void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            // when files is finished downloading
            file_downloaded_progress.Value = 0;

            // start new thread to show "File downloaded" in status bar and remove it after 3sec
            Thread set_lb = new Thread(new ThreadStart(setLbAfterDownload));
            set_lb.Start();
            
        }

        private void setLbAfterDownload()
        {
            // set text
            download_status_lb.Text = "File downloaded";

            // wait 3 sec to remove
            // this will not block UI thread as it is run on another thread
            Thread.Sleep(3000);

            // remove text after sleep
            download_status_lb.Text = "";
        }

        private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // report progress on file download to progress bar
            file_downloaded_progress.Value = e.ProgressPercentage;
        }

        private void Download_all_files_Click(object sender, EventArgs e)
        {
            save_all_folder_dialog.ShowDialog();

            if (save_all_folder_dialog.SelectedPath != null && save_all_folder_dialog.SelectedPath.Trim() != "")
            {
                DownloadAll(save_all_folder_dialog.SelectedPath);
            }
        }

        private void CommitInfoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // when form is closing, clear out temp folder
            RemoveTemp();
        }

        private void RemoveTemp()
        {
            // remove temp directory if any
            string dir_path = Path.GetTempPath() + Commit.Sha;
            if (Directory.Exists(dir_path))
            {
                Directory.Delete(dir_path, true);
            }
        }

        private void Update_ftp_Click(object sender, EventArgs e)
        {
            // download all files from this commit to TEMP
            DownloadAll();

            // create ftp client
            FTPClient ftp = new FTPClient("1.1.1.1", "username", "password");

            // update files
            ftp.UpdateFiles(Commit, new DirectoryInfo(Path.GetTempPath() + Commit.Sha));

            MessageBox.Show("Done");
        }
    }
}
