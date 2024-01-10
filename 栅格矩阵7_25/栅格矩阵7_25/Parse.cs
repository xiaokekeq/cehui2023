using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 栅格矩阵7_25
{
    class Parse
    {
        public List<DataEntity> data = new List<DataEntity>();
        public void parse(string line)
        {
            string[] lines = line.Replace("\t",",").Split(',');
            DataEntity d = new DataEntity();
            double[,] matrix = new double[lines.Count(),1];
            for (int i = 0; i < lines.Count(); i++)
            {
                matrix[i, 0] = Convert.ToDouble(lines[i]);
            }
            d.X = matrix;
            data.Add(d);
        }
    }
}
