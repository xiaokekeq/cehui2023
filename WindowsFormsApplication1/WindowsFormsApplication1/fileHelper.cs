using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class fileHelper
    {
       
        Parse parse = new Parse();
        public Parse Open(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                string[] lines = sr.ReadLine().Split(',');
                parse.referenceName = lines[0];
                parse.refernceH = Convert.ToDouble(lines[1]);
                lines = sr.ReadLine().Split(',');
                for (int i = 0; i < lines.Count(); i++)
                {
                    DataEntity datak = new DataEntity();
                    datak.ID = lines[i];
                    parse.dataK.Add(datak);
                }
                
                for (int i = 0; i < 2; i++)
                {
                    lines = sr.ReadLine().Split(',');
                    DataEntity data = new DataEntity();
                    data.ID = lines[0];
                    data.X = Convert.ToDouble(lines[1]);
                    data.Y = Convert.ToDouble(lines[2]);
                    parse.AB.Add(data);
                }
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    parse.parse(sr.ReadLine());
                }
            }
            return parse;
        }
        public void Save(string fileName,string text)
        {
            using (StreamWriter sw=new StreamWriter(fileName))
            {
                sw.WriteLine(text);
            }
        }
    }
}
