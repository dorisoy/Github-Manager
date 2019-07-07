namespace github_management
{
    partial class LogIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogIn));
            this.label1 = new System.Windows.Forms.Label();
            this.username_tb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.password_tb = new System.Windows.Forms.TextBox();
            this.log_in = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.password_err = new System.Windows.Forms.Label();
            this.username_err = new System.Windows.Forms.Label();
            this.login_err = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(96, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Log In To GitHub";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // username_tb
            // 
            this.username_tb.Location = new System.Drawing.Point(98, 126);
            this.username_tb.Name = "username_tb";
            this.username_tb.Size = new System.Drawing.Size(230, 20);
            this.username_tb.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(95, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Username:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(95, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password";
            // 
            // password_tb
            // 
            this.password_tb.Location = new System.Drawing.Point(98, 195);
            this.password_tb.Name = "password_tb";
            this.password_tb.PasswordChar = '*';
            this.password_tb.Size = new System.Drawing.Size(230, 20);
            this.password_tb.TabIndex = 3;
            // 
            // log_in
            // 
            this.log_in.Location = new System.Drawing.Point(98, 248);
            this.log_in.Name = "log_in";
            this.log_in.Size = new System.Drawing.Size(234, 23);
            this.log_in.TabIndex = 5;
            this.log_in.Text = "Log In";
            this.log_in.UseVisualStyleBackColor = true;
            this.log_in.Click += new System.EventHandler(this.Log_in_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(98, 312);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(237, 85);
            this.label4.TabIndex = 6;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(101, 401);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(187, 13);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://github.com/octokit/octokit.net";
            // 
            // password_err
            // 
            this.password_err.ForeColor = System.Drawing.Color.Red;
            this.password_err.Location = new System.Drawing.Point(98, 218);
            this.password_err.Name = "password_err";
            this.password_err.Size = new System.Drawing.Size(100, 23);
            this.password_err.TabIndex = 8;
            // 
            // username_err
            // 
            this.username_err.ForeColor = System.Drawing.Color.Red;
            this.username_err.Location = new System.Drawing.Point(98, 149);
            this.username_err.Name = "username_err";
            this.username_err.Size = new System.Drawing.Size(100, 23);
            this.username_err.TabIndex = 9;
            // 
            // login_err
            // 
            this.login_err.ForeColor = System.Drawing.Color.Red;
            this.login_err.Location = new System.Drawing.Point(98, 274);
            this.login_err.Name = "login_err";
            this.login_err.Size = new System.Drawing.Size(100, 23);
            this.login_err.TabIndex = 10;
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(429, 450);
            this.Controls.Add(this.login_err);
            this.Controls.Add(this.username_err);
            this.Controls.Add(this.password_err);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.log_in);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.password_tb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.username_tb);
            this.Controls.Add(this.label1);
            this.Name = "LogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LogIn";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LogIn_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox username_tb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox password_tb;
        private System.Windows.Forms.Button log_in;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label password_err;
        private System.Windows.Forms.Label username_err;
        private System.Windows.Forms.Label login_err;
    }
}