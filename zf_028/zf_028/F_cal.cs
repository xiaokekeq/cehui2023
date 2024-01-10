using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zf_028
{
    class F_cal
    {
        double a,b, f;
        double e1_2, e2_2;
        Public_Algo algo = new Public_Algo();
        List<double> u;
        List<double> ab;
        List<double> abg = new List<double>();
        List<double> ABC = new List<double>();
        public F_cal(double a,double f)
        {
            this.a = a;
            this.f = f;
            b = algo.b(a,f);
            e1_2 = algo.e1_2(a,b);
            e2_2 = algo.e2_2(a, b);
        }
        double l;
        double deta=0,deta1=0;
        double lamda;
        public double A1;
        public void auxi_cal(int i,List<DataEntity> data)
        {
             u= new List<double>();
             ab= new List<double>();
            double u1 = Math.Atan(Math.Sqrt(1-e1_2)*Math.Tan(data[i].B1));
            double u2 = Math.Atan(Math.Sqrt(1-e1_2)*Math.Tan(data[i].B2));
            u.Add(u1);
            u.Add(u2);
            l = data[i].L2 - data[i].L1;
            double a1 = Math.Sin(u1)*Math.Sin(u2);
            double a2 = Math.Cos(u1) * Math.Cos(u2);
            double b1 = Math.Cos(u1) * Math.Sin(u2);
            double b2 = Math.Sin(u1) * Math.Cos(u2);
            ab.Add(a1);
            ab.Add(a2);
            ab.Add(b1);
            ab.Add(b2);
        }
        public void startAngle()
        {
            lamda = l;
            double xgm0 = 0,xmg=0;
            do
            {
                xgm0 = xmg;
                double p = Math.Cos(u[1]) * Math.Sin(lamda);
                double q = ab[2] -ab[3] * Math.Cos(lamda);
                A1 = Math.Atan(p / q);
                A1 = judge_A1(A1, p, q);
                double sindeta = p * Math.Sin(A1) + q * Math.Cos(A1);
                double cosdeta = ab[0] + ab[1] * Math.Cos(lamda);
                deta = Math.Atan(sindeta / cosdeta);
                deta = judge_deta(deta);
                double sinA0 = Math.Cos(u[0]) * Math.Sin(A1);
                deta1 = Math.Atan(Math.Tan(u[0]) / Math.Cos(A1));
                double CosA0_2 = algo.CosA0_2(sinA0);
                double K_2 = algo.K_2(e2_2, CosA0_2);
                abg = algo.abg(e1_2, CosA0_2);
                ABC = algo.ABC(K_2, b);
                xmg = sinA0 * (abg[0] * deta + abg[1] * Math.Cos(2 * deta1 + deta) * Math.Sin(deta) + abg[2] * Math.Sin(2 * deta) * Math.Cos(4 * deta1 + 2 * deta));
                lamda = l + xmg;
            } while (Math.Abs(xgm0 - xmg) *206265>1e-10);
        }
        public double landS()
        {
            double Xs = ABC[2] * Math.Sin(2 * deta) * Math.Cos(4*deta1+2*deta);
            double S = (deta - ABC[1] * Math.Sin(deta) * Math.Cos(2 * deta1 + deta) - Xs)/ABC[0];
            return S;
        }
        public double A2()
        {
            double a2 = Math.Atan(Math.Cos(u[0]) * Math.Sin(lamda) / (ab[2] * Math.Cos(lamda) - ab[3]));
            a2=algo.A2_judge(A1,a2);
            return a2;
        }
        public double judge_A1(double A1,double p,double q)
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
        public double judge_deta(double deta)
        {
            double cos = Math.Cos(deta);
            deta = Math.Abs(deta);
            if (cos>0)
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
