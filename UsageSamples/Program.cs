using System;
using System.Diagnostics;
using PersianDate;

namespace UsageSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            string persianSampleDateString1 = "1393/08/01 21:53:26";
            DateTime datetime1 = persianSampleDateString1.ToEn();

            //default format 
            Debug.WriteLine(datetime1.ToFa());//1393/08/01
            //date only (short and D for Long)
            Debug.WriteLine(datetime1.ToFa("d"));//93/08/01
            Debug.WriteLine(datetime1.ToFa("D"));//پنج شنبه, 01 آبان 1393
            //time only 
            Debug.WriteLine(datetime1.ToFa("t"));//21:53
            Debug.WriteLine(datetime1.ToFa("T"));//21:53:26
            //general short date + time
            Debug.WriteLine(datetime1.ToFa("g"));//93/08/01 21:53
            Debug.WriteLine(datetime1.ToFa("G"));//93/08/01 21:53:26
            //general full date + time
            Debug.WriteLine(datetime1.ToFa("f"));//پنج شنبه, 01 آبان 1393 ساعت 21:53
            Debug.WriteLine(datetime1.ToFa("F"));//پنج شنبه, 01 آبان 1393 ساعت 21:53:26
            //only month and not year 
            Debug.WriteLine(datetime1.ToFa("m"));//1 آبان 
            Debug.WriteLine(datetime1.ToFa("M"));//اول آبان 
            //only year and month and not any day
            Debug.WriteLine(datetime1.ToFa("y"));//1393 آبان
            Debug.WriteLine(datetime1.ToFa("Y"));//1393 آبان
            //similar to standard formats : combine them as you wish
            Debug.WriteLine("### Similar to standard formats ####");
            Debug.WriteLine(datetime1.ToFa("yy MMM"));//93 آبان 
            Debug.WriteLine(datetime1.ToFa("yyyy/MM/dd "));//1393/08/01 
            Debug.WriteLine(datetime1.ToFa("yy-M-dd "));//93-8-01
            Debug.WriteLine(datetime1.ToFa("ddd d MMM yyyy"));//جمعه 1 آبان 1393
            Debug.WriteLine(datetime1.ToFa("ddd D MMM yyyy"));//جمعه اول آبان 1393
            /////////part 2
            //testing convertion to DateTime from different styles of persian strings
            //also showing default standard and custom .NET DateTime format strings after convertion
            Debug.WriteLine("### ToEn test (testing convertion to DateTime from different styles of persian strings) ###");
	        //default format 
			Debug.WriteLine("1393/08/01 16:20".ToEn());//10/23/2014 4:20:00 PM
            Debug.WriteLine("01/8/1393".ToEn().ToShortDateString());//10/23/2014
            Debug.WriteLine("1/8/1393".ToEn().ToLongDateString());//Thursday, October 23, 2014
            //https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings
            Debug.WriteLine("1-8-93".ToEn().ToString("d"));//10/23/2014 //Short date pattern 
            Debug.WriteLine("93-8-01".ToEn().ToString("U"));//Wednesday, October 22, 2014 8:30:00 PM //Universal full date/time pattern
            Debug.WriteLine("93-8-01".ToEn().ToString("y"));//October 2014 //Year month pattern
            Debug.WriteLine("93 8 01".ToEn().ToString("ddd d MMM yyyy"));//Thu 23 Oct 2014
            //extra spaces and different separators are handled 
            Debug.WriteLine("1_8_1393 ".ToEn().ToString("g"));//10/23/2014 12:00 AM
            Debug.WriteLine(" 1_8_1393 16:20".ToEn().ToString("f"));//Thursday, October 23, 2014 4:20 PM
            Debug.WriteLine(" 1.8.1393 16:20:48".ToEn().ToString("R"));//Thu, 23 Oct 2014 16:20:48 GMT

            Console.WriteLine("check visual studio output window to see unicode characters");
            Console.WriteLine("press any key to continue");
            Console.ReadKey();
        }
    }
}
