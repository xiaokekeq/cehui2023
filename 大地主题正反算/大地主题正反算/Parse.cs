using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 大地主题正反算
{
    class Parse
    {
        public double a;
        public double f;
        public public_algo public_Algo = new public_algo();
        public List<DataEntity> dataZ = new List<DataEntity>();
        public List<DataEntity> dataF = new List<DataEntity>();

        public void parseZ(string line)
        {
            DataEntity d = new DataEntity();
            string[] lines = line.Split(',');
            d.ID1 = lines[0];
            d.B1 = public_Algo.dms2RAD(Convert.ToDouble(lines[1]));
            d.L1 = public_Algo.dms2RAD(Convert.ToDouble(lines[2]));
            d.A12 = public_Algo.dms2RAD(Convert.ToDouble(lines[3]));
            d.S = Convert.ToDouble(lines[4]);
            d.ID2 = lines[5];
            dataZ.Add(d);
        }
        public void parseF(string line)
        {
            DataEntity d = new DataEntity();
            string[] lines = line.Split(',');
            d.ID1 = lines[0];
            d.B1 = public_Algo.dms2RAD(Convert.ToDouble(lines[1]));
            d.L1 = public_Algo.dms2RAD(Convert.ToDouble(lines[2]));
            d.ID2 = lines[3];
            d.B2 = public_Algo.dms2RAD(Convert.ToDouble(lines[4]));
            d.L2 = public_Algo.dms2RAD(Convert.ToDouble(lines[5]));
            dataF.Add(d);
        }
    }
}
