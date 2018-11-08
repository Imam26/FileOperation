using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace FirstTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "FirstTask.txt";
            string fibNum = "0 1 1 2 3 5 8 13";

            try
            {
                FileStream fStream = new FileStream(fileName, FileMode.Create);

                byte[] input = Encoding.UTF8.GetBytes(fibNum);

                fStream.Write(input, 0, input.Length);
                fStream.Close();

                StreamReader sReader = new StreamReader(fileName);

                int count = 0;
                int symbolCode = 0;
                int lastNumber, nextNumber;

                lastNumber = nextNumber = 0;
               
                while (!sReader.EndOfStream)
                {
                    symbolCode = sReader.Read();
                    if (symbolCode == ' ')
                    {
                        count++;
                        lastNumber = nextNumber;
                        nextNumber = 0;
                    }
                    else
                    {
                        nextNumber*= 10;
                        int tempNumber = 0;
             
                        if(int.TryParse(((char)symbolCode).ToString(), out tempNumber))
                        {
                            nextNumber += tempNumber;
                        }
                    }
                }

                sReader.Close();

                StreamWriter sWriter = new StreamWriter(fileName, true);
                
                for(int i = 0; i<(count+1); i++)
                {
                    sWriter.Write(' ');
                    sWriter.Write(nextNumber + lastNumber);
                    int tempNumber = nextNumber;
                    nextNumber += lastNumber;
                    lastNumber = tempNumber;
                }

                sWriter.Close();

                Process.Start("notepad.exe", fileName);
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
