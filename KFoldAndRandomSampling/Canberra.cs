using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFoldAndRandomSampling
{
    public class Canberra : IMetric
    {
        public double Dist(double[] x, double[] y)
        {
            double sonuc = 0;
            for (int i = 0; i < x.Length; i++)
            {
                sonuc += Math.Abs(x[i] - y[i])/ x[i] + y[i];
            }
            return sonuc;
        }
    }
}
