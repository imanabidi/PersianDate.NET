#PersianDate.NET
===============
install using nuget

https://www.nuget.org/packages/PersianDate/

PM> Install-Package PersianDate

- it is a lightweight(17KB) Persian date convertor library written in C# and with Microsoft.NET 2.
- it tries to detect, normalize  correct given persian date string , considering the default input is in yyyy/mm/dd (1393/07/18) format.
- it uses the default System.Globalization.PersianCalendar class for all date conversions
- most methods uses short names (ToFa or ToEn) and are static for fast invokation

##USES

when you usually use a jquery persian date picker like:
- http://hasheminezhad.com/datepicker 
- https://github.com/behzadi/persianDatepicker
- http://babakhani.github.io/PersianWebToolkit/datepicker.html

in webpages or any other apps in UI side and want to:
- convert your persian date string back to georgian and save it as a datetime in database you need some functions to do it for you. 
- also you need this library when you want to show back the persian date back to UI.

##Formats and samples
Note: all the given samples are in the simple usage console sample Project in the solution
use ToFa and toEn static methods of PersianDate class like below:

	using PersianDate; //requied namespace


    //default format 
    string dts=ConvertDate.ToFa(DateTime.Now);//1393/08/01
    //date only (short and D for Long)
    dts=ConvertDate.ToFa(DateTime.Now, "d");//93/08/01 
    dts=ConvertDate.ToFa(DateTime.Now, "D");//پنج شنبه, 01 آبان 1393
    //time only 
    dts=ConvertDate.ToFa(DateTime.Now, "t");//21:53 
    dts=ConvertDate.ToFa(DateTime.Now, "T");//21:53:26
    //general short date + time
    dts=ConvertDate.ToFa(DateTime.Now, "g");//93/08/01 21:53 
    dts=ConvertDate.ToFa(DateTime.Now, "G");//93/08/01 21:53:26
    //general full date + time
    dts=ConvertDate.ToFa(DateTime.Now, "f");//پنج شنبه, 01 آبان 1393 21:53 
    dts=ConvertDate.ToFa(DateTime.Now, "F");//پنج شنبه, 01 آبان 1393 21:53:26
    //only month and year
    dts=ConvertDate.ToFa(DateTime.Now, "m");//آبان 1 
    dts=ConvertDate.ToFa(DateTime.Now, "y");//1393 آبان
    
    //new standard formats 
    
    string string2=ConvertDate.ToFa(DateTime.Now, "yy MMM");//93 آبان 
    string2=ConvertDate.ToFa(DateTime.Now, "yyyy/MM/dd ");//1393/8/9 
    string2=ConvertDate.ToFa(DateTime.Now, "yy-M-d ");//93-8-09
    string2= ConvertDate.ToFa(DateTime.Now, "ddd dd MMM yyyy");//جمعه 9 آبان 1393
    
    //testing convert back to DateTime from persian string
    ConvertDate.ToEn("1393/08/01");//2014/10/23 00:00:00 
    ConvertDate.ToEn("01/8/1393");//2014/10/23 00:00:00 
    ConvertDate.ToEn("1/8/1393");//2014/10/23 00:00:00 
    ConvertDate.ToEn("1-8-93");//2014/10/23 00:00:00 
    ConvertDate.ToEn("93-8-01");//2014/10/23 00:00:00 
    ConvertDate.ToEn("93 8 01");//2014/10/23 00:00:00 
    //extra spaces and different seperators are handeled 
    ConvertDate.ToEn("1_8_1393 ");//2014/10/23 00:00:00 
    ConvertDate.ToEn(" 1_8_1393 ");//2014/10/23 00:00:00 
    ConvertDate.ToEn(" 1.8.1393 ");//2014/10/23 00:00:00
	
	
	//in 1.5 version time support is also added if entered
	ConvertDate.ToEn("1393/08/01 16:45");//2014-10-23 4:45:00 PM
