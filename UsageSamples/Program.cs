using System;
using System.Diagnostics;
using PersianDate;

namespace UsageSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.WriteLine(DateTime.Now.ToFa());//1393/08/01

            Debug.WriteLine(DateTime.Now.ToFa("d"));//93/08/01
            Debug.WriteLine(DateTime.Now.ToFa("D"));//پنج شنبه, 01 آبان 1393
            
            Debug.WriteLine(DateTime.Now.ToFa("t"));//21:53
            Debug.WriteLine(DateTime.Now.ToFa("T"));//21:53:26
            
            Debug.WriteLine(DateTime.Now.ToFa("g"));//93/08/01 21:53
            Debug.WriteLine(DateTime.Now.ToFa("G"));//93/08/01 21:53:26


            Debug.WriteLine(DateTime.Now.ToFa("f"));//پنج شنبه, 01 آبان 1393 21:53
            Debug.WriteLine(DateTime.Now.ToFa("F"));//پنج شنبه, 01 آبان 1393 21:53:26

            Debug.WriteLine(DateTime.Now.ToFa("m"));//آبان 1
            Debug.WriteLine(DateTime.Now.ToFa("M"));//آبان 1

            Debug.WriteLine(DateTime.Now.ToFa("y"));//1393 آبان
            Debug.WriteLine(DateTime.Now.ToFa("Y"));//1393 آبان
            //new standard formats 
            Debug.WriteLine("new standard formats ");
            Debug.WriteLine(DateTime.Now.ToFa("yy MMM"));//93 آبان 
            Debug.WriteLine(DateTime.Now.ToFa("yyyy/MM/dd "));//1393/8/9 
            Debug.WriteLine(DateTime.Now.ToFa("yy-M-d "));//93-8-09
            Debug.WriteLine(DateTime.Now.ToFa("ddd dd MMM yyyy"));//جمعه 9 آبان 1393

            //testing convert back to DateTime from persian string
            Debug.WriteLine("ToEn test (testing convert back to DateTime from persian string) ");

            Debug.WriteLine("1393/08/01 16:20".ToEn());//2014/10/23 16:20:00
            Debug.WriteLine("01/8/1393".ToEn());//2014/10/23 00:00:00
            Debug.WriteLine("1/8/1393".ToEn());//2014/10/23 00:00:00
            Debug.WriteLine("1-8-93".ToEn());//2014/10/23 00:00:00
            Debug.WriteLine("93-8-01".ToEn());//2014/10/23 00:00:00
            Debug.WriteLine("93 8 01".ToEn());//2014/10/23 00:00:00
            //extra spaces and different separators are handled 
            Debug.WriteLine("1_8_1393 ".ToEn());//2014/10/23 00:00:00
            Debug.WriteLine(" 1_8_1393 16:20".ToEn());//2014/10/23 16:20:00
            Debug.WriteLine(" 1.8.1393 16:20:48".ToEn());//2014/10/23 16:20:48


            Console.WriteLine("check visual studio output window to see unicode characters");
            Console.WriteLine("press any key to continue");
            Console.ReadKey();
        }
    }
}
