using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 大地主题正反算_25
{
    class FileHelper
    {
        Parse parse = new Parse();
        public Parse OpenF(string FileName)
        {
            using (StreamReader sr=new StreamReader(FileName))
            {
                string[] line = sr.ReadLine().Split(',');
                parse.a = Convert.ToDouble(line[0]);
                parse.f =1/ Convert.ToDouble(line[1]);
                while (!sr.EndOfStream)
                {
                    parse.parse1(sr.ReadLine());
                }
            }
            return parse;
        }
        public Parse OpenZ(string FileName)
        {
            using (StreamReader sr = new StreamReader(FileName))
            {
                string[] line = sr.ReadLine().Split(',');
                parse.a = Convert.ToDouble(line[0]);
                parse.f = 1 / Convert.ToDouble(line[1]);
                while (!sr.EndOfStream)
                {
                    parse.parse2(sr.ReadLine());
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
