using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 大地正反算
{
    class public_algo
    {
        public  double[] ABC_Cal(double K,double b)
        {
            double[] ABC = new double[3];
            ABC[0] = (1 - K / 4 + 7 * Math.Pow(K, 2) / 64 - 15 * Math.Pow(K, 3) / 256) / b;
            ABC[1] = (K/ 4 - Math.Pow(K, 2)  / 8 + 37 * Math.Pow(K,3) / 512);
            ABC[2] = (Math.Pow(K,2)/128-Math.Pow(K,3)/128);
            return ABC;
        }
        public double[] Getaf_Beta_Gama(double e1,double cosA0)
        {
            double[] abg=new double[3];
            abg[0] = Math.Pow(e1, 2) / 2 + Math.Pow(e1, 4) / 8 + Math.Pow(e1, 6) / 16 - (Math.Pow(e1, 4) / 16 + Math.Pow(e1, 6) / 16) * cosA0+ Math.Pow(e1, 6) * 3 / 128 * Math.Pow(cosA0, 2);
            abg[1] = (Math.Pow(e1, 4) / 16 + Math.Pow(e1, 6) / 16) * cosA0- Math.Pow(e1, 6) / 32 * Math.Pow(cosA0, 2); ;
            abg[2] = Math.Pow(e1, 6)  / 256 * Math.Pow(cosA0, 2);
            return abg;
        }

        public  double b(double a,double f)
        {
            return a * (1 - f);
        }
        public  double e(double a,double b)
        {
            return Math.Sqrt(Math.Pow(a,2)-Math.Pow(b,2));
        }
        public double DMS2RAD(double dmsValue)
        {
            int i = 1;
            if (dmsValue < 0)
            {
                i = -1;
                dmsValue = Math.Abs(dmsValue);
            }
            int d = (int)dmsValue;
            int m = (int)((dmsValue - d) * 100.0 + 0.0001);
            double s = ((dmsValue - d - m / 100.0) * 10000);
            double rad = (d + m / 60.0 + s / 3600.0) * Math.PI / 180.0;
            return rad * i;
        }
        public double RAD2DMS(double radValue)
        {
            if (Math.Abs(radValue) > 2 * Math.PI)
            {
                radValue -= 2 * Math.PI;
            }
            double dfm = radValue * 180 / Math.PI;
            int d = (int)(dfm);
            double f = (int)((dfm - d) * 60);
            double m = ((dfm - d) * 60 - f) * 60;
            return d + f / 100 + m / 10000;
        }
    }
}
