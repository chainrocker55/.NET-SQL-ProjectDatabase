namespace DB_NTCF_C
{
    partial class จัดการประเภท
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
            this.fix = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.search = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // fix
            // 
            this.fix.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.fix.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.fix.Location = new System.Drawing.Point(171, 131);
            this.fix.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fix.Name = "fix";
            this.fix.Size = new System.Drawing.Size(75, 32);
            this.fix.TabIndex = 24;
            this.fix.TabStop = false;
            this.fix.Text = "แก้ไข";
            this.fix.UseVisualStyleBackColor = false;
            this.fix.Click += new System.EventHandler(this.fix_Click);
            // 
            // delete
            // 
            this.delete.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.delete.Location = new System.Drawing.Point(269, 131);
            this.delete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(75, 32);
            this.delete.TabIndex = 23;
            this.delete.TabStop = false;
            this.delete.Text = "ลบ";
            this.delete.UseVisualStyleBackColor = false;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // add
            // 
            this.add.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.add.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.add.Location = new System.Drawing.Point(76, 131);
            this.add.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(75, 32);
            this.add.TabIndex = 22;
            this.add.TabStop = false;
            this.add.Text = "เพิ่ม";
            this.add.UseVisualStyleBackColor = false;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // search
            // 
            this.search.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.search.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.search.Location = new System.Drawing.Point(314, 64);
            this.search.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(75, 32);
            this.search.TabIndex = 26;
            this.search.TabStop = false;
            this.search.Text = "ค้าหา";
            this.search.UseVisualStyleBackColor = false;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(50, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 25);
            this.label1.TabIndex = 27;
            this.label1.Text = "ชื่อประเภท";
            // 
            // name
            // 
            this.name.FormattingEnabled = true;
            this.name.Items.AddRange(new object[] {
            "ทั้งหมด",
            "เครื่องดืม",
            "อาหารแห้ง",
            "อาหารกระป๋อง",
            "ขนม",
            "เครื่องปรุง"});
            this.name.Location = new System.Drawing.Point(155, 72);
            this.name.Margin = new System.Windows.Forms.Padding(4);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(125, 24);
            this.name.TabIndex = 28;
            this.name.Tag = "ทั้งหมด";
            // 
            // จัดการประเภท
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 253);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.search);
            this.Controls.Add(this.fix);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.add);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "จัดการประเภท";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "จัดการประเภท";
            this.Load += new System.EventHandler(this.จัดการประเภท_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button fix;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox name;
    }
}