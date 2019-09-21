namespace github_management
{
    partial class CommitInfoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.commit_sha = new System.Windows.Forms.Label();
            this.files_panel = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.commit_desc = new System.Windows.Forms.TextBox();
            this.file_downloaded_progress = new System.Windows.Forms.ProgressBar();
            this.save_file_dialog = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.download_status_lb = new System.Windows.Forms.ToolStripStatusLabel();
            this.download_all_files = new System.Windows.Forms.Button();
            this.files_count = new System.Windows.Forms.Label();
            this.update_ftp = new System.Windows.Forms.Button();
            this.save_all_folder_dialog = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // commit_sha
            // 
            this.commit_sha.AutoSize = true;
            this.commit_sha.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commit_sha.Location = new System.Drawing.Point(12, 9);
            this.commit_sha.Name = "commit_sha";
            this.commit_sha.Size = new System.Drawing.Size(109, 24);
            this.commit_sha.TabIndex = 0;
            this.commit_sha.Text = "Commit Info";
            // 
            // files_panel
            // 
            this.files_panel.AutoScroll = true;
            this.files_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.files_panel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.files_panel.Location = new System.Drawing.Point(16, 60);
            this.files_panel.Name = "files_panel";
            this.files_panel.Size = new System.Drawing.Size(395, 378);
            this.files_panel.TabIndex = 1;
            this.files_panel.WrapContents = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Files:";
            // 
            // commit_desc
            // 
            this.commit_desc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.commit_desc.Location = new System.Drawing.Point(434, 60);
            this.commit_desc.MaximumSize = new System.Drawing.Size(354, 378);
            this.commit_desc.Multiline = true;
            this.commit_desc.Name = "commit_desc";
            this.commit_desc.ReadOnly = true;
            this.commit_desc.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.commit_desc.Size = new System.Drawing.Size(354, 378);
            this.commit_desc.TabIndex = 2;
            // 
            // file_downloaded_progress
            // 
            this.file_downloaded_progress.Location = new System.Drawing.Point(434, 12);
            this.file_downloaded_progress.Name = "file_downloaded_progress";
            this.file_downloaded_progress.Size = new System.Drawing.Size(354, 23);
            this.file_downloaded_progress.TabIndex = 4;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.download_status_lb});
            this.statusStrip1.Location = new System.Drawing.Point(0, 503);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // download_status_lb
            // 
            this.download_status_lb.BackColor = System.Drawing.Color.Transparent;
            this.download_status_lb.Name = "download_status_lb";
            this.download_status_lb.Size = new System.Drawing.Size(0, 17);
            // 
            // download_all_files
            // 
            this.download_all_files.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.download_all_files.Location = new System.Drawing.Point(16, 467);
            this.download_all_files.Name = "download_all_files";
            this.download_all_files.Size = new System.Drawing.Size(158, 23);
            this.download_all_files.TabIndex = 9;
            this.download_all_files.Text = "Download files";
            this.download_all_files.UseVisualStyleBackColor = true;
            this.download_all_files.Click += new System.EventHandler(this.Download_all_files_Click);
            // 
            // files_count
            // 
            this.files_count.AutoSize = true;
            this.files_count.Location = new System.Drawing.Point(13, 441);
            this.files_count.Name = "files_count";
            this.files_count.Size = new System.Drawing.Size(35, 13);
            this.files_count.TabIndex = 10;
            this.files_count.Text = "label2";
            // 
            // update_ftp
            // 
            this.update_ftp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.update_ftp.Location = new System.Drawing.Point(180, 467);
            this.update_ftp.Name = "update_ftp";
            this.update_ftp.Size = new System.Drawing.Size(158, 23);
            this.update_ftp.TabIndex = 11;
            this.update_ftp.Text = "Update through FTP";
            this.update_ftp.UseVisualStyleBackColor = true;
            this.update_ftp.Click += new System.EventHandler(this.Update_ftp_Click);
            // 
            // CommitInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 525);
            this.Controls.Add(this.update_ftp);
            this.Controls.Add(this.files_count);
            this.Controls.Add(this.download_all_files);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.file_downloaded_progress);
            this.Controls.Add(this.commit_desc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.files_panel);
            this.Controls.Add(this.commit_sha);
            this.Name = "CommitInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Commit Information";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CommitInfoForm_FormClosed);
            this.Load += new System.EventHandler(this.CommitInfoForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label commit_sha;
        private System.Windows.Forms.FlowLayoutPanel files_panel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox commit_desc;
        private System.Windows.Forms.ProgressBar file_downloaded_progress;
        private System.Windows.Forms.FolderBrowserDialog save_file_dialog;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel download_status_lb;
        public System.Windows.Forms.Button download_all_files;
        private System.Windows.Forms.Label files_count;
        public System.Windows.Forms.Button update_ftp;
        private System.Windows.Forms.FolderBrowserDialog save_all_folder_dialog;
    }
}