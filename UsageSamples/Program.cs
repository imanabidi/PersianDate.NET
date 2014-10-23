using System;
using System.Collections.Generic;

using System.Text;

namespace UsageSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            string persiandate = PersianDate.ConvertDate.ToFa(DateTime.Now);
            
            Console.WriteLine(persiandate);

            Console.WriteLine(PersianDate.ConvertDate.ToEn(persiandate));

            Console.WriteLine("press any key to continue");
            Console.ReadKey();
        }
    }
}
