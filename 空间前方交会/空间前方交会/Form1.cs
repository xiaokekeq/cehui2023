using System.Reflection.Metadata;

namespace 空间前方交会
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        string fileName = "";

        double Xs1, Xs2;
        double Ys1, Ys2;
        double Zs1, Zs2;

        double f1, f2;
        double x1, x2;
        double y1, y2;

        double fa1, fa2;
        double w1, w2;
        double k1, k2;

        double u1, u2, v1, v2, w11, w22;
        double a11, a12, a13, b11, b12, b13, c11, c12, c13, a21, a22, a23, b21, b22, b23, c21, c22, c23;
        double a1, a2, a3, b1, b2, b3, c1, c2, c3;
        const double Pi = Math.PI;
        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "*.txt|*.txt";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fileName = ofd.FileName;
                }
            }
            StreamReader sr = new StreamReader(fileName);
            Xs1 = double.Parse(sr.ReadLine());
            Ys1 = double.Parse(sr.ReadLine());
            Zs1 = double.Parse(sr.ReadLine());
            fa1 = double.Parse(sr.ReadLine());
            w1 = double.Parse(sr.ReadLine());
            k1 = double.Parse(sr.ReadLine());
            x1 = double.Parse(sr.ReadLine());
            y1 = double.Parse(sr.ReadLine());
            f1 = double.Parse(sr.ReadLine());
            Xs2 = double.Parse(sr.ReadLine());
            Ys2 = double.Parse(sr.ReadLine());
            Zs2 = double.Parse(sr.ReadLine());
            fa2 = double.Parse(sr.ReadLine());
            w2 = double.Parse(sr.ReadLine());
            k2 = double.Parse(sr.ReadLine());
            x2 = double.Parse(sr.ReadLine());
            y2 = double.Parse(sr.ReadLine());
            f2 = double.Parse(sr.ReadLine());
            textBox1.Text = Xs1.ToString("0.00000");
            textBox2.Text = Ys1.ToString("0.00000");
            textBox3.Text = Zs1.ToString("0.00000");
            textBox4.Text = fa1.ToString("0.00000");
            textBox5.Text = w1.ToString("0.00000");
            textBox6.Text = k1.ToString("0.00000");
            textBox7.Text = x1.ToString("0.00000");
            textBox8.Text = y1.ToString("0.00000");
            textBox9.Text = f1.ToString("0.00000");
            textBox10.Text = Xs2.ToString("0.00000");
            textBox11.Text = Ys2.ToString("0.00000");
            textBox12.Text = Zs2.ToString("0.00000");
            textBox13.Text = fa2.ToString("0.00000");
            textBox14.Text = w2.ToString("0.00000");
            textBox15.Text = k2.ToString("0.00000");
            textBox16.Text = x2.ToString("0.00000");
            textBox17.Text = y2.ToString("0.00000");
            textBox18.Text = f2.ToString("0.00000");


            a11 = Math.Cos(fa1 / 360 * 2 * Pi) * Math.Cos(k1 / 360 * 2 * Pi) - Math.Sin(fa1 / 360 * 2 * Pi) * Math.Sin(w1 / 360 * 2 * Pi) * Math.Sin(k1 / 360 * 2 * Pi);
            a12 = -Math.Cos(fa1 / 360 * 2 * Pi) * Math.Sin(k1 / 360 * 2 * Pi) - Math.Sin(fa1 / 360 * 2 * Pi) * Math.Sin(k1 / 360 * 2 * Pi) * Math.Sin(w1 / 360 * 2 * Pi);
            a13 = -Math.Sin(fa1 / 360 * 2 * Pi) * Math.Cos(w1 / 360 * 2 * Pi);

            b11 = Math.Cos(w1 / 360 * 2 * Pi) * Math.Sin(k1 / 360 * 2 * Pi);
            b12 = Math.Cos(w1 / 360 * 2 * Pi) * Math.Cos(k1 / 360 * 2 * Pi);
            b13 = -Math.Sin(w1 / 360 * 2 * Pi);
            
            c11 = Math.Sin(fa1 / 360 * 2 * Pi) * Math.Cos(k1 / 360 * 2 * Pi) + Math.Cos(fa1 / 360 * 2 * Pi) * Math.Sin(w1 / 360 * 2 * Pi) * Math.Sin(k1 / 360 * 2 * Pi);
            c12 = -Math.Sin(w1 / 360 * 2 * Pi) * Math.Sin(k1 / 360 * 2 * Pi) + Math.Cos(fa1 / 360 * 2 * Pi) * Math.Sin(w1 / 360 * 2 * Pi) * Math.Cos(k1 / 360 * 2 * Pi);
            c13 = Math.Cos(fa1 / 360 * 2 * Pi) * Math.Cos(w1 / 360 * 2 * Pi);

            a21 = Math.Cos(fa2 / 360 * 2 * Pi) * Math.Cos(k2 / 360 * 2 * Pi) - Math.Sin(fa2 / 360 * 2 * Pi) * Math.Sin(w2 / 360 * 2 * Pi) * Math.Sin(k2 / 360 * 2 * Pi);
            a22 = -Math.Cos(fa2 / 360 * 2 * Pi) * Math.Sin(k2 / 360 * 2 * Pi) - Math.Sin(fa2 / 360 * 2 * Pi) * Math.Sin(k2 / 360 * 2 * Pi) * Math.Sin(w2 / 360 * 2 * Pi);
            a23 = -Math.Sin(fa2 / 360 * 2 * Pi) * Math.Cos(w2 / 360 * 2 * Pi);

            b21 = Math.Cos(w2 / 360 * 2 * Pi) * Math.Sin(k2 / 360 * 2 * Pi);
            b22 = Math.Cos(w2 / 360 * 2 * Pi) * Math.Cos(k2 / 360 * 2 * Pi);
            b23 = -Math.Sin(w2 / 360 * 2 * Pi);

            c21 = Math.Sin(fa2 / 360 * 2 * Pi) * Math.Cos(k2 / 360 * 2 * Pi) + Math.Cos(fa2 / 360 * 2 * Pi) * Math.Sin(w2 / 360 * 2 * Pi) * Math.Sin(k2 / 360 * 2 * Pi);
            c22 = -Math.Sin(w2 / 360 * 2 * Pi) * Math.Sin(k2 / 360 * 2 * Pi) + Math.Cos(fa2 / 360 * 2 * Pi) * Math.Sin(w2 / 360 * 2 * Pi) * Math.Cos(k2 / 360 * 2 * Pi);
            c23 = Math.Cos(fa2 / 360 * 2 * Pi) * Math.Cos(w2 / 360 * 2 * Pi);
        }
        double X, Y, Z;
        private void button4_Click(object sender, EventArgs e)
        {
            X = Xs1 + N1 * u1;
            Y = 0.5 * ((Ys1 + N1 * v1) + Ys2 + N2 * v2);
            Z = Zs1 + N1 * w11;
            textBox21.Text = X.ToString("0.00000");
            textBox22.Text = Y.ToString("0.00000");
            textBox23.Text = Z.ToString("0.00000");
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }
        double N1, N2;
        private void button3_Click(object sender, EventArgs e)
        {
            double Bu = Xs2 - Xs1;
            double Bv = Ys2 - Ys1;
            double Bw = Zs2 - Zs1;
            N1 = (Bu * w22 - Bw * u2) / (u1 * w22 - u2 * w11);
            N2 = (Bu * w11 - Bw * u1) / (u1 * w22 - u2 * w11);
            textBox19.Text = N1.ToString("0.00000");
            textBox20.Text = N2.ToString("0.00000");
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            u1 = a11 * x1 + a12 * y1 + a13 * (f1);
            v1 = b11 * x1 + b12 * y1 + b13 * (f1);
            w11 = c11 * x1 + c12 * y1 + c13 * (f1);
            u2 = a21 * x2 + a22 * y2 + a23 * (f2);
            v2 = b21 * x2 + b22 * y2 + b23 * (f2);
            w22 = c21 * x2 + c22 * y2 + c23 * (f2);
            textBox24.Text = u1.ToString("0.00000");
            textBox25.Text = v1.ToString("0.00000");
            textBox26.Text =w11.ToString("0.00000");
            textBox27.Text = u2.ToString("0.00000");
            textBox28.Text = v2.ToString("0.00000");
            textBox29.Text = w22.ToString("0.00000");

        }
    }
}