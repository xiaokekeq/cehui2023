using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zf_028
{
    class Public_Algo
    {
        public double DSM2RAD(double value)
        {
            int i = 1;
            if (value<0)
            {
                i = -1;
                value = Math.Abs(value);
            }
            double d = (int)value;
            double f = (int)((value - d)*100+0.0001);
            double m = (value - d - f / 100)*10000;
            return i*(d + f / 60 + m / 3600) * Math.PI / 180;
        }
        public double Rad2DFM(double rad)
        {

            double dfm = rad * 180 / Math.PI;
            double d = (int)dfm;
            double f = (int)((dfm - d) * 60);
            double m = (dfm - d - f / 60) * 3600;
            return d + f / 100 + m / 10000;
        }
        public double b(double a,double f)
        {
            return a * (1 - f);
        }
        public double e1_2(double a,double b)
        {
            return (Math.Pow(a, 2) - Math.Pow(b, 2)) / Math.Pow(a, 2);
        }
        public double e2_2(double a,double b)
        {
            return (Math.Pow(a, 2) - Math.Pow(b, 2)) / Math.Pow(b ,2);
        }
        public double K_2(double e2_2,double CosA0_2)
        {
            return e2_2 * CosA0_2;
        }
        public double CosA0_2(double SinA0)
        {
            return 1 - Math.Pow(SinA0,2);
        }
        public List<double> abg(double e1_2,double CosA0_2)
        {
            List<double> abg = new List<double>();
            double a = e1_2 / 2 + Math.Pow(e1_2, 2) / 8 + Math.Pow(e1_2, 3) / 16 - (Math.Pow(e1_2, 2) / 16 + Math.Pow(e1_2, 3) / 16) * CosA0_2 + (3 * Math.Pow(e1_2, 3) / 128) * Math.Pow(CosA0_2, 2);
            double b= (Math.Pow(e1_2, 2) / 16 + Math.Pow(e1_2, 3) / 16) * CosA0_2- ( Math.Pow(e1_2, 3) / 32) * Math.Pow(CosA0_2, 2);
            double g= (Math.Pow(e1_2, 3) / 256) * Math.Pow(CosA0_2, 2);
            abg.Add(a);
            abg.Add(b);
            abg.Add(g);
            return abg;
        }
        public List<double> ABC(double K_2,double b)
        {
            List<double> ABC = new List<double>();
            double A = (1 - K_2 / 4 + 7 * Math.Pow(K_2, 2) / 64 - 15 * Math.Pow(K_2, 3) / 256) / b;
            double B= K_2 / 4 - Math.Pow(K_2, 2) / 8 + 37 * Math.Pow(K_2, 3) / 512;
            double C = Math.Pow(K_2, 2) / 128 - Math.Pow(K_2, 3) / 128;
            ABC.Add(A);
            ABC.Add(B);
            ABC.Add(C);
            return ABC;
        }
        public double A2_judge(double A1,double A2)
        {
            if (A2<0)
            {
                return A2 += Math.PI*2;
            }
            if (A2>Math.PI*2)
            {
                return A2 -= Math.PI * 2;
            }
            if (A1<Math.PI&&A2<Math.PI)
            {
                return Math.PI + A2;
            }
            if (A1>Math.PI&&A2>Math.PI)
            {
                return A2 - Math.PI;
            }
            return A2;
        }
    }
}
