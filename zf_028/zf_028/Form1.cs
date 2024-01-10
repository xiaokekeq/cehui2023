using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zf_028
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
            timer1.Interval = 1000;
        }
        Parse parse = new Parse();
        Public_Algo public_Algo = new Public_Algo();
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "正式数据.txt";
            ofd.Filter = "*.txt|*.txt";
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                FileHelper fh = new FileHelper();
                parse = fh.OpenF(ofd.FileName);
            }
            for (int i = 0; i < parse.data.Count(); i++)
            {
                dataGridView1.Rows.Add(1);
                dataGridView1.Rows[i].Cells[0].Value = parse.data[i].StartID;
                dataGridView1.Rows[i].Cells[1].Value = public_Algo.Rad2DFM(parse.data[i].B1);
                dataGridView1.Rows[i].Cells[2].Value = public_Algo.Rad2DFM(parse.data[i].L1);
                dataGridView1.Rows[i].Cells[3].Value = parse.data[i].EndID;
                dataGridView1.Rows[i].Cells[4].Value = public_Algo.Rad2DFM(parse.data[i].B2);
                dataGridView1.Rows[i].Cells[5].Value = public_Algo.Rad2DFM(parse.data[i].L2);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.ToString();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            F_cal cal = new F_cal(parse.a,parse.f);
            for (int i = 0; i < parse.data.Count(); i++)
            {
                cal.auxi_cal(i,parse.data);
                cal.startAngle();
                parse.data[i].S=cal.landS();
                parse.data[i].A21=cal.A2();
                dataGridView2.Rows.Add(1);
                dataGridView2.Rows[i].Cells[0].Value = parse.data[i].StartID;
                dataGridView2.Rows[i].Cells[1].Value = public_Algo.Rad2DFM(parse.data[i].B1).ToString("f5");
                dataGridView2.Rows[i].Cells[2].Value = public_Algo.Rad2DFM(parse.data[i].L1).ToString("f5");
                dataGridView2.Rows[i].Cells[3].Value = parse.data[i].EndID;
                dataGridView2.Rows[i].Cells[4].Value = public_Algo.Rad2DFM(parse.data[i].B2).ToString("f5");
                dataGridView2.Rows[i].Cells[5].Value = public_Algo.Rad2DFM(parse.data[i].L2).ToString("f5");
                dataGridView2.Rows[i].Cells[6].Value = public_Algo.Rad2DFM(cal.A1).ToString("f5");
                dataGridView2.Rows[i].Cells[7].Value = public_Algo.Rad2DFM(parse.data[i].A21).ToString("f5");
                dataGridView2.Rows[i].Cells[8].Value = parse.data[i].S.ToString("f5");
            }

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "正式数据.txt";
            ofd.Filter = "*.txt|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileHelper fh = new FileHelper();
                parse = fh.OpenZ(ofd.FileName);
            }
            for (int i = 0; i < parse.data.Count(); i++)
            {
                dataGridView1.Rows.Add(1);
                dataGridView1.Rows[i].Cells[0].Value = parse.data[i].StartID;
                dataGridView1.Rows[i].Cells[1].Value = public_Algo.Rad2DFM(parse.data[i].B1);
                dataGridView1.Rows[i].Cells[2].Value = public_Algo.Rad2DFM(parse.data[i].L1);
                dataGridView1.Rows[i].Cells[3].Value = parse.data[i].EndID;
                dataGridView1.Rows[i].Cells[4].Value = public_Algo.Rad2DFM(parse.data[i].B2);
                dataGridView1.Rows[i].Cells[5].Value = public_Algo.Rad2DFM(parse.data[i].L2);
                dataGridView1.Rows[i].Cells[6].Value = public_Algo.Rad2DFM(parse.data[i].A12);
                dataGridView1.Rows[i].Cells[7].Value = public_Algo.Rad2DFM(parse.data[i].A21);
                dataGridView1.Rows[i].Cells[8].Value =(parse.data[i].S);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Z_cal cal = new Z_cal(parse.a,parse.f);
            for (int i = 0; i < parse.data.Count(); i++)
            {
                cal.Lgh(parse.data,i);
                cal.auxi(parse.data[i].A12);
                cal.Sdeta(parse.data[i].S);
                cal.B2L2A2(parse.data[i].A12, parse.data[i].L1);
                dataGridView3.Rows.Add(1);
                dataGridView3.Rows[i].Cells[0].Value = parse.data[i].StartID;
                dataGridView3.Rows[i].Cells[1].Value = public_Algo.Rad2DFM(parse.data[i].B1).ToString("f5");
                dataGridView3.Rows[i].Cells[2].Value = public_Algo.Rad2DFM(parse.data[i].L1).ToString("f5");
                dataGridView3.Rows[i].Cells[3].Value = parse.data[i].EndID;
                dataGridView3.Rows[i].Cells[4].Value = public_Algo.Rad2DFM(cal.B2).ToString("f5");
                dataGridView3.Rows[i].Cells[5].Value = public_Algo.Rad2DFM(cal.L2).ToString("f5");
                dataGridView3.Rows[i].Cells[6].Value = public_Algo.Rad2DFM(parse.data[i].A12);
                dataGridView3.Rows[i].Cells[7].Value = public_Algo.Rad2DFM(cal.A21).ToString("f5");
                dataGridView3.Rows[i].Cells[8].Value = parse.data[i].S;
            }
        }
    }
}
