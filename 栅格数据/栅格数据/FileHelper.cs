using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 栅格数据
{
    internal class FileHelper
    {
        
        public Parse Open(string fileName)//打开数据文件
        {
            Parse parse = new Parse();
            using (StreamReader sr=new StreamReader(fileName))
            {   
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
