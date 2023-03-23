namespace Test_Lab2_3_A
{
    [TestClass]
    public class Test_Lab2_3_A
    {
        [TestMethod]
        public void TestMethod1()
        {
            int n = 10;
            int[] a = new int[10] { 3, 5, 0, 7, -5, 9, 0, 1, 0, 3 };
            int max = Lab2_3_A.Lab2_3_A.Find_Max(a);
            int s = Lab2_3_A.Lab2_3_A.Find_Sum(n, a);
            Assert.AreEqual(9, max);
            Assert.AreEqual(22, s);
        }
    }
}