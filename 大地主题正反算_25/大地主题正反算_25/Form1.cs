using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 大地主题正反算_25
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Parse parse ;
        public_Algo public_Algo = new public_Algo();
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //正算
            parse = new Parse();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "正式数据.txt";
            ofd.Filter = "*.txt|*.txt";
            ofd.InitialDirectory = Application.StartupPath;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileHelper fh = new FileHelper();
                parse = fh.OpenZ(ofd.FileName);
            }
            for (int i = 0; i < parse.data.Count(); i++)
            {
                dataGridView1.Rows.Add(1);
                dataGridView1.Rows[i].Cells[0].Value = parse.data[i].StartID;
                dataGridView1.Rows[i].Cells[1].Value = public_Algo.RAD2DFM(parse.data[i].B1);
                dataGridView1.Rows[i].Cells[2].Value = public_Algo.RAD2DFM(parse.data[i].L1);
                dataGridView1.Rows[i].Cells[3].Value = parse.data[i].EndID;
                dataGridView1.Rows[i].Cells[4].Value = public_Algo.RAD2DFM(parse.data[i].B2);
                dataGridView1.Rows[i].Cells[5].Value = public_Algo.RAD2DFM(parse.data[i].L2);
                dataGridView1.Rows[i].Cells[6].Value = public_Algo.RAD2DFM(parse.data[i].A12);
                dataGridView1.Rows[i].Cells[7].Value = public_Algo.RAD2DFM(parse.data[i].A21);
                dataGridView1.Rows[i].Cells[8].Value = parse.data[i].S;

            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //反算
            parse = new Parse();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "正式数据.txt";
            ofd.Filter = "*.txt|*.txt";
            ofd.InitialDirectory = Application.StartupPath;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileHelper fh = new FileHelper();
                parse = fh.OpenF(ofd.FileName);
            }
            for (int i = 0; i < parse.data.Count(); i++)
            {
                dataGridView1.Rows.Add(1);
                dataGridView1.Rows[i].Cells[0].Value = parse.data[i].StartID;
                dataGridView1.Rows[i].Cells[1].Value = public_Algo.RAD2DFM(parse.data[i].B1);
                dataGridView1.Rows[i].Cells[2].Value = public_Algo.RAD2DFM(parse.data[i].L1);
                dataGridView1.Rows[i].Cells[3].Value = parse.data[i].EndID;
                dataGridView1.Rows[i].Cells[4].Value = public_Algo.RAD2DFM(parse.data[i].B2);
                dataGridView1.Rows[i].Cells[5].Value = public_Algo.RAD2DFM(parse.data[i].L2);
                dataGridView1.Rows[i].Cells[6].Value = public_Algo.RAD2DFM(parse.data[i].A12);
                dataGridView1.Rows[i].Cells[7].Value = public_Algo.RAD2DFM(parse.data[i].A21);
                dataGridView1.Rows[i].Cells[8].Value = parse.data[i].S;

            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            
            Algo_reverse algo = new Algo_reverse(parse.a,parse.f);
            for (int i = 0; i < parse.data.Count(); i++)
            {
                algo.auxi_cal(parse.data, i);
                algo.Startazimuth();
                parse.data[i].S=algo.S();
                algo.A2();
                dataGridView2.Rows.Add(1);
                dataGridView2.Rows[i].Cells[0].Value = parse.data[i].StartID;
                dataGridView2.Rows[i].Cells[1].Value = public_Algo.RAD2DFM(parse.data[i].B1);
                dataGridView2.Rows[i].Cells[2].Value = public_Algo.RAD2DFM(parse.data[i].L1);
                dataGridView2.Rows[i].Cells[3].Value = parse.data[i].EndID;
                dataGridView2.Rows[i].Cells[4].Value = public_Algo.RAD2DFM(parse.data[i].B2);
                dataGridView2.Rows[i].Cells[5].Value = public_Algo.RAD2DFM(parse.data[i].L2);
                dataGridView2.Rows[i].Cells[6].Value = public_Algo.RAD2DFM(algo.A1).ToString("f5");
                dataGridView2.Rows[i].Cells[7].Value = public_Algo.RAD2DFM(algo.A21).ToString("f5");
                dataGridView2.Rows[i].Cells[8].Value = algo.s.ToString("f5");
            }
            tabControl1.SelectedIndex = 1;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Algo algo = new Algo(parse.a,parse.f);
            for (int i = 0; i < parse.data.Count(); i++)
            {
                algo.StartLat(parse.data,i);
                algo.auxi(parse.data[i].A12);
                algo.Sdeta(parse.data[i].S);
                algo.B2L2A2(parse.data[i].A12, parse.data[i].L1);
                dataGridView2.Rows.Add(1);
                dataGridView2.Rows[i].Cells[0].Value = parse.data[i].StartID;
                dataGridView2.Rows[i].Cells[1].Value = public_Algo.RAD2DFM(parse.data[i].B1);
                dataGridView2.Rows[i].Cells[2].Value = public_Algo.RAD2DFM(parse.data[i].L1);
                dataGridView2.Rows[i].Cells[3].Value = parse.data[i].EndID;
                dataGridView2.Rows[i].Cells[4].Value = public_Algo.RAD2DFM(algo.B2).ToString("f5");
                dataGridView2.Rows[i].Cells[5].Value = public_Algo.RAD2DFM(algo.L2).ToString("f5");
                dataGridView2.Rows[i].Cells[6].Value = public_Algo.RAD2DFM(parse.data[i].A12);
                dataGridView2.Rows[i].Cells[7].Value = public_Algo.RAD2DFM(algo.A21).ToString("f5");
                dataGridView2.Rows[i].Cells[8].Value = parse.data[i].S;
            }
            tabControl1.SelectedIndex = 1;
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ret = "";
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "result.txt";
            sfd.Filter = "*.txt|*.txt";
            for (int i = 0; i < dataGridView2.ColumnCount; i++)
            {
                ret += $"{string.Format("{0,-10}",dataGridView2.Columns[i].HeaderText.ToString())}\t";
            }
            ret += "\r\n";
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView2.Rows[0].Cells.Count; j++)
                {
                    ret += $"{string.Format("{0,-10}", dataGridView2.Rows[i].Cells[j].Value)}\t";
                }
                ret += "\r\n";
            }
            if (sfd.ShowDialog()==DialogResult.OK)
            {
                FileHelper fh = new FileHelper();
                fh.Save(sfd.FileName,ret);
            }
          
        }
    }
}
