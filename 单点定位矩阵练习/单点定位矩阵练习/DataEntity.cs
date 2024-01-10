using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 单点定位矩阵练习
{
    class DataEntity
    {
        public DataBase1 sate_cg = new DataBase1();
        public List<DataBase2> data = new List<DataBase2>();
        
        public Matrix P;
        public Matrix L;
        public Matrix Q;
        public Matrix B;
        public Matrix V;
        public Matrix dx;
        public Matrix sigama;
        public double sigama0;
        public double POOP;

    }
}
