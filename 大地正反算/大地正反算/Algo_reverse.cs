using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 大地正反算
{
    class Algo_reverse
    {
        double a = 0;
        double f = 0;
        public Algo_reverse(double a, double f)
        {
            this.a = a;
            this.f = f;
        }
        public Algo_reverse()
        {

        }
        public List<double> ab;
        public List<double> u ;
        public double[] ABC;
        public double l = 0;
        double cosA0_2 = 0;
        public double A1 = 0;
        double deta1 = 0;
        double deta = 0;
        double e1, e,b=0;
        public public_algo public_algo = new public_algo();
        public double azimuth_A1(double p,double q,double A1)
        {
            if (p>0&&q>0)
            {
                A1 = Math.Abs(A1);
            }
            else if (p>0&&q<0)
            {
                A1 = Math.PI - Math.Abs(A1);
            }
            else if (p<0&&q<0)
            {
                A1 = Math.PI + Math.Abs(A1);
            }
            else
            {
                A1 = 2 * Math.PI - Math.Abs(A1);
            }
            return A1;
        }
        public  double azimuth_deta(double deta)
        {
            if (Math.Cos(deta)>0)
            {
                return Math.Abs(deta);
            }
            else
            {
                return Math.PI - Math.Abs(deta);
            }
        }
        public void  auxiliary_cal(List<DataEntity> reverse,int i)
        {
            ab= new List<double>();
            u = new List<double>();
            b = public_algo.b(a, f);
            e = public_algo.e(a, b);
            e1 = e / a; 
            double u1 = Math.Atan(Math.Sqrt(1 - Math.Pow(e1, 2)) * Math.Tan(reverse[i].LonS));
            double u2 = Math.Atan(Math.Sqrt(1 - Math.Pow(e1, 2)) * Math.Tan(reverse[i].LonE));
            u.Add(u1);
            u.Add(u2);
            double a1 = Math.Sin(u1) * Math.Sin(u2);
            double a2 = Math.Cos(u1) * Math.Cos(u2);
            double b1 = Math.Cos(u1) * Math.Sin(u2);
            double b2 = Math.Sin(u1) * Math.Cos(u2);
            ab.Add(a1);
            ab.Add(a2);
            ab.Add(b1);
            ab.Add(b2);
            l = reverse[i].LatE - reverse[i].LatS;
        }
        double lamda;
        public void StartAzimuth()
        {
            lamda = l;
            double xgm2, xgm1=0;
            do
            {
                xgm2 = xgm1;
                double p = Math.Cos(u[1]) * Math.Sin(lamda);
                double q = ab[2] - ab[3] * Math.Cos(lamda);
                A1 = Math.Atan(p / q);
                A1 = azimuth_A1(p, q, A1);
                double sindeta = p * Math.Sin(A1) + q * Math.Cos(A1);
                double cosdeta = ab[0] + ab[1] * Math.Cos(lamda);
                deta = Math.Atan(sindeta / cosdeta);
                deta = azimuth_deta(deta);
                double sinA0 = Math.Cos(u[0]) * Math.Sin(A1);
                deta1 = Math.Atan(Math.Tan(u[0]) / Math.Cos(A1));
                cosA0_2 = 1 - Math.Pow(sinA0, 2);
               
                double[] abg = public_algo.Getaf_Beta_Gama(e1, cosA0_2);
                xgm1 = (abg[0] * deta + abg[1] * Math.Cos(2 * deta1 + deta) * Math.Sin(deta) + abg[2] * Math.Sin(2 * deta) * Math.Cos(4 * deta1 + 2 * deta)) * sinA0;
                lamda = l + xgm1;
            } while (Math.Abs(xgm1 - xgm2) * 206265 > 0.00001);
            
        }

        public double A2;
        public double landS()
        {
            double e2 =  e/b;
            double K_2 = Math.Pow(e2, 2) * cosA0_2 ;
            ABC = public_algo.ABC_Cal(K_2, b);
            double xs =ABC[2]* Math.Sin(2 * deta)*Math.Cos(4*deta1+2*deta);
            double S = (deta - ABC[1] * Math.Sin(deta) * Math.Cos(2 * deta1 + deta)-xs) / ABC[0];
            A2 = Math.Atan(Math.Cos(u[0]) * Math.Sin(lamda) / (ab[2] * Math.Cos(lamda) - ab[3]));
            A2  = Math.Abs(A2);
            return S;
        }
    }
}
