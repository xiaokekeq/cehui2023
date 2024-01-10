using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 大地主题正反算_25
{
    class Parse
    {
        public double a;
        public double f;
       public List<DataEntity> data = new List<DataEntity>();
        public public_Algo public_Algo = new public_Algo();
        public void parse1(string line)
        {
            string[] lines = line.Split(',');
            DataEntity d = new DataEntity();
            d.StartID = lines[0];
            d.B1 = public_Algo.DFM2RAD(Convert.ToDouble(lines[1]));
            d.L1 = public_Algo.DFM2RAD(Convert.ToDouble(lines[2]));
            d.EndID = lines[3];
            d.B2 = public_Algo.DFM2RAD(Convert.ToDouble(lines[4]));
            d.L2 = public_Algo.DFM2RAD(Convert.ToDouble(lines[5]));
            data.Add(d);
        }
        public void parse2(string line)
        {
            string[] lines = line.Split(',');
            DataEntity d = new DataEntity();
            d.StartID = lines[0];
            d.B1 = public_Algo.DFM2RAD(Convert.ToDouble(lines[1]));
            d.L1 = public_Algo.DFM2RAD(Convert.ToDouble(lines[2]));
            d.A12 = public_Algo.DFM2RAD(Convert.ToDouble(lines[3]));
            d.S =(Convert.ToDouble(lines[4]));
            d.EndID = lines[5];
            data.Add(d);
        }
    }
}
