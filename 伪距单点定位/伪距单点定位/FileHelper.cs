using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 伪距单点定位
{
    class FileHelper
    {
        public  string text = "";
      
        public Parse Open(string fileName)
        {
            Parse parse = new Parse();
            using (StreamReader sr=new StreamReader(fileName,Encoding.Default))
            {
                string line = sr.ReadLine();
                string[] lines= line.Trim().Split(',',':','：','(');
                parse.ID = lines[0];
                parse.position_X = Convert.ToDouble(lines[1]);
                parse.position_Y = Convert.ToDouble(lines[2]);
                parse.position_Z = Convert.ToDouble(lines[3]);
                text += line+"\r\n";
                text+= sr.ReadLine() + "\r\n";
                int j = 0;
                while (!sr.EndOfStream)
                {
                    string line1 = sr.ReadLine();
                    if (line1.Split(',',':','：').Count()==4)
                    {
                        text += line1+"\r\n";
                        parse.parse1(line1);
                    }
                    if (line1=="")
                    {
                        break;  
                    }
                    for (int i = 0; i < parse.d.sate.Number; i++)
                    {
                        line1 = sr.ReadLine();
                        text += line1 + "\r\n";
                        parse.parse2(line1);
                    }
                    parse.data.Add(parse.d);
                    j++;
                }
            }
            return parse;
        }
    }
}
