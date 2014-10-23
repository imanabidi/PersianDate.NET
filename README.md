PersianDate.NET
===============

when you usually use a jquery date picker (
  -http://hasheminezhad.com/datepicker 
  -https://github.com/behzadi/persianDatepicker
  -http://babakhani.github.io/PersianWebToolkit/datepicker.html
  ) 
  in webpages or any other apps in UI side and want to:
  
- convert your persian date string back to georgian and save it as a datetime in database you need some functions to do it for you.

  
- also you need this library when you want to show back the persian date back to UI.
  


////////////////////////Formats//////////////////
it uses the following format for converting to  different styles of persian(Farsi or shamsi) date and times 

case "d": return sd.ShortDate;//93/07/27
case "D": return sd.LongDate;//یکشنبه, 27 مهر 1393
case "t": return sd.ShortTime;
case "T": return sd.LongTime;
case "f": //Long date + short time
    return string.Format("{0} {1}", sd.LongDate, sd.ShortTime);
case "F": // Long date + long time //یکشنبه, 27 مهر 1393 01:15:43
    return string.Format("{0} {1}", sd.LongDate, sd.LongTime);
case "g": //Short date + short time //93/07/27 01:14:24
    return string.Format("{0} {1}", sd.ShortDate, sd.ShortTime);
case "G": //Short date + long time
    return string.Format("{0} {1}", sd.ShortDate, sd.LongTime);
case "m":
case "M":  //Month and day
    return string.Format("{0} {1}", sd.MahName, sd.RoozEMah);
case "y":
case "Y": // year and month
    return string.Format("{0} {1}", sd.Saal, sd.MahName);
case "B": // year and month
    return string.Format("{0}/{1:00}/{2:00}", sd.Saal, sd.Mah, sd.RoozEMah);
default:
    return sd.ShortDate;
