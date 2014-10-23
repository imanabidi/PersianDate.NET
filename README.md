PersianDate.NET
===============

when you usually use a jquery persian date picker (

    - http://hasheminezhad.com/datepicker 
    
    - https://github.com/behzadi/persianDatepicker
    
    - http://babakhani.github.io/PersianWebToolkit/datepicker.html
  
  ) 
  in webpages or any other apps in UI side and want to:
  
  
    -convert your persian date string back to georgian and save it as a datetime in database you need some functions to do it for you. 
   - also you need this library when you want to show back the persian date back to UI.
  

////////////////////////Formats//////////////////

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

string persiandate = PersianDate.ConvertDate.ToFa(DateTime.Now);//1393/08/01

Debug.WriteLine(PersianDate.ConvertDate.ToEn(persiandate));//2014/10/23 00:00:00
