using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFoldAndRandomSampling
{
    public class RandomSampling
    {
        public double Rate { get; set; }
        public double[][] Data { get; set; }
        public RandomSampling(double[][] data, double rate)
        {
            Rate = rate;
            Data = data;
        }

        /// <summary>
        /// Veriyi önce ratgele karıştırır. Sonra oranına göre böler.
        /// </summary>
        /// <returns>xTrain, yTrain, xTest, yTest</returns>
        public (double[][], double[], double[][], double[]) Split()
        {

            var testCount = Math.Round(Data.Length * Rate / 100);
            var trainCount = Data.Length - testCount;

            var newTempData = new double[Data.Length][];
            newTempData = Data.OrderBy(x => Guid.NewGuid()).ToArray();

            var test = new double[int.Parse(testCount.ToString())][];
            test = newTempData.Take(int.Parse(testCount.ToString())).ToArray();

            var train = new double[int.Parse(trainCount.ToString())][];
            train = newTempData.Skip(int.Parse(testCount.ToString())).ToArray();
            return new Veri().DataSplit(train, test);
        }

        /// <summary>
        /// Veriyi oranına göre böler, test kısmına mümkün olduğunca eşit sayıda sınıf verisi ekler.
        /// </summary>
        /// <returns>xTrain, yTrain, xTest, yTest</returns>
        public (double[][] xTrain, double[] yTrain, double[][] xTest, double[] yTest) Split2()
        {

            var testCount = Math.Round(Data.Length * Rate / 100);

            double[] y = new double[Data.Length];
            for (int i = 0; i < Data.Length; i++)
            {
                y[i] = Data[i][0];
            }
            var classNames = y.Distinct().ToArray();
            var groups = new List<List<double[]>>();

            for (int j = 0; j < classNames.Length; j++)
            {
                var g = new List<double[]>();
                for (int i = 0; i < Data.Length; i++)
                {
                    if (classNames[j] == Data[i][0])
                    {
                        g.Add(Data[i]);
                    }
                }
                groups.Add(g);
            }
            List<List<double[]>> tempAllData = new List<List<double[]>>();


            var testData = new List<double[]>();
            var durum = true;
            while (durum)
            {
                for (int j = 0; j < classNames.Length; j++)
                {
                    for (int g = 0; g < groups[j].Count; g++)
                    {
                        if (testData.Count < testCount)
                        {
                            testData.Add(groups[j][g]);
                            groups[j].RemoveAt(g);
                            durum = true;
                        }
                        else
                        {
                            durum = false;
                        }
                        break;
                    }
                }
            }
            tempAllData.Add(testData);
            var trainData = new List<double[]>();
            durum = true;
            while (durum)
            {
                for (int i = 0; i < classNames.Length; i++)
                {
                    durum = groups[i].Count == 0 ? false : true;
                    for (int j = 0; j < groups[i].Count; j++)
                    {
                        trainData.Add(groups[i][j]);
                        groups[i].RemoveAt(j);
                    }
                }
            }
            tempAllData.Add(trainData);


            var test = tempAllData[0].OrderBy(x => Guid.NewGuid()).ToArray();
            var train = tempAllData[1].OrderBy(x => Guid.NewGuid()).ToArray();

            return new Veri().DataSplit(train, test);
        }

    }
}
