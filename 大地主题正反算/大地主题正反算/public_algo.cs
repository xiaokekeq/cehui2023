using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 大地主题正反算
{
    class public_algo
    {
        public double b(double a,double f)
        {
            return a * (1 - f);
        }
        public double e1_2(double a,double b)
        {
            return (Math.Pow(a,2)-Math.Pow(b,2))/Math.Pow(a,2);
        }
        public double e2_2(double a, double b)
        {
            return (Math.Pow(a, 2) - Math.Pow(b, 2)) / Math.Pow(b, 2);
        }
        public double CosA_2(double SinA0)
        {
            double CosA_2 = 1 - Math.Pow(SinA0,2);
            return CosA_2;
        }
        public double K_2(double e2_2,double CosA_2)
        {
            return e2_2 * CosA_2;
        }
        public List<double> abg(double e1_2,double CosA_2)
        {
            double af = (e1_2 / 2 + Math.Pow(e1_2, 2) / 8 + Math.Pow(e1_2, 3) / 16) - (Math.Pow(e1_2, 2) / 16 + Math.Pow(e1_2, 3) / 16) * CosA_2 + 3 * Math.Pow(e1_2, 3) / 128 * Math.Pow(CosA_2, 2);
            double beta= (Math.Pow(e1_2, 2) / 16 + Math.Pow(e1_2, 3) / 16) * CosA_2 -  Math.Pow(e1_2, 3) / 32 * Math.Pow(CosA_2, 2);
            double gama = Math.Pow(e1_2, 3) / 256 * Math.Pow(CosA_2, 2);
            List<double> abg = new List<double>();
            abg.Add(af);
            abg.Add(beta);
            abg.Add(gama);
            return abg;
        }   
        public List<double> ABC(double K_2,double b)
        {
            double A = (1 - K_2 / 4 + 7 * Math.Pow(K_2, 2) / 64 - 15 * Math.Pow(K_2, 3) / 256) / b;
            double B = (K_2 / 4 -  Math.Pow(K_2, 2) / 8+ 37 * Math.Pow(K_2, 3) /512) ;
            double C = Math.Pow(K_2, 2) / 128 -  Math.Pow(K_2, 3) / 128;
            List<double> abc = new List<double>();
            abc.Add(A);
            abc.Add(B);
            abc.Add(C);
            return abc;
        }
        public double dms2RAD(double dms)
        {
            int i = 1;
            if (dms<0)
            {
                i = -1;
                dms = Math.Abs(dms);
            }
            double d = (int)dms;
            double f = (int)((dms - d)* 100.0+0.0001);
            double m = ((dms - d - f/100.0) * 10000);
            return i*(d + f / 60 + m / 3600) * Math.PI / 180;
        }
        public double radtDMS(double rad)
        {
            if (Math.Abs(rad) > 2 * Math.PI)
            {
                rad -= 2 * Math.PI;
            }
            double dfm = rad * 180 / Math.PI;
            double d = (int)dfm;
            double f = (int)((dfm - d) * 60);
            double m = ((dfm - d - f/60) * 3600);
            return d + f / 100 + m / 10000;
        }
        public double A2_A1_judge(double A2,double A1)
        {
            if (A2 < 0)
            {
                A2 += Math.PI * 2;
            }
            if (A2 > Math.PI * 2)
            {
                A2 -= Math.PI * 2;
            }
            if (A1 < Math.PI && A2 < Math.PI)
            {
                A2 += Math.PI;
            }
            if (A1 > Math.PI && A2 > Math.PI)
            {
                A2 -= Math.PI;
            }
            return A2;
        }
    }
}
