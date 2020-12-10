namespace KFoldAndRandomSampling
{
    partial class Form1
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
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_hesapla = new System.Windows.Forms.Button();
            this.cbox_metric = new System.Windows.Forms.ComboBox();
            this.btn_hesapla2 = new System.Windows.Forms.Button();
            this.txt_bolmeDegeri = new System.Windows.Forms.TextBox();
            this.lbl_veriyiBolme = new System.Windows.Forms.Label();
            this.cbox_veriyiBolmeTipi = new System.Windows.Forms.ComboBox();
            this.lbl_uzaklikMetrigi = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_pDegeri = new System.Windows.Forms.TextBox();
            this.lbl_pDegeri = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 97);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(993, 347);
            this.dataGridView1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(13, 450);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(993, 219);
            this.dataGridView2.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(344, 22);
            this.textBox1.TabIndex = 2;
            // 
            // btn_hesapla
            // 
            this.btn_hesapla.Location = new System.Drawing.Point(363, 26);
            this.btn_hesapla.Name = "btn_hesapla";
            this.btn_hesapla.Size = new System.Drawing.Size(75, 33);
            this.btn_hesapla.TabIndex = 3;
            this.btn_hesapla.Text = "Hesapla";
            this.btn_hesapla.UseVisualStyleBackColor = true;
            this.btn_hesapla.Click += new System.EventHandler(this.btn_hesapla_Click);
            // 
            // cbox_metric
            // 
            this.cbox_metric.FormattingEnabled = true;
            this.cbox_metric.Items.AddRange(new object[] {
            "Square Cold",
            "Minkowski"});
            this.cbox_metric.Location = new System.Drawing.Point(1114, 136);
            this.cbox_metric.Name = "cbox_metric";
            this.cbox_metric.Size = new System.Drawing.Size(148, 24);
            this.cbox_metric.TabIndex = 6;
            this.cbox_metric.SelectedIndexChanged += new System.EventHandler(this.cbox_metric_SelectedIndexChanged);
            // 
            // btn_hesapla2
            // 
            this.btn_hesapla2.Location = new System.Drawing.Point(1114, 171);
            this.btn_hesapla2.Name = "btn_hesapla2";
            this.btn_hesapla2.Size = new System.Drawing.Size(262, 32);
            this.btn_hesapla2.TabIndex = 7;
            this.btn_hesapla2.Text = "Hesapla 2";
            this.btn_hesapla2.UseVisualStyleBackColor = true;
            this.btn_hesapla2.Click += new System.EventHandler(this.btn_hesapla2_Click);
            // 
            // txt_bolmeDegeri
            // 
            this.txt_bolmeDegeri.Location = new System.Drawing.Point(1341, 99);
            this.txt_bolmeDegeri.MaxLength = 2;
            this.txt_bolmeDegeri.Name = "txt_bolmeDegeri";
            this.txt_bolmeDegeri.Size = new System.Drawing.Size(40, 22);
            this.txt_bolmeDegeri.TabIndex = 8;
            // 
            // lbl_veriyiBolme
            // 
            this.lbl_veriyiBolme.AutoSize = true;
            this.lbl_veriyiBolme.Location = new System.Drawing.Point(1267, 102);
            this.lbl_veriyiBolme.Name = "lbl_veriyiBolme";
            this.lbl_veriyiBolme.Size = new System.Drawing.Size(63, 17);
            this.lbl_veriyiBolme.TabIndex = 9;
            this.lbl_veriyiBolme.Text = "K Değeri";
            // 
            // cbox_veriyiBolmeTipi
            // 
            this.cbox_veriyiBolmeTipi.FormattingEnabled = true;
            this.cbox_veriyiBolmeTipi.Items.AddRange(new object[] {
            "K-Fold",
            "Random Sampling"});
            this.cbox_veriyiBolmeTipi.Location = new System.Drawing.Point(1114, 99);
            this.cbox_veriyiBolmeTipi.Name = "cbox_veriyiBolmeTipi";
            this.cbox_veriyiBolmeTipi.Size = new System.Drawing.Size(148, 24);
            this.cbox_veriyiBolmeTipi.TabIndex = 10;
            this.cbox_veriyiBolmeTipi.SelectedIndexChanged += new System.EventHandler(this.cbox_veriyiBolmeTipi_SelectedIndexChanged);
            // 
            // lbl_uzaklikMetrigi
            // 
            this.lbl_uzaklikMetrigi.AutoSize = true;
            this.lbl_uzaklikMetrigi.Location = new System.Drawing.Point(1012, 137);
            this.lbl_uzaklikMetrigi.Name = "lbl_uzaklikMetrigi";
            this.lbl_uzaklikMetrigi.Size = new System.Drawing.Size(99, 17);
            this.lbl_uzaklikMetrigi.TabIndex = 11;
            this.lbl_uzaklikMetrigi.Text = "Uzaklık Metriği";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(1013, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 35);
            this.label1.TabIndex = 12;
            this.label1.Text = "Veriyi Bölme Yöntemi";
            // 
            // txt_pDegeri
            // 
            this.txt_pDegeri.Location = new System.Drawing.Point(1341, 136);
            this.txt_pDegeri.Name = "txt_pDegeri";
            this.txt_pDegeri.Size = new System.Drawing.Size(40, 22);
            this.txt_pDegeri.TabIndex = 13;
            this.txt_pDegeri.Visible = false;
            // 
            // lbl_pDegeri
            // 
            this.lbl_pDegeri.AutoSize = true;
            this.lbl_pDegeri.Location = new System.Drawing.Point(1267, 139);
            this.lbl_pDegeri.Name = "lbl_pDegeri";
            this.lbl_pDegeri.Size = new System.Drawing.Size(63, 17);
            this.lbl_pDegeri.TabIndex = 14;
            this.lbl_pDegeri.Text = "P Değeri";
            this.lbl_pDegeri.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 750);
            this.Controls.Add(this.lbl_pDegeri);
            this.Controls.Add(this.txt_pDegeri);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_uzaklikMetrigi);
            this.Controls.Add(this.cbox_veriyiBolmeTipi);
            this.Controls.Add(this.lbl_veriyiBolme);
            this.Controls.Add(this.txt_bolmeDegeri);
            this.Controls.Add(this.btn_hesapla2);
            this.Controls.Add(this.cbox_metric);
            this.Controls.Add(this.btn_hesapla);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_hesapla;
        private System.Windows.Forms.ComboBox cbox_metric;
        private System.Windows.Forms.Button btn_hesapla2;
        private System.Windows.Forms.TextBox txt_bolmeDegeri;
        private System.Windows.Forms.Label lbl_veriyiBolme;
        private System.Windows.Forms.ComboBox cbox_veriyiBolmeTipi;
        private System.Windows.Forms.Label lbl_uzaklikMetrigi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_pDegeri;
        private System.Windows.Forms.Label lbl_pDegeri;
    }
}

