namespace DB_NTCF_C
{
    partial class Login
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
            this.shop = new System.Windows.Forms.Label();
            this.pass_text = new System.Windows.Forms.TextBox();
            this.username_text = new System.Windows.Forms.TextBox();
            this.close = new System.Windows.Forms.Button();
            this.Login_but = new System.Windows.Forms.Button();
            this.showpass = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // shop
            // 
            this.shop.AutoSize = true;
            this.shop.BackColor = System.Drawing.Color.Gainsboro;
            this.shop.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shop.Location = new System.Drawing.Point(89, 38);
            this.shop.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.shop.Name = "shop";
            this.shop.Size = new System.Drawing.Size(172, 31);
            this.shop.TabIndex = 10;
            this.shop.Text = "NTCF SHOP";
            // 
            // pass_text
            // 
            this.pass_text.ForeColor = System.Drawing.Color.Gray;
            this.pass_text.Location = new System.Drawing.Point(35, 124);
            this.pass_text.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pass_text.Name = "pass_text";
            this.pass_text.Size = new System.Drawing.Size(285, 22);
            this.pass_text.TabIndex = 2;
            this.pass_text.Text = "Password";
            this.pass_text.Click += new System.EventHandler(this.pass_text_Click);
            this.pass_text.Enter += new System.EventHandler(this.pass_text_Click);
            this.pass_text.Leave += new System.EventHandler(this.pass_text_Leave);
            // 
            // username_text
            // 
            this.username_text.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.username_text.ForeColor = System.Drawing.Color.Black;
            this.username_text.Location = new System.Drawing.Point(35, 92);
            this.username_text.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.username_text.Name = "username_text";
            this.username_text.Size = new System.Drawing.Size(285, 22);
            this.username_text.TabIndex = 1;
            this.username_text.Text = "username";
            this.username_text.Click += new System.EventHandler(this.username_text_Click);
            this.username_text.Enter += new System.EventHandler(this.username_text_Click);
            this.username_text.Leave += new System.EventHandler(this.username_text_Leave);
            // 
            // close
            // 
            this.close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.close.Location = new System.Drawing.Point(221, 190);
            this.close.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(100, 28);
            this.close.TabIndex = 5;
            this.close.Text = "Close";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // Login_but
            // 
            this.Login_but.Location = new System.Drawing.Point(35, 190);
            this.Login_but.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Login_but.Name = "Login_but";
            this.Login_but.Size = new System.Drawing.Size(100, 28);
            this.Login_but.TabIndex = 4;
            this.Login_but.Text = "Login";
            this.Login_but.UseVisualStyleBackColor = true;
            this.Login_but.Click += new System.EventHandler(this.LOgin_but_Click);
            // 
            // showpass
            // 
            this.showpass.Location = new System.Drawing.Point(221, 156);
            this.showpass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.showpass.Name = "showpass";
            this.showpass.Size = new System.Drawing.Size(100, 28);
            this.showpass.TabIndex = 5;
            this.showpass.TabStop = false;
            this.showpass.Text = "Showpass";
            this.showpass.UseVisualStyleBackColor = true;
            this.showpass.Click += new System.EventHandler(this.showpass_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.shop);
            this.groupBox1.Controls.Add(this.Login_but);
            this.groupBox1.Controls.Add(this.close);
            this.groupBox1.Controls.Add(this.showpass);
            this.groupBox1.Controls.Add(this.username_text);
            this.groupBox1.Controls.Add(this.pass_text);
            this.groupBox1.Location = new System.Drawing.Point(627, 202);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(356, 242);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login";
            // 
            // Login
            // 
            this.AcceptButton = this.Login_but;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CancelButton = this.close;
            this.ClientSize = new System.Drawing.Size(1019, 654);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label shop;
        private System.Windows.Forms.TextBox pass_text;
        private System.Windows.Forms.TextBox username_text;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Button Login_but;
        private System.Windows.Forms.Button showpass;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

