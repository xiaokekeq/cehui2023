using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 单点定位矩阵练习
{
    class FileHelper
    {
        Parse parse = new Parse();
        public Parse Open(string fileName)
        {
            using (StreamReader sr=new StreamReader(fileName,Encoding.Default))
            {
                string line = sr.ReadLine();
                string[] lines=line.Split(',', '，', '：', ':','(');
                parse.pos= new Matrix(3,1);
                parse.pos.arr[0,0] = Convert.ToDouble(lines[1]);
                parse.pos.arr[1, 0] = Convert.ToDouble(lines[2]);
                parse.pos.arr[2, 0] = Convert.ToDouble(lines[3]);
                sr.ReadLine();
                int j = 0;
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    if (line=="")
                    {
                        break;
                    }
                    parse.parse1(line);
                    for (int i = 0; i < parse.d.sate_cg.satNum; i++)
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
