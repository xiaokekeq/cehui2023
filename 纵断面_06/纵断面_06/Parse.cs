using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 纵断面_06
{
    class Parse
    {
        public string referID;
        public double referH;
        public List<DataEntity> K = new List<DataEntity>();
        public List<DataEntity> AB = new List<DataEntity>();
        public List<DataEntity> data = new List<DataEntity>();
        public void parse(string line)
        {
            DataEntity d = new DataEntity();
            string[] lines = line.Split(',');
            d.ID = lines[0];
            d.X = Convert.ToDouble(lines[1]);
            d.Y = Convert.ToDouble(lines[2]);
            d.H = Convert.ToDouble(lines[3]);
            data.Add(d);
        }
    }
}
