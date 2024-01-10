using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 大地正反算
{
    class Parse
    {
        public double a;
        public double f;
        public double LonTest;
        public double LatTest;
        public List<DataEntity> reverseData = new List<DataEntity>();
        public List<DataEntity> zcalData = new List<DataEntity>();
        public_algo public_Algo = new public_algo();
        public void parse(string line)
        {
            string[] lines = line.Split(',');
            DataEntity tmp = new DataEntity();
            tmp.Sp = lines[0];
            tmp.LonS = public_Algo.DMS2RAD(Convert.ToDouble(lines[1]));
            tmp.LatS = public_Algo.DMS2RAD(Convert.ToDouble(lines[2]));
            tmp.Ep = lines[3];
            tmp.LonE = public_Algo.DMS2RAD(Convert.ToDouble(lines[4]));
            tmp.LatE = public_Algo.DMS2RAD(Convert.ToDouble(lines[5]));
            reverseData.Add(tmp);
        }
        public void parse1(string line)
        {
            string[] lines = line.Split(',');
            DataEntity tmp = new DataEntity();
            tmp.Sp = lines[0];
            tmp.LonS = public_Algo.DMS2RAD(Convert.ToDouble(lines[1]));
            tmp.LatS = public_Algo.DMS2RAD(Convert.ToDouble(lines[2]));
            tmp.Ep = lines[5];
            tmp.S= Convert.ToDouble(lines[4]);
            tmp.A1 = public_Algo.DMS2RAD(Convert.ToDouble(lines[3]));
            zcalData.Add(tmp);
        }
    }
}
