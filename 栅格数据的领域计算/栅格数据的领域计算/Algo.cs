using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace 栅格数据的领域计算
{
    internal class Algo
    {

        Parse parse1, parse2=new Parse();
        public Algo(Parse parse1,Parse parse2)
        {
            this.parse1 = parse1;
            this.parse2 = parse2;
            
           
        }
        public double V1(int I,int J)
        {  
            int i = parse1.data.Count;//M矩阵行
            int j = parse1.data[0].X.Length;//M矩阵列
            double upper = 0;
            double under = 0;
            for (int n = 0; n < j; n++)
            {
                for(int m = 0; m < j; m++)
                {
                    double mij = M_IJ(I, J, n, m);//判断Mij==0
                    double eps = 1e-10;
                    if (mij!=0)
                    {
                        mij = parse1.data[n].X[0,m];
                    }
                    else
                    {
                        mij = 0;
                    }
                    if (Math.Abs(mij) > eps)
                    {
                        upper += mij * parse2.data[I-n-1].X[0, J - m - 1];//计算Mij*Nij
                        under += mij;
                    }
                }
            }
            return upper / under;
        }
        public double V2(int I,int J)
        {
            //方法2
            int i = parse1.data.Count;//M矩阵行
            int j = parse1.data[0].X.Length;//M矩阵列
            double upper = 0;
            double under = 0;
            for (int n = 0; n < i; n++)
            {
                for (int m = 0; m < i; m++)
                {
                    double mij = M_IJ(I, J, n, m);
                    double eps = 1e-10;
                    if (mij!=0)
                    {
                        mij = parse1.data[n].X[0,m];
                    }
                    else
                    {
                        mij = 0;
                    }
                    if (Math.Abs(mij) > eps)
                    {
                        upper += mij * parse2.data[9-(I-n-1)].X[0, 9 - (J -m - 1)];//计算Mij*Nij
                        under += mij;
                    }
                }
            }
            return upper/under;
        }
        public double[,] matrixV1()
        {
            int I = parse2.data.Count;//N矩阵行
            int J = parse2.data[0].X.Length;//N矩阵列
            double[,] V = new double[I, J];
            for (int n = 0; n < I; n++)
            {
                for (int m = 0; m < I; m++)
                {
                    V[n,m] = V1(n,m);//计算Vij矩阵
                }
            }
            return V;
        }
        public double[,] matrixV2()
        {
            int I = parse2.data.Count;//N矩阵行
            int J = parse2.data[0].X.Length;//N矩阵列
            double[,] V = new double[I, J];
            for (int n = 0; n < I; n++)
            {
                for (int m = 0; m < I; m++)
                {
                    V[n, m] = V2(n, m);//计算Vij矩阵
                }
            }
            return V;
        }
        public double M_IJ(int I, int J, int i, int j)
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
