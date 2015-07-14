using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DomaciRad2Testiranje;

namespace DateUnitTest
{
    [TestClass]
    public class DateTesting
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidProgramException))]
        public void TestWrongYearValue()
        {
            var datum = new Date(0,2,2);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidProgramException))]
        public void TestWrongMonthValue()
        {
            var datum = new Date(2000, 16, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidProgramException))]
        public void TestWrongDayValue()
        {
            var datum = new Date(2000, 5, 70);
        }

        [TestMethod]
        public void TestReturnMonthNameValue()
        {
            var datum = new Date(2001, 6, 1);

            Assert.AreEqual("Lipanj", datum.getMonthName(datum), "6.mjesec je Lipanj");  
        }

        [TestMethod]
        public void TestReturnRemainingDaysValid30Value()
        {
            var datum = new Date(2001, 6, 25);

            Assert.AreEqual(5, datum.getNumberOfRemainingDaysInMonth(datum), "Lipanj ima 30 dana, znaci da je preostali broj dana 5");
        }

        [TestMethod]
        public void TestReturnRemainingDaysValid31Value()
        {
            var datum = new Date(2001, 10, 14);

            Assert.AreEqual(17, datum.getNumberOfRemainingDaysInMonth(datum), "Listopad ima 31 dan, znaci da je preostali broj dana 17");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidProgramException))]
        public void TestReturnRemainingDaysInvalidValue()
        {
            var datum = new Date(2001, 9, 31);

            int brojPreostalihDana = datum.getNumberOfRemainingDaysInMonth(datum);
        }

        [TestMethod]
        public void TestReturnRemainingDaysForLeapYearValidValue()
        {
            var datum = new Date(2000, 2, 25);

            Assert.AreEqual(4, datum.getNumberOfRemainingDaysInMonth(datum), "Krivi izračun broja preostalih dana u prijestupnoj godini i mjesecu Veljači");
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidProgramException))]
        public void TestReturnRemainingDaysForLeapYearInvalidDayValue()
        {
            var datum = new Date(2004, 2, 30);

            int brojPreostalihDana = datum.getNumberOfRemainingDaysInMonth(datum);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidProgramException))]
        public void TestReturnRemainingDaysForNoneLeapYearInvalidDayValue()
        {
            var datum = new Date(2003, 2, 30);

            int brojPreostalihDana = datum.getNumberOfRemainingDaysInMonth(datum);
        }

        [TestMethod]
        public void TestReturnRemainingDaysForNoneLeapYearFebruaryValidValue()
        {
            var datum = new Date(2003, 2, 25);

            Assert.AreEqual(3, datum.getNumberOfRemainingDaysInMonth(datum), "Preostalih dana u neprijestupnoj godini i mjesecu Veljači nakon 25. dana treba biti 3");
        }

    }
}
