using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yosua_1302210126;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        

        [TestMethod]
        public void TestMethod2()
        {
            berbagiTautan obj = new berbagiTautan();

            bool hasil = obj.kepastian("YES");
            Assert.IsTrue(hasil);

            bool hasil2 = obj.kepastian("NO");
            Assert.IsFalse(hasil2);

        }
    }
}