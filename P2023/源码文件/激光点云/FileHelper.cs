using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 激光点云
{
    class FileHelper
    {
        public Parse Open(string FileName)
        {
            Parse parse = new Parse();
            using (StreamReader sr = new StreamReader(FileName))
            {
                parse.num = Convert.ToDouble(sr.ReadLine());
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
