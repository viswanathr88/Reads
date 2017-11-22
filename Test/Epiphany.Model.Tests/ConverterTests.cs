using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System;

namespace Epiphany.Model.Tests
{
    [TestClass]
    public class ConverterTests
    {
        [TestMethod]
        public void ConvertToIntTest()
        {
            int value = Converter.ToInt("10", 0);
            Assert.IsTrue(value == 10, "ToInt failed");

            value = Converter.ToInt("12.7", 0);
            Assert.IsTrue(value == 0, "ToInt failed");

            value = Converter.ToInt("test", 5);
            Assert.IsTrue(value == 5, "ToInt failed");
        }

        [TestMethod]
        public void ConvertToDoubleTest()
        {
            double d = Converter.ToDouble("12.76", 0);
            Assert.IsTrue(d == 12.76, "d != 12.76");

            d = Converter.ToDouble("10", 0);
            Assert.IsTrue(d == 10.0, "d != 10.0");

            d = Converter.ToDouble("test", 1.5);
            Assert.IsTrue(d == 1.5, "d != 1.5");
        }

        [TestMethod]
        public void ConvertToBoolTest()
        {
            bool value = Converter.ToBool("true", false);
            Assert.IsTrue(value, "true test failed");

            value = Converter.ToBool("True", false);
            Assert.IsTrue(value, "True test failed");

            value = Converter.ToBool("TRUE", false);
            Assert.IsTrue(value, "TRUE test failed");

            value = Converter.ToBool("false", true);
            Assert.IsFalse(value, "false test failed");

            value = Converter.ToBool("False", true);
            Assert.IsFalse(value, "False test failed");

            value = Converter.ToBool("FALSE", true);
            Assert.IsFalse(value, "FALSE test failed");

            value = Converter.ToBool("NotABool", true);
            Assert.IsTrue(value, "NotABool test failed");
        }

        [TestMethod]
        public void ConvertToDateTimeTest()
        {
            DateTime actual = Converter.ToDateTime("3/3/2015");
            DateTime expected = new DateTime(2015, 3, 3);
            Assert.IsTrue(actual == expected, "Dt is not 3/3/2015");

            actual = Converter.ToDateTime("4/25/2015 10:30AM");
            expected = new DateTime(2015, 4, 25, 10, 30, 0);
            Assert.IsTrue(actual == expected, "Dt is not 4/25/2015");
        }
    }
}
