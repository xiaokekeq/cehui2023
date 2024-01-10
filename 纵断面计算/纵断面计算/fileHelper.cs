using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 纵断面计算
{
    internal class fileHelper
    {
        Parse parse=new Parse();
        public Parse Open(string fileName)
        {
            using (StreamReader sr=new StreamReader(fileName))
            {
                string[] lines=sr.ReadLine().Split(',');
                parse.refName = lines[0];
                parse.refH = Convert.ToDouble(lines[1]);
                lines=sr.ReadLine().Split(',');
               
            }
        }
        public void Save (string fileName,string text)
        {
            using (StreamWriter sw=new StreamWriter(fileName))
            {
                sw.WriteLine(text);
            }
        }
    }
}
