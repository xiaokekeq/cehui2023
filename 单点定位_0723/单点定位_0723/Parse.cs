using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 单点定位_0723
{
    class Parse
    {
        public string Sate_ID;
        public double Sate_X;
        public double Sate_Y;
        public double Sate_Z;
        public Matrix pos0 = new Matrix(3, 1);
        public List<DataEntity> data_all = new List<DataEntity>();
        public DataEntity d;
        public void parse1(string line)
        {
            d= new DataEntity();
            string[] lines = line.Split(',','，',':','：');
            d.sate.number = Convert.ToInt32( lines[1]);
            d.sate.time=Convert.ToInt32(lines[3]);
           
        }
        public void parse2(string line)
        {
            Data1 data = new Data1();
            string[] lines = line.Split(',', '，', ':', '：');
            data.id = lines[0];
            data.X = Convert.ToDouble(lines[1]);
            data.Y = Convert.ToDouble(lines[2]);
            data.Z = Convert.ToDouble(lines[3]);
            data.Clock = Convert.ToDouble(lines[4]);
            data.ele =(Convert.ToDouble(lines[5]));
            data.CL = Convert.ToDouble(lines[6]);
            data.TD = Convert.ToDouble(lines[7]);
            d.data.Add(data);
        }
    }
}
