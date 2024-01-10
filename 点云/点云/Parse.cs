using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 点云
{
    class Parse
    {
       public  List<DataEntity> data = new List<DataEntity>();
        public int num;
        public void parse(string line)
        {
            string[] lines = line.Replace('\t',',').Split(',');
            DataEntity d = new DataEntity();
            d.X = Convert.ToDouble(lines[0]);
            d.Y = Convert.ToDouble(lines[1]);
            d.Z = Convert.ToDouble(lines[2]);
            data.Add(d);
        }
    }
}
