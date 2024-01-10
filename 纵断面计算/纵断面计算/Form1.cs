using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 纵断面计算
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        string text;
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd=new OpenFileDialog();
            ofd.Filter = "*.txt|*.txt";
            ofd.FileName = "data.txt";
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                fileHelper fh=new fileHelper();
                fh.Open(ofd.FileName);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd=new SaveFileDialog();
            sfd.FileName = "result";
            sfd.Filter = "*.txt|*.txt";
           fileHelper fh=new fileHelper();
            fh.Save(sfd.FileName,text);
        }
    }
}
