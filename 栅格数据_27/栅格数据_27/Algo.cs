using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 栅格数据_27
{
    class Algo
    {
        Parse parse1, parse2;
        public Algo(Parse parse1 ,Parse parse2)
        {
            this.parse1 = parse1;
            this.parse2 = parse2;
        }
       public double Vij1(int I,int J)
        {
            int i = parse2.data.Count();
            int j = parse2.data[0].X.Length;
            double upper = 0;
            double under = 0;
            for (int n = 0;n < i; n++)
            {
                for (int m= 0; m< i; m++)
                {
                    double mij = judge(n,m,I,J);
                    if (mij==0)
                    {
                        mij = 0;
                    }
                    else
                    {
                        mij = parse2.data[n].X[0, m];
                    }
                    if (mij>0)
                    {
                        upper += mij * parse1.data[I - n - 1].X[0, J - m - 1];
                        under += mij;
                    }
                }
            }
            return upper / under;
        }
        public double Vij2(int I, int J)
        {
            int i = parse2.data.Count();
            int j = parse2.data[0].X.Length;
            double upper = 0;
            double under = 0;
            for (int n = 0; n < i; n++)
            {
                for (int m = 0; m < i; m++)
                {
                    double mij = judge(n, m, I, J);
                    if (mij == 0)
                    {
                        mij = 0;
                    }
                    else
                    {
                        mij = parse2.data[n].X[0, m];
                    }
                    if (mij > 0)
                    {
                        upper += mij * parse1.data[9-(I - n- 1)].X[0, 9-(J - m- 1)];
                        under += mij;
                    }
                }
            }
            return upper / under;
        }
        public double[,] V1()
        {
            int I = parse1.data.Count();
            int J = parse1.data[0].X.Length;
            double[,] matrix = new double[I, J];
            for (int i = 0; i < I; i++)
            {
                for (int j = 0; j < J; j++)
                {
                    matrix[i, j] = Vij1(i,j);
                }
            }
            return matrix;
        }
        public double[,] V2()
        {
            int I = parse1.data.Count();
            int J = parse1.data[0].X.Length;
            double[,] matrix = new double[I, J];
            for (int i = 0; i < I; i++)
            {
                for (int j = 0; j < J; j++)
                {
                    matrix[i, j] = Vij2(i, j);
                }
            }
            return matrix;
        }
        public double judge(int i,int j,int I,int J)
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
    }
}
