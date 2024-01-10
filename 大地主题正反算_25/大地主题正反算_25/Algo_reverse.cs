using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 大地主题正反算_25
{
    class Algo_reverse
    {
        public_Algo Algo = new public_Algo();
        List<double> abg = new List<double>();
        List<double> ABC = new List<double>();
        List<double> u;
        List<double> ab;
        double a, f;
        double e1_2, e2_2;
        double b;
        public Algo_reverse(double a,double f)
        {
            this.a = a;
            this.f = f;
            b = Algo.b(a,f);
            e1_2 = Algo.e1_2(a, b);
            e2_2 = Algo.e2_2(a, b);
        }
        double lamda;
        public void auxi_cal(List<DataEntity> reverse, int i)
        {
             u= new List<double>();
            ab = new List<double>();   
            double u1 = Math.Atan(Math.Sqrt(1 - e1_2) * Math.Tan(reverse[i].B1));
            double u2 = Math.Atan(Math.Sqrt(1 - e1_2) * Math.Tan(reverse[i].B2));
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
           lamda = reverse[i].L2 - reverse[i].L1;
        }
        public double A1, deta1, deta;
        public void Startazimuth()
        {
            double xgm=0, xgm0=0;
            double l = lamda;
            do
            {
                xgm0 = xgm;
                double p = Math.Cos(u[1]) * Math.Sin(lamda);
                double q = ab[2] - ab[3] * Math.Cos(lamda);
                A1 = Math.Atan(p / q);
                A1 = A1Judge(A1, p, q);
                double sindeta = p * Math.Sin(A1) + q * Math.Cos(A1);
                double cosdeta = ab[0] + ab[1] * Math.Cos(lamda);
                deta = Math.Atan(sindeta / cosdeta);
                deta = deta_judge(deta);
                double SinA0 = Math.Cos(u[0]) * Math.Sin(A1);
                deta1 = Math.Atan(Math.Tan(u[0]) / Math.Cos(A1));
                double CosA0_2 = Algo.CosA0_2(SinA0);
                abg = Algo.abg(e1_2,CosA0_2);
                double K_2 = Algo.K_2(e2_2,CosA0_2);
                ABC = Algo.ABC(K_2,b);
                xgm = SinA0*(abg[0] * deta + abg[1] * Math.Cos(2 * deta1 + deta) * Math.Sin(deta) + abg[2] * Math.Sin(2 * deta) * Math.Cos(4 * deta1 + 2 * deta));
                lamda =l+xgm;
            } while (Math.Abs(xgm-xgm0)*206265>1e-10);
        }
        public double s;
        public double S()
        {
            double Xs = ABC[2] * Math.Sin(2 * deta) * Math.Cos(4 * deta1 + 2 * deta);
            s = (deta - ABC[1] * Math.Sin(deta) * Math.Cos(deta1 * 2 + deta) - Xs)/ABC[0];
            return s;
        }
        public double A21;
        public double A2()
        {
             A21 = Math.Atan(Math.Cos(u[0]) * Math.Sin(lamda) / (ab[2] * Math.Cos(lamda) - ab[3]));
            return Algo.A2_Judge(A1,A21);
        }
        public double A1Judge(double A1,double p,double q)
        {
            A1 = Math.Abs(A1);
            if (p>0)
            {
                if (q>0)
                {
                    return A1;
                }
                else
                {
                    return Math.PI - A1;
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
        public double deta_judge(double deta)
        {
            double cosdeta = Math.Cos(deta);
            deta = Math.Abs(deta);
            if (cosdeta>0)
            {
                return deta;
            }
            else
            {
                return Math.PI - deta;
            }
        }
      
    }
}
