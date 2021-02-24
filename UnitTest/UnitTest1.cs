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
            var input = "ab<cdefgab(a)g";
            var reader = new MMLReader(input);
            Assert.AreEqual(input, reader.GetMMLString());
        }

        [TestMethod]
        public void OctaveReverseTest()
        {
            var input = "#REVERSE\nab<cdefgab";
            var expected = "\nab>cdefgab";
            var reader = new MMLReader(input);
            Assert.AreEqual(expected, reader.GetMMLString());
        }

        [TestMethod]
        public void VolumeReverseTest()
        {
            var input = "#REVERSE\na(a)a";
            var expected = "\na)a(a";
            var reader = new MMLReader(input);
            Assert.AreEqual(expected, reader.GetMMLString());
        }
    }
}
