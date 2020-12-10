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
                lbl_veriyiBolme.Text = "Test Oranı";
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
                lbl_veriyiBolme.Text = "Test Oranı";
            }
        }

        private void btn_hesapla2_Click(object sender, EventArgs e)
        {
            Veri v = new Veri();
            var data = v.Oku(@"../../wine_data.txt", ';');
            if (cbox_metric.SelectedIndex == 0)
            {
                KFold kf = new KFold(data, int.Parse(txt_bolmeDegeri.Text));
                kf.Fold();
                for (int i = 0; i < int.Parse(txt_bolmeDegeri.Text); i++)
                {
                    dataGridView1.DataSource = kf.FoldCalculate(i).Item1.Select((x, y) => new
                    {
                        Sira = y + 1,
                        MalicAcid = x[0],
                        Ash = x[1],
                        AlcalinityOfAsh = x[2],
                        Magnesium = x[3],
                        TotalPhenols = x[4],
                        Flavanoids = x[5],
                        NonflavanoidPhenols = x[6],
                        Proanthocyanins = x[7],
                        ColorIntensity = x[8],
                        Hue = x[9],
                        DilutedWines = x[10],
                        Proline = x[11],
                    }).ToList();

                    dataGridView2.DataSource = kf.FoldCalculate(i).Item3.Select((x, y) => new
                    {
                        Sira = y + 1,
                        MalicAcid = x[0],
                        Ash = x[1],
                        AlcalinityOfAsh = x[2],
                        Magnesium = x[3],
                        TotalPhenols = x[4],
                        Flavanoids = x[5],
                        NonflavanoidPhenols = x[6],
                        Proanthocyanins = x[7],
                        ColorIntensity = x[8],
                        Hue = x[9],
                        DilutedWines = x[10],
                        Proline = x[11],
                    }).ToList();

                }
            }
            else
            {
                RandomSampling rs = new RandomSampling(data, double.Parse(txt_bolmeDegeri.Text));

                dataGridView1.DataSource = rs.Split2().Item1.Select((x, y) => new
                {
                    Sira = y + 1,
                    MalicAcid = x[0],
                    Ash = x[1],
                    AlcalinityOfAsh = x[2],
                    Magnesium = x[3],
                    TotalPhenols = x[4],
                    Flavanoids = x[5],
                    NonflavanoidPhenols = x[6],
                    Proanthocyanins = x[7],
                    ColorIntensity = x[8],
                    Hue = x[9],
                    DilutedWines = x[10],
                    Proline = x[11],
                }).ToList();

                dataGridView2.DataSource = rs.Split().Item3.Select((x, y) => new
                {
                    Sira = y + 1,
                    MalicAcid = x[0],
                    Ash = x[1],
                    AlcalinityOfAsh = x[2],
                    Magnesium = x[3],
                    TotalPhenols = x[4],
                    Flavanoids = x[5],
                    NonflavanoidPhenols = x[6],
                    Proanthocyanins = x[7],
                    ColorIntensity = x[8],
                    Hue = x[9],
                    DilutedWines = x[10],
                    Proline = x[11],
                }).ToList();
            }
        }

        private void btn_hesapla_Click(object sender, EventArgs e)
        {
            Veri v = new Veri();
            var data = v.Oku(@"../../breast_canser.txt", ';');

            double[] veri2 = new double[data[0].Length - 1];
            string[] veri = textBox1.Text.Split(';');
            for (int i = 0; i < veri.Length; i++)
            {
                veri2[i] = double.Parse(veri[i]);
            }

            //13,24;2,59;2,87;21;118;2,8;2,69;0,39;1,82;4.32;1,04;2,93;735

            KNN knn;
            if (cbox_metric.SelectedIndex == 0)
            {
                knn = new KNN(int.Parse(txt_bolmeDegeri.Text), new SquareCord());
            }
            else
            {
                knn = new KNN(int.Parse(txt_bolmeDegeri.Text), new Minkowski(int.Parse(txt_pDegeri.Text)));
            }


            dataGridView1.DataSource = knn.Classifier2(v, veri2).Select(x =>
                 new
                 {
                     Uzaklik = x[0],
                     Index = x[1],
                     Sinif = x[2]

                 }).ToList();
        }
    }
}
