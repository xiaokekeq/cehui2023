using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 纵横断面
{
    class Algo
    {
        public List<DataEntity> Pnc = new List<DataEntity>();
        public List<DataEntity> centerM = new List<DataEntity>();
        public List<DataEntity> Mnc = new List<DataEntity>();
        public double azimuth(DataEntity d1,DataEntity d2)
        {
            double detaX = d2.X - d1.X;
            double detaY = d2.Y - d1.Y;
            double af = Math.Atan(detaY/detaX);
            if (detaX==0)
            {
                if (detaY>0)
                {
                    return Math.PI / 2;
                }
                else
                {
                    return Math.PI * 1.5;
                }
            }
            if (detaX>0)
            {
                if (detaY>0)
                {
                    return af;
                }
                else
                {
                    return Math.PI * 2 + af;
                }
            }
            else
            {
                return Math.PI + af;
            }
        }
        public double D(DataEntity d1,DataEntity d2)
        {
            return Math.Sqrt(Math.Pow(d1.X-d2.X,2)+Math.Pow(d1.Y-d2.Y,2));
        }
        public void bubble(List<DataEntity> data)
        {
            for (int i = 0; i < data.Count(); i++)
            {
                for (int j = 0; j < data.Count()-1-i; j++)
                {
                    if (data[j+1].D<data[j].D)
                    {
                        DataEntity tmp = new DataEntity();
                        tmp = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = tmp;
                    }
                }
            }
        }
        public double ncH(List<DataEntity> Q,DataEntity p)
        {
            for (int i = 0; i < Q.Count(); i++)
            {
                Q[i].D = D(Q[i],p);
            }
            bubble(Q);
            double upper = 0;
            double under = 0;
            for (int i = 0; i < 5; i++)
            {
                upper += Q[i].H / Q[i].D;
                under += 1 / Q[i].D;
            }
            return upper / under;
        }
        public void Mcenter(List<DataEntity> K)
        {
            for (int i = 0; i < K.Count()-1; i++)
            {
                DataEntity M = new DataEntity();
                M.ID = $"M{i}";
                M.X = (K[i].X+K[i+1].X)/2;
                M.Y = (K[i].Y+K[i+1].Y)/2;
                centerM.Add(M);
            }
        }
        public double area(double h0,DataEntity d1,DataEntity d2,double L)
        {
            return (d1.H + d2.H - 2 * h0) * L / 2;
        }
       public  double D_SUM = 0;

        public void ncZ(DataEntity d1,DataEntity d2,DataEntity d3,ref double dp)
        {
            double D1 = D(d1, d2);
            D_SUM += D1;
            double D0 = D(d1, d3);
            double  af = azimuth(d1,d2);
            d1.D = D0;
            Pnc.Add(d1);
            for (; dp < D_SUM; dp+=10)
            {
                DataEntity d = new DataEntity();
                d.X = d1.X + (dp - D0) * Math.Cos(af);
                d.Y = d1.Y + (dp-D0)*Math.Sin(af);
                d.D = dp;
                d.ID = $"Z{dp/10}";
                Pnc.Add(d);
            }
        }
        public void ncM(DataEntity d1,DataEntity d2,int i)
        {
            double af = azimuth(d1,d2);
            af += Math.PI / 2;
            for (int j=-5; j <=5; j++)
            {
                DataEntity d = new DataEntity();
                d.X = centerM[i].X + j * 5 * Math.Cos(af);
                d.Y= centerM[i].Y + j * 5 * Math.Sin(af);
                d.ID = $"N{j}";
                d.D = j*5;
                Mnc.Add(d);
            }
        }
    }
}
