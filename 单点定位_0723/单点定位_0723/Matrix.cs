using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 单点定位_0723
{
    class Matrix
    {
        public int m;
        public int n;
        public double[,] arr;

        /// <summary>
        /// 创建一个矩阵0*0
        /// </summary>
        public Matrix()
        {
            m = 0;
            n = 0;
            arr = new double[m, n];
        }

        /// <summary>
        /// 拷贝构造
        /// </summary>
        /// <param name="s"></param>
        public Matrix(Matrix s)
        {
            this.m = s.m;
            this.n = s.n;
            arr = new double[m, n];
            this.arr = s.arr;
        }

        public Matrix(int mm, int nn, double[,] arr)
        {
            m = mm;
            n = nn;
            this.arr = arr;
        }

        public Matrix(int mm, int nn)
        {
            m = mm;
            n = nn;
            arr = new double[m, n];
        }

        public Matrix MatrixE(int mm, int nn)
        {
            Matrix matrix = new Matrix(mm, nn);
            m = mm;
            n = nn;
            if (nn==mm)
            {
                arr = new double[m, n];
            }
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = 1;
                }
            }
            return matrix;
        }

        /// <summary>
        /// 重载操作符实现矩阵加法
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        static public Matrix operator +(Matrix A, Matrix B)
        {
            Matrix C = new Matrix(A.m, A.n);
            //判断是否可以运算    
            if (A.m != B.m || A.n != B.n || A.m != C.m || A.n != C.n)
            {
                System.Windows.Forms.MessageBox.Show("矩阵维数不同");
            }
            for (int i = 0; i < C.m; i++)
            {
                for (int j = 0; j < C.n; j++)
                {
                    C.arr[i, j] = A.arr[i, j] + B.arr[i, j];
                }
            }

            return C;
        }

        /// <summary>
        /// 重载操作符实现矩阵减法
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        static public Matrix operator -(Matrix A, Matrix B)
        {
            int i = 0;
            int j = 0;
            Matrix C = new Matrix(A.m, B.n);
            //判断是否可以运算    
            if (A.m != B.m || A.n != B.n ||
                A.m != C.m || A.n != C.n)
            {
                Console.ReadKey();
            }
            for (i = 0; i < C.m; i++)
            {
                for (j = 0; j < C.n; j++)
                {
                    C.arr[i, j] = A.arr[i, j] - B.arr[i, j];
                }
            }
            return C;
        }

        /// <summary>
        /// 重载操作符实现矩阵乘法
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        static public Matrix operator *(Matrix A, Matrix B)
        {
            int i = 0;
            int j = 0;
            int k = 0;
            double temp = 0;
            Matrix C = new Matrix(A.m, B.n);
            //判断是否可以运算    
            if (A.m != C.m || B.n != C.n ||
                A.n != B.m)
            {
                return C;
            }
            //运算    
            for (i = 0; i < C.m; i++)
            {
                for (j = 0; j < C.n; j++)
                {
                    temp = 0;
                    for (k = 0; k < A.n; k++)
                    {
                        temp += A.arr[i, k] * B.arr[k, j];
                    }
                    C.arr[i, j] = temp;
                }
            }
            return C;
        }

        /// <summary>
        /// 矩阵转置
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public Matrix transposs(Matrix A)
        {
            int i = 0;
            int j = 0;
            Matrix B = new Matrix(A.n, A.m);
            for (i = 0; i < B.m; i++)
            {
                for (j = 0; j < B.n; j++)
                {
                    B.arr[i, j] = A.arr[j, i];
                }
            }
            return B;
        }

        public double[,] InverseMatrix(double[,] matrix)
        {
            int n = matrix.GetLength(0);
            double[,] result = new double[n, n];
            double[,] temp = new double[n, 2 * n];

            //将矩阵和单位矩阵拼接成一个2n*n的矩阵
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    temp[i, j] = matrix[i, j];
                    temp[i, j + n] = i == j ? 1 : 0;
                }
            }
            //高斯-约旦消元法
            for (int i = 0; i < n; i++)
            {
                double tempValue = temp[i, i];
                for (int j = i; j < 2 * n; j++)
                {
                    temp[i, j] /= tempValue;
                }
                for (int j = 0; j < n; j++)
                {
                    if (j != i)
                    {
                        tempValue = temp[j, i];
                        for (int k = i; k < 2 * n; k++)
                        {
                            temp[j, k] -= tempValue * temp[i, k];
                        }
                    }
                }
            }
            //取出逆矩阵
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    result[i, j] = temp[i, j + n];
                }
            }

            return result;
        }

        /// <summary>
        /// 矩阵求逆
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public Matrix Inverse(Matrix matrix)
        {
            matrix.arr = InverseMatrix(matrix.arr);
            return matrix;
        }

    }
}
