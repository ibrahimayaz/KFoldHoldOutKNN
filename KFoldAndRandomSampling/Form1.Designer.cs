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
            this.txt_yeniVeri = new System.Windows.Forms.TextBox();
            this.btn_hesapla = new System.Windows.Forms.Button();
            this.cbox_metric = new System.Windows.Forms.ComboBox();
            this.btn_hesapla2 = new System.Windows.Forms.Button();
            this.txt_bolmeDegeri = new System.Windows.Forms.TextBox();
            this.cbox_veriyiBolmeTipi = new System.Windows.Forms.ComboBox();
            this.lbl_uzaklikMetrigi = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_pDegeri = new System.Windows.Forms.TextBox();
            this.lbl_pDegeri = new System.Windows.Forms.Label();
            this.txt_knnKDegeri = new System.Windows.Forms.TextBox();
            this.lbl_knnKDegeri = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_veriSetiniSec = new System.Windows.Forms.Button();
            this.lbl_veriyiBolme = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.cbox_normalizasyon = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(20, 191);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(949, 328);
            this.dataGridView1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(20, 525);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(950, 182);
            this.dataGridView2.TabIndex = 1;
            // 
            // txt_yeniVeri
            // 
            this.txt_yeniVeri.Location = new System.Drawing.Point(127, 104);
            this.txt_yeniVeri.Name = "txt_yeniVeri";
            this.txt_yeniVeri.Size = new System.Drawing.Size(323, 22);
            this.txt_yeniVeri.TabIndex = 2;
            this.txt_yeniVeri.Text = "12,47;1,52;2,2;19;162;2,5;2,27;0,32;3,28;2,6;1,16;2,63;937";
            // 
            // btn_hesapla
            // 
            this.btn_hesapla.Location = new System.Drawing.Point(127, 157);
            this.btn_hesapla.Name = "btn_hesapla";
            this.btn_hesapla.Size = new System.Drawing.Size(148, 32);
            this.btn_hesapla.TabIndex = 3;
            this.btn_hesapla.Text = "Yeni Değeri Hesapla";
            this.btn_hesapla.UseVisualStyleBackColor = true;
            this.btn_hesapla.Click += new System.EventHandler(this.btn_hesapla_Click);
            // 
            // cbox_metric
            // 
            this.cbox_metric.FormattingEnabled = true;
            this.cbox_metric.Items.AddRange(new object[] {
            "Square Cold",
            "Minkowski",
            "Canberra"});
            this.cbox_metric.Location = new System.Drawing.Point(127, 42);
            this.cbox_metric.Name = "cbox_metric";
            this.cbox_metric.Size = new System.Drawing.Size(148, 24);
            this.cbox_metric.TabIndex = 6;
            this.cbox_metric.SelectedIndexChanged += new System.EventHandler(this.cbox_metric_SelectedIndexChanged);
            // 
            // btn_hesapla2
            // 
            this.btn_hesapla2.Location = new System.Drawing.Point(284, 157);
            this.btn_hesapla2.Name = "btn_hesapla2";
            this.btn_hesapla2.Size = new System.Drawing.Size(169, 32);
            this.btn_hesapla2.TabIndex = 7;
            this.btn_hesapla2.Text = "Veri Setini Hesapla";
            this.btn_hesapla2.UseVisualStyleBackColor = true;
            this.btn_hesapla2.Click += new System.EventHandler(this.btn_hesapla2_Click);
            // 
            // txt_bolmeDegeri
            // 
            this.txt_bolmeDegeri.Location = new System.Drawing.Point(397, 76);
            this.txt_bolmeDegeri.MaxLength = 2;
            this.txt_bolmeDegeri.Name = "txt_bolmeDegeri";
            this.txt_bolmeDegeri.Size = new System.Drawing.Size(53, 22);
            this.txt_bolmeDegeri.TabIndex = 8;
            // 
            // cbox_veriyiBolmeTipi
            // 
            this.cbox_veriyiBolmeTipi.FormattingEnabled = true;
            this.cbox_veriyiBolmeTipi.Items.AddRange(new object[] {
            "K-Fold",
            "Random Sampling"});
            this.cbox_veriyiBolmeTipi.Location = new System.Drawing.Point(127, 73);
            this.cbox_veriyiBolmeTipi.Name = "cbox_veriyiBolmeTipi";
            this.cbox_veriyiBolmeTipi.Size = new System.Drawing.Size(148, 24);
            this.cbox_veriyiBolmeTipi.TabIndex = 10;
            this.cbox_veriyiBolmeTipi.SelectedIndexChanged += new System.EventHandler(this.cbox_veriyiBolmeTipi_SelectedIndexChanged);
            // 
            // lbl_uzaklikMetrigi
            // 
            this.lbl_uzaklikMetrigi.AutoSize = true;
            this.lbl_uzaklikMetrigi.Location = new System.Drawing.Point(12, 42);
            this.lbl_uzaklikMetrigi.Name = "lbl_uzaklikMetrigi";
            this.lbl_uzaklikMetrigi.Size = new System.Drawing.Size(99, 17);
            this.lbl_uzaklikMetrigi.TabIndex = 11;
            this.lbl_uzaklikMetrigi.Text = "Uzaklık Metriği";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(15, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 35);
            this.label1.TabIndex = 12;
            this.label1.Text = "Veriyi Bölme Yöntemi";
            // 
            // txt_pDegeri
            // 
            this.txt_pDegeri.Location = new System.Drawing.Point(397, 44);
            this.txt_pDegeri.Name = "txt_pDegeri";
            this.txt_pDegeri.Size = new System.Drawing.Size(53, 22);
            this.txt_pDegeri.TabIndex = 13;
            this.txt_pDegeri.Visible = false;
            // 
            // lbl_pDegeri
            // 
            this.lbl_pDegeri.AutoSize = true;
            this.lbl_pDegeri.Location = new System.Drawing.Point(281, 45);
            this.lbl_pDegeri.Name = "lbl_pDegeri";
            this.lbl_pDegeri.Size = new System.Drawing.Size(63, 17);
            this.lbl_pDegeri.TabIndex = 14;
            this.lbl_pDegeri.Text = "P Değeri";
            this.lbl_pDegeri.Visible = false;
            // 
            // txt_knnKDegeri
            // 
            this.txt_knnKDegeri.Location = new System.Drawing.Point(127, 131);
            this.txt_knnKDegeri.Name = "txt_knnKDegeri";
            this.txt_knnKDegeri.Size = new System.Drawing.Size(148, 22);
            this.txt_knnKDegeri.TabIndex = 19;
            // 
            // lbl_knnKDegeri
            // 
            this.lbl_knnKDegeri.Location = new System.Drawing.Point(12, 132);
            this.lbl_knnKDegeri.Name = "lbl_knnKDegeri";
            this.lbl_knnKDegeri.Size = new System.Drawing.Size(110, 22);
            this.lbl_knnKDegeri.TabIndex = 18;
            this.lbl_knnKDegeri.Text = "KNN - K Değeri";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn_veriSetiniSec
            // 
            this.btn_veriSetiniSec.Location = new System.Drawing.Point(15, 8);
            this.btn_veriSetiniSec.Name = "btn_veriSetiniSec";
            this.btn_veriSetiniSec.Size = new System.Drawing.Size(435, 28);
            this.btn_veriSetiniSec.TabIndex = 20;
            this.btn_veriSetiniSec.Text = "Veri Setini Seç";
            this.btn_veriSetiniSec.UseVisualStyleBackColor = true;
            this.btn_veriSetiniSec.Click += new System.EventHandler(this.btn_veriSetiniSec_Click);
            // 
            // lbl_veriyiBolme
            // 
            this.lbl_veriyiBolme.Location = new System.Drawing.Point(281, 76);
            this.lbl_veriyiBolme.Name = "lbl_veriyiBolme";
            this.lbl_veriyiBolme.Size = new System.Drawing.Size(106, 19);
            this.lbl_veriyiBolme.TabIndex = 21;
            this.lbl_veriyiBolme.Text = "K-Fold Değeri";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(15, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 22);
            this.label2.TabIndex = 22;
            this.label2.Text = "Yeni Değeri";
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(459, 8);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersWidth = 51;
            this.dataGridView3.RowTemplate.Height = 24;
            this.dataGridView3.Size = new System.Drawing.Size(510, 177);
            this.dataGridView3.TabIndex = 24;
            // 
            // cbox_normalizasyon
            // 
            this.cbox_normalizasyon.AutoSize = true;
            this.cbox_normalizasyon.Location = new System.Drawing.Point(284, 131);
            this.cbox_normalizasyon.Name = "cbox_normalizasyon";
            this.cbox_normalizasyon.Size = new System.Drawing.Size(123, 21);
            this.cbox_normalizasyon.TabIndex = 25;
            this.cbox_normalizasyon.Text = "Normalizasyon";
            this.cbox_normalizasyon.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 719);
            this.Controls.Add(this.cbox_normalizasyon);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_veriyiBolme);
            this.Controls.Add(this.btn_veriSetiniSec);
            this.Controls.Add(this.txt_knnKDegeri);
            this.Controls.Add(this.lbl_knnKDegeri);
            this.Controls.Add(this.lbl_pDegeri);
            this.Controls.Add(this.txt_pDegeri);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_uzaklikMetrigi);
            this.Controls.Add(this.cbox_veriyiBolmeTipi);
            this.Controls.Add(this.txt_bolmeDegeri);
            this.Controls.Add(this.btn_hesapla2);
            this.Controls.Add(this.cbox_metric);
            this.Controls.Add(this.btn_hesapla);
            this.Controls.Add(this.txt_yeniVeri);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox txt_yeniVeri;
        private System.Windows.Forms.Button btn_hesapla;
        private System.Windows.Forms.ComboBox cbox_metric;
        private System.Windows.Forms.Button btn_hesapla2;
        private System.Windows.Forms.TextBox txt_bolmeDegeri;
        private System.Windows.Forms.ComboBox cbox_veriyiBolmeTipi;
        private System.Windows.Forms.Label lbl_uzaklikMetrigi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_pDegeri;
        private System.Windows.Forms.Label lbl_pDegeri;
        private System.Windows.Forms.TextBox txt_knnKDegeri;
        private System.Windows.Forms.Label lbl_knnKDegeri;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_veriSetiniSec;
        private System.Windows.Forms.Label lbl_veriyiBolme;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.CheckBox cbox_normalizasyon;
    }
}

