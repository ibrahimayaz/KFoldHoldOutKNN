using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFoldAndRandomSampling
{
    public class SquareCord : IMetric
    {
        public double Dist(double[] x, double[] y)
        {
            double sonuc = 0;
            for (int i = 0; i < x.Length; i++)
            {
                sonuc += Math.Pow(Math.Sqrt(x[i]) - Math.Sqrt(y[i]),2);
            }
            return sonuc;
        }
    }
}
