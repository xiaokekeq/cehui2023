using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 纵断面_07_21
{
    class FileHelper
    {
        public Parse Open(string FileName)
        {
            Parse parse = new Parse();
            using (StreamReader sr=new StreamReader(FileName))
            {
                string[] line = sr.ReadLine().Split(',');
                parse.referHId = line[0];
                parse.referH = Convert.ToDouble(line[1]);
                line = sr.ReadLine().Split(',');
                for (int i = 0; i < line.Count(); i++)
                {
                    DataEntity d = new DataEntity();
                    d.ID = line[i];
                    parse.AB.Add(d);
                }    
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string line1 = sr.ReadLine();
                    parse.parse(line1);
                }
                return parse;
            }
        }
    }
}
