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
                lbl_veriyiBolme.Text = "K Değeri";
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
                lbl_veriyiBolme.Text = "K Değeri";
            }
            else
            {
                lbl_veriyiBolme.Text = "Test Oranı %";
            }
        }

        private void btn_hesapla2_Click(object sender, EventArgs e)
        {
            if (cbox_veriyiBolmeTipi.SelectedIndex == 0)
            {
                KFold kf = new KFold(v.Data, int.Parse(txt_bolmeDegeri.Text));
                kf.Fold();
                double[] accScore = new double[int.Parse(txt_bolmeDegeri.Text)];
                for (int i = 0; i < int.Parse(txt_bolmeDegeri.Text); i++)
                {
                    var currentFoldData=kf.FoldCalculate(i);
                    v.xTrain = currentFoldData.xTrain;
                    v.yTrain = currentFoldData.yTrain;
                    v.xTest = currentFoldData.xTest;
                    v.yTest = currentFoldData.yTest;
                    KNN knn = new KNN(int.Parse(txt_knnKDegeri2.Text), v, SecilenMetrik());
                    accScore[i]=knn.Classifier();
                    DataGridVeriEkle(dataGridView1, currentFoldData.xTrain);
                    DataGridVeriEkle(dataGridView2, currentFoldData.xTest);
                }
            }
            else
            {
                RandomSampling rs = new RandomSampling(data, double.Parse(txt_bolmeDegeri.Text));

                DataGridVeriEkle(dataGridView1, v.Data);
                DataGridVeriEkle(dataGridView2, v.Data);
            }
        }

        private void btn_hesapla_Click(object sender, EventArgs e)
        {
            double[] yeniVeri = new double[v.Data[0].Length - 1];
            string[] veri = txt_yeniVeri.Text.Split(';');
            if (v.Data[0].Length-1 == veri.Length)
            {
                for (int i = 0; i < veri.Length; i++)
                {
                    yeniVeri[i] = double.Parse(veri[i]);
                }

                //13,24;2,59;2,87;21;118;2,8;2,69;0,39;1,82;4.32;1,04;2,93;735

                KNN knn = new KNN(int.Parse(txt_knnKDegeri.Text), v, SecilenMetrik());
                var r = knn.Classifier2(yeniVeri);
                dataGridView1.Rows.Clear();
                dataGridView2.Rows.Clear();
                dataGridView1.DataSource = r.Item1.Select(x =>
                     new
                     {
                         Uzaklik = x[0],
                         Index = x[1],
                         Sinif = x[2]
                     }).ToList();

                MessageBox.Show("Tahmin Edilen Sınıf: " + r.Item2);
            }
            else
            {
                MessageBox.Show("Veri Setinin kolon sayısı ile girilen yeni değer dizinin uzunluğu("+ veri.Length.ToString() +") birbiriyle uyuşmamaktadır.");
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
            else
            {
                return new Minkowski(int.Parse(txt_pDegeri.Text));
            }
        }

        private void DataGridVeriEkle(DataGridView dtGridView, double[][] tempData)
        {
            dtGridView.Rows.Clear();
            dtGridView.ColumnCount = tempData[0].Length;
            for (int i = 0; i < tempData.Length; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dtGridView);
                for (int j = 0; j < tempData[i].Length; j++)
                {
                    row.Cells[j].Value = tempData[i][j];
                }
                dtGridView.Rows.Add(row);
            }
        }
    }
}
