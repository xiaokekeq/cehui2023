using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 单点定位_28
{
    class DataEntity
    {
        public Data satep = new Data();
        public List<Data1> data = new List<Data1>();
        public Matrix B;
        public Matrix L;
        public Matrix V;
        public Matrix P;
        public Matrix dx;
        public Matrix xigama;
        public double xigama0;
        public Matrix Q;
        public double POOP;
    }
}
