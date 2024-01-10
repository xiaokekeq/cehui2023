using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 大地主题正反算
{
    class Algo_reverse
    {
        double f,a;
        public Algo_reverse(double f,double a)
        {
            this.f = f;
            this.a = a;
        }
        Parse parse = new Parse();
        public public_algo public_algo = new public_algo();
        double l = 0;
        double b ,e1_2,e2_2;
        public List<double> u;
        public List<double> ab;
        public void auxi(List<DataEntity> reverse,int i)
        {
            u = new List<double>();
            ab = new List<double>();
            b = public_algo.b(a, f);
            e1_2 = public_algo.e1_2(a,b);
            e2_2 = public_algo.e2_2(a,b);
            double u1 = Math.Atan(Math.Tan(reverse[i].B1)*Math.Sqrt(1-e1_2));
            double u2 = Math.Atan(Math.Tan(reverse[i].B2)*Math.Sqrt(1 -e1_2));
            u.Add(u1);
            u.Add(u2);
            double a1 = Math.Sin(u1)*Math.Sin(u2);
            double a2 = Math.Cos(u1)*Math.Cos(u2);
            double b1 = Math.Cos(u1) * Math.Sin(u2);
            double b2 = Math.Sin(u1) * Math.Cos(u2);
            ab.Add(a1);
            ab.Add(a2);
            ab.Add(b1);
            ab.Add(b2);
            l = reverse[i].L2 - reverse[i].L1;
        }
        double deta,deta1;
        public List<double> abg,ABC;
        public double judgeA12(double p,double q,double A1)
        {
           A1= Math.Abs(A1);
            if (p>0)
            {
                if (q>0)
                {
                    return A1;
                }
                else
                {
                    return Math.PI-A1;
                }
            }
            else
            {
                if (q>0)
                {
                    return Math.PI * 2 - A1;
                }
                else
                {
                    return Math.PI + A1;
                }
            }
        }
        double lamda;
        public double StartA1()
        {
            lamda = l;
            double xgm1 = 0;
            double xgm = 0;
            double A1;
            do
            {
                xgm1 = xgm;
                double p = Math.Cos(u[1]) * Math.Sin(lamda);
                double q = ab[2] - ab[3] * Math.Cos(lamda);
                A1 = Math.Atan(p / q);
                A1 = judgeA12(p, q, A1);
                double sindeta = p * Math.Sin(A1) + q * Math.Cos(A1);
                double cosdeta = ab[0] + ab[1] * Math.Cos(lamda);
                deta = Math.Atan(sindeta / cosdeta);
                double sinA0 = Math.Cos(u[0]) * Math.Sin(A1);
                deta1 = Math.Atan(Math.Tan(u[0]) / Math.Cos(A1));
                double CosA_2 = public_algo.CosA_2(sinA0);
                abg = public_algo.abg(e1_2, CosA_2);
                double K_2 = public_algo.K_2(e2_2, CosA_2);
                ABC = public_algo.ABC(K_2, b);
                xgm = sinA0 * (abg[0] * deta + abg[1] * Math.Cos(2 * deta1 + deta) * Math.Sin(deta) + abg[2] * Math.Sin(2 * deta) * Math.Cos(4 * deta1 + 2 * deta));
                lamda = l + xgm;
            } while (Math.Abs(xgm-xgm1)*206265> 0.0000000001);
            return A1;
        }
        public double S()
        {
            double Xs = ABC[2] * Math.Sin(2 * deta) * Math.Cos(4 * deta1 + 2 * deta);
            double S = (deta - ABC[1] * Math.Sin(deta) * Math.Cos(2 * deta1 + deta) - Xs)/ABC[0];
            return S;
        }
        public double A2(double A1)
        {
            double A2= Math.Atan((Math.Cos(u[0]) * Math.Sin(lamda)) / (ab[2] * Math.Cos(lamda) - ab[3]));
            A2= public_algo.A2_A1_judge(A2,A1);
            return A2;
        }
    }
}
