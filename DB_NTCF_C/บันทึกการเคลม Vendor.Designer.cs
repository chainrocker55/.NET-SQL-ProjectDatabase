namespace DB_NTCF_C
{
    partial class บันทึกการเคลม
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
            this.detailsearch = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.ComboBox();
            this.delete = new System.Windows.Forms.Button();
            this.dtg = new System.Windows.Forms.DataGridView();
            this.search = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.datesent = new System.Windows.Forms.DateTimePicker();
            this.datereceive = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.id2 = new System.Windows.Forms.ComboBox();
            this.cause = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.idpro = new System.Windows.Forms.Label();
            this.save = new System.Windows.Forms.Button();
            this.จำนวน = new System.Windows.Forms.TextBox();
            this.qty = new System.Windows.Forms.Label();
            this.detail = new System.Windows.Forms.Label();
            this.idorder = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.datesentddd = new System.Windows.Forms.Label();
            this.datere = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.detailsearch);
            this.groupBox1.Controls.Add(this.id);
            this.groupBox1.Controls.Add(this.delete);
            this.groupBox1.Controls.Add(this.dtg);
            this.groupBox1.Controls.Add(this.search);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(0, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(729, 611);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "เรียกดู";
            // 
            // detailsearch
            // 
            this.detailsearch.Location = new System.Drawing.Point(287, 59);
            this.detailsearch.Name = "detailsearch";
            this.detailsearch.Size = new System.Drawing.Size(170, 31);
            this.detailsearch.TabIndex = 35;
            this.detailsearch.Text = "รายละเอียด";
            this.detailsearch.UseVisualStyleBackColor = true;
            this.detailsearch.Click += new System.EventHandler(this.detailsearch_Click);
            // 
            // id
            // 
            this.id.FormattingEnabled = true;
            this.id.Location = new System.Drawing.Point(143, 27);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(121, 28);
            this.id.TabIndex = 34;
            // 
            // delete
            // 
            this.delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.delete.Location = new System.Drawing.Point(385, 22);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(72, 31);
            this.delete.TabIndex = 30;
            this.delete.Text = "ลบ";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click_1);
            // 
            // dtg
            // 
            this.dtg.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg.Location = new System.Drawing.Point(7, 111);
            this.dtg.Name = "dtg";
            this.dtg.RowTemplate.Height = 24;
            this.dtg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg.Size = new System.Drawing.Size(711, 450);
            this.dtg.TabIndex = 33;
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(287, 22);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(75, 31);
            this.search.TabIndex = 32;
            this.search.Text = "ค้นหา";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click_1);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.Location = new System.Drawing.Point(27, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 20);
            this.label8.TabIndex = 30;
            this.label8.Text = "ID การเคลม";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.datesent);
            this.groupBox3.Controls.Add(this.datereceive);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.idorder);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.datesentddd);
            this.groupBox3.Controls.Add(this.datere);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(700, 622);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "บันทึกเพิ่ม";
            // 
            // datesent
            // 
            this.datesent.CustomFormat = "yyyy-MM-dd";
            this.datesent.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datesent.Location = new System.Drawing.Point(120, 37);
            this.datesent.Name = "datesent";
            this.datesent.Size = new System.Drawing.Size(149, 26);
            this.datesent.TabIndex = 38;
            // 
            // datereceive
            // 
            this.datereceive.CustomFormat = "yyyy-MM-dd";
            this.datereceive.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datereceive.Location = new System.Drawing.Point(120, 80);
            this.datereceive.Name = "datereceive";
            this.datereceive.Size = new System.Drawing.Size(149, 26);
            this.datereceive.TabIndex = 37;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.id2);
            this.groupBox2.Controls.Add(this.cause);
            this.groupBox2.Controls.Add(this.dataGridView2);
            this.groupBox2.Controls.Add(this.idpro);
            this.groupBox2.Controls.Add(this.save);
            this.groupBox2.Controls.Add(this.จำนวน);
            this.groupBox2.Controls.Add(this.qty);
            this.groupBox2.Controls.Add(this.detail);
            this.groupBox2.Location = new System.Drawing.Point(20, 167);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(674, 430);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "รายละเอียด";
            // 
            // id2
            // 
            this.id2.FormattingEnabled = true;
            this.id2.Location = new System.Drawing.Point(119, 26);
            this.id2.Name = "id2";
            this.id2.Size = new System.Drawing.Size(130, 28);
            this.id2.TabIndex = 36;
            // 
            // cause
            // 
            this.cause.Location = new System.Drawing.Point(364, 26);
            this.cause.Name = "cause";
            this.cause.Size = new System.Drawing.Size(182, 26);
            this.cause.TabIndex = 33;
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView2.Location = new System.Drawing.Point(22, 113);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(632, 316);
            this.dataGridView2.TabIndex = 32;
            // 
            // idpro
            // 
            this.idpro.AutoSize = true;
            this.idpro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.idpro.Location = new System.Drawing.Point(18, 32);
            this.idpro.Name = "idpro";
            this.idpro.Size = new System.Drawing.Size(68, 20);
            this.idpro.TabIndex = 12;
            this.idpro.Text = "ID สินค้า";
            // 
            // save
            // 
            this.save.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.save.Location = new System.Drawing.Point(404, 64);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(82, 41);
            this.save.TabIndex = 21;
            this.save.Text = "บันทึก";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // จำนวน
            // 
            this.จำนวน.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.จำนวน.Location = new System.Drawing.Point(119, 71);
            this.จำนวน.Name = "จำนวน";
            this.จำนวน.Size = new System.Drawing.Size(130, 26);
            this.จำนวน.TabIndex = 29;
            // 
            // qty
            // 
            this.qty.AutoSize = true;
            this.qty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.qty.Location = new System.Drawing.Point(18, 77);
            this.qty.Name = "qty";
            this.qty.Size = new System.Drawing.Size(54, 20);
            this.qty.TabIndex = 28;
            this.qty.Text = "จำนวน";
            // 
            // detail
            // 
            this.detail.AutoSize = true;
            this.detail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.detail.Location = new System.Drawing.Point(292, 25);
            this.detail.Name = "detail";
            this.detail.Size = new System.Drawing.Size(52, 20);
            this.detail.TabIndex = 14;
            this.detail.Text = "สาเหตุ";
            // 
            // idorder
            // 
            this.idorder.FormattingEnabled = true;
            this.idorder.Location = new System.Drawing.Point(120, 115);
            this.idorder.Name = "idorder";
            this.idorder.Size = new System.Drawing.Size(130, 28);
            this.idorder.TabIndex = 26;
            this.idorder.TextChanged += new System.EventHandler(this.idorder_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(19, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 25;
            this.label2.Text = "ID ใบสั่งซื้อ";
            // 
            // datesentddd
            // 
            this.datesentddd.AutoSize = true;
            this.datesentddd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.datesentddd.Location = new System.Drawing.Point(15, 40);
            this.datesentddd.Name = "datesentddd";
            this.datesentddd.Size = new System.Drawing.Size(91, 20);
            this.datesentddd.TabIndex = 6;
            this.datesentddd.Text = "วันที่ส่งเคลม";
            // 
            // datere
            // 
            this.datere.AutoSize = true;
            this.datere.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.datere.Location = new System.Drawing.Point(15, 83);
            this.datere.Name = "datere";
            this.datere.Size = new System.Drawing.Size(76, 20);
            this.datere.TabIndex = 7;
            this.datere.Text = "วันที่รับคืน";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(746, 692);
            this.tabControl1.TabIndex = 32;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(738, 659);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "เรียกดู";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(738, 659);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "บันทึกเพิ่ม";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // บันทึกการเคลม
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(764, 531);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "บันทึกการเคลม";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "บันทึกการเคลม";
            this.Load += new System.EventHandler(this.บันทึกการเคลม_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dtg;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox จำนวน;
        private System.Windows.Forms.Label qty;
        private System.Windows.Forms.ComboBox idorder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Label idpro;
        private System.Windows.Forms.Label detail;
        private System.Windows.Forms.Label datesentddd;
        private System.Windows.Forms.Label datere;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.TextBox cause;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button detailsearch;
        private System.Windows.Forms.ComboBox id;
        private System.Windows.Forms.DateTimePicker datesent;
        private System.Windows.Forms.DateTimePicker datereceive;
        private System.Windows.Forms.ComboBox id2;
    }
}