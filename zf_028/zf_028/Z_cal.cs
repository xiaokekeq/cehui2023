using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zf_028
{
    class Z_cal
    {
        double a, b,f;
        double e1_2, e2_2;
        Public_Algo algo = new Public_Algo();
        List<double> ABC = new List<double> ();
        List<double> abg = new List<double>();
        public Z_cal(double a,double f)
        {
            this.a = a;
            this.f = f;
            b = algo.b(a,f);
            e1_2 = algo.e1_2(a,b);
            e2_2 = algo.e2_2(a,b);
        }
        double sinu1, cosu1;
        public void Lgh(List<DataEntity> data,int i)
        {
            double W1 = Math.Sqrt(1 - e1_2 * Math.Sin(data[i].B1) * Math.Sin(data[i].B1));
            sinu1 = Math.Sin(data[i].B1) * Math.Sqrt(1-e1_2)/W1;
            cosu1 = Math.Cos(data[i].B1) / W1;
        }
        double SinA0;
        double deta1;
        public void auxi(double A1)
        {
            SinA0 = cosu1 * Math.Sin(A1);
            double cotdeta = cosu1 * Math.Cos(A1) / sinu1;
            deta1 = Math.Atan(1 / cotdeta);
            double CosA0_2 = algo.CosA0_2(SinA0);
            double K_2 = algo.K_2(e2_2,CosA0_2);
            ABC = algo.ABC(K_2,b);
            abg = algo.abg(e1_2,CosA0_2);
        }
        double deta, deta0;
        public void Sdeta(double S)
        {
            deta = ABC[0] * S;
            deta0 = 0;
            do
            {
                deta0 = deta;
                deta = ABC[0] * S + ABC[1] * Math.Sin(deta) * Math.Cos(2 * deta1 + deta) + ABC[2] * Math.Sin(2 * deta) * Math.Cos(4 * deta1 + 2 * deta);
            } while (Math.Abs(deta0-deta)>1e-10);
        }
        public double L()
        {
            double L = SinA0 * (abg[0] * deta + abg[1] * Math.Cos(2 * deta1 + deta) * Math.Sin(deta) + abg[2] * Math.Sin(2 * deta) * Math.Cos(4 * deta1 + 2 * deta));
            return L;
        }
        public double B2, L2, A21;
        public void B2L2A2(double A1, double L1)
        {
            double sinu2 = sinu1 * Math.Cos(deta) + cosu1 * Math.Sin(deta) * Math.Cos(A1);
            B2 = Math.Atan(sinu2 / (Math.Sqrt(1 - e1_2) * Math.Sqrt(1 - Math.Pow(sinu2, 2))));
            double lamda = Math.Atan(Math.Sin(A1) * Math.Sin(deta) / (cosu1 * Math.Cos(deta) - sinu1 * Math.Sin(deta) * Math.Cos(A1)));
            lamda = judge_lamda(lamda, A1);
            L2 = L1 + lamda - L();
            A21 = Math.Atan(cosu1 * Math.Sin(A1) / (cosu1 * Math.Cos(deta) * Math.Cos(A1) - sinu1 * Math.Sin(deta)));
            A21 = A2(A1, A21);
            A21 = algo.A2_judge(A1, A21);

        }
        public double A2(double A1, double A2)
        {
            double sinA1 = Math.Sin(A1);
            double tanA2 = Math.Tan(A2);
            A2 = Math.Abs(A2);
            if (sinA1 > 0)
            {
                if (tanA2 > 0)
                {
                    return Math.PI + A2;
                }
                else
                {
                    return Math.PI * 2 - A2;
                }
            }
            else
            {
                if (tanA2 > 0)
                {
                    return A2;
                }
                else
                {
                    return Math.PI - A2;
                }
            }
        }
        public double judge_lamda(double lamda, double A1)
        {
            double sinA1 = Math.Sin(A1);
            double tanl = Math.Tan(lamda);
            lamda = Math.Abs(lamda);
            if (sinA1 > 0)
            {
                if (tanl > 0)
                {
                    return lamda;
                }
                else
                {
                    return Math.PI - lamda;
                }
            }
            else
            {
                if (tanl > 0)
                {
                    return lamda - Math.PI;
                }
                else
                {
                    return -lamda;
                }
            }
        }
    }
}
