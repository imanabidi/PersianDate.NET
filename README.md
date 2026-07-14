# PersianDate.NET

A lightweight (~17 KB) Persian (Shamsi / Jalali) date converter for .NET, written in C# and targeting **.NET Framework 4.8**.

Install from NuGet: https://www.nuget.org/packages/PersianDate/

```powershell
Install-Package PersianDate
```

## Features

- Converts Gregorian dates to Persian and Persian date strings back to Gregorian.
- Detects, normalizes and corrects a given Persian date string, assuming the default input is in `yyyy/mm/dd` format (e.g. `1393/07/18`).
- Tolerant parsing — handles extra spaces and different separators (`/`, `-`, `_`, `.`, `,`, `:`) and 2-digit years.
- Built on the standard `System.Globalization.PersianCalendar` for all conversions.
- Short, static method names (`ToFa` / `ToEn`) that work as extension methods on `DateTime`, `DateTime?` and `string`.
- Standard-style format strings (`d`, `D`, `t`, `T`, `f`, `F`, `g`, `G`, `m`, `M`, `y`, `Y`, `B`) plus custom patterns (`yyyy/MM/dd`, `ddd d MMM yyyy`, ...).

## When to use it

If you use a jQuery/JavaScript Persian date picker on the UI side, such as:

- http://hasheminezhad.com/datepicker
- https://github.com/behzadi/persianDatepicker
- http://babakhani.github.io/PersianWebToolkit/datepicker.html

then you typically need to:

- Convert the Persian date string coming from the UI back to a Gregorian `DateTime` before saving it to the database.
- Convert a Gregorian `DateTime` back to a Persian string when displaying it in the UI.

`PersianDate.NET` provides the conversion helpers for both directions.

## Quick start

```csharp
using PersianDate;

// Persian string -> DateTime
DateTime date = "1393/08/01 21:53:26".ToEn();

// DateTime -> Persian string (default "B" format)
string persian = date.ToFa(); // 1393/08/01
```

## Formatting: `DateTime.ToFa(format)`

`ToFa` accepts a single-letter standard format or a custom pattern. The default is `"B"`.

```csharp
DateTime datetime1 = "1393/08/01 21:53:26".ToEn();

// default format
datetime1.ToFa();      // 1393/08/01

// date only (short "d", long "D")
datetime1.ToFa("d");   // 93/08/01
datetime1.ToFa("D");   // پنج شنبه, 01 آبان 1393

// time only (short "t", long "T")
datetime1.ToFa("t");   // 21:53
datetime1.ToFa("T");   // 21:53:26

// short date + time
datetime1.ToFa("g");   // 93/08/01 21:53
datetime1.ToFa("G");   // 93/08/01 21:53:26

// full date + time
datetime1.ToFa("f");   // پنج شنبه, 01 آبان 1393 ساعت 21:53
datetime1.ToFa("F");   // پنج شنبه, 01 آبان 1393 ساعت 21:53:26

// month and day only
datetime1.ToFa("m");   // 1 آبان
datetime1.ToFa("M");   // اول آبان

// year and month only
datetime1.ToFa("y");   // 1393 آبان
datetime1.ToFa("Y");   // 1393 آبان
```

### Custom format patterns

Combine tokens as you wish:

```csharp
datetime1.ToFa("yy MMM");          // 93 آبان
datetime1.ToFa("yyyy/MM/dd");      // 1393/08/01
datetime1.ToFa("yy-M-dd");         // 93-8-01
datetime1.ToFa("ddd d MMM yyyy");  // جمعه 1 آبان 1393
datetime1.ToFa("ddd D MMM yyyy");  // جمعه اول آبان 1393
```

| Token  | Meaning                                   |
|--------|-------------------------------------------|
| `yyyy` | 4-digit year (1393)                       |
| `yy`   | 2-digit year (93)                         |
| `MMM`  | Month name (آبان)                         |
| `MM`   | 2-digit month (08)                        |
| `M`    | Month number (8)                          |
| `dd`   | 2-digit day of month (01)                 |
| `d`    | Day of month (1)                          |
| `ddd`  | Day-of-week name (جمعه)                   |
| `D`    | Day of month as words (اول)               |
| `hh`   | 2-digit hour                              |
| `mm`   | 2-digit minute                            |
| `ss`   | 2-digit second                            |

## Parsing: `string.ToEn()`

`ToEn` converts a Persian date string to a Gregorian `DateTime`. It normalizes separators and extra spaces, and corrects 2-digit years automatically.

```csharp
"1393/08/01 16:20".ToEn();                      // 10/23/2014 4:20:00 PM
"01/8/1393".ToEn().ToShortDateString();         // 10/23/2014
"1/8/1393".ToEn().ToLongDateString();           // Thursday, October 23, 2014

// standard and custom .NET DateTime format strings after conversion
// https://docs.microsoft.com/dotnet/standard/base-types/standard-date-and-time-format-strings
"1-8-93".ToEn().ToString("d");                  // 10/23/2014            (short date)
"93-8-01".ToEn().ToString("U");                 // Wednesday, October 22, 2014 8:30:00 PM
"93-8-01".ToEn().ToString("y");                 // October 2014          (year month)
"93 8 01".ToEn().ToString("ddd d MMM yyyy");    // Thu 23 Oct 2014

// extra spaces and different separators are handled
"1_8_1393 ".ToEn().ToString("g");               // 10/23/2014 12:00 AM
" 1_8_1393 16:20".ToEn().ToString("f");         // Thursday, October 23, 2014 4:20 PM
" 1.8.1393 16:20:48".ToEn().ToString("R");      // Thu, 23 Oct 2014 16:20:48 GMT
```

You can also convert from separate numeric parts:

```csharp
DateTime d = ConvertDate.ToEn(1393, 8, 1); // year, month, day
```

## Helper utilities: `DateAndTimeH`

Convenience helpers for common UI scenarios (drop-downs, footers, spans):

```csharp
using PersianDate;

DateAndTimeH.CurrentFarsiDate;      // e.g. "93/08/01"
DateAndTimeH.CurrentFarsiSalNum;    // current Shamsi year
DateAndTimeH.CurrentFarsiMahNum;    // current Shamsi month

DateAndTimeH.SaalNum(DateTime.Now); // Shamsi year of a date
DateAndTimeH.MahNum(DateTime.Now);  // Shamsi month of a date
DateAndTimeH.RoozNum(DateTime.Now); // Shamsi day-of-month of a date

DateAndTimeH.GetAllFarsiMonths();          // Dictionary<name, number> of the 12 months
DateAndTimeH.GetAllFarsiYearsFromMinDate(); // list of Shamsi years from a minimum date to now

// human-readable remaining/elapsed time in Persian
DateAndTimeH.MandehFa(someFutureDate);      // e.g. "3 روز  2 ساعت"
```

## License

See the repository for license details.
