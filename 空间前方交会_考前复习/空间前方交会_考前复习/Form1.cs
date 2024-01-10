using System;
using System.Diagnostics.Eventing.Reader;

namespace 空间前方交会_考前复习
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string text = "";
        double Xs1, Xs2, Ys1, Ys2, Zs1, Zs2;
        double fai1, fai2;
        double k1, k2;
        double w1, w2;
        double f1, f2;
        double x1, x2;
        double y1, y2;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.txt|*.txt";
            ofd.Title = "前方交会数据";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(ofd.FileName))
                {
                    Xs1 = Convert.ToDouble(sr.ReadLine());
                    Ys1 = Convert.ToDouble(sr.ReadLine());
                    Zs1 = Convert.ToDouble(sr.ReadLine());
                    fai1 = Convert.ToDouble(sr.ReadLine());
                    w1 = Convert.ToDouble(sr.ReadLine());
                    k1 = Convert.ToDouble(sr.ReadLine());
                    x1 = Convert.ToDouble(sr.ReadLine());
                    y1 = Convert.ToDouble(sr.ReadLine());
                    f1 = Convert.ToDouble(sr.ReadLine());
                    Xs2 = Convert.ToDouble(sr.ReadLine());
                    Ys2 = Convert.ToDouble(sr.ReadLine());
                    Zs2 = Convert.ToDouble(sr.ReadLine());
                    fai2 = Convert.ToDouble(sr.ReadLine());
                    w2 = Convert.ToDouble(sr.ReadLine());
                    k2 = Convert.ToDouble(sr.ReadLine());
                    x2 = Convert.ToDouble(sr.ReadLine());
                    y2 = Convert.ToDouble(sr.ReadLine());
                    f2 = Convert.ToDouble(sr.ReadLine());
                }
                textBox1.Text = Xs1.ToString("0.00000");
                textBox2.Text = Ys1.ToString("0.00000");
                textBox3.Text = Zs1.ToString("0.00000");
                textBox4.Text = fai1.ToString("0.00000");
                textBox5.Text = w1.ToString("0.00000");
                textBox6.Text = k1.ToString("0.00000");
                textBox7.Text = x1.ToString("0.00000");
                textBox8.Text = y1.ToString("0.00000");
                textBox9.Text = f1.ToString("0.00000");

                textBox10.Text = Xs2.ToString("0.00000");
                textBox11.Text = Ys2.ToString("0.00000");
                textBox12.Text = Zs2.ToString("0.00000");
                textBox13.Text = fai2.ToString("0.00000");
                textBox14.Text = w2.ToString("0.00000");
                textBox15.Text = k2.ToString("0.00000");
                textBox16.Text = x2.ToString("0.00000");
                textBox17.Text = y2.ToString("0.00000");
                textBox18.Text = f2.ToString("0.00000");

            }
            else
            {
                MessageBox.Show("open error", "open", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        double PI = Math.PI;
        public double cpt(double num)
        {
            return ((num / 360) * 2 * PI);
        }
        double u1, u2;
        double v1, v2;
        double w11, w12;
        private void button2_Click(object sender, EventArgs e)
        {
            double a11, a12, a13;
            double b11, b12, b13;
            double c11, c12, c13;
            double a21, a22, a23;
            double b21, b22, b23;
            double c21, c22, c23;
            a11 = Math.Cos(cpt(fai1)) * Math.Cos(cpt(k1)) - Math.Sin(cpt(fai1)) * Math.Sin(cpt(w1)) * Math.Sin(cpt(k1));
            a12 = -Math.Cos(cpt(fai1)) * Math.Sin(cpt(k1)) - Math.Sin(cpt(fai1)) * Math.Sin(cpt(w1)) * Math.Sin(cpt(k1));
            a13 = -Math.Sin(cpt(fai1)) * Math.Cos(cpt(w1));

            b11 = Math.Cos(cpt(w1)) * Math.Sin(cpt(k1));
            b12 = Math.Cos(cpt(w1)) * Math.Cos(cpt(k1));
            b13 = -Math.Sin(cpt(w1));

            c11 = Math.Sin(cpt(fai1)) * Math.Cos(cpt(k1)) + Math.Cos(cpt(fai1)) * Math.Sin(cpt(w1)) * Math.Sin(cpt(k1));
            c12 = -Math.Sin(cpt(w1)) * Math.Sin(cpt(k1)) + Math.Cos(cpt(fai1)) * Math.Sin(cpt(w1)) * Math.Cos(cpt(k1));
            c13 = Math.Cos(cpt(fai1)) * Math.Cos(cpt(w1));

            a21 = Math.Cos(cpt(fai2)) * Math.Cos(cpt(k2)) - Math.Sin(cpt(fai2)) * Math.Sin(cpt(w2)) * Math.Sin(cpt(k2));
            a22 = -Math.Cos(cpt(fai2)) * Math.Sin(cpt(k2)) - Math.Sin(cpt(fai1)) * Math.Sin(cpt(w2)) * Math.Sin(cpt(k2));
            a23 = -Math.Sin(cpt(fai2)) * Math.Cos(cpt(w2));

            b21 = Math.Cos(cpt(w2)) * Math.Sin(cpt(k2));
            b22 = Math.Cos(cpt(w2)) * Math.Cos(cpt(k2));
            b23 = -Math.Sin(cpt(w2));

            c21 = Math.Sin(cpt(fai2)) * Math.Cos(cpt(k2)) + Math.Cos(cpt(fai2)) * Math.Sin(cpt(w2)) * Math.Sin(cpt(k2));
            c22 = -Math.Sin(cpt(w2)) * Math.Sin(cpt(k2)) + Math.Cos(cpt(fai2)) * Math.Sin(cpt(w2)) * Math.Cos(cpt(k2));
            c23 = Math.Cos(cpt(fai2)) * Math.Cos(cpt(w2));
            u1 = a11 * x1 + a12 * y1 + a13 * f1;
            v1 = b11 * x1 + b12 * y1 + b13 * f1;
            w11 = c11 * x1 + c12 * y1 + c13 * f1;

            u2 = a21 * x2 + a22 * y2 + a23 * f2;
            v2 = b21 * x2 + b22 * y2 + b23 * f2;
            w12 = c21 * x2 + c22 * y2 + c23 * f2;

            textBox19.Text = u1.ToString("0.00000");
            textBox20.Text = v1.ToString("0.00000");
            textBox21.Text = w11.ToString("0.00000");
            textBox22.Text = u2.ToString("0.00000");
            textBox23.Text = v2.ToString("0.00000");
            textBox24.Text = w12.ToString("0.00000");
            text += $"u1:{u1.ToString("0.00000")}\r\n";
            text += $"v1:{v1.ToString("0.00000")}\r\n";
            text += $"w1:{w11.ToString("0.00000")}\r\n";
            text += $"u2:{u2.ToString("0.00000")} \r\n";
            text += $"v2:{v2.ToString("0.00000")} \r\n";
            text += $"w2:{w12.ToString("0.00000")} \r\n";


        }

        double N1, N2;
        private void button3_Click(object sender, EventArgs e)
        {
            double Bu = Xs2 - Xs1;
            double Bv = Ys2 - Ys1;
            double Bw = Zs2 - Zs1;
            N1 = (Bu * w12 - Bw * u2) / (u1 * w12 - u2 * w11);
            N2 = (Bu * w11 - Bw * u1) / (u1 * w12 - u2 * w11);
            textBox25.Text = N1.ToString("0.00000");
            textBox26.Text = N2.ToString("0.00000");
            text += $"N1:{N1.ToString("0.00000")} \r\n";
            text += $"N2:{N2.ToString("0.00000")} \r\n";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double X = Xs1 + N1 * u1;
            double Y = 0.5 * ((Ys1 + N1 * v1) + Ys2 + N2 * v2);
            double Z = Zs1 + N1 * w11;
            textBox27.Text = X.ToString("0.00000");
            textBox28.Text = Y.ToString("0.00000");
            textBox29.Text = Z.ToString("0.00000");
            text += $"X:{X.ToString("0.00000")} \r\n";
            text += $"Y:{Y.ToString("0.00000")} \r\n";
            text += $"Z:{Z.ToString("0.00000")} \r\n";
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            button6_Click(sender, e);
        }

        private void 数据获取ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 计算空间辅助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }

        private void 获取投影系数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button3_Click(sender, e);
        }

        private void 计算地面摄影测量坐标ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button4_Click(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (text=="")
            {
                MessageBox.Show("save error (empty)", "save", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "*.txt|*.txt";
                sfd.Title = "保存空间前方交会数据";
                sfd.FileName = "result.txt";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName))
                    {
                        sw.WriteLine(text);
                    }
                }
            }
           

        }
    }
}