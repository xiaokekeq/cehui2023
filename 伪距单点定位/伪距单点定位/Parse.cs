using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 伪距单点定位
{
    class Parse
    {
        public string ID;
        public double position_X;//接收机坐标
        public double position_Y;
        public double position_Z;
        public DataEntity d;
        public List<DataEntity> data = new List<DataEntity>();
        public void parse1(string line)
        {
            d = new DataEntity();
            string[] lines = line.Split(',', ':', '：');
            d.sate.Number = Convert.ToDouble(lines[1]);
            d.sate.time = Convert.ToDouble(lines[3].ToString().Trim());
        }
        public void parse2(string line)
        {
                DataEntitydata data = new DataEntitydata();
                string[] lines = line.Trim().Split(',', ':', '：');
                data.PRN = lines[0];
                data.X = Convert.ToDouble(lines[1]);
                data.Y = Convert.ToDouble(lines[2]);
                data.Z = Convert.ToDouble(lines[3]);
                data.Clock = Convert.ToDouble(lines[4]);
                data.Elevation = Convert.ToDouble(lines[5]);
                data.CL = Convert.ToDouble(lines[6]);
                data.Trop = Convert.ToDouble(lines[7]);
                d.data.Add(data);
        }
    }
}
