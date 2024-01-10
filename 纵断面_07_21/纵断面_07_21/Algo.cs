using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 纵断面_07_21
{
    class Algo
    {
        double h0 = 0;
        public Algo(double h0)
        {
            this.h0 = h0;
        }
        public List<DataEntity> H = new List<DataEntity>();
        public List<DataEntity> Z = new List<DataEntity>();
        public Algo()
        {

        }
        double af=0;
        public double azimuth(DataEntity d1,DataEntity d2)
        {
            double detaX = d2.X - d1.X;
            double detaY = d2.Y - d1.Y;
            af = Math.Atan(detaY / detaX);
            if (detaX==0)
            {
                return Math.PI / 2;
            }
            else
            {
                return 1.5*Math.PI;
            }

            if (detaX>0)
            {
                if (detaY>0)
                {

                    return af;
                }
                else
                {
                    return af=Math.PI + af;
                }
            }
            else 
            {
                   return af = af + Math.PI;
            }
        }
        public double D(DataEntity d1,DataEntity d2)
        {
            return Math.Sqrt(Math.Pow(d2.X-d1.X,2)+ Math.Pow(d2.Y- d1.Y,2));
        }
        public void bubble(List<DataEntity> data)
        {
            for (int i = 0; i < data.Count(); i++)
            {
                for (int j = 0; j < data.Count()-i-1; j++)
                {
                    if (data[j+1].D<data[j].D)
                    {
                        DataEntity tmp = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = tmp;
                    }
                }
            }
        }
        public double ncH(List<DataEntity> data,DataEntity P)
        {
            for (int i = 0; i < data.Count(); i++)
            {
                data[i].D=D(data[i],P);
             }
            bubble(data);
            double upper = 0;
            double under =0;
            for (int i = 0; i < 5; i++)
            {
                upper += data[i].H / data[i].D;
                under += 1 / data[i].D;
            }
            return upper / under;
           
        }
        public DataEntity Mcenter(DataEntity d1,DataEntity d2,int i)
        {
            DataEntity d = new DataEntity();
            d.ID = $"M{i}";
            d.X=(d1.X + d2.X)/2;
            d.Y=(d1.Y + d2.Y)/2;
            return d;
        }
        public double area(DataEntity d1,DataEntity d2)
        {
            return (d1.H + d2.H - 2 * h0) / 2 * (d2.D - d1.D);
        }
        public void nccoordinateZ(List<DataEntity> data,DataEntity d,ref int L,double D)
        {
            int last = data.Count() - 1;
            Z.Add(d);
            for (L= 10; L <= D; L += 10)
            {
                DataEntity Z1 = new DataEntity();
                double Xi = d.X + L * Math.Cos(af);
                double Yi = d.Y + L * Math.Sin(af);
                Z1.X = Xi;
                Z1.Y = Yi;
                Z1.ID = $"Z{L / 10}";
                Z1.D = L;
                Z.Add(Z1);
            }
        }
        double afM = 0;
        public void nccoordinateH(DataEntity M)
        {
            afM = af + Math.PI / 2;
            int i = 1;
            for (int L = -30; L <= 30; L+=10)
            {
                if (L==0)
                {
                    continue;
                }
                DataEntity H1 = new DataEntity();
                double Xi = M.X + L * Math.Cos(afM);
                double Yi = M.Y + L * Math.Sin(afM);
                H1.ID = $"N{i}";
                H1.X = Xi;
                H1.Y = Yi;
                H.Add(H1);
                H1.D =L;
                i++;
            }
        }
    }
}
