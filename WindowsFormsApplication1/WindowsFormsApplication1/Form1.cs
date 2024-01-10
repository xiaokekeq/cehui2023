using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string text="";
        fileHelper fh = new fileHelper();
        Parse parse = new Parse();
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.txt|*.txt";
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                parse=fh.Open(ofd.FileName);
                for (int i = 0; i < parse.data.Count(); i++)
                {
                    //textBox1.Text += $"{ parse.data[i].ID},{i}\r\n";
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = parse.data[i].ID;
                    dataGridView1.Rows[i].Cells[1].Value = parse.data[i].X;
                    dataGridView1.Rows[i].Cells[2].Value = parse.data[i].Y;
                    dataGridView1.Rows[i].Cells[3].Value = parse.data[i].H;
                   
                }
               
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.txt|*.txt ";
            if (sfd.ShowDialog()==DialogResult.OK)
            {
                fh.Save(sfd.FileName, text);
            }
           
        }
        private void dataGridView1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }
        private void dataGridView1_RowContextMenuStripChanged(object sender, DataGridViewRowEventArgs e)
        {

        }

        private void dataGridView1_ColumnHeaderCellChanged(object sender, DataGridViewColumnEventArgs e)
        {
            
        }

        private void dataGridView1_RowHeaderCellChanged(object sender, DataGridViewRowEventArgs e)
        {
            
        }

        private void dataGridView1_RowStateChanged_1(object sender, DataGridViewRowStateChangedEventArgs e)
        {
          
            for (int i = 0; i < parse.data.Count(); i++)
            {
                e.Row.HeaderCell.Value = $"{i}";
            }
        }
    }
}
