using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text.RegularExpressions;

namespace PersianDate.Standard
{
    /// <summary>
    /// not very essential class just some utility and helper methods to use with dates
    /// </summary>
    public static class DateAndTimeH
    {

        public static DateTime MinStartDate
        {
            get
            {
                //it is a sample date and can be customized ofcourse
                return new DateTime(1, 1, 1);
            }
        }

        public static Dictionary<String, int> GetAllFarsiMonths()
        {
            Dictionary<String, int> ht = new Dictionary<String, int>();

            for (int i = 1; i <= 12; i++)
                ht.Add(ConvertDate.MapFarsiMonthNumToName(i), i);
            //ht.Add(string.Format("{1} - {0}",Convert_Date.Map_FarsiMonthNum_ToName(i),i), i);

            return ht;
        }

        /// <summary>
        /// used to convert dropdownlist farsi months and year to make 2 string to set in persian calender
        /// </summary>
        /// <param name="faYear"></param>
        /// <param name="faMonth"></param>
        /// <param name="faDate1"></param>
        /// <param name="faDate2"></param>
        public static void ComputeStartEndDatesSpan(string faYear, string faMonth, ref string faDate1, ref string faDate2)
        {
            if (!Regex.IsMatch(faMonth, @"^\d{1,}$") || !Regex.IsMatch(faYear, @"^\d{1,}$")) return;

            int farsiMonth = int.Parse(faMonth);
            int farsiyear = int.Parse(faYear);

            faDate1 = String.Format("{0}/{1,2:D2}/01", farsiyear, farsiMonth);
            //////////////
            if (farsiMonth < 0 || farsiMonth > 12) return;

            if (farsiMonth < 12)
                faDate2 = String.Format("{0}/{1,2:D2}/01", farsiyear, farsiMonth + 1);
            else if (farsiMonth == 12)
                faDate2 = String.Format("{0}/{1,2:D2}/01", farsiyear + 1, 1);
        }


         

        public static List<int> GetAllFarsiYearsFromMinDate()
        {
            return GetAllFarsiYearsFromMinDate(MinStartDate);
        }
        public static List<int> GetAllFarsiYearsFromMinDate(DateTime minDate)
        {
            return GetAllFarsiYearsFromMinDate(minDate, DateTime.UtcNow);
        }
        public static List<int> GetAllFarsiYearsFromMinDate(DateTime minDate, DateTime endDate)
        {
            List<int> ht = new List<int>();

            int farsiStartYear = SaalNum(minDate);
            int farsiCurrentYear = SaalNum(endDate);

            for (int i = farsiCurrentYear; i >= farsiStartYear; i--)
                ht.Add(i);

            return ht;
        }


        /// <summary>
        /// return only the year, used for example in the footer and copyright in one shot
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static int SaalNum(DateTime dateTime)
        {
            return ConvertDate.ToShamsiDate(dateTime).Saal;
        }

        /// <summary>
        /// return only the month , used for example in the footer and copyright in one shot
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static int MahNum(DateTime dateTime)
        {
            return ConvertDate.ToShamsiDate(dateTime).Mah;
        }



        /// <summary>
        /// روزه ماه
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static int RoozNum(DateTime dateTime)
        {
            return ConvertDate.ToShamsiDate(dateTime).RoozeMah;
        }

        /// <summary>
        /// like 1391/03/08
        /// </summary>
        public static string CurrentFarsiDate
        {
            //get { return ConvertDate.ToFa(DateTime.Now); }
            get { return ConvertDate.ToFa(DateTime.Now, "d"); }
        }

        public static int CurrentFarsiMahNum
        {
            get { return MahNum(DateTime.Now); }
        }
        public static int CurrentFarsiSalNum
        {
            get { return SaalNum(DateTime.Now); }
        }

        #region Mandeha
        /// <summary>
        /// be rooz va saat va daghighe
        /// </summary>
        /// <param name="spanMandeh"></param>
        /// <returns></returns>
        public static string MandehFa(TimeSpan spanMandeh)
        {
            string word = "";
            if (spanMandeh.Ticks < 0)
            {
                spanMandeh = spanMandeh.Negate();
                word = " - ";
            }

            if (spanMandeh.Days >= 1)
                word += string.Format("{0} روز ", spanMandeh.Days);

            if (spanMandeh.Hours >= 1)
            {
                word += string.Format("  {0} ساعت ", spanMandeh.Hours);
                if (spanMandeh.Minutes != 0)
                    word += string.Format("  {0} دقیقه ", spanMandeh.Minutes);
            }
            else
                if (spanMandeh.Minutes >= 1)
                    // word += string.Format(" {0} دقیقه و {1} ثانیه ", span_Mandeh.Minutes, span_Mandeh.Seconds);
                    word += string.Format("{0} دقیقه ", spanMandeh.Minutes);
                else if (spanMandeh.TotalSeconds < 60)
                    word += string.Format("{0:0.00} ثانیه ", spanMandeh.TotalSeconds);
            return word;
        }

        /// <summary>
        /// from DateTime.Now
        /// </summary>
        /// <param name="date2"></param>
        /// <returns></returns>
        public static string MandehFa(DateTime date2)
        {
            return MandehFa(date2 - DateTime.Now);
        }


        public static string MandehFa(DateTime d2, DateTime d1)
        {
            return MandehFa(d2 - d1);
        } 
        #endregion




        #region Static properties
        /// <summary>
        /// start of day with zero time (rounded time)
        /// </summary>
        /// <returns></returns>
        public static DateTime CurrentDateStart
        {
            get { return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day); }
        }

        public static DateTime CurrentFarsiMahStart
        {
            get
            {
                System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                int y = pc.GetYear(DateTime.Now);
                int m = pc.GetMonth(DateTime.Now);

                return pc.ToDateTime(y, m, 1, 0, 0, 0, 0, 0);
            }

        }
        
        #endregion

        /// <summary>
        /// get farsi mah number
        /// </summary>
        /// <param name="selectedYear"></param>
        /// <param name="selectedMonth"></param>
        /// <param name="selectedDay"></param>
        /// <returns></returns>
        internal static int? MahNum(int? selectedYear, int? selectedMonth, int? selectedDay)
        {
            var shamsi = ConvertDate.ToShamsiDate(selectedYear, selectedMonth, selectedDay);
            if (shamsi == null) return null;

            return shamsi.Mah;
        }

        /// <summary>
        /// get farsi mah number
        /// </summary>
        /// <param name="selectedYear"></param>
        /// <param name="selectedMonth"></param>
        /// <param name="selectedDay"></param>
        /// <returns></returns>
        internal static int? SaalNum(int? selectedYear, int? selectedMonth, int? selectedDay)
        {
            var shamsi = ConvertDate.ToShamsiDate(selectedYear, selectedMonth, selectedDay);
            if (shamsi == null) return null;

            return shamsi.Saal;
        }





    }


}
