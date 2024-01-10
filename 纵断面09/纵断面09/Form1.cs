using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 纵断面09
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

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }
        parse parse = new parse();
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.txt|*.txt";
            ofd.FileName = "data.txt";
            ofd.InitialDirectory = Application.StartupPath;
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                FileHelper fh = new FileHelper();
                parse=fh.Open(ofd.FileName);
            }
            if (parse.data.Count()==0)
            {
                MessageBox.Show("open empty","open",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            richTextBox1.Text += $"{parse.referID} ";
            richTextBox1.Text += $"{parse.referH}\r\n";
            for (int i = 0; i < parse.K.Count(); i++)
            {
                richTextBox1.Text += $"{parse.K[i].ID} ";
            }
            richTextBox1.Text += "\r\n";
            for (int i = 0; i < parse.AB.Count(); i++)
            {
                richTextBox1.Text += $"{parse.AB[i].ID},{parse.AB[i].X},{parse.AB[i].Y}\r\n";
            }
            richTextBox1.Text += "\r\n";
            int j = 0;
            for (int i = 0; i < parse.data.Count(); i++)
            {
                richTextBox1.Text += $"{parse.data[i].ID},{parse.data[i].X},{parse.data[i].Y},{parse.data[i].H}\r\n";
                if (parse.data[i].ID.Contains("K"))
                {
                    parse.K[j].X=parse.data[i].X;
                    parse.K[j].Y = parse.data[i].Y;
                    parse.K[j].H = parse.data[i].H;
                    j++;
                }
            }

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            algo algo = new algo();
            //内插纵断面
            int L = 10;
            for (int i = 0; i < parse.K.Count()-1; i++)
            {
                algo.Pnc(parse.K[i],parse.K[i+1],parse.K[0],ref L);
                if (i==parse.K.Count()-2)
                {
                    parse.K[i + 1].L = algo.D_all;
                    algo.nc_p.Add(parse.K[i+1]);
                }
            }
            for (int i = 0; i < algo.nc_p.Count(); i++)
            {
                if (algo.nc_p[i].ID.Contains("K"))
                {
                    richTextBox2.Text += $"{algo.nc_p[i].ID},{algo.nc_p[i].X.ToString("0.000")},{algo.nc_p[i].Y.ToString("0.000")},{algo.nc_p[i].H.ToString("0.000")}\r\n";
                    continue;
                }
                else
                {
                    algo.ncH(algo.nc_p[i], parse.data);
                    richTextBox2.Text += $"{algo.nc_p[i].ID},{algo.nc_p[i].X.ToString("0.000")},{algo.nc_p[i].Y.ToString("0.000")},{algo.nc_p[i].H.ToString("0.000")}\r\n";
                }
            }
            double areaZ = 0;
            for (int i = 0; i < algo.nc_p.Count()-1; i++)
            {
                areaZ += algo.area(parse.referH, algo.nc_p[i + 1].L - algo.nc_p[i].L, algo.nc_p[i], algo.nc_p[i + 1]);
            }
            richTextBox2.Text += $"纵断面面积:>{areaZ.ToString("0.000")}\r\n";
            algo.cm(parse.K);
            for (int i = 0; i < algo.centerM.Count(); i++)
            {
                richTextBox2.Text += $"M{algo.centerM[i].ID},{algo.centerM[i].X.ToString("0.000")},{algo.centerM[i].Y.ToString("0.000")}\r\n";
            }
            for (int i = 0; i < parse.K.Count()-1; i++)
            {
                algo.ncM(parse.K[i], parse.K[i + 1], i);
            }
            for (int i = 0; i < algo.nc_m.Count(); i++)
            {
                algo.ncH(algo.nc_m[i],parse.data);
                richTextBox2.Text += $"{algo.nc_m[i].ID},{algo.nc_m[i].X.ToString("0.000")},{algo.nc_m[i].Y.ToString("0.000")},{algo.nc_m[i].H.ToString("0.000")}\r\n";
            }
            for (int i = 0; i < algo.nc_m.Count(); i++)
            {
                dataGridView1.Rows.Add(1);
                dataGridView1.Rows[i].Cells[0].Value = $"{algo.nc_m[i].ID}";
                dataGridView1.Rows[i].Cells[1].Value = $"{algo.nc_m[i].X.ToString("f3")}";
                dataGridView1.Rows[i].Cells[2].Value = $"{algo.nc_m[i].Y.ToString("f3")}";
                dataGridView1.Rows[i].Cells[3].Value = $"{algo.nc_m[i].H.ToString("f3")}";
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }
    }
}
