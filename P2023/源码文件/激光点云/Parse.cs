using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 激光点云
{
    class Parse
    {
        public double num;
        public List<DataEntity> data = new List<DataEntity>();
        public void parse(string line)
        {
            string[] lines = line.Split(',');
            DataEntity d = new DataEntity();
            d.ID = lines[0];
            d.X = Convert.ToDouble(lines[1]);
            d.Y = Convert.ToDouble(lines[2]);
            d.Z = Convert.ToDouble(lines[3]);
            data.Add(d);
        }
    }
}
