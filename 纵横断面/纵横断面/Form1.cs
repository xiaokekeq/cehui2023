using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 纵横断面
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
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "正式数据.txt";
            ofd.Filter = "*.txt|*.txt";
            ofd.InitialDirectory = Application.StartupPath;
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                FileHelper fh = new FileHelper();
                parse=fh.Open(ofd.FileName);
            }
            int j = 0;
            for (int i = 0; i < parse.data.Count(); i++)
            {
                dataGridView1.Rows.Add(1);
                dataGridView1.Rows[i].Cells[0].Value = parse.data[i].ID;
                dataGridView1.Rows[i].Cells[1].Value = parse.data[i].X;
                dataGridView1.Rows[i].Cells[2].Value = parse.data[i].Y;
                dataGridView1.Rows[i].Cells[3].Value = parse.data[i].H;
                if (parse.data[i].ID.Contains("K"))
                {
                    parse.K[j].X = parse.data[i].X;
                    parse.K[j].Y = parse.data[i].Y;
                    parse.K[j].H = parse.data[i].H;
                    j++;
                }
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }
        Algo algo = new Algo();
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
           
            double dp = 10;
            //内插纵断面点
            for (int i = 0; i < parse.K.Count()-1; i++)
            {
                algo.ncZ(parse.K[i],parse.K[i+1],parse.K[0],ref dp);
                if (i==parse.K.Count()-2)
                {
                    parse.K[i + 1].D = algo.D_SUM;
                    algo.Pnc.Add(parse.K[i+1]);
                }
            }
            //内插纵断面的高程
            for (int i = 0; i < algo.Pnc.Count(); i++)
            {
                if (algo.Pnc[i].H!=0)
                {
                    dataGridView2.Rows.Add(1);
                    dataGridView2.Rows[i].Cells[0].Value = algo.Pnc[i].ID;
                    dataGridView2.Rows[i].Cells[1].Value = algo.Pnc[i].X.ToString("f3");
                    dataGridView2.Rows[i].Cells[2].Value = algo.Pnc[i].Y.ToString("f3");
                    dataGridView2.Rows[i].Cells[3].Value = algo.Pnc[i].H.ToString("f3");
                    dataGridView2.Rows[i].Cells[4].Value = algo.Pnc[i].D.ToString("f3");
                    continue;
                }
                else
                {
                    algo.Pnc[i].H=algo.ncH(parse.data, algo.Pnc[i]);
                    dataGridView2.Rows.Add(1);
                    dataGridView2.Rows[i].Cells[0].Value = algo.Pnc[i].ID;
                    dataGridView2.Rows[i].Cells[1].Value = algo.Pnc[i].X.ToString("f3");
                    dataGridView2.Rows[i].Cells[2].Value = algo.Pnc[i].Y.ToString("f3");
                    dataGridView2.Rows[i].Cells[3].Value = algo.Pnc[i].H.ToString("f3");
                    dataGridView2.Rows[i].Cells[4].Value = algo.Pnc[i].D.ToString("f3");
                }
            }
            //计算纵断面面积
            double Sz = 0;
            for (int i = 0; i < algo.Pnc.Count()-1; i++)
            {
               Sz+= algo.area(parse.referHv, algo.Pnc[i], algo.Pnc[i + 1], Math.Abs(algo.Pnc[i].D- algo.Pnc[i+1].D));
            }
            richTextBox1.Text += $"纵断面面积：{Sz.ToString("f3")}\r\n";
            richTextBox1.Text += $"总长度：{algo.D_SUM.ToString("f3")}\r\n";

            //内插横断面
            double Sh = 0;
            algo.Mcenter(parse.K);
            for (int i = 0; i < algo.centerM.Count(); i++)
            {
                algo.ncM(parse.K[i],parse.K[i+1],i);
            } 
            for (int i = 0; i < algo.Mnc.Count(); i++)
            { 
                algo.Mnc[i].H=algo.ncH(parse.data,algo.Mnc[i]);
                dataGridView3.Rows.Add(1);
                dataGridView3.Rows[i].Cells[0].Value = algo.Mnc[i].ID;
                dataGridView3.Rows[i].Cells[1].Value = algo.Mnc[i].X.ToString("f3");
                dataGridView3.Rows[i].Cells[2].Value = algo.Mnc[i].Y.ToString("f3");
                dataGridView3.Rows[i].Cells[3].Value = algo.Mnc[i].H.ToString("f3");
                dataGridView3.Rows[i].Cells[4].Value = algo.Mnc[i].D.ToString("f3");
            }
            //计算横断面面积
            for (int i = 0; i < algo.Mnc.Count / 2 - 1; i++)
            {
                Sh += algo.area(parse.referHv, algo.Mnc[i], algo.Mnc[i + 1], 5);
            }
            richTextBox1.Text += $"横断面面积：{Sh.ToString("f3")}\r\n";
            Sh = 0;
            for (int i = algo.Mnc.Count / 2; i < algo.Mnc.Count() - 1; i++)
            {
                Sh += algo.area(parse.referHv, algo.Mnc[i], algo.Mnc[i + 1], 5);
            }
            richTextBox1.Text += $"横断面面积：{Sh.ToString("f3")}\r\n";
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "result.txt";
            sfd.Filter = "*.txt|*.txt";
            string ret = "";
            for (int i = 0; i < dataGridView2.ColumnCount; i++)
            {
                ret +=string.Format("{0,-10}",dataGridView2.Columns[i].HeaderText);
            }
            ret += "\r\n";
            int j = 1;
            for (int i = 0; i < algo.Pnc.Count(); i++)
            {
                if (algo.Pnc.Count()/2==i||i==0)
                {
                    ret += $"第{j}段\r\n";
                    j++;
                }
                ret += string.Format("{0,-10}", dataGridView2.Rows[i].Cells[0].Value);
                ret += string.Format("{0,-10}", dataGridView2.Rows[i].Cells[1].Value);
                ret += string.Format("{0,-10}", dataGridView2.Rows[i].Cells[2].Value);
                ret += string.Format("{0,-10}", dataGridView2.Rows[i].Cells[3].Value);
                ret += "\r\n";
            }
            ret += "\r\n";
            for (int i = 0; i < dataGridView3.ColumnCount; i++)
            {
                ret += string.Format("{0,-10}", dataGridView3.Columns[i].HeaderText);
            }
            ret += "\r\n";
            j = 1;
            for (int i = 0; i < algo.Mnc.Count(); i++)
            {
                if (algo.Mnc.Count() / 2 == i || i == 0)
                {
                    ret += $"第{j}段\r\n";
                    j++;
                }
                ret += string.Format("{0,-10}", dataGridView3.Rows[i].Cells[0].Value);
                ret += string.Format("{0,-10}", dataGridView3.Rows[i].Cells[1].Value);
                ret += string.Format("{0,-10}", dataGridView3.Rows[i].Cells[2].Value);
                ret += string.Format("{0,-10}", dataGridView3.Rows[i].Cells[3].Value);
                ret += string.Format("{0,-10}", dataGridView3.Rows[i].Cells[4].Value);
                ret += "\r\n";
            }
            ret += richTextBox1.Text;
            if (sfd.ShowDialog()==DialogResult.OK)
            {
                FileHelper fh = new FileHelper();
                fh.Save(sfd.FileName,ret);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
