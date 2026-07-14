using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersianDate;

namespace UsageSamples.Tests
{
    [TestClass]
    public class UsageSamplesTests
    {
        [TestMethod]
        public void ToFa_Formats()
        {
            string persianSampleDateString = "1393/08/01 21:53:26";
            DateTime datetime = persianSampleDateString.ToEn();

            Assert.AreEqual("1393/08/01", datetime.ToFa());
            Assert.AreEqual("93/08/01", datetime.ToFa("d"));
            Assert.AreEqual("پنج شنبه, 01 آبان 1393", datetime.ToFa("D"));
            Assert.AreEqual("21:53", datetime.ToFa("t"));
            Assert.AreEqual("21:53:26", datetime.ToFa("T"));
            Assert.AreEqual("93/08/01 21:53", datetime.ToFa("g"));
            Assert.AreEqual("93/08/01 21:53:26", datetime.ToFa("G"));
            Assert.AreEqual("1393/08/01 21:53", datetime.ToFa("f"));
            Assert.AreEqual("پنج شنبه, 01 آبان 1393 ساعت 21:53:26", datetime.ToFa("F"));
            Assert.AreEqual("1 آبان ", datetime.ToFa("m"));
            Assert.AreEqual("اول آبان ", datetime.ToFa("M"));
            Assert.AreEqual("1393 آبان", datetime.ToFa("y"));
            Assert.AreEqual("1393 آبان", datetime.ToFa("Y"));
            Assert.AreEqual("93 آبان ", datetime.ToFa("yy MMM"));
            Assert.AreEqual("1393/08/01 ", datetime.ToFa("yyyy/MM/dd "));
            Assert.AreEqual("93-8-01 ", datetime.ToFa("yy-M-dd "));
            Assert.AreEqual("جمعه 1 آبان 1393", datetime.ToFa("ddd d MMM yyyy"));
            Assert.AreEqual("جمعه اول آبان 1393", datetime.ToFa("ddd D MMM yyyy"));
            Assert.AreEqual("جمعه اول آبان 1393", datetime.ToFaWithTime());
            Assert.AreEqual("1393/08/01 21:00", "1393/08/01 21:00".ToEn().ToFa("YYYY/MM/dd hh:mm"));
        }

        [TestMethod]
        public void ToEn_ParsesVarious()
        {
            Assert.AreEqual("10/23/2014 4:20:00 PM", "1393/08/01 16:210".ToEn().ToString());
            Assert.AreEqual("10/23/2014", "01/8/1393".ToEn().ToShortDateString());
            Assert.AreEqual("Thursday, October 23, 2014", "1/8/1393".ToEn().ToLongDateString());
            Assert.AreEqual("10/23/2014", "1-8-93".ToEn().ToString("d"));
            Assert.AreEqual("Wednesday, October 22, 2014 8:30:00 PM", "93-8-01".ToEn().ToString("U"));
            Assert.AreEqual("October 2014", "93-8-01".ToEn().ToString("y"));
            Assert.AreEqual("Thu 23 Oct 2014", "93 8 01".ToEn().ToString("ddd d MMM yyyy"));
            Assert.AreEqual("10/23/2014 12:00 AM", "1_8_1393 ".ToEn().ToString("g"));
            Assert.AreEqual("Thursday, October 23, 2014 4:20 PM", " 1_8_1393 16:20".ToEn().ToString("f"));
            Assert.AreEqual("Thu, 23 Oct 2014 16:20:48 GMT", " 1.8.1393 16:20:48".ToEn().ToString("R"));
        }
    }
}
