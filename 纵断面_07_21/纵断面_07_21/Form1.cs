using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 纵断面_07_21
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
            timer1.Interval = 1000;
            toolStripStatusLabel2.Alignment = ToolStripItemAlignment.Right;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.ToString();
        }
        Parse parse = new Parse();
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "正式数据.txt";
            ofd.Filter = "*.txt|*.txt";
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                FileHelper fh = new FileHelper();
                parse=fh.Open(ofd.FileName);
            }
            int j = 0;
            for (int i = 0; i < parse.data.Count(); i++)
            {
                dataGridView1.Rows.Add(1);
                dataGridView1.Rows[i].Cells[0].Value = parse.data[i].ID;
                dataGridView1.Rows[i].Cells[1].Value =parse.data[i].X.ToString("f3");
                dataGridView1.Rows[i].Cells[2].Value =parse.data[i].Y.ToString("f3");
                dataGridView1.Rows[i].Cells[3].Value =parse.data[i].H.ToString("f3");
                if (parse.data[i].ID.Contains("A")||parse.data[i].ID.Contains("B"))
                {
                    parse.AB[j].ID = parse.data[i].ID;
                    parse.AB[j].X =Convert.ToDouble( parse.data[i].X);
                    parse.AB[j].Y = Convert.ToDouble(parse.data[i].Y);
                    parse.AB[j].H = Convert.ToDouble(parse.data[i].H);
                    j++;
                }
            }



        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Algo algo = new Algo();
            //纵断面
            double af = algo.azimuth(parse.AB[0], parse.AB[1]);
            double D=algo.D(parse.AB[0],parse.AB[1]);
            int L = 0;
            algo.nccoordinateZ(parse.data, parse.AB[0], ref L,D);
            double Zarea = 0;
            for (int i = 1; i < algo.Z.Count(); i++)
            {
                algo.Z[i].H=algo.ncH(parse.data,algo.Z[i]);
            }
            algo.Z.Add(parse.AB[1]);
            for (int i = 0; i < algo.Z.Count()-1; i++)
            {
                Zarea+=algo.area(algo.Z[i],algo.Z[i+1]);
            }
            for (int i = 0; i < algo.Z.Count(); i++)
            {
                dataGridView2.Rows.Add(1);
                dataGridView2.Rows[i].Cells[0].Value = algo.Z[i].ID;
                dataGridView2.Rows[i].Cells[1].Value = Convert.ToDouble(algo.Z[i].X).ToString("f3");
                dataGridView2.Rows[i].Cells[2].Value = Convert.ToDouble(algo.Z[i].Y).ToString("f3");
                dataGridView2.Rows[i].Cells[3].Value = Convert.ToDouble(algo.Z[i].H).ToString("f3");
                dataGridView2.Rows[i].Cells[4].Value = Convert.ToDouble(algo.Z[i].D).ToString("f3");
            }
            dataGridView2.Rows[0].Cells[5].Value = Zarea.ToString("f3");
            tabControl1.SelectedIndex = 1;
            //横断面
            DataEntity M;
            M=algo.Mcenter(parse.AB[0],parse.AB[1],1);
            M.H=algo.ncH(parse.data,M);
            int  count = algo.Z.Count();
            double AMarea = 0;
            double MBarea = 0;
            AMarea = algo.area(algo.Z[0], M);
            MBarea = algo.area( M, algo.Z[algo.Z.Count() - 1]);

          
            for (int i = algo.Z.Count()/2; i < algo.Z.Count(); i++)
            {
                MBarea += algo.area(algo.Z[i], algo.Z[i + 1]);
            }
            algo.nccoordinateH(M);
            for (int i = 0; i < algo.H.Count(); i++)
            {
                algo.H[i].H=algo.ncH(parse.data, algo.H[i]);
            }
            double Harea = 0;
            for (int i = 0; i < algo.H.Count()-1; i++)
            {
                Harea=algo.area(algo.H[i], algo.H[i + 1]);
            }
            dataGridView2.Rows.Add(1);
            for (int i = algo.Z.Count(); i < algo.H.Count()+algo.Z.Count(); i++)
            {
                dataGridView2.Rows.Add(1);
                dataGridView2.Rows[i].Cells[0].Value = algo.H[i- algo.Z.Count()].ID;
                dataGridView2.Rows[i].Cells[1].Value = Convert.ToDouble(algo.H[i- algo.Z.Count()].X).ToString("f3");
                dataGridView2.Rows[i].Cells[2].Value = Convert.ToDouble(algo.H[i- algo.Z.Count()].Y).ToString("f3");
                dataGridView2.Rows[i].Cells[3].Value = Convert.ToDouble(algo.H[i- algo.Z.Count()].H).ToString("f3");
            }
            dataGridView2.Rows[21].Cells[5].Value = Harea.ToString("f3");
        }
    }
}
