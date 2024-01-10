using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace 纵断面27
{
    class Algo
    {
        public List<DataEntity> Pnc = new List<DataEntity>();
        public List<DataEntity> Mnc = new List<DataEntity>();
        public List<DataEntity> Mcenter = new List<DataEntity>();
        public double azimuth(DataEntity d1, DataEntity d2)
        {
            double detaX = d2.X - d1.X;
            double detaY = d2.Y - d1.Y;
            double deta = Math.Atan(detaY / detaX);
            if (detaX == 0)
            {
                if (detaY > 0)
                {
                    return Math.PI / 2;
                }
                else
                {
                    return Math.PI * 1.5;
                }
            }
            else if (detaX > 0)
            {
                if (detaY > 0)
                {
                    return deta;
                }
                else
                {
                    return Math.PI * 2 + deta;
                }
            }
            else
            {
                return Math.PI + deta;

            }
        }
        public double D(DataEntity d1,DataEntity d2)
        {
            return Math.Sqrt(Math.Pow(d1.X-d2.X,2)+Math.Pow(d1.Y-d2.Y,2));
        }
        public void ncH(List<DataEntity> Q,DataEntity p)
        {
            for (int i = 0; i < Q.Count(); i++)
            {
                Q[i].L = D(Q[i], p);
            }
            bubble(Q);
            double upper = 0;
            double under = 0;
            for (int i = 0; i < 5; i++)
            {
                upper += Q[i].H / Q[i].L;
                under += 1 / Q[i].L;
            }
            p.H= upper / under;
        }
        public void bubble(List<DataEntity > data)
        {
            for (int i = 0; i < data.Count(); i++)
            {
                for (int j = 0; j < data.Count()-i-1; j++)
                {
                    if (data[j].L>data[j+1].L)
                    {
                        DataEntity tmp = data[j];
                        data[j] = data[j+1];
                        data[j + 1] = tmp;
                   }
                }
            }
        }
        public double area(double h0,double L,DataEntity d1,DataEntity d2)
        {
            return (d1.H + d2.H - 2 * h0) * L / 2;
        }
        public double D_SUM;
        public void Pcoor(DataEntity d1,DataEntity d2,DataEntity d3,ref double dp)
        {
            double D1 = D(d1,d2);
            D_SUM += D1;
            double D0 = D(d1,d3);
            double af = azimuth(d1,d2);
            d1.L = D0; ;
            Pnc.Add(d1);
            for (;dp < D_SUM;dp+=10)
            {
                DataEntity d = new DataEntity();
                d.X = d1.X + (dp-D0)*Math.Cos(af);
                d.Y = d1.Y + (dp-D0)*Math.Sin(af);
                d.ID = $"{dp/10}";
                d.L = dp;
                Pnc.Add(d);
            }
        }
        public void M(List<DataEntity> K)
        {
            for (int i = 0; i < K.Count()-1; i++)
            {
                DataEntity d = new DataEntity();
                d.X = (K[i].X + K[i + 1].X)/2;
                d.Y = (K[i].Y+K[i+1].Y)/2;
                Mcenter.Add(d);
            }
        }
        public void Mcoor(DataEntity d1,DataEntity d2,int j)
        {
            double af = azimuth(d1,d2);
            af += Math.PI / 2;
            for (int i = -5; i <=5; i++)
            {
                DataEntity d = new DataEntity();
                d.X = Mcenter[j].X + 5*i * Math.Cos(af);
                d.Y = Mcenter[j].Y + 5 * i * Math.Sin(af);
                d.ID = $"N{Math.Abs(i)}";
                Mnc.Add(d);
            }
        }
    }
}
