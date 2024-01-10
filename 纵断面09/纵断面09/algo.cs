using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 纵断面09
{
    class algo
    {
        public List<DataEntity> nc_p = new List<DataEntity>();//放入内插点
        public List<DataEntity> centerM = new List<DataEntity>();
        public List<DataEntity> nc_m = new List<DataEntity>();
        public double D(DataEntity data1,DataEntity data2)
        {
            return Math.Sqrt(Math.Pow(data1.X-data2.X,2)+Math.Pow(data1.Y-data2.Y,2));
        }
        /// <summary>
        /// 计算方位角
        /// </summary>
        /// <param name="data1">第一个点</param>
        /// <param name="data2">第二个点</param>
        /// <returns>方位角</returns>
        public double azimuth(DataEntity data1,DataEntity data2)
        {
            double detaX = data2.X - data1.X;
            double detaY = data2.Y - data1.Y;
            double deta = Math.Atan(detaY/ detaX);
            if (detaX==0)
            {
                if (detaY > 0)
                {
                    deta=Math.PI/2;
                }
                else
                {
                    deta = Math.PI * 1.5;
                }
            }
            else if (detaX>0)
            {
                if (detaY>0)
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
                deta += Math.PI ;
            }
            return deta;

        }
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="Q"></param>
        public void bubble(List<DataEntity> Q)
        {
            for (int i = 0; i < Q.Count; i++)
            {
                for (int j = 0; j <Q.Count()-1-i; j++)
                {
                    if (Q[j].L>Q[j+1].L)
                    {
                        DataEntity tmp =Q[j];
                        Q[j] = Q[j + 1];
                        Q[j + 1] = tmp;
                    }
                }
            }
        }
        /// <summary>
        /// 计算内插点
        /// </summary>
        /// <param name="data1"></param>
        /// <param name="data2"></param>
        /// <param name="L"></param>
        public double D_all = 0;
        public void Pnc(DataEntity data1,DataEntity data2,DataEntity data3,ref int L)
        {
            double D0 = D(data1, data2);
            D_all += D0;
            double D1 = D(data1, data3);
            double azm = azimuth(data1,data2);
            data1.L =D1 ;
            nc_p.Add(data1);
            for (; L < D_all; L+=10)
            {
                DataEntity tmp = new DataEntity();
                tmp.X = data1.X + (L - D1) * Math.Cos(azm);
                tmp.Y = data1.Y + (L - D1) * Math.Sin(azm);
                tmp.ID = $"V{L / 10}";
                tmp.L =Math.Abs(L);
                nc_p.Add(tmp);
            }

        }
        public void ncH(DataEntity Pk,List<DataEntity> Q)
        {
           
            double d_all = 0;
            double di = 0;
            for (int i = 0; i < Q.Count(); i++)
            {
                Q[i].L=D(Pk, Q[i]);
            }
            bubble(Q);
            for (int i = 0; i <5; i++)
            {
                d_all += Q[i].H / Q[i].L;
                di += 1 / Q[i].L;
            }
            Pk.H = d_all / di;
        }
        public double area(double h0,double L,DataEntity data1,DataEntity data2)
        {
            return ((data1.H + data2.H - 2 * h0) * L) / 2;
        }
        public void cm(List<DataEntity> K)
        {
            for (int i = 0; i < K.Count()-1; i++)
            {
                DataEntity m = new DataEntity();
                m.X = (K[i].X + K[i + 1].X)/2;
                m.Y = (K[i]. Y   + K[i + 1].Y)/2;
                m.ID = i.ToString();
                centerM.Add(m);
            }
        }
        public void ncM(DataEntity data1,DataEntity data2,int j)
        {
            double azm = azimuth(data1,data2)+Math.PI/2;
            for (int i = -5; i <=5; i++)
            {
                DataEntity mp = new DataEntity();
                mp.ID = $"{(char)('A'+j)}{i}";
                mp.X = centerM[j].X + i * 5 * Math.Cos(azm);
                mp.Y = centerM[j].Y + i * 5 * Math.Sin(azm);
                nc_m.Add(mp);
            }
        }
    }
}
