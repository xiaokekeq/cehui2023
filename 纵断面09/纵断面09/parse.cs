using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 纵断面09
{
    class parse
    {
        public string referID;
        public double referH;
        public List<DataEntity> AB = new List<DataEntity>();
        public List<DataEntity> data = new List<DataEntity>();
        public List<DataEntity> K = new List<DataEntity>();
        public void Parse(string line)
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
