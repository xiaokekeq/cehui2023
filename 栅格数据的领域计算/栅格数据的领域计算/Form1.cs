using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 栅格数据的领域计算
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           toolStripStatusLabel2.Text=DateTime.Now.ToString();
            toolStripStatusLabel2.Alignment = ToolStripItemAlignment.Right;
        }
        Parse parse1=new Parse();
        Parse parse2=new Parse();
        string text = "";
        string result = "";
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.txt|*.txt";
            ofd.FileName = "M矩阵.txt";
            
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                if (ofd.FileName.Contains("M矩阵"))
                {
                    FileHelper fh = new FileHelper();
                    parse1 = fh.Open(ofd.FileName);
                    for (int i = 0; i < parse1.data.Count(); i++)
                    {
                        for (int j = 0; j < parse1.data[i].X.Length; j++)
                        {
                            text +=$"{parse1.data[i].X[0, j].ToString()}  ";
                        }
                        text += "\r\n";
                    }
                    richTextBox1.Text=text;
                }
                else
                {
                    MessageBox.Show("请打开M矩阵文件","open",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.txt|*.txt";
            ofd.FileName = "N矩阵.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (ofd.FileName.Contains("N矩阵"))
                {
                    FileHelper fh = new FileHelper();
                    parse2 = fh.Open(ofd.FileName);
                    for (int i = 0; i < parse2.data.Count(); i++)
                    {
                        for (int j = 0; j < parse2.data[i].X.Length; j++)
                        {
                            text += $"{parse2.data[i].X[0, j].ToString()}  ";
                        }
                        text += "\r\n";
                    }
                    richTextBox1.Text = text;
                }
                else
                {
                    MessageBox.Show("请打开N矩阵文件", "open", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Algo algo = new Algo(parse1,parse2);
            double[,] Vmatrix1=algo.matrixV1();
            for (int i = 0;i < Math.Sqrt(Vmatrix1.Length);i++)
            {
                for (int j = 0; j < Math.Sqrt(Vmatrix1.Length); j++)
                {
                    result += $"{Vmatrix1[i, j].ToString("0.00")}   ";
                }
                result += "\r\n";
            }
            result +=$"{new string('-',90)}"+"\r\n";
            double[,] Vmatrix2 = algo.matrixV2();
            for (int i = 0; i < Math.Sqrt(Vmatrix1.Length); i++)
            {
                for (int j = 0; j < Math.Sqrt(Vmatrix1.Length); j++)
                {
                    result += $"{Vmatrix1[i, j].ToString("0.00")}   ";
                }
                result += "\r\n";
            }
            richTextBox2.Clear();
            tabControl1.SelectTab(1);
            richTextBox2.Text = result;

            
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd=new SaveFileDialog();
            sfd.Filter = "*.txt|*.txt";
            sfd.FileName = "result.txt";
            if (sfd.ShowDialog()==DialogResult.OK)
            {
                FileHelper fh = new FileHelper();
                fh.Save(sfd.FileName, result);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            保存ToolStripMenuItem_Click(sender, e);
        }
    }
}
