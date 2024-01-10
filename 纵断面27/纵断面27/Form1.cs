using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 纵断面27
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Parse parse = new Parse();
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "正式数据.txt";
            ofd.Filter = "*.txt|*.txt";
            ofd.InitialDirectory = Application.StartupPath;
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                FileHelper fh = new FileHelper();
                parse = fh.Open(ofd.FileName);
            }
            int j = 0;
            for (int i = 0; i < parse.data.Count(); i++)
            {
                dataGridView1.Rows.Add(1);
                dataGridView1.Rows[i].Cells[0].Value = parse.data[i].ID;
                dataGridView1.Rows[i].Cells[1].Value = parse.data[i].X;
                dataGridView1.Rows[i].Cells[2].Value = parse.data[i].Y;
                dataGridView1.Rows[i].Cells[3].Value = parse.data[i].H;
                if (parse.data[i].ID.Contains("K"))
                {
                    parse.K[j].X= parse.data[i].X;
                    parse.K[j].Y= parse.data[i].Y;
                    parse.K[j].H= parse.data[i].H;
                    j++;
                }
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.ToString();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Algo algo = new Algo();
            double dp = 10;
            for (int i = 0; i < parse.K.Count()-1; i++)
            {
                algo.Pcoor(parse.K[i],parse.K[i+1],parse.K[0],ref dp);
                if (i==parse.K.Count()-2)
                {
                    parse.K[i + 1].L = algo.D_SUM;
                    algo.Pnc.Add(parse.K[i+1]);       
                }
            }
            for (int i = 0; i < algo.Pnc.Count(); i++)
            {
                if (algo.Pnc[i].H!=0)
                {
                    continue;
                }
                algo.ncH(parse.data, algo.Pnc[i]);
            }
            for (int i = 0; i < algo.Pnc.Count(); i++)
            {
                dataGridView2.Rows.Add(1);
                dataGridView2.Rows[i].Cells[0].Value = algo.Pnc[i].ID;
                dataGridView2.Rows[i].Cells[1].Value = algo.Pnc[i].X.ToString("f3");
                dataGridView2.Rows[i].Cells[2].Value = algo.Pnc[i].Y.ToString("f3");
                dataGridView2.Rows[i].Cells[3].Value = algo.Pnc[i].H.ToString("f3");
                dataGridView2.Rows[i].Cells[4].Value = algo.Pnc[i].L.ToString("f3");
            }
            double S=0;
            dataGridView2.Rows[0].Cells[5].Value = algo.D_SUM.ToString("f3");
            for (int i = 0; i < algo.Pnc.Count()-1; i++)
            {
                S+= algo.area(parse.Hv,(algo.Pnc[i+1].L - algo.Pnc[i].L),algo.Pnc[i],algo.Pnc[i+1]);
            }
            dataGridView2.Rows[1].Cells[5].Value = S.ToString("f3");
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Algo algo = new Algo();
            algo.M(parse.K);
            for (int i = 0; i < parse.K.Count() - 1; i++)
            {
                algo.Mcoor(parse.K[i], parse.K[i + 1],i);
            }
            for (int i = 0; i < algo.Mnc.Count(); i++)
            {
                algo.ncH(parse.data, algo.Mnc[i]);
            }
            for (int i = 0; i < algo.Mnc.Count(); i++)
            {
                dataGridView3.Rows.Add(1);
                dataGridView3.Rows[i].Cells[0].Value = algo.Mnc[i].ID;
                dataGridView3.Rows[i].Cells[1].Value = algo.Mnc[i].X.ToString("f3");
                dataGridView3.Rows[i].Cells[2].Value = algo.Mnc[i].Y.ToString("f3");
                dataGridView3.Rows[i].Cells[3].Value = algo.Mnc[i].H.ToString("f3");
                dataGridView3.Rows[i].Cells[4].Value = algo.Mnc[i].L.ToString("f3");
            }
            double S = 0;
            for (int i = 0; i < algo.Mnc.Count()/2-1; i++)
            {
                S += algo.area(parse.Hv,5,algo.Mnc[i],algo.Mnc[i+1]);
            }
            dataGridView3.Rows[0].Cells[5].Value = S;
            S = 0;
            for (int i = algo.Mnc.Count()/2-1; i < algo.Mnc.Count()-1; i++)
            {
                S += algo.area(parse.Hv, Math.Abs(algo.Mnc[i].L - algo.Mnc[i + 1].L), algo.Mnc[i], algo.Mnc[i + 1]);
            }
            dataGridView3.Rows[1].Cells[5].Value = S;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }
    }
}
