using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 激光点云
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
        Parse parse1 = new Parse();
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "正式数据.txt";
            ofd.Filter = "(文本文件)*.txt|*.txt";
            ofd.InitialDirectory = Application.StartupPath;
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                FileHelper fh = new FileHelper();
                parse=fh.Open(ofd.FileName);
                parse1= fh.Open(ofd.FileName);
            }
            for (int i = 0; i < parse.data.Count(); i++)
            {
                dataGridView1.Rows.Add(1);
                dataGridView1.Rows[i].Cells[0].Value = parse.data[i].ID;
                dataGridView1.Rows[i].Cells[1].Value = parse.data[i].X;
                dataGridView1.Rows[i].Cells[2].Value = parse.data[i].Y;
                dataGridView1.Rows[i].Cells[3].Value = parse.data[i].Z;
            }
        }
        Algo algo = new Algo();
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            
            double Xmax = 0;
            double Xmin = 0;
            double Ymax = 0;
            double Ymin = 0;
            double Zmax = 0;
            double Zmin = 0;
            algo.Mx(parse.data,ref Xmax,ref Xmin);
            algo.MY(parse.data, ref Ymax, ref Ymin);
            algo.MZ(parse.data, ref Zmax, ref Zmin);

            algo.sghua(parse1.data);
            algo.geo();
            algo.areasplit(parse1.data);
            algo.in_out(parse1.data);
            dataGridView2.Rows.Add(1);
            dataGridView2.Rows[0].Cells[0].Value = "P0";
            dataGridView2.Rows[0].Cells[1].Value = algo.x.ToString("f3") ;
            dataGridView2.Rows[0].Cells[2].Value = algo.y.ToString("f3");
            dataGridView2.Rows[0].Cells[3].Value = algo.z.ToString("f3");
            dataGridView2.Rows[0].Cells[4].Value ="J1";

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
            algo = new Algo();
            parse = new Parse();
            parse1 = new Parse();
        }

        private void 打开文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton1_Click(sender, e);
        }

        private void 保存文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton5_Click(sender, e);
        }
        string ret = "";
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "result.txt";
            sfd.Filter = "*.txt|*.txt";
            for (int i = 0; i < dataGridView2.Columns.Count; i++)
            {
                ret += string.Format("{0,-10}",dataGridView2.Columns[i].HeaderText);
            }
            ret += "\r\n";
            ret += string.Format("{0,-10}", dataGridView2.Rows[0].Cells[0].Value);
            ret += string.Format("{0,-20}", dataGridView2.Rows[0].Cells[1].Value);
            ret += string.Format("{0,-20}", dataGridView2.Rows[0].Cells[2].Value);
            ret += string.Format("{0,-20}", dataGridView2.Rows[0].Cells[3].Value);
            ret += string.Format("{0,-20}", "J1");
            if (sfd.ShowDialog()==DialogResult.OK)
            {
                FileHelper fh = new FileHelper();
                fh.Save(sfd.FileName,ret);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }
    }
}
