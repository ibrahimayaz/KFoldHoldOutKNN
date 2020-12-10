using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFoldAndRandomSampling
{
    public class Minkowski:IMetric
    {
        private int P { get; set; }
        public Minkowski(int p)
        {
            P = p;
        }
        /// <summary>
        /// Minkowski Uzaklığı
        /// p=1 olursa  Manhattan, p=2 olursa Öklid uzaklığını almış olursunuz
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="p">p>=1 olmak zorundadır ve p değerini girmek zorunlu değildir, girilmediği taktirde p=2 olur.</param>
        /// <returns></returns>
        public double Dist(double[] x, double[] y)
        {
            double sonuc = 0;
            for (int i = 0; i < x.Length; i++)
            {
                sonuc += Math.Pow(Math.Abs(x[i] - y[i]), P);
            }
            return Math.Pow(sonuc, 1 / P);
        }

        
    }
}
