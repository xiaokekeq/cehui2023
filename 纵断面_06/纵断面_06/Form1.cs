using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 纵断面_06
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Interval = 1000;
            toolStripStatusLabel2.Alignment = ToolStripItemAlignment.Right;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.ToString();
        }
        Parse parse = new Parse();
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "文本文件(*.txt)|*.txt";
            ofd.FileName = "data.txt";
            ofd.InitialDirectory = Application.StartupPath;
            richTextBox1.Clear();
           
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                FileHelper fh = new FileHelper();
                parse=fh.Open(ofd.FileName);
            }
            if (ofd.FileName == "data.txt")
            {
                MessageBox.Show("open empty", "open", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            richTextBox1.Text += $"Hid:{parse.referID} ,H:{parse.referH}\r\n";
            richTextBox1.Text += "K点号\r\n";
            for (int i = 0; i < parse.K.Count(); i++)
            {
                richTextBox1.Text += $"{parse.K[i].ID} ";
            }
            richTextBox1.Text += "\r\n";
            for (int i = 0; i < parse.AB.Count; i++)
            {
                richTextBox1.Text += $"AB ID={parse.AB[i].ID}, X={parse.AB[i].X}, X={parse.AB[i].Y}, X={parse.AB[i].H}\r\n";
            }
            richTextBox1.Text += "\r\n";
            richTextBox1.Text += "散点点号，X，Y，H\r\n";
            int j = 0;
            for (int i = 0; i < parse.data.Count(); i++)
            {
                richTextBox1.Text += $"ID={parse.data[i].ID}, X={parse.data[i].X}, y={parse.data[i].Y}, h={parse.data[i].H}\r\n";
                if (parse.data[i].ID.Contains("K"))
                {
                    parse.K[j].ID = parse.data[i].ID;
                    parse.K[j].X = parse.data[i].X;
                    parse.K[j].Y = parse.data[i].Y;
                    parse.K[j].H = parse.data[i].H;
                    j++;
                }
            }
            tabControl1.SelectedIndex = 0;
        }
        string ret = "";
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (ret=="")
            {
                MessageBox.Show("save empty", "save",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "result.txt";
            sfd.Filter = "文本文件(*.txt)|*.txt";
            sfd.Title = "保存文件";
            sfd.InitialDirectory = Application.StartupPath;
            if (sfd.ShowDialog()==DialogResult.OK)
            {
                FileHelper fh = new FileHelper();
                fh.Save(sfd.FileName,ret);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            richTextBox2.Clear();
            if (richTextBox1.Text=="")
            {
                MessageBox.Show("data empty error", "calculation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            algo algo = new algo();
            ///计算纵断面内插坐标加上了k0，k1，k2
            int dp = 10;
            for (int i = 0; i < parse.K.Count()-1; i++)
            {
                algo.pzuobiaio(parse.K[i], parse.K[i + 1],parse.K[0],ref dp);
                if (i==parse.K.Count()-2)
                {
                    parse.K[i + 1].L = algo.D_sum;
                    algo.PncPoint.Add(parse.K[i+1]);
                }
            }
            double areaZ = 0;
            richTextBox2.Text += $"p内插坐标\r\n";
            ///计算内插高程，要把已有的高程点去掉不进行计算
            for (int i = 0; i < algo.PncPoint.Count(); i++)
            {
                if (algo.PncPoint[i].H!=0)
                {
                    richTextBox2.Text += $"{algo.PncPoint[i].ID},{algo.PncPoint[i].X.ToString("0.000")},{algo.PncPoint[i].Y.ToString("0.000")},{algo.PncPoint[i].H.ToString("0.000")}\r\n";
                    continue;
                }
                else
                {
                    algo.ncH(algo.PncPoint[i], parse.data);
                    richTextBox2.Text += $"{algo.PncPoint[i].ID},{algo.PncPoint[i].X.ToString("0.000")},{algo.PncPoint[i].Y.ToString("0.000")},{algo.PncPoint[i].H.ToString("0.000")}\r\n";
                }
                
            }
            ///距离不是固定的10，而是例如
            ///k0到p1，p2...p4到k1的距离,k1到p5的距离，中间的k值到两内插点的距离不为10
            for (int i = 0; i < algo.PncPoint.Count() - 1; i++)
            {
                areaZ += algo.area(parse.referH, algo.PncPoint[i+1].L - algo.PncPoint[i].L, algo.PncPoint[i], algo.PncPoint[i + 1]);
            }
            richTextBox2.Text += $"面积为{areaZ.ToString("0.000")}\r\n";
            richTextBox2.Text += $"总长度为{algo.D_sum.ToString("0.000")}\r\n";
            ///横断面
            richTextBox2.Text += "横断面：\r\n";
            richTextBox2.Text += "中心坐标\r\n";
            algo.Hcenter(parse.K);
            for (int i = 0; i < algo.centerM.Count(); i++)
            {
                richTextBox2.Text += $"{algo.centerM[i].ID},{algo.centerM[i].X.ToString("0.000")},{algo.centerM[i].Y.ToString("0.000")}\r\n";
            }
            for (int i = 0; i < parse.K.Count()-1; i++)
            {
                algo.mcoordinate(parse.K[i],parse.K[i+1],i);
            }
            //横断面插值
            richTextBox2.Text += "横断面插值\r\n";
            for (int i = 0; i < algo.Mnc.Count(); i++)
            {
                algo.ncH(algo.Mnc[i],parse.data);
                richTextBox2.Text += $"{algo.Mnc[i].ID},{algo.Mnc[i].X.ToString("0.000")},{algo.Mnc[i].Y.ToString("0.000")},{algo.Mnc[i].H.ToString("0.000")}\r\n";
            }
            double areaH = 0;
            for (int i = 0; i <(algo.Mnc.Count())/2-1; i++)
            {
                areaH += algo.area(parse.referH,5,algo.Mnc[i],algo.Mnc[i+1]);
            }
            richTextBox2.Text += $"面积为{areaH.ToString("0.000")}\r\n";
            areaH = 0;
            for (int i = (algo.Mnc.Count()) / 2; i < (algo.Mnc.Count() - 1); i++)
            {
                areaH += algo.area(parse.referH, 5, algo.Mnc[i], algo.Mnc[i + 1]);
            }
            richTextBox2.Text += $"面积为{areaH.ToString("0.000")}\r\n";
            for (int i = 0; i < algo.Mnc.Count(); i++)
            {
                dataGridView1.Rows.Add(1);
                dataGridView1.Rows[i].Cells[0].Value = algo.Mnc[i].ID;
                dataGridView1.Rows[i].Cells[1].Value = algo.Mnc[i].X.ToString("f3");
                dataGridView1.Rows[i].Cells[2].Value = algo.Mnc[i].Y.ToString("f3");
                dataGridView1.Rows[i].Cells[3].Value = algo.Mnc[i].H.ToString("f3");
            }
        }
    }
}
