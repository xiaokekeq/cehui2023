using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 纵断面27
{
    class Parse
    {
        public string Hid;
        public double Hv;
        public List<DataEntity> K = new List<DataEntity>();
        public List<DataEntity> AB = new List<DataEntity>();
        public List<DataEntity> data = new List<DataEntity>();
        public void parse(string line)
        {
            string[] lines = line.Split(',');
            DataEntity d = new DataEntity();
            d.ID = lines[0];
            d.X = Convert.ToDouble(lines[1]);
            d.Y = Convert.ToDouble(lines[2]);
            d.H = Convert.ToDouble(lines[3]);
            data.Add(d);
        }
    }
}
