using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 单点定位矩阵练习
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
            int sateNum = parse.data_all[i].sate_cg.satNum;
            parse.data_all[i].B = new Matrix(sateNum, 4);
            parse.data_all[i].L = new Matrix(sateNum, 1);
            parse.data_all[i].P= new Matrix(sateNum, sateNum);
            for (int j = 0; j < sateNum; j++)
            {
                double R0 = Math.Sqrt(
                Math.Pow(-parse.pos.arr[0, 0] + parse.data_all[i].data[j].X, 2)
                + Math.Pow(-parse.pos.arr[1, 0] + parse.data_all[i].data[j].Y, 2)
                + Math.Pow(-parse.pos.arr[2, 0] + parse.data_all[i].data[j].Z, 2)
             );
                parse.data_all[i].B.arr[j, 0] = (parse.data_all[i].data[j].X - parse.pos.arr[0, 0])/R0;
                parse.data_all[i].B.arr[j, 1] = (parse.data_all[i].data[j].Y - parse.pos.arr[1, 0])/ R0;
                parse.data_all[i].B.arr[j, 2] = (parse.data_all[i].data[j].Z - parse.pos.arr[2, 0])/ R0;
                parse.data_all[i].B.arr[j, 3] = -1;
                //L矩阵
                parse.data_all[i].L.arr[j,0]= parse.data_all[i].data[j].CL-R0 + parse.data_all[i].data[j].Clock - parse.data_all[i].data[j].TD;
                //P矩阵
                parse.data_all[i].P.arr[j, j] = Math.Sin(parse.data_all[i].data[j].Elev * Math.PI / 180)/0.04;
            }
        }
        public void LSQ(int i)
        {
            Matrix pos = new Matrix(4,1);
            //Q
            parse.data_all[i].Q = pos.Inverse(pos.transposs(parse.data_all[i].B)* parse.data_all[i].P* parse.data_all[i].B);
            parse.data_all[i].dx = pos - pos.Inverse(pos.transposs(parse.data_all[i].B) * parse.data_all[i].P * parse.data_all[i].B) * pos.transposs(parse.data_all[i].B) * parse.data_all[i].P * parse.data_all[i].L;
            parse.pos.arr[0, 0] += parse.data_all[i].dx.arr[0, 0];
            parse.pos.arr[1, 0] += parse.data_all[i].dx.arr[1, 0];
            parse.pos.arr[2, 0] += parse.data_all[i].dx.arr[2, 0];
            parse.data_all[i].V = parse.data_all[i].B * parse.data_all[i].dx + parse.data_all[i].L;
            Matrix vtpv = (pos.transposs(parse.data_all[i].V) * parse.data_all[i].P * parse.data_all[i].V);
            parse.data_all[i].sigama0 = Math.Sqrt(vtpv.arr[0,0] / (parse.data_all[i].sate_cg.satNum - 4));
            
            parse.data_all[i].sigama = new Matrix(4,1);
            parse.data_all[i].sigama.arr[0,0]= parse.data_all[i].sigama0 * Math.Sqrt(parse.data_all[i].Q.arr[0, 0]);
            parse.data_all[i].sigama.arr[1,0] = parse.data_all[i].sigama0 * Math.Sqrt(parse.data_all[i].Q.arr[1, 1]);
            parse.data_all[i].sigama.arr[2,0] = parse.data_all[i].sigama0 * Math.Sqrt(parse.data_all[i].Q.arr[2, 2]);
            parse.data_all[i].sigama.arr[3,0] = parse.data_all[i].sigama0 * Math.Sqrt(parse.data_all[i].Q.arr[3, 3]);
            //poop值
            parse.data_all[i].POOP = Math.Sqrt(parse.data_all[i].Q.arr[0,0]+ parse.data_all[i].Q.arr[1,1]+ parse.data_all[i].Q.arr[2,2]);
        }
    }
}
