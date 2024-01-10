using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 大地正反算
{
    class FileHelper
    {
        Parse parse = new Parse();
        public Parse Open(string fileName)
        {
            using (StreamReader sr=new StreamReader(fileName))
            {
                string[] lines=sr.ReadLine().Split(',');
                parse.a = Convert.ToDouble(lines[0]);
                parse.f = 1/Convert.ToDouble(lines[1]);
                while (!sr.EndOfStream)
                {
                    parse.parse(sr.ReadLine());
                }
            }
            return parse;
        }
        public Parse Open1(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                string[] lines = sr.ReadLine().Split(',');
                parse.a = Convert.ToDouble(lines[0]);
                parse.f = 1 / Convert.ToDouble(lines[1]);
                while (!sr.EndOfStream)
                {
                    parse.parse1(sr.ReadLine());
                }
            }
            return parse;
        }
        public void Save(string filename,string ret)
        {
            using (StreamWriter sw=new StreamWriter(filename))
            {
                sw.WriteLine(ret);
            }
        }
    }
}
