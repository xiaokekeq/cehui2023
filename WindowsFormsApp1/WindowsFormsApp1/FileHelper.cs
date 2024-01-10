using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class FileHelper
    {
        Parse parse=new Parse();
        public Parse Open(string fileName)
        {
            using (StreamReader sr=new StreamReader(fileName))
            {
                string[] lines=sr.ReadLine().Split(',');
                parse.referenceName = lines[0];
                parse.referenceH = Convert.ToDouble(lines[1]);
                lines= sr.ReadLine().Split(',');
                for (int i = 0; i < lines.Count(); i++)
                {
                    DataEntity d = new DataEntity();
                    d.ID = lines[i];
                    parse.datak.Add(d);
                }
               
                for (int i = 0;i < 2; i++)
                {
                    lines = sr.ReadLine().Split(',');
                    DataEntity dataEntity = new DataEntity();
                    dataEntity.ID = lines[0];
                    dataEntity.X = Convert.ToDouble(lines[1]);
                    dataEntity.Y= Convert.ToDouble(lines[2]);
                    parse.AB.Add(dataEntity);
                }
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    parse.parse(sr.ReadLine());
                }
                return parse; 
            }
        }
        public void save(string fileName,string text)
        {
            using (StreamWriter sw=new StreamWriter(fileName))
            {
                sw.WriteLine(text);
            }
        }
    }
}
