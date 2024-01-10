using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 栅格数据的领域计算_0721
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.ToString();
        }
        Parse parse1 = new Parse();
        Parse parse2 = new Parse();
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "N矩阵.txt";
            ofd.Filter = "*.txt|*.txt";
            if (ofd.ShowDialog()==DialogResult.OK)
            {
              
                FileHelper fh = new FileHelper();
                parse1=fh.Open(ofd.FileName);
            }
            for (int i = 0; i < parse1.data.Count(); i++)
            {
                for (int j = 0; j < parse1.data[0].X.Length; j++)
                {
                    richTextBox2.Text += parse1.data[i].X[0, j];
                    richTextBox2.Text += "\t";
                }
                richTextBox2.Text += "\r\n";
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
             string ret = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "M矩阵.txt";
            ofd.Filter = "*.txt|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
               
                FileHelper fh = new FileHelper();
                parse2=fh.Open(ofd.FileName);
            }
            for (int i = 0; i < parse2.data.Count(); i++)
            {
                for (int j = 0; j < parse2.data[0].X.Length; j++)
                {
                    ret += parse2.data[i].X[0, j];
                    ret += "\t";
                }
                ret += "\r\n";
            }
            richTextBox2.Text += ret;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Algo algo = new Algo(parse1, parse2);
            double[,] Matrix=algo.MatrixVIJ();
            for (int i = 0; i < Math.Sqrt(Matrix.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(Matrix.Length); j++)
                {
                    richTextBox1.Text += Matrix[i,j].ToString("f2");
                    richTextBox1.Text += "\t";
                }
                richTextBox1.Text += "\r\n";
            }
            tabControl1.SelectedIndex = 1;
        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Algo algo = new Algo(parse1, parse2);
            double[,] Matrix2 = algo.MatrixVIJ2();
            for (int i = 0; i < Math.Sqrt(Matrix2.Length); i++)
            {
                dataGridView1.Rows.Add(1);
                for (int j = 0; j < Math.Sqrt(Matrix2.Length); j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = Matrix2[i, j].ToString("f2");
                }
            }
            tabControl1.SelectedIndex = 2;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

        }

        private void 保存数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
