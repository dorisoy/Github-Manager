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
            this.repo_name = new System.Windows.Forms.Label();
            this.repo_desc = new System.Windows.Forms.Label();
            this.menu_strip = new System.Windows.Forms.MenuStrip();
            this.window_panel = new System.Windows.Forms.Panel();
            this.window_panel.SuspendLayout();
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
            this.empty_lb.Location = new System.Drawing.Point(348, 214);
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
            this.repos_panel.Location = new System.Drawing.Point(18, 29);
            this.repos_panel.Name = "repos_panel";
            this.repos_panel.Size = new System.Drawing.Size(200, 398);
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
            // repo_name
            // 
            this.repo_name.AutoSize = true;
            this.repo_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repo_name.Location = new System.Drawing.Point(259, 29);
            this.repo_name.Name = "repo_name";
            this.repo_name.Size = new System.Drawing.Size(0, 20);
            this.repo_name.TabIndex = 0;
            // 
            // repo_desc
            // 
            this.repo_desc.AutoSize = true;
            this.repo_desc.Location = new System.Drawing.Point(260, 49);
            this.repo_desc.Name = "repo_desc";
            this.repo_desc.Size = new System.Drawing.Size(0, 13);
            this.repo_desc.TabIndex = 5;
            // 
            // menu_strip
            // 
            this.menu_strip.Location = new System.Drawing.Point(0, 0);
            this.menu_strip.Name = "menu_strip";
            this.menu_strip.Size = new System.Drawing.Size(800, 24);
            this.menu_strip.TabIndex = 6;
            this.menu_strip.Text = "menuStrip1";
            // 
            // window_panel
            // 
            this.window_panel.Controls.Add(this.repo_desc);
            this.window_panel.Controls.Add(this.repos_panel);
            this.window_panel.Controls.Add(this.repo_name);
            this.window_panel.Controls.Add(this.repo_count_lb);
            this.window_panel.Controls.Add(this.empty_lb);
            this.window_panel.Controls.Add(this.welcome_lb);
            this.window_panel.Location = new System.Drawing.Point(12, 29);
            this.window_panel.Name = "window_panel";
            this.window_panel.Size = new System.Drawing.Size(776, 454);
            this.window_panel.TabIndex = 7;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 495);
            this.Controls.Add(this.menu_strip);
            this.Controls.Add(this.window_panel);
            this.MainMenuStrip = this.menu_strip;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage repository updates";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Shown += new System.EventHandler(this.Main_Shown);
            this.window_panel.ResumeLayout(false);
            this.window_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label welcome_lb;
        private System.Windows.Forms.Label empty_lb;
        private System.Windows.Forms.FlowLayoutPanel repos_panel;
        private System.Windows.Forms.Label repo_count_lb;
        private System.Windows.Forms.Label repo_name;
        private System.Windows.Forms.Label repo_desc;
        private System.Windows.Forms.MenuStrip menu_strip;
        private System.Windows.Forms.Panel window_panel;
    }
}

