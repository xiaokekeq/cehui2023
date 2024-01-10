using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 大地正反算
{
    class Algo
    {
        double a = 0;
        double f = 0;
        public_algo public_Algo = new public_algo();
        double e, b;
        double[] ABC;
        double[] abg;
        public Algo(double a, double f)
        {
            this.a = a;
            this.f = f;
            b = public_Algo.b(a, f);
            e = public_Algo.e(a, b);
            e2 = e / b;
            e1 = e / a;
        }
        double e2;
        double e1;
        double sinu1, cosu1;
        double deta1;
        double deta;
        public double B2, L2, A2;
        public void StartLat(List<DataEntity> zcal,int i)
        {
            double W1 = Math.Sqrt(1-Math.Pow(e1,2)*Math.Pow(Math.Sin(zcal[i].LonS),2));
            sinu1 = Math.Sqrt(1 - Math.Pow(e1, 2)) * Math.Sin(zcal[i].LonS) / W1;
            cosu1 = Math.Cos(zcal[i].LonS) / W1;
        }
        public void auxi_cal(double A1,double L1,double S)
        {
            double SinA1 = Math.Sin(A1);
            double CosA1 = Math.Cos(A1);
            double sinA0 = cosu1 * SinA1;
            double CosA0= 1 - Math.Pow(sinA0, 2);
            double cotdeta1 = cosu1 * CosA1/sinu1;
            deta1 = Math.Atan(1/cotdeta1);
            double K2 = CosA0*e2*e2;
            ABC = public_Algo.ABC_Cal(K2,b);
            abg=public_Algo.Getaf_Beta_Gama(e1, CosA0);
            L(S);
            //计算经差改正数
            double lamda_L = (abg[0] * deta + abg[1] * Math.Sin(deta) * Math.Cos(2 * deta1 + deta) + abg[2] * Math.Sin(2 * deta) * Math.Cos(4 * deta1 + 2 * deta)) * sinA0;
            //计算终点大地坐标及大地方位角
            double sinu2 = sinu1 * Math.Cos(deta) + cosu1 * CosA1 * Math.Sin(deta);
            B2 = Math.Atan(sinu2/(Math.Sqrt(1-Math.Pow(e1,2))*Math.Sqrt(1-Math.Pow(sinu2,2))));
            double lamda = Math.Atan(SinA1 * Math.Sin(deta) / (cosu1 * Math.Cos(deta) - sinu1 * Math.Sin(deta) * CosA1));
            lamda=Judgelamda(lamda,SinA1);
            L2 = L1+ lamda - lamda_L;
            A2 = Math.Atan(cosu1*SinA1/(cosu1*Math.Cos(deta)*CosA1-sinu1*Math.Sin(deta)));
            A2 = JudgeA2(A2,SinA1);
            if (A2 > 2 * Math.PI) A2 -= 2 * Math.PI;
            if (A2 < 0) A2+= 2 * Math.PI;
            if (A1<Math .PI&&A2<Math.PI)
            {
                A2 += Math.PI;
            }
            if (A1 > Math.PI && A2 > Math.PI)
            {
                A2 -= Math.PI;
            }
        }
        public double Judgelamda(double lamda,double SinA1)
        {
            double tanl = Math.Tan(lamda);
            lamda = Math.Abs(lamda);
            if (SinA1>0)
            {
                if (tanl>0)
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
                if (tanl>0)
                {
                    return lamda - Math.PI;
                }
                else
                {
                    return -lamda;
                }
            }
        }
        public double JudgeA2( double A2,double SinA1)
        {
            double tanA2 = Math.Atan(A2);
            A2 = Math.Abs(A2);
            if (SinA1>0)
            {
                if (tanA2>0)
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
        public void L(double S)
        {
            deta = ABC[0] * S;
            double deta_1 = 0;
            do
            {
                deta_1 = deta;
                deta = ABC[0] * S + ABC[1] * Math.Sin(deta) * Math.Cos(2 * deta1 + deta) + ABC[2] * Math.Sin(2 * deta) * Math.Cos(4 * deta1 + 2 * deta);
            } while (Math.Abs(deta_1 - deta) > 0.000000001);
        }

    }
}
