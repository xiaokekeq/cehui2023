using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 单点定位_0723
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Parse parse = new Parse();
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.txt|*.txt";
            ofd.FileName = "正式数据.txt";
            ofd.InitialDirectory = Application.StartupPath;
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                FileHelper fh = new FileHelper();
                parse = fh.Open(ofd.FileName);
            }
            int m = 0;
            for (int i = 0; i < parse.data_all.Count(); i++)
            {
                dataGridView1.Rows.Add(1);
                dataGridView1.Rows[m].Cells[0].Value = $"第{i}个数据";
                m += 1;
                for (int j = 0; j < parse.data_all[i].data.Count(); j++)
                {
                    dataGridView1.Rows.Add(1);
                    dataGridView1.Rows[m].Cells[0].Value = parse.data_all[i].data[j].id;
                    dataGridView1.Rows[m].Cells[1].Value = parse.data_all[i].data[j].X;
                    dataGridView1.Rows[m].Cells[2].Value = parse.data_all[i].data[j].Y;
                    dataGridView1.Rows[m].Cells[3].Value = parse.data_all[i].data[j].Z;
                    dataGridView1.Rows[m].Cells[4].Value = parse.data_all[i].data[j].Clock;
                    dataGridView1.Rows[m].Cells[5].Value = parse.data_all[i].data[j].ele;
                    dataGridView1.Rows[m].Cells[6].Value = parse.data_all[i].data[j].CL;
                    dataGridView1.Rows[m].Cells[7].Value = parse.data_all[i].data[j].TD;
                    m++;
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            int m = 0;
            Algo algo = new Algo(parse);
            for (int i = 0; i < parse.data_all.Count(); i++)
            {
                algo.BLP(i);
                algo.Lsq(parse.pos0, i);
                dataGridView2.Rows.Add(1);
                dataGridView2.Rows[m].Cells[0].Value = parse.data_all[i].sate.time;
                dataGridView2.Rows[m].Cells[1].Value = parse.data_all[i].pos.arr[0, 0].ToString("F4");
                dataGridView2.Rows[m].Cells[2].Value = parse.data_all[i].sigma.arr[0, 0].ToString("F4");
                dataGridView2.Rows[m].Cells[3].Value = parse.data_all[i].pos.arr[1, 0].ToString("F4");
                dataGridView2.Rows[m].Cells[4].Value = parse.data_all[i].sigma.arr[1, 0].ToString("F4");
                dataGridView2.Rows[m].Cells[5].Value = parse.data_all[i].pos.arr[2, 0].ToString("F4");
                dataGridView2.Rows[m].Cells[6].Value = parse.data_all[i].sigma.arr[2, 0].ToString("F4");
                dataGridView2.Rows[m].Cells[7].Value = parse.data_all[i].PDOP.ToString("F4");
                m++;
            }
           
        }
    }
}
