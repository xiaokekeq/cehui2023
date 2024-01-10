using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zf_028
{
    class Parse
    {
        public double a;
        public double f;
        public List<DataEntity> data = new List<DataEntity>();
        public Public_Algo public_algo = new Public_Algo();
        public void parseZ(string line)
        {
            string[] lines = line.Split(',');
            DataEntity d = new DataEntity();
            d.StartID = lines[0];
            d.B1 = public_algo.DSM2RAD(Convert.ToDouble(lines[1]));
            d.L1 = public_algo.DSM2RAD(Convert.ToDouble(lines[2]));
            d.A12 = public_algo.DSM2RAD(Convert.ToDouble(lines[3]));
            d.S = Convert.ToDouble(lines[4]);
            d.EndID = (lines[5]);
            data.Add(d);
        }
        public void parseF(string line)
        {
            string[] lines = line.Split(',');
            DataEntity d = new DataEntity();
            d.StartID = lines[0];
            d.B1 = public_algo.DSM2RAD (Convert.ToDouble(lines[1]));
            d.L1 = public_algo.DSM2RAD(Convert.ToDouble(lines[2]));
            d.EndID = lines[3];
            d.B2 = public_algo.DSM2RAD (Convert.ToDouble(lines[4]));
            d.L2 = public_algo.DSM2RAD (Convert.ToDouble(lines[5]));
            data.Add(d);
        }
    }
}
