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
        /// 
        /// </summary>
        /// <returns>Test, Train</returns>
        public (double[][], double[][]) Split()
        {

            var testCount   = Math.Round(Data.Length * Rate / 100);
            var trainCount  = Data.Length - testCount;

            var newTempData = new double[Data.Length][];
            newTempData = Data.OrderBy(x => Guid.NewGuid()).ToArray();

            var test = new double[int.Parse(testCount.ToString())][];
            test = newTempData.Take(int.Parse(testCount.ToString())).ToArray();

            var train = new double[int.Parse(trainCount.ToString())][];
            train = newTempData.Skip(int.Parse(testCount.ToString())).ToArray();

            return (test, train);
        }
       
    }
}
