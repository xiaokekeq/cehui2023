using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void 大地反算ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        string text;
        Parse parse=new Parse();
        FileHelper fh=new FileHelper();
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.txt|*.txt";
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                parse=fh.Open(ofd.FileName);
                for (int i = 0; i < parse.data1.Count(); i++)
                {
                    textBox1.Text += parse.data1[i].ID;
                    textBox1.Text += parse.data1[i].X;
                    textBox1.Text += parse.data1[i].Y;
                    textBox1.Text += parse.data1[i].H;
                    textBox1.Text += parse.data1[i].L;
                    textBox1.Text += "\r\n";
                }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd=new SaveFileDialog();
            sfd.Filter = "*.txt|*.txt";
            fh.save(sfd.FileName,text);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }
    }
}
