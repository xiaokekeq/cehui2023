using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 单点定位_28
{
    class Parse
    {
        public List<DataEntity> data_all = new List<DataEntity>();
        public DataEntity data;
        public  Matrix pos = new Matrix(3,1);
        public void parse1(string line)
        {
            data = new DataEntity();
            string[] lines = line.Replace('\t',',').Split(',',':','：','(');
            data.satep.satNum = Convert.ToInt32(lines[1]);
            data.satep.time = Convert.ToInt32(lines[3]);
            
        }
        public void parse2(string line)
        {
            string[] lines = line.Replace('\t', ',').Split(',', ':', '：', '(');
            Data1 d = new Data1();
            d.id = lines[0];
            d.X = Convert.ToDouble(lines[1]);
            d.Y= Convert.ToDouble(lines[2]);
            d.Z = Convert.ToDouble(lines[3]);
            d.Clock = Convert.ToDouble(lines[4]);
            d.Elev = Convert.ToDouble(lines[5]);
            d.CL = Convert.ToDouble(lines[6]);
            d.TD = Convert.ToDouble(lines[7]);
            data.data.Add(d);
        }
    }
}