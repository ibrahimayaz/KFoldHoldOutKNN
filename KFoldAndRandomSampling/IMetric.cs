using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFoldAndRandomSampling
{
    public interface IMetric
    {
        double Dist(double[] x, double[] y);
    }
}
