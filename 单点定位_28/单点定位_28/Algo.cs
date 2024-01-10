using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 单点定位_28
{
    class Algo
    {
        Parse parse = new Parse();
        public Algo(Parse parse)
        {
            this.parse = parse;
        }
        public void BLP(int i)
        {
            int num = parse.data_all[i].satep.satNum;
            parse.data_all[i].B = new Matrix(num,4);
            parse.data_all[i].L = new Matrix(num,1);
            parse.data_all[i].P = new Matrix(num,num);
            for (int j = 0; j < parse.data_all[i].data.Count(); j++)
            {
                double R0 = Math.Sqrt(
                Math.Pow(parse.pos.arr[0, 0] - parse.data_all[i].data[j].X, 2) +
                Math.Pow(parse.pos.arr[1, 0] - parse.data_all[i].data[j].Y, 2) +
                Math.Pow(parse.pos.arr[2, 0] - parse.data_all[i].data[j].Z, 2)
               );
                parse.data_all[i].B.arr[j, 0] = (parse.data_all[i].data[j].X - parse.pos.arr[0, 0] )/ R0;
                parse.data_all[i].B.arr[j, 1] = (parse.data_all[i].data[j].Y - parse.pos.arr[1, 0] )/ R0;
                parse.data_all[i].B.arr[j, 2] = (parse.data_all[i].data[j].Z - parse.pos.arr[2, 0] )/ R0;
                parse.data_all[i].B.arr[j, 3] = -1;
                parse.data_all[i].L.arr[j, 0] = parse.data_all[i].data[j].CL - R0 + parse.data_all[i].data[j].Clock - parse.data_all[i].data[j].TD;
                parse.data_all[i].P.arr[j, j] = Math.Sin(parse.data_all[i].data[j].Elev*Math.PI/180)/0.04 ;
            }

        }
        public Matrix pos;
        public void VQX(int i)
        {
            pos = new Matrix(3, 1);
            Matrix inv = new Matrix(4,1);
            parse.data_all[i].Q = inv.Inverse(inv.transposs(parse.data_all[i].B) * parse.data_all[i].P * parse.data_all[i].B);
            parse.data_all[i].dx = inv - (parse.data_all[i].Q) * inv.transposs(parse.data_all[i].B) * parse.data_all[i].P * parse.data_all[i].L;
            pos.arr[0,0]=parse.pos.arr[0, 0] + parse.data_all[i].dx.arr[0,0];
            pos.arr[1, 0] = parse.pos.arr[1, 0] + parse.data_all[i].dx.arr[1,0];
            pos.arr[2, 0] = parse.pos.arr[2, 0] + parse.data_all[i].dx.arr[2,0];
            parse.data_all[i].V = parse.data_all[i].B * parse.data_all[i].dx + parse.data_all[i].L;
            Matrix tmp = inv.transposs(parse.data_all[i].V)* parse.data_all[i].P* parse.data_all[i].V;
            parse.data_all[i].xigama0 = Math.Sqrt(tmp.arr[0, 0] / (parse.data_all[i].satep.satNum - 4));
            parse.data_all[i].xigama = new Matrix(4, 1);
            parse.data_all[i].xigama.arr[0,0] = parse.data_all[i].xigama0*Math.Sqrt(parse.data_all[i].Q.arr[0,0]);
            parse.data_all[i].xigama.arr[1,0] = parse.data_all[i].xigama0*Math.Sqrt(parse.data_all[i].Q.arr[1,1]);
            parse.data_all[i].xigama.arr[2,0] = parse.data_all[i].xigama0*Math.Sqrt(parse.data_all[i].Q.arr[2,2]);
            parse.data_all[i].xigama.arr[3,0] = parse.data_all[i].xigama0*Math.Sqrt(parse.data_all[i].Q.arr[3,3]);
            parse.data_all[i].POOP = Math.Sqrt(parse.data_all[i].Q.arr[0,0]+ parse.data_all[i].Q.arr[1,1]+ parse.data_all[i].Q.arr[2,2]);
        }
    }
}
