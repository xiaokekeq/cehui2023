using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 栅格矩阵7_25
{
    class Algo
    {
        Parse parse1, parse2;
        public Algo(Parse parse1,Parse parse2)
        {
            this.parse1 = parse1;
            this.parse2 = parse2;
        }
        public double V1(int I,int J)
        {
            int n = parse2.data.Count();
            int m = parse2.data[0].X.Length;
            double upper=0, under=0;
             double mij = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int num=judge(i, j, I, J);
                    if (num!=0)
                    {
                        mij=parse2.data[i].X[j,0];
                    }
                    else
                    {
                        mij = 0;
                    }
                    if (Math.Abs(num) >0)
                    {
                        upper += mij * parse1.data[I - i - 1].X[J - j - 1, 0];
                        under += mij;
                    }
                }
            }
            return upper / under;
        }
        public double[,] VIJ()
        {
            int n= parse1.data.Count();
            int m = parse1.data[0].X.Length;
            double[,] matrix = new double[n,m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = V1(i,j);
                }
            }
            return matrix;
        }
        public double V2(int I,int J)
        {
            int i = parse2.data.Count();
            int j = parse2.data[0].X.Length;
            double mij = 0;
            double upper = 0;
            double under = 0;
            for (int n = 0; n < i; n++)
            {
                for (int m = 0; m < j; m++)
                {
                    mij = judge(n,m,I,J);
                    if (mij!=0)
                    {
                        mij = parse2.data[n].X[m, 0];
                    }
                    else
                    {
                        mij = 0;
                    }
                    if (mij>0)
                    {
                        upper += mij * parse1.data[9-(I-n-1)].X[9 - (J - m - 1), 0];
                        under += mij;
                    }
                }
            }
            return upper / under;
        }
        public double[,] VIJ_2()
        {
            int i = parse1.data.Count();
            int j = parse1.data[0].X.Length;
            double[,] V = new double[i, j];
            for (int m = 0; m < i; m++)
            {
                for (int n = 0; n < j; n++)
                {
                    V[m, n] = V2(m,n);
                }
            }
            return V;
        }
        public int judge(int i,int j,int I,int J)
        {
            if (I-i-1<0||J-j-1<0||J-j-1>9||i-i-1>9)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
