using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 栅格矩阵7_25
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
        Parse parse1 = new Parse();
        Parse parse2= new Parse();
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "正式数据.txt";
            ofd.Filter = "*.txt|*.txt";
         
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                if (!ofd.FileName.Contains("N"))
                {
                    MessageBox.Show("只能打开N文件", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                FileHelper fh = new FileHelper();
                parse1=fh.Open(ofd.FileName);
                if (richTextBox1.GetLineFromCharIndex(richTextBox1.TextLength) + 1 > (parse1.data.Count() + parse2.data.Count()))
                {
                    richTextBox1.Clear();
                }
                for (int i = 0; i < parse1.data.Count(); i++)
                {
                    for (int j = 0; j < parse1.data[i].X.Length; j++)
                    {
                        richTextBox1.Text += $"{parse1.data[i].X[j, 0].ToString("f2")}\t";
                        
                    }
                    richTextBox1.Text += "\r\n";
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "正式数据.txt";
            ofd.Filter = "*.txt|*.txt";
           
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (!ofd.FileName.Contains("M"))
                {
                    MessageBox.Show("只能打开M文件", "error", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                }
                FileHelper fh = new FileHelper();
                parse2 = fh.Open(ofd.FileName);
                if (richTextBox1.GetLineFromCharIndex(richTextBox1.TextLength) + 1 > (parse1.data.Count() + parse2.data.Count()))
                {
                    richTextBox1.Clear();
                }
                for (int i = 0; i < parse2.data.Count(); i++)
                {
                    for (int j = 0; j < parse2.data[i].X.Length; j++)
                    {
                        richTextBox1.Text += $"{parse2.data[i].X[j, 0].ToString("f2")}\t";
                    }
                    richTextBox1.Text += "\r\n";
                }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
            tabControl1.SelectedIndex = 1;
            Algo algo = new Algo(parse1,parse2);
            double[,] matrix = algo.VIJ();
            for (int i = 0; i < parse1.data.Count(); i++)
            {
                dataGridView1.Rows.Add(1);
                for (int j = 0; j < parse1.data[0].X.Length; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = matrix[i, j];
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.ToString();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
            tabControl1.SelectedIndex = 1;
            Algo algo = new Algo(parse1,parse2);
            double[,] Matrix = algo.VIJ_2();
            for (int i = 0; i < parse1.data.Count(); i++)
            {
                dataGridView1.Rows.Add(1);
                for (int j = 0; j < parse1.data[0].X.Length; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = Matrix[i, j].ToString("f2");
                }
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
            tabControl1.SelectedIndex = 0;
        }

        private void 打开N文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton1_Click(sender, e);
        }

        private void 打开M文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton2_Click(sender, e);
        }

        private void 算法1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton3_Click(sender, e);
        }

        private void 算法2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton4_Click(sender, e);
        }

        private void 保存文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
