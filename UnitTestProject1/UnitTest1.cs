using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CLR_HW_Project;
using System.Text;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestStringFormatHelper()
        {
            var str = new StringBuilder();
            var sep = ";";
            str.Append("Майя").Append(sep);
            str.Append("Иван").Append(sep);
            str.Append("Маруся").Append(sep);
            Assert.AreEqual("Майя;Иван;Маруся", StringFormatHelper.RemoveLastSeparator(str, sep.Length));
        }
    }
}
