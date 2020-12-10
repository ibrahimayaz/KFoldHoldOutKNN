
using System.Linq;
using System.IO;

namespace KFoldAndRandomSampling
{
    public class Veri
    {
     
        public static double[][] Oku(string filePath, char ayrac)
        {
            var temp_data = from row in File.ReadAllLines(filePath)
            select (row.Split(ayrac)).ToList();
            var veri = new double[temp_data.Count()][];
            int satir = 0;
            foreach (var item in temp_data)
            {
                veri[satir] = new double[item.Count];
                for (int kolon = 0; kolon < item.Count; kolon++)
                {
                    veri[satir][kolon] = double.Parse(item[kolon]);
                }
                satir++;
            }
       
            return veri;
        }
    }
}
