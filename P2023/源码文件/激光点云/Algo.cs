using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 激光点云
{
    class Algo
    {
        public double x, y, z;
        public void Mx(List<DataEntity> data,ref double Xmax,ref double Xmin)
        {
            Xmax = 0;
            Xmin = 0;
            for (int i = 0; i < data.Count(); i++)
            {
                for (int j = 0; j < data.Count()-i-1; j++)
                {
                    if (data[j].X>data[j+1].X)
                    {
                        DataEntity temp = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = temp;
                    }
                }
            }
            Xmin = data[0].X;
            Xmax = data[data.Count() - 1].X;
        }
        public void MY(List<DataEntity> data, ref double Ymax, ref double Ymin)
        {
            Ymax = 0;
            Ymin = 0;
            for (int i = 0; i < data.Count(); i++)
            {
                for (int j = 0; j < data.Count() - i - 1; j++)
                {
                    if (data[j].Y> data[j + 1].Y)
                    {
                        DataEntity temp = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = temp;
                    }
                }
            }
            Ymin = data[0].Y;
            Ymax = data[data.Count() - 1].Y;
        }
        public void MZ(List<DataEntity> data, ref double Zmax, ref double Zmin)
        {
            Zmax = 0;
            Zmin = 0;
            for (int i = 0; i < data.Count(); i++)
            {
                for (int j = 0; j < data.Count() - i - 1; j++)
                {
                    if (data[j].Z> data[j + 1].Z)
                    {
                        DataEntity temp = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = temp;
                    }
                }
            }
            Zmin = data[0].Z;
            Zmax = data[data.Count() - 1].Z;
        }
        public List<DataEntity> C = new List<DataEntity>();
        public List<DataEntity> shange = new List<DataEntity>();//
        public void sghua(List<DataEntity> data)
        {
            double dx = 10;
            double dy = 10;
            for (int m = 0; m < data.Count(); m++)
            {
                data[m].i = Math.Floor(data[m].Y / dy);
                data[m].j= Math.Floor(data[m].X / dx);
            }
            for (int i = 0; i < data.Count(); i++)
            {
                if (data[i].Y > 30 && data[i].Y < 40 && data[i].X > 20 && data[i].X < 30)
                {
                    C.Add(data[i]);

                }
            }
            /*
            int x = 0;
            for (int n = 0; n < Math.Pow(dx,2); n+=10)//x
            {
                for (int m = 0; m < Math.Pow(dy,2); m+=10)//y
                {
                    if (data[x].X > n && data[x].X < n+10 && data[x].Y > m && data[x].Y < m+10)
                    {
                        data[m].local[n, m] = 0;
                    }
                    x++;
                }
            }
            */
           

        }
        public double aveElev = 0;
        public double Hc = 0;
        public double Hc_2 = 0;
        public void geo()
        {
            double size = C.Count();
            double sum_Z = 0;
            double Zmax = 0;
            double Zmin = 0;
            for (int i = 0; i < C.Count(); i++)
            {
                sum_Z += C[i].Z;
            }
            aveElev = 1 / size * (sum_Z);
           MZ(C,ref Zmax,ref Zmin);
            Hc = Zmax - Zmin;
            double Z_fc = 0;
            for (int i = 0; i < C.Count(); i++)
            {
                Z_fc += C[i].Z - aveElev;
            }
            Hc_2 = 1 / size * (Z_fc);
        }
        public List<double[,]> ABDC = new List<double[,]>();
        public List<double[,]> ABCD(DataEntity d1,DataEntity d2,DataEntity d3)
        {
            double[,] abcd = new double[4, 1];
            double A = (d2.Y - d1.Y) * (d3.Z - d1.Z) - (d3.Y - d1.Y) * (d2.Z - d1.Z);
            double B = (d2.Z - d1.Z) * (d3.X - d1.X) - (d3.Z - d1.Z) * (d2.X - d1.X);
            double C = (d2.X - d1.X) * (d3.Y - d1.Y) - (d3.X - d1.X) * (d2.Y - d1.Y);
            double D = -A * d1.X - B * d1.Y - C * d1.Z;
            abcd[0, 0] = A;
            abcd[1, 0] = B;
            abcd[2, 0] = C;
            abcd[3, 0] = D;
            ABDC.Add(abcd);
            return ABDC;
        }
        public double Dis(DataEntity d1,DataEntity d2)
        {
            return Math.Sqrt(Math.Pow(d1.X - d2.X, 2)+ Math.Pow(d1.Y - d2.Y, 2));
        }
        public void threePoint(DataEntity d1, DataEntity d2, DataEntity d3)
        {
            d1.dis = Dis(d1, d2);
            d2.dis = Dis(d2, d3);
            d3.dis = Dis(d3, d1);
            double p = (d1.dis + d2.dis + d3.dis) / 2;
            S = Math.Sqrt(p * (p - d1.dis) * (p - d2.dis) * (p - d3.dis));
            if (S>0.1)
            {
                S_all.Add(S);
            }
            else
            {
                S_all.Add(0);
            }
           
        }
       public double S1 = 0;
       public double S = 0;
        public List<double> S_all=new List<double>();
        /// <summary>
        /// 面积分割
        /// </summary>
        /// <param name="data">所有点数据</param>
        public void areasplit(List<DataEntity> data)
        {
            threePoint(data[0], data[1], data[2]);
            data[0].dis = Dis(data[0],data[1]);
            data[1].dis = Dis(data[1],data[2]);
            data[2].dis = Dis(data[2],data[0]);
            double p = (data[0].dis+ data[1].dis+ data[2].dis) / 2;
            S1 = Math.Sqrt(p*(p- data[0].dis)* (p - data[1].dis)* (p - data[2].dis));
            if (S1>0.1)
            {
                ABCD(data[0], data[1], data[2]);
            }       
        }
        /// <summary>
        /// 距离公式
        /// </summary>
        /// <param name="data"></param>
        /// <param name="ABCD"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public double d(DataEntity data,List<double[,]> ABCD,int i)
        {
            double d1 = Math.Abs(ABCD[i][0, 0] * data.X + ABCD[i][1,0] * data.Y + ABCD[i][2,0] * data.Z + ABCD[i][3, 0]) / Math.Sqrt(Math.Pow(ABCD[i][0, 0], 2)+ Math.Pow(ABCD[i][1, 0], 2)+ Math.Pow(ABCD[i][2, 0], 2));
            return d1;
        }
        List<List<double>> dp_all = new List<List<double>>();
        List<DataEntity> dp = new List<DataEntity>();
        List<DataEntity> dp_out = new List<DataEntity>();
        double[,] dp_3001 = new double[300,1];
        double[,] dp_3002 = new double[300,1];
        /// <summary>
        /// 内外点
        /// </summary>
        /// <param name="data">所有点数据</param>
        public  void in_out(List<DataEntity> data)
        {
            int n = 1;
            double dp0 = d(data[999], ABDC, 0);
            double dp5 = d(data[4], ABDC, 0);
            for (int i = 0; i < data.Count(); i++)
            {
                double tmp= d(data[i], ABDC, 0);
                if (tmp<0.1)
                {
                    dp.Add(data[i]);
                }
                else
                {
                    dp_out.Add(data[i]);
                }
            }
            for (int i = 3; i <900; i += 3)
            {
                double dp1 = 0;
                double dp2 = 0;
                double l = 0;
                threePoint(data[i], data[i + 1], data[i + 2]);
                ABCD(data[i], data[i + 1], data[i + 2]);
                dp = new List<DataEntity>();
                dp_out = new List<DataEntity>();
                for (int j = 0; j < data.Count(); j++)
                {
                    double tmp = d(data[j], ABDC, n);
                    if (tmp < 0.1)
                    {
                        dp1++;
                        dp.Add(data[j]);
                    }
                    else
                    {
                        dp2++;
                        dp_out.Add(data[j]);
                    }
                }
                dp_3001[n, 0]=dp1;
                dp_3002[n, 0]=dp2;
                if (dp_3002[n , 0] == 260)
                {
                    l = dp_3001[n, 0];
                    break;
                }
                n++;
            }
            double d1 = Math.Pow(ABDC[69][0, 0], 2) + Math.Pow(ABDC[69][1, 0], 2) + Math.Pow(ABDC[69][2, 0], 2);
            x = ((ABDC[69][1, 0] * ABDC[69][1, 0] + ABDC[69][2, 0] * ABDC[69][2, 0] )* data [4].X- ((ABDC[69][1, 0]*data[4].Y + ABDC[69][2, 0]* data[4].Z + ABDC[69][3, 0])* ABDC[69][0,0]));
             y = ((ABDC[69][0, 0] * ABDC[69][0 ,0] + ABDC[69][2, 0] * ABDC[69][2, 0] )* data [4].Y- ((ABDC[69][0, 0]*data[4].Y + ABDC[69][2, 0]* data[4].Z + ABDC[69][3, 0])* ABDC[69][1,0]));
            z = ((ABDC[69][0, 0] * ABDC[69][0, 0] + ABDC[69][1, 0] * ABDC[69][1, 0] )* data [4].Z- ((ABDC[69][0, 0]*data[4].Y + ABDC[69][1, 0]* data[4].Z + ABDC[69][3, 0])* ABDC[69][2,0]));


            List<DataEntity>  dp_1 = new List<DataEntity>();
            List<DataEntity>  dpout_2 = new List<DataEntity>();
            n = 0;
            ABDC = new List<double[,]>();
            S_all = new List<double>();
            for (int i = 0; i < 240; i+=3)
            {
                double dp1 = 0;
                double dp2 = 0;
                threePoint(dp_out[i], dp_out[i + 1], dp_out[i + 2]);
                ABCD(dp_out[i], dp_out[i + 1], dp_out[i + 2]);
                dp_1 = new List<DataEntity>();
                dpout_2 = new List<DataEntity>();
                double l = 0;
                for (int j = 0; j < dp_out.Count(); j++)
                {
                    double tmp = d(dp_out[j], ABDC, n);
                    if (tmp < 0.1)
                    {
                        dp1++;
                        dp_1.Add(dp_out[j]);
                    }
                    else
                    {
                        dp2++;
                        dpout_2.Add(dp_out[j]);
                    }
                }
                if (dp1 ==137)
                {
                    l = dp_3001[n, 0];
                    break;
                }
                n++;
            }
           
            for (int i = 0; i < 100; i += 3)
            {
                threePoint(data[i], data[i + 1], data[i + 2]);
                ABCD(data[i], data[i + 1], data[i + 2]);
                d(data[i], ABDC, n);
                n++;
            }
            double a = 0;
        }
     
    }
}
