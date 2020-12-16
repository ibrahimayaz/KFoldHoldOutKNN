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
           
            double[][] distances = new double[V.xTrain.Length][];
            double correct = 0;

            for (var i = 0; i < V.xTest.Length; i++)
            {
                for (int j = 0; j < V.xTrain.Length; j++)
                {
                    distances[j] = new double[3];
                    distances[j][0] = Metric.Dist(V.xTest[i], V.xTrain[j]);
                    distances[j][1] = i;
                    distances[j][2] = V.yTrain[j];
                }

                var orderedDistances = distances.OrderBy(x => x[0]).Take(K).ToList();
                var classNameGroups = orderedDistances.GroupBy(x => x[2]).Select(x => new
                {
                    ClassName = x.Key,
                    Count = x.Count()
                }).ToList();

                var predictedClass = classNameGroups.OrderByDescending(x => x.Count).Select(x => x.ClassName).Take(1).ToArray()[0];
                var realClass = V.yTest[i];

                if (predictedClass == realClass)
                {
                    correct++;
                }
            }

            return (correct / V.xTest.Length) * 100;


        }


        public (List<double[]>, string) Classifier2(double[] newDataItem)
        {
            var tempData = new double[V.Data.Length][];

            int index = 0;
            foreach (var item in V.Data)
            {
                tempData[index] = new double[item.Length - 1];
                for (int j = 1; j < item.Length; j++)
                {
                    tempData[index][j - 1] = item[j];
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
            var orderedDistances = distances.OrderBy(x => x[0]).Take(K).ToList();
            var classNameGroups = orderedDistances.GroupBy(x => x[2]).Select(x => new
            {
                ClassName = x.Key,
                Count = x.Count()
            }).ToList();

            var predictedClassName = classNameGroups.OrderByDescending(x => x.Count).Select(x => x.ClassName).Take(1).ToArray()[0];
            return (orderedDistances, predictedClassName.ToString());
        }
    }
}
