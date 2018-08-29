namespace DB_NTCF_C
{
    partial class รายการขาย
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.retail = new System.Windows.Forms.Button();
            this.order = new System.Windows.Forms.Button();
            this.date2 = new System.Windows.Forms.DateTimePicker();
            this.date1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.de = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.Location = new System.Drawing.Point(31, 151);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(904, 407);
            this.dataGridView1.TabIndex = 34;
            // 
            // retail
            // 
            this.retail.BackColor = System.Drawing.Color.White;
            this.retail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.retail.ForeColor = System.Drawing.Color.Blue;
            this.retail.Location = new System.Drawing.Point(507, 93);
            this.retail.Name = "retail";
            this.retail.Size = new System.Drawing.Size(158, 35);
            this.retail.TabIndex = 62;
            this.retail.Text = "การค้าปลีก";
            this.retail.UseVisualStyleBackColor = false;
            this.retail.Click += new System.EventHandler(this.retail_Click);
            // 
            // order
            // 
            this.order.BackColor = System.Drawing.Color.White;
            this.order.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.order.ForeColor = System.Drawing.Color.Blue;
            this.order.Location = new System.Drawing.Point(671, 93);
            this.order.Name = "order";
            this.order.Size = new System.Drawing.Size(158, 35);
            this.order.TabIndex = 63;
            this.order.Text = "การค้าส่ง";
            this.order.UseVisualStyleBackColor = false;
            this.order.Click += new System.EventHandler(this.order_Click);
            // 
            // date2
            // 
            this.date2.CustomFormat = "yyyy-MM-dd";
            this.date2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.date2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date2.Location = new System.Drawing.Point(406, 26);
            this.date2.Name = "date2";
            this.date2.Size = new System.Drawing.Size(185, 27);
            this.date2.TabIndex = 67;
            // 
            // date1
            // 
            this.date1.CustomFormat = "yyyy-MM-dd";
            this.date1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.date1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date1.Location = new System.Drawing.Point(159, 27);
            this.date1.Name = "date1";
            this.date1.Size = new System.Drawing.Size(166, 27);
            this.date1.TabIndex = 66;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(351, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 25);
            this.label3.TabIndex = 65;
            this.label3.Text = "ถึง";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(71, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 25);
            this.label2.TabIndex = 64;
            this.label2.Text = "วันที่";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button1.ForeColor = System.Drawing.Color.Blue;
            this.button1.Location = new System.Drawing.Point(204, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(181, 35);
            this.button1.TabIndex = 68;
            this.button1.Text = "รายละเอียดการค้าปลีก";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ID
            // 
            this.ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ID.Location = new System.Drawing.Point(76, 92);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(119, 30);
            this.ID.TabIndex = 69;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(38, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 25);
            this.label1.TabIndex = 70;
            this.label1.Text = "ID";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button2.ForeColor = System.Drawing.Color.Blue;
            this.button2.Location = new System.Drawing.Point(391, 90);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 35);
            this.button2.TabIndex = 71;
            this.button2.Text = "ลบ";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // de
            // 
            this.de.BackColor = System.Drawing.Color.White;
            this.de.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.de.ForeColor = System.Drawing.Color.Blue;
            this.de.Location = new System.Drawing.Point(835, 92);
            this.de.Name = "de";
            this.de.Size = new System.Drawing.Size(64, 35);
            this.de.TabIndex = 72;
            this.de.Text = "ลบ";
            this.de.UseVisualStyleBackColor = false;
            this.de.Click += new System.EventHandler(this.de_Click);
            // 
            // รายการขาย
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 570);
            this.Controls.Add(this.de);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ID);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.date2);
            this.Controls.Add(this.date1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.order);
            this.Controls.Add(this.retail);
            this.Controls.Add(this.dataGridView1);
            this.Name = "รายการขาย";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "รายการขาย";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button retail;
        private System.Windows.Forms.Button order;
        private System.Windows.Forms.DateTimePicker date2;
        private System.Windows.Forms.DateTimePicker date1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox ID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button de;
    }
}