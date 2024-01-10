using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 纵断面09
{
    class FileHelper
    {
        parse parse = new parse();
        public parse Open(string fileName)
        {
            using (StreamReader sr=new StreamReader(fileName))
            {
                string[] lines=sr.ReadLine().Split(',');
                parse.referID = lines[0];
                parse.referH = Convert.ToDouble(lines[1]);
                lines = sr.ReadLine().Split(',');
                for (int i = 0; i < lines.Count(); i++)
                {
                    DataEntity d = new DataEntity();
                    d.ID = lines[i];
                    parse.K.Add(d);
                }
                
                for (int i = 0; i < 2; i++)
                {
                    lines = sr.ReadLine().Split(',');
                    DataEntity d = new DataEntity();
                    d.ID = lines[0];
                    d.X = Convert.ToDouble(lines[1]);
                    d.Y = Convert.ToDouble(lines[2]);
                    parse.AB.Add(d);
                }
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    parse.Parse(sr.ReadLine());
                }
            }
            return parse;
        }
    }
}
