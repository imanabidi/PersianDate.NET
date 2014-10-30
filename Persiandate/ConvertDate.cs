using System;
using System.Collections.Generic;
using System.Globalization;
//using System.Linq;
using System.Text;
using PersianDate;

namespace PersianDate
{

    public static class ConvertDate
    {
        private static readonly string[] ShamsiMonthNames = { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };
        //private static readonly string[] ShamsiWeekDayNames = {"شنبه", "یکشنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنجشنبه", "جمعه" };
        // private static readonly string[] ShamsiWeekDayShortNames = { "ی", "د", "س", "چ", "پ", "ج", "ش" };



        /// <summary>
        /// usually to convert the persian calendar output text and any format starting with 4 digit farsi year
        /// </summary>
        /// <param name="fadate"></param>
        /// <returns></returns>
        public static DateTime ToEn(string fadate)
        {
            if (fadate.Trim() == "") return DateTime.MinValue;
            int[] farsiPartArray = SplitRoozMahSal(fadate);

            return new PersianCalendar().ToDateTime(farsiPartArray[0], farsiPartArray[1], farsiPartArray[2], 0, 0, 0, 0);

        }

        /// <summary>
        /// get persian date and convert to georgian or miladi date
        /// </summary>
        /// <param name="y">shamsi year like 1392</param>
        /// <param name="m">shamsi month number like 1 </param>
        /// <param name="d">shamsi day number like 17</param>
        /// <returns></returns>
        public static DateTime ToEn(int y, int m, int d)
        {
            if (y < 100 | y > 3000 | m < 0 | m > 12 | d < 0 | d > 33) return DateTime.MinValue;

            return new PersianCalendar().ToDateTime(y, m, d, 0, 0, 0, 0);

        }

