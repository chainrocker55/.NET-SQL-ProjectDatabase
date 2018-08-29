namespace DB_NTCF_C
{
    partial class การจัดการแผนก
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.delete = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.serch = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.add = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.name2 = new System.Windows.Forms.TextBox();
            this.edit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.delete);
            this.groupBox1.Controls.Add(this.name);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.serch);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(15, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(725, 297);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ค้นหา";
            // 
            // delete
            // 
            this.delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.delete.Location = new System.Drawing.Point(437, 30);
            this.delete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(75, 28);
            this.delete.TabIndex = 4;
            this.delete.Text = "ลบ";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // name
            // 
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.name.FormattingEnabled = true;
            this.name.Location = new System.Drawing.Point(168, 30);
            this.name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(121, 28);
            this.name.TabIndex = 3;
            this.name.SelectedIndexChanged += new System.EventHandler(this.search_Click);
            this.name.Click += new System.EventHandler(this.name_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(65, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "ชื่อ แผนก";
            // 
            // serch
            // 
            this.serch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.serch.Location = new System.Drawing.Point(340, 30);
            this.serch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.serch.Name = "serch";
            this.serch.Size = new System.Drawing.Size(75, 28);
            this.serch.TabIndex = 1;
            this.serch.Text = "ค้นหา";
            this.serch.UseVisualStyleBackColor = true;
            this.serch.Click += new System.EventHandler(this.search_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(5, 74);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(715, 203);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.add);
            this.groupBox2.Controls.Add(this.id);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.name2);
            this.groupBox2.Controls.Add(this.edit);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(20, 340);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(411, 170);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "เพิ่มแผนก";
            // 
            // add
            // 
            this.add.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.add.Location = new System.Drawing.Point(65, 117);
            this.add.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(75, 28);
            this.add.TabIndex = 8;
            this.add.Text = "เพิ่ม";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // id
            // 
            this.id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.id.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.id.FormattingEnabled = true;
            this.id.Location = new System.Drawing.Point(144, 81);
            this.id.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(127, 28);
            this.id.TabIndex = 4;
            this.id.Click += new System.EventHandler(this.id_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(39, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "ID Head";
            // 
            // name2
            // 
            this.name2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.name2.Location = new System.Drawing.Point(144, 39);
            this.name2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.name2.Name = "name2";
            this.name2.Size = new System.Drawing.Size(127, 27);
            this.name2.TabIndex = 6;
            // 
            // edit
            // 
            this.edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.edit.Location = new System.Drawing.Point(192, 117);
            this.edit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(75, 28);
            this.edit.TabIndex = 4;
            this.edit.Text = "แก้ไข";
            this.edit.UseVisualStyleBackColor = true;
            this.edit.Click += new System.EventHandler(this.edit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(39, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "ชื่อ แผนก";
            // 
            // การจัดการแผนก
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 523);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "การจัดการแผนก";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "การจัดการแผนก";
            this.Load += new System.EventHandler(this.การจัดการแผนก_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.ComboBox name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button serch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.ComboBox id;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox name2;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Label label2;
    }
}