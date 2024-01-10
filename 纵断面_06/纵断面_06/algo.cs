using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 纵断面_06
{
    class algo
    {
        public List<DataEntity> PncPoint = new List<DataEntity>();
        public List<DataEntity> centerM = new List<DataEntity>();
        public List<DataEntity> Mnc = new List<DataEntity>();
        public double D_sum = 0;
        /// <summary>
        /// 计算方位角
        /// </summary>
        /// <param name="data1">第一个点</param>
        /// <param name="data2">第二个点</param>
        /// <returns>返回方位角</returns>
        public double azimuth(DataEntity data1, DataEntity data2)
        {
            double detaX = data2.X - data1.X;
            double detaY = data2.Y - data1.Y;
            double deta = Math.Atan(detaY / detaX);
            if (detaX == 0)
            {
                if (detaY > 0)
                {
                    deta = Math.PI / 2;
                }
                else
                {
                    deta = 1.5 * Math.PI;
                }
            }
            else if (detaX > 0)
            {
                if (detaY > 0)
                {
                    deta = deta;
                }
                else
                {
                    deta += 2 * Math.PI;
                }
            }
            else
            {
                deta += Math.PI;
            }

            return deta;
        }
        /// <summary>
        /// 计算长度
        /// </summary>
        /// <param name="data1"></param>
        /// <param name="data2"></param>
        /// <returns>长度</returns>
        public double D(DataEntity data1, DataEntity data2)
        {
            double D = Math.Sqrt(Math.Pow(data2.X - data1.X, 2) + Math.Pow(data2.Y - data1.Y, 2));
            return D;
        }
        public void ncH(DataEntity Pk, List<DataEntity> Q)
        {
            double di = 0;
            double L_all = 0;
            for (int i = 0; i < Q.Count(); i++)
            {
                Q[i].L = D(Pk, Q[i]);
            }
            bubble(Q);
            for (int i = 0; i < 5; i++)
            {
                L_all += (Q[i].H / Q[i].L);
                di += 1 / Q[i].L;
            }
            Pk.H = L_all / di;
        }
        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <param name="Q">把n个数据排序取前m个元素</param>
        public void bubble(List<DataEntity> Q)
        {
            for (int i = 0; i < Q.Count; i++)
            {
                for (int j = 0; j < Q.Count - i - 1; j++)
                {
                    if (Q[j].L > Q[j + 1].L)
                    {
                        DataEntity tmp = Q[j];
                        Q[j] = Q[j + 1];
                        Q[j + 1] = tmp;
                    }
                }
            }
        }
        public double area(double h0, double L, DataEntity data1, DataEntity data2)
        {
            double S = ((data1.H + data2.H - 2 * h0) * L) / 2;
            return S;
        }
        public void pzuobiaio(DataEntity data1, DataEntity data2, DataEntity data3, ref int dp)
        {
            double D1 = D(data1, data2);
            D_sum += D1;
            double D0 = D(data1, data3);
            double afk = azimuth(data1, data2);
            data1.L = D0;
            PncPoint.Add(data1);
            for (; dp < D_sum; dp += 10)
            {
                DataEntity d = new DataEntity();
                double xi = data1.X + (dp - D0) * Math.Cos(afk);
                double yi = data1.Y + (dp - D0) * Math.Sin(afk);
                d.X = xi;
                d.Y = yi;
                d.L = Math.Abs(dp);
                d.ID = $"Z{dp}";
                PncPoint.Add(d);
            }
        }
        public void Hcenter(List<DataEntity> K)
        {
            for (int i = 0; i < K.Count() - 1; i++)
            {
                DataEntity M = new DataEntity();
                M.X = (K[i].X + K[i +1].X) / 2;
                M.Y = (K[i].Y + K[i + 1].Y) / 2;
                M.ID = $"M{i}";
                centerM.Add(M);
            }
        }
        public void mcoordinate(DataEntity data1,DataEntity data2,int i)
        {
            double afk = azimuth(data1,data2);
            afk += Math.PI / 2;
            for (int j = -5; j <=5; j++)
            {
                    DataEntity m = new DataEntity();
                    m.X = centerM[i].X + j * 5 * Math.Cos(afk);
                    m.Y = centerM[i].Y + j * 5 * Math.Sin(afk);
                    m.ID ="N"+(char)('A'+i)+ $"{j}";
                    Mnc.Add(m);
            }
            
        }
    }
}