        /// <summary>
        /// it is the main function responsible for analyzing and splitting the given persian date parts 
        /// and then convert back to gregorian date 
        /// </summary>
        /// <param name="farsiDate"></param>
        /// <returns></returns>
        private static int[] SplitRoozMahSal(string farsiDate)
        {


            #region normalization and exception hadling
            //normalize with one character
            farsiDate = farsiDate.Trim().Replace(@"\", "/").Replace(@"-", "/").Replace(@" ", "/");

            if (!farsiDate.Contains("/"))
            {
                if (farsiDate.Split('/').Length != 2)
                    throw new Exception("usually there should be 2 seperator for a complete date");
            }
            else //mostly given in all numeric format like 13930316
            {
                // detect year side and add slashes in right places and continue
            }
            //todo: handle if date is given in rtl format like 16021393
            //todo: handle if date is given in short year format like 930316
            //todo: ()not very usual handle if date is given in very short format like 93316

            #endregion


            int year = 0;
            int month = 0;
            int day = 0;
            int.TryParse(farsiDate.Substring(0, 4), out year);
            if (year == 0)
                throw new Exception("the first 4 character must denots a shamsi year like 1393");


            switch (farsiDate.Length)
            {
                case 10://1389/01/01
                    month = Convert.ToInt32(farsiDate.Substring(5, 2));
                    day = Convert.ToInt32(farsiDate.Substring(8, 2));
                    break;

                case 8://13900421
                    if (!farsiDate.Contains("/"))
                    {
                        month = Convert.ToInt32(farsiDate.Substring(4, 2));
                        day = Convert.ToInt32(farsiDate.Substring(6, 2));
                    }
                    else if (farsiDate[4] == '/' && farsiDate[6] == '/')//1389/1/1
                    {
                        month = Convert.ToInt32(farsiDate.Substring(5, 1));
                        day = Convert.ToInt32(farsiDate.Substring(7, 1));
                    }
                    break;

                case 9://1389/01/1 or //1389/1/01
                    if (farsiDate.Substring(7, 1) == "/")
                    {
                        month = Convert.ToInt32(farsiDate.Substring(5, 2));
                        day = Convert.ToInt32(farsiDate.Substring(8, 1));
                    }
                    else
                    {
                        month = Convert.ToInt32(farsiDate.Substring(5, 1));
                        day = Convert.ToInt32(farsiDate.Substring(7, 2));
                    }
                    break;
            }
            return new[] { year, month, day };

        }







        #region ShamsiDate


        internal static ShamsiDate ToShamsiDate(DateTime date)
        {
            return new ShamsiDate(date);
        }

        internal static ShamsiDate ToShamsiDate(int selectedYear, int selectedMonth, int selectedDay)
        {
            var date = new DateTime(selectedYear, selectedMonth, selectedDay);

            return new ShamsiDate(date);
        }

        internal static ShamsiDate ToShamsiDate(int? selectedYear, int? selectedMonth, int? selectedDay)
        {
            if (!(selectedYear.HasValue && selectedMonth.HasValue && selectedDay.HasValue)) return null;

            var date = new DateTime(selectedYear.Value, selectedMonth.Value, selectedDay.Value);

            return new ShamsiDate(date);
        }

        internal static ShamsiDate ToShamsiDate(DateTime? selectedDate)
        {
            if (!selectedDate.HasValue) return null;

            return new ShamsiDate(selectedDate.Value);
        }

        #endregion

        public static string MapWeekDayToName(int sunDayOfWeek)
        {
            //we can use this method instead if switch
            //return ShamsiMonthNames[sunDayOfWeek];

            switch (sunDayOfWeek)
            {
                case 0: return "شنبه";
                case 1: return "یک شنبه";
                case 2: return "دو شنبه";
                case 3: return "سه شنبه";
                case 4: return "چهار شنبه";
                case 5: return "پنج شنبه";
                case 6: return "جمعه";

                default: throw new Exception("Map_WeekDay_ToName invalid number");
            }
        }

        public static string MapWeekDayToName(DayOfWeek sunDayOfWeek)
        {
            switch (sunDayOfWeek)
            {
                case DayOfWeek.Saturday: return "شنبه";
                case DayOfWeek.Sunday: return "یک شنبه";
                case DayOfWeek.Monday: return "دو شنبه";
                case DayOfWeek.Tuesday: return "سه شنبه";
                case DayOfWeek.Wednesday: return "چهار شنبه";
                case DayOfWeek.Thursday: return "پنج شنبه";
                case DayOfWeek.Friday: return "جمعه";
            }
            return "";
        }

        public static int MapWeekDayToNum(DayOfWeek sunDayOfWeek)
        {

            switch (sunDayOfWeek)
            {
                case DayOfWeek.Saturday: return 0;
                case DayOfWeek.Sunday: return 1;
                case DayOfWeek.Monday: return 2;
                case DayOfWeek.Tuesday: return 3;
                case DayOfWeek.Wednesday: return 4;
                case DayOfWeek.Thursday: return 5;
                case DayOfWeek.Friday: return 6;

                default: throw new Exception("Map_WeekDay_ToName invalid number");
            }
        }

        public static string MapFarsiMonthNumToName(int fmonth)
        {
            return ShamsiMonthNames[fmonth - 1];
        }


        /// <summary>
        /// convert to persian string with default format like 1393/07/03
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToFa(DateTime dateTime)
        {
            return ToFa(dateTime, "B");
        }

        /// <summary>
        /// nice method from persian calendar project by Nickmehr
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="format">d(date short),D t(time short),T f(full),F 
        /// - g,G , m,M y,Y and finally B (1393/07/18)</param>
        /// <returns></returns>
        public static string ToFa(DateTime? dateTime, string format)
        {

            if (!dateTime.HasValue)
                return string.Empty;

            ShamsiDate sd = ToShamsiDate(dateTime.Value);

            if (format.Length == 1)
            {


                switch (format)
                {

                    case "d":
                        return sd.ShortDate; //93/07/27
                    case "D":
                        return sd.LongDate; //یکشنبه, 27 مهر 1393
                    case "t":
                        return sd.ShortTime;
                    case "T":
                        return sd.LongTime;

                    case "f": //Long date + short time
                        return string.Format("{0} {1}", sd.LongDate, sd.ShortTime);
                    case "F": // Long date + long time //یکشنبه, 27 مهر 1393 01:15:43
                        return string.Format("{0} {1}", sd.LongDate, sd.LongTime);

                    case "g": //Short date + short time //93/07/27 01:14:24
                        return string.Format("{0} {1}", sd.ShortDate, sd.ShortTime);
                    case "G": //Short date + long time
                        return string.Format("{0} {1}", sd.ShortDate, sd.LongTime);

                    case "m":
                    case "M": //Month and day
                        return string.Format("{0} {1}", sd.MahName, sd.RoozeMah);

                    case "y":
                    case "Y": // year and month
                        return string.Format("{0} {1}", sd.Saal, sd.MahName);

                    case "B": //best with year and month and day ,simple
                        return string.Format("{0}/{1:00}/{2:00}", sd.Saal, sd.Mah, sd.RoozeMah);
                    default:
                        return sd.ShortDate;
                }
            }
            else
            {
                //important: first replace longer occurances

                format = format.Replace("YY","yy");

                return format
                    .Replace("yyyy", sd.Saal.ToString(CultureInfo.InvariantCulture))
                    .Replace("yy", sd.Saal.ToString(CultureInfo.InvariantCulture).Substring(2,2))
                    .Replace("MMM",  sd.MahName.ToString(CultureInfo.InvariantCulture))
                    .Replace("MM", sd.Mah.ToString(CultureInfo.InvariantCulture).PadLeft(2,'0'))
                    .Replace("M", sd.Mah.ToString(CultureInfo.InvariantCulture))
                    .Replace("ddd", sd.RoozeHaftehName.ToString(CultureInfo.InvariantCulture))
                    .Replace("dd", sd.RoozeMah.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0'))
                    .Replace("d", sd.RoozeMah.ToString(CultureInfo.InvariantCulture))
                    .Replace("hh", sd.Saat.ToString(CultureInfo.InvariantCulture))
                    .Replace("mm", sd.Daghighe.ToString(CultureInfo.InvariantCulture))
                    .Replace("ss", sd.Saniyeh.ToString(CultureInfo.InvariantCulture)); 
            }


        }

    }
}
