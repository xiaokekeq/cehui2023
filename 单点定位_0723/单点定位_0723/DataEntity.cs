using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 单点定位_0723
{
    class DataEntity
    {
        public Data sate = new Data();
        public List<Data1> data = new List<Data1>();
        public Matrix dx;
        public Matrix pos;
        public Matrix sigma;
        public Matrix Q;
        public Matrix P;
        public Matrix B;
        public Matrix L;
        public Matrix V;
        public double sigma0;
        public double PDOP;
    }

}
