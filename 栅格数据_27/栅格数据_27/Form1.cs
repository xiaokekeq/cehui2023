using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 栅格数据_27
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
        Parse parse1 = new Parse();
        Parse parse2 = new Parse();
        public void refresh()
        {
            this.Controls.Clear();
            InitializeComponent();
           parse1 = new Parse();
           parse2 = new Parse();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
          
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "正式数据.txt";
            ofd.Filter = "*.txt|*.txt";
            ofd.InitialDirectory = Application.StartupPath;
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                if (ofd.FileName.Contains("M"))
                {
                    MessageBox.Show("请打开N文件", "error open", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                FileHelper fh = new FileHelper();
                parse1=fh.Open(ofd.FileName);
            }
            if (richTextBox1.GetLineFromCharIndex(richTextBox1.TextLength)==(parse1.data.Count()+parse2.data.Count()))
            {
                richTextBox1.Clear();
            }
            for (int i = 0; i < parse1.data.Count(); i++)
            {
                for (int j = 0; j < parse1.data[i].X.Length; j++)
                {
                    richTextBox1.Text += $"{parse1.data[i].X[0, j]}\t";
                }
                richTextBox1.Text += "\r\n";
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "正式数据.txt";
            ofd.Filter = "*.txt|*.txt";
            ofd.InitialDirectory = Application.StartupPath;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (ofd.FileName.Contains("N"))
                {
                    MessageBox.Show("请打开M文件", "error open", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                FileHelper fh = new FileHelper();
                parse2 = fh.Open(ofd.FileName);
            }
            if (richTextBox1.GetLineFromCharIndex(richTextBox1.TextLength) == (parse1.data.Count() + parse2.data.Count()))
            {
                richTextBox1.Clear();
            }
            for (int i = 0; i < parse2.data.Count(); i++)
            {
                for (int j = 0; j < parse2.data[i].X.Length; j++)
                {
                    richTextBox1.Text += $"{parse2.data[i].X[0, j]}\t";
                }
                richTextBox1.Text += "\r\n";
            }
            
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (parse1.data.Count()==0||parse2.data.Count()==0)
            {
                MessageBox.Show("请导入数据后进行计算","error cal",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            dataGridView1.Rows.Clear();
            Algo algo = new Algo(parse1,parse2);
            double[,] matrix = algo.V1();
            for (int i = 0; i < parse1.data.Count(); i++)
            {
                dataGridView1.Rows.Add(1);
                for (int j = 0; j < parse1.data[i].X.Length; j++)
                {             
                    dataGridView1.Rows[i].Cells[j].Value = matrix[i, j].ToString("f2"); 
                }
            }
        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (parse1.data.Count() == 0 || parse2.data.Count() == 0)
            {
                MessageBox.Show("请导入数据后进行计算", "error cal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Algo algo = new Algo(parse1, parse2);
            double[,] matrix = algo.V2();
            dataGridView2.Rows.Clear();
            for (int i = 0; i < parse1.data.Count(); i++)
            {
                dataGridView2.Rows.Add(1);
                for (int j = 0; j < parse1.data[i].X.Length; j++)
                {
                    dataGridView2.Rows[i].Cells[j].Value = matrix[i, j].ToString("f2");
                    
                }
            }
            
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            string ret = "";

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                ret += string.Format("{0,-10}", dataGridView1.Columns[i].HeaderText);
            }
            ret += "\r\n";
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j= 0; j < dataGridView1.Rows[0].Cells.Count; j++)
                {
                    ret += string.Format("{0,-10}", dataGridView1.Rows[i].Cells[j].Value);
                }
                ret += "\r\n";
            }
            for (int i = 0; i < dataGridView2.Columns.Count; i++)
            {
                ret += string.Format("{0,-10}", dataGridView2.Columns[i].HeaderText);
            }
            ret += "\r\n";
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView2.Rows[0].Cells.Count; j++)
                {
                    ret += string.Format("{0,-10}", dataGridView2.Rows[i].Cells[j].Value);
                }
                ret += "\r\n";
            }
       
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "result.txt";
            sfd.Filter = "*.txt|*.txt";
            if (sfd.ShowDialog()==DialogResult.OK)
            {
                FileHelper fh = new FileHelper();
                fh.Save(sfd.FileName,ret);
            }
         
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            refresh();
        }
    }
}
