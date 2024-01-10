using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace 栅格数据
{
    internal class Algo
    {
        Parse parse1, parse2=new Parse();
        public Algo(Parse parse1,Parse parse2)
        {
            this.parse1 = parse1;
            this.parse2 = parse2;
        }
        //Mij判断是否为0
        public double Mij(int I,int J,int i,int j) 
        {
           if (I-i-1<0||J-j-1<0||I-i-1>9||J-j-1>9)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        //计算V1每一个值
        public double V1(int I,int J)
        {
            int j = parse1.data[0].X.Length;//M矩阵列
            int i = parse1.data.Count;//M矩阵行
            double upper= 0;
            double under= 0;
            for (int n = 0; n < i; n++)
            {
                for (int m = 0; m < j; m++)
                {
                    double mij=Mij(I,J,n, m);
                    if (mij!=0)
                    {
                        mij = parse1.data[n].X[0, m];
                        upper += mij * parse2.data[I - n - 1].X[0, J - m - 1];
                        under += mij;
                    }      
                }
            }
            return upper / under;
        }
        //每一个值构成V矩阵
        public double[,] matrixV1()
        {
            int I = parse2.data.Count;//N矩阵行数
            int J = parse2.data[0].X.Length;//N矩阵列
            double[,] V = new double[I, J];
            for (int n = 0; n < I; n++)
            {
                for (int m = 0; m < J; m++)
                {
                    V[n, m] = V1(n,m);
                }
            }
            return V;
        }
        public double V2(int I, int J)
        {
            int j = parse1.data[0].X.Length;//M矩阵列
            int i = parse1.data.Count;//M矩阵行
            double upper = 0;
            double under = 0;
            for (int n = 0; n < i; n++)
            {
                for (int m = 0; m < j; m++)
                {
                    double mij = Mij(I, J, n, m);
                    if (mij != 0)
                    {
                        mij = parse1.data[n].X[0, m];
                        upper += mij * parse2.data[9 - (I - n - 1)].X[0, 9 - (J - m - 1)];
                        under += mij;
                    }

                }
            }
            return upper / under;
        }
        public double[,] matrixV2()
        {
            int I = parse2.data.Count;//N矩阵行数
            int J = parse2.data[0].X.Length;//N矩阵列
            double[,] V = new double[I, J];
            for (int n = 0; n < I; n++)
            {
                for (int m = 0; m < J; m++)
                {
                    V[n, m] = V2(n, m);
                }
            }
            return V;
        }
    }
}
