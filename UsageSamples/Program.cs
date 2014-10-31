using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace UsageSamples
{
    class Program
    {
        static void Main(string[] args)
        {

            Debug.WriteLine(PersianDate.ConvertDate.ToFa(DateTime.Now));//1393/08/01

            Debug.WriteLine(PersianDate.ConvertDate.ToFa(DateTime.Now, "d"));//93/08/01
            Debug.WriteLine(PersianDate.ConvertDate.ToFa(DateTime.Now, "D"));//پنج شنبه, 01 آبان 1393
            
            Debug.WriteLine(PersianDate.ConvertDate.ToFa(DateTime.Now, "t"));//21:53
            Debug.WriteLine(PersianDate.ConvertDate.ToFa(DateTime.Now, "T"));//21:53:26
            
            Debug.WriteLine(PersianDate.ConvertDate.ToFa(DateTime.Now, "g"));//93/08/01 21:53
            Debug.WriteLine(PersianDate.ConvertDate.ToFa(DateTime.Now, "G"));//93/08/01 21:53:26


            Debug.WriteLine(PersianDate.ConvertDate.ToFa(DateTime.Now, "f"));//پنج شنبه, 01 آبان 1393 21:53
            Debug.WriteLine(PersianDate.ConvertDate.ToFa(DateTime.Now, "F"));//پنج شنبه, 01 آبان 1393 21:53:26

            Debug.WriteLine(PersianDate.ConvertDate.ToFa(DateTime.Now, "m"));//آبان 1
            Debug.WriteLine(PersianDate.ConvertDate.ToFa(DateTime.Now, "M"));//

            Debug.WriteLine(PersianDate.ConvertDate.ToFa(DateTime.Now, "y"));//1393 آبان
            Debug.WriteLine(PersianDate.ConvertDate.ToFa(DateTime.Now, "Y"));//1393 آبان
            //new standard formats 
            Debug.WriteLine("new standard formats ");
            Debug.WriteLine(PersianDate.ConvertDate.ToFa(DateTime.Now, "yy MMM"));//93 آبان 
            Debug.WriteLine(PersianDate.ConvertDate.ToFa(DateTime.Now, "yyyy/MM/dd "));//1393/8/9 
            Debug.WriteLine(PersianDate.ConvertDate.ToFa(DateTime.Now, "yy-M-d "));//93-8-09
            Debug.WriteLine(PersianDate.ConvertDate.ToFa(DateTime.Now, "ddd dd MMM yyyy"));//جمعه 9 آبان 1393

            //testing convert back to DateTime from persian string
            Debug.WriteLine("ToEn test (testing convert back to DateTime from persian string) ");

            Debug.WriteLine(PersianDate.ConvertDate.ToEn("1393/08/01"));//2014/10/23 00:00:00
            Debug.WriteLine(PersianDate.ConvertDate.ToEn("01/8/1393"));//2014/10/23 00:00:00
            Debug.WriteLine(PersianDate.ConvertDate.ToEn("1/8/1393"));//2014/10/23 00:00:00
            Debug.WriteLine(PersianDate.ConvertDate.ToEn("1-8-93"));//2014/10/23 00:00:00
            Debug.WriteLine(PersianDate.ConvertDate.ToEn("93-8-01"));//2014/10/23 00:00:00
            Debug.WriteLine(PersianDate.ConvertDate.ToEn("93 8 01"));//2014/10/23 00:00:00
            //extra spaces and different seperators are handeled
            Debug.WriteLine(PersianDate.ConvertDate.ToEn("1_8_1393 "));//2014/10/23 00:00:00
            Debug.WriteLine(PersianDate.ConvertDate.ToEn(" 1_8_1393 "));//2014/10/23 00:00:00
            Debug.WriteLine(PersianDate.ConvertDate.ToEn(" 1.8.1393 "));//2014/10/23 00:00:00


            Console.WriteLine("check visual studio output window");
            Console.WriteLine("press any key to continue");
            Console.ReadKey();
        }
    }
}
