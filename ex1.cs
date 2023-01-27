using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_HW_25012023
{
    public class Ex1
    {
        private readonly static Ex1 _EX1 = new Ex1();
        public static Ex1 EX1
        {
            get { return _EX1; }
        }

        public void WriteToFile()
        {
            string FileName = "file.txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(FileName, true))
                {
                    for (int i = 0; i < 10; i++)
                    {
                        sw.WriteLine("hello");

                    }

                }

            }
            catch (Exception)
            {

                throw;
            }
            Thread.Sleep(1000);
        }
    }
}
