using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 单点定位_0723
{
    class FileHelper
    {
        public string[] name ;
       
        public Parse Open(string FileName)
        {
            Parse parse = new Parse();

            using (StreamReader sr=new StreamReader(FileName,Encoding.Default))
            {
                string[] lines = sr.ReadLine().Split(',', ':', '：', '(');
                parse.Sate_ID = lines[0];
                parse.Sate_X = Convert.ToDouble(lines[1]);
                parse.Sate_Y = Convert.ToDouble(lines[2]);
                parse.Sate_Z = Convert.ToDouble(lines[3]);
                parse.pos0.arr[0, 0] = parse.Sate_X;
                parse.pos0.arr[1, 0] = parse.Sate_Y;
                parse.pos0.arr[2, 0] = parse.Sate_Z;

                int j = 0;
                name=sr.ReadLine().Split(',', ':', '：');
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (line == "")
                    {
                        break;
                    }
                    parse.parse1(line);
                    for (int i = 0; i < parse.d.sate.number; i++)
                    {
                        parse.parse2(sr.ReadLine());
                    }
                    parse.data_all.Add(parse.d);
                    j++;
                }

            }
            return parse;
        }
    }
}
