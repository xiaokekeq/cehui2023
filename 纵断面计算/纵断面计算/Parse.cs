using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 纵断面计算
{
    internal class Parse
    {
        public string refName;
        public double refH;
        public List<dataEntity> AB=new List<dataEntity>();
        public List<dataEntity> dataK=new List<dataEntity>();
        public List<dataEntity> data=new List<dataEntity>();
        public void parse(string line)
        {
            dataEntity d = new dataEntity();
            string[] lines = line.Split(',');
            d.Id = lines[0];
            d.X = Convert.ToDouble(lines[1]);
            d.Y = Convert.ToDouble(lines[2]);
            d.H= Convert.ToDouble(lines[3]);
            data.Add(d);
        }
    }
}
