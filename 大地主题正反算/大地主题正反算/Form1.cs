using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 大地主题正反算
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
            timer1.Interval = 1000;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        Parse parse1 = new Parse();//正算
        Parse parse2 = new Parse();//反算
        public void refresh()
        {
            this.Controls.Clear();
            InitializeComponent();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            refresh();
            public_algo public_algo = new public_algo();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.txt|*.txt";
            ofd.FileName = "正算数据.txt";
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                FileHelper fh = new FileHelper();
                parse1=fh.OpenZ(ofd.FileName);
            }
            toolStripLabel2.Text = (parse1.a).ToString("f3");
            toolStripLabel4.Text = parse1.f.ToString("f3");
            for (int i = 0; i < parse1.dataZ.Count(); i++)
            {
                dataGridView1.Rows.Add(1);
                dataGridView1.Rows[i].Cells[0].Value = parse1.dataZ[i].ID1;
                dataGridView1.Rows[i].Cells[1].Value = public_algo.radtDMS(parse1.dataZ[i].B1).ToString();
                dataGridView1.Rows[i].Cells[2].Value = public_algo.radtDMS(parse1.dataZ[i].L1).ToString();
                dataGridView1.Rows[i].Cells[3].Value = parse1.dataZ[i].ID2;
                dataGridView1.Rows[i].Cells[4].Value = public_algo.radtDMS(parse1.dataZ[i].B2).ToString();
                dataGridView1.Rows[i].Cells[5].Value = public_algo.radtDMS(parse1.dataZ[i].L2).ToString();
                dataGridView1.Rows[i].Cells[6].Value = public_algo.radtDMS(parse1.dataZ[i].A12).ToString();
                dataGridView1.Rows[i].Cells[7].Value = public_algo.radtDMS(parse1.dataZ[i].A21).ToString();
                dataGridView1.Rows[i].Cells[8].Value =(parse1.dataZ[i].S).ToString();

            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            refresh();
            public_algo public_algo = new public_algo();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.txt|*.txt";
            ofd.FileName = "反算数据.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileHelper fh = new FileHelper();
                parse2 = fh.OpenF(ofd.FileName);
            }
            toolStripLabel2.Text = (parse2.a).ToString("f3");
            toolStripLabel4.Text = parse2.f.ToString("f3");
            for (int i = 0; i < parse2.dataF.Count(); i++)
            {
                dataGridView1.Rows.Add(1);
                dataGridView1.Rows[i].Cells[0].Value = parse2.dataF[i].ID1;
                dataGridView1.Rows[i].Cells[1].Value = public_algo.radtDMS(parse2.dataF[i].B1).ToString();
                dataGridView1.Rows[i].Cells[2].Value = public_algo.radtDMS(parse2.dataF[i].L1).ToString();
                dataGridView1.Rows[i].Cells[3].Value = parse2.dataF[i].ID2;
                dataGridView1.Rows[i].Cells[4].Value = public_algo.radtDMS(parse2.dataF[i].B2).ToString();
                dataGridView1.Rows[i].Cells[5].Value = public_algo.radtDMS(parse2.dataF[i].L2).ToString();
   
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex=1;
            Algo algo = new Algo(parse1.a,parse1.f);
            for (int i = 0; i < parse1.dataZ.Count(); i++)
            {
                algo.StartLat(parse1.dataZ, i);
                algo.auxi_cal(parse1.dataZ[i].A12);
                algo.S(parse1.dataZ[i].S);
                algo.L_A(parse1.dataZ[i].A12,parse1.dataZ[i].L1,ref parse1.dataZ[i].B2, ref parse1.dataZ[i].A21, ref  parse1.dataZ[i].L2);

                dataGridView2.Rows.Add(1);
                dataGridView2.Rows[i].Cells[0].Value = parse1.dataZ[i].ID1;
                dataGridView2.Rows[i].Cells[1].Value = algo.public_Algo.radtDMS(parse1.dataZ[i].B1).ToString();
                dataGridView2.Rows[i].Cells[2].Value = algo.public_Algo.radtDMS(parse1.dataZ[i].L1).ToString();
                dataGridView2.Rows[i].Cells[3].Value = parse1.dataZ[i].ID2;
                dataGridView2.Rows[i].Cells[4].Value = algo.public_Algo.radtDMS(parse1.dataZ[i].B2).ToString("f5");
                dataGridView2.Rows[i].Cells[5].Value = algo.public_Algo.radtDMS(parse1.dataZ[i].L2).ToString("f5");
                dataGridView2.Rows[i].Cells[6].Value = algo.public_Algo.radtDMS(parse1.dataZ[i].A12).ToString();
                dataGridView2.Rows[i].Cells[7].Value = algo.public_Algo.radtDMS(parse1.dataZ[i].A21).ToString("f5");
                dataGridView2.Rows[i].Cells[8].Value = (parse1.dataZ[i].S).ToString();
            }
            

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            double S = 0;
            double A21 = 0;
            Algo_reverse algo_reverse = new Algo_reverse(parse2.f,parse2.a);
            for (int i = 0; i < parse2.dataF.Count(); i++)
            {
                algo_reverse.auxi(parse2.dataF, i);
                double A12 = algo_reverse.StartA1();
                 S=algo_reverse.S();
                A21 = algo_reverse.A2(A12);

                dataGridView2.Rows.Add(1);
                dataGridView2.Rows[i].Cells[0].Value = parse2.dataF[i].ID1;
                dataGridView2.Rows[i].Cells[1].Value = algo_reverse.public_algo.radtDMS(parse2.dataF[i].B1).ToString();
                dataGridView2.Rows[i].Cells[2].Value = algo_reverse.public_algo.radtDMS(parse2.dataF[i].L1).ToString();
                dataGridView2.Rows[i].Cells[3].Value = parse2.dataF[i].ID2;
                dataGridView2.Rows[i].Cells[4].Value = algo_reverse.public_algo.radtDMS(parse2.dataF[i].B2).ToString();
                dataGridView2.Rows[i].Cells[5].Value = algo_reverse.public_algo.radtDMS(parse2.dataF[i].L2).ToString();
                dataGridView2.Rows[i].Cells[6].Value = algo_reverse.public_algo.radtDMS(A12).ToString("f5");
                dataGridView2.Rows[i].Cells[7].Value = algo_reverse.public_algo.radtDMS(A21).ToString("f5");
                dataGridView2.Rows[i].Cells[8].Value = (S).ToString("f5");
            }
           
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refresh();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            刷新ToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.txt|*.txt ";
            sfd.FileName = "result.txt";
            if (dataGridView2.Rows[0].Cells[0].Value ==null)
            {
                MessageBox.Show("暂无数据","save",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            string text = "";
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView2.Rows[0].Cells.Count; j++)
                {
                    text += $"{dataGridView2.Rows[i].Cells[j].Value}\t";
                }
                text += "\r\n";
            }
            if (sfd.ShowDialog()==DialogResult.OK)
            {
                FileHelper fh = new FileHelper();
                fh.Save(sfd.FileName,text);
            }
        }
    }
}
