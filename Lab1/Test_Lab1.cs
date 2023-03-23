namespace Test_Lab1
{
    [TestClass]
    public class Test_Lab1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int a = 1, b = 2, c = 3, S, V;

            V = Lab1.Lab1.Example_V(a, b, c);
            Assert.AreEqual(6, V);
            S = Lab1.Lab1.Example_S(a, b, c);
            Assert.AreEqual(22, S);
        }
    }
}