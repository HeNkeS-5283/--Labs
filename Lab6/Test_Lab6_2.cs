using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Test_Lab6_2
{
    [TestClass]
    public class Test_Lab6_2
    {
        [TestMethod]
        public void TestMethod1()
        {
            int x;
            int[] arr = new int[] { 14, 53, 9, 75, 11, 40 };
            Lab6_2.Conference conference = new Lab6_2.Conference();
            x = conference.longparticipant(arr);
            Assert.AreEqual(x, 4);
        }
    }
}
