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
        public Veri V { get; set; }

        public KNN(int k, Veri v, IMetric metric)
        {
            K = k;
            Metric = metric;
            V = v;
        }

        public double Classifier()
        {

            double[][] uzakliklar = new double[V.xTrain.Length][];

            for (int i = 0; i < V.xTrain.Length; i++)
            {
                uzakliklar[i] = new double[2];
            }

            double dogruluk = 0, puan = 0, testSayisi = 0;

            for (var i = 0; i < V.xTest.Length; i++)
            {
                for (int j = 0; j < V.xTrain.Length; j++)
                {
                    uzakliklar[j][0] = Metric.Dist(V.xTest[i], V.xTrain[j]);
                    uzakliklar[j][1] = i;
                }

                var siralanmisUzakliklar = uzakliklar.OrderBy(x => x[0]).Take(K);

                var gercekSinif = V.yTest[i];

                foreach (var item in siralanmisUzakliklar)
                {
                    var tahminEdilenSinif = (int)V.yTrain[(int)item[1]];
                    if (gercekSinif == tahminEdilenSinif)
                    {
                        puan++;
                    }
                    testSayisi++;
                }
            }

            return (puan / testSayisi) * 100;
        }


        public (List<double[]>, string) Classifier2(double[] newDataItem)
        {
            var tempData = new double[V.Data.Length][];

            int index = 0;
            foreach (var item in V.Data)
            {
                tempData[index] = new double[item.Length-1];
                for (int j = 1; j < item.Length; j++)
                {
                    tempData[index][j-1] = item[j];
                }
                index++;
            }
            double[][] distances = new double[V.Data.Length][];            

            for (int i = 0; i < tempData.Length; i++)
            {
                distances[i] = new double[3];
                distances[i][0] = Metric.Dist(newDataItem, tempData[i]);
                distances[i][1] = i;
                distances[i][2] = V.Data[i][0];
            }
            var resultTable = distances.OrderBy(x => x[0]).Take(K).ToList();
            var classNameGroups = resultTable.GroupBy(x => x[2]).Select(x => new
            {
                ClassName=x.Key,
                Count=x.Count()
            }).ToList();

            var resultClassName= classNameGroups.OrderByDescending(x=>x.Count).Select(x=>x.ClassName).Take(1).ToArray();
            return (resultTable, resultClassName[0].ToString());
        }


    }
}
