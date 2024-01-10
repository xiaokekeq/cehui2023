using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 栅格数据的领域计算_0721
{
    class Algo
    {
        Parse parse1, parse2 = new Parse();
        public Algo(Parse parse1,Parse parse2)
        {
            this.parse1 = parse1;//N
            this.parse2 = parse2;//M
        }
        public double VIJ1(int I,int J)
        {
            int i = parse2.data.Count();//矩阵行
            int j = parse2.data[0].X.Length;//矩阵列
            double under = 0;
            double upper = 0;
            for (int n = 0; n < j; n++)
            {
                for (int m = 0; m < j; m++)
                {
                    double mij = M_IJ(n,m,I,J);
                    if (mij == 0)
                    {
                         mij = 0;
                    }
                    else
                    {
                        mij = parse2.data[n].X[0, m];
                    }
                    if (Math.Abs(mij) > 0)
                    {
                        upper += mij* parse1.data[9 - (I - n - 1)].X[0, 9 - (J - m - 1)];
                        under += mij;
                    }
                }
            }
            return upper / under;
        }
        public double VIJ2(int I, int J)
        {
            int i = parse2.data.Count();
            int j = parse2.data[0].X.Length;
            double upper = 0;
            double under = 0;
            for (int n = 0; n < i; n++)
            {
                for (int m = 0; m < i; m++)
                {
                    double mij = M_IJ(n,m,I,J);
                    if (mij==0)
                    {
                        mij = 0;
                    }
                    else
                    {
                        mij = parse2.data[n].X[0, m];
                    }
                    if (Math.Abs(mij)>0)
                    {
                        upper += mij * parse1.data[I - n - 1].X[0, J - m - 1];
                        under += mij;
                    }
                }

            }
            return upper / under;
        }
        public double[,] MatrixVIJ()
        {
            int I = parse1.data.Count();
            int J = parse1.data[0].X.Length;
            double[,] V = new double[I, J];
            for (int i = 0; i <I; i++)
            {
                for (int j = 0; j < J; j++)
                {
                    V[i, j] = VIJ1(i,j);
                }
            }
            return V;
        }
        public double[,] MatrixVIJ2()
        {
            
            int i = parse1.data.Count();
            int j = parse1.data[0].X.Length;
            double[,] matrix = new double[i, j];
            for (int n = 0; n < i; n++)
            {
                for (int m = 0; m < j; m++)
                {
                    matrix[n, m] = VIJ2(n, m);
                }
            }
            return matrix;
        }
        /// <summary>
        /// 判断VIJ
        /// </summary>
        /// <param name="i">计算每次MN矩阵的i</param>
        /// <param name="j"></param>
        /// <param name="I">外层VIJ</param>
        /// <param name="J"></param>
        /// <returns></returns>
        public double M_IJ(int i,int j,int I,int J)
        {
            if (I - i - 1 < 0 || J - j - 1 < 0 || I - i - 1 > 9 || J - j - 1 > 9)
            {
                return 0;
            }
            else {
                return 1;
             }
        }
    }
}
