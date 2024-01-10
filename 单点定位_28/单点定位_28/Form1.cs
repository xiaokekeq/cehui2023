using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 单点定位_28
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
            timer1.Interval = 1000;
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
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                FileHelper fh = new FileHelper();
                parse=fh.Open(ofd.FileName);
            }
            int m = 0;
            for (int i = 0; i < parse.data_all.Count(); i++)
            {
                dataGridView1.Rows.Add(1);
                dataGridView1.Rows[m].Cells[0].Value = $"第{i+1}组数据";
                m++;
                for (int j = 0; j < parse.data_all[i].data.Count(); j++)
                {
                    dataGridView1.Rows.Add(1);
                    dataGridView1.Rows[m].Cells[0].Value = parse.data_all[i].data[j].id;
                    dataGridView1.Rows[m].Cells[1].Value = parse.data_all[i].data[j].X;
                    dataGridView1.Rows[m].Cells[2].Value = parse.data_all[i].data[j].Y;
                    dataGridView1.Rows[m].Cells[3].Value = parse.data_all[i].data[j].Z;
                    dataGridView1.Rows[m].Cells[4].Value = parse.data_all[i].data[j].Clock;
                    dataGridView1.Rows[m].Cells[5].Value = parse.data_all[i].data[j].Elev;
                    dataGridView1.Rows[m].Cells[6].Value = parse.data_all[i].data[j].CL;
                    dataGridView1.Rows[m].Cells[7].Value = parse.data_all[i].data[j].TD;
                    m++;
                }
            }
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Algo algo = new Algo(parse);
            for (int i = 0; i < parse.data_all.Count(); i++)
            {
                algo.BLP(i);
                algo.VQX(i);
                dataGridView2.Rows.Add(1);
                dataGridView2.Rows[i].Cells[0].Value = parse.data_all[i].satep.time;
                dataGridView2.Rows[i].Cells[1].Value =algo.pos.arr[0, 0].ToString("f4");
                dataGridView2.Rows[i].Cells[2].Value = parse.data_all[i].xigama.arr[0,0].ToString("f4");
                dataGridView2.Rows[i].Cells[3].Value = algo.pos.arr[1, 0].ToString("f4");
                dataGridView2.Rows[i].Cells[4].Value = parse.data_all[i].xigama.arr[1, 0].ToString("f4");
                dataGridView2.Rows[i].Cells[5].Value = algo.pos.arr[2, 0].ToString("f4");
                dataGridView2.Rows[i].Cells[6].Value = parse.data_all[i].xigama.arr[2, 0].ToString("f4");
                dataGridView2.Rows[i].Cells[7].Value = parse.data_all[i].POOP.ToString("f4");
            }

        }
    }
}
