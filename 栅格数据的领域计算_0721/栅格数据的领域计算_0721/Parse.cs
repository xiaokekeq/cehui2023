using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 栅格数据的领域计算_0721
{
    class Parse
    {
        public List<DataEntity> data = new List<DataEntity>();
        public void parse(string line)
        {
            string[] lines = line.Replace('\t', ',').Split(',');
            DataEntity d = new DataEntity();
            double[,] Matrix = new double[1, lines.Count()];
            for (int i = 0; i < lines.Count(); i++)
            {
                Matrix[0, i] = Convert.ToDouble(lines[i]);
                d.X = Matrix;
            }
            data.Add(d);
        }
    }
}
