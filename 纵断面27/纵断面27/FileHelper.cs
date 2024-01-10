using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 纵断面27
{
    class FileHelper
    {
        public Parse Open(string FileName)
        {
            Parse parse = new Parse();
            using (StreamReader sr=new StreamReader(FileName))
            {
                string[] lines= sr.ReadLine().Split(',');
                parse.Hid = lines[0];
                parse.Hv = Convert.ToDouble(lines[1]);
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
    }
}
