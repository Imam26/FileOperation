using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace SecondTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFileName = "INPUT.txt";
            string outputFileName = "OUTPUT.txt";

            try
            {
                using (FileStream fStream = new FileStream(inputFileName, FileMode.Create))
                {
                    Byte[] input = Encoding.UTF8.GetBytes("5 10");

                    fStream.Write(input, 0, input.Length);
                }

                using(FileStream fStream = new FileStream(outputFileName, FileMode.Create))
                {
                    string [] str = File.ReadAllText(inputFileName).Split(new char[]{' '});

                    int sum = int.Parse(str[0]) + int.Parse(str[1]);

                    Byte[] input = Encoding.UTF8.GetBytes(sum.ToString());

                    fStream.Write(input, 0, input.Length);
                }

                Process.Start("notepad.exe", outputFileName);
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }         
        }
    }
}
