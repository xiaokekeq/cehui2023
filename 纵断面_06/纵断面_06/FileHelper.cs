using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 纵断面_06
{
    class FileHelper
    {
        Parse parse = new Parse();
        public Parse Open(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                string[] lines=sr.ReadLine().Split(',');
                parse.referID = lines[0];
                parse.referH = Convert.ToDouble(lines[1]);
                lines = sr.ReadLine().Split(',');
                for (int i = 0; i < lines.Count(); i++)
                {
                    DataEntity k = new DataEntity();
                    k.ID = lines[i];
                    parse.K.Add(k);
                }
                for (int i = 0; i < 2; i++)
                {
                    lines = sr.ReadLine().Split(',');
                    DataEntity ab = new DataEntity();
                    ab.ID = lines[0];
                    ab.X = Convert.ToDouble(lines[1]);
                    ab.Y = Convert.ToDouble(lines[2]);
                    parse.AB.Add(ab);
                }
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    parse.parse(sr.ReadLine());
                }
            }
            return parse;
        }
        public void Save(string fileName,string ret)
        {
            using (StreamWriter sw=new StreamWriter(fileName))
            {
                sw.WriteLine(ret);
            }
        }
    }
}
