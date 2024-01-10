using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 单点定位_0723
{
    class Algo
    {
        Parse parse = new Parse();
        public Algo(Parse parse)
        {
            this.parse = parse;
           
        }
        
        public void sateCoordinate(int i)
        {
            
        }
        /// <summary>
        /// 计算BLP
        /// </summary>
        /// <param name="i">一共有多少组要求解</param>
        public void BLP(int i)
        {
            parse.data_all[i].B = new Matrix(parse.data_all[i].sate.number, 4);
            parse.data_all[i].L = new Matrix(parse.data_all[i].sate.number, 1);
            parse.data_all[i].P = new Matrix(parse.data_all[i].sate.number, parse.data_all[i].sate.number);
            for (int j = 0; j < parse.data_all[i].sate.number; j++)
            {
               double R0 = Math.Sqrt(Math.Pow(-parse.Sate_X + parse.data_all[i].data[j].X, 2)
             + Math.Pow(-parse.Sate_Y +parse.data_all[i].data[j].Y, 2)
             + Math.Pow(-parse.Sate_Z + parse.data_all[i].data[j].Z, 2));
                //矩阵B
                parse.data_all[i].B.arr[j, 0] = (-parse.Sate_X + parse.data_all[i].data[j].X) / R0;
                parse.data_all[i].B.arr[j, 1] = (-parse.Sate_Y + parse.data_all[i].data[j].Y) / R0;
                parse.data_all[i].B.arr[j, 2] = (-parse.Sate_Z + parse.data_all[i].data[j].Z) / R0;
                parse.data_all[i].B.arr[j, 3] = -1;
                //观测向量L
                parse.data_all[i].L.arr[j, 0] = parse.data_all[i].data[j].CL - R0 + parse.data_all[i].data[j].Clock - parse.data_all[i].data[j].TD;
                //权阵P
                parse.data_all[i].P.arr[j, j] = Math.Sin(parse.data_all[i].data[j].ele * Math.PI / 180) / 0.04;
            }
            
        }
        /// <summary>
        ///   最小二乘解算
        /// </summary>
        public void Lsq(Matrix pos0,int i)
        {
            Matrix zero = new Matrix(4,1);
            //协因数Q
           // pos0.Inverse((pos0.transposs(epoch.B) * epoch.P * epoch.B));
            parse.data_all[i].Q = pos0.Inverse(pos0.transposs(parse.data_all[i].B) * parse.data_all[i].P * parse.data_all[i].B);
            //增量dx
            // epoch.dx = zero - epoch.Q * pos0.transposs(epoch.B) * epoch.P * epoch.L;
            parse.data_all[i].dx = zero - parse.data_all[i].Q * pos0.transposs(parse.data_all[i].B) * parse.data_all[i].P * parse.data_all[i].L;
            Matrix _dx = new Matrix(3, 1);
            _dx.arr[0, 0] = parse.data_all[i].dx.arr[0, 0];
            _dx.arr[1, 0] = parse.data_all[i].dx.arr[1, 0];
            _dx.arr[2, 0] = parse.data_all[i].dx.arr[2, 0];
            //估计位置
            parse.data_all[i].pos = pos0 + _dx;
            //后验残差V
            parse.data_all[i].V = parse.data_all[i].B * parse.data_all[i].dx + parse.data_all[i].L;
            Matrix vtpv = pos0.transposs(parse.data_all[i].V)* parse.data_all[i].P* parse.data_all[i].V;
            //单位权中误差
            parse.data_all[i].sigma0 = Math.Sqrt(vtpv.arr[0, 0] / (parse.data_all[i].sate.number - 4));
            parse.data_all[i].sigma = new Matrix(4, 1);
            parse.data_all[i].sigma.arr[0, 0] = parse.data_all[i].sigma0 * Math.Sqrt(parse.data_all[i].Q.arr[0, 0]);
            parse.data_all[i].sigma.arr[1, 0] = parse.data_all[i].sigma0 * Math.Sqrt(parse.data_all[i].Q.arr[1, 1]);
            parse.data_all[i].sigma.arr[2, 0] = parse.data_all[i].sigma0 * Math.Sqrt(parse.data_all[i].Q.arr[2, 2]);
            parse.data_all[i].sigma.arr[3, 0] = parse.data_all[i].sigma0 * Math.Sqrt(parse.data_all[i].Q.arr[3, 3]);
            //PDOP值
            parse.data_all[i].PDOP = Math.Sqrt(parse.data_all[i].Q.arr[0, 0] + parse.data_all[i].Q.arr[1, 1] + parse.data_all[i].Q.arr[2, 2]);
        }

    }
}
