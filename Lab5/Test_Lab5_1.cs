using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Test_Lab5_1
{
    [TestClass]
    public class Test_Lab5_1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int x;
            int[] arr = new int[] { 14, 53, 9, 75, 11, 40 };

            x = Lab5_1.Conference.longparticipant(arr);
            Assert.AreEqual(x, 3);
        }
    }
}
