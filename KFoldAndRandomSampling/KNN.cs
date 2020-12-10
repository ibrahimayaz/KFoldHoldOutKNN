using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFoldAndRandomSampling
{
    public class KNN
    {
        public int K { get; set; }
        public IMetric Metric { get; set; }
        public KNN(int k, IMetric metric)
        {
            K = k;
            Metric = metric;
        }

        public double Classifier(Veri v)
        {

            double[][] uzakliklar = new double[v.xTrain.Length][];

            for (int i = 0; i < v.Data.Length; i++)
            {
                uzakliklar[i] = new double[2];
            }

            double dogruluk = 0, puan = 0, testSayisi = 0;

            for (var i = 0; i < v.xTest.Length; i++)
            {
                for (int j = 0; j < v.xTrain.Length; j++)
                {
                    uzakliklar[j][0] = Metric.Dist(v.xTest[i], v.xTrain[j]);
                    uzakliklar[j][1] = i;
                }

                var siralanmisUzakliklar = uzakliklar.OrderBy(x => x[0]).Take(K);

                var gercekSinif = v.yTest[i];


                foreach (var item in siralanmisUzakliklar)
                {
                    var tahminEdilenSinif = (int)v.yTrain[(int)item[1]];
                    if (gercekSinif == tahminEdilenSinif)
                    {
                        puan++;
                    }
                    testSayisi++;
                }
            }

            dogruluk = (puan / testSayisi) * 100;
            return dogruluk;
        }



        public List<double[]> Classifier2(Veri v, double[] newDataItem)
        {
            var tempData = new double[v.Data.Length][];

            int index = 0;
            foreach (var item in v.Data)
            {
                tempData[index] = new double[item.Length-1];
                for (int j = 1; j < item.Length; j++)
                {
                    tempData[index][j-1] = item[j];
                }
                index++;
            }
            double[][] distances = new double[v.Data.Length][];            

            for (int i = 0; i < tempData.Length; i++)
            {
                distances[i] = new double[3];
                distances[i][0] = Metric.Dist(newDataItem, tempData[i]);
                distances[i][1] = i;
                distances[i][2] = v.Data[i][0];
            }
            return distances.OrderBy(x => x[0]).Take(K).ToList();
        }


    }
}
