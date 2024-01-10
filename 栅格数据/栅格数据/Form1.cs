using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 栅格数据
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Parse parse1=new Parse();
        Parse parse2=new Parse();
        string text = "";//数据文件
        string result = "";//结果文件
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd=new OpenFileDialog();
            ofd.Filter = "*.txt|*.txt";
            ofd.FileName = "data.txt";
            
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                if (!ofd.FileName.Contains("M矩阵"))
                {
                    MessageBox.Show("请打开M矩阵", "Open error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                FileHelper fh = new FileHelper();
                parse1=fh.Open(ofd.FileName);
            }
            for (int i = 0; i < parse1.data.Count(); i++)
            {
                for (int j = 0; j < parse1.data[i].X.Length; j++)
                {
                    text += $"{parse1.data[i].X[0, j]} ";
                }
                text += "\r\n";
            }
            richTextBox1.Text = text;
            toolStripStatusLabel1.Text = "成功打开M文件!";
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.txt|*.txt";
            ofd.FileName = "data.txt";
            
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (!ofd.FileName.Contains("N矩阵"))
                {
                    MessageBox.Show("请打开N矩阵", "Open error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                FileHelper fh = new FileHelper();
                parse2 = fh.Open(ofd.FileName);
            }
            text += $"{new string('-', 90)}\r\n";
            for (int i = 0; i < parse2.data.Count(); i++)
            {
                for (int j = 0; j < parse2.data[i].X.Length; j++)
                {
                    text += $"{parse2.data[i].X[0, j]} ";
                }
                text+= "\r\n";
            }
            richTextBox1.Text= text;
            toolStripStatusLabel1.Text = "成功打开N文件!";
        }

        private void Form1_Load(object sender, EventArgs e)
        {    
            timer1.Interval = 1000;//时钟间隔1ms
            timer1.Start();//开始
            toolStripStatusLabel2.Alignment=ToolStripItemAlignment.Right;//把时间置于右边
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);//点击计算后跳转到报告中
            Algo algo = new Algo(parse1,parse2);
            double[,] v1=algo.matrixV1();
            for (int i = 0; i < Math.Sqrt(v1.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(v1.Length); j++)
                {
                    result += $"{v1[i, j].ToString("0.00")}   ";
                }
                result += "\r\n";
            }
            result += $"{new string('-', 80)}\r\n";
            double[,] v2=algo.matrixV2();
            for (int i = 0; i < Math.Sqrt(v2.Length); i++)//显示矩阵
            {
                for (int j = 0; j < Math.Sqrt(v2.Length); j++)
                {
                    result += $"{v2[i, j].ToString("0.00")}   ";
                }
                result += "\r\n";
            }
            richTextBox2.Text += result;
            toolStripStatusLabel1.Text = "计算栅格数据成功!";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel2.Text = DateTime.Now.ToString();//状态栏显示时间
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd=new SaveFileDialog();//保存
            sfd.Filter = "*.txt|*.txt";
            sfd.FileName = "result.txt";
            if (sfd.ShowDialog()==DialogResult.OK)
            {
                FileHelper fh = new FileHelper();
                fh.Save(sfd.FileName,result);
            }
        }
    }
}
