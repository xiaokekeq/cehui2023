using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 大地主题正反算
{
    class Algo
    {
        double a, f;
        public Algo(double a,double f)
        {
            this.a = a;
            this.f = f;

        }
        double sinu1,cosu1;
        double e1_2;
       public  public_algo public_Algo = new public_algo();
        public void StartLat(List<DataEntity> Z,int i)
        {
            b = public_Algo.b(a, f);
            e1_2 = public_Algo.e1_2(a, b);
            double W1 = Math.Sqrt(1-e1_2*Math.Pow(Math.Sin(Z[i].B1),2));
            sinu1 = Math.Sin(Z[i].B1) * Math.Sqrt(1 - e1_2)/W1;
            cosu1 = Math.Cos((Z[i].B1)) / W1;
        }
        double sinA0, cotdeta1, deta1;
        double e2_2, CosA_2, K_2,b;
        public void auxi_cal(double A1)
        {
            sinA0 = cosu1 * Math.Sin(A1);
            cotdeta1 = cosu1 * Math.Cos(A1)/sinu1;
            deta1 = Math.Atan(1/cotdeta1);
           
            e2_2 = public_Algo.e2_2(a, b);
            CosA_2 = public_Algo.CosA_2(sinA0);
            K_2 = public_Algo.K_2(e2_2, CosA_2);
        }
        double deta;
        public void S(double S)
        {
            List<double> ABC=public_Algo.ABC(K_2,b);
            deta = ABC[0] * S;
            double deta_0 = 0;
            do
            {
                deta_0 = deta;
                deta = ABC[0] * S + ABC[1] * Math.Sin(deta) * Math.Cos(2 * deta1 + deta) + ABC[2] * Math.Sin(2 * deta) * Math.Cos(4 * deta1 + 2 * deta);
            } while (Math.Abs(deta_0-deta) > 0.0000000001);
        }

        public double L()
        {
           
            List<double> abg = public_Algo.abg(e1_2, CosA_2);
            double L = (abg[0] * deta + abg[1] *Math.Sin(deta)* Math.Cos(2 * deta1 + deta) + abg[2] * Math.Sin(2 * deta) * Math.Cos(4 * deta1 + deta * 2))*sinA0;
            return L;
        }
        public double lamda_judge(double lamda,double sinA1)
        {
            double tanlamda = Math.Tan(lamda);
            lamda = Math.Abs(lamda);
            if (sinA1>0)
            {
                if (tanlamda>0)
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
                if (tanlamda>0)
                {
                    return lamda - Math.PI;
                }
                else
                {
                    return -lamda;
                }
            }
        }
        public double A2_judge(double A1,double A2)
        {
            double sinA1 = Math.Sin(A1);
            double tanA2 = Math.Tan(A2);
            A2 = Math.Abs(A2);
            if (sinA1>0)
            {
                if (tanA2>0)
                {
                    return A2 + Math.PI;
                }
                else
                {
                    return Math.PI * 2 - A2;
                }
            }
            else
            {
                if (tanA2>0)
                {
                    return A2;
                }
                else
                {
                    return Math.PI - A2;
                }
            }

        }
        public void L_A(double A1,double L1,ref double B2,ref double A2,ref double L2)
        {
            double sinu2 = sinu1 * Math.Cos(deta) + cosu1 * Math.Cos(A1) * Math.Sin(deta);
            B2 = Math.Atan(sinu2 / (Math.Sqrt(1 - e1_2) * Math.Sqrt(1 - Math.Pow(sinu2, 2))));
            double lamda = Math.Atan(Math.Sin(A1) * Math.Sin(deta) / (cosu1 * Math.Cos(deta) - sinu1 * Math.Sin(deta) * Math.Cos(A1)));
            lamda= lamda_judge(lamda,Math.Sin(A1));
            L2 = L1 +lamda-L();
            A2 = Math.Atan(cosu1 * Math.Sin(A1)/(cosu1*Math.Cos(deta)*Math.Cos(A1)-sinu1*Math.Sin(deta)));
            A2 = A2_judge(A1,A2);
            A2=public_Algo.A2_A1_judge(A2,A1);
        }
    }
}
