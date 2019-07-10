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
            this.commit_message = new System.Windows.Forms.Label();
            this.files_panel = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.commit_desc = new System.Windows.Forms.TextBox();
            this.file_downloaded_progress = new System.Windows.Forms.ProgressBar();
            this.save_file_dialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // commit_message
            // 
            this.commit_message.AutoSize = true;
            this.commit_message.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commit_message.Location = new System.Drawing.Point(12, 9);
            this.commit_message.Name = "commit_message";
            this.commit_message.Size = new System.Drawing.Size(109, 24);
            this.commit_message.TabIndex = 0;
            this.commit_message.Text = "Commit Info";
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
            // CommitInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.file_downloaded_progress);
            this.Controls.Add(this.commit_desc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.files_panel);
            this.Controls.Add(this.commit_message);
            this.Name = "CommitInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Commit Information";
            this.Load += new System.EventHandler(this.CommitInfoForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label commit_message;
        private System.Windows.Forms.FlowLayoutPanel files_panel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox commit_desc;
        private System.Windows.Forms.ProgressBar file_downloaded_progress;
        private System.Windows.Forms.FolderBrowserDialog save_file_dialog;
    }
}