using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KFoldAndRandomSampling
{

    /// <summary>
    /// Normalizasyon, verileri 0 ve 1 arasında yeniden ölçekler. 
    /// Bu işlem tüm parametrelerin aynı pozitif ölçeğe sahip olması gereken bazı durumlarda 
    /// yararlı olabilir. Ancak aykırı değerlerin (outliers) kaybolmasına yol açar.
    /// En sık kullanılan normalizasyon yöntemlerinden biri olan 
    /// Feature Scaling, (Özellik Ölçekleme veya Min-Max Normalizasyonu) normal dağılımı esas alır
    /// ve her bir değerin ortalamadan olan uzaklığının standart sapmaya oranı ile bulunur.
    /// https://medium.com/@aokanarik/makine-%C3%B6%C4%9Frenmesinde-veri-normalizasyonu-ve-standardizasyonu-827c5142b050
    /// </summary>
    public class FeatureScaling : INormalization
    {
        
        public double[][] Normalize(double[][] data)
        {
            double[][] Data = new double[data.Length][];
            var minMax = EnBuyukEnKucuk(data);
            int satir = 0;
            foreach (var item in data)
            {
                Data[satir] = new double[item.Length];
                for (int kolon = 0; kolon < item.Length; kolon++)
                {
                    Data[satir][kolon] = Math.Abs(item[kolon] - minMax.tempMinArg[kolon]) / (minMax.tempMaxArg[kolon] - minMax.tempMinArg[kolon]);
                }
                satir++;
            }
            return Data;
        }

    
        private (double[] tempMaxArg, double[] tempMinArg) EnBuyukEnKucuk(double[][] data)
        {
            double[] tempMaxArg = new double[data[0].Length];
            double[] tempMinArg = new double[data[0].Length];
            for (int i = 0; i < data[0].Length; i++)
            {
                double tempMax = data[0][i];
                double tempMin = data[0][i];
                for (int j = 0; j < data.Length; j++)
                {
                    if (tempMax < data[j][i])
                    {
                        tempMax = data[j][i];
                    }

                    if (data[j][i] < tempMin)
                    {
                        tempMin = data[j][i];
                    }
                }
                tempMaxArg[i] = tempMax;
                tempMinArg[i] = tempMin;
            }

            return (tempMaxArg, tempMinArg);        
        }
    }
}
