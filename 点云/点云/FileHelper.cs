using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 点云
{
    class FileHelper
    {
        Parse parse = new Parse();
        public Parse Open(string FileName)
        {
            using (StreamReader sr=new StreamReader(FileName))
            {
                parse.num = Convert.ToInt32(sr.ReadLine());
                while (!sr.EndOfStream)
                {
                    parse.parse(sr.ReadLine());
                }
            }
            return parse;
        }
    }
}
