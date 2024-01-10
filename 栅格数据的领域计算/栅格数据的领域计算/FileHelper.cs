using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 栅格数据的领域计算
{
    internal class FileHelper
    {
        public Parse Open(string FileName)
        {
            Parse parse=new Parse();
            using (StreamReader sr=new StreamReader(FileName))
            {
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
