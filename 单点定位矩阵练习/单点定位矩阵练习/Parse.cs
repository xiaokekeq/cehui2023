using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 单点定位矩阵练习
{
    class Parse
    {
        public List<DataEntity> data_all = new List<DataEntity>();
        public Matrix pos = new Matrix(3,1);
        public DataEntity d;
        public void parse1(string line)
        {
            d = new DataEntity(); 
            string[] lines = line.Split(',',':','：');
            d.sate_cg.satNum = Convert.ToInt32(lines[1]);
            d.sate_cg.time = Convert.ToInt32(lines[3]);
        }
        public void parse2(string line)
        {
            string[] lines = line.Split(',', ':', '：');
            DataBase2 sate = new DataBase2();
            sate.ID = lines[0];
            sate.X = Convert.ToDouble(lines[1]);
            sate.Y= Convert.ToDouble(lines[2]);
            sate.Z= Convert.ToDouble(lines[3]);
            sate.Clock= Convert.ToDouble(lines[4]);
            sate.Elev= Convert.ToDouble(lines[5]);
            sate.CL= Convert.ToDouble(lines[6]);
            sate.TD= Convert.ToDouble(lines[7]);
            d.data.Add(sate);
        }
    }
}
