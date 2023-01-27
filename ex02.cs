using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_HW_25012023
{
    public class Ex02
    {
        private readonly static Ex02 _EX2 = new Ex02();
        public static Ex02 EX2
        {
            get { return _EX2; }
        }
        public Task<string> ShowNumbers(int num)
        {

            return Task.Run(() =>
            {
                Thread.Sleep(1000);
                return num.ToString();

            });
        }

    }
}
