using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace WindowsFormsApp1
{
    internal class Parse
    {
        public string referenceName;
        public double referenceH;
        public List<DataEntity> AB=new List<DataEntity>();
        public List<DataEntity> datak=new List<DataEntity>();
        public List<DataEntity> data1=new List<DataEntity>();
        public void parse(string line)
        {
            DataEntity data = new DataEntity();
            string[] lines = line.Split(',');
            data.ID = lines[0]; ;
            data.X = Convert.ToDouble(lines[1]);
            data.Y = Convert.ToDouble(lines[2]);
            data.H = Convert.ToDouble(lines[3]);
            data1.Add(data);
        }
    }
}
