using System;
using System.Collections.Generic;
using System.Globalization;
//using System.Linq;
using System.Text;
using PersianDate;

namespace PersianDate.Standard
{

	public static class ConvertDate
	{
		private static readonly string[] ShamsiMonthNames =
		{
			"فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور",
			"مهر", "آبان", "آذر", "دی", "بهمن", "اسفند"
		};

		private static readonly string[] ShamsiDays =
		{
			"اول" ,"دوم" , "سوم"  , "چهارم"  , "پنجم"  , "ششم"  , "هفتم"  , "هشتم"  , "نهم"  , "دهم"
			, "یازدهم"  , "دوازدهم"  , "سیزدهم"  , "چهاردهم"  , "پانزدهم"  , "شانزدهم"  , "هفدهم"  , "هجدهم"  , "نوزدهم"  , "بیستم"
			, "بیست و یکم"  , "بیست و دوم" , "بیست و سوم" , "بیست و چهارم" , "بیست و پنجم" , "بیست و ششم" , "بیست و هفتم", "بیست و هشتم" , "بیست و نهم" , "سی ام" , "سی و یکم"
		};
		/// <summary>
		/// usually to convert the persian calendar output text and any format starting with 4 digit farsi year
		/// </summary>
		/// <param name="persianDate"></param>
		/// <returns></returns>
		public static DateTime ToEn(this string persianDate)
		{
			if (persianDate.Trim() == "") return DateTime.MinValue;
			int[] farsiPartArray = SplitRoozMahSalNew(persianDate);

			return new PersianCalendar().ToDateTime(farsiPartArray[0], farsiPartArray[1], farsiPartArray[2],
				farsiPartArray[3], farsiPartArray[4], farsiPartArray[5], farsiPartArray[6]);
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
		/// simpler and more powerfull and returns ShamsiDate
		/// </summary>
		/// <param name="farsiDate"></param>
		/// <returns></returns>
		private static int[] SplitRoozMahSalNew(string farsiDate)
		{
			int pYear = 0;
			int pMonth = 0;
			int pDay = 0;
			int pHour = 0;
			int pMins = 0;
			int pSeconds = 0;
			int pMilliSeconds = 0;

			//normalize with one character
			farsiDate = farsiDate.Trim().Replace(@"\", "/").Replace(@"-", "/").Replace(@"_", "/").
				Replace(@",", "/").Replace(@".", "/").Replace(@" ", "/").Replace(@":", "/");

			string[] rawValues = farsiDate.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

			if (!farsiDate.Contains("/"))
			{
				if (rawValues.Length != 2)
					throw new Exception("usually there should be 2 seperator for a complete date");
			}
			else //mostly given in all numeric format like 13930316
			{
				// detect year side and add slashes in right places and continue
			}
			//new simple method which emcompass below methods too
			try
			{
				pYear = int.Parse(rawValues[0].TrimStart(new[] { '0' }).Trim());
				pMonth = int.Parse(rawValues[1].TrimStart(new[] { '0' }).Trim());
				pDay = int.Parse(rawValues[2].TrimStart(new[] { '0' }).Trim());

				if (rawValues.Length >= 4)
					pHour = int.Parse(rawValues[3].TrimStart(new[] { '0' }).Trim());
				if (rawValues.Length >= 5)
					pMins = int.Parse(rawValues[4].TrimStart(new[] { '0' }).Trim());
				if (rawValues.Length >= 6)
					pSeconds = int.Parse(rawValues[5].TrimStart(new[] { '0' }).Trim());
				if (rawValues.Length >= 7)
					pMilliSeconds = int.Parse(rawValues[6].TrimStart(new[] { '0' }).Trim());

				// the year usually must be larger than 90
				//or for historic values rarely lower than 33 if 2 digit is given
				if (pYear < 33 && pYear > 0)
				{
					//swap year and day
					pYear = pDay;
					pDay = int.Parse(rawValues[0]); //convert again
				}
				//fix 2 digits of persian strings
				if (pYear.ToString(CultureInfo.InvariantCulture).Length == 2)
					pYear = pYear + 1300;
				//
				if (pMonth <= 0 || pMonth >= 13)
					throw new Exception("mahe shamsi must be under 12 ");
			}
			catch (Exception ex)
			{
				throw new Exception(
					"invalid Persian date format: maybe all 3 numric Sal, Mah,rooz parts are not present. \r\n" + ex);
			}

			return new[] { pYear, pMonth, pDay, pHour, pMins, pSeconds, pMilliSeconds };
		}

		/// <summary>
		/// it is the main function responsible for analyzing and splitting the given persian date parts 
		/// and then convert back to gregorian date 
		/// </summary>
		/// <param name="farsiDate"></param>
		/// <returns></returns>
		private static int[] SplitRoozMahSal(string farsiDate)
		{
			int year = 0;
			int month = 0;
			int day = 0;

			#region normalization and exception hadling
			//normalize with one character
			farsiDate = farsiDate.Trim().Replace(@"\", "/").Replace(@"-", "/").Replace(@"_", "/").
				Replace(@",", "/").Replace(@".", "/").Replace(@" ", "/");


			string[] rawValues = farsiDate.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);


			if (!farsiDate.Contains("/"))
			{
				if (rawValues.Length != 2)
					throw new Exception("usually there should be 2 seperator for a complete date");
			}
			else //mostly given in all numeric format like 13930316
			{
				// detect year side and add slashes in right places and continue
			}



			//todo: handle if date is given in rtl format like 16/02/1393
			//todo: handle if date is given in short year format like 93/03/16
			//if a number is greater than 31 it is year side 
			//note:only if it is 2 digit there is risk after 1400 it becomes corrupted
			//todo: ()not very usual handle if date is given in very short format like 93/3/16

			#endregion



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

		public static string MapWeekDayToName(DayOfWeek dayOfWeek)
		{
			switch (dayOfWeek)
			{
				case DayOfWeek.Saturday: return MapWeekDayToName(0);
				case DayOfWeek.Sunday: return MapWeekDayToName(1);
				case DayOfWeek.Monday: return MapWeekDayToName(2);
				case DayOfWeek.Tuesday: return MapWeekDayToName(3);
				case DayOfWeek.Wednesday: return MapWeekDayToName(4);
				case DayOfWeek.Thursday: return MapWeekDayToName(5);
				case DayOfWeek.Friday: return MapWeekDayToName(6);
			}
			return "";
		}

		public static int MapWeekDayToNum(DayOfWeek dayOfWeek)
		{
			switch (dayOfWeek)
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


		public static string ToFa(this DateTime? dateTime, string format = "B")
		{
			return !dateTime.HasValue ? string.Empty : dateTime.Value.ToFa(format);
		}

		/// <summary>
		/// nice method from persian calendar project by Nickmehr
		/// </summary>
		/// <param name="dateTime"></param>
		/// <param name="format">d(date short),D t(time short),T f(full),F 
		/// - g,G , m,M y,Y and finally B (1393/07/18)</param>
		/// <returns></returns>
		public static string ToFa(this DateTime dateTime, string format = "B")
		{
			ShamsiDate sd = ToShamsiDate(dateTime);

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
						return string.Format("{0} ساعت {1}", sd.LongDate, sd.ShortTime);
					case "F": // Long date + long time //یکشنبه, 27 مهر 1393 01:15:43
						return string.Format("{0} ساعت {1}", sd.LongDate, sd.LongTime);

					case "g": //Short date + short time //93/07/27 01:14:24
						return string.Format("{0} {1}", sd.ShortDate, sd.ShortTime);
					case "G": //Short date + long time
						return string.Format("{0} {1}", sd.ShortDate, sd.LongTime);

					case "m":
						return string.Format("{0} {1}", sd.RoozeMah, sd.MahName);
					case "M": //Month and day
						return string.Format("{0} {1}", ShamsiDays[sd.RoozeMah - 1] ?? "", sd.MahName);

					case "y":
					case "Y": // year and month
						return string.Format("{0} {1}", sd.Saal, sd.MahName);

					case "B": //best with year and month and day ,simple
						return string.Format("{0}/{1:00}/{2:00}", sd.Saal, sd.Mah, sd.RoozeMah);
					default:
						return sd.ShortDate;
				}
			}
			//important: first replace longer occurances
			return format.Replace("YY", "yy") // because year is not case sensetive
						 .Replace("yyyy", sd.Saal.ToString(CultureInfo.InvariantCulture))
						 .Replace("yy", sd.Saal.ToString(CultureInfo.InvariantCulture).Substring(2, 2))
						 .Replace("MMM", sd.MahName.ToString())
						 .Replace("MM", sd.Mah.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0'))
						 .Replace("M", sd.Mah.ToString(CultureInfo.InvariantCulture))
						 .Replace("D", ShamsiDays[sd.RoozeMah - 1]?.ToString())
						 .Replace("ddd", sd.RoozeHaftehName.ToString())
						 .Replace("dd", sd.RoozeMah.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0'))
						 .Replace("d", sd.RoozeMah.ToString(CultureInfo.InvariantCulture))
						 .Replace("hh", sd.Saat.ToString(CultureInfo.InvariantCulture))
						 .Replace("mm", sd.Daghighe.ToString(CultureInfo.InvariantCulture))
						 .Replace("ss", sd.Saniyeh.ToString(CultureInfo.InvariantCulture));
		}

	}
}
