using System;
using System.Collections.Generic;

using System.Text;

namespace UsageSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            string persiandate = PersianDate.Persia.ConvertDate.ToFa(DateTime.Now);
            Console.WriteLine(persiandate);

            Console.WriteLine(PersianDate.Persia.ConvertDate.ToEn(persiandate));

            Console.WriteLine("press any key to continue");
            Console.ReadKey();
        }
    }
}
