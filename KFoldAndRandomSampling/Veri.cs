
using System.Linq;
using System.IO;

namespace KFoldAndRandomSampling
{
    public class Veri
    {
        public double[][] Data { get; set; }
        public double[][] xTrain { get; set; }
        public double[] yTrain { get; set; }
        public double[][] xTest { get; set; }
        public double[] yTest { get; set; }

        public double[][] Oku(string filePath, char ayrac)
        {
            var temp_data = from row in File.ReadAllLines(filePath)
            select (row.Split(ayrac)).ToList();
            Data = new double[temp_data.Count()][];
            int satir = 0;
            foreach (var item in temp_data)
            {
                Data[satir] = new double[item.Count];
                for (int kolon = 0; kolon < item.Count; kolon++)
                {
                    Data[satir][kolon] = double.Parse(item[kolon]);
                }
                satir++;
            }
       
            return Data;
        }


        /// <summary>
        /// Bu fonksiyonun amacı verinin özniteliklerini ve sınıfnı bir birinden ayırır.
        /// ÖNEMLİ NOT: Sınıf kolonu verinin ilk sütununda olmak zorundadır.
        /// </summary>
        /// <param name="train"></param>
        /// <param name="test"></param>
        /// <returns></returns>
        public (double[][], double[], double[][], double[]) DataSplit(double[][] train, double[][] test)
        {
           
            xTrain = new double[train.Length][];
            yTrain = new double[train.Length];
            xTest = new double[test.Length][];
            yTest = new double[test.Length];
            int r = 0;
            foreach (var item in test)
            {
                xTest[r] = new double[item.Length - 1];
                for (int c = 1; c < item.Length; c++)
                {
                    xTest[r][c - 1] = item[c];
                    yTest[r] = item[0];
                }
                r++;
            }

            r = 0;
            foreach (var item in train)
            {
                xTrain[r] = new double[item.Length - 1];
                for (int c = 1; c < item.Length; c++)
                {
                    xTrain[r][c - 1] = item[c];
                    yTrain[r] = item[0];
                }
                r++;
            }


            return (xTrain, yTrain, xTest, yTest);
        }
    }
}
