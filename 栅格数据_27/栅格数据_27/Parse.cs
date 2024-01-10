using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 栅格数据_27
{
    class Parse
    {
        public List<DataEntity> data = new List<DataEntity>();
        public void parse(string line)
        {
            string[] lines = line.Replace("\t", ",").Split(',');
            double[,] matrix = new double[1,lines.Count()];
            DataEntity d = new DataEntity();
            for (int i = 0; i < lines.Count(); i++)
            { 
                matrix[0, i] = Convert.ToDouble(lines[i]);
            }
            d.X = matrix;
            data.Add(d);
        }
    }
}
