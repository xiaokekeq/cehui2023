using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 栅格数据的领域计算_0721
{
    class FileHelper
    {
        public Parse Open(string fileName)
        {
            Parse parse = new Parse();
            using (StreamReader sr = new StreamReader(fileName))
            {
                while (!sr.EndOfStream)
                {
                    parse.parse(sr.ReadLine());
                }
            }
            return parse;   
        }

    }
}
