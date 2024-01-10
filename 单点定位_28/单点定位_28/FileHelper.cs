using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 单点定位_28
{
    class FileHelper
    {
        public Parse Open(string FileName)
        {
            Parse parse = new Parse();
            
            using (StreamReader sr=new StreamReader(FileName,Encoding.Default))
            {
                string[] lines = sr.ReadLine().Replace('\t', ',').Split(',', ':', '：', '(');
                parse.pos.arr[0,0] = Convert.ToDouble(lines[1]);
                parse.pos.arr[1, 0] = Convert.ToDouble(lines[2]);
                parse.pos.arr[2, 0] = Convert.ToDouble(lines[3]);
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (line=="")
                    {
                        break;
                    }
                    parse.parse1(line);
                    for (int i = 0; i < parse.data.satep.satNum; i++)
                    {
                        parse.parse2(sr.ReadLine());
                    }
                    parse.data_all.Add(parse.data);
                }
            }
            return parse;
        }
    }
}
