using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 大地正反算
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
        FileHelper fh;
        Parse parse = new Parse();
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.txt|*.txt";
            ofd.FileName = "正算数据.txt";
            ofd.InitialDirectory = Application.StartupPath;
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                if (!ofd.FileName.Contains("正算数据"))
                {
                    MessageBox.Show("error data","open",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                FileHelper fh = new FileHelper();
                parse=fh.Open1(ofd.FileName);
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.ToString();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
           
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.txt|*.txt";
            ofd.FileName = "反算数据.txt";
            ofd.InitialDirectory = Application.StartupPath;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (!ofd.FileName.Contains("反算数据"))
                {
                    MessageBox.Show("error data", "open", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                FileHelper fh = new FileHelper();
                parse = fh.Open(ofd.FileName);
                toolStripButton8.Text = parse.a.ToString("f3");
                toolStripButton10.Text = parse.f.ToString("f3");
            }
        }
        string retreverse = "";
        string retz = "";
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.txt|*.txt";
            sfd.FileName = "result.txt";
            sfd.InitialDirectory = Application.StartupPath;

            if (sfd.ShowDialog()==DialogResult.OK)
            {
                if (retreverse=="")
                {
                    MessageBox.Show("error save empty ", "save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                FileHelper fh = new FileHelper();
                fh.Save(sfd.FileName,retreverse);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            刷新ToolStripMenuItem_Click(sender, e);
            if (parse.reverseData.Count()==0)
            {
                MessageBox.Show("error data empty","calculation",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            Algo_reverse algo_Reverse = new Algo_reverse(parse.a,parse.f);
            double[] S=new double[parse.reverseData.Count()];
            for (int i = 0; i < parse.reverseData.Count(); i++)
            {
                algo_Reverse.auxiliary_cal(parse.reverseData,i);
                algo_Reverse.StartAzimuth();
                S[i]=algo_Reverse.landS();
                dataGridView1.Rows.Add(1);
                dataGridView1.Rows[i].Cells[0].Value = parse.reverseData[i].Sp;
                dataGridView1.Rows[i].Cells[1].Value = algo_Reverse.public_algo.RAD2DMS(parse.reverseData[i].LonS);
                dataGridView1.Rows[i].Cells[2].Value = algo_Reverse.public_algo.RAD2DMS(parse.reverseData[i].LatS);
                dataGridView1.Rows[i].Cells[3].Value = parse.reverseData[i].Ep;
                dataGridView1.Rows[i].Cells[4].Value = algo_Reverse.public_algo.RAD2DMS(parse.reverseData[i].LonE);
                dataGridView1.Rows[i].Cells[5].Value = algo_Reverse.public_algo.RAD2DMS(parse.reverseData[i].LatE);
                dataGridView1.Rows[i].Cells[6].Value = algo_Reverse.public_algo.RAD2DMS(algo_Reverse.A1).ToString("f5");
                dataGridView1.Rows[i].Cells[7].Value = algo_Reverse.public_algo.RAD2DMS(algo_Reverse.A2).ToString("f5");
                dataGridView1.Rows[i].Cells[8].Value = S[i].ToString("f5");
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            刷新ToolStripMenuItem_Click(sender, e);
            if (parse.zcalData.Count() == 0)
            {
                MessageBox.Show("error data empty", "calculation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            public_algo public_Algo = new public_algo();
            Algo algo = new Algo(parse.a, parse.f);
            for (int i = 0; i < parse.zcalData.Count(); i++)
            {
                algo.StartLat(parse.zcalData,i);
                algo.auxi_cal(parse.zcalData[i].A1, parse.zcalData[i].LatS,parse.zcalData[i].S);
                dataGridView1.Rows.Add(1);
                dataGridView1.Rows[i].Cells[0].Value = parse.zcalData[i].Sp;
                dataGridView1.Rows[i].Cells[1].Value = public_Algo.RAD2DMS(parse.zcalData[i].LonS);
                dataGridView1.Rows[i].Cells[2].Value = public_Algo.RAD2DMS(parse.zcalData[i].LatS);
                dataGridView1.Rows[i].Cells[3].Value = parse.zcalData[i].Ep;
                dataGridView1.Rows[i].Cells[4].Value = public_Algo.RAD2DMS(algo.B2).ToString("f5");
                dataGridView1.Rows[i].Cells[5].Value = public_Algo.RAD2DMS(algo.L2).ToString("f5");
                dataGridView1.Rows[i].Cells[6].Value = public_Algo.RAD2DMS(parse.zcalData[i].A1);
                dataGridView1.Rows[i].Cells[7].Value = public_Algo.RAD2DMS(algo.A2).ToString("f5");
                dataGridView1.Rows[i].Cells[8].Value = parse.zcalData[i].S;

            }
      
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
            
        }
    }
}
