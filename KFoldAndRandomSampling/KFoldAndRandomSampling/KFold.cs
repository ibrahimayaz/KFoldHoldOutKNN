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
        public List<double[][]> FoldData { get; set; }
        public KFold(double[][] data, int k)
        {
            Data = data;
            K = k;
            Fold();
        }

        public void Fold()
        {
            FoldData = new List<double[][]>();
            var remainingDataCount = Data.Length % K;
            var foldCount = Data.Length / K;
            
            var newTempData = new double[Data.Length][];
            newTempData = Data.OrderBy(x => Guid.NewGuid()).ToArray();

            double[] y = new double[Data.Length];
            for (int i = 0; i < newTempData.Length; i++)
            {
                y[i] = newTempData[i][0];
            }

            var classData = y.Distinct().ToArray();
            for (int i = 0; i < newTempData.Length; i++)
            {
                for (int j = 0; j < classData.Length; j++)
                {

                }
            }

            

           
            //for (int i = 0; i < K; i++)
            //{
            //    FoldData.Add(newTempData.Skip(i * foldCount).Take(foldCount).ToArray());
            //}

          

        }

    }
}
