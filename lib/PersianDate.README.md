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


    	string persianSampleDateString1 = "1393/08/01 21:53:26";
	DateTime datetime1 = persianSampleDateString1.ToEn();

	//default format 
	datetime1.ToFa();//1393/08/01
	//date only (short and D for Long)
	datetime1.ToFa("d");//93/08/01
	datetime1.ToFa("D");//پنج شنبه, 01 آبان 1393
	//time only 
	datetime1.ToFa("t");//21:53
	datetime1.ToFa("T");//21:53:26
	//general short date + time
	datetime1.ToFa("g");//93/08/01 21:53
	datetime1.ToFa("G");//93/08/01 21:53:26
	//general full date + time
	datetime1.ToFa("f");//پنج شنبه, 01 آبان 1393 ساعت 21:53
	datetime1.ToFa("F");//پنج شنبه, 01 آبان 1393 ساعت 21:53:26
	//only month and not year 
	datetime1.ToFa("m");//1 آبان 
	datetime1.ToFa("M");//اول آبان 
	//only year and month and not any day
	datetime1.ToFa("y");//1393 آبان
	datetime1.ToFa("Y");//1393 آبان
	//similar to standard formats : combine them as you wish
	datetime1.ToFa("yy MMM");//93 آبان 
	datetime1.ToFa("yyyy/MM/dd ");//1393/08/01 
	datetime1.ToFa("yy-M-dd ");//93-8-01
	datetime1.ToFa("ddd d MMM yyyy");//جمعه 1 آبان 1393
	datetime1.ToFa("ddd D MMM yyyy");//جمعه اول آبان 1393
	/////////part 2
	//testing convertion to DateTime from different styles of persian strings
	//also showing default standard and custom .NET DateTime format strings after convertion
	//default format 
	"1393/08/01 16:20".ToEn();//10/23/2014 4:20:00 PM
	"01/8/1393".ToEn().ToShortDateString();//10/23/2014
	"1/8/1393".ToEn().ToLongDateString();//Thursday, October 23, 2014
	//https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings
	"1-8-93".ToEn().ToString("d");//10/23/2014 //Short date pattern 
	"93-8-01".ToEn().ToString("U");//Wednesday, October 22, 2014 8:30:00 PM //Universal full date/time pattern
	"93-8-01".ToEn().ToString("y");//October 2014 //Year month pattern
	"93 8 01".ToEn().ToString("ddd d MMM yyyy");//Thu 23 Oct 2014
	//extra spaces and different separators are handled 
	"1_8_1393 ".ToEn().ToString("g");//10/23/2014 12:00 AM
	" 1_8_1393 16:20".ToEn().ToString("f");//Thursday, October 23, 2014 4:20 PM
	" 1.8.1393 16:20:48".ToEn().ToString("R");//Thu, 23 Oct 2014 16:20:48 GMT
