using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 纵横断面
{
    class FileHelper
    {
        Parse parse = new Parse();
        public Parse Open(string FileName)
        {
            using (StreamReader sr=new StreamReader(FileName,Encoding.Default))
            {
                string[] line = sr.ReadLine().Split(',');
                parse.referH = line[0];
                parse.referHv = Convert.ToDouble(line[1]);
                line = sr.ReadLine().Split(',');
                for (int i = 0; i < line.Count(); i++)
                {
                    DataEntity d = new DataEntity();
                    d.ID = line[i];
                    parse.K.Add(d);
                }
                for (int i = 0; i < 2; i++)
                {
                    line = sr.ReadLine().Split(',');
                    DataEntity d = new DataEntity();
                    d.ID = line[0];
                    d.X = Convert.ToDouble(line[1]);
                    d.Y = Convert.ToDouble(line[2]);
                    parse.AB.Add(d);
                }
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    parse.parse(sr.ReadLine());
                }
            }
            return parse;
        }
        public void Save(string FileName,string ret)
        {
            using (StreamWriter sw=new StreamWriter(FileName))
            {
                sw.WriteLine(ret);
            }
        }
    }
}
