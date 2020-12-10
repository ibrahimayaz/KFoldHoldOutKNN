using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFoldAndRandomSampling
{
    public class KFold
    {
        private int K { get; set; }
        private double[][] Data { get; set; }
        private List<List<double[]>> FoldData { get; set; }
        public KFold(double[][] data, int k)
        {
            Data = data;
            K = k;
        }

        public List<List<double[]>> Fold()
        {
            var remainingDataCount = Data.Length % K;
            var foldCount = Data.Length / K;

            var newTempData = new double[Data.Length][];
            var a = Guid.NewGuid();
            newTempData = Data.OrderBy(x => Guid.NewGuid()).ToArray();

            double[] y = new double[Data.Length];
            for (int i = 0; i < newTempData.Length; i++)
            {
                y[i] = newTempData[i][0];
            }
            var classNames = y.Distinct().ToArray();
            var groups = new List<List<double[]>>();

            for (int j = 0; j < classNames.Length; j++)
            {
                var g = new List<double[]>();
                for (int i = 0; i < newTempData.Length; i++)
                {
                    if (classNames[j] == newTempData[i][0])
                    {
                        g.Add(newTempData[i]);
                    }
                }
                groups.Add(g);
            }
            FoldData = new List<List<double[]>>();

            for (int i = 0; i < K; i++)
            {
                var tempData = new List<double[]>();
                var durum = true;
                while (durum)
                {
                    for (int j = 0; j < classNames.Length; j++)
                    {
                        for (int g = 0; g < groups[j].Count; g++)
                        {
                            if (tempData.Count<foldCount)
                            {
                                tempData.Add(groups[j][g]);
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
                FoldData.Add(tempData);
            }

            if (remainingDataCount>0)
            {
                for (int i = 0; i < FoldData.Count; i++)
                {
                    for (int j = 0; j < classNames.Length; j++)
                    {
                        for (int g = 0; g < groups[j].Count; g++)
                        {
                            FoldData[i].Add(groups[j][g]);
                            groups[j].RemoveAt(g);
                            break;
                        }
                        if (groups[j].Count != 0)
                        {
                            break;
                        }

                    }                  
                }
            }


            return FoldData;
        }

        public (double[][], double[], double[][], double[]) FoldCalculate(int foldTestNumber)
        {
            var test = FoldData[foldTestNumber].OrderBy(x => Guid.NewGuid()).ToArray();
            var tempTrain = new List<List<double[]>>();
            var tempData = new List<double[]>();
            for (int i = 0; i < K; i++)
            {
                if (i!=foldTestNumber)
                {
                    for (int j = 0; j < FoldData[i].Count; j++)
                    {
                        tempData.Add(FoldData[i][j]);
                    }
                }
            }

           var train = tempData.ToArray();
           return new Veri().DataSplit(train, test);
        }

    }
}
