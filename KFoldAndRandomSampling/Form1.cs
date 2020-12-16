using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KFoldAndRandomSampling
{
    public partial class Form1 : Form
    {
        public double[][] data;
        public Veri v;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbox_metric.SelectedIndex = 0;
            cbox_veriyiBolmeTipi.SelectedIndex = 0;

            if (cbox_veriyiBolmeTipi.SelectedIndex==0)
            {
                lbl_veriyiBolme.Text = "K-Fold Değeri";
            }
            else
            {
                lbl_veriyiBolme.Text = "Test Oranı %";
            }


            if (cbox_metric.SelectedIndex == 1)
            {
                lbl_pDegeri.Visible = true;
                txt_pDegeri.Visible = true;
            }
            else
            {
                lbl_pDegeri.Visible = false;
                txt_pDegeri.Visible = false;
            }


        }

        private void cbox_metric_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbox_metric.SelectedIndex == 1)
            {
                lbl_pDegeri.Visible = true;
                txt_pDegeri.Visible = true;
            }
            else
            {
                lbl_pDegeri.Visible = false;
                txt_pDegeri.Visible = false;
            }
        }

        private void cbox_veriyiBolmeTipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbox_veriyiBolmeTipi.SelectedIndex == 0)
            {
                lbl_veriyiBolme.Text = "K-Fold Değeri";
            }
            else
            {
                lbl_veriyiBolme.Text = "Test Oranı %";
            }
        }

        private void btn_hesapla2_Click(object sender, EventArgs e)
        {
            if (Kontrol())
            {
                DataGridVeriTemizle(dataGridView1);
                DataGridVeriTemizle(dataGridView2);
                if (cbox_veriyiBolmeTipi.SelectedIndex == 0)
                {
                    KFold kf = new KFold(v.Data, int.Parse(txt_bolmeDegeri.Text));
                    kf.Fold();
                    double[] accScore = new double[int.Parse(txt_bolmeDegeri.Text)];
                    for (int i = 0; i < int.Parse(txt_bolmeDegeri.Text); i++)
                    {
                        var currentFoldData = kf.FoldCalculate(i);
                        v.xTrain = cbox_normalizasyon.Checked ? new FeatureScaling().Normalize(currentFoldData.xTrain) : currentFoldData.xTrain;
                        v.yTrain = currentFoldData.yTrain;
                        v.xTest = cbox_normalizasyon.Checked ? new FeatureScaling().Normalize(currentFoldData.xTest) : currentFoldData.xTest;
                        v.yTest = currentFoldData.yTest;
                        KNN knn = new KNN(int.Parse(txt_knnKDegeri.Text), v, SecilenMetrik());
                        accScore[i] = knn.Classifier();

                        DataGridVeriEkle(dataGridView1, v.xTrain);
                        DataGridVeriEkle(dataGridView2, v.xTest);
                    }
                    DataGridVeriTemizle(dataGridView3);
                    dataGridView3.DataSource = accScore.Select((x, y) => new {
                        FoldNumber = y + 1,
                        AccScore = x
                    }).ToList();

                    var accuracyScore = accScore.Sum() / int.Parse(txt_bolmeDegeri.Text);
                    MessageBox.Show("Accruacy Score: " + accuracyScore.ToString());
                }
                else
                {
                    double accScore = 0;
                    RandomSampling rs = new RandomSampling(data, double.Parse(txt_bolmeDegeri.Text));
                    var currentFoldData = rs.Split2();
                    v.xTrain = cbox_normalizasyon.Checked ? new FeatureScaling().Normalize(currentFoldData.xTrain) : currentFoldData.xTrain;
                    v.yTrain = currentFoldData.yTrain;
                    v.xTest = cbox_normalizasyon.Checked ? new FeatureScaling().Normalize(currentFoldData.xTest) : currentFoldData.xTest;
                    v.yTest = currentFoldData.yTest;
                    KNN knn = new KNN(int.Parse(txt_knnKDegeri.Text), v, SecilenMetrik());
                    accScore = knn.Classifier();
                    DataGridVeriEkle(dataGridView1, v.xTrain);
                    DataGridVeriEkle(dataGridView2, v.xTest);
                    DataGridVeriTemizle(dataGridView3);
                    MessageBox.Show("Accruacy Score: " + accScore.ToString());

                }
            }
            else
            {
                MessageBox.Show("Boş alanlar var kontrol ediniz.");
            }
            
        }

        private void btn_hesapla_Click(object sender, EventArgs e)
        {
            if (Kontrol())
            {
                double[] yeniVeri = new double[v.Data[0].Length - 1];
                string[] veri = txt_yeniVeri.Text.Split(';');
                if (v.Data[0].Length - 1 == veri.Length)
                {
                    for (int i = 0; i < veri.Length; i++)
                    {
                        yeniVeri[i] = double.Parse(veri[i]);
                    }
                    KNN knn = new KNN(int.Parse(txt_knnKDegeri.Text), v, SecilenMetrik());
                    var r = knn.Classifier2(yeniVeri);

                    DataGridVeriEkle(dataGridView3, r.Item1.ToArray());
                    MessageBox.Show("Tahmin Edilen Sınıf: " + r.Item2);
                }
                else
                {
                    MessageBox.Show("Veri Setinin kolon sayısı ile girilen yeni değer dizisinin uzunluğu(" + veri.Length.ToString() + ") birbiriyle uyuşmamaktadır.");
                }
            }
            else
            {
                MessageBox.Show("Boş alanlar var kontrol ediniz.");
            }
            
           
          
        }

        private void btn_veriSetiniSec_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Veri setini seçiniz";
            openFileDialog1.Filter = "Dosya Seçin(*.txt)|*.txt";
            openFileDialog1.FilterIndex = 1;
            try
            {
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openFileDialog1.CheckFileExists)
                    {
                        string path = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                        v = new Veri();
                        data = v.Oku(path, ';');
                        DataGridVeriEkle(dataGridView1, data);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen belgeyi karşıya yükleyin.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private IMetric SecilenMetrik()
        {
            if (cbox_metric.SelectedIndex == 0)
            {
                return new SquareCord();
            }
            else if (cbox_metric.SelectedIndex == 2)
            {
                return new Canberra();
            }
            else
            {
                return new Minkowski(double.Parse(txt_pDegeri.Text));
            }
        }

        private void DataGridVeriEkle(DataGridView dtGridView, double[][] tempData)
        {
            DataGridVeriTemizle(dtGridView);
            dtGridView.ColumnCount = tempData[0].Length + 1;
            int siraNo = 1;
            for (int i = 0; i < tempData.Length; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dtGridView);
                for (int j = 1; j < dtGridView.ColumnCount; j++)
                {
                    row.Cells[0].Value = siraNo;
                    row.Cells[j].Value = tempData[i][j-1];
                }
                dtGridView.Rows.Add(row);
                siraNo++;
            }
        }

        private void DataGridVeriTemizle(DataGridView dtGridView)
        {
            if (dtGridView.Columns.Count>0)
            {
                dtGridView.Columns.Clear();
            }
            
        }
        private bool Kontrol()
        {
            if (string.IsNullOrEmpty(txt_knnKDegeri.Text) || (txt_pDegeri.Visible==true && string.IsNullOrEmpty(txt_pDegeri.Text)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
