using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 栅格数据的领域计算
{
    internal class Parse
    {
        public List<DataEntity> data=new List<DataEntity>();
        public void parse(string line)
        {
            DataEntity d=new DataEntity();
            line = line.Replace("\t", ",");      
            string[] lines = line.Split(',');
            double[,] matrix = new double[1, lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                
                matrix[0, i] = Convert.ToDouble(lines[i]);
                d.X= matrix;
            }
            data.Add(d);
        }
    }
}
