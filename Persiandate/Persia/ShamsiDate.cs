using System;


namespace PersianDate.Persia
{
    internal class ShamsiDate
    {

        public ShamsiDate(DateTime date)
        {
            var pDate = new System.Globalization.PersianCalendar();

            Saal = pDate.GetYear(date);
            Mah = pDate.GetMonth(date);
            RoozEMah = pDate.GetDayOfMonth(date);
            //time  
            Saat = pDate.GetHour(date);
            Daghighe = pDate.GetMinute(date);
            Saniyeh = pDate.GetSecond(date);

            RoozeHafteh = ConvertDate.MapWeekDayToNum(pDate.GetDayOfWeek(date));
        }

        #region properties
        public string RoozeHaftehName
        {
            get
            {
                if (RoozeHafteh >= 0 && RoozeHafteh <= 6)
                    return ConvertDate.MapWeekDayToName(RoozeHafteh);
                return "";
            }
        }
        public string MahName
        {
            get
            {
                if (Mah > 0 && Mah < 13)
                    return ConvertDate.MapFarsiMonthNumToName(Mah);
                return "";
            }
        }
        private string TimeSymbol
        {
            get
            {
                return (Saat / 12 == 1 ? "عصر" : "صبح");
            }
        }
        private string TimeSymbolShort
        {
            get
            {
                return (Saat / 12 == 1 ? "ص" : "ع");
            }
        }
        public string ShortDate
        {
            get
            {
                var shortSal = Saal.ToString().Remove(0,2);

                return string.Format("{0}/{1:00}/{2:00}",shortSal, Mah, RoozEMah);

            }
        }
        public string ShortTime
        {
            get
            {
                return string.Format("{0:00}:{1:00}", Saat, Daghighe);

            }
        }
        public string LongDate
        {
            get
            {
                return string.Format("{0}, {1:00} {2} {3}", RoozeHaftehName, RoozEMah, MahName, Saal);
            }
        }
        public string LongTime
        {
            get
            {
                return string.Format("{0:00}:{1:00}:{2:00}", Saat, Daghighe, Saniyeh);

            }
        }

        public int RoozeHafteh { get; private set; }
        public int RoozEMah { get; private set; }
        public int Mah { get; private set; }
        public int Saal { get; private set; }
        public int Saat { get; private set; }
        public int Daghighe { get; private set; }
        public int Saniyeh { get; private set; }
        #endregion
    }
}

