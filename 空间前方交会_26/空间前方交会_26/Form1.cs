using System;
using System.IO;
using System.Windows.Forms;

namespace 空间前方交会_26
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.ToShortDateString();
        }
        public double dms2rad(double dms)
        {
            return dms / 180 * Math.PI;
        }
        double x1, y1, x2, y2, f;
        double o1, o2, p1, p2, q1, q2;

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            u1 = a11 * x1 + a12 * y1 + a13 * f;
            u2 = a21 * x2 + a22 * y2 + a23 * f;
            v1 = b11 * x1 + b12 * y1 + b13 * f;
            v2 = b21 * x2 + b22 * y2 + b23 * f;
            w1 = c11 * x1 + c12 * y1 + c13 * f;
            w2 = c21 * x2 + c22 * y2 + c23 * f;


            Bu = Xs2 - Xs1;
            Bv = Ys2 - Ys1;
            Bw = Zs2 - Zs1;

            N1 = (Bu * w2 - Bw * u2) / (u1 * w2 - u2 * w1);
            N2 = (Bu * w1 - Bw * u1) / (u1 * w2 - u2 * w1);

            X = Xs1 + N1 * u1;
            Y = 0.5 * (Ys1 + N1 * v1 + Ys2 + N2 * v2);
            Z = Zs1 + N1 * w1;
        }

        double Xs1, Ys1, Zs1, Xs2, Ys2, Zs2;
        string ret = "";
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.txt|*.txt";
            sfd.FileName = "result.txt";
            ret += string.Format("{0,-10}", dataGridView2.Columns[0].HeaderCell.Value);
            ret += string.Format("{0,-10}", dataGridView2.Columns[1].HeaderCell.Value);
            ret += string.Format("{0,-10}", dataGridView2.Columns[2].HeaderCell.Value);
            ret += string.Format("{0,-10}", dataGridView2.Columns[3].HeaderCell.Value);
            ret += string.Format("{0,-10}", dataGridView2.Columns[4].HeaderCell.Value);
            ret += string.Format("{0,-10}", dataGridView2.Columns[5].HeaderCell.Value);
            ret += string.Format("{0,-10}", dataGridView2.Columns[6].HeaderCell.Value);
            ret += "\r\n";

            for (int i = 0; i < 2; i++)
            {

                ret += string.Format("{0,-15}", dataGridView2.Rows[i].Cells[0].Value) ;
                ret += string.Format("{0,-15}", dataGridView2.Rows[i].Cells[1].Value) ;
                ret += string.Format("{0,-15}", dataGridView2.Rows[i].Cells[2].Value) ;
                ret += string.Format("{0,-15}", dataGridView2.Rows[i].Cells[3].Value) ;
                ret += string.Format("{0,-15}", dataGridView2.Rows[i].Cells[4].Value) ;
                ret += string.Format("{0,-15}", dataGridView2.Rows[i].Cells[5].Value) ;
                ret += string.Format("{0,-15}", dataGridView2.Rows[i].Cells[6].Value) ;
                ret += "\r\n";
            }
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName))
                {
                    sw.WriteLine(ret);
                }
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            dataGridView2.Rows.Add(2);
            dataGridView2.Rows[0].Cells[0].Value = u1.ToString("f5"); ;
            dataGridView2.Rows[0].Cells[1].Value = v1.ToString("f5"); ;
            dataGridView2.Rows[0].Cells[2].Value = w1.ToString("f5"); ;
            dataGridView2.Rows[0].Cells[3].Value = N1.ToString("f5"); ;
            dataGridView2.Rows[0].Cells[4].Value = X.ToString("f5"); ;
            dataGridView2.Rows[0].Cells[5].Value = Y.ToString("f5"); ;
            dataGridView2.Rows[0].Cells[6].Value = Z.ToString("f5"); ;

            dataGridView2.Rows[1].Cells[0].Value = u2.ToString("f5"); ;
            dataGridView2.Rows[1].Cells[1].Value = v2.ToString("f5"); ;
            dataGridView2.Rows[1].Cells[2].Value = w2.ToString("f5"); ;
            dataGridView2.Rows[1].Cells[3].Value = N2.ToString("f5"); ;
            dataGridView2.Rows[1].Cells[4].Value = X.ToString("f5"); ;
            dataGridView2.Rows[1].Cells[5].Value = Y.ToString("f5"); ;
            dataGridView2.Rows[1].Cells[6].Value = Z.ToString("f5"); ;


        }

        double a11, a12, a13;
        double b11, b12, b13;
        double c11, c12, c13;
        double a21, a22, a23;
        double b21, b22, b23;
        double c21, c22, c23;
        double Bu, Bv, Bw;
        double N1, N2;
        double X, Y, Z;
        double u1, v1, w1;
        double u2, v2, w2;
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "正式数据.txt";
            ofd.Filter = "*.txt|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(ofd.FileName))
                {
                    Xs1 = double.Parse(sr.ReadLine());
                    Ys1 = double.Parse(sr.ReadLine());
                    Zs1 = double.Parse(sr.ReadLine());
                    o1 = dms2rad(double.Parse(sr.ReadLine()));
                    p1 = dms2rad(double.Parse(sr.ReadLine()));
                    q1 = dms2rad(double.Parse(sr.ReadLine()));
                    x1 = double.Parse(sr.ReadLine());
                    y1 = double.Parse(sr.ReadLine());
                    f = double.Parse(sr.ReadLine());
                    Xs2 = double.Parse(sr.ReadLine());
                    Ys2 = double.Parse(sr.ReadLine());
                    Zs2 = double.Parse(sr.ReadLine());
                    o2 = dms2rad(double.Parse(sr.ReadLine()));
                    p2 = dms2rad(double.Parse(sr.ReadLine()));
                    q2 = dms2rad(double.Parse(sr.ReadLine()));
                    x2 = double.Parse(sr.ReadLine());
                    y2 = double.Parse(sr.ReadLine());
                    f = double.Parse(sr.ReadLine());
                    dataGridView1.Rows.Add(2);
                    dataGridView1.Rows[0].Cells[0].Value = Xs1.ToString("f5");
                    dataGridView1.Rows[0].Cells[1].Value = Ys1.ToString("f5");
                    dataGridView1.Rows[0].Cells[2].Value = Zs1.ToString("f5");
                    dataGridView1.Rows[0].Cells[3].Value = o1.ToString("f5");
                    dataGridView1.Rows[0].Cells[4].Value = p1.ToString("f5");
                    dataGridView1.Rows[0].Cells[5].Value = q1.ToString("f5");
                    dataGridView1.Rows[0].Cells[6].Value = x1.ToString("f5");
                    dataGridView1.Rows[0].Cells[7].Value = y1.ToString("f5");
                    dataGridView1.Rows[0].Cells[8].Value = f.ToString("f5");

                    dataGridView1.Rows[1].Cells[0].Value = Xs2.ToString("f5");
                    dataGridView1.Rows[1].Cells[1].Value = Ys2.ToString("f5");
                    dataGridView1.Rows[1].Cells[2].Value = Zs2.ToString("f5");
                    dataGridView1.Rows[1].Cells[3].Value = o2.ToString("f5");
                    dataGridView1.Rows[1].Cells[4].Value = p2.ToString("f5");
                    dataGridView1.Rows[1].Cells[5].Value = q2.ToString("f5");
                    dataGridView1.Rows[1].Cells[6].Value = x2.ToString("f5");
                    dataGridView1.Rows[1].Cells[7].Value = y2.ToString("f5");
                    dataGridView1.Rows[1].Cells[8].Value = f.ToString("f5");
                }
                a11 = Math.Cos(o1) * Math.Cos(q1) - Math.Sin(o1) * Math.Sin(p1) * Math.Sin(q1);
                a12 = -Math.Cos(o1) * Math.Sin(q1) - Math.Sin(o1) * Math.Sin(p1) * Math.Sin(q1);
                a13 = -Math.Sin(o1) * Math.Cos(p1);
                b11 = Math.Cos(p1) * Math.Sin(q1);
                b12 = Math.Cos(p1) * Math.Cos(q1);
                b13 = -Math.Sin(p1);
                c11 = Math.Sin(o1) * Math.Cos(q1) + Math.Cos(o1) * Math.Sin(p1) * Math.Sin(q1);
                c12 = -Math.Sin(p1) * Math.Sin(q1) + Math.Cos(o1) * Math.Sin(p1) * Math.Cos(q1);
                c13 = Math.Cos(o1) * Math.Cos(p1);

                a21 = Math.Cos(o2) * Math.Cos(q2) - Math.Sin(o2) * Math.Sin(p2) * Math.Sin(q2);
                a22 = -Math.Cos(o2) * Math.Sin(q2) - Math.Sin(o2) * Math.Sin(p2) * Math.Sin(q2);
                a23 = -Math.Sin(o2) * Math.Cos(p2);
                b21 = Math.Cos(p2) * Math.Sin(q2);
                b22 = Math.Cos(p2) * Math.Cos(q2);
                b23 = -Math.Sin(p2);
                c21 = Math.Sin(o2) * Math.Cos(q2) + Math.Cos(o2) * Math.Sin(p2) * Math.Sin(q2);
                c22 = -Math.Sin(p2) * Math.Sin(q2) + Math.Cos(o2) * Math.Sin(p2) * Math.Cos(q2);
                c23 = Math.Cos(o2) * Math.Cos(p2);
            }

        }
    }
}
