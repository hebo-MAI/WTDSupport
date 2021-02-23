using Microsoft.VisualStudio.TestTools.UnitTesting;
using WTDSupport;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = "ab<cdefgab";
            var reader = new MMLReader(input);
            Assert.AreEqual(input, reader.GetMMLString());
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = "#OCTAVE REVERSE\nab<cdefgab";
            var expected = "\nab>cdefgab";
            var reader = new MMLReader(input);
            Assert.AreEqual(expected, reader.GetMMLString());
        }
    }
}
