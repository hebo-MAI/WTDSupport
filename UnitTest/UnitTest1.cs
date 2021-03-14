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

        [TestMethod]
        public void LfoTest()
        {
            var input = "@lfo 0, 0, 1, 0, 1";
            var expected = "m 0, 0, 1, 0, 1";
            var reader = new MMLReader(input);
            Assert.AreEqual(expected, reader.GetMMLString());
        }

        [TestMethod]
        public void LineCommentTest1()
        {
            var input = "abc// comment";
            var expected = "abc";
            var reader = new MMLReader(input);
            Assert.AreEqual(expected, reader.GetMMLString());
        }

        [TestMethod]
        public void LineCommentTest2()
        {
            var input = @"abc// comment
";
            var expected = @"abc
";
            var reader = new MMLReader(input);
            Assert.AreEqual(expected, reader.GetMMLString());
        }

        [TestMethod]
        public void AreaCommentTest1()
        {
            var input = "abc/*test*/de";
            var expected = "abcde";
            var reader = new MMLReader(input);
            Assert.AreEqual(expected, reader.GetMMLString());
        }

        [TestMethod]
        public void AreaCommentTest2()
        {
            var input = @"abc/* comment 1
comment 2*/de";
            var expected = "abcde";
            var reader = new MMLReader(input);
            Assert.AreEqual(expected, reader.GetMMLString());
        }

        [TestMethod]
        public void AreaCommentTest3()
        {
            var input = "a/*a*/b/*b*/c/*c*/d";
            var expected = "abcd";
            var reader = new MMLReader(input);
            Assert.AreEqual(expected, reader.GetMMLString());
        }
    }
}
