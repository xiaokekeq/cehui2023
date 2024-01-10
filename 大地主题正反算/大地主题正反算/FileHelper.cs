using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 大地主题正反算
{
    class FileHelper
    {
        public Parse OpenZ(string FileName)
        {
            Parse parse = new Parse();
            using (StreamReader sr=new StreamReader(FileName))
            {
                string[] line= sr.ReadLine().Split(',');
                parse.a = Convert.ToDouble(line[0]);
                parse.f =1/ Convert.ToDouble(line[1]);
                while (!sr.EndOfStream)
                {
                    parse.parseZ(sr.ReadLine());
                }
            }
            return parse;
        }
        public Parse OpenF(string FileName)
        {
            Parse parse = new Parse();
            using (StreamReader sr = new StreamReader(FileName))
            {
                string[] line = sr.ReadLine().Split(',');
                parse.a = Convert.ToDouble(line[0]);
                parse.f = 1/Convert.ToDouble(line[1]);
                while (!sr.EndOfStream)
                {
                    parse.parseF(sr.ReadLine());
                }
            }
            return parse;
        }
        public void Save(string fileName, string text)
        {
            using (StreamWriter sw=new StreamWriter(fileName))
            {
                sw.WriteLine(text);
            }
        }
    }
}
