namespace github_management
{
    partial class Main
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
            this.welcome_lb = new System.Windows.Forms.Label();
            this.empty_lb = new System.Windows.Forms.Label();
            this.repos_panel = new System.Windows.Forms.FlowLayoutPanel();
            this.repo_count_lb = new System.Windows.Forms.Label();
            this.repo_desc = new System.Windows.Forms.Label();
            this.menu_strip = new System.Windows.Forms.MenuStrip();
            this.changeBashPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeWorkingDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.window_panel = new System.Windows.Forms.Panel();
            this.search_tb = new System.Windows.Forms.TextBox();
            this.main_view = new System.Windows.Forms.Panel();
            this.commits_panel = new System.Windows.Forms.FlowLayoutPanel();
            this.repo_name = new System.Windows.Forms.LinkLabel();
            this.clone_url_tb = new System.Windows.Forms.TextBox();
            this.copy_clone_url = new System.Windows.Forms.Button();
            this.open_terminal = new System.Windows.Forms.Button();
            this.loading_panel = new System.Windows.Forms.Panel();
            this.loading_lb = new System.Windows.Forms.Label();
            this.changeBashPathDialog = new System.Windows.Forms.OpenFileDialog();
            this.changeWorkingDirectoryDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.general_progress_bar = new System.Windows.Forms.ToolStripProgressBar();
            this.menu_strip.SuspendLayout();
            this.window_panel.SuspendLayout();
            this.main_view.SuspendLayout();
            this.loading_panel.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // welcome_lb
            // 
            this.welcome_lb.AutoSize = true;
            this.welcome_lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcome_lb.Location = new System.Drawing.Point(15, 9);
            this.welcome_lb.Name = "welcome_lb";
            this.welcome_lb.Size = new System.Drawing.Size(66, 17);
            this.welcome_lb.TabIndex = 0;
            this.welcome_lb.Text = "Welcome";
            // 
            // empty_lb
            // 
            this.empty_lb.AutoSize = true;
            this.empty_lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.empty_lb.Location = new System.Drawing.Point(340, 244);
            this.empty_lb.Name = "empty_lb";
            this.empty_lb.Size = new System.Drawing.Size(362, 26);
            this.empty_lb.TabIndex = 3;
            this.empty_lb.Text = "Please select repository from the list";
            // 
            // repos_panel
            // 
            this.repos_panel.AutoScroll = true;
            this.repos_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.repos_panel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.repos_panel.Location = new System.Drawing.Point(18, 56);
            this.repos_panel.Name = "repos_panel";
            this.repos_panel.Size = new System.Drawing.Size(200, 371);
            this.repos_panel.TabIndex = 4;
            this.repos_panel.WrapContents = false;
            // 
            // repo_count_lb
            // 
            this.repo_count_lb.AutoSize = true;
            this.repo_count_lb.Location = new System.Drawing.Point(15, 430);
            this.repo_count_lb.Name = "repo_count_lb";
            this.repo_count_lb.Size = new System.Drawing.Size(35, 13);
            this.repo_count_lb.TabIndex = 0;
            this.repo_count_lb.Text = "label1";
            // 
            // repo_desc
            // 
            this.repo_desc.Location = new System.Drawing.Point(19, 42);
            this.repo_desc.MinimumSize = new System.Drawing.Size(500, 0);
            this.repo_desc.Name = "repo_desc";
            this.repo_desc.Size = new System.Drawing.Size(500, 13);
            this.repo_desc.TabIndex = 5;
            this.repo_desc.Text = "Repository description";
            // 
            // menu_strip
            // 
            this.menu_strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeBashPathToolStripMenuItem,
            this.changeWorkingDirectoryToolStripMenuItem,
            this.showInfoToolStripMenuItem});
            this.menu_strip.Location = new System.Drawing.Point(0, 0);
            this.menu_strip.Name = "menu_strip";
            this.menu_strip.Size = new System.Drawing.Size(800, 24);
            this.menu_strip.TabIndex = 6;
            this.menu_strip.Text = "menuStrip1";
            // 
            // changeBashPathToolStripMenuItem
            // 
            this.changeBashPathToolStripMenuItem.Name = "changeBashPathToolStripMenuItem";
            this.changeBashPathToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.changeBashPathToolStripMenuItem.Text = "Change bash path";
            this.changeBashPathToolStripMenuItem.Click += new System.EventHandler(this.ChangeBashPathToolStripMenuItem_Click);
            // 
            // changeWorkingDirectoryToolStripMenuItem
            // 
            this.changeWorkingDirectoryToolStripMenuItem.Name = "changeWorkingDirectoryToolStripMenuItem";
            this.changeWorkingDirectoryToolStripMenuItem.Size = new System.Drawing.Size(156, 20);
            this.changeWorkingDirectoryToolStripMenuItem.Text = "Change working directory";
            this.changeWorkingDirectoryToolStripMenuItem.Click += new System.EventHandler(this.ChangeWorkingDirectoryToolStripMenuItem_Click);
            // 
            // showInfoToolStripMenuItem
            // 
            this.showInfoToolStripMenuItem.Name = "showInfoToolStripMenuItem";
            this.showInfoToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.showInfoToolStripMenuItem.Text = "Show Info";
            this.showInfoToolStripMenuItem.Click += new System.EventHandler(this.ShowInfoToolStripMenuItem_Click);
            // 
            // window_panel
            // 
            this.window_panel.Controls.Add(this.search_tb);
            this.window_panel.Controls.Add(this.repos_panel);
            this.window_panel.Controls.Add(this.repo_count_lb);
            this.window_panel.Controls.Add(this.welcome_lb);
            this.window_panel.Controls.Add(this.main_view);
            this.window_panel.Controls.Add(this.loading_panel);
            this.window_panel.Location = new System.Drawing.Point(12, 29);
            this.window_panel.Name = "window_panel";
            this.window_panel.Size = new System.Drawing.Size(776, 454);
            this.window_panel.TabIndex = 7;
            // 
            // search_tb
            // 
            this.search_tb.Location = new System.Drawing.Point(18, 30);
            this.search_tb.Name = "search_tb";
            this.search_tb.Size = new System.Drawing.Size(200, 20);
            this.search_tb.TabIndex = 11;
            this.search_tb.TextChanged += new System.EventHandler(this.Search_tb_TextChanged);
            // 
            // main_view
            // 
            this.main_view.Controls.Add(this.repo_desc);
            this.main_view.Controls.Add(this.commits_panel);
            this.main_view.Controls.Add(this.repo_name);
            this.main_view.Controls.Add(this.clone_url_tb);
            this.main_view.Controls.Add(this.copy_clone_url);
            this.main_view.Controls.Add(this.open_terminal);
            this.main_view.Location = new System.Drawing.Point(229, 14);
            this.main_view.Name = "main_view";
            this.main_view.Size = new System.Drawing.Size(544, 437);
            this.main_view.TabIndex = 13;
            this.main_view.Visible = false;
            // 
            // commits_panel
            // 
            this.commits_panel.AutoScroll = true;
            this.commits_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.commits_panel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.commits_panel.Location = new System.Drawing.Point(22, 97);
            this.commits_panel.Name = "commits_panel";
            this.commits_panel.Size = new System.Drawing.Size(480, 308);
            this.commits_panel.TabIndex = 9;
            this.commits_panel.WrapContents = false;
            // 
            // repo_name
            // 
            this.repo_name.AutoSize = true;
            this.repo_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repo_name.Location = new System.Drawing.Point(19, 15);
            this.repo_name.Name = "repo_name";
            this.repo_name.Size = new System.Drawing.Size(121, 18);
            this.repo_name.TabIndex = 7;
            this.repo_name.TabStop = true;
            this.repo_name.Text = "Repository name";
            this.repo_name.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Repo_name_LinkClicked);
            // 
            // clone_url_tb
            // 
            this.clone_url_tb.Location = new System.Drawing.Point(22, 58);
            this.clone_url_tb.Name = "clone_url_tb";
            this.clone_url_tb.Size = new System.Drawing.Size(100, 20);
            this.clone_url_tb.TabIndex = 10;
            this.clone_url_tb.Visible = false;
            // 
            // copy_clone_url
            // 
            this.copy_clone_url.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copy_clone_url.Location = new System.Drawing.Point(441, 411);
            this.copy_clone_url.Name = "copy_clone_url";
            this.copy_clone_url.Size = new System.Drawing.Size(94, 23);
            this.copy_clone_url.TabIndex = 8;
            this.copy_clone_url.Text = "Get clone URL";
            this.copy_clone_url.UseVisualStyleBackColor = true;
            this.copy_clone_url.Click += new System.EventHandler(this.Copy_Clone_Url_Click);
            // 
            // open_terminal
            // 
            this.open_terminal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.open_terminal.Location = new System.Drawing.Point(341, 411);
            this.open_terminal.Name = "open_terminal";
            this.open_terminal.Size = new System.Drawing.Size(94, 23);
            this.open_terminal.TabIndex = 9;
            this.open_terminal.Text = "Open terminal";
            this.open_terminal.UseVisualStyleBackColor = true;
            this.open_terminal.Click += new System.EventHandler(this.Open_terminal_Click);
            // 
            // loading_panel
            // 
            this.loading_panel.Controls.Add(this.loading_lb);
            this.loading_panel.Location = new System.Drawing.Point(232, 17);
            this.loading_panel.Name = "loading_panel";
            this.loading_panel.Size = new System.Drawing.Size(544, 434);
            this.loading_panel.TabIndex = 12;
            this.loading_panel.Visible = false;
            // 
            // loading_lb
            // 
            this.loading_lb.AutoSize = true;
            this.loading_lb.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loading_lb.Location = new System.Drawing.Point(190, 187);
            this.loading_lb.Name = "loading_lb";
            this.loading_lb.Size = new System.Drawing.Size(166, 39);
            this.loading_lb.TabIndex = 0;
            this.loading_lb.Text = "Loading...";
            // 
            // changeBashPathDialog
            // 
            this.changeBashPathDialog.FileName = "openFileDialog1";
            this.changeBashPathDialog.Filter = "Git Bash Exe|bash.exe";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.general_progress_bar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 491);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(317, 17);
            this.toolStripStatusLabel1.Text = "This project utilizes GitHub API along with Octokit package";
            // 
            // general_progress_bar
            // 
            this.general_progress_bar.Name = "general_progress_bar";
            this.general_progress_bar.Size = new System.Drawing.Size(100, 16);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 513);
            this.Controls.Add(this.empty_lb);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menu_strip);
            this.Controls.Add(this.window_panel);
            this.MainMenuStrip = this.menu_strip;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage repository updates";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Shown += new System.EventHandler(this.Main_Shown);
            this.menu_strip.ResumeLayout(false);
            this.menu_strip.PerformLayout();
            this.window_panel.ResumeLayout(false);
            this.window_panel.PerformLayout();
            this.main_view.ResumeLayout(false);
            this.main_view.PerformLayout();
            this.loading_panel.ResumeLayout(false);
            this.loading_panel.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label welcome_lb;
        private System.Windows.Forms.FlowLayoutPanel repos_panel;
        private System.Windows.Forms.Label repo_count_lb;
        private System.Windows.Forms.MenuStrip menu_strip;
        private System.Windows.Forms.Panel window_panel;
        private System.Windows.Forms.ToolStripMenuItem changeBashPathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeWorkingDirectoryToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog changeBashPathDialog;
        private System.Windows.Forms.FolderBrowserDialog changeWorkingDirectoryDialog;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar general_progress_bar;
        private System.Windows.Forms.ToolStripMenuItem showInfoToolStripMenuItem;
        private System.Windows.Forms.TextBox search_tb;
        private System.Windows.Forms.Label loading_lb;
        public System.Windows.Forms.Label empty_lb;
        public System.Windows.Forms.Label repo_desc;
        public System.Windows.Forms.LinkLabel repo_name;
        public System.Windows.Forms.Button copy_clone_url;
        public System.Windows.Forms.Button open_terminal;
        public System.Windows.Forms.TextBox clone_url_tb;
        public System.Windows.Forms.FlowLayoutPanel commits_panel;
        public System.Windows.Forms.Panel loading_panel;
        public System.Windows.Forms.Panel main_view;
    }
}

